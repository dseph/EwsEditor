using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Microsoft.Exchange.WebServices.Data;
using EWSEditor.Common;
using EWSEditor.Exchange;
using EWSEditor.Logging;
using EWSEditor.Resources;
using EWSEditor.Settings;

namespace EWSEditor.Forms
{
    public partial class UserConfigForm : CountedForm
    {
        public UserConfigForm()
        {
            InitializeComponent();
            SetForm();
        }

        private void UserConfigForm_Load(object sender, EventArgs e)
        {

        }

 
        private void SetForm()
        {
            LoadUserConfigIntoTreeView(CurrentService, ref treeView1);

        }

        public static void LoadUserConfigIntoTreeView(ExchangeService service, ref TreeView oTreeView)
        {

            oTreeView.Nodes.Clear();
            TreeNode oParentNode = oTreeView.Nodes.Add("User Config Settings");
            oParentNode.Tag = null;

            TreeNode oNode = null;

            oNode = oParentNode.Nodes.Add("OWA.UserOptions");
            oNode.Tag = null;
            LoadUserConfigIntoTreeViewNode(service, ref oNode, "OWA.UserOptions");

            oNode = oParentNode.Nodes.Add("OWA.UserOptions");
            oNode.Tag = null;
            LoadUserConfigIntoTreeViewNode(service, ref oNode, "OWA.UserOptions");

        }

        public static void EnumUserConfig(ExchangeService service, ref string UserSettings)
        {
            string sResult = string.Empty;
            Folder Root = Folder.Bind(service, WellKnownFolderName.Root);
            UserConfiguration OWAConfiguration = UserConfiguration.Bind(service,
                "OWA.UserOptions",
                Root.ParentFolderId,
                UserConfigurationProperties.All);

            IDictionaryEnumerator OWAEnum = (IDictionaryEnumerator)OWAConfiguration.Dictionary.GetEnumerator();
            while (OWAEnum.MoveNext())
            {
                sResult += "Key : " + OWAEnum.Key;
                sResult += "Value : " + OWAEnum.Value;
            }

            UserSettings = sResult;
        }

        public static void LoadUserConfigIntoTreeViewNode(ExchangeService service, ref TreeNode oNode, string sSettingsName)
        {
            Folder Root = Folder.Bind(service, WellKnownFolderName.Root);
            UserConfiguration OWAConfiguration = UserConfiguration.Bind(service,
                sSettingsName,
                Root.ParentFolderId,
                UserConfigurationProperties.All);

            TreeNode xNode = null;
            IDictionaryEnumerator OWAEnum = (IDictionaryEnumerator)OWAConfiguration.Dictionary.GetEnumerator();
            while (OWAEnum.MoveNext())
            {
                OWAEnum.Key.ToString();
                xNode = new TreeNode(OWAEnum.Key.ToString());
                xNode.Tag = OWAEnum.Value.ToString();
                oNode.Nodes.Add(xNode);
            }
        }


    }
}
