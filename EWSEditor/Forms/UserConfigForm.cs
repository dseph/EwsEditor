using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

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

        private ExchangeService _CurrentService = null;
        public UserConfigForm()
        {
            InitializeComponent();
        }

        public UserConfigForm(ExchangeService oExchangeService)
        {
            InitializeComponent();
            _CurrentService = oExchangeService;
            SetForm();
        }


        private void UserConfigForm_Load(object sender, EventArgs e)
        {
             
        }

 
        private void SetForm()
        {
            LoadUserConfigIntoTreeView(_CurrentService, ref treeView1);
        }

        public static void LoadUserConfigIntoTreeView(ExchangeService service, ref TreeView oTreeView)
        {

            oTreeView.Nodes.Clear();
            TreeNode oParentNode = oTreeView.Nodes.Add("User Config Settings");
            oParentNode.Tag = null;

            TreeNode oNode = null;

            Folder RootFolder = Folder.Bind(service, WellKnownFolderName.Root);

            oNode = oParentNode.Nodes.Add("OWA.UserOptions");
            oNode.Tag = null;
            LoadUserConfigIntoTreeViewNode(service, ref oNode, RootFolder.Id, "OWA.UserOptions");

 

            Folder CalendarFolder = Folder.Bind(service, WellKnownFolderName.Calendar);
              
            oNode = oParentNode.Nodes.Add("WellKnownFolderName.Calendar CategoryList");
            oNode.Tag = null;
            LoadUserConfigIntoTreeViewNodeCategoryList(service, ref oNode, CalendarFolder.Id, "CategoryList");

            oParentNode.ExpandAll();
 
        }
 

        public static void LoadUserConfigIntoTreeViewNode(ExchangeService service, ref TreeNode oNode, string sSettingsName)
        {
            Folder Root = Folder.Bind(service, WellKnownFolderName.Root);
            LoadUserConfigIntoTreeViewNode(service, ref  oNode, Root.ParentFolderId, sSettingsName);
        }

        public static void LoadUserConfigIntoTreeViewNode(ExchangeService service, ref TreeNode oNode, FolderId oFolderId, string sSettingsName)
        {
             

            UserConfiguration OWAConfiguration = UserConfiguration.Bind(service,
                sSettingsName,
                oFolderId,
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

        // Note: Accessing hidden folders such as the one for categories is not something which is considered supportable or advised by MS.
        public static void LoadUserConfigIntoTreeViewNodeCategoryList(ExchangeService service, ref TreeNode oNode, FolderId oFolderId, string sSettingsName)
        {


            UserConfiguration oUserConfiguration = UserConfiguration.Bind(service,
                sSettingsName,
                oFolderId,
                UserConfigurationProperties.XmlData);
 
            TreeNode xNode = null;
            xNode = new TreeNode("XmlData");
            xNode.Tag = Encoding.UTF8.GetString(oUserConfiguration.XmlData);
            oNode.Nodes.Add(xNode);
 
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            txtValue.Text = (string)treeView1.SelectedNode.Tag;
        }
       

    }
}
