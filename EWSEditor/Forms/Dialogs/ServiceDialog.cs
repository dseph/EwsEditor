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
using System.Xml;
using EWSEditor.Common;
 
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
        public static DialogResult ShowDialog(ref ExchangeService service, ref  EwsEditorAppSettings oAppSettings)
        {
            ServiceDialog dialog = new ServiceDialog();

            if (service != null)
            {
                dialog.CurrentService = service;
            }

            if (oAppSettings != null)
            {
                dialog.CurrentAppSettings = oAppSettings;
            }

            DialogResult res = dialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                service = dialog.CurrentService;

                oAppSettings = dialog.CurrentAppSettings;
    
            }

            return res;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            // Validation for credential input...
            if (rdoCredentialsUserSpecified.Checked && (txtUserName.Text.Length == 0 || txtPassword.Text.Length == 0))
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
 
                EwsProxyFactory.RequestedExchangeVersion = exchangeVersionCombo.SelectedItem;

                EwsProxyFactory.OverrideTimezone = GlobalSettings.OverrideTimezone;
                EwsProxyFactory.SelectedTimeZoneId = GlobalSettings.SelectedTimeZoneId;

                EwsProxyFactory.AllowAutodiscoverRedirect = GlobalSettings.AllowAutodiscoverRedirect;

                EwsProxyFactory.UseDefaultCredentials = this.rdoCredentialsDefaultWindows.Checked;
                if (this.rdoCredentialsDefaultWindows.Checked)
                {
                    EwsProxyFactory.AuthenticationMethod = RequestedAuthType.DefaultAuth;
                }

                EwsProxyFactory.CredentialsUserSpecified = this.rdoCredentialsUserSpecified.Checked;

                if (this.rdoCredentialsUserSpecified.Checked)
                {
                    EwsProxyFactory.AuthenticationMethod = RequestedAuthType.SpecifiedCredentialsAuth;
                }

                if (this.rdoCredentialsOAuth.Checked)
                {
                    EwsProxyFactory.AuthenticationMethod = RequestedAuthType.oAuth;
                }

                // MailboxBeingAccessed
                switch (EwsProxyFactory.AuthenticationMethod)
                {
                    case RequestedAuthType.DefaultAuth:
                        AutodiscoverEmailText.Text = UserPrincipal.Current.EmailAddress;
                        //if (this.AutodiscoverEmailText.Text.Trim().Length != 0)
                        //    EwsProxyFactory.MailboxBeingAccessed = this.AutodiscoverEmailText.Text.Trim();
                        break;
                    case RequestedAuthType.SpecifiedCredentialsAuth:
                        if (this.AutodiscoverEmailText.Text.Trim().Length != 0)
                            EwsProxyFactory.MailboxBeingAccessed = this.AutodiscoverEmailText.Text.Trim();
                        else
                            EwsProxyFactory.MailboxBeingAccessed = this.txtUserName.Text.Trim();
                        break;
                    case RequestedAuthType.oAuth:
                        EwsProxyFactory.MailboxBeingAccessed = this.AutodiscoverEmailText.Text.Trim();  // override later in ewsproxyfactory
                        break;
                }

                if (this.AutodiscoverEmailText.Text.Trim().Length != 0)
                    EwsProxyFactory.MailboxBeingAccessed = this.AutodiscoverEmailText.Text.Trim();
                if (this.ImpersonationCheck.Checked) // Override
                    EwsProxyFactory.MailboxBeingAccessed = ImpersonatedIdTextBox.Text.Trim();
 

                EwsProxyFactory.UserImpersonationSelected = this.ImpersonationCheck.Checked;
                //EwsProxyFactory.UserToImpersonate = this.ImpersonatedIdTextBox.Text  // set below
                EwsProxyFactory.ImpersonationType = this.connectingIdCombo.SelectedItem.Value.ToString();
                EwsProxyFactory.ImpersonatedId = this.ImpersonatedIdTextBox.Text.Trim();


                EwsProxyFactory.UseoAuth = this.rdoCredentialsOAuth.Checked;
                EwsProxyFactory.oAuthRedirectUrl = this.txtOAuthRedirectUri.Text.Trim();
                EwsProxyFactory.oAuthClientId = this.txtOAuthAppId.Text.Trim();
                EwsProxyFactory.oAuthServerName = this.txtOAuthServerName.Text.Trim();
                EwsProxyFactory.oAuthAuthority = this.txtOAuthAuthority.Text.Trim();
 
 
                EwsProxyFactory.EnableScpLookup = GlobalSettings.EnableScpLookups;
                EwsProxyFactory.PreAuthenticate = GlobalSettings.PreAuthenticate;

                EwsProxyFactory.OverrideTimeout = GlobalSettings.OverrideTimeout;
                EwsProxyFactory.Timeout = GlobalSettings.Timeout;
                EwsProxyFactory.UserAgent = GlobalSettings.UserAgent;

                EwsProxyFactory.UserName = this.txtUserName.Text.Trim();
               // EwsProxyFactory.Password = this.txtPassword.Text.Trim();   // Don't keep.
                EwsProxyFactory.Domain = this.txtDomain.Text.Trim(); 

                EwsProxyFactory.SetDefaultProxy = GlobalSettings.SetDefaultProxy;
                EwsProxyFactory.BypassProxyForLocalAddress = GlobalSettings.BypassProxyForLocalAddress;
                EwsProxyFactory.SpecifyProxySettings = GlobalSettings.SpecifyProxySettings;
                EwsProxyFactory.ProxyServerName = GlobalSettings.ProxyServerName;
                EwsProxyFactory.ProxyServerPort = GlobalSettings.ProxyServerPort;
                EwsProxyFactory.OverrideProxyCredentials = GlobalSettings.OverrideProxyCredentials;
                EwsProxyFactory.ProxyServerUser = GlobalSettings.ProxyServerUser;
                EwsProxyFactory.ProxyServerPassword = GlobalSettings.ProxyServerPassword;
                EwsProxyFactory.ProxyServerDomain = GlobalSettings.ProxyServerDomain;




 
                EwsProxyFactory.EwsUrl = this.rdoAutodiscoverEmail.Checked ?
                    null : new Uri(ExchangeServiceURLText.Text.Trim());

                EwsProxyFactory.UserToImpersonate = this.ImpersonationCheck.Checked ?
                    new ImpersonatedUserId(this.connectingIdCombo.SelectedItem.Value, this.ImpersonatedIdTextBox.Text.Trim()) : null;

                EwsProxyFactory.SetXAnchorMailbox = this.chkSetXAnchorMailbox.Checked;
                EwsProxyFactory.XAnchorMailbox = this.txtXAnchorMailbox.Text.Trim();


                EwsProxyFactory.EnableAdditionalHeader1 = GlobalSettings.EnableAdditionalHeader1;
                EwsProxyFactory.AdditionalHeader1 = GlobalSettings.AdditionalHeader1;
                EwsProxyFactory.AdditionalHeaderValue1 = GlobalSettings.AdditionalHeaderValue1;
                EwsProxyFactory.EnableAdditionalHeader2 = GlobalSettings.EnableAdditionalHeader2;
                EwsProxyFactory.AdditionalHeader2 = GlobalSettings.AdditionalHeader2;
                EwsProxyFactory.AdditionalHeaderValue2 = GlobalSettings.AdditionalHeaderValue2;
                EwsProxyFactory.EnableAdditionalHeader3 = GlobalSettings.EnableAdditionalHeader3;
                EwsProxyFactory.AdditionalHeader3 = GlobalSettings.AdditionalHeader3;
                EwsProxyFactory.AdditionalHeaderValue3 = GlobalSettings.AdditionalHeaderValue3;

                EwsProxyFactory.AddTimeZoneContext = GlobalSettings.AddTimeZoneContext;
                EwsProxyFactory.SelectedTimeZoneContextId = GlobalSettings.SelectedTimeZoneContextId;


                EwsProxyFactory.ServiceEmailAddress = this.AutodiscoverEmailText.Text.Trim();
                EwsProxyFactory.UseAutoDiscover = this.rdoAutodiscoverEmail.Checked;

                //EwsProxyFactory.ServiceCredential = rdoCredentialsUserSpecified.Checked ?
                //   new NetworkCredential(
                //       this.txtUserName.Text.Trim(),
                //       this.txtPassword.Text.Trim(),  // This will fail on passwords ending with whitespace
                //       this.txtDomain.Text.Trim()) :
                //   null;

                // ----- Set Credentials ----
                EwsProxyFactory.ServiceCredential = null;
                EwsProxyFactory.ServiceNetworkCredential = null;

                if (rdoCredentialsDefaultWindows.Checked)
                {
                    EwsProxyFactory.ServiceCredential = (NetworkCredential)CredentialCache.DefaultCredentials;

                    EwsProxyFactory.ServiceNetworkCredential = (NetworkCredential)CredentialCache.DefaultCredentials;
                }

                if (rdoCredentialsUserSpecified.Checked)
                {
                    NetworkCredential oNetworkCredential = new NetworkCredential(
                       this.txtUserName.Text.Trim(),
                       this.txtPassword.Text.Trim(),  // This will fail on passwords ending with whitespace
                       this.txtDomain.Text.Trim());

                    EwsProxyFactory.ServiceCredential = oNetworkCredential;

                    EwsProxyFactory.ServiceNetworkCredential = oNetworkCredential;
                }
 

                if (this.rdoCredentialsOAuth.Checked)
                {
                    AuthenticationHelper oAH = new AuthenticationHelper();

                    EwsProxyFactory.ServiceCredential = oAH.Do_OAuth(ref EwsProxyFactory.MailboxBeingAccessed, ref EwsProxyFactory.AccountAccessingMailbox,
                      EwsProxyFactory.oAuthAuthority, EwsProxyFactory.oAuthClientId, EwsProxyFactory.oAuthRedirectUrl, EwsProxyFactory.oAuthServerName);
                   
                    //EwsProxyFactory.AccountAccessingMailbox
                    //EwsProxyFactory.MailboxBeingAccessed = EwsProxyFactory.AccountAccessingMailbox;
                }

                // ----    Autodiscover    ----

                if (this.rdoAutodiscoverEmail.Checked)
                {
                    EwsProxyFactory.DoAutodiscover();
                }

                // ----    New service & app settings    ----
                 
                CurrentService = EwsProxyFactory.CreateExchangeService();


                // ----    Save settings    ----
                EWSEditor.Common.EwsEditorAppSettings oAppSettings = new EwsEditorAppSettings();
                EwsProxyFactory.SetAppSettingsFromProxyFactory(ref oAppSettings);
                CurrentAppSettings = oAppSettings;
                
                //CurrentAppSettings.MailboxBeingAccessed = EwsProxyFactory.AccountAccessingMailbox;
                // CurrentAppSettings

                // EwsProxyFactory.AccountAccessingMailbox

                // ----    Do a basic test to be sure that the mailbox can be reached with an EWS call   ----
                CurrentService.TestExchangeService();

                CurrentService.OnSerializeCustomSoapHeaders += m_Service_OnSerializeCustomSoapHeaders;
           

                DialogResult = DialogResult.OK;
            }
            finally
            {
                Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        ///// <summary>
        /////  This is used for adding soap headers not exposed in the EWS Managed API
        ///// </summary>
        ///// <param name="oRequest"></param>
         public void m_Service_OnSerializeCustomSoapHeaders(XmlWriter writer)
        {

            // Add TimeZoneDefinition...
            // http://blogs.msdn.com/b/emeamsgdev/archive/2014/04/23/ews-missing-soap-headers-when-using-the-ews-managed-api.aspx

            if (EwsProxyFactory.AddTimeZoneContext == true)
            {
                writer.WriteRaw(Environment.NewLine + "    <t:TimeZoneContext><t:TimeZoneDefinition Id=\"" + GlobalSettings.SelectedTimeZoneContextId + "\"/></t:TimeZoneContext>" + Environment.NewLine);
            }
    
         }

        private void ChkCredentials_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void ChkImpersonation_CheckedChanged(object sender, EventArgs e)
        {
            ImpersonatedIdTextBox.Text = string.Empty;

            this.connectingIdCombo.Enabled = ImpersonationCheck.Checked;
            ImpersonatedIdTextBox.Enabled = ImpersonationCheck.Checked;
            lblImpId.Enabled = ImpersonationCheck.Checked;
            lblImpIdType.Enabled = ImpersonationCheck.Checked;
 
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
                tempService.TraceEnablePrettyPrinting = true;
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
            this.exchangeVersionCombo.Text = "Exchange2013";

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
                    this.rdoCredentialsUserSpecified.Checked = true;

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

            SetAuthEnablement();
            
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
                //this.AutodiscoverEmailText.Text = string.Empty;
                this.AutodiscoverEmailText.Enabled = true;
                this.lblAutodiscoverEmailDesc.Enabled = true;
                this.AutodiscoverEmailText.Focus();

                this.ExchangeServiceURLText.Enabled = false;
                this.lblExchangeServiceURLTextDesc.Enabled = false;
                this.btnDefault365Settings.Enabled = false;
            }

            if (this.rdoServiceUrl.Checked == true)
            {
                //this.ExchangeServiceURLText.Text = string.Empty;
                this.ExchangeServiceURLText.Enabled = true;
                this.lblExchangeServiceURLTextDesc.Enabled = true;
                this.ExchangeServiceURLText.Focus();

                this.btnDefault365Settings.Enabled = true;

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

        private void btnDefault365Settings_Click(object sender, EventArgs e)
        {
            ExchangeServiceURLText.Text = "https://outlook.office365.com/EWS/Exchange.asmx";
        }

        private void btnDefaultSmtp_Click(object sender, EventArgs e)
        {
            AutodiscoverEmailText.Text = UserPrincipal.Current.EmailAddress;
        }

        private void TempConnectingIdCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chkSetXAnchorMailbox_CheckedChanged(object sender, EventArgs e)
        {
            txtXAnchorMailbox.Enabled = chkSetXAnchorMailbox.Checked;

            // Default ImpersonatedIdTextBox ImpersonationCheck
            if (chkSetXAnchorMailbox.Checked == true && txtXAnchorMailbox.Text.Trim().Length == 0)
            {
                if (ImpersonationCheck.Checked == true)
                {
                    if (ImpersonatedIdTextBox.Text.Contains("@"))
                        txtXAnchorMailbox.Text = ImpersonatedIdTextBox.Text;
                }
                else
                {

                    if (rdoAutodiscoverEmail.Checked == true && AutodiscoverEmailText.Text.Contains("@"))
                    {
                        txtXAnchorMailbox.Text = AutodiscoverEmailText.Text;
                    }
                    else
                    {
                        if (txtUserName.Text.Contains("@"))
                            txtXAnchorMailbox.Text = txtUserName.Text;
                    }
                }
 
            }
        }

        private void rdoCredentialsUserSpecified_CheckedChanged(object sender, EventArgs e)
        {

            SetAuthEnablement();

            

        }

        private void SetAuthEnablement()
        {
            bool bUserSpecified = this.rdoCredentialsUserSpecified.Checked;
            bool bUseOAuth = this.rdoCredentialsOAuth.Checked; 

            //txtUserName.Text = string.Empty;
            //txtPassword.Text = string.Empty;
            //txtDomain.Text = string.Empty;

            txtUserName.Enabled = bUserSpecified;
            txtPassword.Enabled = bUserSpecified;
            txtDomain.Enabled = bUserSpecified;
            lblUserName.Enabled = bUserSpecified;
            lblPassword.Enabled = bUserSpecified;
            lblDomain.Enabled = bUserSpecified;

            if (this.rdoCredentialsUserSpecified.Checked == true)
            {
                if (rdoAutodiscoverEmail.Checked == true)
                {
                    if (txtUserName.Text.Trim().Length == 0)
                    {
                        if (AutodiscoverEmailText.Text.Trim().Length != 0)
                        {
                            txtUserName.Text = AutodiscoverEmailText.Text.Trim();
                        }
                    }
                }
            }

            this.lblOAuthAppId.Enabled = bUseOAuth;
            this.lblOAuthAuthority.Enabled = bUseOAuth;
            this.lblOAuthRedirectUri.Enabled = bUseOAuth;
            this.lblOAuthServerName.Enabled = bUseOAuth;

            this.txtOAuthAppId.Enabled = bUseOAuth;
            this.txtOAuthAuthority.Enabled = bUseOAuth;
            this.txtOAuthRedirectUri.Enabled = bUseOAuth;
            this.txtOAuthServerName.Enabled = bUseOAuth;
        }

        private void txtOAuthRedirectUri_TextChanged(object sender, EventArgs e)
        {

        }

        private void rdoCredentialsOAuth_CheckedChanged(object sender, EventArgs e)
        {
            SetAuthEnablement();
        }

        private void rdoCredentialsDefaultWindows_CheckedChanged(object sender, EventArgs e)
        {
            SetAuthEnablement();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ImpersonatedIdTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDefaultUserNameSmtp_Click(object sender, EventArgs e)
        {
            this.txtUserName.Text = UserPrincipal.Current.EmailAddress;
        }
 
    }
}
