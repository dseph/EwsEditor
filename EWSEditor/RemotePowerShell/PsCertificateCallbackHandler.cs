using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWSEditor.RemotePowerShell
{
    public class PsCertificateCallbackHandler
    {

        public string _Certificates = string.Empty;


        public bool PsCertificateValidationCallBack(
                 object sender,
                 System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                 System.Security.Cryptography.X509Certificates.X509Chain chain,
                 System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            string sCerts = string.Empty;


            // If the certificate is a valid, signed certificate, return true.
            if (sslPolicyErrors == System.Net.Security.SslPolicyErrors.None)
            {
                sCerts += "[Valid Cert - No Errors]----------------------------\r\n\r\n";
                sCerts += "Issuer:               " + certificate.Issuer + "\r\n";
                sCerts += "Subject:              " + certificate.Subject + "\r\n";
                sCerts += "EffectiveDateString:  " + certificate.GetEffectiveDateString() + "\r\n";
                sCerts += "ExpirationDate:       " + certificate.GetExpirationDateString() + "\r\n";
                sCerts += "Format:               " + certificate.GetFormat() + "\r\n";
                sCerts += "SerialNumber:         " + certificate.GetSerialNumberString() + "\r\n";
                sCerts += "RawCertData:          " + certificate.GetRawCertDataString() + "\r\n";
                sCerts += "PublicKey:            " + certificate.GetPublicKeyString() + "\r\n";
                sCerts += "\r\n---------------------------------\r\n\r\n";
                _Certificates += sCerts;
                return true;
            }

            // If thre are errors in the certificate chain, look at each error to determine the cause.
            if ((sslPolicyErrors & System.Net.Security.SslPolicyErrors.RemoteCertificateChainErrors) != 0)
            {
                sCerts += "[Remote Certificate Chain Errors Found]----------------------------\r\n\r\n";
                if (chain != null && chain.ChainStatus != null)
                {
                    foreach (System.Security.Cryptography.X509Certificates.X509ChainStatus status in chain.ChainStatus)
                    {
                        if ((certificate.Subject == certificate.Issuer) &&
                           (status.Status == System.Security.Cryptography.X509Certificates.X509ChainStatusFlags.UntrustedRoot))
                        {

                            sCerts += "    [Self-signed certificates with an untrusted root - Considering as valid]----------------------------\r\n\r\n";
                            sCerts += "    Status Information:   " + status.StatusInformation + "\r\n\r\n";

                            sCerts += "    Issuer:               " + certificate.Issuer + "\r\n";
                            sCerts += "    Subject:              " + certificate.Subject + "\r\n";
                            sCerts += "    EffectiveDateString:  " + certificate.GetEffectiveDateString() + "\r\n";
                            sCerts += "    ExpirationDate:       " + certificate.GetExpirationDateString() + "\r\n";
                            sCerts += "    Format:               " + certificate.GetFormat() + "\r\n";
                            sCerts += "    SerialNumber:         " + certificate.GetSerialNumberString() + "\r\n";
                            sCerts += "    RawCertData:          " + certificate.GetRawCertDataString() + "\r\n";
                            sCerts += "    PublicKey:            " + certificate.GetPublicKeyString() + "\r\n";
                            sCerts += "\r\n    ---------------------------------\r\n\r\n";
                            _Certificates += sCerts;
                            // Self-signed certificates with an untrusted root are valid. 
                            continue;
                        }
                        else
                        {
                            if (status.Status != System.Security.Cryptography.X509Certificates.X509ChainStatusFlags.NoError)
                            {
                                sCerts += "    [Certificate Errors - Considering as invlid]----------------------------\r\n";

                                sCerts += "    Status Information:   " + status.StatusInformation + "\r\n\r\n";

                                sCerts += "    Issuer:               " + certificate.Issuer + "\r\n";
                                sCerts += "    Subject:              " + certificate.Subject + "\r\n";
                                sCerts += "    EffectiveDateString:  " + certificate.GetEffectiveDateString() + "\r\n";
                                sCerts += "    ExpirationDate:       " + certificate.GetExpirationDateString() + "\r\n";
                                sCerts += "    Format:               " + certificate.GetFormat() + "\r\n";
                                sCerts += "    SerialNumber:         " + certificate.GetSerialNumberString() + "\r\n";
                                sCerts += "    RawCertData:          " + certificate.GetRawCertDataString() + "\r\n";
                                sCerts += "    PublicKey:            " + certificate.GetPublicKeyString() + "\r\n";
                                sCerts += "\r\n    ---------------------------------\r\n\r\n";
                                _Certificates += sCerts;
                                // If there are any other errors in the certificate chain, the certificate is invalid,
                                // so the method returns false.
                                return false;
                            }
                        }
                    }
                }

                // When processing reaches this line, the only errors in the certificate chain are 
                // untrusted root errors for self-signed certifcates. These certificates are valid
                // for default Exchange server installations, so return true.
                return true;
            }
            else
            {
                // In all other cases, return false.
                return false;
            }
        }
    }
}
