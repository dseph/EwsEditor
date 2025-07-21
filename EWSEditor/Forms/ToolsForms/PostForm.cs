// PostForm.cs
// Used for raw POSTs using EWS.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EWSEditor.Common;
using Microsoft.Exchange.WebServices.Data;
using System.Net;
using System.Web;

 
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Xml;
using System.Diagnostics;
using System.Linq.Expressions;

namespace EWSEditor.Common
{
    public partial class PostForm : Form
    {
        private EwsEditorAppSettings _CurrentAppSettings = null;

        private string _XAnchorMailboxDefault = string.Empty;

        public PostForm()
        {
            InitializeComponent();
        }
        public PostForm(EwsEditorAppSettings oCurrentAppSettings)
        {
            InitializeComponent();
            _CurrentAppSettings = oCurrentAppSettings;

            if (_CurrentAppSettings != null)
                _XAnchorMailboxDefault = _CurrentAppSettings.MailboxBeingAccessed;
        }

     



        private CredentialCache GetCredentials(string sAuthentication, string User, string Password, string Domain, string Url)
        {
            NetworkCredential oNetworkCredential = null; 
            CredentialCache oCredentialCache = null;
 
            oCredentialCache = new CredentialCache();
           
            Uri oUri = new Uri(Url);

             

            if (sAuthentication == "Anonymous")
            {
                oCredentialCache = null;
                //oNetworkCredential = new NetworkCredential();
                 
            }
            else
            {  

                if (sAuthentication != "DefaultCredentials" && sAuthentication != "DefaultNetworkCredentials")
                {
                    if (txtDomain.Text.Trim().Length == 0)
                        oNetworkCredential = new NetworkCredential(User, Password);
                    else
                        oNetworkCredential = new NetworkCredential(User, Password, Domain);
                    oCredentialCache.Add(oUri, sAuthentication, oNetworkCredential);
                    //oCredentialCache.Add(oUri, "Basic", oNetworkCredential);
                    //oCredentialCache.Add(oUri, "NTLM", oNetworkCredential);
                    //oCredentialCache.Add(oUri, "Digest", oNetworkCredential);
                }
                else
                {
                   
                }
            }
 
            return  oCredentialCache;
        }

        private void GoRun_Click(object sender, EventArgs e)
        {

            if (cmboVerb.Text == "RAW")
                DoRawPost();
            else
                DoPostByHttpVerb();
 


        }

        string CheckResponseForOddCharacters(string sBody)
        {
            StringBuilder oSB = new StringBuilder();
       
            bool bResponseHasUnicode = false;
            bool bResponseHasExtendedAsciiCharacters = false;
            bool bResponseHasControlCharacters = false;
            bool bResponseHasOddCharacters = false;
            string sReponseCheck = string.Empty;
            bool bThisCharacterIsOK = false;

            int iVal = 0;
            string sComment = string.Empty;
            StringBuilder oCharCheck = new StringBuilder();

            oCharCheck.AppendFormat("\r\nDumping response string...\r\n");
            oCharCheck.AppendFormat("Value   Char  Comment\r\n");
            StringBuilder oSanitized = new StringBuilder();
            foreach (char c in sBody)
            {
                bThisCharacterIsOK = true;

                sComment = string.Empty;
                iVal = (int)c;
                if (iVal > 127 & iVal < 256)
                {
                    sComment = "Over 127   ***  ***  ***";
                    bResponseHasOddCharacters = true;
                    bResponseHasExtendedAsciiCharacters = true;
                    bThisCharacterIsOK = true;
                }
                if (iVal > 255)
                { 
                    sComment = "Over 255   ***  ***  ***";
                    bResponseHasOddCharacters = true;
                    bResponseHasUnicode = true;
                    bThisCharacterIsOK = true;
                }
                if ((iVal > 0 && iVal < 7) || (iVal > 13 && iVal < 32))
                {
                    sComment = "Control Character   ***  ***  ***";
                    bResponseHasControlCharacters = true;
                    bResponseHasOddCharacters = true;
                    bThisCharacterIsOK = true;
                }

                if (bThisCharacterIsOK == true)
                {
                    oSanitized.Append(c);
                     
                }

                oCharCheck.AppendFormat("[{0}] - {1}  {2} \r\n", (int)c, c, sComment);
            }


            if (bResponseHasOddCharacters == true)
            {
                oSB.AppendLine("***");
                if (bResponseHasControlCharacters == true)
                    oSB.AppendLine("***  Control Characters found in response. ***");
                if (bResponseHasUnicode == true)
                    oSB.AppendLine("***  Unicode characters found in response. ***");
                if (bResponseHasExtendedAsciiCharacters == true)
                    oSB.AppendLine("***  Extended ASCII characters found in response. ***");
                oSB.AppendLine("***");
                oSB.Append(oCharCheck.ToString());  // Character by character check

                oSB.Append("\r\nThe following is a version of the response without extended ascii/unicode/control characters:\r\n\r\n");
                oSB.Append(oSanitized.ToString());
                oSB.Append("\r\n\r\n");

                MessageBox.Show("The are non-basic ASCII characters found in response. Check the EWS Call Info text box.");
            }
            else
                oSB.Append(oSanitized.ToString());

            return oSB.ToString();
        }

 

        private void DoRawPost()
        {


            string sRequest = string.Empty;
            sRequest = txtRequest.Text;

            System.Net.WebProxy oWebProxy = null;
            if (this.rdoSpecifyProxySettings.Checked == true)
            {
                oWebProxy = new System.Net.WebProxy(this.txtProxyServerName.Text.Trim(), Convert.ToInt32(this.txtProxyServerPort.Text.Trim()));
            }

            DateTime dtStart = DateTime.Now;
            Stopwatch oStopwatch = new Stopwatch();
            oStopwatch.Start();
             
            HttpWebRequest oHttpWebRequest = EWSEditor.Common.HttpHelper.EntirePostRequestToHttpWebRequest(
                    txtRequest.Text,
                    cmboAuthentication.Text,
                    txtUser.Text.Trim(),
                    txtPassword.Text.Trim(),
                    txtDomain.Text.Trim(),
                    oWebProxy
                );
 

            bool bRet = false;
            string sRequestHeaders = string.Empty;
            string sResult = string.Empty;
            string sResponeHeaders= string.Empty;
            string sError= string.Empty;
            string sResponseStatusCode= string.Empty;
            int iResponseStatusCodeNumber = 0;
            string sResponseStatusDescription= string.Empty;

            bRet = EWSEditor.Common.HttpHelper.DoHttpWebRequest(
                ref oHttpWebRequest,
 
                ref sRequestHeaders,
                ref sResult,
                ref sResponeHeaders,
                ref sError,
                ref sResponseStatusCode,
                ref iResponseStatusCodeNumber,
                ref sResponseStatusDescription
            );

            DateTime dtEnd = DateTime.Now;
            oStopwatch.Stop();
            TimeSpan oTimeSpan = oStopwatch.Elapsed;
            string sElapsed = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    oTimeSpan.Hours,
                    oTimeSpan.Minutes,
                    oTimeSpan.Seconds,
                    oTimeSpan.Milliseconds / 10);


            sResult = SerialHelper.TryRestoreCrLfAndIndents(sResult);
            txtResponse.Text = sResult;
      
            // blank
           //wbResponse.DocumentText = sResult;

           // blank...
           // string sFile = CreateTempFile(sResult, "xml");
            // wbResponse.Navigate(sFile);
            
            // same...
            //byte[] bytes = Encoding.UTF8.GetBytes(sResult);
            //MemoryStream oMemoryStream = new MemoryStream();
            //oMemoryStream.Write(bytes, 0, bytes.Length);
            //oMemoryStream.Position = 0;
            //wbResponse.DocumentStream = oMemoryStream;

            // Note:  If the browser or browser control sees whats inteh utf16Line line the it will error and not render.
            // So as a work-around for now the code wills trip that line just for ie control rendering.
            string utf16Line = "<?xml version=\"1.0\" encoding=\"utf-16\"?>";
            string utf8Line = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
            string sCopy = sResult.TrimStart();

            if (sCopy.StartsWith(utf16Line))
            {
                sCopy = sCopy.Remove(0, utf16Line.Length);
                sCopy = sCopy.TrimStart();
            }
            if (sCopy.StartsWith(utf8Line))
            {
                sCopy = sCopy.Remove(0, utf8Line.Length);
                sCopy = sCopy.TrimStart();
            }

            string sFile = CreateTempFile(sCopy, "xml");
            wbResponse.Navigate(sFile);
            wbResponse.DocumentText = sCopy;
          
          
            // Start building Call summery 

            StringBuilder oSB = new StringBuilder();
            string sDividerLine = "----------------------------------------\r\n\r\n";

            oSB.AppendFormat("** Call Report **\r\n\r\n");

            oSB.AppendFormat("Start: {0}  End: {1}  Timespan: {2}\r\n\r\n",
                dtStart.ToString(),
                dtEnd.ToString(),
                sElapsed
                );

            if (bRet != true)
            {

                oSB.AppendFormat("Failed:\r\n");
                oSB.AppendFormat("    Error: {0}\r\n\r\n", sError);
            }

            oSB.AppendFormat(sDividerLine);

            oSB.AppendFormat("ResponseStatusCode: {0}\r\n\r\n", sResponseStatusCode);
            oSB.AppendFormat("ResponseCodeNumber: {0}\r\n\r\n", iResponseStatusCodeNumber);
            oSB.AppendFormat("ResponseStatusDescription: {0}\r\n\r\n", sResponseStatusDescription);
            //oSB.AppendFormat("Result: {0}\r\n", sResult);
            oSB.AppendFormat(sDividerLine);

            oSB.AppendFormat("Request Headers: \r\n\r\n{0}\r\n\r\n", sRequestHeaders);
            oSB.AppendFormat("Request Body: \r\n\r\n{0}\r\n\r\n", txtRequest.Text);

            oSB.AppendFormat(sDividerLine);
            oSB.AppendFormat("Response Headers: \r\n\r\n{0}\r\n\r\n", sResponeHeaders);
            oSB.AppendFormat("Response Body: \r\n\r\n{0}\r\n\r\n", sResult);

            oSB.AppendFormat(sDividerLine);
            oSB.AppendFormat("Check Response For Odd Characters: \r\n\r\n{0}\r\n\r\n", CheckResponseForOddCharacters(sResult));


            txtResponseSummary.Text = oSB.ToString();


            this.Cursor = Cursors.Default;
             
        }


        private string CreateTempFile(string sContent)
        {
            string sFileNameExtension = string.Empty;
            return CreateTempFile(sContent, sFileNameExtension);
        }

        private string CreateTempFile(string sContent, string sFileNameExtension)
        {


            string sFoldePath = Path.GetTempPath();
            string sFileName = Path.GetRandomFileName();
            if (sFileNameExtension != string.Empty)
                sFileName += ("." + sFileNameExtension);
            string sFile = Path.Combine(sFoldePath, sFileName);

            StreamWriter oSW = new StreamWriter(sFile);
            oSW.Write(sContent);
            oSW.Close();
            oSW = null;

            //File.WriteAllText(sFile, sContent);

            return sFile;
        }


        private void DoPostByHttpVerb()
        {
            string sRequestHeaders = string.Empty;
            string sResult = string.Empty;
            string sResponeHeaders = string.Empty;

            string sError = string.Empty;

            string sResponseStatusCodeNumber = string.Empty;
            string sResponseStatusCode = string.Empty;
            int  iResponseStatusCodeNumber = 0;
            string sResponseStatusDescription = string.Empty;


            EWSEditor.Logging.EwsTraceListener oETL = new Logging.EwsTraceListener();
            //oETL.Trace("xxxx", "xxxx");


            this.Cursor = Cursors.WaitCursor;
            string sUseVerb = cmboVerb.Text.Trim();

            // http://msdn.microsoft.com/en-us/library/office/bb409286(v=exchg.150).aspx


            List<KeyValuePair<string, string>> oHeadersList = new List<KeyValuePair<string, string>>();
            foreach (DataGridViewRow row in dgvOptions.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    oHeadersList.Add(new KeyValuePair<string, string>(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString()));
                }
            }

            if (cmboVerb.Text.Trim().ToUpper() == "GET RESTREPORT" )
            {
                oHeadersList.Add(new KeyValuePair<string, string>("DataServiceVersion", "2.0"));
                oHeadersList.Add(new KeyValuePair<string, string>("MaxDataServiceVersion", "2.0"));
                oHeadersList.Add(new KeyValuePair<string, string>("Accept-Language", "EN-US"));
                oHeadersList.Add(new KeyValuePair<string, string>("X-RWS-Version", "2013-V1"));

                sUseVerb = "GET";
            }


            System.Net.WebProxy oWebProxy = null;
            if (this.rdoSpecifyProxySettings.Checked == true)
            {
                oWebProxy = new System.Net.WebProxy(this.txtProxyServerName.Text.Trim(), Convert.ToInt32(this.txtProxyServerPort.Text.Trim()));

                // TODO: If space is found for the other proxy settins on the window then add them and use the code below.  You can copy the fields from the GlobalOptionsDialog.cs form.
                //oWebProxy.BypassProxyOnLocal = this.chkBypassProxyForLocalAddress.Checked;
                //if (this.rdoOverrideProxyCredentials.Checked == true)
                //{

                //    if (this.txtProxyServerUser.Text.Trim().Length == 0)
                //    {
                //        oWebProxy.UseDefaultCredentials = true;
                //    }
                //    else
                //    {
                //        if (this.txtProxyServerDomain.Trim().Length == 0)
                //            oWebProxy.Credentials = new NetworkCredential(this.txtProxyServerUser.Text.Trim(), this.txtProxyServerPassword.Text.Trim());
                //        else
                //            oWebProxy.Credentials = new NetworkCredential(this.txtProxyServerUser.Text.Trim(), this.txtProxyServerPassword.Text.Trim(), this.txtProxyServerDomain.Text.Trim());
                //    }
                //}
                //else
                //{
                //    oWebProxy.UseDefaultCredentials = true;
                //}
            }
 
            bool bRet = false;

            DateTime dtStart = DateTime.Now;
            Stopwatch oStopwatch = new Stopwatch();
            oStopwatch.Start();

            bRet = EWSEditor.Common.HttpHelper.HtppCall(
                sUseVerb,
                txtUrl.Text.Trim(),
                cmboContentType.Text,
                cmboAuthentication.Text,
                txtUser.Text.Trim(),
                txtPassword.Text.Trim(),
                txtDomain.Text.Trim(),
                oHeadersList,
                oWebProxy,
                txtRequest.Text,
                //txtProxyServer.Text,
                //txtProxyPort.Text,
                (int)numericUpDownTimeoutSeconds.Value,
                chkPragmaNocache.Checked,
                chkTranslateF.Checked,
                chkAllowRedirect.Checked,
                cmboUserAgent.Text,
                ref sRequestHeaders,
                ref sResult,
                ref sResponeHeaders,
                ref sError,
                ref sResponseStatusCode,
                ref iResponseStatusCodeNumber,
                ref sResponseStatusDescription
                );

            DateTime dtEnd = DateTime.Now;
            oStopwatch.Stop();
            TimeSpan oTimeSpan = oStopwatch.Elapsed;
            string sElapsed = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    oTimeSpan.Hours,
                    oTimeSpan.Minutes,
                    oTimeSpan.Seconds,
                    oTimeSpan.Milliseconds / 10);

            string sResultOrigional = sResult;
            sResult = SerialHelper.TryRestoreCrLfAndIndents(sResult);
            txtResponse.Text = sResult;

            // Logging

            if (chkLogCalls.Checked)
            {
                oETL.Trace("EwsRequestHttpHeaders", EWSPostLogEntry(sRequestHeaders, "EwsRequestHttpHeaders"));
                oETL.Trace("EwsRequestHttpBody", EWSPostLogEntry(txtRequest.Text, "EwsRequestHttpBody"));

                oETL.Trace("EwsResponseHttpHeaders", EWSPostLogEntry(sResponeHeaders, "EwsResponseHttpHeaders"));
                oETL.Trace("EwsResponseHttpBody", EWSPostLogEntry(sResultOrigional, "EwsResponseHttpBody"));

                //Debug this section
            }



            string utf16Line = "<?xml version=\"1.0\" encoding=\"utf-16\"?>";
            string utf8Line = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
            string sCopy = sResult.TrimStart();

            if (sCopy.StartsWith(utf16Line))
            {
                //sCopy = sCopy.Remove(0, utf16Line.Length);
 
                sCopy = sCopy.Replace(utf16Line, utf8Line + "\r\n<!-- Note: EwsEditor has replaced the \"utf-16\" text in the first line with\"utf-8\" in order for the XML to render in the response web control. -->");
                //sCopy = sCopy.TrimStart();
            }

            wbResponse.DocumentText = sCopy;
            txtResponse.Text = sCopy;


            StringBuilder oSB = new StringBuilder();
            string sDividerLine = "----------------------------------------\r\n\r\n";

            oSB.AppendFormat("** Call Report **\r\n\r\n");

            oSB.AppendFormat("Start: {0}  End: {1}  Timespan: {2}\r\n\r\n",
                dtStart.ToString(),
                dtEnd.ToString(),
                sElapsed
                );

            if (bRet != true)
            {

                oSB.AppendFormat("Failed:\r\n");
                oSB.AppendFormat("    Error: {0}\r\n\r\n", sError);
            }

            oSB.AppendFormat(sDividerLine);

            oSB.AppendFormat("ResponseStatusCode: {0}\r\n\r\n", sResponseStatusCode);
            oSB.AppendFormat("ResponseCodeNumber: {0}\r\n\r\n", iResponseStatusCodeNumber);
            oSB.AppendFormat("ResponseStatusDescription: {0}\r\n\r\n", sResponseStatusDescription);
            //oSB.AppendFormat("Result: {0}\r\n", sResult);
            oSB.AppendFormat(sDividerLine);

            oSB.AppendFormat("Request Headers: \r\n\r\n{0}\r\n\r\n", sRequestHeaders);
            oSB.AppendFormat("Request Body: \r\n\r\n{0}\r\n\r\n", txtRequest.Text);

            oSB.AppendFormat(sDividerLine);
            oSB.AppendFormat("Response Headers: \r\n\r\n{0}\r\n\r\n", sResponeHeaders);
            oSB.AppendFormat("Response Body: \r\n\r\n{0}\r\n\r\n", sResult);

            oSB.AppendFormat(sDividerLine);
            oSB.AppendFormat("Check Response For Odd Characters: \r\n\r\n{0}\r\n\r\n", CheckResponseForOddCharacters(sResult));


            txtResponseSummary.Text = oSB.ToString();

            //StringBuilder oSB = new StringBuilder();

            //oSB.AppendFormat("Start: {0}  End: {1}  Timespan: {2}:\r\n\r\n", 
            //    dtStart .ToString(),
            //    dtEnd.ToString(),
            //    sElapsed
            //    );

            //if (bRet != true)
            //{  

            //    oSB.AppendFormat("Failed:\r\n"); 
            //    oSB.AppendFormat("    Error: {0}\r\n\r\n", sError);
            //}

            //oSB.AppendFormat("ResponseStatusCode: {0}\r\n\r\n", sResponseStatusCode);
            //oSB.AppendFormat("ResponseCodeNumber: {0}\r\n\r\n", iResponseStatusCodeNumber);
            //oSB.AppendFormat("ResponseStatusDescription: {0}\r\n\r\n", sResponseStatusDescription);
            ////oSB.AppendFormat("Result: {0}\r\n", sResult);



            //oSB.AppendFormat("Request Headers: \r\n{0}\r\n", sRequestHeaders);
            //oSB.AppendFormat("Response Headers: \r\n{0}\r\n", sResponeHeaders);

            //oSB.AppendLine(CheckResponseForOddCharacters(sResult));

            //txtResponseSummary.Text = oSB.ToString();


            this.Cursor = Cursors.Default;
        }

        private string EWSPostLogEntry(string sEntry, string sEntryType)
        {
            string sTraceTop = "< Trace Tag = \"EwsResponseHttpHeaders\" Tid = \"1\" Time = \"" + DateTime.Now.ToString() + "\" >\r\n";
            string sTraceBottom = "\r\n</Trace>\r\n";

            return sTraceTop + sEntry + sTraceBottom;


            //< Trace Tag = "EwsResponseHttpHeaders" Tid = "1" Time = "2021-05-10 14:32:36Z" >
        }

        private void PostForm_Load(object sender, EventArgs e)
        {
            SetFields();
            //EwsPostEnablement();
            SetEnablementForPostByVerb(true);

            // Below lines are critical to work-around resizing issues for the scrolling text boxes.
            tabControl1.Width = splitContainer1.Panel1.Width -2;
            tabResponse.Width = splitContainer1.Panel2.Width -2;
            tabControl1.Height = splitContainer1.Panel1.Height - 2;
            tabResponse.Height = splitContainer1.Panel2.Height - 2;
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
            string sFilter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";

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
            string sFilter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";

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

            oPostFormSetting.UserAgent = this.cmboUserAgent.Text;

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

                //this.chkRawPost.Checked = oPostFormSetting.RawPost;
                UInt32 iTimeoutSeconds = 0;
                iTimeoutSeconds = Convert.ToUInt32(oPostFormSetting.TimeoutSeconds);
                this.numericUpDownTimeoutSeconds.Value = iTimeoutSeconds;
                this.cmboUserAgent.Text = FixSetting(oPostFormSetting.UserAgent);

                this.chkPragmaNocache.Checked = oPostFormSetting.PragmaNoCache;
                this.chkTranslateF.Checked = oPostFormSetting.TranslateF;
                this.chkAllowRedirect.Checked = oPostFormSetting.AllowAutoRedirect;
 
                this.txtRequest.Text = FixSetting(oPostFormSetting.EasRequest); // .Replace("\n", "\r\n");

                string sRet = string.Empty;
                if (CheckXml(txtRequest.Text, ref sRet) == true)
                    wbRequest.DocumentText = txtRequest.Text;
                else
                    wbRequest.DocumentText = sRet;

 
                this.txtResponse.Text = FixSetting(oPostFormSetting.EasResponse); //.Replace("\n", "\r\n");
                //try
                //{
                //    this.wbResponse.DocumentText = txtRequest.Text;
                //}
                //catch (Exception ex1)
                //{ }

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

            cmboUserAgent.Items.Clear();
            EWSEditor.Common.UserAgentHelper.AddUserAgentsToComboBox(ref cmboUserAgent);


            //cmboAuthentication.Text = "Basic";
            //cmboVerb.Text = "POST";
            //cmboAuthentication.Text = "text/xml";
             
        }

        private void cmboAuthentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetFields();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAddHeaders_Click(object sender, EventArgs e)
        {
             
            EWSEditor.Forms.MailHeadersForm oForm = new EWSEditor.Forms.MailHeadersForm ();

            oForm.ShowDialog(this);
            if (oForm.bChoseSave == true)
            {
                int n = dgvOptions.Rows.Add();
                dgvOptions.Rows[n].Cells[0].Value = oForm.txtName.Text;
                dgvOptions.Rows[n].Cells[1].Value = oForm.txtValue.Text;
            }
            oForm = null;
        }

        private void btnDeleteHeader_Click(object sender, EventArgs e)
        {
            if (dgvOptions.SelectedRows.Count > 0) { dgvOptions.Rows.RemoveAt(dgvOptions.SelectedRows[0].Index); }
        }

        private void chkRawPost_CheckedChanged(object sender, EventArgs e)
        {
         
        }

        private void EwsPostEnablement()
        {
            grpHttpVerbOptions.Enabled = true;

            //if (chkRawPost.Checked == true)
            //{
            //    grpHttpVerbOptions.Enabled = false;
            //}
            //else
            //{
            //    grpHttpVerbOptions.Enabled = true;
            //}

        }

        private void btnDefault365Settings_Click(object sender, EventArgs e)
        {
            cmboAuthentication.Text = "Basic";
            txtUrl.Text = "https://outlook.office365.com/EWS/Exchange.asmx";

        }

        private void cmboUserAgent_SelectedIndexChanged(object sender, EventArgs e)
        {
             
        }

        private void txtResponse_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmboVerb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmboVerb.Text == "RAW")
                SetEnablementForPostByVerb(false);
            else
                SetEnablementForPostByVerb(true);
        }

        private void SetEnablementForPostByVerb(bool bEnable)
        {
            cmboContentType.Enabled = bEnable;
            numericUpDownTimeoutSeconds.Enabled = bEnable;
            cmboUserAgent.Enabled = bEnable;
            chkPragmaNocache.Enabled = bEnable;
            chkTranslateF.Enabled = bEnable;
            chkPragmaNocache.Enabled = bEnable;
            chkAllowRedirect.Enabled = bEnable;
            dgvOptions.Enabled = bEnable;
            btnAddHeaders.Enabled = bEnable;
            btnDeleteHeader.Enabled = bEnable;
            txtUrl.Enabled = bEnable;
        }

        private void cmboContentType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabControl2_Click(object sender, EventArgs e)
        {
   
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            string sRet = string.Empty;
            if (CheckXml(txtRequest.Text, ref sRet) == true)
                wbRequest.DocumentText = txtRequest.Text;
            else
                wbRequest.DocumentText = sRet;
        }

        

        private void wbRequest_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
       
            
        }

        private void wbResponse_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
           // wbResponse
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void rdoDontOverrideProxySettings_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtProxyServerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddQuickHeaders_Click(object sender, EventArgs e)
        {
            PostFormQuickHeaders oForm = new PostFormQuickHeaders(_CurrentAppSettings);
            oForm.XAnchorMailbox = _XAnchorMailboxDefault;
            oForm.ShowDialog(this);

            if (oForm.choseOK)
            {
                if (oForm.choseNewClientRequestId == true)
                    AddHeaderRows("client-request-id", Guid.NewGuid().ToString());

                if (oForm.choseReturnClientRequestId == true)
                    AddHeaderRows("return-client-request-id", "True");

                if (oForm.choseLoginToken == true)
                    AddHeaderRows("Authorization", "bearer " + _CurrentAppSettings.oBearerToken);

                if (oForm.choseXAnchorMailbox == true)
                {
                    AddHeaderRows("X-AnchorMailbox", oForm.XAnchorMailbox);
                    _XAnchorMailboxDefault = oForm.XAnchorMailbox;
                }
            }
             
            oForm = null;
 
            //EwsTraceListener
        }

        private void AddHeaderRows(string sName, string sValue)
        {

            int x = 0;
            x = dgvOptions.Rows.Count;
            x = dgvOptions.RowCount;
            x = 0;
            foreach (DataGridViewRow xx  in dgvOptions.Rows)
            {
                //string sHeader = dgvOptions.Rows[x].Cells[0].Value.ToString();
                x++;
            }

            // Remove existing header if there is a match.  
            for (int iCount = dgvOptions.Rows.Count  -1; iCount > 0; iCount--)
            {
                DataGridViewRow o = dgvOptions.Rows[iCount-1];
                //string sHeader = dgvOptions.Rows[iCount ].Cells[0].Value.ToString();
                string sHeader = o.Cells[0].Value.ToString();

                if (sHeader == sName)
                {
                    dgvOptions.Rows.RemoveAt(dgvOptions.Rows[iCount-1].Index);
                }
           }

            // Add new header
            int n = dgvOptions.Rows.Add();
            dgvOptions.Rows[n].Cells[0].Value = sName;
            dgvOptions.Rows[n].Cells[1].Value = sValue;
        }

        private void grpHttpVerbOptions_Enter(object sender, EventArgs e)
        {

        }

        private void tabControl1_Click_1(object sender, EventArgs e)
        {

           // wbRequest.DocumentText = "";
            try
            {
                string sRet = string.Empty;
                if (CheckXml(txtRequest.Text, ref sRet) == true)
                    wbRequest.DocumentText = txtRequest.Text;
                else
                    wbRequest.DocumentText = sRet;

     
            }
            catch (Exception ex)
            {
                wbRequest.DocumentText = ex.ToString();
            };
        }

        private bool CheckXml(string XmlString, ref string  CheckXml)
        {
            string sRet = string.Empty;

            bool bRet = false;

            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.DtdProcessing = DtdProcessing.Prohibit; // Optional: to prevent DTD processing

                using (XmlReader reader = XmlReader.Create(new System.IO.StringReader(XmlString), settings))
                {
                    while (reader.Read()) { }
                }

                bRet = true;
                sRet = XmlString;
                // Console.WriteLine("XML is well-formed.");
            }
            catch (XmlException ex)
            {
                sRet = string.Format($"XML is not well-formed: {ex.Message}");

                bRet = false;
            }
            CheckXml = sRet;
            return bRet;
             
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

        public bool RawPost = false;

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
