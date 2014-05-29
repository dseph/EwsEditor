using System;
using System.Net;
using System.Windows.Forms;
using EWSEditor.Common.Extensions;
using EWSEditor.Exchange;
using EWSEditor.Forms.Controls;
using EWSEditor.Resources;
using EWSEditor.Settings;
using Microsoft.Exchange.WebServices.Data;
using System.DirectoryServices.AccountManagement;

 
namespace EWSEditor.Forms
{
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
            // Validation for credential input...
            if (chkCredentials.Checked && (txtUserName.Text.Length == 0 || txtPassword.Text.Length == 0))
            {
                ErrorDialog.ShowInfo(DisplayStrings.MSG_SPECIFY_CREDS);
                return;
            }

            // Validation for Autodiscover input...
 
            if (this.rdoAutodiscoverEmail.Checked && String.IsNullOrEmpty(this.AutodiscoverEmailText.Text))
            {
                ErrorDialog.ShowInfo(DisplayStrings.MSG_SERVICE_REQ);
                return;
            }

            // Validation for URL input...
            if (this.rdoServiceUrl.Checked && String.IsNullOrEmpty(this.ExchangeServiceURLText.Text))
            {
                ErrorDialog.ShowInfo(DisplayStrings.MSG_SERVICE_REQ);
                return;
            }

            // Validation for Impersonation input...
            if (this.ImpersonationCheck.Checked && (String.IsNullOrEmpty(this.ImpersonatedIdTextBox.Text) || !this.connectingIdCombo.SelectedItem.HasValue))
            {
                ErrorDialog.ShowInfo(DisplayStrings.MSG_IMPERSON_REQ);
                return;
            }

            try
            {
                Cursor = System.Windows.Forms.Cursors.WaitCursor;
 
                //EwsProxyFactory.InitializeWithDefaults(exchangeVersionCombo.SelectedIndex,
                EwsProxyFactory.RequestedExchangeVersion = exchangeVersionCombo.SelectedItem;


                //if (this.chkUseSpecifiedTimezone.Checked)
                //{
                //    TimeZoneInfo oTimeZone = TimeZoneInfo.FindSystemTimeZoneById(cmboTimeZoneIds.Text);
                //    EwsProxyFactory.SelectedTimeZone = oTimeZone;
                //}
                //else
                //{
                //    EwsProxyFactory.SelectedTimeZone = null;
                //}

                EwsProxyFactory.OverrideTimezone = GlobalSettings.OverrideTimezone;
                EwsProxyFactory.SelectedTimeZoneId = GlobalSettings.SelectedTimeZoneId;

                EwsProxyFactory.AllowAutodiscoverRedirect = GlobalSettings.AllowAutodiscoverRedirect;
                EwsProxyFactory.UseDefaultCredentials = !chkCredentials.Checked;
                EwsProxyFactory.EnableScpLookup = GlobalSettings.EnableScpLookups;
                EwsProxyFactory.PreAuthenticate = GlobalSettings.PreAuthenticate;

                EwsProxyFactory.OverrideTimeout = GlobalSettings.OverrideTimeout;
                EwsProxyFactory.Timeout = GlobalSettings.Timeout;
                EwsProxyFactory.UserAgent = GlobalSettings.UserAgent;

                EwsProxyFactory.SetDefaultProxy = GlobalSettings.SetDefaultProxy;
                EwsProxyFactory.BypassProxyForLocalAddress = GlobalSettings.BypassProxyForLocalAddress;
                EwsProxyFactory.SpecifyProxySettings = GlobalSettings.SpecifyProxySettings;
                EwsProxyFactory.ProxyServerName = GlobalSettings.ProxyServerName;
                EwsProxyFactory.ProxyServerPort = GlobalSettings.ProxyServerPort;
                EwsProxyFactory.OverrideProxyCredentials = GlobalSettings.OverrideProxyCredentials;
                EwsProxyFactory.ProxyServerUser = GlobalSettings.ProxyServerUser;
                EwsProxyFactory.ProxyServerPassword = GlobalSettings.ProxyServerPassword;
                EwsProxyFactory.ProxyServerDomain = GlobalSettings.ProxyServerDomain;

                EwsProxyFactory.ServiceCredential = chkCredentials.Checked ?
                    new NetworkCredential(
                        this.txtUserName.Text.Trim(), 
                        this.txtPassword.Text.Trim(), //TODO:  This will fail on passwords ending with whitespace
                        this.txtDomain.Text.Trim()) :
                    null;

                 
                EwsProxyFactory.EwsUrl = this.rdoAutodiscoverEmail.Checked ?
                    null : new Uri(ExchangeServiceURLText.Text.Trim());

                EwsProxyFactory.UserToImpersonate = this.ImpersonationCheck.Checked ?
                    new ImpersonatedUserId(this.connectingIdCombo.SelectedItem.Value, this.ImpersonatedIdTextBox.Text.Trim()) : null;

                EwsProxyFactory.ServiceEmailAddress = this.AutodiscoverEmailText.Text.Trim();
                if (this.rdoAutodiscoverEmail.Checked)
                {
                    EwsProxyFactory.DoAutodiscover();
                }

 

                CurrentService = EwsProxyFactory.CreateExchangeService();

                CurrentService.TestExchangeService();

                DialogResult = DialogResult.OK;
            }
            finally
            {
                Cursor = System.Windows.Forms.Cursors.Default;
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

 

        //private void UseAutodiscoverCheck_CheckedChanged(object sender, EventArgs e)
        //{
        //    this.AutodiscoverEmailText.Enabled = this.UseAutodiscoverCheck.Checked;
        //    this.ExchangeServiceURLText.ReadOnly = this.UseAutodiscoverCheck.Checked;

        //    if (!this.UseAutodiscoverCheck.Checked)
        //    {
        //        this.ExchangeServiceURLText.Text = string.Empty;
        //        this.ExchangeServiceURLText.Focus();
        //    }
        //    else
        //    {
        //        this.AutodiscoverEmailText.Focus();
        //    }
        //}

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
                tempService.TraceListener = new EWSEditor.Logging.EwsTraceListener();

                if (GlobalSettings.AllowAutodiscoverRedirect)
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
            this.exchangeVersionCombo.Text = "Exchange2007_SP1";

            this.connectingIdCombo.TransformComboBox(this.TempConnectingIdCombo);
            this.connectingIdCombo.SelectedItem = ConnectingIdType.SmtpAddress;

             
 

            // If CurrentService is already set then we are editing an
            // existing ExchangeService and need to load it first.
            if (this.CurrentService != null)
            {
                if (this.CurrentService.Url != null)
                { 
                    this.rdoAutodiscoverEmail.Checked = false;
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

            SetAutoDiscoverSelection();
            
        }

        private void chkUseSpecifiedTimezone_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            OptionsDialog.ShowDialog();
        }

        private void cmboTimeZoneIds_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rdoAutodiscoverEmail_CheckedChanged(object sender, EventArgs e)
        {

            SetAutoDiscoverSelection();
        }

        private void SetAutoDiscoverSelection()
        {
            if (this.rdoAutodiscoverEmail.Checked == true)
            {
                this.AutodiscoverEmailText.Text = string.Empty;
                this.AutodiscoverEmailText.Enabled = true;
                this.lblAutodiscoverEmailDesc.Enabled = true;
                this.AutodiscoverEmailText.Focus();

                this.ExchangeServiceURLText.Enabled = false;
                this.lblExchangeServiceURLTextDesc.Enabled = false;
            }

            if (this.rdoServiceUrl.Checked == true)
            {
                this.ExchangeServiceURLText.Text = string.Empty;
                this.ExchangeServiceURLText.Enabled = true;
                this.lblExchangeServiceURLTextDesc.Enabled = true;
                this.ExchangeServiceURLText.Focus();

                this.AutodiscoverEmailText.Enabled = false;
                this.lblAutodiscoverEmailDesc.Enabled = false;
            }
        }

        private void rdoServiceUrl_CheckedChanged(object sender, EventArgs e)
        {
            SetAutoDiscoverSelection();
        }

        private void lblImpId_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
             
        }

        private void txtDefaultSmtp_Click(object sender, EventArgs e)
        {
            AutodiscoverEmailText.Text =  UserPrincipal.Current.EmailAddress;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        //private void btnOptions_Click(object sender, EventArgs e)
        //{
        //    OptionsDialog.ShowDialog();
        //}
    }
}
