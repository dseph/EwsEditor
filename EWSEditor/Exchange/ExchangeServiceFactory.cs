using System;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.Exchange
{
    public class ExchangeServiceFactory
    {
        public ExchangeVersion? ExchangeVersion = null;
        public bool? AllowAutodiscoverRedirect = null;
        public bool? EnableScpLookup;
        public NetworkCredential ServiceCredential = null;
        public EmailAddress ServiceEmailAddress = null;
        public Uri ServiceUri;
        public int? Timeout = null;
        public bool? TraceEnabled = null;
        public ITraceListener TraceListner = null;
        public bool? UseDefaultCredentials = null;
        public string UserAgent;

        public ExchangeServiceFactory()
        {

        }

        public void DoAutodiscover()
        {
            DoAutodiscover(this.ServiceEmailAddress);
        }

        public void DoAutodiscover(EmailAddress emailAddress)
        {
            ExchangeService service = this.CreateService();

            service.AutodiscoverUrl(emailAddress.Address, AllowRedirect);

            this.ServiceUri = service.Url;
        }

        public ExchangeService CreateService()
        {
            ExchangeService service = null;

            if (this.ExchangeVersion.HasValue)
            {
                service = new ExchangeService(this.ExchangeVersion.Value);
            }
            else
            {
                service = new ExchangeService();
            }

            if (this.EnableScpLookup.HasValue)
            {
                service.EnableScpLookup = this.EnableScpLookup.Value;
            }

            if (this.ServiceCredential != null)
            {
                service.Credentials = this.ServiceCredential;
            }

            if (this.TraceEnabled.HasValue)
            {
                service.TraceEnabled = this.TraceEnabled.Value;
            }

            if (this.TraceListner != null)
            {
                service.TraceListener = this.TraceListner;
            }

            if (this.ServiceUri != null)
            {
                service.Url = this.ServiceUri;
            }

            if (this.Timeout.HasValue)
            {
                service.Timeout = this.Timeout.Value;
            }

            if (this.UseDefaultCredentials.HasValue)
            {
                service.UseDefaultCredentials = this.UseDefaultCredentials.Value;
            }

            service.UserAgent = this.UserAgent;

            CertificateValidationHelper.SimpleCertValidationOverride();

            return service;
        }

        public ExchangeService CreateService(ConnectingIdType type, string impersonate)
        {
            ExchangeService service = CreateService();

            service.ImpersonatedUserId = new ImpersonatedUserId(
                ConnectingIdType.SmtpAddress,
                impersonate);

            return service;
        }

        private bool AllowRedirect(string url)
        {
            if (this.AllowAutodiscoverRedirect.HasValue)
            {
                return this.AllowAutodiscoverRedirect.Value;
            }
            else
            {
                return false;
            }
        }
    }
}
