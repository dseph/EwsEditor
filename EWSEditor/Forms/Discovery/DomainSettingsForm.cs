using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EWSEditor.Forms.Controls;
using EWSEditor.Logging;
using EWSEditor.Settings;
using Microsoft.Exchange.WebServices.Autodiscover;
using Microsoft.Exchange.WebServices.Data;
using EWSEditor.Common;
using System.Net;
using System.DirectoryServices.AccountManagement;

namespace EWSEditor.Forms.Dialogs
{
    public partial class DomainSettingsForm : Form
    {
        private EnumComboBox<ExchangeVersion> exchangeVersionCombo = new EnumComboBox<ExchangeVersion>();

        public DomainSettingsForm()
        {
            InitializeComponent();
        }

        private void DomainSettingsForm_Load(object sender, EventArgs e)
        {
            this.exchangeVersionCombo.TransformComboBox(this.TempExchangeVersionCombo);
            this.exchangeVersionCombo.HasEmptyItem = true;
            this.exchangeVersionCombo.Text = "Exchange2010_SP2";

            // See AutodiscoverInfo.cs 
            // https://msdn.microsoft.com/en-us/library/ee625368(v=exchg.80).aspx
            // https://msdn.microsoft.com/en-us/library/office/gg274400(v=exchg.80).aspx

            // also see:
            //    https://msdn.microsoft.com/en-us/library/office/ff406195(v=exchg.150).aspx 
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

        private void btnDefaultUser_Click(object sender, EventArgs e)
        {
            txtUser.Text = UserPrincipal.Current.EmailAddress;
        }

        private void btnDefaultSmtp_Click(object sender, EventArgs e)
        {
            
        }

        private void GoRun_Click(object sender, EventArgs e)
        {
            bool bError = false;
            StringBuilder oSB = new StringBuilder();

            AutodiscoverService autodiscoverService = new AutodiscoverService(TargetMailDomain.Text.Trim(), this.exchangeVersionCombo.SelectedItem.Value);

            autodiscoverService.UseDefaultCredentials = this.chkDefaultWindowsCredentials.Checked;

            if (this.chkDefaultWindowsCredentials.Checked == false)
            {
                if (txtUser.Text.Trim().Length != 0 || txtUser.Text.Trim().Length != 0)
                {
                    if (txtDomain.Text.Trim().Length == 0)
                        autodiscoverService.Credentials = new NetworkCredential(txtUser.Text.Trim(), txtPassword.Text.Trim());
                    else
                        autodiscoverService.Credentials = new NetworkCredential(txtUser.Text.Trim(), txtPassword.Text.Trim(), txtDomain.Text.Trim());
                }
                else
                {
                    MessageBox.Show("Uer ID and Password need to be set at a mimum.");
                }
            }

            if (bError == false)
            {
                // Submit a request and get the settings. The response contains only the
                // settings that are requested, if they exist.
                GetDomainSettingsResponse domainresponse = autodiscoverService.GetDomainSettings(
                    TargetMailDomain.Text.Trim(),
                    this.exchangeVersionCombo.SelectedItem.Value,
                    DomainSettingName.ExternalEwsUrl,
                    DomainSettingName.ExternalEwsVersion);

                // Display each retrieved value. The settings are part of a key value pair.
                foreach (KeyValuePair<DomainSettingName, Object> domainsetting in domainresponse.Settings)
                {
                    oSB.AppendLine(domainsetting.Key.ToString() + ": " + domainsetting.Value.ToString());
                }
            }

            txtResults.Text = oSB.ToString();
 
        }


    }
}
