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
            }
            string sDefaultTimezone = TimeZone.CurrentTimeZone.StandardName;
            int SelectedTimezoneLength = GlobalSettings.SelectedTimeZoneId.Trim().Length;
            if (SelectedTimezoneLength == 0)
                this.cmboSelectedTimeZoneId.Text = sDefaultTimezone;
            else
                this.cmboSelectedTimeZoneId.Text = GlobalSettings.SelectedTimeZoneId; //TimeZone.CurrentTimeZone.DaylightName;
            this.chkOverrideTimezone.Checked = GlobalSettings.OverrideTimezone;
            this.cmboSelectedTimeZoneId.Enabled = this.chkOverrideTimezone.Checked;

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

            //if (rdoSpecifyProxySettings.Checked == false && chkOverrideProxyCredentials.Checked == false)
            //    rdoDontOverrideProxySettings.Checked = false;
            //else
            //    rdoDontOverrideProxySettings.Checked = true;

            SetCheckedProxyOverride();
            SetCheckedOverrideProxyCredentials();

        }

        private void SaveSettings()
        {
            GlobalSettings.UserAgent = this.cmboUserAgent.Text;

            GlobalSettings.ShouldSaveLogToFile = this.SaveLogFileCheck.Checked;
            GlobalSettings.LogFilePath = this.LogFilePathText.Text;

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

            //GlobalSettings.SetDefaultProxy = this.rdoGetAndSetDefaultProxy.Checked;
 
            GlobalSettings.SpecifyProxySettings = this.rdoSpecifyProxySettings.Checked;
            GlobalSettings.ProxyServerName =  this.txtProxyServerName.Text;
            GlobalSettings.ProxyServerPort = Convert.ToInt32(this.txtProxyServerPort.Text.Trim());
            GlobalSettings.BypassProxyForLocalAddress = this.chkBypassProxyForLocalAddress.Checked;

            GlobalSettings.OverrideProxyCredentials = this.chkOverrideProxyCredentials.Checked;
            GlobalSettings.ProxyServerUser = this.txtProxyServerUserName.Text;
            GlobalSettings.ProxyServerPassword = this.txtProxyServerPassword.Text;
            GlobalSettings.ProxyServerDomain = this.txtProxyServerDomain.Text; 
             
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

    }
}
