// EwsProxyFactory.cs 

using System;
using System.Net;
using EWSEditor.Common;
//using EWSEditor.EwsVsProxy;
using EWSEditor.Logging;
using EWSEditor.Settings;
using EWSEditor.Common.Extensions;
using Microsoft.Exchange.WebServices.Data;
using EWSEditor.Forms;
using System.Xml;

using Microsoft.Exchange.WebServices.Autodiscover;
using System.Configuration;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Identity.Client;

namespace EWSEditor.Exchange
{
    public class EwsProxyFactory
    {
        public static ExchangeVersion? RequestedExchangeVersion = null;
        public static bool? OverrideTimezone;
        public static string SelectedTimeZoneId;
        public static bool? AllowAutodiscoverRedirect = null;
        public static bool? EnableScpLookup;
        public static bool? PreAuthenticate;
        public static ExchangeCredentials ServiceCredential = null;
        public static NetworkCredential ServiceNetworkCredential = null;
        public static Microsoft.Exchange.WebServices.Data.EmailAddress ServiceEmailAddress = null;
        public static Uri EwsUrl;
        public static bool? OverrideTimeout;
        public static int? Timeout = null;

        public static string MailboxBeingAccessed = string.Empty;  // calculated mailbox being accessed.
        public static string AccountAccessingMailbox = string.Empty; // Who is effectively accessing the mailbox.

        public static RequestedAuthType AuthenticationMethod = RequestedAuthType.DefaultAuth;

        public static bool? UseAutoDiscover = null;
        public static string RequestedAutodiscoverEmail = string.Empty;
        public static string RequestedExchangeServiceURL = string.Empty;

        public static bool? UseDefaultCredentials = null;
        public static bool? CredentialsUserSpecified = null;
        public static string UserName = string.Empty;
        public static string Password = string.Empty;
        public static string Domain = string.Empty;

        public static bool? UseoAuth = null;
        public static string oAuthRedirectUrl = string.Empty;
        public static string oAuthClientId = string.Empty;
        public static string oAuthServerName = string.Empty;
        public static string oAuthAuthority = string.Empty;

        public static bool? UseoAuth2 = null;
        public static string OAuth2RedirectUrl = string.Empty;
        public static string OAuth2Authority = string.Empty;
        public static bool OAuth2ValidateAuthority = true;

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
        public static string ImpersonationType  = string.Empty;
        public static string ImpersonatedId  = string.Empty;

        public static bool? SetXAnchorMailbox = null;
        public static bool? SetXPublicFolderMailbox = null;

        public static string XAnchorMailbox;
        public static string XPublicFolderMailbox;

        public static string UserAgent;

        public static bool SetDefaultProxy =  false;
        public static bool BypassProxyForLocalAddress = false;
        public static bool SpecifyProxySettings;
        public static string ProxyServerName;
        public static int ProxyServerPort;
        public static bool OverrideProxyCredentials;
        public static string ProxyServerUser;
        public static string ProxyServerPassword;
        public static string ProxyServerDomain;

        public static bool AddTimeZoneContext = false;
        public static string SelectedTimeZoneContextId;

        public static bool EnableAdditionalHeader1 = false;
        public static string AdditionalHeader1;
        public static string AdditionalHeaderValue1;
        public static bool EnableAdditionalHeader2;
        public static string  AdditionalHeader2;
        public static string AdditionalHeaderValue2;
        public static bool EnableAdditionalHeader3;
        public static string AdditionalHeader3;
        public static string AdditionalHeaderValue3;


        public static void DoAutodiscover()
        {
            DoAutodiscover(ServiceEmailAddress);
        }

        public static void DoAutodiscover(Microsoft.Exchange.WebServices.Data.EmailAddress emailAddress)
        {
            //EWSEditor.Common.EwsEditorAppSettings oSettings = new EWSEditor.Common.EwsEditorAppSettings();

            ExchangeService service = CreateExchangeService();

    //
    // Your code here


            //service.EnableScpLookup = GlobalSettings.EnableScpLookups;
            string sError = string.Empty;

            try
            { 
                service.AutodiscoverUrl(emailAddress.Address, ValidationCallbackHelper.RedirectionUrlValidationCallback);
                EwsUrl = service.Url;
            }
            catch (AutodiscoverLocalException oException)
            {
                sError += string.Format("Error: {0}\r\n", oException.HResult);
                sError += oException.ToString();
                ErrorDialog.ShowError(sError);
            }
            catch (System.IO.IOException oIOException)
            {
                sError += string.Format("Error: {0}\r\n", oIOException.HResult);
                sError = oIOException.ToString();
                ErrorDialog.ShowError(sError);
            }
            catch (ServerBusyException srBusyException)  // 2013+
            {
                Console.WriteLine(srBusyException);
                sError += string.Format("Error: {0}\r\n", srBusyException.HResult);
                sError += "    BackOffMilliseconds: " + srBusyException.BackOffMilliseconds.ToString() + "\r\n";
                sError += "    Error Message: " + srBusyException.Message + "\r\n";
                sError += "    Inner Error Message: " + srBusyException.InnerException + "\r\n";
                sError += "    Stack Trace: " + srBusyException.StackTrace + "\r\n";
                sError += "    See: " + srBusyException.HelpLink + "\r\n";
            }

 
 
        }

        // CreateExchangeService()
        // Creates the initial service object and initializes it based-upon the class public values above.
        // This class does not create a credential object or call autodiscover.
        public static ExchangeService CreateExchangeService()
        {
            ExchangeService service = null;

            TimeZoneInfo oTimeZone = null;

             

            if (SelectedTimeZoneId != null)
            {
                if (OverrideTimezone == true)
                {
                    oTimeZone = TimeZoneInfo.FindSystemTimeZoneById(SelectedTimeZoneId);
                }
            }

            //ServicePointManager.DefaultConnectionLimit = 10;  // Winform default is 2 connections. Need more connections?  Then increase the limit.
             
            System.Diagnostics.Debug.WriteLine(" ServicePointManager.DefaultConnectionLimit: " +  ServicePointManager.DefaultConnectionLimit.ToString() );
            System.Diagnostics.Debug.WriteLine(" ServicePointManager.DefaultPersistentConnectionLimit: " +  ServicePointManager.DefaultPersistentConnectionLimit.ToString() );
       
            if (RequestedExchangeVersion.HasValue)
            {
                if (oTimeZone != null)
                    service = new ExchangeService(RequestedExchangeVersion.Value, oTimeZone);
                else
                    service = new ExchangeService(RequestedExchangeVersion.Value);
 
            }
            else
            {
                //if (oTimeZone != null)
                //    service = new ExchangeService(oTimeZone);
                //else
                //    service = new ExchangeService();

                if (oTimeZone != null)
                    service = new ExchangeService(ExchangeVersion.Exchange2010_SP2, oTimeZone);
                else
                    service = new ExchangeService(ExchangeVersion.Exchange2010_SP2);

            }
             

 
            if (UserAgent != null)
                if (UserAgent.Length != 0)
                    service.UserAgent = UserAgent;

            //service.UserAgent = UserAgent;
            //service.HttpHeaders.Add("client-request-id", Guid.NewGuid().ToString());
            //service.HttpHeaders.Add("return-client-request-id", "true");

            // EWS Tracing: http://msdn.microsoft.com/en-us/library/office/dn495632(v=exchg.150).aspx
            service.TraceEnabled = true;
            service.TraceEnablePrettyPrinting = true;
            service.TraceListener = new EWSEditor.Logging.EwsTraceListener();

            // Instrumentation settings: http://msdn.microsoft.com/en-us/library/office/dn720380(v=exchg.150).aspx
            service.ReturnClientRequestId = true;  // This will give us more data back about the servers used in the response headers
            service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.
            service.SendClientLatencies = true;  // sends latency info which is used by Microsoft to improve EWS and Exchagne 365.

            if (EnableScpLookup.HasValue)
            {
                service.EnableScpLookup = EnableScpLookup.Value;
            }

            if (PreAuthenticate.HasValue)
            {
                service.PreAuthenticate = PreAuthenticate.Value;
            }
            

            if (OverrideTimeout.HasValue)
            {
                if (OverrideTimeout == true)
                {
                    if (Timeout.HasValue)
                        service.Timeout = (int)Timeout;
                }
            }

           // Proxy server settings for the 'service' object.
           if (SpecifyProxySettings == true)
            {
                WebProxy oWebProxy  = null;
                oWebProxy = new WebProxy(ProxyServerName, ProxyServerPort);
                oWebProxy.BypassProxyOnLocal = BypassProxyForLocalAddress;
   
                if (OverrideProxyCredentials == true)
                {
                    if (ProxyServerUser.Trim().Length == 0)
                    {
                        oWebProxy.UseDefaultCredentials = true;
                    }
                    else
                    { 
                        if (ProxyServerDomain.Trim().Length == 0)
                            oWebProxy.Credentials = new NetworkCredential(ProxyServerUser, ProxyServerPassword);
                        else
                            oWebProxy.Credentials = new NetworkCredential(ProxyServerUser, ProxyServerPassword, ProxyServerDomain);
                    }
                }   
                else
                {
                    oWebProxy.UseDefaultCredentials = true;
                }
                service.WebProxy = oWebProxy;
            }
 

            if (ServiceCredential != null)
            {
                service.Credentials = ServiceCredential;
            }

            if (EwsUrl != null)
            {
                service.Url = EwsUrl;
            }

 

            if (UseDefaultCredentials.HasValue)
            {
                service.UseDefaultCredentials = UseDefaultCredentials.Value;
            }

            if (UserToImpersonate != null)
            {
                service.ImpersonatedUserId = UserToImpersonate;

                // Set headers which help with affinity when Impersonation is being used against Exchange 2013 and Exchagne Online 15.
                // http://blogs.msdn.com/b/mstehle/archive/2013/07/17/more-affinity-considerations-for-exchange-online-and-exchange-2013.aspx
 
            }

            if (SetXAnchorMailbox == true)
            {
                service.HttpHeaders.Add("X-AnchorMailbox", XAnchorMailbox);
            }
            if (SetXPublicFolderMailbox == true)
            {
                service.HttpHeaders.Add("X-PublicFolderMailbox",  XPublicFolderMailbox);
            }


            // Additional headers for service object to add to requests.
            if (EnableAdditionalHeader1 == true)
                service.HttpHeaders.Add(AdditionalHeader1, AdditionalHeaderValue1);
            if (EnableAdditionalHeader2 == true)
                service.HttpHeaders.Add(AdditionalHeader2, AdditionalHeaderValue2);
            if (EnableAdditionalHeader3 == true)
                service.HttpHeaders.Add(AdditionalHeader3, AdditionalHeaderValue3);
             
 
            return service;
        }



        /// <summary>
        ///  This is used for preparing an HttpWebRequest for a raw post.
        /// </summary>
        /// <param name="oRequest"></param>
        public static void CreateHttpWebRequest(ref HttpWebRequest oRequest)
        {
            HttpWebRequest oHttpWebRequest = (HttpWebRequest)WebRequest.Create(EwsUrl);
             
            if (UserAgent.Length != 0)
                oHttpWebRequest.UserAgent = UserAgent;
 

            oHttpWebRequest.Method = "POST";
            oHttpWebRequest.ContentType = "text/xml";


            if (OverrideTimeout.HasValue)

            {
                if (OverrideTimeout == true)
                {
                    if (Timeout.HasValue)
                        oHttpWebRequest.Timeout = (int)Timeout;
                }
            }

            oHttpWebRequest.Headers.Add("Translate", "f");
            oHttpWebRequest.Headers.Add("Pragma", "no-cache");
            oHttpWebRequest.Headers.Add("return-client-request-id", "true");  // This will give us more data back about the servers used in the response headers
            oHttpWebRequest.Headers.Add("client-request-id", Guid.NewGuid().ToString());   
            if (PreAuthenticate.HasValue)
            {
                oHttpWebRequest.Headers.Add("PreAuthenticate", PreAuthenticate.Value.ToString());
            }

            // TODO:  Add timezone injection
            //TimeZoneInfo oTimeZone = null;
            //if (SelectedTimeZoneId != null)
            //{
            //    if (OverrideTimezone == true)
            //    {
            //        oTimeZone = TimeZoneInfo.FindSystemTimeZoneById(SelectedTimeZoneId);
            //    }
            //}

              


            if (SpecifyProxySettings == true)
            {
                 WebProxy oWebProxy  = null;
                 oWebProxy = new WebProxy(ProxyServerName, ProxyServerPort);
 
                oWebProxy.BypassProxyOnLocal = BypassProxyForLocalAddress;
   

                if (OverrideProxyCredentials == true)
                {
                     
                    if (ProxyServerUser.Trim().Length == 0)
                    {
                        oWebProxy.UseDefaultCredentials = true;
                    }
                    else
                    { 
                        if (ProxyServerDomain.Trim().Length == 0)
                            oWebProxy.Credentials = new NetworkCredential(ProxyServerUser, ProxyServerPassword);
                        else
                            oWebProxy.Credentials = new NetworkCredential(ProxyServerUser, ProxyServerPassword, ProxyServerDomain);
                    }
                }   
                else
                {

                    oWebProxy.UseDefaultCredentials = true;
                }
                oHttpWebRequest.Proxy = oWebProxy;
            }


            if (UseDefaultCredentials.HasValue)
            {
                oHttpWebRequest.UseDefaultCredentials = UseDefaultCredentials.Value;
            }
          

            if (ServiceCredential != null)
            {
                oHttpWebRequest.Credentials =  ServiceNetworkCredential ;
            }

            if (oBearerToken != string.Empty)
            {
                oHttpWebRequest.Headers.Add("Authorization", "Bearer " + oBearerToken);

      

            }



            if (UserToImpersonate != null)
            {
                //service.ImpersonatedUserId = UserToImpersonate;
                // TODO: Add injection of impersonation.
 
            }

            oRequest = oHttpWebRequest;
 

        }

         

        public static void InitializeWithDefaults()
        {
            InitializeWithDefaults(null, null, null);
        }

        /// <summary>
        /// Create a service binding based off of default credentials,
        /// the assumed root folder, and an assumed autodiscover email address
        /// </summary>
        /// <param name="version">EWS schema version to use.  Passing NULL uses the
        /// EWS Managed API default value.</param>
        /// <param name="ewsUrl">URL to EWS endpoint.  Passing NULL or an empty string
        /// results in a call to Autodiscover</param>
        /// <param name="autodiscoverAddress">Email address to use for Autodiscover.
        /// Passing NULL or an empty string results in a ActiveDirectory querying.</param>
        /// <returns>A new instance of an ExchangeService</returns>
        private static void InitializeWithDefaults(ExchangeVersion? version, Uri ewsUrl, string autodiscoverAddress)
        {
            RequestedExchangeVersion = version;
            UseDefaultCredentials = true;

            // If the EWS URL is not specified, use Autodiscover to find it
            if (ewsUrl == null)
            {
                // If no email address was given to use with Autodiscover, attempt
                // to look it up in Active Directory
                if (String.IsNullOrEmpty(autodiscoverAddress))
                {
                    autodiscoverAddress = ActiveDirectoryHelper.GetPrimarySmtp(
                        System.Security.Principal.WindowsIdentity.GetCurrent().Name);
                }

                DoAutodiscover(autodiscoverAddress);
            }
            else
            {
                EwsUrl = ewsUrl;
            }

            try
            {
                //EWSEditor.Common.EwsEditorAppSettings oSettings = new EWSEditor.Common.EwsEditorAppSettings();
                CreateExchangeService().TestExchangeService();
            }
            catch (ServiceVersionException ex)
            {
                DebugLog.WriteVerbose("Initial requested version of Exchange2010 didn't work, trying Exchange 2007_SP1", ex);
                // Pass the autodiscover email address and URL if we've already looked those up
                InitializeWithDefaults(ExchangeVersion.Exchange2007_SP1, EwsUrl, autodiscoverAddress);
            }

        }

        public static void  SetAppSettingsFromProxyFactory (ref EWSEditor.Common.EwsEditorAppSettings oSettings)
        {

            oSettings.LogSecurityToken = LogSecurityToken;
            oSettings.oBearerToken = oBearerToken;

            oSettings.MailboxBeingAccessed = MailboxBeingAccessed;
            oSettings.AccountAccessingMailbox = AccountAccessingMailbox;

            if (EwsUrl != null)
                oSettings.UrlHost = EwsUrl.Host;
            else
                oSettings.UrlHost = "";

            oSettings.AuthenticationMethod = AuthenticationMethod;  // Default, UserSpecified, oAuth

            oSettings.UseAutoDiscover = (bool)UseAutoDiscover;
            oSettings.RequestedAutodiscoverEmail = RequestedAutodiscoverEmail;
            oSettings.RequestedExchangeServiceURL = RequestedExchangeServiceURL;

            oSettings.RequestedExchangeVersion = RequestedExchangeVersion;

            oSettings.UserName = UserName;
            oSettings.Password = Password;
            oSettings.Domain = Domain;

            oSettings.UserImpersonationSelected = (bool)UserImpersonationSelected;
            oSettings.UserToImpersonate = UserToImpersonate;
            oSettings.ImpersonationType = ImpersonationType;
            oSettings.ImpersonatedId = ImpersonatedId;

            oSettings.UseoAuth = UseoAuth;
            oSettings.oAuthRedirectUrl = oAuthRedirectUrl;
            oSettings.oAuthClientId = oAuthClientId;
            oSettings.oAuthServerName = oAuthServerName;
            oSettings.oAuthAuthority = oAuthAuthority;

            oSettings.UseoAuth2 = UseoAuth2;
            oSettings.OAuth2RedirectUrl = OAuth2RedirectUrl;
            oSettings.OAuth2Authority = OAuth2Authority;
            oSettings.OAuth2ValidateAuthority = OAuth2ValidateAuthority;

            oSettings.UseOAuthDelegate = UseOAuthDelegate;
            oSettings.UseOAuthApplication = UseOAuthApplication;
            oSettings.oAuthApplicationId = oAuthApplicationId;
            oSettings.oAuthTenantId = oAuthTenantId;
            oSettings.oAuthClientSecret = oAuthClientSecret;
            oSettings.oAuthClientCertificate = oAuthClientCertificate;

            oSettings.oBearerToken = oBearerToken;
            oSettings.LogSecurityToken = LogSecurityToken;

            oSettings.EnableAdditionalHeader1 = EnableAdditionalHeader1;
            oSettings.AdditionalHeader1 = AdditionalHeader1;
            oSettings.AdditionalHeaderValue1 = AdditionalHeaderValue1;
            oSettings.EnableAdditionalHeader2 = EnableAdditionalHeader2;
            oSettings.AdditionalHeader2 = AdditionalHeader2;
            oSettings.AdditionalHeaderValue2 = AdditionalHeaderValue2;
            oSettings.EnableAdditionalHeader3 = EnableAdditionalHeader3;
            oSettings.AdditionalHeader3 = AdditionalHeader3;
            oSettings.AdditionalHeaderValue3 = AdditionalHeaderValue3;

        }

 
    }
}
