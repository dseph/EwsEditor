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

//using Microsoft.Identity.Client;
//using System.Threading.Tasks;
//using System.Net.Sockets;
//using System.Text;
//using System.Net.Security;



namespace EWSEditor.Forms.SMTP
{
    public partial class SmtpTest : Form
    {


        private static TcpClient _smtpClient = null;
        private static SslStream _sslStream = null;
        public StringBuilder oSB = new StringBuilder();

        public SmtpTest()
        {
            InitializeComponent();
        }

        private void SmtpTest_Load(object sender, EventArgs e)
        {
            SetAuthEnablement();
        }

        ////private void TestIMAP()
        ////{

        ////    AuthenticationResult authResult = GetToken();
        ////    RetrieveMessages(authResult);
             
        ////}

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

        string TestSMTP(AuthenticationResult authResult, string mimeContent = "")
        {  

            oSB = new StringBuilder();
            var smtpScope = AuthFactory.OAuth2Scope;

            try
            {
                
                // Use the token to connect to SMTP service
                string SendResult = SendMessageToSelf(authResult, mimeContent);
                oSB.AppendLine(SendResult);

            }
            catch (MsalException ex)
            {
                oSB.AppendLine($"Error acquiring access token: {ex}");
            }
            catch (Exception ex)
            {
                oSB.AppendLine($"Error: {ex}");
            }
            oSB.AppendLine("Finished");

            return oSB.ToString();

        }

        string SendMessageToSelf(AuthenticationResult authResult, string sMime = "")
        {
            oSB = new StringBuilder();
            try
            {
 
                using (_smtpClient = new TcpClient(AuthFactory.Server, AuthFactory.Port))
                {
                    NetworkStream smtpStream = _smtpClient.GetStream();
                    try
                    {
                        // We need to initiate the TLS connection                       
                        if (!ReadNetworkStream(smtpStream).StartsWith("220"))
                            throw new Exception("Unexpected welcome message");

                        WriteNetworkStream(smtpStream, "EHLO OAuthTest.app");
                        if (!ReadNetworkStream(smtpStream).StartsWith("250"))
                            throw new Exception("Failed on EHLO");

                        WriteNetworkStream(smtpStream, "STARTTLS");
                    }
                    catch (Exception ex)
                    {
                        // We've received an error or unexpected response.  We'll send a QUIT as there's nothing more we can do.
                       
                        oSB.AppendLine(ex.Message);
                        WriteNetworkStream(smtpStream, "QUIT");
                        smtpStream.Close();
                        smtpStream = null;
                    }

                    if (smtpStream != null && ReadNetworkStream(smtpStream).StartsWith("220"))
                    {
                        // Now we can initialise and communicate over an encrypted connection
                        using (_sslStream = new SslStream(smtpStream))
                        {
                            _sslStream.AuthenticateAsClient("outlook.office365.com");

                            try
                            {
                                // EHLO again
                                WriteSSLStream("EHLO");
                                ReadSSLStream();

                                // Initiate OAuth login
                                WriteSSLStream("AUTH XOAUTH2");
                                if (!ReadSSLStream().StartsWith("334"))
                                    throw new Exception("Failed on AUTH XOAUTH2");

                                // Send OAuth token
                                WriteSSLStream(XOauth2(authResult));
                                if (!ReadSSLStream().StartsWith("235"))
                                    throw new Exception("Log on failed");

                                // Logged in, send test message

                                // MAIL FROM
                                WriteSSLStream($"MAIL FROM:<{authResult.Account.Username}>");
                                if (!ReadSSLStream().StartsWith("250"))
                                    throw new Exception("Failed at MAIL FROM");

                                // RCPT TO
                                WriteSSLStream($"RCPT TO:<{authResult.Account.Username}>");
                                if (!ReadSSLStream().StartsWith("250"))
                                    throw new Exception("Failed at RCPT TO");

                                // DATA
                                WriteSSLStream("DATA");
                                if (!ReadSSLStream().StartsWith("354"))
                                    throw new Exception("Failed at DATA");

                                if (String.IsNullOrEmpty(sMime))
                                    WriteSSLStream($"Subject: OAuth SMTP Test Message{Environment.NewLine}{Environment.NewLine}This is a test.{Environment.NewLine}.{Environment.NewLine}");
                                else
                                {
                                    // Read the .eml file and send that
                                    WriteSSLStream($"{System.IO.File.ReadAllText(sMime)}{Environment.NewLine}.{Environment.NewLine}");
                                }

                                ReadSSLStream();
                            }
                            catch (Exception ex)
                            {
                                oSB.AppendLine(ex.Message);
                            }
                            WriteSSLStream("QUIT");
                            ReadSSLStream();

                            oSB.AppendLine("Closing connection");
                        }
                    }
                    smtpStream?.Close();
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


         

        static string ReadNetworkStream(NetworkStream Stream)
        {
            int bytes = -1;
            byte[] buffer = new byte[4096];
            bytes = Stream.Read(buffer, 0, buffer.Length);
            string response = Encoding.ASCII.GetString(buffer, 0, bytes);
            Console.WriteLine(response); // We add a blank line after the response as it makes the output easier to read
            return response;
        }

        static void WriteNetworkStream(NetworkStream Stream, string Data)
        {
            if (!Data.EndsWith(Environment.NewLine))
                Data = $"{Data}{Environment.NewLine}";
            byte[] myWriteBufferNetworkStream = Encoding.ASCII.GetBytes(Data);
            Stream.Write(myWriteBufferNetworkStream, 0, myWriteBufferNetworkStream.Length);
            Stream.Flush();
            Console.Write(Data);
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

                
            }

            if (rdoCredentialsOAuthDelegated.Checked)
            {
 
                // Delegate flow scopes
                cmboScope.Items.Clear();
                cmboScope.Items.Add("https://outlook.office.com/SMTP.Send");
 
 
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            string sMimeContent = txtMime.Text;
            AuthenticationResult authResult = GetToken();
            this.txtToken.Text  =  authResult.AccessToken;

            string s = TestSMTP(authResult, sMimeContent);
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

        private void txtPort_TextChanged(object sender, EventArgs e)
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
