﻿// oAuthHelper.cs //

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
using System.Linq.Expressions;
//using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Net.NetworkInformation;

// For reference:
//      https://learn.microsoft.com/en-us/azure/active-directory/develop/msal-client-application-configuration
//      https://learn.microsoft.com/en-us/java/api/com.microsoft.identity.client.azurecloudinstance?view=azure-java-stable
//      https://learn.microsoft.com/en-us/dotnet/api/microsoft.identity.client.abstractapplicationbuilder-1.withauthority?f1url=%3FappId%3DDev16IDEF1%26l%3DEN-US%26k%3Dk(Microsoft.Identity.Client.AbstractApplicationBuilder%25601.WithAuthority)%3Bk(TargetFrameworkMoniker-.NETFramework%2CVersion%253Dv4.8)%3Bk(DevLang-csharp)%26rd%3Dtrue&view=msal-dotnet-latest
//      https://azuread.github.io/microsoft-authentication-library-for-objc/Enums/MSALAzureCloudInstance.html
//      https://learn.microsoft.com/en-us/azure/active-directory/develop/authentication-national-cloud

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


        ///------------------------------------------------------------------------------------------------------
        /// <summary>
        ///  
        /// </summary>
        /// <param name="ClientId"></param>
        /// <param name="TenantId"></param>
        /// <param name="OAuth2RedirectUrl"></param>
        /// <param name="OAuth2Authority"></param>
        /// <param name="OAuth2ValidateAuthority"></param>
        /// <returns></returns>
        public async Task<AuthenticationResult> GetDelegateToken(
                string ClientId, 
                string TenantId, 
                string OAuth2RedirectUrl, 
                string OAuth2Authority, 
                bool OAuth2ValidateAuthority,
                string OAuth2Scope
                )
        {
            _Success = false;

            //var ewsScopes = new string[] { "https://outlook.office365.com/EWS.AccessAsUser.All" };
            string[] ewsScopes = { OAuth2Scope };

            // Using Microsoft.Identity.Client 4.22.0
            PublicClientApplicationOptions pcaOptions = null;

            //Initialize the cloudInstance enum.
            var OAuth2AzCloudInstance = AzureCloudInstance.None;

            //Switch to set logon authority enum.
            switch (OAuth2Authority)
            {
                case "https://login.microsoftonline.us":
                    OAuth2AzCloudInstance = AzureCloudInstance.AzureUsGovernment;
                    break;

                case "https://login.microsoftonline.de":
                    OAuth2AzCloudInstance = AzureCloudInstance.AzureGermany;
                    break;

                case "https://login.partner.microsoftonline.cn":
                    OAuth2AzCloudInstance = AzureCloudInstance.AzureChina;
                    break;
                default:
                    OAuth2AzCloudInstance = AzureCloudInstance.AzurePublic;
                    break;
            }


            if (OAuth2RedirectUrl != "<Do not use a redirect URL.>")
            {
                // Configure the MSAL client to get tokens
                pcaOptions = new PublicClientApplicationOptions
                {
                    ClientId = ClientId,
                    TenantId = TenantId,
                    RedirectUri = OAuth2RedirectUrl,
                    AzureCloudInstance = OAuth2AzCloudInstance

                }; 

            }
            else
            {
                // Configure the MSAL client to get tokens
                pcaOptions = new PublicClientApplicationOptions
                {
                    ClientId = ClientId,
                    TenantId = TenantId
                };

            }


            var pca = PublicClientApplicationBuilder
                .CreateWithApplicationOptions(pcaOptions).Build();

            // The permission scope required for EWS access
             

            AuthenticationResult oResult = null;

 
            try
            {
                oResult = await pca.AcquireTokenInteractive(ewsScopes)
                    .WithAuthority(OAuth2Authority, TenantId, OAuth2ValidateAuthority)
                    .ExecuteAsync();
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


        // ------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ClientId"></param>
        /// <param name="TenantId"></param>
        /// <param name="ClientSecret"></param>
        /// <param name="OAuth2RedirectUrl"></param>
        /// <param name="OAuth2Authority"></param>
        /// <param name="OAuth2ValidateAuthority"></param>
        /// <param name="OAuth2Scope"></param>
        /// <returns></returns>
        public async Task<AuthenticationResult> GetApplicationToken(
                string ClientId, 
                string TenantId, 
                string ClientSecret, 
                string OAuth2RedirectUrl,
                string OAuth2Authority,
                bool OAuth2ValidateAuthority,
                string OAuth2Scope )
        {

            // Configure the MSAL client to get tokens
            //var ewsScopes = new string[] { "https://outlook.office.com/.default" };
            string[] ewsScopes = { OAuth2Scope };
         
            IConfidentialClientApplication app = null;

            try
            {


                if (OAuth2RedirectUrl != "<Do not use a redirect URL.>")
                {
                    app = ConfidentialClientApplicationBuilder.Create(ClientId)
                      //.WithAuthority(AzureCloudInstance.AzurePublic, TenantId)
                      .WithAuthority(OAuth2Authority, TenantId, OAuth2ValidateAuthority)
                      .WithClientSecret(ClientSecret)
                      .WithRedirectUri(OAuth2RedirectUrl)
                      .Build();
                }
                else
                {
                    app = ConfidentialClientApplicationBuilder.Create(ClientId)
                      //.WithAuthority(AzureCloudInstance.AzurePublic, TenantId)
                      .WithAuthority(OAuth2Authority, TenantId, OAuth2ValidateAuthority)
                      .WithClientSecret(ClientSecret)
                      .Build();
                }
            }
            catch (Exception ex)
            {
                _Success = false;
                _lastException = ex;
                string sError = string.Empty;
                sError += string.Format("Error: {0}\r\n", ex.ToString());
                sError += ex.ToString();

                ErrorDialog.ShowError(sError);

            }

            // Microsoft.Identity.Client.AuthenticationResult
            AuthenticationResult oResult = null;
            try
            {
                // Make the token request (should not be interactive, unless Consent required)
                oResult = await app.AcquireTokenForClient(ewsScopes)
                    //.WithAuthority(AzureCloudInstance.AzurePublic, "{tenantID}")  // do not use "common" or "organizations"!
                    // See: https://github.com/AzureAD/microsoft-authentication-library-for-dotnet/wiki/Client-credential-flows
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
                sError += string.Format("Error: {0}\r\n", ex.ToString());
                sError += ex.ToString();
                sError += "\r\n\r\nAlso see: https://docs.microsoft.com/en-us/exchange/client-developer/exchange-web-services/how-to-authenticate-an-ews-application-by-using-oauth";
                ErrorDialog.ShowError(sError);
            }

            GetAuthenticationResultInformation(oResult);

            return oResult;

        }

        // ----------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ClientId"></param>
        /// <param name="TenantId"></param>
        /// <param name="ClientCertificate"></param>
        /// <param name="OAuth2RedirectUrl"></param>
        /// <param name="OAuth2Authority"></param>
        /// <param name="OAuth2ValidateAuthority"></param>
        /// <param name="OAuth2Scope"></param>
        /// <returns></returns>
        public async Task<AuthenticationResult> GetCertificateToken(
                string ClientId, 
                string TenantId, 
                X509Certificate2 ClientCertificate, 
                string OAuth2RedirectUrl,
                string OAuth2Authority,
                bool OAuth2ValidateAuthority,
                string OAuth2Scope)
        {
            // Configure the MSAL client to get tokens
            //var ewsScopes = new string[] { "https://outlook.office.com/.default" };
            string[] ewsScopes = { OAuth2Scope };
     

            IConfidentialClientApplication app = null;


            if (OAuth2RedirectUrl != "<Do not use a redirect URL.>")
            {
                app = ConfidentialClientApplicationBuilder.Create(ClientId)
                //.WithAuthority(AzureCloudInstance.AzurePublic, TenantId)
                    .WithAuthority(OAuth2Authority, TenantId, OAuth2ValidateAuthority)
                    .WithCertificate(ClientCertificate)
                    .WithRedirectUri(OAuth2RedirectUrl)
                    .Build();
                }
            else
            {
                app = ConfidentialClientApplicationBuilder.Create(ClientId)
                    .WithAuthority(OAuth2Authority, TenantId, OAuth2ValidateAuthority)
                    .WithCertificate(ClientCertificate)
                    .Build();
            }

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
        public async Task<AuthenticationResult> GetRefreshToken(PublicClientApplication oPCA)
        {

            // https://docs.microsoft.com/en-us/azure/active-directory/develop/msal-error-handling-dotnet#msaluirequiredexception
 
            // https://github.com/AzureAD/microsoft-authentication-library-for-dotnet/wiki/AcquireTokenSilentAsync-using-a-cached-token
 

            var accounts = await oPCA.GetAccountsAsync();

            // The permission scope required for EWS access
            var ewsScopes = new string[] { "https://outlook.office365.com/EWS.AccessAsUser.All" };

            AuthenticationResult oResult = null;

            try
            {
                oResult = await oPCA.AcquireTokenSilent(ewsScopes, accounts.FirstOrDefault())
                        .ExecuteAsync();
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

            if (oResult != null)
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
                sb.AppendLine(string.Format("TenantId: {0}", oResult.TenantId));
                sb.AppendLine(string.Format("UniqueId: {0}", oResult.UniqueId));

                sInfo = sb.ToString();

                return sInfo;
            }
            else
            {
                return "AuthenticationResult is Null.";
            }
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
