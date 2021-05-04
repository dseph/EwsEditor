// Note: much of the code was taken from David Barrett's EWSTreamingNotificationSample GitHub sample

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Security.Cryptography.X509Certificates;
 using EWS = Microsoft.Exchange.WebServices.Data;
using Autodiscover = Microsoft.Exchange.WebServices.Autodiscover;
using Microsoft.Identity.Client;
using System.Windows.Forms;


namespace EWSEditor.Common.Auth
 
{
    //public enum AuthType
    //{
    //    None,
    //    Default,
    //    Basic,
    //    Certificate,
    //    OAuth
    //}

    //public class CredentialHandler
    //{
    //    String _password = String.Empty;
    //    X509Certificate2 _certificate = null;
    //    AuthType _authType = AuthType.Basic;
    //    private AuthenticationResult _lastOAuthResult = null;
    //    private OAuthHelper _oAuthHelper = new OAuthHelper();
    //    private ClassLogger _logger = null;

    //    public CredentialHandler(AuthType authType, ClassLogger Logger = null)
    //    {
    //        _authType = authType;
    //        _logger = Logger;
    //    }

    //    public string Username { get; set; } = String.Empty;

    //    public string Domain { get; set; } = String.Empty;

    //    public string TenantId { get; set; } = String.Empty;

    //    public string ApplicationId { get; set; } = String.Empty;

    //    public string ClientSecret { get; set; } = String.Empty;

    //    public string Password
    //    {
    //        set { _password = value; }
    //    }

    //    public string OAuthToken
    //    {
    //        get
    //        {
    //            if (_lastOAuthResult == null)
    //                return null;
    //            return _lastOAuthResult.AccessToken;
    //        }
    //    }

    //    public bool OAuthTokenExpired()
    //    {
    //        if (_lastOAuthResult != null && _lastOAuthResult.ExpiresOn > DateTime.Now)
    //            return false;
    //        return true;
    //    }

    //    public X509Certificate2 Certificate
    //    {
    //        get { return _certificate; }
    //        set { _certificate = value; }
    //    }


    //    public void GetAppTokenWithSecret()
    //    {
    //        try
    //        {
    //            _lastOAuthResult = Task.Run(async () => await OAuthHelper.GetApplicationToken(ApplicationId, TenantId, ClientSecret)).Result;
    //            _logger?.Log($"Token obtained, expires {_lastOAuthResult.ExpiresOn}");
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show(ex.Message, "Unable to acquire token", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //        }
    //    }

    //    public void GetAppTokenWithCertificate()
    //    {
    //        try
    //        {
    //            _lastOAuthResult = Task.Run(async () => await OAuthHelper.GetApplicationToken(ApplicationId, TenantId, Certificate)).Result;
    //            _logger?.Log($"Token obtained, expires {_lastOAuthResult.ExpiresOn}");
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show(ex.Message, "Unable to acquire token", MessageBoxButtons.OK, MessageBoxIcon.Error);
    //        }
    //    }

    //    public void AcquireToken()
    //    {
    //        _logger?.Log("Requesting new access token");
    //        if (_certificate != null)
    //            GetAppTokenWithCertificate();
    //        else
    //            GetAppTokenWithSecret();
    //    }

    //    private bool HaveValidCredentials()
    //    {
    //        switch (_authType)
    //        {
    //            case AuthType.Default:
    //                return true;

    //            case AuthType.Basic:
    //                if (!String.IsNullOrEmpty(Username)) return true;
    //                return false;

    //            case AuthType.Certificate:
    //                return (_certificate != null);

    //            case AuthType.OAuth:
    //                // Check if we already have valid access token
    //                if (_lastOAuthResult != null && _lastOAuthResult.ExpiresOn > DateTime.Now) return true;

    //                // We don't have an access token, so check the application configuration
    //                if (String.IsNullOrEmpty(ApplicationId)) return false;
    //                if (String.IsNullOrEmpty(TenantId)) return false;
    //                if ((_certificate == null) && String.IsNullOrEmpty(ClientSecret)) return false;

    //                // Obtain a token
    //                AcquireToken();
    //                if (_lastOAuthResult != null && _lastOAuthResult.ExpiresOn > DateTime.Now) return true;
    //                return false;

    //            default: return false;
    //        }
    //    }

    //    public void LogCredentials(ClassLogger Logger)
    //    {
    //        StringBuilder sCredentialInfo = new StringBuilder();
    //        switch (_authType)
    //        {
    //            case AuthType.Default:
    //                sCredentialInfo.AppendLine("Using default credentials");
    //                sCredentialInfo.Append("Username: ");
    //                sCredentialInfo.AppendLine(Environment.UserName);
    //                sCredentialInfo.Append("Domain: ");
    //                sCredentialInfo.AppendLine(Environment.UserDomainName);
    //                break;

    //            case AuthType.Basic:
    //                sCredentialInfo.AppendLine("Using specific credentials");
    //                sCredentialInfo.Append("Username: ");
    //                sCredentialInfo.AppendLine(Username);
    //                sCredentialInfo.Append("Domain: ");
    //                sCredentialInfo.AppendLine(Domain);
    //                break;

    //            case AuthType.Certificate:
    //                sCredentialInfo.AppendLine("Using certificate");
    //                if (_certificate != null)
    //                {
    //                    sCredentialInfo.Append("Subject: ");
    //                    sCredentialInfo.AppendLine(_certificate.Subject);
    //                }
    //                else
    //                    sCredentialInfo.AppendLine("NO CERTIFICATE SPECIFIED");
    //                break;

    //            case AuthType.OAuth:
    //                sCredentialInfo.AppendLine("Using OAuth");
    //                if (_lastOAuthResult != null)
    //                    sCredentialInfo.AppendLine($"Current access token expiry: {_lastOAuthResult.ExpiresOn}");
    //                break;

    //        }

    //        Logger.Log(sCredentialInfo.ToString(), "Request Credentials");
    //    }

    //    public bool ApplyCredentialsToHttpWebRequest(HttpWebRequest Request)
    //    {
    //        if (!HaveValidCredentials())
    //            return false;

    //        switch (_authType)
    //        {
    //            case AuthType.Default:
    //                Request.UseDefaultCredentials = true;
    //                return true;

    //            case AuthType.Basic:
    //                Request.Credentials = new NetworkCredential(Username, _password);
    //                return true;

    //            case AuthType.Certificate:
    //                Request.ClientCertificates = new X509CertificateCollection();
    //                Request.ClientCertificates.Add(_certificate);
    //                return true;

    //            case AuthType.OAuth:
    //                Request.Headers["Authorization"] = $"Bearer {_lastOAuthResult.AccessToken}";
    //                return true;
    //        }

    //        return false;
    //    }

    //    public bool ApplyCredentialsToExchangeService(EWS.ExchangeService Exchange)
    //    {
    //        if (!HaveValidCredentials())
    //            return false;

    //        switch (_authType)
    //        {
    //            case AuthType.Default:
    //                Exchange.UseDefaultCredentials = true;
    //                return true;

    //            case AuthType.Basic:
    //                Exchange.Credentials = new NetworkCredential(Username, _password);
    //                return true;

    //            case AuthType.Certificate:
    //                //Request.ClientCertificates = new X509CertificateCollection();
    //                //Request.ClientCertificates.Add(_certificate);
    //                return false;

    //            case AuthType.OAuth:
    //                Exchange.Credentials = new EWS.OAuthCredentials(_lastOAuthResult.AccessToken);
    //                return true;
    //        }

    //        return false;
    //    }

    //    public bool ApplyCredentialsToAutodiscoverService(Autodiscover.AutodiscoverService Autodiscover)
    //    {
    //        if (!HaveValidCredentials())
    //            return false;

    //        switch (_authType)
    //        {
    //            case AuthType.Default:
    //                Autodiscover.UseDefaultCredentials = true;
    //                return true;

    //            case AuthType.Basic:
    //                Autodiscover.Credentials = new NetworkCredential(Username, _password);
    //                return true;

    //            case AuthType.Certificate:
    //                //Request.ClientCertificates = new X509CertificateCollection();
    //                //Request.ClientCertificates.Add(_certificate);
    //                return false;

    //            case AuthType.OAuth:
    //                Autodiscover.Credentials = new EWS.OAuthCredentials(_lastOAuthResult.AccessToken);
    //                return true;
    //        }

    //        return false;
    //    }
    //}
}
