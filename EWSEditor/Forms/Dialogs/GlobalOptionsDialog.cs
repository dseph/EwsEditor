using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EWSEditor.Settings;

namespace EWSEditor.Forms
{
    public partial class OptionsDialog : BaseForm
    {
        private static OptionsDialog currentDialog = null;

        public static new void ShowDialog()
        {
            if (currentDialog == null)
            {
                currentDialog = new OptionsDialog();
                ((Form)currentDialog).ShowDialog();
                currentDialog = null;
            }
            else
            {
                currentDialog.BringToFront();
            }
        }

        public OptionsDialog()
        {
            InitializeComponent();
        }

        private void MyCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OptionsDialog_Load(object sender, EventArgs e)
        {

            cmboUserAgent.Items.Clear();
            EWSEditor.Common.UserAgentHelper.AddUserAgentsToComboBox(ref cmboUserAgent);

            LoadSettings();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            SaveSettings();
            this.Close();
        }

        // Load global options 
        private void LoadSettings()
        {
            cmboUserAgent.Items.Clear();
            //cmboUserAgent.Items.Add(oTempService.UserAgent);
            EWSEditor.Common.UserAgentHelper.AddUserAgentsToComboBox(ref cmboUserAgent);
 
            this.cmboUserAgent.Text = GlobalSettings.UserAgent;

            this.SaveLogFileCheck.Checked = GlobalSettings.ShouldSaveLogToFile;
            this.LogFilePathText.Text = GlobalSettings.LogFilePath;

            this.chkLogSecurityToken.Checked  = GlobalSettings.LogSecurityToken;

            this.CalendarViewText.Text = GlobalSettings.CalendarViewSize.ToString();
            this.FindFolderText.Text = GlobalSettings.FindFolderViewSize.ToString();
            this.FindItemText.Text = GlobalSettings.FindItemViewSize.ToString();
            this.DumpFolderText.Text = GlobalSettings.DumpFolderViewSize.ToString();

            this.OverrideSslCheck.Checked = GlobalSettings.OverrideCertValidation;
            this.EnableSslDetailCheck.Checked = GlobalSettings.EnableSslDetailLogging;
            this.AllowRedirectsCheck.Checked = GlobalSettings.AllowAutodiscoverRedirect;
            this.EnableScpLookups.Checked = GlobalSettings.EnableScpLookups;
            this.PreAuthenticate.Checked = GlobalSettings.PreAuthenticate;

            this.chkOverrideTimeout.Checked = GlobalSettings.OverrideTimeout;
            this.numericUpDownTimeout.Value = GlobalSettings.Timeout;

            foreach (TimeZoneInfo tzinfo in TimeZoneInfo.GetSystemTimeZones())
            {
                this.cmboSelectedTimeZoneId.Items.Add(tzinfo.Id);
                this.cmboSelectedTimeZoneContextId.Items.Add(tzinfo.Id);
            }

            string sDefaultTimezone = TimeZone.CurrentTimeZone.StandardName;

            int SelectedTimezoneLength = GlobalSettings.SelectedTimeZoneId.Trim().Length;
            if (SelectedTimezoneLength == 0)
                this.cmboSelectedTimeZoneId.Text = sDefaultTimezone;
            else
                this.cmboSelectedTimeZoneId.Text = GlobalSettings.SelectedTimeZoneId; //TimeZone.CurrentTimeZone.DaylightName;
            this.chkOverrideTimezone.Checked = GlobalSettings.OverrideTimezone;
            this.cmboSelectedTimeZoneId.Enabled = this.chkOverrideTimezone.Checked;

            int SelectedTimezoneContextLength = GlobalSettings.SelectedTimeZoneContextId.Trim().Length;
            if (SelectedTimezoneContextLength == 0)
                this.cmboSelectedTimeZoneContextId.Text = sDefaultTimezone;
            else
                this.cmboSelectedTimeZoneContextId.Text = GlobalSettings.SelectedTimeZoneContextId; //TimeZone.CurrentTimeZone.DaylightName;
            this.chkAddTimeZoneContext.Checked = GlobalSettings.AddTimeZoneContext;
            this.cmboSelectedTimeZoneContextId.Enabled = this.chkAddTimeZoneContext.Checked;

            this.rdoDontOverrideProxySettings.Checked = true; // Default

            //if (GlobalSettings.SetDefaultProxy == true)
            //    this.rdoGetAndSetDefaultProxy.Checked = true;

            if (GlobalSettings.SpecifyProxySettings == true)
                this.rdoSpecifyProxySettings.Checked = true;
            this.txtProxyServerName.Text = GlobalSettings.ProxyServerName;
            this.txtProxyServerPort.Text = GlobalSettings.ProxyServerPort.ToString();
            this.chkBypassProxyForLocalAddress.Checked = GlobalSettings.BypassProxyForLocalAddress;
             
            this.chkOverrideProxyCredentials.Checked = GlobalSettings.OverrideProxyCredentials;
            this.txtProxyServerUserName.Text = GlobalSettings.ProxyServerUser;
            this.txtProxyServerPassword.Text = GlobalSettings.ProxyServerPassword;
            this.txtProxyServerDomain.Text = GlobalSettings.ProxyServerDomain;

            this.chkAdditionalHeader1.Checked = GlobalSettings.EnableAdditionalHeader1;
            this.txtAdditionalHeader1.Text = GlobalSettings.AdditionalHeader1;
            this.txtAdditionalHeaderValue1.Text = GlobalSettings.AdditionalHeaderValue1;
            this.chkAdditionalHeader2.Checked = GlobalSettings.EnableAdditionalHeader2;
            this.txtAdditionalHeader2.Text = GlobalSettings.AdditionalHeader2;
            this.txtAdditionalHeaderValue2.Text = GlobalSettings.AdditionalHeaderValue2;
            this.chkAdditionalHeader3.Checked = GlobalSettings.EnableAdditionalHeader3;
            this.txtAdditionalHeader3.Text = GlobalSettings.AdditionalHeader3;
            this.txtAdditionalHeaderValue3.Text = GlobalSettings.AdditionalHeaderValue3;


            //if (rdoSpecifyProxySettings.Checked == false && chkOverrideProxyCredentials.Checked == false)
            //    rdoDontOverrideProxySettings.Checked = false;
            //else
            //    rdoDontOverrideProxySettings.Checked = true;

            SetCheckedProxyOverride();
            SetCheckedOverrideProxyCredentials();
            SetCheckedAdditionalHeaders();
             

        }

        private void SaveSettings()
        {
            GlobalSettings.UserAgent = this.cmboUserAgent.Text;

            GlobalSettings.ShouldSaveLogToFile = this.SaveLogFileCheck.Checked;
            GlobalSettings.LogFilePath = this.LogFilePathText.Text;

            GlobalSettings.LogSecurityToken = this.chkLogSecurityToken.Checked;


            GlobalSettings.CalendarViewSize = Convert.ToInt32(this.CalendarViewText.Text);
            GlobalSettings.FindFolderViewSize = Convert.ToInt32(this.FindFolderText.Text);
            GlobalSettings.FindItemViewSize = Convert.ToInt32(this.FindItemText.Text);
            GlobalSettings.DumpFolderViewSize = Convert.ToInt32(this.DumpFolderText.Text);

            GlobalSettings.OverrideCertValidation = this.OverrideSslCheck.Checked;
            GlobalSettings.EnableSslDetailLogging = this.EnableSslDetailCheck.Checked;
            GlobalSettings.AllowAutodiscoverRedirect = this.AllowRedirectsCheck.Checked;
            GlobalSettings.EnableScpLookups = this.EnableScpLookups.Checked;
            GlobalSettings.PreAuthenticate = this.PreAuthenticate.Checked;

            GlobalSettings.OverrideTimeout = this.chkOverrideTimeout.Checked;
            GlobalSettings.Timeout = (int)this.numericUpDownTimeout.Value;

            GlobalSettings.OverrideTimezone = this.chkOverrideTimezone.Checked;
            GlobalSettings.SelectedTimeZoneId = this.cmboSelectedTimeZoneId.Text;

            GlobalSettings.AddTimeZoneContext = this.chkAddTimeZoneContext.Checked;
            GlobalSettings.SelectedTimeZoneContextId = this.cmboSelectedTimeZoneContextId.Text;

            //GlobalSettings.SetDefaultProxy = this.rdoGetAndSetDefaultProxy.Checked;
 
            GlobalSettings.SpecifyProxySettings = this.rdoSpecifyProxySettings.Checked;
            GlobalSettings.ProxyServerName =  this.txtProxyServerName.Text;
            GlobalSettings.ProxyServerPort = Convert.ToInt32(this.txtProxyServerPort.Text.Trim());
            GlobalSettings.BypassProxyForLocalAddress = this.chkBypassProxyForLocalAddress.Checked;

            GlobalSettings.OverrideProxyCredentials = this.chkOverrideProxyCredentials.Checked;
            GlobalSettings.ProxyServerUser = this.txtProxyServerUserName.Text;
            GlobalSettings.ProxyServerPassword = this.txtProxyServerPassword.Text;
            GlobalSettings.ProxyServerDomain = this.txtProxyServerDomain.Text;

            GlobalSettings.EnableAdditionalHeader1= this.chkAdditionalHeader1.Checked;
            GlobalSettings.AdditionalHeader1 = this.txtAdditionalHeader1.Text;
            GlobalSettings.AdditionalHeaderValue1= this.txtAdditionalHeaderValue1.Text;
            GlobalSettings.EnableAdditionalHeader2 =this.chkAdditionalHeader2.Checked;
            GlobalSettings.AdditionalHeader2 =this.txtAdditionalHeader2.Text; 
            GlobalSettings.AdditionalHeaderValue2 =this.txtAdditionalHeaderValue2.Text;
            GlobalSettings.EnableAdditionalHeader3 =this.chkAdditionalHeader3.Checked; 
            GlobalSettings.AdditionalHeader3 = this.txtAdditionalHeader3.Text;
            GlobalSettings.AdditionalHeaderValue3 = this.txtAdditionalHeaderValue3.Text; 


             
        }

        private void EnableScpLookups_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void MiscSettingsGroup_Enter(object sender, EventArgs e)
        {

        }

        private void chkUseSpecifiedTimezone_CheckedChanged(object sender, EventArgs e)
        {
             
        }

        private void chkOverrideTimezone_CheckedChanged(object sender, EventArgs e)
        {
            this.cmboSelectedTimeZoneId.Enabled = this.chkOverrideTimezone.Checked;


        }

        private void SaveLogFileCheck_CheckedChanged(object sender, EventArgs e)
        {
            this.LogFilePathText.Enabled = this.SaveLogFileCheck.Checked;
        }

        private void SetCheckedProxyOverride()
        {
            bool bState = this.rdoSpecifyProxySettings.Checked;
            this.txtProxyServerName.Enabled = bState;
            this.txtProxyServerPort.Enabled = bState;
            this.chkOverrideProxyCredentials.Enabled = bState;
            this.chkBypassProxyForLocalAddress.Enabled = bState;

            SetCheckedOverrideProxyCredentials();
 
        }

        private void SetCheckedAdditionalHeaders()
        {
            txtAdditionalHeader1.Enabled = chkAdditionalHeader1.Checked;
            txtAdditionalHeaderValue1.Enabled = chkAdditionalHeader1.Checked;

            txtAdditionalHeader2.Enabled = chkAdditionalHeader2.Checked;
            txtAdditionalHeaderValue2.Enabled = chkAdditionalHeader2.Checked;

            txtAdditionalHeader3.Enabled = chkAdditionalHeader3.Checked;
            txtAdditionalHeaderValue3.Enabled = chkAdditionalHeader3.Checked;

        }

        private void chkOverrideProxyServerDefaults_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckedProxyOverride();
        }

        private void chkOverrideProxyCredentials_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckedOverrideProxyCredentials();

        }

        private void SetCheckedOverrideProxyCredentials()
        {
            bool bState = false;
       
            if (this.rdoSpecifyProxySettings.Checked == true)
                if (this.chkOverrideProxyCredentials.Checked == true)
                    bState = true;

             
            this.txtProxyServerUserName.Enabled = bState;
            this.txtProxyServerPassword.Enabled = bState;
            this.txtProxyServerDomain.Enabled = bState;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void rdoSpecifyProxySettings_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckedProxyOverride();
        }

        private void rdoDontOverrideProxySettings_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckedProxyOverride();
        }

        private void rdoGetAndSetDefaultProxy_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckedProxyOverride();
        }

        private void UserAgentText_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkAddTimeZoneContext_CheckedChanged(object sender, EventArgs e)
        {
            this.cmboSelectedTimeZoneContextId.Enabled = this.chkAddTimeZoneContext.Checked;
        }

        private void OverrideSslCheck_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cmboSelectedTimeZoneContextId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chkAdditionalHeader1_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckedAdditionalHeaders();
        }

        private void chkAdditionalHeader2_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckedAdditionalHeaders();
        }

        private void chkAdditionalHeader3_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckedAdditionalHeaders();
        }

        private void txtProxyServerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void DumpFolderLabel_Click(object sender, EventArgs e)
        {

        }

        private void FindItemText_TextChanged(object sender, EventArgs e)
        {

        }

        private void FindFolderText_TextChanged(object sender, EventArgs e)
        {

        }

        private void CalendarViewText_TextChanged(object sender, EventArgs e)
        {

        }

        private void DumpFolderText_TextChanged(object sender, EventArgs e)
        {

        }

        private void FindItemLabel_Click(object sender, EventArgs e)
        {

        }

        private void FindFolderLabel_Click(object sender, EventArgs e)
        {

        }

        private void CalendarViewLabel_Click(object sender, EventArgs e)
        {

        }

    }
}
