using System;
using System.Net;
using EWSEditor.Common;
using EWSEditor.EwsVsProxy;
using EWSEditor.Logging;
using EWSEditor.Settings;
using EWSEditor.Common.Extensions;
using Microsoft.Exchange.WebServices.Data;
using EWSEditor.Forms;

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
        public static NetworkCredential ServiceCredential = null;
        public static Microsoft.Exchange.WebServices.Data.EmailAddress ServiceEmailAddress = null;
        public static Uri EwsUrl;
        public static bool? OverrideTimeout;
        public static int? Timeout = null;
        public static bool? UseDefaultCredentials = null;
        public static ImpersonatedUserId UserToImpersonate = null;
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

 

        public static void DoAutodiscover()
        {
            DoAutodiscover(ServiceEmailAddress);
        }

        public static void DoAutodiscover(Microsoft.Exchange.WebServices.Data.EmailAddress emailAddress)
        {
            ExchangeService service = CreateExchangeService();
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

            //try
            //{
            //    service.EnableScpLookup = GlobalSettings.EnableScpLookups;
            //    service.AutodiscoverUrl(emailAddress.Address, ValidationCallbackHelper.RedirectionUrlValidationCallback);
            //    EwsUrl = service.Url;
            //}
            //catch (AutodiscoverLocalException oException)
            //{
            //    ErrorDialog.ShowError(oException.ToString());
            //}
 
        }
 
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

            if (RequestedExchangeVersion.HasValue)
            {
                if (oTimeZone != null)
                    service = new ExchangeService(RequestedExchangeVersion.Value, oTimeZone);
                else
                    service = new ExchangeService(RequestedExchangeVersion.Value);

              
                //System.Diagnostics.Debug.WriteLine(service.PreferredCulture);
   
            }
            else
            {
                if (oTimeZone != null)
                    service = new ExchangeService(oTimeZone);
                else
                    service = new ExchangeService( ); 
            }

            if (UserAgent.Length != 0)
                service.UserAgent = UserAgent;

            service.TraceEnabled = true;
            service.TraceListener = new EWSEditor.Logging.EwsTraceListener();

            service.ReturnClientRequestId = true;  // This will give us more data back about the servers used in the response headers

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
                if (service.RequestedServerVersion.ToString().StartsWith("Exchange2007") == false &&
                    service.RequestedServerVersion.ToString().StartsWith("Exchange2010") == false)
                {
                    //// Should set for 365...:

                    //if (service.HttpHeaders.ContainsKey("X-AnchorMailbox") == false)
                    //    service.HttpHeaders.Add("X-AnchorMailbox", service.ImpersonatedUserId.Id);
                    //else
                    //    service.HttpHeaders["X-AnchorMailbox"] = service.ImpersonatedUserId.Id;

                    //if (service.HttpHeaders.ContainsKey("X-PreferServerAffinity") == false)
                    //    service.HttpHeaders.Add("X-PreferServerAffinity", "true");
                    //else
                    //    service.HttpHeaders["X-PreferServerAffinity"] = "true";
                } 
            }

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
                oHttpWebRequest.Headers.Add("UserAgent", UserAgent);

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

            //if (RequestedExchangeVersion.HasValue)
            //{
            //    if (oTimeZone != null)
            //        service = new ExchangeService(RequestedExchangeVersion.Value, oTimeZone);
            //    else
            //        service = new ExchangeService(RequestedExchangeVersion.Value);


            //    //System.Diagnostics.Debug.WriteLine(service.PreferredCulture);

            //}
            //else
            //{
            //    if (oTimeZone != null)
            //        service = new ExchangeService(oTimeZone);
            //    else
            //        service = new ExchangeService();
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
                oHttpWebRequest.Credentials = ServiceCredential;
            }
            //else
            //{
            //    oHttpWebRequest.Credentials =   GetNetworkCredential();
   
            //}

 

            //if (ServiceCredential != null)
            //{
            //    service.Credentials = ServiceCredential;
            //}

            //    if (sAuthentication == "DefaultCredentials")
            //    {
            //        oHttpWebRequest.UseDefaultCredentials = true;
            //        oHttpWebRequest.Credentials = CredentialCache.DefaultCredentials;
            //    }
            //    else
            //    {
            //        if (sAuthentication == "DefaultNetworkCredentials")
            //            oHttpWebRequest.Credentials = CredentialCache.DefaultNetworkCredentials;
            //        else
            //        {
            //            oHttpWebRequest.Credentials = oCrentialCache;
            //        }
            //    }

 
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
                CreateExchangeService().TestExchangeService();
            }
            catch (ServiceVersionException ex)
            {
                DebugLog.WriteVerbose("Initial requested version of Exchange2010 didn't work, trying Exchange 2007_SP1", ex);
                // Pass the autodiscover email address and URL if we've already looked those up
                InitializeWithDefaults(ExchangeVersion.Exchange2007_SP1, EwsUrl, autodiscoverAddress);
            }

        }
    }
}
