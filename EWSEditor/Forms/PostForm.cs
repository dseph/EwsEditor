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

 
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Xml;

namespace EWSEditor.Common
{
    public partial class PostForm : Form
    {
        public PostForm()
        {
            InitializeComponent();
        }

        private CredentialCache GetCredentials(string sAuthentication, string User, string Password, string Domain, string Url)
        {
            NetworkCredential oNetworkCredential = null; 
            CredentialCache oCredentialCache = null;
 
            oCredentialCache = new CredentialCache();
           
            Uri oUri = new Uri(Url);

            if (sAuthentication != "DEFAULT")
            {
                if (txtDomain.Text.Trim().Length == 0)
                {
                    oNetworkCredential = new NetworkCredential(User, Password);
                }
                else
                {
                    oNetworkCredential = new NetworkCredential(User, Password, Domain);

                }

                oCredentialCache.Add(oUri, sAuthentication, oNetworkCredential);
                //oCredentialCache.Add(oUri, "Basic", oNetworkCredential);
                //oCredentialCache.Add(oUri, "NTLM", oNetworkCredential);
                //oCredentialCache.Add(oUri, "Digest", oNetworkCredential);
            }
            else
            {
                 
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

            this.Cursor = Cursors.WaitCursor;


            // http://msdn.microsoft.com/en-us/library/office/bb409286(v=exchg.150).aspx

            //bool bPragmaNoCache = true;
            //bool bTranslateF = false;
            //bool bAllowAutoRedirect = false; 

            CredentialCache oCredentialCache = new CredentialCache();
 
                oCredentialCache = GetCredentials(
                                        cmboAuthentication.Text,
                                        txtUser.Text.Trim(),
                                        txtPassword.Text.Trim(),
                                        txtDomain.Text.Trim(),
                                        txtUrl.Text.Trim());
 
            bool bRet = false;

            bRet = EWSEditor.Common.HttpHelper.RawHtppCall(
                cmboVerb.Text,
                txtUrl.Text.Trim(),
                cmboContentType.Text,
                cmboAuthentication.Text,
                oCredentialCache,
                txtRequest.Text,
                //txtProxyServer.Text,
                //txtProxyPort.Text,
                (int)numericUpDownTimeoutSeconds.Value,
                chkPragmaNocache.Checked,
                chkTranslateF.Checked,
                chkAllowRedirect.Checked,
                txtUserAgent.Text,
                ref sResult,
                ref sError,
                ref sResponseStatusCode,
                ref iResponseStatusCodeNumber,
                ref sResponseStatusDescription
                );
            
            StringBuilder oSB = new StringBuilder();

            sResult = SerialHelper.RestoreCrLfAndIndents(sResult);
             
            if (bRet == true)
            {  
                oSB.AppendFormat("{0}\r\n\r\n", sResult); 
            }
            else
            { 
            oSB.AppendFormat("Failed:\r\n"); 
            oSB.AppendFormat("Error: {0}\r\n\r\n", sError);
            oSB.AppendFormat("ResponseStatusCode: {0}\r\n\r\n", sResponseStatusCode);
            oSB.AppendFormat("ResponseCodeNumber{0}\r\n\r\n", iResponseStatusCodeNumber);
            oSB.AppendFormat("ResponseStatusDescription: {0}\r\n\r\n", sResponseStatusDescription);
            oSB.AppendFormat("sResult: {0}\r\n", sResult);
            }
            txtResponse.Text = oSB.ToString();

            this.Cursor = Cursors.Default;
        }

        private void PostForm_Load(object sender, EventArgs e)
        {
            SetFields();
        }

        private void btnLoadSettings_Click(object sender, EventArgs e)
        {
            string sFile = string.Empty;
            string sConnectionSettings = string.Empty;
            PostFormSetting oPostFormSetting = null;
            string sFileContents = string.Empty;

            if (UserIoHelper.PickLoadFromFile(Application.UserAppDataPath, "*.xml", ref sFile, "XML files (*.xml)|*.xml"))
            {
                try
                {
                    sFileContents = System.IO.File.ReadAllText(sFile);
                    oPostFormSetting = SerialHelper.DeserializeObjectFromString<PostFormSetting>(sFileContents);
                    if (oPostFormSetting == null)
                        throw new Exception("Settings file cannot be deserialized.");
                    SetFormFromSettings(oPostFormSetting);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString(), "Error Loading File");
                }

                SetFields(); 

            }
             
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            string sFile = string.Empty;
            string sConnectionSettings = string.Empty;
            PostFormSetting oPostFormSetting = new PostFormSetting();

            SetSettingsFromForm(ref oPostFormSetting);

            if (UserIoHelper.PickSaveFileToFolder(Application.UserAppDataPath, "Connection Settings " + TimeHelper.NowMashup() + ".xml", ref sFile, "XML files (*.xml)|*.xml"))
            {

                //http://msdn.microsoft.com/en-us/library/system.xml.xmlwritersettings.newlinehandling(v=vs.110).aspx
                sConnectionSettings = SerialHelper.SerializeObjectToString<PostFormSetting>(oPostFormSetting);
                if (sConnectionSettings != string.Empty)
                {
                    try
                    {
                        System.IO.File.WriteAllText(sFile, sConnectionSettings);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error Saving File");
                    }
                }
            }
        }

        private void btnLoadExample_Click(object sender, EventArgs e)
        {
            string sInitialDirectory = Application.StartupPath + "\\EwsPostExamples";

            string sSuggestedFilename = "*.xml";
            string sSelectedfile = string.Empty;
            string sFilter = "Text files (*.xml)|*.xml|All files (*.*)|*.*";

            if (UserIoHelper.PickLoadFromFile(sInitialDirectory, sSuggestedFilename, ref  sSelectedfile, sFilter))
            {
                try
                {

                    txtRequest.Text = System.IO.File.ReadAllText(sSelectedfile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error reading file.");
                }

            }
 
        }

        private void btnSaveExample_Click(object sender, EventArgs e)
        {
            string sInitialDirectory = Application.StartupPath + "\\EwsPostExamples";

            string sSuggestedFilename = "*.xml";
            string sSelectedfile = string.Empty;
            string sFilter = "Text files (*.xml)|*.xml|All files (*.*)|*.*";

            if ( UserIoHelper.PickSaveFileToFolder(sInitialDirectory, sSuggestedFilename, ref  sSelectedfile, sFilter))
            {
                try
                {
                    System.IO.File.WriteAllText(sSelectedfile, txtRequest.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error writting file.");
                }

            }
        }

        private void SetSettingsFromForm(ref PostFormSetting oPostFormSetting)
        {
 
            oPostFormSetting.User = this.txtUser.Text;
            oPostFormSetting.Domain = this.txtDomain.Text;

            oPostFormSetting.Authentication = this.cmboAuthentication.Text;
            oPostFormSetting.Url = this.txtUrl.Text;
            oPostFormSetting.Verb = this.cmboVerb.Text;
            oPostFormSetting.ContentType = this.cmboContentType.Text;

 
            oPostFormSetting.TimeoutSeconds = (int)this.numericUpDownTimeoutSeconds.Value;

            oPostFormSetting.UserAgent = this.txtUserAgent.Text;

            oPostFormSetting.PragmaNoCache = this.chkPragmaNocache.Checked = oPostFormSetting.PragmaNoCache;
            oPostFormSetting.TranslateF = this.chkTranslateF.Checked;
            oPostFormSetting.AllowAutoRedirect = this.chkAllowRedirect.Checked = oPostFormSetting.AllowAutoRedirect;

            oPostFormSetting.EasRequest = this.txtRequest.Text;
            oPostFormSetting.EasResponse = this.txtResponse.Text;

        }

        private void SetFormFromSettings(PostFormSetting oPostFormSetting)
        {
            try
            {
 
                this.txtUser.Text = FixSetting(oPostFormSetting.User);
                this.txtDomain.Text = FixSetting(oPostFormSetting.Domain);

                this.cmboAuthentication.Text = FixSetting(oPostFormSetting.Authentication);
                this.txtUrl.Text = FixSetting(oPostFormSetting.Url);
                this.cmboVerb.Text = FixSetting(oPostFormSetting.Verb);
                this.cmboContentType.Text = FixSetting(oPostFormSetting.ContentType);

                UInt32 iTimeoutSeconds = 0;
                iTimeoutSeconds = Convert.ToUInt32(oPostFormSetting.TimeoutSeconds);
                this.numericUpDownTimeoutSeconds.Value = iTimeoutSeconds;
                this.txtUserAgent.Text = FixSetting(oPostFormSetting.UserAgent);

                this.chkPragmaNocache.Checked = oPostFormSetting.PragmaNoCache;
                this.chkTranslateF.Checked = oPostFormSetting.TranslateF;
                this.chkAllowRedirect.Checked = oPostFormSetting.AllowAutoRedirect;
 
                this.txtRequest.Text = FixSetting(oPostFormSetting.EasRequest); // .Replace("\n", "\r\n");
                this.txtResponse.Text = FixSetting(oPostFormSetting.EasResponse); //.Replace("\n", "\r\n");

                oPostFormSetting = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error loading settings into form");
            }

        }


        private string FixSetting(string sSetting)
        {
            if (sSetting == null)
                return "";
            else
                return sSetting;

        }

        private void chkDefaultWindowsCredentials_CheckedChanged(object sender, EventArgs e)
        {
            SetFields();  
        }

        private void SetFields()
        {
            if (cmboAuthentication.Text == "DEFAULT")
            {
                txtUser.Enabled = false;
                txtPassword.Enabled = false;
                txtDomain.Enabled = false;
            }
            else
            {
                txtUser.Enabled = true;
                txtPassword.Enabled = true;
                txtDomain.Enabled = true;
            }
        }

        private void cmboAuthentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFields();
        }
    }

    public class PostFormSetting
    {

        public string Authentication = string.Empty;

        public string MailDomain = string.Empty;

        public string User = string.Empty;
        public string Domain = string.Empty;
        public string Password = string.Empty;
        public string Url = string.Empty;
        public string Verb = string.Empty;
        public string ContentType = string.Empty;
        public int TimeoutSeconds = 90;

        public string UserAgent = string.Empty;

        public bool PragmaNoCache = true;
        public bool TranslateF = false;
        public bool AllowAutoRedirect = false; 

        public string EasRequest = string.Empty;
        public string EasResponse = string.Empty;

    }
}
