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
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace EWSEditor.Common
{
    public class AuthenticationHelper
    {

        public  bool Do_OAuth(ref ExchangeService oService, ref string MailboxBeingAccessed, ref string AccountAccessingMailbox,
            string sAuthority, string sAppId, string sRedirectURL, string sServername)
        {
            bool bRet = false;


            // See // https://msdn.microsoft.com/en-us/library/office/dn903761%28v=exchg.150%29.aspx?f=255&MSPPError=-2147217396#bk_getToken
            // get authentication token
            string authority = sAuthority;
            string clientID = sAppId;
            Uri clientAppUri = new Uri(sRedirectURL);
            string serverName = sServername;

            AuthenticationContext authenticationContext = new AuthenticationContext(authority, false);

            AuthenticationResult authenticationResult = authenticationContext.AcquireToken(serverName, clientID, clientAppUri, PromptBehavior.Always);

            //System.Diagnostics.Debug.WriteLine(authenticationResult.UserInfo.DisplayableId);
            MailboxBeingAccessed = authenticationResult.UserInfo.DisplayableId;
            AccountAccessingMailbox = authenticationResult.UserInfo.DisplayableId;  // oAuth at this time does not support delegate or impersonation access - may need to change this in the future.

            // Add authenticaiton token to requests
            oService.Credentials = new OAuthCredentials(authenticationResult.AccessToken);

            bRet = true;
            return bRet;

        }

        public ExchangeCredentials Do_OAuth( ref string MailboxBeingAccessed, ref string AccountAccessingMailbox,
            string sAuthority, string sAppId, string sRedirectURL, string sServername)
        {
             
            ExchangeCredentials oExchangeCredentials = null;

            // See // https://msdn.microsoft.com/en-us/library/office/dn903761%28v=exchg.150%29.aspx?f=255&MSPPError=-2147217396#bk_getToken
            // get authentication token
            string authority = sAuthority;
            string clientID = sAppId;
            Uri clientAppUri = new Uri(sRedirectURL);
            string serverName = sServername;

            AuthenticationContext authenticationContext = new AuthenticationContext(authority, false);

            AuthenticationResult authenticationResult = authenticationContext.AcquireToken(serverName, clientID, clientAppUri, PromptBehavior.Always);

            // Add authenticaiton token to requests
            oExchangeCredentials = new OAuthCredentials(authenticationResult.AccessToken);

            MailboxBeingAccessed = authenticationResult.UserInfo.DisplayableId;
            AccountAccessingMailbox = authenticationResult.UserInfo.DisplayableId;  // oAuth at this time does not support delegate or impersonation access - may need to change this in the future.
 
            return oExchangeCredentials;

        }

    }
}
