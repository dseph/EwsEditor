using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
//using Microsoft.Identity.Client;
//using Microsoft.IdentityModel.Clients.ActiveDirectory;

using EWSEditor.Common;
//using EWSEditor.EwsVsProxy;
using EWSEditor.Logging;
using EWSEditor.Settings;
using EWSEditor.Common.Extensions;
using Microsoft.Exchange.WebServices.Data;
using EWSEditor.Forms;
using EWSEditor.Resources;
using EWSEditor.Exchange;

 
using Microsoft.Identity.Client;


namespace EWSEditor.Common.Auth
{
    public class OAuthHelper
    {
        private bool _Success = false;
        private Exception _lastException = null;
        private string _BearerToken = string.Empty;
        private PublicClientApplication _CurrentPublicClientApplication = null;

        public bool Success
        {
            get { return _Success; }
        }

        public Exception LastException
        {
            get { return _lastException; }
        }

        public string BearerToken
        {            
            get { return _BearerToken; }

        }

        public PublicClientApplication CurrentPublicClientApplication
        {
            get { return _CurrentPublicClientApplication; }
        }

         


        public async Task<AuthenticationResult> GetDelegateToken(string ClientId,  string TenantId)
        {
            _Success = false;

            // Using Microsoft.Identity.Client 4.22.0

            // Configure the MSAL client to get tokens
            var pcaOptions = new PublicClientApplicationOptions
            {
                ClientId = ClientId,
                TenantId = TenantId
            };

            var pca = PublicClientApplicationBuilder
                .CreateWithApplicationOptions(pcaOptions).Build();
            
            // The permission scope required for EWS access
            var ewsScopes = new string[] { "https://outlook.office365.com/EWS.AccessAsUser.All" };

            AuthenticationResult oResult = null;

            try
            {
                oResult = await pca.AcquireTokenInteractive(ewsScopes).ExecuteAsync();
                _CurrentPublicClientApplication = (PublicClientApplication)pca;
                _Success = true;
                return oResult;
            }
            catch (Exception ex)
            {
                _Success = false;
                _lastException = ex;

            }
 
            GetAuthenticationResultInformation(oResult);

            return null;

        }

        public async Task<AuthenticationResult> GetApplicationToken(string ClientId, string TenantId, string ClientSecret)
        {

            // Configure the MSAL client to get tokens
            var ewsScopes = new string[] { "https://outlook.office.com/.default" };

            var app = ConfidentialClientApplicationBuilder.Create(ClientId)
                .WithAuthority(AzureCloudInstance.AzurePublic, TenantId)
                .WithClientSecret(ClientSecret)
                .Build();
            // Microsoft.Identity.Client.AuthenticationResult
            AuthenticationResult oResult = null;
            try
            {
                // Make the token request (should not be interactive, unless Consent required)
                oResult = await app.AcquireTokenForClient(ewsScopes)
                    .ExecuteAsync();

                //oResult.Account.ToString();
                //oResult.Account;

                _Success = true;
                _lastException = null;
            }
            catch (Exception ex)
            {
                _Success = false;
                _lastException = ex;
                string sError = string.Empty;
                sError += string.Format("Error: {0}\r\n", ex.HResult);
                sError += ex.ToString();
                sError += "\r\n\r\nAlso see: https://docs.microsoft.com/en-us/exchange/client-developer/exchange-web-services/how-to-authenticate-an-ews-application-by-using-oauth";
                ErrorDialog.ShowError(sError);
            }


             


            GetAuthenticationResultInformation(oResult);



            return oResult;

        }

        public async Task<AuthenticationResult> GetCertificateToken(string ClientId, string TenantId, X509Certificate2 ClientCertificate)
        {
            // Configure the MSAL client to get tokens
            var ewsScopes = new string[] { "https://outlook.office.com/.default" };

            var app = ConfidentialClientApplicationBuilder.Create(ClientId)
                .WithAuthority(AzureCloudInstance.AzurePublic, TenantId)
                .WithCertificate(ClientCertificate)
                .Build();

            AuthenticationResult oResult = null;
            try
            {
                // Make the token request (should not be interactive, unless Consent required)
                oResult = await app.AcquireTokenForClient(ewsScopes)
                    .ExecuteAsync();

                _Success = true;
                _lastException = null;


            }
            catch (Exception ex)
            {
                _Success = false;
                _lastException = ex;
            }

            

            GetAuthenticationResultInformation(oResult);

            return oResult;
        }

        //public async Task<AuthenticationResult> GetRefreshToken(string sClientId, string sTenantId, Microsoft.Identity.Client.AuthenticationResult oAR, PublicClientApplication oPCA)
        public async Task<AuthenticationResult> GetRefreshToken( PublicClientApplication oPCA)
        {

            // https://docs.microsoft.com/en-us/azure/active-directory/develop/msal-error-handling-dotnet#msaluirequiredexception


            //var pcaOptions = new PublicClientApplicationOptions
            //{
            //    ClientId = sClientId,
            //    TenantId = sTenantId
            //};



            //var pca = PublicClientApplicationBuilder
            //    .CreateWithApplicationOptions(pcaOptions).Build();

            // https://github.com/AzureAD/microsoft-authentication-library-for-dotnet/wiki/AcquireTokenSilentAsync-using-a-cached-token

            //var accounts = await pca.GetAccountsAsync();
            //var firstAccount = accounts.FirstOrDefault();

       

            var accounts = await oPCA.GetAccountsAsync();
 
            // The permission scope required for EWS access
            var ewsScopes = new string[] { "https://outlook.office365.com/EWS.AccessAsUser.All" };

            AuthenticationResult oResult = null;
             
            try
            {
                oResult = await oPCA.AcquireTokenSilent(ewsScopes, accounts.FirstOrDefault())
                        .ExecuteAsync()  ;
                //oResult = await pca.AcquireTokenSilent(ewsScopes, accounts.FirstOrDefault()).ExecuteAsync();
                _CurrentPublicClientApplication = (PublicClientApplication)oPCA;
                //GetAuthenticationResultInformation(oResult);
                //oResult = await pca.AcquireTokenSilent(ewsScopes, accounts.FirstOrDefault()).ExecuteAsync();
                _Success = true;
                _lastException = null;
            }
            catch (Exception ex)
            {
                _Success = false;
                _lastException = ex;
            }

            GetAuthenticationResultInformation(oResult);

            return oResult;
        }

        public string GetAuthenticationResultInformation(AuthenticationResult oResult)
        {
            string sInfo = string.Empty;

            StringBuilder sb = new StringBuilder();

 
            sb.AppendLine(string.Format("AccessToken: {0}", oResult.AccessToken));
            if (oResult.Account != null)
            { 
                sb.AppendLine(string.Format("Account: {0}", oResult.Account.ToString()));
                sb.AppendLine(string.Format("    Username: {0}", oResult.Account.Username));
                sb.AppendLine(string.Format("    Environment: {0}", oResult.Account.Environment.ToString()));
                sb.AppendLine(string.Format("    HomeAccountId: {0}", oResult.Account.HomeAccountId.ToString()));
                sb.AppendLine(string.Format("    Account: {0}", oResult.Account));
            }
            sb.AppendLine(string.Format("AuthenticationResultMetadata: {0}", oResult.AuthenticationResultMetadata.ToString()));
            sb.AppendLine(string.Format("CorrelationId: {0}", oResult.CorrelationId.ToString()));
            sb.AppendLine(string.Format("ExpiresOn: {0}", oResult.ExpiresOn.ToString()));
            sb.AppendLine(string.Format("ExtendedExpiresOn: {0}", oResult.ExtendedExpiresOn.ToString()));
            sb.AppendLine(string.Format("IdToken: {0}", oResult.IdToken));
            sb.AppendLine(string.Format("IsExtendedLifeTimeToken: {0}", oResult.IsExtendedLifeTimeToken.ToString()));
            sb.AppendLine(string.Format("Scopes:  "));
            foreach (string s in oResult.Scopes)
            {
                sb.AppendLine(string.Format("    {0}", s));
            }
            sb.AppendLine(string.Format("TenantId: {0}", oResult.TenantId ));
            sb.AppendLine(string.Format("UniqueId: {0}", oResult.UniqueId ));

            sInfo = sb.ToString();

            return sInfo;

        }

    }
    
}

        //public class OAuthHelper
        //{
        //    private static Exception _lastError = null;

        //    public static Exception LastError
        //    {
        //        get { return _lastError; }
        //    }

        //    public static async Task<AuthenticationResult> GetDelegateToken(string ClientId, string TenantId, string Scope = "EWS.AccessAsUser.All")
        //    {
        //        var pcaOptions = new PublicClientApplicationOptions
        //        {
        //            ClientId = ClientId,
        //            TenantId = TenantId
        //        };

        //        var pca = PublicClientApplicationBuilder
        //            .CreateWithApplicationOptions(pcaOptions);

        //        if (ClientId.Equals("4a03b746-45be-488c-bfe5-0ffdac557d68"))
        //            pca = pca.WithRedirectUri("http://localhost/SOAPe");

        //        var app = pca.Build();

        //        var ewsScopes = new string[] { $"https://outlook.office.com/{Scope}" };

        //        try
        //        {
        //            // Make the interactive token request
        //            AuthenticationResult authResult = await app.AcquireTokenInteractive(ewsScopes).ExecuteAsync();
        //            return authResult;
        //        }
        //        catch (Exception ex)
        //        {
        //            _lastError = ex;
        //        }
        //        return null;
        //    }

        //    public static async Task<AuthenticationResult> GetApplicationToken(string ClientId, string TenantId, string ClientSecret)
        //    {
        //        // Configure the MSAL client to get tokens
        //        var ewsScopes = new string[] { "https://outlook.office.com/.default" };

        //        var app = ConfidentialClientApplicationBuilder.Create(ClientId)
        //            .WithAuthority(AzureCloudInstance.AzurePublic, TenantId)
        //            .WithClientSecret(ClientSecret)
        //            .Build();

        //        AuthenticationResult result = null;
        //        try
        //        {
        //            // Make the token request (should not be interactive, unless Consent required)
        //            result = await app.AcquireTokenForClient(ewsScopes)
        //                .ExecuteAsync();
        //        }
        //        catch (Exception ex)
        //        {
        //            _lastError = ex;
        //        }
        //        return result;
        //    }

        //    public static async Task<AuthenticationResult> GetApplicationToken(string ClientId, string TenantId, X509Certificate2 ClientCertificate)
        //    {
        //        // Configure the MSAL client to get tokens
        //        var ewsScopes = new string[] { "https://outlook.office.com/.default" };

        //        var app = ConfidentialClientApplicationBuilder.Create(ClientId)
        //            .WithAuthority(AzureCloudInstance.AzurePublic, TenantId)
        //            .WithCertificate(ClientCertificate)
        //            .Build();

        //        AuthenticationResult result = null;
        //        try
        //        {
        //            // Make the token request (should not be interactive, unless Consent required)
        //            result = await app.AcquireTokenForClient(ewsScopes)
        //                .ExecuteAsync();
        //        }
        //        catch (Exception ex)
        //        {
        //            _lastError = ex;
        //        }
        //        return result;
        //    }
        //}
   // }
