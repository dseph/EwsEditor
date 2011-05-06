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

    public partial class UserIdDialog : EWSEditor.Forms.DialogForm
    {
        private EnumComboBox<StandardUser> standardUserCombo = new EnumComboBox<StandardUser>();
        private UserId userId = null;

        private UserIdDialog()
        {
            InitializeComponent();
        }

        private UserId UserId
        {
            get
            {
                if (!String.IsNullOrEmpty(this.SmtpAddressText.Text))
                {
                    this.userId = new UserId(this.SmtpAddressText.Text);
                }
                else if (this.standardUserCombo.SelectedItem.HasValue)
                {
                    this.userId = new UserId(this.standardUserCombo.SelectedItem.Value);
                }
                else
                {
                    this.userId = new UserId();
                }

                this.userId.DisplayName = this.DisplayNameText.Text;
                this.userId.SID = this.UserSidText.Text;

                return this.userId;
            }

            set
            {
                if (value != null)
                {
                    // Copy the values of the UserId to a new object
                    this.userId = new UserId();
                    this.userId.DisplayName = value.DisplayName;
                    this.userId.PrimarySmtpAddress = value.PrimarySmtpAddress;
                    this.userId.SID = value.SID;
                    this.userId.StandardUser = value.StandardUser;

                    // Set form controls
                    this.DisplayNameText.Text = this.userId.DisplayName;
                    this.UserSidText.Text = this.userId.SID;
                    this.SmtpAddressText.Text = this.userId.PrimarySmtpAddress;
                    this.standardUserCombo.SelectedItem = this.userId.StandardUser;
                }
                else
                {
                    this.userId = null;

                    // Set form controls
                    this.DisplayNameText.Text = string.Empty;
                    this.UserSidText.Text = string.Empty;
                    this.SmtpAddressText.Text = string.Empty;
                    this.standardUserCombo.SelectedItem = null;
                }
            }
        }

        public static DialogResult ShowDialog(ExchangeService service, ref UserId user)
        {
            UserIdDialog dialog = new UserIdDialog();
            dialog.CurrentService = service;

            dialog.UserId = user;

            DialogResult res = dialog.ShowDialog();

            if (res == DialogResult.OK)
            {
                user = dialog.UserId;
            }

            return res;
        }

        #region Event Methods

        private void UserIdDialog_Load(object sender, EventArgs e)
        {
            this.standardUserCombo.TransformComboBox(this.TempStandardUserCombo);
            this.standardUserCombo.HasEmptyItem = true;
        }

        private void ResolveNameButton_Click(object sender, EventArgs e)
        {
            NameResolution name = null;
            if (ResolveNameDialog.ShowDialog(this.CurrentService, out name) == DialogResult.OK)
            {
                if (name != null && name.Mailbox != null)
                {
                    this.DisplayNameText.Text = name.Mailbox.Name;
                    this.SmtpAddressText.Text = name.Mailbox.Address;
                    this.standardUserCombo.SelectedItem = null;
                }
            }
        }

        #endregion
    }
}
