using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using EWSEditor.Common;
 
using Microsoft.Identity.Client;
using System.Net.Sockets;
using System.Net.Security;
using EWSEditor.Settings;
using Microsoft.Exchange.WebServices.Data;
using System.DirectoryServices.AccountManagement;
using System.Net;
using System.Security.Cryptography.X509Certificates;
 
using EWSEditor.Exchange;
using System.ComponentModel.Composition.Primitives;


namespace EWSEditor.Forms.IMAP
{
    public partial class ImapTest : Form
    {
 

        private static TcpClient _imapClient = null;
        private static SslStream _sslStream = null;
        public StringBuilder oSB = new StringBuilder();

        public ImapTest()
        {
            InitializeComponent();
        }

        private void ImapTest_Load(object sender, EventArgs e)
        {
            SetAuthEnablement();
        }

        private void TestIMAP()
        {

            AuthenticationResult authResult = GetToken();
            RetrieveMessages(authResult);
             
        }

        string ReadSSLStream()
        {
            int bytes = -1;
            byte[] buffer = new byte[2048];
            bytes = _sslStream.Read(buffer, 0, buffer.Length);
            string response = Encoding.ASCII.GetString(buffer, 0, bytes);
            oSB.AppendLine(response);
            return response;
        }

        void WriteSSLStream(string Data)
        {
            _sslStream.Write(Encoding.ASCII.GetBytes($"{Data}{Environment.NewLine}"));
            _sslStream.Flush();
            oSB.AppendLine(Data);
        }

        /// <summary>
        /// Test the given provided IMAP details (attempt to obtain token and access mailbox)
        /// </summary>
        string RetrieveMessages(AuthenticationResult authResult )
        {
            oSB = new StringBuilder();
    

            try
            {
                //int iPort = Int32.Parse(txtPort.Text.Trim());

                using (_imapClient = new TcpClient(AuthFactory.Server, AuthFactory.Port))
                {
                    using (_sslStream = new SslStream(_imapClient.GetStream()))
                    {
                        _sslStream.AuthenticateAsClient(AuthFactory.Server);

                        ReadSSLStream();

                        //Send the users login details
                        WriteSSLStream($"$ CAPABILITY");
                        ReadSSLStream();

                        //Send the users login details
                        if (AuthFactory.UseOAuthDelegate == true)
                            WriteSSLStream($"$ AUTHENTICATE XOAUTH2 {XOauth2(authResult)}");
                        else
                            WriteSSLStream($"$ AUTHENTICATE XOAUTH2 {XOauth2(authResult, AuthFactory.MailboxBeingAccessed)}");
                        string response = ReadSSLStream();
                        if (response.StartsWith("$ NO AUTHENTICATE"))
                            oSB.AppendLine("Authentication failed.");
                        else
                        {

                            //sb.AppendLine("Authenticated.");

                            // Retrieve inbox unread messages
                            WriteSSLStream("$ STATUS INBOX (unseen)");
                            ReadSSLStream();

                            // Log out
                            WriteSSLStream($"$ LOGOUT");
                            ReadSSLStream();
                        }

                        // Tidy up
                        oSB.AppendLine("Closing connection");
                    }
                }
            }
            catch (SocketException ex)
            {
                oSB.AppendLine(ex.Message);
            }

            return oSB.ToString();
        }

        /// <summary>
        /// Calculate and return the log-in code, which is a base 64 encoded combination of mailbox (user) and auth token
        /// </summary>
        /// <param name="authResult">Valid OAuth token</param>
        /// <param name="mailbox">If missing, mailbox will be read from the token</param>
        /// <returns>IMAP log-in code</returns>
        static string XOauth2(AuthenticationResult authResult, string mailbox = null)
        {
            char ctrlA = (char)1;
            if (String.IsNullOrEmpty(mailbox))
                mailbox = authResult.Account.Username;
            Console.WriteLine($"Authenticating for access to mailbox {mailbox}");
            string login = $"user={mailbox}{ctrlA}auth=Bearer {authResult.AccessToken}{ctrlA}{ctrlA}";
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(login);
            return Convert.ToBase64String(plainTextBytes);
        }

        /// <summary>
        /// Loads certificate from file
        private void BtnLoadCertificate_Click(object sender, EventArgs e)
        {
            string sFile = string.Empty;
            string sConnectionSettings = string.Empty;
            // PostFormSetting oPostFormSetting = null;
            string sFileContents = string.Empty;

            if (UserIoHelper.PickLoadFromFile(Application.UserAppDataPath, "*.cer", ref sFile, "CER files (*.cer)|*.cer"))
            {
                try
                {
                    txtAuthCertificatePath.Text = sFile;
                    if (!System.IO.File.Exists(sFile))
                        MessageBox.Show("File does not exist.");
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), "Error Loading File");
                }

            }
        }

        private void rdoCredentialsOAuthDelegated_CheckedChanged(object sender, EventArgs e)
        {
            SetAuthEnablement();
            cmboScope.Text = string.Empty;
        }

        private void rdoCredentialsOAuthApplication_CheckedChanged(object sender, EventArgs e)
        {
            SetAuthEnablement();
            cmboScope.Text = string.Empty;
        }

        private void rdoCredentialsOAuthCertificate_CheckedChanged(object sender, EventArgs e)
        {
            SetAuthEnablement();
            cmboScope.Text = string.Empty;
        }

        /// <summary>
        /// Enables and discables controls based on the selected authentication method
        /// </summary>
        private void SetAuthEnablement()
        {
            string[] sDelegateScopes = { };


            this.lblOAuthClientSecret.Enabled = (rdoCredentialsOAuthApplication.Checked);
            this.txtAuthCertificatePath.Enabled = (rdoCredentialsOAuthCertificate.Checked);

            this.txtOAuthClientSecret.Enabled = (rdoCredentialsOAuthApplication.Checked);
            this.chkShowSecret.Enabled = (rdoCredentialsOAuthApplication.Checked);
  
            this.txtAuthCertificatePath.Enabled = (rdoCredentialsOAuthCertificate.Checked);
            this.BtnLoadCertificate.Enabled = (rdoCredentialsOAuthCertificate.Checked);

            if (rdoCredentialsOAuthApplication.Checked || rdoCredentialsOAuthCertificate.Checked)
            {
                // Applicaiton Flow
                cmboScope.Items.Clear();
                cmboScope.Items.Add("https://outlook.office365.com/.default");
                cmboScope.Items.Add("https://outlook.office365.us/.default");
                cmboScope.Items.Add("https://outlook.office365.de/.default");
                cmboScope.Items.Add("https://outlook.office365.cn/.default");

                // Note In Azure set: Client credentials (Application permissions):  IMAP.AccessAsApp 
            }

            if (rdoCredentialsOAuthDelegated.Checked)
            {
 
                // Delegate flow scopes
                cmboScope.Items.Clear();
                cmboScope.Items.Add("https://outlook.office.com/IMAP.AccessAsUser.All");
                cmboScope.Items.Add("https://outlook.office.us/IMAP.AccessAsUser.All");
                cmboScope.Items.Add("https://outlook.office.de/IMAP.AccessAsUser.All");
                cmboScope.Items.Add("https://outlook.office.cn/IMAP.AccessAsUser.All");

                // Note In Azure set: Auth code flow (Delegate permissions): IMAP.AccessAsUser.All
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            AuthenticationResult authResult = GetToken();
            this.txtToken.Text  =  authResult.AccessToken;
            string s = RetrieveMessages(authResult);
            this.txtTestResults .Text = s;

        }

        /// <summary>
        /// Loads settings from the form into the AuthFactory
        /// </summary>
        private void LoadSettingsFromForm()
        {


            AuthFactory.AuthenticationMethod = RequestedAuthType.oAuth2Application;
  
  
            AuthFactory.OAuth2RedirectUrl = cmboRedirectUrl.Text.Trim();
            AuthFactory.OAuth2Authority = cmboAuthority.Text.Trim();
            AuthFactory.OAuth2ValidateAuthority = chkValidateAuthority.Checked;
            AuthFactory.OAuth2Scope = cmboScope.Text.Trim();

            if (this.rdoCredentialsOAuthDelegated.Checked)
                AuthFactory.AuthenticationMethod = RequestedAuthType.oAuth2Delegate;

            if (this.rdoCredentialsOAuthApplication.Checked)
                AuthFactory.AuthenticationMethod = RequestedAuthType.oAuth2Application;

            if (this.rdoCredentialsOAuthCertificate.Checked)
                AuthFactory.AuthenticationMethod = RequestedAuthType.oAuth2Certificate;

            AuthFactory.MailboxBeingAccessed = this.txtMailbox.Text.Trim();
  
            AuthFactory.UseOAuthDelegate = this.rdoCredentialsOAuthDelegated.Checked;
            AuthFactory.UseOAuthApplication = this.rdoCredentialsOAuthApplication.Checked;
            AuthFactory.oAuthApplicationId = this.txtOAuthApplicationId.Text.Trim();
            AuthFactory.oAuthTenantId = this.txtOAuthTenantId.Text.Trim();
            AuthFactory.oAuthClientSecret = this.txtOAuthClientSecret.Text.Trim();
            // AuthFactory.oAuthCertificate = this.txtAuthCertificate.Text.Trim();
            AuthFactory.oBearerToken = string.Empty;

            AuthFactory.LogSecurityToken = GlobalSettings.LogSecurityToken;
 

            //AuthFactory.OverrideTimeout = GlobalSettings.OverrideTimeout;
            //AuthFactory.Timeout = GlobalSettings.Timeout;
            AuthFactory.UserAgent = GlobalSettings.UserAgent;

    

            AuthFactory.SetDefaultProxy = GlobalSettings.SetDefaultProxy;
            AuthFactory.BypassProxyForLocalAddress = GlobalSettings.BypassProxyForLocalAddress;
            AuthFactory.SpecifyProxySettings = GlobalSettings.SpecifyProxySettings;
            AuthFactory.ProxyServerName = GlobalSettings.ProxyServerName;
            AuthFactory.ProxyServerPort = GlobalSettings.ProxyServerPort;
            AuthFactory.OverrideProxyCredentials = GlobalSettings.OverrideProxyCredentials;
            AuthFactory.ProxyServerUser = GlobalSettings.ProxyServerUser;
            AuthFactory.ProxyServerPassword = GlobalSettings.ProxyServerPassword;
            AuthFactory.ProxyServerDomain = GlobalSettings.ProxyServerDomain;

            AuthFactory.Server = this.txtServer.Text.Trim();
            int i;
            bool success = int.TryParse(this.txtPort.Text.Trim(), out i);
            AuthFactory.Port = i;


 

        }

        /// <summary>
        /// Gets the oAuth token based-upon the settings of the AuthFactory
        /// </summary>
        /// <returns></returns>
        private AuthenticationResult GetToken()
        {

            LoadSettingsFromForm();

            AuthenticationResult oResult = null;

            if (this.rdoCredentialsOAuthDelegated.Checked)
            {
                EWSEditor.Common.Auth.OAuthHelper o = new EWSEditor.Common.Auth.OAuthHelper();

                /* AuthenticationResult */ oResult = System.Threading.Tasks.Task.Run(async () => await o.GetDelegateToken(
                        AuthFactory.oAuthApplicationId,
                        AuthFactory.oAuthTenantId,
                        AuthFactory.OAuth2RedirectUrl,
                        AuthFactory.OAuth2Authority,
                        AuthFactory.OAuth2ValidateAuthority,
                        AuthFactory.OAuth2Scope
                        )
                    ).Result;
                AuthFactory.MsalAuthenticationResult = oResult;
 
                var oCredentials = new Microsoft.Exchange.WebServices.Data.OAuthCredentials(oResult.AccessToken);

              
                AuthFactory.MsalAuthenticationResult = oResult;
                AuthFactory.oBearerToken = oResult.AccessToken;
                AuthFactory.CurrentPublicClientApplication = o.CurrentPublicClientApplication;

                AuthFactory.MailboxBeingAccessed = oResult.Account.Username;

            

            }

            if (this.rdoCredentialsOAuthApplication.Checked)
            {
                EWSEditor.Common.Auth.OAuthHelper o = new EWSEditor.Common.Auth.OAuthHelper();
                /* AuthenticationResult */ oResult = System.Threading.Tasks.Task.Run(async () => await o.GetApplicationToken(AuthFactory.oAuthApplicationId,
                                                                                                                        AuthFactory.oAuthTenantId,
                                                                                                                        AuthFactory.oAuthClientSecret,
                                                                                                                        AuthFactory.OAuth2RedirectUrl,
                                                                                                                        AuthFactory.OAuth2Authority,
                                                                                                                        AuthFactory.OAuth2ValidateAuthority,
                                                                                                                        AuthFactory.OAuth2Scope

                                                                                                                        )).Result;

                var oCredentials = new Microsoft.Exchange.WebServices.Data.OAuthCredentials(oResult.AccessToken);

               
                AuthFactory.MsalAuthenticationResult = oResult;
                AuthFactory.oBearerToken = oResult.AccessToken;
                AuthFactory.CurrentPublicClientApplication = o.CurrentPublicClientApplication;
 
            }

            if (this.rdoCredentialsOAuthCertificate.Checked)
            {
                EWSEditor.Common.Auth.OAuthHelper o = new EWSEditor.Common.Auth.OAuthHelper();

                /* AuthenticationResult */  oResult = System.Threading.Tasks.Task.Run(async () => await o.GetCertificateToken(
                    AuthFactory.oAuthApplicationId,
                    AuthFactory.oAuthTenantId,
                    AuthFactory.oAuthClientCertificate,
                    AuthFactory.OAuth2Authority,
                    AuthFactory.OAuth2RedirectUrl,
                    AuthFactory.OAuth2ValidateAuthority,
                    AuthFactory.OAuth2Scope
                    )).Result;



                var oCredentials = new Microsoft.Exchange.WebServices.Data.OAuthCredentials(oResult.AccessToken);

              
                AuthFactory.MsalAuthenticationResult = oResult;
                AuthFactory.oBearerToken = oResult.AccessToken;
                AuthFactory.CurrentPublicClientApplication = o.CurrentPublicClientApplication;
 
            }

            return oResult;
        }

        /// <summary>
        /// AuthFactory is a static class that holds the settings for the current authentication session.
        /// </summary>
        private class AuthFactory
        {
 

            public static string MailboxBeingAccessed = string.Empty;  // calculated mailbox being accessed.
            public static string AccountAccessingMailbox = string.Empty; // Who is effectively accessing the mailbox.

            public static RequestedAuthType AuthenticationMethod = RequestedAuthType.DefaultAuth;

 

            public static bool? UseoAuth2 = null;
            public static string OAuth2RedirectUrl = string.Empty;
            public static string OAuth2Authority = string.Empty;
            public static bool OAuth2ValidateAuthority = true;
            public static string OAuth2Scope = string.Empty;

            public static bool? UseOAuthDelegate = null;
            public static bool? UseOAuthApplication = null;
            public static string oAuthApplicationId = string.Empty;
            public static string oAuthTenantId = string.Empty;
            public static string oAuthClientSecret = string.Empty;
            public static string oAuthClientCertificatePath = string.Empty;
            public static X509Certificate2 oAuthClientCertificate = null;
            public static Microsoft.Identity.Client.AuthenticationResult MsalAuthenticationResult = null;
            public static PublicClientApplication CurrentPublicClientApplication = null;
            public static bool LogSecurityToken = false;

            public static string oBearerToken = string.Empty;




            public static bool? UserImpersonationSelected = false;
            public static ImpersonatedUserId UserToImpersonate = null;
            public static string ImpersonationType = string.Empty;
            public static string ImpersonatedId = string.Empty;

 

            public static string UserAgent;

            public static bool SetDefaultProxy = false;
            public static bool BypassProxyForLocalAddress = false;
            public static bool SpecifyProxySettings;
            public static string ProxyServerName;
            public static int ProxyServerPort;
            public static bool OverrideProxyCredentials;
            public static string ProxyServerUser;
            public static string ProxyServerPassword;
            public static string ProxyServerDomain;

            public static string Server;    
            public static int Port;
   

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txtToken_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnShowCS_Click(object sender, EventArgs e)
        {
            if (txtOAuthClientSecret.PasswordChar == '*')
                txtOAuthClientSecret.PasswordChar = '\0';
            else
                txtOAuthClientSecret.PasswordChar = '*';
             
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtImapPort_TextChanged(object sender, EventArgs e)
        {
            int i;

            if (int.TryParse(this.txtPort.Text.Trim(), out i) == false)
            {
                MessageBox.Show("Port must be an integer.  Defaulting to 993.");
                this.txtPort.Text = "993";
            }
        }

        private void txtAuthCertificatePath_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkShowSecret_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowSecret.Checked)
                txtOAuthClientSecret.PasswordChar = '\0';
            else
                txtOAuthClientSecret.PasswordChar = '*';
 
        }

        private void lblScope_Click(object sender, EventArgs e)
        {

        }

        private void lblServer_Click(object sender, EventArgs e)
        {

        }

        private void btnAuthenticate_Click(object sender, EventArgs e)
        {
       
 
        }

        private void btnParseToken_Click(object sender, EventArgs e)
        {
            string s = txtToken.Text.Trim();
            if (s == "")
                MessageBox.Show("There is no bearer token.", "Bearer Token Required");
            else
            {
                if (s.ToLower().StartsWith("bearer"))
                    MessageBox.Show("The word bearer needs to be removed.", "Only enter the token value.");
                else
                {
                    string sParsed = EWSEditor.Common.Auth.JwtHelper.ParseJwtToken(txtToken.Text.Trim());

                    ShowTextDocument oForm = new ShowTextDocument();
                    oForm.Text = "Parsed JWT Token";
                    oForm.txtEntry.Text = sParsed;
                    oForm.ShowDialog();
                    oForm = null;

                }
            }
        }
    }
}
