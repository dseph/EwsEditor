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
        private TreeNode _ParentNode = null;
        private FolderId _ChosenFolderId = null;

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

        public void LoadUserConfigIntoTreeView(ExchangeService service, ref TreeView oTreeView)
        {

            oTreeView.Nodes.Clear();
             _ParentNode = oTreeView.Nodes.Add("User Config Settings");
             _ParentNode.Tag = null;
             string sError = string.Empty;

            //TreeNode oNode = null;

             TryLoadSettings(service, WellKnownFolderName.Root, ref _ParentNode, "OWA.UserOptions", "OWA.UserOptions", ref sError);
             TryLoadSettings(service, WellKnownFolderName.Calendar, ref _ParentNode, "WellKnownFolderName.Calendar CategoryList", "CategoryList", ref sError);
//             TryLoadSettings(service, WellKnownFolderName.Calendar, ref _ParentNode, "WellKnownFolderName.Calendar BookInPolicy", "BookInPolicy", ref sError);

            //try
            //{
            //    Folder RootFolder = Folder.Bind(service, WellKnownFolderName.Root);
            //    oNode = oParentNode.Nodes.Add("OWA.UserOptions");
            //    oNode.Tag = null;
            //    LoadUserConfigIntoTreeViewNode(service, ref oNode, RootFolder.Id, "OWA.UserOptions");
            //}  
            //catch (Exception ex)
            //{
            //    System.Diagnostics.Debug.WriteLine("Error: " + ex.Message.ToString());
            //}

            //try
            //{
            //    Folder CalendarFolder = Folder.Bind(service, WellKnownFolderName.Calendar);
            //    oNode = oParentNode.Nodes.Add("WellKnownFolderName.Calendar CategoryList");
            //    oNode.Tag = null;
            //    LoadUserConfigIntoTreeViewNodeCategoryList(service, ref oNode, CalendarFolder.Id, "CategoryList");
            //}
            //catch (Exception ex)
            //{
            //    System.Diagnostics.Debug.WriteLine("Error: " + ex.Message.ToString());
            //}

            ////Folder CalendarFolderBookInPolicy = Folder.Bind(service, WellKnownFolderName.Calendar);
            ////oNode = oParentNode.Nodes.Add("WellKnownFolderName.Calendar BookInPolicy");
            ////oNode.Tag = null;
            ////LoadUserConfigIntoTreeViewNodeCategoryList(service, ref oNode, CalendarFolderBookInPolicy.Id, "BookInPolicy");

            _ParentNode.ExpandAll();
 
        }

        public TreeNode TryLoadSettings(
            ExchangeService oService, 
            FolderId oFolderId,
            ref TreeNode oParentNode, 
            string sStartingNodeName,
            string sOptionsToLoad,
            ref string sError)
        {
            //bool bRet = true;
            TreeNode oNode = null;

            try
            {
                Folder RootFolder = Folder.Bind(oService, oFolderId);
                oNode = oParentNode.Nodes.Add(sStartingNodeName);
                oNode.Tag = null;
                LoadUserConfigIntoTreeViewNode(oService, ref oNode, RootFolder.Id, sOptionsToLoad);
                //bRet = true;
            }
            catch (Exception ex)
            {
                sError = "Error loading '" + sOptionsToLoad + "': " + ex.Message.ToString();
                System.Diagnostics.Debug.WriteLine(sError);
                //bRet = false;
            }
            return oNode;
        }
 

        public void LoadUserConfigIntoTreeViewNode(ExchangeService service, ref TreeNode oNode, string sSettingsName)
        {
            Folder Root = Folder.Bind(service, WellKnownFolderName.Root);
            LoadUserConfigIntoTreeViewNode(service, ref  oNode, Root.ParentFolderId, sSettingsName);
        }

        public void LoadUserConfigIntoTreeViewNode(ExchangeService service, ref TreeNode oNode, FolderId oFolderId, string sSettingsName)
        {
            bool bFound = false;

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
                if (OWAEnum.Value != null)
                    xNode.Tag = OWAEnum.Value.ToString();
                else
                    xNode.Tag = "";  
                oNode.Nodes.Add(xNode);
                bFound = true;
            }

            if (bFound == false)
                oNode.ForeColor = Color.Gray;

        }

        // Note: Accessing hidden folders such as the one for categories is not something which is considered supportable or advised by MS.
        public void LoadUserConfigIntoTreeViewNodeCategoryList(ExchangeService service, ref TreeNode oNode, FolderId oFolderId, string sSettingsName)
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnGetFolderId_Click(object sender, EventArgs e)
        {
            FolderId folderId = null;
            if (Forms.FolderIdDialog.ShowDialog(ref folderId) == DialogResult.OK)
            {
               // SetAndDisplayFolderId(folderId);
                _ChosenFolderId = folderId;
                txtFolderId.Text = PropertyInformation.TypeValues.FolderIdTypeValue.GetValue(folderId, true);
  
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string sUserId = txtUserSetting.Text.Trim();
            string sError = string.Empty;
            if (_ChosenFolderId == null || sUserId.Length == 0)
            {
                MessageBox.Show("Select a folder and enter a UserConfig setting before clicking 'Load'.");
            }
            else
            {
                TreeNode oTreeNode = null;
                oTreeNode = TryLoadSettings(_CurrentService, _ChosenFolderId, ref _ParentNode, sUserId, sUserId, ref sError);
                //if (oTreeNode == null)
                //    MessageBox.Show("Could not load settings.");
                if (sError != string.Empty)
                {
                    MessageBox.Show(sError , "Settings could not be pulled.") ;
                }
                else
                {
                    oTreeNode.ExpandAll();
                    oTreeNode.EnsureVisible();
                }
            }
        }
       

    }
}
