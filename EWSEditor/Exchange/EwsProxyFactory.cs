using System;
using System.Net;
using EWSEditor.Common;
using EWSEditor.EwsVsProxy;
using EWSEditor.Logging;
using EWSEditor.Settings;
using EWSEditor.Common.Extensions;
using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.Exchange
{
    public class EwsProxyFactory
    {
        public ExchangeVersion? RequestedExchangeVersion = null;
        public bool? AllowAutodiscoverRedirect = null;
        public bool? EnableScpLookup;
        public NetworkCredential ServiceCredential = null;
        public Microsoft.Exchange.WebServices.Data.EmailAddress ServiceEmailAddress = null;
        public Uri EwsUrl;
        public int? Timeout = null;
        public bool? UseDefaultCredentials = null;
        public ImpersonatedUserId UserToImpersonate = null;

        public EwsProxyFactory()
        {

        }

        public void DoAutodiscover()
        {
            DoAutodiscover(this.ServiceEmailAddress);
        }

        public void DoAutodiscover(Microsoft.Exchange.WebServices.Data.EmailAddress emailAddress)
        {
            ExchangeService service = this.CreateExchangeService();
            service.AutodiscoverUrl(emailAddress.Address, ValidationCallbackHelper.RedirectionUrlValidationCallback );

            this.EwsUrl = service.Url;
        }

        public ExchangeService CreateExchangeService()
        {
            ExchangeService service = null;

            if (this.RequestedExchangeVersion.HasValue)
            {
                service = new ExchangeService(this.RequestedExchangeVersion.Value);
            }
            else
            {
                service = new ExchangeService();
            }

            service.UserAgent = GlobalSettings.UserAgent;

            service.TraceEnabled = true;
            service.TraceListener = new EWSEditor.Logging.EwsTraceListener();

            if (this.EnableScpLookup.HasValue)
            {
                service.EnableScpLookup = this.EnableScpLookup.Value;
            }

            if (this.ServiceCredential != null)
            {
                service.Credentials = this.ServiceCredential;
            }

            if (this.EwsUrl != null)
            {
                service.Url = this.EwsUrl;
            }

            if (this.Timeout.HasValue)
            {
                service.Timeout = this.Timeout.Value;
            }

            if (this.UseDefaultCredentials.HasValue)
            {
                service.UseDefaultCredentials = this.UseDefaultCredentials.Value;
            }

            if (this.UserToImpersonate != null)
            {
                service.ImpersonatedUserId = this.UserToImpersonate;
            }

            return service;
        }

        public ExchangeServiceBinding CreateExchangeServiceBinding()
        {
            var binding = new ExchangeServiceBinding();
            binding.AllowAutoRedirect = false;

            binding.UserAgent = GlobalSettings.UserAgent;

            // Set the RequestServerVersionValue
            binding.RequestServerVersionValue = new EwsVsProxy.RequestServerVersion();
            switch (this.RequestedExchangeVersion)
            {
                case ExchangeVersion.Exchange2007_SP1:
                    binding.RequestServerVersionValue.Version = ExchangeVersionType.Exchange2007_SP1;
                    break;
                case ExchangeVersion.Exchange2010:
                    binding.RequestServerVersionValue.Version = ExchangeVersionType.Exchange2010;
                    break;
                case ExchangeVersion.Exchange2010_SP1:
                    binding.RequestServerVersionValue.Version = ExchangeVersionType.Exchange2010_SP1;
                    break;
                default:
                    DebugLog.WriteVerbose("Requested ExchangeVersion was '" + this.RequestedExchangeVersion.Value.ToString() + "' which is not expected");
                    throw new ApplicationException("Unexpected ExchangeVersion");
            }

            if (this.EwsUrl != null)
            {
                binding.Url = this.EwsUrl.AbsoluteUri;
            }

            if (this.ServiceCredential != null)
            {
                binding.Credentials = this.ServiceCredential;
            }

            if (this.UseDefaultCredentials.HasValue)
            {
                binding.UseDefaultCredentials = this.UseDefaultCredentials.Value;
            }

            if (this.Timeout.HasValue)
            {
                binding.Timeout = this.Timeout.Value;
            }

            // Create the ExchangeImpersonationType if needed
            if (this.UserToImpersonate != null)
            {
                binding.ExchangeImpersonation = new ExchangeImpersonationType();
                binding.ExchangeImpersonation.ConnectingSID = new ConnectingSIDType();
                binding.ExchangeImpersonation.ConnectingSID.Item = this.UserToImpersonate.Id;
                switch (this.UserToImpersonate.IdType)
                {
                    case ConnectingIdType.PrincipalName:
                        binding.ExchangeImpersonation.ConnectingSID.ItemElementName = ItemChoiceType.PrincipalName;
                        break;
                    case ConnectingIdType.SID:
                        binding.ExchangeImpersonation.ConnectingSID.ItemElementName = ItemChoiceType.SID;
                        break;
                    case ConnectingIdType.SmtpAddress:
                        binding.ExchangeImpersonation.ConnectingSID.ItemElementName = ItemChoiceType.SmtpAddress;
                        break;
                }
            }

            return binding;
        }

        public static EwsProxyFactory InitializeWithDefaults()
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
        private static EwsProxyFactory InitializeWithDefaults(ExchangeVersion? version, Uri ewsUrl, string autodiscoverAddress)
        {
            EwsProxyFactory factory = new EwsProxyFactory();

            factory.RequestedExchangeVersion = version;
            factory.UseDefaultCredentials = true;

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

                factory.DoAutodiscover(autodiscoverAddress);
            }
            else
            {
                factory.EwsUrl = ewsUrl;
            }

            try
            {
                factory.CreateExchangeService().TestExchangeService();
            }
            catch (ServiceVersionException ex)
            {
                DebugLog.WriteVerbose("Initial requested version of Exchange2010 didn't work, trying Exchange 2007_SP1", ex);
                // Pass the autodiscover email address and URL if we've already looked those up
                factory = InitializeWithDefaults(ExchangeVersion.Exchange2007_SP1, factory.EwsUrl, autodiscoverAddress);
            }

            return factory;
        }
    }
}
