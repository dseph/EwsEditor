// OofForm.cs
// Used to read and set out of office (OOF) settings for a user.

namespace EWSEditor.Forms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    using EWSEditor.Common;
    using EWSEditor.Forms.Controls;
    using EWSEditor.PropertyInformation;

    using Microsoft.Exchange.WebServices.Data;

    /// <summary>
    /// OofForm - Excercises the GetUserOofSettings and SetUserOofSettings
    /// EWS method calls.
    /// </summary>
    public partial class OofForm : DialogForm
    {
        private EnumComboBox<OofExternalAudience> externalAudienceCombo = new EnumComboBox<OofExternalAudience>();

        private OofSettings originalOofSettings = null;

        private OofForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the mailbox to retrieve OOF settings from.
        /// </summary>
        public Mailbox TargetMailbox
        {
            get
            {
                if (String.IsNullOrEmpty(this.TargetMailboxText.Text))
                {
                    return null;
                }
                else
                {
                    return new Mailbox(this.TargetMailboxText.Text);
                }
            }

            set
            {
                if (value != null)
                {
                    this.TargetMailboxText.Text = value.Address;
                }
                else
                {
                    this.TargetMailboxText.Text = string.Empty;
                }
            }
        }

        /// <summary>
        /// Show the form used to display and edit OofSettings on the 
        /// default mailbox.
        /// </summary>
        /// <param name="service">ExchangeService to use to make calls.</param>
        public static void ShowDialog(ExchangeService service)
        {
            ShowDialog(service, null);
        }

        /// <summary>
        /// Show the form used to display and edit OofSettings on the 
        /// given mailbox.
        /// </summary>
        /// <param name="service">ExchangeService to use to make calls.</param>
        /// <param name="targetMbx">Mailbox to retrieve OOF settings from</param>
        public static void ShowDialog(ExchangeService service, Mailbox targetMbx)
        {
            // Can't do anything without an ExchangeService
            if (service == null)
            {
                throw new ApplicationException("ExchangeService cannot be null!");
            }

            OofForm dialog = new OofForm();
            dialog.TargetMailbox = targetMbx;
            dialog.CurrentService = service;

            dialog.ShowDialog();
        }

        #region Event Methods

        /// <summary>
        /// Load the dialog with the current delegate settings
        /// by calling RefreshDelegates()
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void OofForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // Setup EnumComboBox controls
                this.externalAudienceCombo.TransformComboBox(this.TempExternalAudienceCombo);
                this.externalAudienceCombo.HasEmptyItem = true;

                this.InitializeFormOofSettings();

                // If we have a mailbox preload the settings
                if (this.TargetMailbox != null) 
                {
                    this.DisplayOofSettings(); 
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Display the ResolveNamesDialog to get a mailbox SMTP address
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void ResolveTargetButton_Click(object sender, EventArgs e)
        {
            NameResolution principal = null;
            DialogResult res = ResolveNameDialog.ShowDialog(this.CurrentService, out principal);

            // If no name is returned or dialog result wasn't okay then bailout
            if (res != DialogResult.OK || principal == null)
            {
                return;
            }

            this.TargetMailbox = new Mailbox(principal.Mailbox.Address);
        }

        /// <summary>
        /// Get the OOF settings by passing the target mailbox specified 
        /// in txtTarget
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void GetOofButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // If there is no target mailbox then there's nothing to do
                if (this.TargetMailbox == null)
                {
                    ErrorDialog.ShowWarning("A target mailbox must be specified before calling GetUserOofSettings.");
                    return;
                }

                this.InitializeFormOofSettings();

                this.DisplayOofSettings();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// If the OofSettings have been changed call SetUserOofSettings to
        /// update them.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void OkButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // If there's no OofSettings loaded then do nothing
                if (this.originalOofSettings == null)
                {
                    return;
                }

                // If the current and original OofSettings are the same do nothing
                if (ComparisonHelper.IsEqual(this.originalOofSettings, this.GetFormOofSettings()))
                {
                    return;
                }

                this.CurrentService.SetUserOofSettings(this.TargetMailbox.Address, this.GetFormOofSettings());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OofDisabledOption_CheckedChanged(object sender, EventArgs e)
        {
            if (this.OofDisabledOption.Checked)
            {
                this.EnableControlsForOofState(OofState.Disabled);
            }
        }

        private void OofEnabledOption_CheckedChanged(object sender, EventArgs e)
        {
            if (this.OofEnabledOption.Checked)
            {
                this.EnableControlsForOofState(OofState.Enabled);
            }
        }

        private void OofScheduledCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (this.OofScheduledCheck.Checked)
            {
                this.EnableControlsForOofState(OofState.Scheduled);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Certain controls need to be enabled or disabled depending on the 
        /// selected OofState.
        /// </summary>
        /// <param name="state">OofState for the form to display</param>
        private void EnableControlsForOofState(OofState state)
        {
            // Both Scheduled and Enabled mean that OOF is enabled
            bool isEnabled = state == OofState.Enabled || state == OofState.Scheduled;
            
            this.OofScheduledCheck.Enabled = isEnabled;
            this.InternalReplyText.ReadOnly = !isEnabled;
            this.InternalReplyCulture.Enabled = isEnabled;
            this.InternalReplyCultureLabel.Enabled = isEnabled;
            this.ExternalReplyText.ReadOnly = !isEnabled;
            this.ExternalReplyCulture.Enabled = isEnabled;
            this.ExternalReplyCultureLabel.Enabled = isEnabled;
            this.externalAudienceCombo.Enabled = isEnabled;
            this.ExternalAudienceLabel.Enabled = isEnabled;

            // Greying out the text boxes when ReadOnly is more intuitive
            System.Drawing.Color textBoxColor = isEnabled ?
                System.Drawing.Color.FromKnownColor(KnownColor.Window) :
                System.Drawing.Color.FromKnownColor(KnownColor.Control);
            this.InternalReplyText.BackColor = textBoxColor;
            this.ExternalReplyText.BackColor = textBoxColor;

            // Set these controls specific to the Scheduled state
            bool isScheduled = state == OofState.Scheduled;
            this.ScheduleStartTimeLabel.Enabled = isScheduled;
            this.ScheduledStartTime.Enabled = isScheduled;
            this.ScheduleEndTimeLabel.Enabled = isScheduled;
            this.ScheduledEndTime.Enabled = isScheduled;
        }

        /// <summary>
        /// Set form controls to an initial state
        /// </summary>
        private void InitializeFormOofSettings()
        {
            // Start form in OOF disabled state
            this.OofDisabledOption.Checked = true;
            this.EnableControlsForOofState(OofState.Disabled);

            this.externalAudienceCombo.SelectedItem = null;
            this.ScheduledStartTime.Value = DateTimePicker.MinimumDateTime;
            this.ScheduledEndTime.Value = DateTimePicker.MinimumDateTime;
            this.ExternalReplyCulture.Text = string.Empty;
            this.ExternalReplyText.Text = string.Empty;
            this.InternalReplyCulture.Text = string.Empty;
            this.InternalReplyText.Text = string.Empty;
            this.OofSettingsGroup.Text = "OOF Settings";
        }

        /// <summary>
        /// Convert the current form control values into OofSettings
        /// </summary>
        /// <returns> OofSettings created from the form control values</returns>
        private OofSettings GetFormOofSettings()
        {
            // Gather new OOF settings
            OofSettings newOof = new OofSettings();

            DateTime startTime = new DateTime(
                this.ScheduledStartTime.Value.Year,
                this.ScheduledStartTime.Value.Month,
                this.ScheduledStartTime.Value.Day,
                this.ScheduledStartTime.Value.Hour,
                this.ScheduledStartTime.Value.Minute,
                this.ScheduledStartTime.Value.Second);

            DateTime endTime = new DateTime(
                this.ScheduledEndTime.Value.Year,
                this.ScheduledEndTime.Value.Month,
                this.ScheduledEndTime.Value.Day,
                this.ScheduledEndTime.Value.Hour,
                this.ScheduledEndTime.Value.Minute,
                this.ScheduledEndTime.Value.Second);

            newOof.Duration = new TimeWindow(startTime, endTime);

            OofExternalAudience? audience = this.externalAudienceCombo.SelectedItem;
            if (audience.HasValue)
            {
                newOof.ExternalAudience = audience.Value;
            }

            newOof.ExternalReply = new OofReply();
            if (!String.IsNullOrEmpty(this.ExternalReplyText.Text))
            {
                newOof.ExternalReply.Culture = this.ExternalReplyCulture.Text;
                newOof.ExternalReply.Message = this.ExternalReplyText.Text;
            }

            newOof.InternalReply = new OofReply();
            if (!String.IsNullOrEmpty(this.InternalReplyText.Text))
            {
                newOof.InternalReply.Culture = this.InternalReplyCulture.Text;
                newOof.InternalReply.Message = this.InternalReplyText.Text;
            }

            // OofState can only be Disabled, Enabled, or Scheduled.  Since this is
            // displayed on the between three controls order is important here.  If
            // OofDisabledOption is checked then we are disabled, even though
            // OofScheduledCheck could be checked too.  If OofScheduledCheck is checked
            // then the state is Scheduled, even though OofEnabledOption could be
            // checked too.
            if (this.OofDisabledOption.Checked)
            {
                newOof.State = OofState.Disabled;
            }
            else if (this.OofScheduledCheck.Checked)
            {
                newOof.State = OofState.Scheduled;
            }
            else if (this.OofEnabledOption.Checked)
            {
                newOof.State = OofState.Enabled;
            }

            return newOof;
        }

        /// <summary>
        /// Call GetUserOofSettings to get OOF of the target mailbox and display
        /// settings in the form controls.
        /// </summary>
        private void DisplayOofSettings()
        {
            // Get OOF settings
            this.originalOofSettings = this.CurrentService.GetUserOofSettings(this.TargetMailbox.Address);
            this.DisplayOofSettings(this.originalOofSettings);
        }

        /// <summary>
        /// Display the given OofSettings in the form controls.
        /// </summary>
        /// <param name="settings">OofSettings to display in the form</param>
        private void DisplayOofSettings(OofSettings settings)
        {
            // Convert the OOF settings to control values
            switch (this.originalOofSettings.State)
            {
                case OofState.Disabled:
                    this.OofDisabledOption.Checked = true;
                    this.OofEnabledOption.Checked = false;
                    this.OofScheduledCheck.Checked = false;
                    break;
                case OofState.Enabled:
                    this.OofEnabledOption.Checked = true;
                    this.OofDisabledOption.Checked = false;
                    this.OofScheduledCheck.Checked = false;
                    break;
                case OofState.Scheduled:
                    this.OofEnabledOption.Checked = true;
                    this.OofScheduledCheck.Checked = true;
                    this.OofDisabledOption.Checked = false;
                    break;
            }

            this.EnableControlsForOofState(settings.State);

            this.externalAudienceCombo.SelectedItem = this.originalOofSettings.ExternalAudience;

            this.ScheduledStartTime.Value = this.originalOofSettings.Duration.StartTime;
            this.ScheduledEndTime.Value = this.originalOofSettings.Duration.EndTime;

            this.ExternalReplyCulture.Text = this.originalOofSettings.ExternalReply.Culture;
            this.ExternalReplyText.Text = this.originalOofSettings.ExternalReply.Message;

            this.InternalReplyCulture.Text = this.originalOofSettings.InternalReply.Culture;
            this.InternalReplyText.Text = this.originalOofSettings.InternalReply.Message;

            // Display the target mailbox address in the group box text
            this.OofSettingsGroup.Text = string.Format("OOF Settings for '{0}'", this.TargetMailbox.Address);
        }

        #endregion

        private void OofSettingsGroup_Enter(object sender, EventArgs e)
        {

        }
    }
}
