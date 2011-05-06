namespace EWSEditor.Forms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Net;
    using System.Text;
    using System.Windows.Forms;

    using EWSEditor.Common;
    using EWSEditor.Common.Extensions;
    using EWSEditor.Diagnostics;
    using EWSEditor.Forms.Controls;
    using EWSEditor.Resources;

    using Microsoft.Exchange.WebServices.Data;

    public partial class ServiceDialog : DialogForm
    {
        private EnumComboBox<ConnectingIdType> connectingIdCombo = new EnumComboBox<ConnectingIdType>();
        private EnumComboBox<ExchangeVersion> exchangeVersionCombo = new EnumComboBox<ExchangeVersion>();

        private ServiceDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// A passed ExchangeService can be displayed for editing or a new
        /// service will be returned after created using this dialog.
        /// </summary>
        /// <param name="service">ExchangeService to be returned or displayed</param>
        /// <returns>DialogResult indicating the user action which closed the dialog</returns>
        public static DialogResult ShowDialog(ref ExchangeService service)
        {
            ServiceDialog dialog = new ServiceDialog();

            if (service != null)
            {
                dialog.CurrentService = service;
            }

            DialogResult res = dialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                service = dialog.CurrentService;
            }

            return res;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                // Setup the Requested Server Version
                ExchangeVersion? version = this.exchangeVersionCombo.SelectedItem;
                if (version.HasValue)
                {
                    this.CurrentService = new ExchangeService(version.Value);
                }
                else
                {
                    this.CurrentService = new ExchangeService();
                }

                this.CurrentService.TraceEnabled = true;
                this.CurrentService.TraceListener = new EWSEditorTraceListener();

                // Setup credentials
                if (chkCredentials.Checked)
                {
                    if (txtUserName.Text.Length == 0 || txtPassword.Text.Length == 0)
                    {
                        ErrorDialog.ShowInfo(DisplayStrings.MSG_SPECIFY_CREDS);
                        return;
                    }
                    else
                    {
                        this.CurrentService.Credentials = new NetworkCredential(
                                                txtUserName.Text,
                                                txtPassword.Text,
                                                txtDomain.Text);
                    }
                }
                else
                {
                    this.CurrentService.UseDefaultCredentials = true;
                }

                // Setup the service URL
                if (this.UseAutodiscoverCheck.Checked && !String.IsNullOrEmpty(this.AutodiscoverEmailText.Text))
                {
                    this.CurrentService.AutodiscoverUrl(this.AutodiscoverEmailText.Text);
                    this.ExchangeServiceURLText.Text = this.CurrentService.Url.PathAndQuery;
                }
                else if (!this.UseAutodiscoverCheck.Checked)
                {
                    this.CurrentService.Url = new Uri(ExchangeServiceURLText.Text);
                }

                // Setup Exchange Impersonation
                if (this.ImpersonationCheck.Checked)
                {
                    if (!String.IsNullOrEmpty(this.ImpersonatedIdTextBox.Text) && 
                        this.connectingIdCombo.SelectedItem.HasValue)
                    {
                        this.CurrentService.ImpersonatedUserId = new ImpersonatedUserId(
                            this.connectingIdCombo.SelectedItem.Value,
                            this.ImpersonatedIdTextBox.Text);
                    }
                    else
                    {
                        ErrorDialog.ShowInfo(DisplayStrings.MSG_IMPERSON_REQ);
                        return;
                    }
                }

                // Test the service with a canary call to see if it works. If not
                // don't close the form, display the exception and allow the user
                // to fix the settings.
                this.CurrentService.TestExchangeService(ConfigHelper.OverrideCertValidation);

                this.DialogResult = DialogResult.OK;
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void ChkCredentials_CheckedChanged(object sender, EventArgs e)
        {
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtDomain.Text = string.Empty;

            txtUserName.Enabled = chkCredentials.Checked;
            txtPassword.Enabled = chkCredentials.Checked;
            txtDomain.Enabled = chkCredentials.Checked;
            lblUserName.Enabled = chkCredentials.Checked;
            lblPassword.Enabled = chkCredentials.Checked;
            lblDomain.Enabled = chkCredentials.Checked;
        }

        private void ChkImpersonation_CheckedChanged(object sender, EventArgs e)
        {
            ImpersonatedIdTextBox.Text = string.Empty;

            this.connectingIdCombo.Enabled = ImpersonationCheck.Checked;
            ImpersonatedIdTextBox.Enabled = ImpersonationCheck.Checked;
            lblImpId.Enabled = ImpersonationCheck.Checked;
            lblImpIdType.Enabled = ImpersonationCheck.Checked;
        }

        private void UseAutodiscoverCheck_CheckedChanged(object sender, EventArgs e)
        {
            this.AutodiscoverEmailText.Enabled = this.UseAutodiscoverCheck.Checked;
            this.ExchangeServiceURLText.ReadOnly = this.UseAutodiscoverCheck.Checked;

            if (!this.UseAutodiscoverCheck.Checked)
            {
                this.ExchangeServiceURLText.Text = string.Empty;
                this.ExchangeServiceURLText.Focus();
            }
            else
            {
                this.AutodiscoverEmailText.Focus();
            }
        }

        /// <summary>
        /// Display the GetMailboxNameDialog to get the SMTP address and
        /// perform Autodiscover operation to get the EWS service URL.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void BtnAutodiscover_Click(object sender, EventArgs e)
        {
            Mailbox mbx = null;

            // If the result isn't OK do nothing.
            if (GetMailboxNameDialog.ShowDialog(ref mbx) != DialogResult.OK)
            {
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                ExchangeService tempService = new ExchangeService(ExchangeVersion.Exchange2010);
                tempService.TraceEnabled = true;
                tempService.TraceListener = new EWSEditorTraceListener();

                if (ConfigHelper.OverrideAutodiscValidation)
                {
                    tempService.AutodiscoverUrl(
                        mbx.Address,
                        delegate(string url) { return true; });
                }
                else
                {
                    tempService.AutodiscoverUrl(mbx.Address);
                }

                AutodiscoverEmailText.Text = mbx.Address;
                ExchangeServiceURLText.Text = tempService.Url.ToString();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ServiceDialog_Load(object sender, EventArgs e)
        {
            this.exchangeVersionCombo.TransformComboBox(this.TempExchangeVersionCombo);
            this.exchangeVersionCombo.HasEmptyItem = true;

            this.connectingIdCombo.TransformComboBox(this.TempConnectingIdCombo);
            this.connectingIdCombo.SelectedItem = ConnectingIdType.SmtpAddress;

            // If CurrentService is already set then we are editing an
            // existing ExchangeService and need to load it first.
            if (this.CurrentService != null)
            {
                if (this.CurrentService.Url != null)
                {
                    this.UseAutodiscoverCheck.Checked = false;
                    this.ExchangeServiceURLText.Text = this.CurrentService.Url.ToString();
                }

                this.exchangeVersionCombo.SelectedItem = this.CurrentService.RequestedServerVersion;

                if (this.CurrentService.Credentials != null)
                {
                    this.chkCredentials.Checked = true;

                    NetworkCredential cred = this.CurrentService.GetNetworkCredential();
                    this.txtUserName.Text = cred.UserName;
                    this.txtPassword.Text = cred.Password;
                    this.txtDomain.Text = cred.Domain;
                }

                if (this.CurrentService.ImpersonatedUserId != null)
                {
                    this.ImpersonationCheck.Checked = true;

                    this.connectingIdCombo.SelectedItem = this.CurrentService.ImpersonatedUserId.IdType;
                    this.ImpersonatedIdTextBox.Text = this.CurrentService.ImpersonatedUserId.Id;
                }
            }
        }
    }
}