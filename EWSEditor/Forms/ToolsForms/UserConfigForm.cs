// UserConfigForm.cs

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

            this.Cursor = Cursors.WaitCursor;

            oTreeView.Nodes.Clear();
             _ParentNode = oTreeView.Nodes.Add("User Config Settings");
             _ParentNode.Tag = null;
             string sError = string.Empty;

            //TreeNode oNode = null;

             TryLoadSettings(service, WellKnownFolderName.Root, ref _ParentNode, "OWA.UserOptions (WellKnownFolderName.Root)", "OWA.UserOptions", ref sError);
             TryLoadSettings(service, WellKnownFolderName.Root, ref _ParentNode, "OWA.OtherMailbox (WellKnownFolderName.Root)", "OWA.OtherMailbox", ref sError);
             TryLoadSettings(service, WellKnownFolderName.Root, ref _ParentNode, "OWA.AutocompleteCache (WellKnownFolderName.Root)", "OWA.AutocompleteCache", ref sError);
             TryLoadSettings(service, WellKnownFolderName.Root, ref _ParentNode, "OWA.SendFromCache (WellKnownFolderName.Root)", "OWA.SendFromCache", ref sError);
             TryLoadSettings(service, WellKnownFolderName.Root, ref _ParentNode, "WellKnownFolderName.Root - OWA.ViewStateConfiguration (WellKnownFolderName.Root)", "OWA.ViewStateConfiguration", ref sError);

             TryLoadSettings(service, WellKnownFolderName.Root, ref _ParentNode, "TargetFolderMRU (WellKnownFolderName.Root)", " ", ref sError);

             TryLoadSettings(service, WellKnownFolderName.Calendar, ref _ParentNode, "Calendar (WellKnownFolderName.Calendar)", "Calendar", ref sError);
             TryLoadSettings(service, WellKnownFolderName.Calendar, ref _ParentNode, "CategoryList (WellKnownFolderName.Calendar)", "CategoryList", ref sError);
             TryLoadSettings(service, WellKnownFolderName.Calendar, ref _ParentNode, "BookInPolicy (WellKnownFolderName.Calendar)", "BookInPolicy", ref sError);
             TryLoadSettings(service, WellKnownFolderName.Calendar, ref _ParentNode, "RequestInPolicy (WellKnownFolderName.Calendar)", "RequestInPolicy ", ref sError);
             TryLoadSettings(service, WellKnownFolderName.Calendar, ref _ParentNode, "RequestOutofPolicy (WellKnownFolderName.Calendar)", "RequestOutofPolicy ", ref sError);
             TryLoadSettings(service, WellKnownFolderName.Calendar, ref _ParentNode, "WorkHours (WellKnownFolderName.Calendar)", "WorkHours", ref sError);


             
            _ParentNode.ExpandAll();

            this.Cursor = Cursors.Default;
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
                oService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.
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
            service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.
            Folder Root = Folder.Bind(service, WellKnownFolderName.Root);
            LoadUserConfigIntoTreeViewNode(service, ref  oNode, Root.ParentFolderId, sSettingsName);
        }

        public void LoadUserConfigIntoTreeViewNode(ExchangeService service, ref TreeNode oNode, FolderId oFolderId, string sSettingsName)
        {
            //bool bFound = false;
 

            service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.
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
                //bFound = true;
            }


        }

        // Note: Accessing hidden folders such as the one for categories is not something which is considered supportable or advised by MS.
        public void LoadUserConfigIntoTreeViewNodeCategoryList(ExchangeService service, ref TreeNode oNode, FolderId oFolderId, string sSettingsName)
        {
            service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.
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

            FolderIdDialog oForm = new FolderIdDialog(this.CurrentService);
            oForm.ShowDialog();
            if (oForm.ChoseOK == true)
            {
                txtFolderId.Text = PropertyInformation.TypeValues.FolderIdTypeValue.GetValue(oForm.ChosenFolderId, true);
                
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


       
        //http://stackoverflow.com/questions/20473013/available-userconfigurationname-names-for-getuserconfiguration-for-distinguished

        //    DistinguishedFolderId   Calendar:
        //        IPM.Configuration.Calendar, 
        //        IPM.Configuration.CategoryList 
        //      IPM.Configuration.WorkHours  

        //      DistinguishedFolderId "root"
        //        IPM.Configuration.TargetFolderMRU 
        //        IPM.Configuration.OWA.ViewStateConfiguration  
        //        IPM.Configuration.OWA.UserOptions  
  
        //http://gsexdev.blogspot.com/2014/02/adding-additionalshared-mailbox-to-owa.html 

        //    OWA.OtherMailbox 

        //https://blogs.msdn.microsoft.com/deva/2014/08/21/mapi-how-to-programmatically-get-autocomplete-cacheentries-for-owa-2013/
        //    OWA.AutocompleteCache 

        //https://social.technet.microsoft.com/Forums/exchange/en-US/1f18ea4a-5a9d-46c9-a0c8-5ce19143e106/exchange-2010-owa-purge-send-as-list?forum=exchangesvrclientslegacy
        //    OWA.SendFromCache  ... dont know...

        // http://www.msexchange.org/articles-tutorials/exchange-server-2007/management-administration/managing-resource-mailboxes-exchange-server-2007-part2-.html
    }
}
