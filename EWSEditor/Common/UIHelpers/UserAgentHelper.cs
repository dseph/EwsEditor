// UserAgentHeaders.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EWSEditor.Common
{
    public class UserAgentHelper
    {
        public static void AddUserAgentsToComboBox(ref ComboBox oComboBox)
        {
            string sCurrentVersion = Application.ProductName + " " + Application.ProductVersion;
            
            oComboBox.Items.Add(sCurrentVersion);
            oComboBox.Items.Add("EwsEditor");
            oComboBox.Items.Add("");            
            oComboBox.Items.Add("Microsoft Office/15.0 (Windows NT 6.1; Microsoft Outlook 15.0.4551; Pro)");
            oComboBox.Items.Add("Microsoft Office/14.0 (Windows NT 5.1; Microsoft Outlook 14.0.4536; Pro; MSOffice 14)");
            oComboBox.Items.Add("Microsoft Office/14.0 (Windows NT 6.1; Microsoft Outlook 14.0.5128; Pro)");
            oComboBox.Items.Add("Microsoft Office/12.0 (Windows NT 6.1; Microsoft Office Word 12.0.6425; Pro)");
            oComboBox.Items.Add("Microsoft Office/12.0 (Windows NT 5.1; Microsoft Office Outlook 12.0.6554; Pro)");
            oComboBox.Items.Add("Microsoft Office/12.0 (Windows NT 5.2; Pro)");
            oComboBox.Items.Add("MacOutlook/14.2.0.101115 (Intel Mac OS X 10.6.7)");
            oComboBox.Items.Add("MOWAHost-iPhone/929.19 CFNetwork/672.1.14 Darwin/14.0.0");

            oComboBox.Text = sCurrentVersion;

        }
    }
}
