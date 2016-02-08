using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.Common
{

    public class EwsEditorAppSettings
    {


        public string MailboxBeingAccessed = string.Empty;  // calc

        public RequestedAuthType AuthenticationMethod = RequestedAuthType.DefaultAuth;  // Default, UserSpecified, oAuth

        public bool UseAutoDiscover = false;  
        public string RequestedAutodiscoverEmail = string.Empty;
        public string RequestedExchangeServiceURL = string.Empty;

        public ExchangeVersion? RequestedExchangeVersion = null;
 
        public string UserName = string.Empty;
        public string Password = string.Empty;
        public string Domain = string.Empty;

        public bool UserImpersonationSelected = false;
        public ImpersonatedUserId UserToImpersonate = null;
        public string ImpersonationType = string.Empty;
        public string ImpersonatedId = string.Empty;

        public bool? UseoAuth = null;
        public string oAuthRedirectUrl = string.Empty;
        public string oAuthClientId = string.Empty;
        public string oAuthServerName = string.Empty;
        public string oAuthAuthority = string.Empty;

        public bool EnableAdditionalHeader1 = false;
        public string AdditionalHeader1 = string.Empty;
        public string AdditionalHeaderValue1 = string.Empty;
        public bool EnableAdditionalHeader2 = false;
        public string AdditionalHeader2 = string.Empty;
        public string AdditionalHeaderValue2 = string.Empty;
        public bool EnableAdditionalHeader3 = false;
        public string  AdditionalHeader3 = string.Empty;
        public string AdditionalHeaderValue3 = string.Empty;
 
    }

    public enum RequestedAuthType
    {
        DefaultAuth,
        SpecifiedCredentialsAuth,
        oAuth
    }
     
   
}
