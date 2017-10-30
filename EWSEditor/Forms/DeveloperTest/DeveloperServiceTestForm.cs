using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics.Tracing;

using EWSEditor.Common;
using EWSEditor.Exchange;
using EWSEditor.Logging;
using EWSEditor.Resources;
using EWSEditor.Settings;
using System.Net;
using System.Xml;
using Microsoft.Exchange.WebServices.Data;
using Microsoft.IdentityModel.Clients.ActiveDirectory;


using System.Configuration;
using System.Globalization;
using System.Web.Script.Serialization;
using Microsoft.Exchange.WebServices.Autodiscover;
using System.Diagnostics;


// This form is a convient place for a developer to integrate their code on an ExchangeService level in order to do testing.
// 
namespace EWSEditor.Forms
{
    public partial class DeveloperServiceTestForm : Form
    {
        ExchangeService _service = null;

        public DeveloperServiceTestForm()
        {
            InitializeComponent();
        }

        public DeveloperServiceTestForm(ExchangeService service)
        {
            InitializeComponent();
            _service = service;
        }

        private void DeveloperToolsTestWindow_Load(object sender, EventArgs e)
        {

            StringBuilder oSB = new StringBuilder();
            oSB.Append("This windows is to be used by developers with EWSEditor source in order that they may test their EWS Managed API code to work on the initialized ExchangeService object.");
            oSB.Append("  The ExchangeService is availible in this form and so that you can use it with your custom test code.");
            oSB.AppendLine("");
            oSB.AppendLine("");
            oSB.AppendFormat("Service.Url.AbsolutePath: {0}\r\n", _service.Url.AbsoluteUri.ToString());


            textBox1.Text = oSB.ToString();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Service URL: " + _service.Url);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Read 
            //  Using OAuth2 to access Calendar, Contact and Mail API in Office 365 Exchange Online
            //  https://blogs.msdn.microsoft.com/exchangedev/2014/03/25/using-oauth2-to-access-calendar-contact-and-mail-api-in-office-365-exchange-onli
            // 
            // Authorize access to web applications using OAuth 2.0 and Azure Active Directory
            // https://docs.microsoft.com/en-us/azure/active-directory/develop/active-directory-protocols-oauth-code
            // Note: Tells how to setup Azure for oAuth.
            // Azure portal:  https://portal.azure.com
            // Step by step instrucitons for setting it up in Azure:  https://docs.microsoft.com/en-us/azure/active-directory/develop/active-directory-protocols-oauth-code
            // 
            // Integrating applications with Azure Active Directory
            // https://docs.microsoft.com/en-us/azure/active-directory/develop/active-directory-integrating-applications#BKMK_Native
            //
            //  Building Daemon or Service Apps with Office 365 Mail, Calendar, and Contacts APIs (OAuth2 client credential flow)
            //  https://blogs.msdn.microsoft.com/exchangedev/2015/01/21/building-daemon-or-service-apps-with-office-365-mail-calendar-and-contacts-apis-oauth2-client-credential-flow/
            //
            // Office 365 / EWS Authentication using OAuth
            // https://stackoverflow.com/questions/22892650/office-365-ews-authentication-using-oauth
            //  
            string sAdmin = "danba@dseph.onmicrosoft.com";
            string sImpersonationAccount = "mrimpersonation@dseph.onmicrosoft.com";
            string sAccessMailbox = "User1@dseph.onmicrosoft.com ";
            string sSecretary = "secretary@dseph.onmicrosoft.com";
            string sBoss = "theboss @dseph.onmicrosoft.com";
            string sMine = "danba@microsoft.com";

            //ServicePointManager.ServerCertificateValidationCallback = CertificateValidationCallBack;
            DisplayRootFolderChildCount(sMine);
 
        }


        private bool CertificateValidationCallBack(
         object sender,
         System.Security.Cryptography.X509Certificates.X509Certificate certificate,
         System.Security.Cryptography.X509Certificates.X509Chain chain,
         System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            // If the certificate is a valid, signed certificate, return true.
            if (sslPolicyErrors == System.Net.Security.SslPolicyErrors.None)
                return true;

            // If there are errors in the certificate chain, look at each error to determine the cause.
            if ((sslPolicyErrors & System.Net.Security.SslPolicyErrors.RemoteCertificateChainErrors) != 0)
            {

                if (chain != null && chain.ChainStatus != null)
                {
                    foreach (System.Security.Cryptography.X509Certificates.X509ChainStatus status in chain.ChainStatus)
                    {
                        if ((certificate.Subject == certificate.Issuer) &&
                           (status.Status == System.Security.Cryptography.X509Certificates.X509ChainStatusFlags.UntrustedRoot))
                        {
                            // Self-signed certificates with an untrusted root are valid. 
                            continue;
                        }
                        else
                        {
                            if (status.Status != System.Security.Cryptography.X509Certificates.X509ChainStatusFlags.NoError)
                            {
                                // If there are any other errors in the certificate chain, the certificate is invalid,
                                // so the method returns false.
                                return false;
                            }
                        }
                    }
                }


                // When processing reaches this line, the only errors in the certificate chain are 
                // untrusted root errors for self-signed certificates. These certificates are valid
                // for default Exchange server installations, so return true.
                return  true;
            }
            else
            {
                // In all other cases, return false.
                return false;
            }
        }



        private void test()
        {
 
            //// https://msdn.microsoft.com/EN-US/library/office/dn903761(v=exchg.150).aspx


            //string sAuthority = string.Empty;
            //string sClientID = string.Empty;
            //string sClientAppUri = string.Empty;
            //string sServerName = string.Empty;

            //sAuthority = "http://login.windows.net/danba.onmicrosoft.com";
            //sClientID = "EWSEditor";
            //Uri uriClientAppUri = new Uri("xxxxxxxxxxxxxxx"];
            //sServerName = "outlook.office365.com";

            //AuthenticationResult authenticationResult = null;
            //AuthenticationContext authenticationContext = new AuthenticationContext(sAuthority, false);



            //// Set Azure AD Tenant name; not used in this script 
            //string adTenant = "domain.onmicrosoft.com";

            //// Set well-known client ID from Azure AD for this application
            //// It is in the form of a guid 1a2b34c5-da6b-7777-ef8a-g9h001i23456
            //string clientId = "client-id";

            //// Set redirect URI from Azure AD for this application - e.g https://myapp/reply
            //string redirectUri = "reply-url";

            //// Set Resource URI to Office 365 in this case
            //string resourceAppIdURI = "https://outlook.office365.com/";  // Set Resource URI to Office 365 in this case

            //// Set Authority to Azure AD Tenant
            ////http://stackoverflow.com/questions/26384034/how-to-get-the-azure-account-tenant-id
            //string authority = "https://login.windows.net/<tenant-id>/oauth2/authorize";

            //// Create Authentication Context tied to Azure AD Tenant

            //// //$authContext = New - Object "Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationContext" - ArgumentList $authority

            ////AuthenticationContext authenticationContext = new AuthenticationContext(authority, false);
            //// // Acquire token

            //// $authResult = $authContext.AcquireToken($resourceAppIdURI, $clientId, $redirectUri, "Auto")

            //// //// Code From http://poshcode.org/624
            //// //// Create a compilation environment
            //// $Provider = New - Object Microsoft.CSharp.CSharpCodeProvider
            //// $Compiler =$Provider.CreateCompiler()
            //// $Params = New - Object System.CodeDom.Compiler.CompilerParameters
            //// $Params.GenerateExecutable =$False
            //// $Params.GenerateInMemory =$True
            //// $Params.IncludeDebugInformation =$False
            //// $Params.ReferencedAssemblies.Add("System.DLL") | Out - Null

            //// $TASource =@'
            ////   namespace Local.ToolkitExtensions.Net.CertificatePolicy
            ////     {
            ////         public class TrustAll : System.Net.ICertificatePolicy
            ////         {
            ////             public TrustAll()
            ////             {
            ////             }
            ////             public bool CheckValidationResult(System.Net.ServicePoint sp,
            ////               System.Security.Cryptography.X509Certificates.X509Certificate cert,
            ////               System.Net.WebRequest req, int problem)
            ////             {
            ////                 return true;
            ////             }
            ////         }
            ////     }
            //// '@ 
            //// $TAResults=$Provider.CompileAssemblyFromSource($Params,$TASource)
            //// $TAAssembly=$TAResults.CompiledAssembly

            //// //// We now create an instance of the TrustAll and attach it to the ServicePointManager
            //// $TrustAll=$TAAssembly.CreateInstance("Local.ToolkitExtensions.Net.CertificatePolicy.TrustAll")
            //// [System.Net.ServicePointManager]::CertificatePolicy=$TrustAll


            //// Import-Module -Name "C:\Program Files\Microsoft\Exchange\Web Services\2.2\Microsoft.Exchange.WebServices.dll"

            //// $service = new-object Microsoft.Exchange.WebServices.Data.ExchangeService([Microsoft.Exchange.WebServices.Data.ExchangeVersion]::Exchange2010_SP2)

            //// $service.Url = new-object System.Uri("https://outlook.office365.com/ews/exchange.asmx")

            //// $service.Credentials  = new-object Microsoft.Exchange.WebServices.Data.OAuthCredentials($authResult.AccessToken)

            //// $inbox = [Microsoft.Exchange.WebServices.Data.Folder]::Bind($service, [Microsoft.Exchange.WebServices.Data.WellKnownFolderName]::Inbox)
            //// ""
            //// "Total items in Inbox : " + $inbox.TotalCount
            //// $view = New-Object Microsoft.Exchange.WebServices.Data.ItemView(5)
            //// $findItemResults = $service.FindItems([Microsoft.Exchange.WebServices.Data.WellKnownFolderName]::Inbox,$view)
            //// ""

            //// "Printing subject of last five items from Inbox:"

            //// ""
            //// $item = [Microsoft.Exchange.WebServices.Data.Item]

            //// $i = 1

            //// foreach ($item in $findItemResults)
            //// {
            //// "Subject " + $i + ": " + $item.Subject
            //// $i = $i + 1 
            //// ""
            //// }
            ////         }
        }


        //public bool GetOAuthAdminFlowAccessToken(  
            //string sAuthority, string sAppId, string sRedirectURL, string sServername, 
            // ref string AccountAccessingMailbox,
            //ref string sAccessToken)

        private bool GetOAuthAdminFlowAccessToken(ref string sAccessToken)
        {
            string sAuthority = string.Empty;
            string sClientID = string.Empty;
            string sClientAppUri = string.Empty;
            string sServerName = string.Empty;

            sAuthority = "https://login.windows.net/common";
            sClientID = "EWSEditor";
            Uri uriClientAppUri = new Uri("https://microsoft.com/EwsEditor");  // Redirect
            sServerName = "https://outlook.office365.com";

            AuthenticationResult oAuthenticationResult = null;
            AuthenticationContext oAuthenticationContext = null;
            oAuthenticationContext = new AuthenticationContext(sAuthority, false);
            //  Application registration portal - graph:  https://apps.dev.microsoft.com/
            //  Application registration portal - EWS:  https://dev.outlook.com/AppRegistration 

            oAuthenticationResult = oAuthenticationContext.AcquireToken(sServerName, sClientID, uriClientAppUri, PromptBehavior.Never);

            string errorMessage = null;
            try
            {
                oAuthenticationResult = oAuthenticationContext.AcquireToken(sServerName, sClientID, uriClientAppUri);
            }
            catch (AdalException ex)
            {
                errorMessage = ex.Message;
                if (ex.InnerException != null)
                {
                    MessageBox.Show("InnerException: " + ex.InnerException.Message, "Error");
                    return false;
                }
            }
            catch (ArgumentException ex)
            {
                errorMessage = ex.Message;
                MessageBox.Show("Error: " + ex.Message, "Error");
                return false;
            }

            if (!string.IsNullOrEmpty(errorMessage))
            {
                Console.WriteLine("Failed: {0}" + errorMessage);
                MessageBox.Show("Failed: " + errorMessage, "Error");
                return false;
            }
 
           string  MailboxBeingAccessed = oAuthenticationResult.UserInfo.DisplayableId;
           // AccountAccessingMailbox = oAuthenticationResult.UserInfo.DisplayableId;  // oAuth at this time does not support delegate or impersonation access - may need to change this in the future.


            sAccessToken = oAuthenticationResult.AccessToken;
            return true;

        }


        private ExchangeService GetExchangeService(string sMailbox, bool bTraceLogging)

        {
            ExchangeService oService = new ExchangeService(ExchangeVersion.Exchange2016, TimeZoneInfo.Local);
            oService.HttpHeaders.Add("X-AnchorMailbox", sMailbox);
            oService.ImpersonatedUserId = new ImpersonatedUserId(ConnectingIdType.SmtpAddress, sMailbox);


            if (bTraceLogging)
            {
                oService.TraceFlags = TraceFlags.All;
                oService.TraceEnabled = true;
            }

            //string accessToken = GetOAuthAdminFlowAccessToken();
            //if (!string.IsNullOrEmpty(accessToken))
            //    oService.HttpHeaders.Add("Authorization", "Bearer " + accessToken);

            string sAccessToken = string.Empty;
            if (GetOAuthAdminFlowAccessToken(ref sAccessToken))
                oService.Credentials = new OAuthCredentials(sAccessToken);  // https://msdn.microsoft.com/en-us/library/office/dn903761(v=exchg.150).aspx

            return oService;

        }

        private void ClearMailboxFromExchagneService(ref ExchangeService oExchangeService)
        {
            //Clean-up
            if (!string.IsNullOrEmpty("X-AnchorMailbox"))
                oExchangeService.HttpHeaders.Remove("X-AnchorMailbox");

            if (oExchangeService.ImpersonatedUserId != null)
                oExchangeService.ImpersonatedUserId = null;
        }

        public bool DisplayRootFolderChildCount(string sMailbox)
        {

            bool bRet = false;
            ExchangeService oService = null;
            oService = GetExchangeService(sMailbox, false);

            // Do Work.
            int iCount = 0;
            FindFoldersResults oFindFoldersResults = null;
            oFindFoldersResults = oService.FindFolders(WellKnownFolderName.Root, new FolderView(10));
            foreach (Folder oFolder in oFindFoldersResults.Folders)
            {
                iCount++;
                bRet = true;
            }
            MessageBox.Show("Folders Found: " + iCount.ToString(), "Read from mailbox.");

            //Clean-up
            ClearMailboxFromExchagneService(ref oService);

            return bRet;
        }


        //public bool Do_OAuth(ref ExchangeService oService, ref string MailboxBeingAccessed, ref string AccountAccessingMailbox,
        //    string sAuthority, string sAppId, string sRedirectURL, string sServername)
        //{
        //    bool bRet = false;


        //    // See // https://msdn.microsoft.com/en-us/library/office/dn903761%28v=exchg.150%29.aspx?f=255&MSPPError=-2147217396#bk_getToken
        //    // get authentication token
        //    string authority = sAuthority;
        //    string clientID = sAppId;
        //    Uri clientAppUri = new Uri(sRedirectURL);
        //    string serverName = sServername;

        //    AuthenticationContext authenticationContext = new AuthenticationContext(authority, false);

        //    AuthenticationResult authenticationResult = authenticationContext.AcquireToken(serverName, clientID, clientAppUri, PromptBehavior.Always);

        //    //System.Diagnostics.Debug.WriteLine(authenticationResult.UserInfo.DisplayableId);
        //    MailboxBeingAccessed = authenticationResult.UserInfo.DisplayableId;
        //    AccountAccessingMailbox = authenticationResult.UserInfo.DisplayableId;  // oAuth at this time does not support delegate or impersonation access - may need to change this in the future.

        //    // Add authenticaiton token to requests
        //    oService.Credentials = new OAuthCredentials(authenticationResult.AccessToken);

        //    bRet = true;
        //    return bRet;

 
 

    }
}
