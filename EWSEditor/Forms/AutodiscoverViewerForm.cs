using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EWSEditor.Forms.Controls;
using EWSEditor.Logging;
using EWSEditor.Settings;
using Microsoft.Exchange.WebServices.Autodiscover;
using Microsoft.Exchange.WebServices.Data;
using EWSEditor.Common;

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
            //this.TempExchangeVersionCombo.Text = "Exchange2007_SP1";
            SetFields();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // Create the AutodiscoverService object and set the request
                // ExchangeVersion if one was selected
                AutodiscoverService service = null;
                if (this.exchangeVersionCombo.SelectedItem.HasValue)
                {
                    service = new AutodiscoverService(this.exchangeVersionCombo.SelectedItem.Value);
                }
                else
                {
                    service = new AutodiscoverService();
                }

                // Set the AutodiscoverService credentials
                service.UseDefaultCredentials = this.chkDefaultWindowsCredentials.Checked;
                if (!service.UseDefaultCredentials)
                {
                    service.Credentials = new WebCredentials(txtUser.Text, txtPassword.Text, txtDomain.Text);
                }

                // Enable/Disable the SCP lookup against Active Directory
                service.EnableScpLookup = this.chkEnableScpLookup.Checked;

                // Enable/Disable pre-authenticating requests
                service.PreAuthenticate = this.chkPreAuthenticate.Checked;

                // Create and set the trace listener
                service.TraceEnabled = true;
                service.TraceListener = new EwsTraceListener();

                // Allow/Disallow following 302 redirects in the Autodiscover sequence
                service.RedirectionUrlValidationCallback = ValidationCallbackHelper.RedirectionUrlValidationCallback;

                GetUserSettingsResponse response = service.GetUserSettings(this.TargetMailboxText.Text, System.Enum.GetValues(typeof(UserSettingName)) as UserSettingName[]);
                ErrorDialog.ShowInfo("Autodiscover completed successfully!  Check the EWSEditor Log Viewer for detailed output.");
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        public string AutodiscoverGetUserSettings(ref AutodiscoverService service, string sUserSmtpAddress)
        { 
            string sRet = string.Empty;

            try
            {
                GetUserSettingsResponse response = service.GetUserSettings(
                    sUserSmtpAddress,
                    System.Enum.GetValues(typeof(UserSettingName)) as UserSettingName[]);

                string sLine = string.Empty;

                // Display each retrieved value. The settings are part of a key value pair.
                string sValue = string.Empty;
                string sType = string.Empty;
                foreach (KeyValuePair<UserSettingName, Object> usersetting in response.Settings)
                {
                    sValue = string.Empty;

                    sType = usersetting.Value.ToString();
                    switch (sType)
                    {
                        case ("Microsoft.Exchange.WebServices.Autodiscover.WebClientUrlCollection"):
                            Microsoft.Exchange.WebServices.Autodiscover.WebClientUrlCollection oCollection1;
                            oCollection1 = (Microsoft.Exchange.WebServices.Autodiscover.WebClientUrlCollection)usersetting.Value;
                            foreach (WebClientUrl oUrl in oCollection1.Urls)
                            {
                                sValue = string.Format("\r\n    Url: {0} - Authentication: {1}\r\n", oUrl.Url, oUrl.AuthenticationMethods);
                            }
                            break;
                        case ("Microsoft.Exchange.WebServices.Autodiscover.ProtocolConnectionCollection"):
                            Microsoft.Exchange.WebServices.Autodiscover.ProtocolConnectionCollection oCollection2;
                            oCollection2 = (Microsoft.Exchange.WebServices.Autodiscover.ProtocolConnectionCollection)usersetting.Value;
                            foreach (ProtocolConnection oProtocolConnection in oCollection2.Connections)
                            {
                                sValue = string.Format("\r\n    Hostname: {0} - Port: {1} - EncryptionMethod: {2}\r\n", oProtocolConnection.Hostname, oProtocolConnection.Port, oProtocolConnection.EncryptionMethod);
                            }

                            break;
                        default:
                            sValue = string.Format("{0}\r\n", usersetting.Value.ToString());
                            break;


                    }
                    sLine = string.Format("{0}:               {1}", usersetting.Key.ToString(), sValue);

                    sRet += sLine;
                }

                sRet += "\r\n\r\n-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-\r\n\r\n";
                sRet += "Response Information: \r\n\r\n";
                sRet += "  Response Redirect Target: " + response.RedirectTarget + "\r\n";
                sRet += "  Response Errors: \r\n";
                sRet += "     ErrorCode: " + response.ErrorCode + "\r\n";
                sRet += "     ErrorMessage: " + response.ErrorMessage + "\r\n";
                sRet += "     Error on settings not returned:  \r\n";
                foreach (UserSettingError oError in response.UserSettingErrors)
                {
                    sRet += "Setting: " + oError.SettingName + "\r\n";
                    sRet += "   ErrorCode: " + oError.ErrorCode + "\r\n";
                    sRet += "   ErrorCode: " + oError.ErrorMessage + "\r\n";
                    sRet += "\r\n--\r\n";
                }
                sRet += "\r\n-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-\r\n\r\n";

            }
            catch (Exception ex)
            {

                sRet += "\r\n\r\n-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-\r\n\r\n";
                sRet += "Error thrown in code:\r\n\r\n";
                sRet += "    Error Message: " + ex.Message + "\r\n";
                sRet += "    Inner Error Message: " + ex.Message + "\r\n";
                sRet += "\r\n-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-\r\n";
            }

            return sRet;
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
        }
    }
}
