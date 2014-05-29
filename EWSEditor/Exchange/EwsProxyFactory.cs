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

            service.UserAgent = GlobalSettings.UserAgent;

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
            //if (SetDefaultProxy == true)
            //{
            //    service.WebProxy = WebProxy.GetDefaultProxy();  // Obsolete
            //}


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

        //public static ExchangeServiceBinding CreateExchangeServiceBinding()
        //{
        //    var binding = new ExchangeServiceBinding();
        //    binding.AllowAutoRedirect = false;

        //    binding.UserAgent = GlobalSettings.UserAgent;

        //    // Set the RequestServerVersionValue
        //    binding.RequestServerVersionValue = new EwsVsProxy.RequestServerVersion();
        //    switch (RequestedExchangeVersion)
        //    {
        //        case ExchangeVersion.Exchange2007_SP1:
        //            binding.RequestServerVersionValue.Version = ExchangeVersionType.Exchange2007_SP1;
        //            break;
        //        case ExchangeVersion.Exchange2010:
        //            binding.RequestServerVersionValue.Version = ExchangeVersionType.Exchange2010;
        //            break;
        //        case ExchangeVersion.Exchange2010_SP1:
        //            binding.RequestServerVersionValue.Version = ExchangeVersionType.Exchange2010_SP1;
        //            break;
        //        case ExchangeVersion.Exchange2010_SP2:
        //            binding.RequestServerVersionValue.Version = ExchangeVersionType.Exchange2010_SP2;
        //            break;
        //        case ExchangeVersion.Exchange2013:
        //            binding.RequestServerVersionValue.Version = ExchangeVersionType.Exchange2013;
        //            break;
        //        default:
        //            DebugLog.WriteVerbose("Requested ExchangeVersion was '" + RequestedExchangeVersion.Value.ToString() + "' which is not expected");
        //            throw new ApplicationException("Unexpected ExchangeVersion");
        //    }

        //    if (EwsUrl != null)
        //    {
        //        binding.Url = EwsUrl.AbsoluteUri;
        //    }

        //    if (ServiceCredential != null)
        //    {
        //        binding.Credentials = ServiceCredential;
        //    }

        //    if (UseDefaultCredentials.HasValue)
        //    {
        //        binding.UseDefaultCredentials = UseDefaultCredentials.Value;
        //    }

        //    if (Timeout.HasValue)
        //    {
        //        binding.Timeout = Timeout.Value;
        //    }

        //    // Create the ExchangeImpersonationType if needed
        //    if (UserToImpersonate != null)
        //    {
        //        binding.ExchangeImpersonation = new ExchangeImpersonationType();
        //        binding.ExchangeImpersonation.ConnectingSID = new ConnectingSIDType();
        //        binding.ExchangeImpersonation.ConnectingSID.Item = UserToImpersonate.Id;
        //        switch (UserToImpersonate.IdType)
        //        {
        //            case ConnectingIdType.PrincipalName:
        //                binding.ExchangeImpersonation.ConnectingSID.ItemElementName = ItemChoiceType.PrincipalName;
        //                break;
        //            case ConnectingIdType.SID:
        //                binding.ExchangeImpersonation.ConnectingSID.ItemElementName = ItemChoiceType.SID;
        //                break;
        //            case ConnectingIdType.SmtpAddress:
        //                binding.ExchangeImpersonation.ConnectingSID.ItemElementName = ItemChoiceType.SmtpAddress;
        //                break;
        //        }

        //        // Set headers which help with affinity when Impersonation is being used against Exchange 2013 and Exchagne Online 15.
        //        // http://blogs.msdn.com/b/mstehle/archive/2013/07/17/more-affinity-considerations-for-exchange-online-and-exchange-2013.aspx
        //        if (binding.RequestServerVersionValue.Version.ToString().StartsWith("Exchange2007") == false &&
        //            binding.RequestServerVersionValue.Version.ToString().StartsWith("Exchange2010") == false)
        //        {
        //            //// Should set for 365:
        //            //if (binding.ContainsKey("X-AnchorMailbox") == false)
        //            //    binding.HttpHeaders.Add("X-AnchorMailbox", binding.ImpersonatedUserId.Id);
        //            //else
        //            //    binding.HttpHeaders["X-AnchorMailbox"] = binding.ImpersonatedUserId.Id;
        //        }
        //    }

        //    return binding;
        //}

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
