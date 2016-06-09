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

    using Microsoft.Exchange.WebServices.Data;

    public partial class AttendeeInfoDialog : DialogForm
    {
        private MeetingAttendeeType defaultAttendeeType = MeetingAttendeeType.Required;
        private EmailAddress defaultAddress = null;
        private AttendeeInfo currentAttendee = null;

        private EnumComboBox<MeetingAttendeeType> attendeeTypeCombo = new EnumComboBox<MeetingAttendeeType>();

        private AttendeeInfoDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Show a dialog to allow the user to input settings to
        /// create an AttendeeInfo object from the given information.
        /// </summary>
        /// <param name="address">Default address to preload in the form</param>
        /// <param name="attendeeType">Default MeetingAttendeeType to preload in the form</param>
        /// <param name="attendee">Output parameter representing the AttendeeInfo created 
        /// from the dialog settings.</param>
        /// <returns>
        /// Returns DialogResult.OK if the user clicked OK and the
        /// AttendeeInfo was created successfully.
        /// </returns>
        public static DialogResult ShowDialog(
            ExchangeService service,
            EmailAddress address, 
            MeetingAttendeeType attendeeType,
            out AttendeeInfo attendee)
        {
            AttendeeInfo newAttendee = null;
            DialogResult result = AttendeeInfoDialog.ShowDialog(service, address, attendeeType, out newAttendee);

            if (result == DialogResult.OK &&
                newAttendee != null)
            {
                attendee = newAttendee;
            }
            else
            {
                attendee = null;
            }

            return result;
        }

        /// <summary>
        /// Show a dialog to allow the user to input settings to
        /// create an AttendeeInfo object.
        /// </summary>
        /// <param name="attendee">
        /// Out parameter representing the AttendeeInfo created
        /// from the dialog settings.
        /// </param>
        /// <returns>
        /// Returns DialogResult.OK if the user clicked OK and the
        /// AttendeeInfo was created successfully.
        /// </returns>
        public static DialogResult ShowDialog(ExchangeService service, out AttendeeInfo attendee)
        {
            AttendeeInfo newAttendee = null;
            DialogResult result = AttendeeInfoDialog.ShowDialog(service, null, null, out newAttendee);

            if (result == DialogResult.OK &&
                newAttendee != null)
            {
                attendee = newAttendee;
            }
            else
            {
                attendee = null;
            }

            return result;
        }

        private static DialogResult ShowDialog(
            ExchangeService service,
            EmailAddress address,
            MeetingAttendeeType? attendeeType, 
            out AttendeeInfo attendee)
        {
            if (service == null)
            {
                throw new ArgumentNullException("service", ExceptionHelper.ExchangeServiceRequiredMessage);
            }
            AttendeeInfoDialog dialog = new AttendeeInfoDialog();
            dialog.CurrentService = service;

            if (attendeeType.HasValue)
            {
                dialog.defaultAttendeeType = attendeeType.Value;
            }

            if (address != null)
            {
                dialog.defaultAddress = address;
            }

            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK &&
                dialog.currentAttendee != null)
            {
                attendee = dialog.currentAttendee;
            }
            else
            {
                attendee = null;
            }

            return result;
        }

        #region Event Methods

        private void AttendeeInfoDialog_Load(object sender, EventArgs e)
        {
            // Load the combo box and set the default selected value
            this.attendeeTypeCombo.TransformComboBox(this.TempAttendeeTypeCombo);
            this.attendeeTypeCombo.SelectedItem = this.defaultAttendeeType;

            // Preset the SMTP address text box if available
            if (this.defaultAddress != null &&
                !String.IsNullOrEmpty(this.defaultAddress.Address))
            {
                this.SmtpAddressText.Text = this.defaultAddress.Address;
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            AttendeeInfo attendee = new AttendeeInfo();

            if (String.IsNullOrEmpty(this.SmtpAddressText.Text))
            {
                ErrorDialog.ShowWarning("An SMTP address is required in order to create an AttendeeInfo object.");
                return;
            }
            else
            {
                attendee.SmtpAddress = this.SmtpAddressText.Text;
            }

            if (this.attendeeTypeCombo.SelectedItem.HasValue)
            {
                attendee.AttendeeType = this.attendeeTypeCombo.SelectedItem.Value;
            }

            attendee.ExcludeConflicts = this.ExcludeConflictsCheck.Checked;

            this.currentAttendee = attendee;
        }

        private void ResolveNamesButton_Click(object sender, EventArgs e)
        {
            NameResolution name = null;
            if (ResolveNameDialog.ShowDialog(this.CurrentService, out name) == DialogResult.OK)
            {
                if (name.Mailbox != null)
                {
                    this.SmtpAddressText.Text = name.Mailbox.Address;
                }
            }
        }

        #endregion
    }
}
