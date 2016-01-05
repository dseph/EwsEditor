using System;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using EWSEditor.Logging;
using EWSEditor.Settings;
using Microsoft.Exchange.WebServices.Data;
using System.Runtime.CompilerServices;

namespace EWSEditor.Common.Extensions
{
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

            string s = string.Empty;
            
            //s = service.GetNetworkCredential().UserName;
 
           
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
                    return string.Empty;

                    // HACK: Don't know what happened if we got here...
                   // throw new ApplicationException("Unexpected ExchangeService.Credentials type");
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
        /// Attempt a simple request to ConvertIds to see if this service configuration finds an Exchange
        /// server that can handle the requested schema.
        /// </summary>
        /// <param name="service">The ExchangeService configuration to test.</param>
        public static void TestExchangeService(this ExchangeService service)
        {
            // mstehle - 11/15/2011 - The validation override is now handled by GlobalSettings, no need
            // to do all this stuff anymore.  Just try ConvertIds and let the exceptions bubble up.
            service.ConvertIds(
                new AlternateId[] { new AlternateId(IdFormat.HexEntryId, "00", "blah@blah.com") },
                IdFormat.HexEntryId);
        }
    }
}
