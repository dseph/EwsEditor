using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using EWSEditor;
using EWSEditor.Exchange;
using EWSEditor.Settings;
using EWSEditor.Resources;
using System.Net;

namespace EWSEditor
{
    public partial class GetMailTipsForm : Form
    {
        public GetMailTipsForm()
        {
            InitializeComponent();
        }

        private void GetMailTips_Load(object sender, EventArgs e)
        {


            this.cmboMailTipsRequested.Text = "All";
            this.cmboMailboxRoutingType.Text = "SMTP";
        }

        private static bool GetMailTipsEWS(string ServerVersion, string SendingAs_EmailAddress, string Mailbox_EmailAddress, string Mailbox_RoutingType, string MailTipsRequested, ref string sXMLResponse)
        {

            bool bSuccess = false;
            string sResponseText = string.Empty;
            System.Net.HttpWebRequest oHttpWebRequest = null;
            EwsProxyFactory.CreateHttpWebRequest(ref oHttpWebRequest);

            string EwsRequest = string.Empty;
            EwsRequest = TemplateEwsRequests.GetMailTips;
         
            EwsRequest = EwsRequest.Replace("##RequestServerVersion##", "Exchange2010");
            EwsRequest = EwsRequest.Replace("##SendingAs.EmailAddress##", SendingAs_EmailAddress);
            EwsRequest = EwsRequest.Replace("##Mailbox.EmailAddress##", Mailbox_EmailAddress);
            EwsRequest = EwsRequest.Replace("##Mailbox.RoutingType##", Mailbox_RoutingType);
            EwsRequest = EwsRequest.Replace("##MailTipsRequested##", MailTipsRequested);

             

            //string sBase64Data = string.Empty;
            //sBase64Data = EWSEditor.Common.FileHelper.GetBinaryFileAsBase64(sFile);
            //System.Diagnostics.Debug.WriteLine("sBase64: " + sBase64Data);
            // EwsRequest = EwsRequest.Replace("##Data##", sBase64Data); // Convert byte array to base64

            // Now inject the base64 body into the stream:
            try
            {

                byte[] bytes = Encoding.UTF8.GetBytes(EwsRequest);
                oHttpWebRequest.ContentLength = bytes.Length;

                using (Stream requestStream = oHttpWebRequest.GetRequestStream())
                {
                    requestStream.Write(bytes, 0, bytes.Length);
                    requestStream.Flush();
                    requestStream.Close();
                }

                // Get response
                HttpWebResponse oHttpWebResponse = (HttpWebResponse)oHttpWebRequest.GetResponse();

                StreamReader oStreadReader = new StreamReader(oHttpWebResponse.GetResponseStream());
                sResponseText = oStreadReader.ReadToEnd();


                if (oHttpWebResponse.StatusCode == HttpStatusCode.OK)
                {
                    bSuccess = true;
                }
                else
                {
                    bSuccess = false;
                }
            }
            finally
            {


            }
            sXMLResponse = sResponseText;
            return bSuccess;
        }

        private void cmboMailTipsRequested_SelectedIndexChanged(object sender, EventArgs e)
        {
            // https://msdn.microsoft.com/en-us/library/office/dd899452(v=exchg.150).aspx
        }

        private void btnGetMailTips_Click(object sender, EventArgs e)
        {
            string sResult = string.Empty;
            bool bRet = false;
            bRet = GetMailTipsEWS("Exchange2010",
                this.txtSendAsMailbox.Text.Trim(),
                txtMailboxEmailAddressxtBox1.Text.Trim(),
                cmboMailboxRoutingType.Text,
                cmboMailTipsRequested.Text,
                ref sResult
                );

            if (bRet == true)
            {
                txtResponse.Text = sResult;
                webBrowser1.DocumentText = txtResponse.Text;
            }
            else
            {
                txtResponse.Text = "";
                webBrowser1.DocumentText = "";
         
            }

        }

        private void txtResponse_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
