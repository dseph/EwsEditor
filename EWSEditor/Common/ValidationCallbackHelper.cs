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
            // If we're overriding validation then always return true
            if (GlobalSettings.OverrideCertValidation)
            {
                return true;
            }

            // If there were errors output error code and return false
            if (sslPolicyErrors != System.Net.Security.SslPolicyErrors.None)
            {
                DebugLog.WriteInfo("SSL certificate validation failed", "System.Net.Security.SslPolicyErrors = '{0}'",
                    System.Enum.GetName(typeof(System.Net.Security.SslPolicyErrors), sslPolicyErrors));

                return false;
            }

            // Only write detailed certificate information if requested
            if (GlobalSettings.EnableSslDetailLogging)
            {
                DumpCertificationDetail(certificate, chain);
            }

            return true;
        }

        public static void DumpCertificationDetail(
            System.Security.Cryptography.X509Certificates.X509Certificate certificate, 
            System.Security.Cryptography.X509Certificates.X509Chain chain)
        {
            StringBuilder certificateDetail = new StringBuilder();
            certificateDetail.AppendLine("-----------------------------------------------");
            certificateDetail.AppendLine("X509Certificate");
            certificateDetail.AppendLine("-----------------------------------------------");
            certificateDetail.AppendLine(certificate.ToString(true));
            certificateDetail.AppendLine();

            certificateDetail.AppendLine("-----------------------------------------------");
            certificateDetail.AppendLine("X509Chain");
            certificateDetail.AppendLine("ChainContext: " + chain.ChainContext.ToString());
            //builder.AppendLine("ChainPolicy: " + chain.ChainPolicy.);
            certificateDetail.AppendLine("ChainStatus: ");
            foreach (X509ChainStatus status in chain.ChainStatus)
            {
                certificateDetail.AppendLine("\tChainStatus.Status:" + status.Status.ToString());
                certificateDetail.AppendLine("\tChainStatus.StatusInformation:" + status.StatusInformation);
            }
            certificateDetail.AppendLine("-----------------------------------------------");

            foreach (X509ChainElement element in chain.ChainElements)
            {
                certificateDetail.AppendLine("-----------------------------------------------");
                certificateDetail.AppendLine("X509ChainElement");
                certificateDetail.AppendLine("ChainElementStatus:");
                foreach (X509ChainStatus status in element.ChainElementStatus)
                {
                    certificateDetail.AppendLine("\tChainElementStatus.Status:" + status.Status.ToString());
                    certificateDetail.AppendLine("\tChainElementStatus.StatusInformation:" + status.StatusInformation);
                }
                certificateDetail.AppendLine("Information:" + element.Information);
                certificateDetail.AppendLine("-----------------------------------------------");
                certificateDetail.AppendLine(element.Certificate.ToString(true));
                certificateDetail.AppendLine();
            }

            DebugLog.WriteInfo("SSL Certificate detail", certificateDetail.ToString());
        }

        public static bool RedirectionUrlValidationCallback(string redirectionUrl)
        {
            // Validate the contents of the redirection URL. In this simple validation
            // callback, the redirection URL is considered valid if it is using HTTPS
            // to encrypt the authentication credentials. 
            Uri redirectionUri = new Uri(redirectionUrl);

            if (redirectionUri.Scheme != "https")
            {
                DebugLog.WriteInfo("Unsafe URL redirection blocked", "Cannot allow potentially unsafe redirection to non-SSL URL: " + redirectionUrl);
                return false;
            }

            DebugLog.WriteInfo((GlobalSettings.AllowAutodiscoverRedirect ? "Allow URL redirection" : "Blocked URL redirection to"), "URL: " + redirectionUrl);
            return GlobalSettings.AllowAutodiscoverRedirect;
        }
    }
}
