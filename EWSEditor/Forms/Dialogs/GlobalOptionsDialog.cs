﻿using System;
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
            this.UserAgentText.Text = GlobalSettings.UserAgent;

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
        }

        private void SaveSettings()
        {
            GlobalSettings.UserAgent = this.UserAgentText.Text;

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
    }
}
