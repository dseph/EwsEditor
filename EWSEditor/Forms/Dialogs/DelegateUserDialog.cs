namespace EWSEditor.Forms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    using EWSEditor.Common;
    using EWSEditor.Diagnostics;
    using EWSEditor.Forms.Controls;

    using Microsoft.Exchange.WebServices.Data;

    public partial class DelegateUserDialog : EWSEditor.Forms.DialogForm
    {
        private DelegateUser delegateUser = null;

        private EnumComboBox<DelegateFolderPermissionLevel> calendarPermissionComboBox = new EnumComboBox<DelegateFolderPermissionLevel>();
        private EnumComboBox<DelegateFolderPermissionLevel> contactsPermissionComboBox = new EnumComboBox<DelegateFolderPermissionLevel>();
        private EnumComboBox<DelegateFolderPermissionLevel> inboxPermissionComboBox = new EnumComboBox<DelegateFolderPermissionLevel>();
        private EnumComboBox<DelegateFolderPermissionLevel> journalPermissionComboBox = new EnumComboBox<DelegateFolderPermissionLevel>();
        private EnumComboBox<DelegateFolderPermissionLevel> notesPermissionComboBox = new EnumComboBox<DelegateFolderPermissionLevel>();
        private EnumComboBox<DelegateFolderPermissionLevel> tasksPermissionComboBox = new EnumComboBox<DelegateFolderPermissionLevel>();

        private DelegateUserDialog()
        {
            InitializeComponent();
        }

        #region Properties

        /// <summary>
        /// Gets or sets an value indicating the DelegateUser object represented
        /// by the form control values.
        /// </summary>
        private DelegateUser DelegateUser
        {
            get
            {
                if (this.delegateUser != null)
                {
                    this.delegateUser.ReceiveCopiesOfMeetingMessages = this.DelegateReceivesCopyCheck.Checked;
                    this.delegateUser.ViewPrivateItems = this.PrivateItemsCheck.Checked;

                    this.delegateUser.Permissions.CalendarFolderPermissionLevel = this.calendarPermissionComboBox.SelectedItem.Value;
                    this.delegateUser.Permissions.ContactsFolderPermissionLevel = this.contactsPermissionComboBox.SelectedItem.Value;
                    this.delegateUser.Permissions.InboxFolderPermissionLevel = this.inboxPermissionComboBox.SelectedItem.Value;
                    this.delegateUser.Permissions.JournalFolderPermissionLevel = this.journalPermissionComboBox.SelectedItem.Value;
                    this.delegateUser.Permissions.NotesFolderPermissionLevel = this.notesPermissionComboBox.SelectedItem.Value;
                    this.delegateUser.Permissions.TasksFolderPermissionLevel = this.tasksPermissionComboBox.SelectedItem.Value;
                }

                return this.delegateUser;
            }

            set
            {
                if (value != null)
                {
                    // Copy the values of the DelegateUser to a new object
                    if (!String.IsNullOrEmpty(value.UserId.PrimarySmtpAddress))
                    {
                        this.delegateUser = new DelegateUser(value.UserId.PrimarySmtpAddress);
                    }
                    else if (value.UserId.StandardUser.HasValue)
                    {
                        this.delegateUser = new DelegateUser(value.UserId.StandardUser.Value);
                    }
                    else
                    {
                        throw new ArgumentException("DelegateUser must have a PrimarySmtpAddress or StandardUser value.");
                    }

                    this.delegateUser.Permissions.CalendarFolderPermissionLevel = value.Permissions.CalendarFolderPermissionLevel;
                    this.delegateUser.Permissions.ContactsFolderPermissionLevel = value.Permissions.ContactsFolderPermissionLevel;
                    this.delegateUser.Permissions.InboxFolderPermissionLevel = value.Permissions.InboxFolderPermissionLevel;
                    this.delegateUser.Permissions.JournalFolderPermissionLevel = value.Permissions.JournalFolderPermissionLevel;
                    this.delegateUser.Permissions.NotesFolderPermissionLevel = value.Permissions.NotesFolderPermissionLevel;
                    this.delegateUser.Permissions.TasksFolderPermissionLevel = value.Permissions.TasksFolderPermissionLevel;
                    this.delegateUser.ReceiveCopiesOfMeetingMessages = value.ReceiveCopiesOfMeetingMessages;
                    this.delegateUser.ViewPrivateItems = value.ViewPrivateItems;
                }
                else
                {
                    this.delegateUser = null;
                }

                this.SetFormControlsForDelegateUser(this.delegateUser);
            }
        }

        #endregion

        #region Static Methods

        public static DialogResult ShowDialog(ExchangeService service, ref DelegateUser user)
        {
            DelegateUserDialog diag = new DelegateUserDialog();
            diag.CurrentService = service;
            diag.DelegateUser = user;

            DialogResult res = diag.ShowDialog();
            if (res == DialogResult.OK)
            {
                user = diag.DelegateUser;
            }

            return res;
        }

        #endregion

        #region Event Methods

        private void DelegateUserDialog_Load(object sender, EventArgs e)
        {
            // Convert simple ComboBoxes to EnumComboBoxes and initialize them
            this.calendarPermissionComboBox.TransformComboBox(this.TempCalendarPermissionComboBox);
            this.contactsPermissionComboBox.TransformComboBox(this.TempContactsPermissionComboBox);
            this.inboxPermissionComboBox.TransformComboBox(this.TempInboxPermissionComboBox);
            this.journalPermissionComboBox.TransformComboBox(this.TempJournalPermissionComboBox);
            this.notesPermissionComboBox.TransformComboBox(this.TempNotesPermissionComboBox);
            this.tasksPermissionComboBox.TransformComboBox(this.TempTasksPermissionComboBox);

            // If a DelegateUser is already set then don't allow changing the UserId
            // and initialize the form controls to the value of this DelegateUser
            if (this.DelegateUser != null)
            {
                this.GetUserIdButton.Enabled = false;
            }
        }

        private void GetUserIdButton_Click(object sender, EventArgs e)
        {
            UserId delegateUserId = null;

            if (UserIdDialog.ShowDialog(this.CurrentService, ref delegateUserId) != DialogResult.OK)
            {
                // If the UserIdDialog does not return OK then do nothing
                TraceHelper.WriteVerbose("UserIdDialog did not return OK");
                return;
            }

            if (delegateUserId == null)
            {
                // If delegateUserId is NULL then do nothing
                TraceHelper.WriteVerbose("UserIdDialog return a NULL UserId");
                return;
            }

            // If the UserIdDialog returns OK then reset the DelegateUser using the new UserId
            if (!String.IsNullOrEmpty(delegateUserId.PrimarySmtpAddress))
            {
                this.DelegateUser = new DelegateUser(delegateUserId.PrimarySmtpAddress);
            }
            else if (delegateUserId.StandardUser.HasValue)
            {
                this.DelegateUser = new DelegateUser(delegateUserId.StandardUser.Value);
            }
            else
            {
                // Treat an invalid delegateUserId as if the UserIdDialog did not return OK
                TraceHelper.WriteVerbose("UserIdDialog returned OK but UserId returned didn't have StandardUser or PrimarySmtpAddress");
            }           
        }

        #endregion

        #region Private Methods

        private void SetFormControlsForDelegateUser(DelegateUser user)
        {
            // If there is no value to set do nothing
            if (user != null)
            {
                // Set the UserIdText value based on the UserId
                if (this.delegateUser.UserId != null)
                {
                    if (!String.IsNullOrEmpty(this.delegateUser.UserId.PrimarySmtpAddress))
                    {
                        this.UserIdText.Text = this.delegateUser.UserId.PrimarySmtpAddress;
                    }
                    else if (this.delegateUser.UserId.StandardUser.HasValue)
                    {
                        this.UserIdText.Text = this.delegateUser.UserId.StandardUser.Value.ToString();
                    }
                }

                // Set the selected value of each combo box based on
                // the DelegateUser's settings
                this.calendarPermissionComboBox.SelectedItem = user.Permissions.CalendarFolderPermissionLevel;
                this.contactsPermissionComboBox.SelectedItem = user.Permissions.ContactsFolderPermissionLevel;
                this.inboxPermissionComboBox.SelectedItem = user.Permissions.InboxFolderPermissionLevel;
                this.journalPermissionComboBox.SelectedItem = user.Permissions.JournalFolderPermissionLevel;
                this.notesPermissionComboBox.SelectedItem = user.Permissions.NotesFolderPermissionLevel;
                this.tasksPermissionComboBox.SelectedItem = user.Permissions.TasksFolderPermissionLevel;

                this.DelegateReceivesCopyCheck.Checked = user.ReceiveCopiesOfMeetingMessages;
                this.PrivateItemsCheck.Checked = user.ViewPrivateItems;
            }
            else
            {
                this.UserIdText.Text = string.Empty;

                this.calendarPermissionComboBox.SelectedItem = DelegateFolderPermissionLevel.None;
                this.contactsPermissionComboBox.SelectedItem = DelegateFolderPermissionLevel.None;
                this.inboxPermissionComboBox.SelectedItem = DelegateFolderPermissionLevel.None;
                this.journalPermissionComboBox.SelectedItem = DelegateFolderPermissionLevel.None;
                this.notesPermissionComboBox.SelectedItem = DelegateFolderPermissionLevel.None;
                this.tasksPermissionComboBox.SelectedItem = DelegateFolderPermissionLevel.None;

                this.DelegateReceivesCopyCheck.Checked = false;
                this.PrivateItemsCheck.Checked = false;
            }
        }

        #endregion
    }
}
