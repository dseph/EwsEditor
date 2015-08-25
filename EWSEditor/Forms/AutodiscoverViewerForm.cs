using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EWSEditor.Forms.Controls;
using EWSEditor.Logging;
using EWSEditor.Settings;
using Microsoft.Exchange.WebServices.Autodiscover;
using Microsoft.Exchange.WebServices.Data;
using EWSEditor.Common;
using System.DirectoryServices.AccountManagement;

namespace EWSEditor.Forms
{
    public partial class AutodiscoverViewerForm : BaseForm
    {
        private EnumComboBox<ExchangeVersion> exchangeVersionCombo = new EnumComboBox<ExchangeVersion>();

        public new static void Show()
        {
            AutodiscoverViewerForm dialog = new AutodiscoverViewerForm();
            ((Form)dialog).Show();
        }

        private AutodiscoverViewerForm()
        {
            InitializeComponent();
        }

        private void AutodiscoverViewerForm_Load(object sender, EventArgs e)
        {
            this.exchangeVersionCombo.TransformComboBox(this.TempExchangeVersionCombo);
            this.exchangeVersionCombo.HasEmptyItem = true;
            this.exchangeVersionCombo.Text = "Exchange2010_SP2";
            //this.TempExchangeVersionCombo.Text = "Exchange2007_SP1";

            AutodiscoverService oTempService = new AutodiscoverService();

            cmboUserAgent.Items.Clear();
            cmboUserAgent.Items.Add(oTempService.UserAgent);
            UserAgentHelper.AddUserAgentsToComboBox(ref cmboUserAgent);
            cmboUserAgent.Text = oTempService.UserAgent;

            rdoUseAutoDiscover.Checked = true;
            rdoUseUserSpecifiedUrl.Checked = false;
            txtAutodiscoverServiceURL.Enabled = false;

            txtInfo.Text = String.Empty;
            txtInfo.BackColor = System.Drawing.SystemColors.Control;

            SetFields();

            SetEnablementOptionalHeaders();
        }

        private void SetEnablementOptionalHeaders()
        {
            txtHeader1Name.Enabled = chkOptHeader1.Checked;
            txtHeader1Value.Enabled = chkOptHeader1.Checked;

            txtHeader2Name.Enabled = chkOptHeader2.Checked;
            txtHeader2Value.Enabled = chkOptHeader2.Checked;

            txtHeader3Name.Enabled = chkOptHeader3.Checked;
            txtHeader3Value.Enabled = chkOptHeader3.Checked;

        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                txtResults.Text = string.Empty;
                txtResults.Update();


                txtInfo.Text = string.Empty;
                txtInfo.Update();
 

                
                // Create the AutodiscoverService object and set the request
                // ExchangeVersion if one was selected
                AutodiscoverService service = null;
                Uri oURI = null;

                if (this.rdoUseAutoDiscover.Checked == true)
                {
                    if (this.exchangeVersionCombo.SelectedItem.HasValue)
                    {
                        service = new AutodiscoverService(this.exchangeVersionCombo.SelectedItem.Value);
                    }
                    else
                    {
                        service = new AutodiscoverService();
                    }
                }
                else
                {
                    oURI = new Uri(this.txtAutodiscoverServiceURL.Text);
                    if (this.exchangeVersionCombo.SelectedItem.HasValue)
                    {
                        service = new AutodiscoverService(oURI, this.exchangeVersionCombo.SelectedItem.Value);
                    }
                    else
                    {
                        service = new AutodiscoverService(oURI);
                    }
                }
                 
                // Set the AutodiscoverService credentials
                service.UseDefaultCredentials = this.chkDefaultWindowsCredentials.Checked;
                if (!service.UseDefaultCredentials)
                {
                    service.Credentials = new WebCredentials(txtUser.Text.Trim(), txtPassword.Text.Trim(), txtDomain.Text.Trim());
                }

                // Enable/Disable the SCP lookup against Active Directory
                service.EnableScpLookup = this.chkEnableScpLookup.Checked;

                service.ReturnClientRequestId = true;  // This will give us more data back about the servers used in the response headers

                // Enable/Disable pre-authenticating requests
                service.PreAuthenticate = this.chkPreAuthenticate.Checked;

                if (cmboUserAgent.Text.Trim().Length != 0)
                    service.UserAgent = cmboUserAgent.Text.Trim();

                if (chkOptHeader1.Checked == true)
                    service.HttpHeaders.Add(txtHeader1Name.Text, txtHeader1Value.Text);
                if (chkOptHeader2.Checked == true)
                    service.HttpHeaders.Add(txtHeader2Name.Text, txtHeader2Value.Text);
                if (chkOptHeader3.Checked == true)
                    service.HttpHeaders.Add(txtHeader3Name.Text, txtHeader3Value.Text);


                // Create and set the trace listener
                service.TraceEnabled = true;
                //service.TraceEnablePrettyPrinting = true;  // Hmmm not implemented in the 2.2 version of the manage api for the autodiscover object - it is for service
                service.TraceListener = new EwsTraceListener();

                System.Net.WebProxy oWebProxy = null;
                if (this.rdoSpecifyProxySettings.Checked == true)
                {
                    oWebProxy = new System.Net.WebProxy(this.txtProxyServerName.Text.Trim(), Convert.ToInt32(this.txtProxyServerPort.Text.Trim()));

                    service.WebProxy = oWebProxy;
                }

                // Allow/Disallow following 302 redirects in the Autodiscover sequence
                service.RedirectionUrlValidationCallback = ValidationCallbackHelper.RedirectionUrlValidationCallback;

                AutodiscoverGetUserSettings(ref service, this.TargetMailboxText.Text.Trim());

                txtInfo.Text = "Autodiscover URL used: " + service.Url;
            
                //GetUserSettingsResponse response = service.GetUserSettings(this.TargetMailboxText.Text, System.Enum.GetValues(typeof(UserSettingName)) as UserSettingName[]);
                //ErrorDialog.ShowInfo("Autodiscover completed successfully!  Check the EWSEditor Log Viewer for detailed output.");

                 
                //ErrorDialog.ShowInfo(sResponse);
                this.Cursor = Cursors.Default;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        public void AutodiscoverGetUserSettings(ref AutodiscoverService service, string sUserSmtpAddress)
        { 
            string sRet = string.Empty;
            lvItems.Items.Clear();
            txtResults.Text = string.Empty;

            try
            {
                GetUserSettingsResponse response = service.GetUserSettings(
                    sUserSmtpAddress,
                    System.Enum.GetValues(typeof(UserSettingName)) as UserSettingName[]);
                
               
                if (response.ErrorCode == AutodiscoverErrorCode.NoError)
                {
                    string sLine = string.Empty;
                    sLine += "Finished.  \r\n";
                    sLine += "Response Redirect Target: " + response.RedirectTarget + "\r\n";
                    sLine += "\r\n";

                    // Display each retrieved value. The settings are part of a key value pair.
                    string sValue = string.Empty;
                    string sType = string.Empty;
                    int ValueCount = 0;
                    foreach (KeyValuePair<UserSettingName, Object> usersetting in response.Settings)
                    {
                        sValue = string.Empty;

                        ValueCount = 0;
                        sType = usersetting.Value.ToString();
                        switch (sType)
                        {
                            case ("Microsoft.Exchange.WebServices.Autodiscover.WebClientUrlCollection"):
                                Microsoft.Exchange.WebServices.Autodiscover.WebClientUrlCollection oCollection1;
                                oCollection1 = (Microsoft.Exchange.WebServices.Autodiscover.WebClientUrlCollection)usersetting.Value;
                                foreach (WebClientUrl oUrl in oCollection1.Urls)
                                {
                                    sValue += string.Format("Url: {0} \r\n" +
                                                "Authentication: {1}\r\n", 
                                                oUrl.Url, 
                                                oUrl.AuthenticationMethods);
                                    ValueCount++;
                                }
                                break;
                            case ("Microsoft.Exchange.WebServices.Autodiscover.ProtocolConnectionCollection"):
                                Microsoft.Exchange.WebServices.Autodiscover.ProtocolConnectionCollection oCollection2;
                                oCollection2 = (Microsoft.Exchange.WebServices.Autodiscover.ProtocolConnectionCollection)usersetting.Value;
                                foreach (ProtocolConnection oProtocolConnection in oCollection2.Connections)
                                {
                                    sValue += string.Format("Hostname: {0} \r\n" +
                                                "Port: {1}\r\n" +
                                                "EncryptionMethod: {2}\r\n", 
                                                oProtocolConnection.Hostname, 
                                                oProtocolConnection.Port, 
                                                oProtocolConnection.EncryptionMethod);
                                    ValueCount++;
                                }
                                break;
    case ("Microsoft.Exchange.WebServices.Autodiscover.AlternateMailboxCollection"):
        Microsoft.Exchange.WebServices.Autodiscover.AlternateMailboxCollection oCollection3;
        oCollection3 = (Microsoft.Exchange.WebServices.Autodiscover.AlternateMailboxCollection)usersetting.Value;
        foreach (AlternateMailbox oAlternativeMailbox in oCollection3.Entries)
        {
            sValue += string.Format(
                            "Type: {0} \r\n" +
                            "DisplayName: {1} \r\n" +   
                            "LegacyDN: {2} \r\n" +      
                            "Server: {3} \r\n" +
                            "SmtpAddress: {4} \r\n" +
                            "OwnerSmtpAddress: {5} \r\n" +
                            "\r\n", 

                oAlternativeMailbox.Type,
                oAlternativeMailbox.DisplayName,
                oAlternativeMailbox.LegacyDN,
                oAlternativeMailbox.Server,
                oAlternativeMailbox.SmtpAddress,
                oAlternativeMailbox.OwnerSmtpAddress
            
                );
            ValueCount++;
        }
                                break;
                            default:
                                sValue = string.Format("{0}\r\n", usersetting.Value.ToString());
                                break;


                        }
                        ListViewItem oItem = new ListViewItem(usersetting.Key.ToString());
                        ListViewItem.ListViewSubItem o = oItem.SubItems.Add(sValue);
                        if (ValueCount > 1)
                            o.ForeColor = System.Drawing.Color.DarkBlue;
                        lvItems.Items.Add(oItem); // Add to grid


                        //sLine = string.Format("{0}:               {1}", usersetting.Key.ToString(), sValue);

                        //sRet += sLine;
                    }

                    //sRet += "\r\n\r\n-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-\r\n\r\n";
                    //sRet += "Response Information: \r\n\r\n";
                    //sRet += "  Response Redirect Target: " + response.RedirectTarget + "\r\n";
                    //sRet += "  Response Errors: \r\n";
                    //sRet += "     ErrorCode: " + response.ErrorCode + "\r\n";
                    //sRet += "     ErrorMessage: " + response.ErrorMessage + "\r\n";
                    //sRet += "     Error on settings not returned:  \r\n";
                    //sRet += "\r\n";
                    //foreach (UserSettingError oError in response.UserSettingErrors)
                    //{
                    //    sRet += "Setting: " + oError.SettingName + "\r\n";
                    //    sRet += "   ErrorCode: " + oError.ErrorCode + "\r\n";
                    //    sRet += "   ErrorCode: " + oError.ErrorMessage + "\r\n";
                    //    sRet += "\r\n--\r\n";
                    //}
           
                }
                else
                {
                    sRet += "Response Error:\r\n\r\n";
                    sRet += "    AutodiscoverErrorCode : " + response.ErrorCode.ToString() + "\r\n";
                    sRet += "    Error Message:          " + response.ErrorMessage + "\r\n";
                }
            }
            catch (AutodiscoverLocalException oAutodiscoverLocalException)
            {
                sRet += "Caught AutodiscoverLocalException Exception:\r\n\r\n";
                sRet += "    Error Message: " + oAutodiscoverLocalException.Message + "\r\n";
                sRet += "    Inner Error Message: " + oAutodiscoverLocalException.InnerException + "\r\n";
                sRet += "    Stack Trace: " + oAutodiscoverLocalException.StackTrace + "\r\n";
                sRet += "    See: " + oAutodiscoverLocalException.HelpLink + "\r\n";
            }

            catch (AutodiscoverRemoteException oAutodiscoverRemoteException)
            {
                sRet += "Caught AutodiscoverRemoteException Exception:\r\n\r\n";
                sRet += "    Error Message: " + oAutodiscoverRemoteException.Message + "\r\n";
                sRet += "    Inner Error Message: " + oAutodiscoverRemoteException.InnerException + "\r\n";
                sRet += "    Stack Trace: " + oAutodiscoverRemoteException.StackTrace + "\r\n";
                sRet += "    See: " + oAutodiscoverRemoteException.HelpLink + "\r\n";
            }
            catch (AutodiscoverResponseException oAutodiscoverResponseException)
            {
                sRet += "Caught AutodiscoverResponseException Exception:\r\n\r\n";
                sRet += "    Error Message: " + oAutodiscoverResponseException.Message + "\r\n";
                sRet += "    Inner Error Message: " + oAutodiscoverResponseException.InnerException + "\r\n";
                sRet += "    Stack Trace: " + oAutodiscoverResponseException.StackTrace + "\r\n";
                sRet += "    See: " + oAutodiscoverResponseException.HelpLink + "\r\n";
            }
            catch (ServerBusyException srBusyException)  // 2013+
            {
                Console.WriteLine(srBusyException);
                sRet += "Caught ServerBusyException Exception:\r\n\r\n";
                sRet += "    BackOffMilliseconds: " + srBusyException.BackOffMilliseconds.ToString() + "\r\n";
                sRet += "    Error Message: " + srBusyException.Message + "\r\n";
                sRet += "    Inner Error Message: " + srBusyException.InnerException + "\r\n";
                sRet += "    Stack Trace: " + srBusyException.StackTrace + "\r\n";
                sRet += "    See: " + srBusyException.HelpLink + "\r\n";
            }
            catch (Exception ex)
            {
                sRet += "Caught Exception:\r\n\r\n";
                sRet += "    Error Message: " + ex.Message + "\r\n";
                sRet += "    Inner Error Message: " + ex.InnerException + "\r\n";
                sRet += "    Stack Trace: " + ex.StackTrace + "\r\n";
                sRet += "    See: " + ex.HelpLink + "\r\n";
            }

            txtResults.Text = sRet;
        }

        private void chkDefaultWindowsCredentials_CheckedChanged(object sender, EventArgs e)
        {
            SetFields();  
        }

        private void SetFields()
        {
            if (chkDefaultWindowsCredentials.Checked == true)
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

            
            this.cmboUserAgent.Enabled = chkOverrideUserAgent.Checked;

             
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvItems.SelectedItems.Count > 0)
            {
                txtValues.Text = lvItems.SelectedItems[0].SubItems[1].Text;
            }
            else
            {
                txtValues.Text = string.Empty;
            }
        }

        private void lvItems_DoubleClick(object sender, EventArgs e)
        {
            string sDisplay = string.Empty;
            if (lvItems.SelectedItems.Count > 0)
            {
                sDisplay += "Type: \r\n";  
                sDisplay += "-----\r\n" + lvItems.SelectedItems[0].Text;
           
                sDisplay += "\r\n\r\n";

                sDisplay += "Value(s): \r\n";
                sDisplay += "---------\r\n" + lvItems.SelectedItems[0].SubItems[1].Text;

                ShowTextDocument oForm = new ShowTextDocument();
                oForm.txtEntry.WordWrap = false;
                oForm.Text = "Values for item";
                oForm.txtEntry.Text = sDisplay;
                oForm.ShowDialog();
            }
        }

        private void chkOverrideUserAgent_CheckedChanged(object sender, EventArgs e)
        {
            this.cmboUserAgent.Enabled = chkOverrideUserAgent.Checked;
        }

        private void lvItems_Click(object sender, EventArgs e)
        {
 
            if (lvItems.SelectedItems.Count > 0)
            {
                txtValues.Text = lvItems.SelectedItems[0].SubItems[1].Text;
            }
            else
            {
                txtValues.Text = string.Empty;
            }
        }

        private void btnDefaultSmtp_Click(object sender, EventArgs e)
        {
            TargetMailboxText.Text = UserPrincipal.Current.EmailAddress;
        }

        private void btnDefaultUser_Click(object sender, EventArgs e)
        {
            txtUser.Text = UserPrincipal.Current.EmailAddress;
        }

        private void txtValues_TextChanged(object sender, EventArgs e)
        {
 
        }

        private void rdoUseUserSpecifiedUrl_CheckedChanged(object sender, EventArgs e)
        {
            txtAutodiscoverServiceURL.Enabled = rdoUseUserSpecifiedUrl.Checked;
        }

        private void rdoUseAutoDiscover_CheckedChanged(object sender, EventArgs e)
        {
            txtAutodiscoverServiceURL.Enabled = rdoUseUserSpecifiedUrl.Checked;
        }

        private void lblInfo_Click(object sender, EventArgs e)
        {

        }

        private void chkOptHeader1_CheckedChanged(object sender, EventArgs e)
        {
            txtHeader1Name.Enabled = chkOptHeader1.Checked;
            txtHeader1Value.Enabled = chkOptHeader1.Checked;
        }

        private void chkOptHeader2_CheckedChanged(object sender, EventArgs e)
        {
            txtHeader2Name.Enabled = chkOptHeader2.Checked;
            txtHeader2Value.Enabled = chkOptHeader2.Checked;
        }

        private void chkOptHeader3_CheckedChanged(object sender, EventArgs e)
        {
            txtHeader3Name.Enabled = chkOptHeader3.Checked;
            txtHeader3Value.Enabled = chkOptHeader3.Checked;
        }
    }
}
