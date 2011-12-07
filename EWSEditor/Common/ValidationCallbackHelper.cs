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

            if (GlobalSettings.EnableSslDetailLogging)
            {
                DebugLog.WriteInfo(builder.ToString());
            }

            return GlobalSettings.OverrideCertValidation;
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
