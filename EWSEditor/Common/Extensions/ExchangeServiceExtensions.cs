namespace EWSEditor.Common.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Security;
    using System.Security.Cryptography.X509Certificates;
    using System.Security.Principal;
    using System.Text;

    using Microsoft.Exchange.WebServices.Data;

    using EWSEditor.Diagnostics;

    public static class ExchangeServiceExtensions
    {
        /// <summary>
        /// Determine if this ExchangeService instance is the same as the
        /// given ExchangeService instance.
        /// </summary>
        /// <param name="service">"this" instance of ExchangeService</param>
        /// <param name="service2">ExchangeService to compare to</param>
        /// <returns>True if the connection properties of the given 
        /// ExchangeService are the same, False if not.</returns>
        public static bool IsEqual(this ExchangeService service, ExchangeService service2)
        {
            if (service.Url != service2.Url)
            {
                return false;
            }

            // If RequestedServerVersion is specified they should be the same
            if (service.RequestedServerVersion != service2.RequestedServerVersion)
            {
                return false;
            }

            // If both services have specified credentials they should be the same
            if (service.Credentials != null && service2.Credentials != null)
            {
                NetworkCredential cred1 = service.GetNetworkCredential();
                NetworkCredential cred2 = service2.GetNetworkCredential();

                if ((cred1.UserName != cred2.UserName) ||
                    (cred1.Password != cred2.Password) ||
                    (cred1.Domain != cred2.Domain))
                {
                    return false;
                }
            }
            else
            {
                // If one doesn't have credentials setup then neither should
                if (!(service.Credentials == null && service2.Credentials == null))
                {
                    return false;
                }
            }

            // If both services have impersonation setup, verify the values are the same
            if (service.ImpersonatedUserId != null && service2.ImpersonatedUserId != null)
            {
                if (service.ImpersonatedUserId.Id != service2.ImpersonatedUserId.Id)
                {
                    return false;
                }

                if (service.ImpersonatedUserId.IdType != service2.ImpersonatedUserId.IdType)
                {
                    return false;
                }
            }
            else
            {
                // If one doesn't have impersonation setup, then the should both not
                // have it setup.
                if (!(service.ImpersonatedUserId == null && service2.ImpersonatedUserId == null))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Get a NetworkCredential object from the ExchangeService 
        /// object.  In some cases this may not be a straight forward conversion.
        /// </summary>
        /// <returns>NetworkCredential retrieved</returns>
        public static NetworkCredential GetNetworkCredential(this ExchangeService service)
        {
            if (service.Credentials == null)
            {
                return null;
            }

            WebCredentials webCreds = (WebCredentials)service.Credentials;

            if (!(webCreds.Credentials is NetworkCredential))
            {
                throw new ApplicationException("Unexpected Credential type in ExchangeService.Credentials.");
            }

            return (NetworkCredential)webCreds.Credentials;
        }

        /// <summary>
        /// Get the user name of the service account specified in the
        /// ExchangeService.
        /// </summary>
        /// <returns>User name of the service account used to submit 
        /// request via this ExchangeService object</returns>
        public static string GetServiceAccountName(this ExchangeService service)
        {
            if (service == null)
            {
                return string.Empty;
            }

            // If the service is using default credentials then the service account is
            // the thread identity, otherwise it is the account specified in ExchangeService.Credentials
            if (service.UseDefaultCredentials)
            {
                return System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split(new char[] { '\\' })[1];
            }
            else
            {
                if (service.Credentials is WebCredentials)
                {
                    return service.GetNetworkCredential().UserName;
                }
                else
                {
                    // HACK: Don't know what happened if we got here...
                    throw new ApplicationException("Unexpected ExchangeService.Credentials type");
                }
            }
        }

        /// <summary>
        /// Determine the account that this ExchangeService will act as on objects when
        /// contacting Exchange.
        /// </summary>
        /// <returns>User name of the account used to act on Exchange objects</returns>
        public static string GetActAsAccountName(this ExchangeService service)
        {
            if (service == null)
            {
                return string.Empty;
            }

            // If the service is configured to use Exchange Impersonation, return the
            // user name.  If not, return the service account.
            if (service.ImpersonatedUserId != null)
            {
                return service.ImpersonatedUserId.Id;
            }
            else
            {
                return service.GetServiceAccountName();
            }
        }

        /// <summary>
        /// Attempt a simple request to ConvertIds to see if this service configuration finds Exchange.
        /// Exchange test servers often have invalid certificates initially, this code will trap that
        /// error and bypass the certificate validation so requests will go through anyway.
        /// </summary>
        /// <param name="service">The ExchangeService configuration to test.</param>
        /// <param name="fixBadCert">Indicates whether or not to fix a bad SSL cert issue.</param>
        public static void TestExchangeService(this ExchangeService service, bool fixBadCert)
        {
            try
            {
                service.ConvertIds(
                    new AlternateId[] { new AlternateId(IdFormat.HexEntryId, "00", "blah@blah.com") },
                    IdFormat.HexEntryId);
            }
            catch (ServiceRequestException ex)
            {
                if (ex.Message == "Request failed. The underlying connection was closed: Could not establish trust relationship for the SSL/TLS secure channel."
                    && fixBadCert)
                {
                    // Hook up the cert callback.
                    System.Net.ServicePointManager.ServerCertificateValidationCallback =
                        delegate(Object obj, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
                        {
                            // Validate the certificate and return true or false as appropriate.
                            // Note that it not a good practice to always return true because not
                            // all certificates should be trusted.

                            return true;
                        };

                    TraceHelper.WriteVerbose("Certification verification failed but further verification was overridden.");
                    TraceHelper.WriteVerbose(ex);
                }
                else
                {
                    throw;
                }
            }
        }

        public static void TestExchangeService(this ExchangeService service)
        {
            service.ConvertIds(
                new AlternateId[] { new AlternateId(IdFormat.HexEntryId, "00", "blah@blah.com") },
                IdFormat.HexEntryId);
        }

        /// <summary>
        /// Create an ExchangeService with all default values
        /// </summary>
        public static ExchangeService GetExchangeService()
        {
            return InitializeWithDefaults(null, null, null);
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
        private static ExchangeService InitializeWithDefaults(ExchangeVersion? version, Uri ewsUrl, string autodiscoverAddress)
        {
            ExchangeService service = null;

            if (version.HasValue)
            {
                service = new ExchangeService(version.Value);
            }
            else
            {
                service = new ExchangeService();
            }

            // Setup request/response tracer
            service.TraceEnabled = true;
            service.TraceListener = new EWSEditorTraceListener();

            // Use default credentials
            service.UseDefaultCredentials = true;

            // If the EWS URL is not specified, use Autodiscover to find it
            if (ewsUrl == null)
            {
                // If no email address was given to use with Autodiscover, attempt
                // to look it up in Active Directory
                if (String.IsNullOrEmpty(autodiscoverAddress))
                {
                    autodiscoverAddress = ActiveDirectoryHelper.GetPrimarySmtp(
                        WindowsIdentity.GetCurrent().Name);
                }

                if (ConfigHelper.AllowAutodiscoverRedirect)
                {
                    service.AutodiscoverUrl(autodiscoverAddress,
                        delegate(string url) { return true; });
                }
                else
                {
                    service.AutodiscoverUrl(autodiscoverAddress);
                }
            }
            else
            {
                service.Url = ewsUrl;
            }

            try
            {
                service.TestExchangeService(ConfigHelper.OverrideCertValidation);
            }
            catch (ServiceVersionException ex)
            {
                // If requesting Exchange 2010 by default didn't work, try Exchange 2007 SP1.
                if (service.ServerInfo.MajorVersion == 8)
                {
                    // Pass the autodiscover email address and URL if we've already looked
                    // those up
                    service = InitializeWithDefaults(ExchangeVersion.Exchange2007_SP1, service.Url, autodiscoverAddress);
                }

                TraceHelper.WriteVerbose("Initial requested version of Exchange2010 didn't work, trying Exchange 2007_SP1");
                TraceHelper.WriteVerbose(ex);
            }

            return service;
        }
    }
}
