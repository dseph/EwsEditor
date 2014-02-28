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
using System.Net.Sockets;
 
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

            if (sAuthentication != "DefaultCredentials" && sAuthentication != "DefaultNetworkCredentials")
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
            Int32 UsePort = 443;
            string sResponse = string.Empty;
            if (cmboVerb.Text == "Sockets")
            {
                DoRawPost(txtUrl.Text, txtRequest.Text, UsePort, ref sResponse, 10000);
                txtResponse.Text = sResponse;
            }
            else
                DoPostByHttpVerb();
        }

        private void DoPostByHttpVerb()
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

            List<KeyValuePair<string, string>> oHeadersList = new List<KeyValuePair<string, string>>();
            foreach (DataGridViewRow row in dgvOptions.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    oHeadersList.Add(new KeyValuePair<string, string>(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString()));
                }
            }

            //string sUrl = string.Empty;
            //if (cmboVerb.Text == "  ")
            //{
            //    sUrl = txtUrl.Text.Trim();
            //}
            //else
            //{
            //    sUrl = txtUrl.Text.Trim();

            //}
             

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
                oHeadersList,
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

            cmboVerb.Items.Clear();
            cmboVerb.Items.Add("POST");
            cmboVerb.Items.Add("GET");
            cmboVerb.Items.Add("PUT");
            //cmboVerb.Items.Add("Sockets");
            //cmboVerb.Items.Add("HttpWebRequest RAW");
 
            //EwsPostEnablement();
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

                //this.chkRawPost.Checked = oPostFormSetting.RawPost;
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
            //EwsPostEnablement();
        }

        //private void EwsPostEnablement()
        //{
        //    if (chkRawPost.Checked == true)
        //    {
        //        grpHttpVerbOptions.Enabled = false;
        //    }
        //    else
        //    {
        //        grpHttpVerbOptions.Enabled = true;
        //    }

        //}


        // Sockets code taken from sample from: http://code.msdn.microsoft.com/windowsdesktop/Communication-through-91a2582b
        private bool DoRawPost(string sServer, string sRequest, Int32 PortNumber, ref string sResponse, int iTimeOut)
        {
            // Receiving byte array  
            byte[] bytes = new byte[1024]; 
            Socket senderSock = null;
            int iMaxTick = 0;
            
            bool bError = false;

            string sInfo = string.Empty;

            try
            {

                // Connection ---------------------------------------------------------------------------------------

 
                SocketPermission permission = new SocketPermission(
                    NetworkAccess.Connect,     
                    TransportType.Tcp,         
                    "",                       
                    SocketPermission.AllPorts  
                    );

 
                permission.Demand();  // Make sure we have permisssion to access the socket.

                IPHostEntry ipHost = Dns.GetHostEntry(sServer);
                IPAddress ipAddr = ipHost.AddressList[0];  // Get first IP

                IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, PortNumber);  // Set endpoint
 
                senderSock = new Socket(
                    ipAddr.AddressFamily, 
                    SocketType.Stream,   
                    ProtocolType.Tcp     
                    );

                senderSock.NoDelay = false;    
                senderSock.Connect(ipEndPoint);   

                System.Diagnostics.Debug.WriteLine("Socket is connected to: " + senderSock.RemoteEndPoint.ToString());
 
            }
            catch (SocketException SocketEx)
            {
                //MessageBox.Show(exc.ToString());
                sInfo += "\r\n\r\n" + SocketEx.ToString() + "\r\n\r\n";
                bError = true;

            }
            catch (Exception exc) 
            { 
                //MessageBox.Show(exc.ToString());
                sInfo += "\r\n\r\n" + exc.ToString() + "\r\n\r\n";
                bError = true;
            
            }

            // Send -----------------------------------------------------------------------------------------------
            if (bError == false)
            {
                bool bDoLoopSend = false;
                iMaxTick = Environment.TickCount + iTimeOut;

                do {

                    if (Environment.TickCount > iMaxTick)
                    {
                        sInfo += "\r\n\r\n" + "Error - Timed Out on Send" + "\r\n\r\n";
                        bError = true;
                        bDoLoopSend = false;
                    }

                    if (bError == false)
                    {
                        try
                        {

                            //<Client Quit> is the sign for end of data 
                            string theMessageToSend = sRequest;
                            byte[] msg = Encoding.Unicode.GetBytes(theMessageToSend + "<Client Quit>");  //<Client Quit> is the sign for end of data 

                            // Sends data to a connected Socket. 
                            int bytesSend = senderSock.Send(msg);
                            bDoLoopSend = false;

                        }
                        catch (SocketException SocketEx)
                        {
                            if (SocketEx.SocketErrorCode == SocketError.IOPending || SocketEx.SocketErrorCode == SocketError.WouldBlock || SocketEx.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
                            {
                                bDoLoopSend = true;
                                System.Threading.Thread.Sleep(100);  // Wait 1/10th of a second.
                            }
                            else
                            {
                                sInfo += "\r\n\r\n" + "Error sending - " + SocketEx.ToString() + "\r\n\r\n";
                                bError = true;
                            }

                        }
                        catch (Exception exc)
                        {
                            //MessageBox.Show(exc.ToString());
                            sInfo += "\r\n\r\n" + "Error sending - " + exc.ToString() + "\r\n\r\n";
                            bError = true;

                        }

                    }

                } while (bDoLoopSend == true);
            }

            // Receive Data ------------------------------------------------------------------------------------------
            // http://www.csharp-examples.net/socket-send-receive/

            if (bError == false)
            {
                bool bDoReceiveLoop= false;
                iMaxTick = Environment.TickCount + iTimeOut;
                StringBuilder oSB = new StringBuilder();
                int iReceivedBytes = 0;
                do {

                    if (Environment.TickCount > iMaxTick)
                    {
                        sInfo += "\r\n\r\n" + "Error - Timed Out on Send" + "\r\n\r\n";
                        bError = true;
                        bDoReceiveLoop = false;
                    }

                    if (bError == false)
                    {

                        try
                        {
                            // Receives data from a bound Socket. 
                            iReceivedBytes = senderSock.Receive(bytes);
 
                            // Converts byte array to string 
                            String theMessageToReceive = Encoding.Unicode.GetString(bytes, 0, iReceivedBytes);
                            // Continues to read the data till data isn't available 
                            while (senderSock.Available > 0)
                            {
                                iReceivedBytes += senderSock.Receive(bytes);
                                oSB.Append(Encoding.Unicode.GetString(bytes, 0, iReceivedBytes));
                                bDoReceiveLoop = false;

                                //theMessageToReceive += Encoding.Unicode.GetString(bytes, 0, iReceivedBytes);
                            }

                            theMessageToReceive = oSB.ToString();

                            sInfo = theMessageToReceive;
                            //tbReceivedMsg.Text = "The server reply: " + theMessageToReceive;
                        }
                        catch (SocketException SocketEx)
                        {
                            if (SocketEx.SocketErrorCode == SocketError.IOPending || SocketEx.SocketErrorCode == SocketError.WouldBlock || SocketEx.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
                            {
                                bDoReceiveLoop = true;
                                System.Threading.Thread.Sleep(100);  // Wait 1/10th of a second.
                            }
                            else
                            {
                                sInfo += "\r\n\r\n" + "Error receiving - " + SocketEx.ToString() + "\r\n\r\n";
                                bError = true;
                            }


                        }
                        catch (Exception exc)
                        {
                            //MessageBox.Show(exc.ToString());
                            sInfo += "\r\n\r\n" + "Error receiving - " + exc.ToString() + "\r\n\r\n";
                            bError = true;
                        }

                    }
                } while (bDoReceiveLoop == true);
            
            }

            // Disconnect ---------------------------------------------------------------------------------------
            try
            {
                // Disables sends and receives on a Socket. 
                senderSock.Shutdown(SocketShutdown.Both);

                //Closes the Socket connection and releases all resources 
                senderSock.Close();

                //Disconnect_Button.IsEnabled = false;
            }
            catch (SocketException SocketEx)
            {
                //MessageBox.Show(exc.ToString());
                sInfo += "\r\n\r\n" + SocketEx.ToString() + "\r\n\r\n";
                bError = true;

            }
            catch (Exception exc) 
            { 
                MessageBox.Show(exc.ToString());
                sInfo += "\r\n\r\n" + exc.ToString() + "\r\n\r\n";
                bError = true;
            }

            sResponse = sInfo;

            return bError;
        }

        private void cmboVerb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
 
         
        // End of class
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
