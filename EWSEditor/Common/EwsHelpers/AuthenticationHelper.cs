using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EWSEditor.Common.Extensions;
using Microsoft.Exchange.WebServices.Data;
using EWSEditor.Forms;
using System.Xml;
using System.Net;
using Microsoft.Exchange.WebServices.Autodiscover;
using System.Configuration;
using Microsoft.IdentityModel.Clients.ActiveDirectory;  // Needed for oAuth

namespace EWSEditor.Common
{
    public class AuthenticationHelper
    {

        //public  bool Do_OAuth(ref ExchangeService oService, ref string MailboxBeingAccessed, ref string AccountAccessingMailbox,
        //    string sAuthority, string sAppId, string sRedirectURL, string sServername)
        //{
        //    bool bRet = false;


        //    // See // https://msdn.microsoft.com/en-us/library/office/dn903761(v=exchg.150).aspx
        //    // get authentication token
        //    string authority = sAuthority;
        //    string clientID = sAppId;
        //    Uri clientAppUri = new Uri(sRedirectURL);
        //    string serverName = sServername;

        //    AuthenticationContext authenticationContext = new AuthenticationContext(authority, false);
        //    PlatformParameters oPlatformParameters = new PlatformParameters(PromptBehavior.Always);
        //    AuthenticationResult authenticationResult =   authenticationContext.AcquireTokenAsync(serverName, clientID, clientAppUri, oPlatformParameters).Result; 

        //      //System.Diagnostics.Debug.WriteLine(authenticationResult.UserInfo.DisplayableId);
        //      MailboxBeingAccessed = authenticationResult.UserInfo.DisplayableId;
        //    AccountAccessingMailbox = authenticationResult.UserInfo.DisplayableId;  // oAuth at this time does not support delegate or impersonation access - may need to change this in the future.

        //    // Add authenticaiton token to requests
        //    oService.Credentials = new OAuthCredentials(authenticationResult.AccessToken);

        //    bRet = true;
        //    return bRet;

        //}

        public ExchangeCredentials Do_OAuth(ref string MailboxBeingAccessed, ref string AccountAccessingMailbox,
            string sAuthority, string sAppId, string sRedirectURL, string sServername, ref string sBearerToken, PromptBehavior oPromptBehavior)
        {

            ExchangeCredentials oExchangeCredentials = null;

            // See // https://msdn.microsoft.com/en-us/library/office/dn903761(v=exchg.150).aspx
            // get authentication token
            string authority = sAuthority;
            string clientID = sAppId;
            Uri clientAppUri = new Uri(sRedirectURL);
            string serverName = sServername;
           
            AuthenticationContext authenticationContext = new AuthenticationContext(authority, false);
            PlatformParameters oPlatformParameters = new PlatformParameters(oPromptBehavior);
            AuthenticationResult authenticationResult = authenticationContext.AcquireTokenAsync(serverName, clientID, clientAppUri, oPlatformParameters).Result;

            sBearerToken = authenticationResult.AccessToken;

            // Add authenticaiton token to requests
            oExchangeCredentials = new OAuthCredentials(authenticationResult.AccessToken);

            MailboxBeingAccessed = authenticationResult.UserInfo.DisplayableId;
            AccountAccessingMailbox = authenticationResult.UserInfo.DisplayableId;  // oAuth at this time does not support delegate or impersonation access - may need to change this in the future.

            return oExchangeCredentials;

        }

        public ExchangeCredentials Do_OAuth( ref string MailboxBeingAccessed, ref string AccountAccessingMailbox,
            string sAuthority, string sAppId, string sRedirectURL, string sServername, ref string sBearerToken)
        {

            return Do_OAuth(ref MailboxBeingAccessed, ref AccountAccessingMailbox,
             sAuthority, sAppId, sRedirectURL, sServername, ref sBearerToken, PromptBehavior.Always);

            //ExchangeCredentials oExchangeCredentials = null;

            //// See // https://msdn.microsoft.com/en-us/library/office/dn903761(v=exchg.150).aspx
            //// get authentication token
            //string authority = sAuthority;
            //string clientID = sAppId;
            //Uri clientAppUri = new Uri(sRedirectURL);
            //string serverName = sServername;

            //AuthenticationContext authenticationContext = new AuthenticationContext(authority, false);
            //PlatformParameters oPlatformParameters = new PlatformParameters(PromptBehavior.Always);
            //AuthenticationResult authenticationResult = authenticationContext.AcquireTokenAsync (serverName, clientID, clientAppUri, oPlatformParameters).Result;

            //sBearerToken = authenticationResult.AccessToken;

            //// Add authenticaiton token to requests
            //oExchangeCredentials = new OAuthCredentials(authenticationResult.AccessToken);

            //MailboxBeingAccessed = authenticationResult.UserInfo.DisplayableId;
            //AccountAccessingMailbox = authenticationResult.UserInfo.DisplayableId;  // oAuth at this time does not support delegate or impersonation access - may need to change this in the future.

           // return oExchangeCredentials;

        }

    }
}
