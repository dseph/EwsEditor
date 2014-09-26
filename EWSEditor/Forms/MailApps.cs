using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Exchange.WebServices.Data;
using EWSEditor.Common;
using EWSEditor.Exchange;

using System.Collections.ObjectModel;

namespace EWSEditor.Forms
{
    public partial class MailApps : Form
    {
        private ExchangeService _CurrentService = null;

        public MailApps()
        {
            InitializeComponent();
 
        }

        public MailApps(ExchangeService CurrentService)
        {
            InitializeComponent();

            _CurrentService = CurrentService;
        }

         
        private void Apps_Load(object sender, EventArgs e)
        {

        }

        private void btnGetAppsManifest_Click(object sender, EventArgs e)
        {
            System.Collections.ObjectModel.Collection<System.Xml.XmlDocument> oCollection = _CurrentService.GetAppManifests();
            string sInfo = string.Empty;
            StringBuilder oSB = new StringBuilder();

            foreach (System.Xml.XmlDocument xd in oCollection)
            {
                oSB.AppendLine("\r\n============================\r\n{0}");
                oSB.AppendLine(xd.OuterXml);
            }

            textBox1.Text = oSB.ToString();
        }

        private void btnInstallApp_Click(object sender, EventArgs e)
        {
            string sSelectedFile = string.Empty;

            if (UserIoHelper.PickLoadFromFile(Application.UserAppDataPath, "*.*", ref sSelectedFile, "All files (*.*)|*.*"))
            {
 
                byte[] baContents = System.IO.File.ReadAllBytes(sSelectedFile);
                System.IO.MemoryStream oStream = new System.IO.MemoryStream(baContents);
                _CurrentService.InstallApp(oStream);
 
            };
        }

        private void btnUninstallApp_Click(object sender, EventArgs e)
        {
            string sAppId = this.txtUninstallAppId.Text.Trim();
            _CurrentService.UninstallApp(sAppId);
        }

        private void btnDisableApp_Click(object sender, EventArgs e)
        {
            string sAppId = this.txtDisableAppId.Text.Trim();
            DisableReasonType oDisableReasonType = DisableReasonType.NoReason;

            switch (cmboDisableReason.Text.Trim())
            {
                case "NoReason":
                    oDisableReasonType = DisableReasonType.NoReason;
                    break;
                case "OutlookClientPerformance":
                    oDisableReasonType = DisableReasonType.OutlookClientPerformance;
                    break;
                case "OWAClientPerformance":
                    oDisableReasonType = DisableReasonType.OWAClientPerformance;
                    break;
                case "MobileClientPerformance":
                    oDisableReasonType = DisableReasonType.MobileClientPerformance;
                    break;
            }
             
            _CurrentService.DisableApp(sAppId, oDisableReasonType);
 
        }

        private void btsGetAppMarketplaceUrl_Click(object sender, EventArgs e)
        {
            txtAppMarketplaceUrl.Text = _CurrentService.GetAppMarketplaceUrl();
            
        }
    }
}
