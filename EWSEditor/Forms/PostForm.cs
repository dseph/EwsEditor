using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EWSEditor.Common;
using System.Net;
using System.Web;

namespace EWSEditor.Common
{
    public partial class PostForm : Form
    {
        public PostForm()
        {
            InitializeComponent();
        }

        private CredentialCache GetCredentials(bool UseDefault, string User, string Password, string Domain, string Url)
        {
            NetworkCredential oNetworkCredential = null;
            CredentialCache oCredentialCache = null;
            
             
 
            oCredentialCache = new CredentialCache();
             
            Uri oUri = new Uri(Url);

            if (UseDefault == false) 
            {
                if (txtDomain.Text.Trim().Length == 0)
                {
                    oNetworkCredential = new NetworkCredential(User, Password);
                }
                else
                {
                    oNetworkCredential = new NetworkCredential(User, Password, Domain);

                }

                oCredentialCache.Add(oUri, "Basic", oNetworkCredential);
                //oCredentialCache.Add(oUri, "NTLM", oNetworkCredential);
            }
 
            return  oCredentialCache;
        }

        private void GoRun_Click(object sender, EventArgs e)
        {
            string  sResult = string.Empty;
            string  sError = string.Empty;
            string  sResponseStatusCodeNumber = string.Empty;
            string sResponseStatusCode = string.Empty;
            int  iResponseStatusCodeNumber = 0;
            string sResponseStatusDescription = string.Empty; 

            CredentialCache oCredentialCache = new CredentialCache();
            oCredentialCache = GetCredentials(
                                    chkDefaultWindowsCredentials.Checked, 
                                    txtUser.Text.Trim(),
                                    txtPassword.Text.Trim(), 
                                    txtDomain.Text.Trim(), 
                                    txtUrl.Text.Trim());


            EWSEditor.Common.HttpHelper.RawHtppCall(
                cmboVerb.Text,
                txtUrl.Text.Trim(),
                cmboContentType.Text,
                oCredentialCache,
                txtRequest.Text,
                90,
                true,
                false,
                true,
                ref sResult,
                ref sError,
                ref sResponseStatusCode,
                ref iResponseStatusCodeNumber,
                ref sResponseStatusDescription
                );
                


 
            //public static bool RawPost(
            //    string sUrl,
            //    string sContentType,
            //    NetworkCredential oNetworkCredential,
            //    string sRequestBody,

            //    int iTimeoutSeconds,
            //    bool bPragmaNoCache,
            //    bool bTranslateF,
            //    bool bAllowAutoRedirect,
 
            //    ref string sResult,
            //    ref string sError,
            //    ref string sResponseStatusCode,
            //    ref int iResponseStatusCodeNumber,
            //    ref string sResponseStatusDescription 
       
            //)
        }

        private void PostForm_Load(object sender, EventArgs e)
        {

        }
    }
}
