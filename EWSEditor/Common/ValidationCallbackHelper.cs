using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using EWSEditor.Logging;
using EWSEditor.Settings;

namespace EWSEditor.Common
{
    public class ValidationCallbackHelper
    {
        public static bool CertificateValidationCallBack(
                 object sender,
                 System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                 System.Security.Cryptography.X509Certificates.X509Chain chain,
                 System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("SslPolicyErrors: " + sslPolicyErrors.ToString());
            builder.AppendLine("-----------------------------------------------");
            builder.AppendLine("X509Certificate");
            builder.AppendLine("-----------------------------------------------");
            builder.AppendLine(certificate.ToString(true));
            builder.AppendLine();

            builder.AppendLine("-----------------------------------------------");
            builder.AppendLine("X509Chain");
            builder.AppendLine("ChainContext: " + chain.ChainContext.ToString());
            //builder.AppendLine("ChainPolicy: " + chain.ChainPolicy.);
            builder.AppendLine("ChainStatus: ");
            foreach (X509ChainStatus status in chain.ChainStatus)
            {
                builder.AppendLine("\tChainStatus.Status:" + System.Enum.GetName(typeof(X509ChainStatus), status.Status));
                builder.AppendLine("\tChainStatus.StatusInformation:" + status.StatusInformation);
            }
            builder.AppendLine("-----------------------------------------------");

            foreach (X509ChainElement element in chain.ChainElements)
            {
                builder.AppendLine("-----------------------------------------------");
                builder.AppendLine("X509ChainElement");
                builder.AppendLine("ChainElementStatus:");
                foreach (X509ChainStatus status in element.ChainElementStatus)
                {
                    builder.AppendLine("\tChainElementStatus.Status:" + System.Enum.GetName(typeof(X509ChainStatus), status.Status));
                    builder.AppendLine("\tChainElementStatus.StatusInformation:" + status.StatusInformation);
                }
                builder.AppendLine("Information:" + element.Information);
                builder.AppendLine("-----------------------------------------------");
                builder.AppendLine(element.Certificate.ToString(true));
                builder.AppendLine();
            }

            // Only write detailed certificate information if requested
            if (GlobalSettings.EnableSslDetailLogging)
            {
                DebugLog.WriteInfo(builder.ToString());
            }

            // If we're overriding validation then always return true
            if (GlobalSettings.OverrideCertValidation)
            {
                return true;
            }

            // If there were errors output error code and return false
            if (sslPolicyErrors != System.Net.Security.SslPolicyErrors.None)
            {
                DebugLog.WriteInfo("SSL certificate validation failed because System.Net.Security.SslPolicyErrors = '{0}'",
                    System.Enum.GetName(typeof(System.Net.Security.SslPolicyErrors), sslPolicyErrors));

                return false;
            }

            return true;
        }

        public static bool RedirectionUrlValidationCallback(string redirectionUrl)
        {
            // Validate the contents of the redirection URL. In this simple validation
            // callback, the redirection URL is considered valid if it is using HTTPS
            // to encrypt the authentication credentials. 
            Uri redirectionUri = new Uri(redirectionUrl);
            if (redirectionUri.Scheme != "https")
            {
                DebugLog.WriteInfo("Cannot allow potentially unsafe redirection to non-SSL URL: " + redirectionUrl);
                return false;
            }

            DebugLog.WriteInfo((GlobalSettings.AllowAutodiscoverRedirect ? "Allow redirection to: " : "Blocked redirection to: ") + redirectionUrl);

            return GlobalSettings.AllowAutodiscoverRedirect;
        }
    }
}
