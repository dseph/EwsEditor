using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using EWSEditor.Common.Extensions;
using EWSEditor.Common.ServiceProfiles;
using EWSEditor.Logging;
using EWSEditor.PropertyInformation;
using EWSEditor.Resources;
using EWSEditor.Settings;
using Microsoft.Exchange.WebServices.Data;
using EWSEditor.Exchange;
using EWSEditor.Common;

namespace EWSEditor.Forms.Dialogs
{
    public partial class SelectFolder : Form
    {
        public bool ChoseOK = false;
        public FolderId ChosenFolderId = null;
        public FolderId RootFolderId = null;
        private ExchangeService _ExchangeService = null;
        private PropertySet folderNodePropertySet = new PropertySet(BasePropertySet.FirstClassProperties);

        public SelectFolder()
        {
            InitializeComponent();
        }

        public SelectFolder(ExchangeService oExchangeService, FolderId oFolderId)
        {
            InitializeComponent();

            _ExchangeService = oExchangeService;
            RootFolderId = oFolderId;
        }

        private void FolderTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            FolderId x = null;
           // x = (FolderId)FolderTreeView.SelectedNode.Tag;
             ChosenFolderId = (FolderId)FolderTreeView.SelectedNode.Tag;
            
           // ChosenFolderId = new FolderId(sFolderId);

            if (e.Node.Tag != null)
            {
                this.Cursor = Cursors.WaitCursor;
                ChosenFolderId = (FolderId)FolderTreeView.SelectedNode.Tag;
                this.Cursor = Cursors.Default;
            }
            else
                ChosenFolderId = string.Empty;
 
        }


        private TreeNode AddRootFolderToTreeView(ExchangeService oExchangeService, FolderId StartingFolderId)
        {
            Folder oUseFolder = null;
            TreeNode oParentTreeNode = null;

            try
            {
                oUseFolder = Folder.Bind(
                    oExchangeService,
                    StartingFolderId,
                     BasePropertySet.FirstClassProperties);
              

                string nodeText = string.Empty;
                string nodeToolTip = string.Empty;

                oParentTreeNode = null;
                oParentTreeNode = FolderTreeView.Nodes.Add("WellKnownFolderName.Root");
                oParentTreeNode.Tag = oUseFolder.Id;
                oParentTreeNode.ImageIndex = 1;


                AddFolderToTreeNode(oExchangeService, ref oParentTreeNode, oUseFolder.Id);

                oParentTreeNode.Expand();

                //AddFolderToTreeNode(ExchangeService oExchangeService, ref TreeNode oNode, FolderId oFolder)
 
                oUseFolder = null;

                //FolderTreeView.SelectedNode = oParentTreeNode;
 

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
 
            return oParentTreeNode;
        }

 
        private void AddFoldersToTreeView(ref TreeNode oTreeNode, bool bAlwayExpand)
        {
            FolderId oFolderId = null;

            try
            {
                int iNodes = oTreeNode.GetNodeCount(false);
                bool bAddNodes = false;

                if ((iNodes == 1) && (oTreeNode.Nodes[0].Text == ""))
                    bAddNodes = true;
                else
                    bAddNodes = false;

                if (bAlwayExpand == true)
                    bAddNodes = true;

                if (bAddNodes == true)
                {
                    oTreeNode.Nodes[0].Remove();
                    oFolderId = (FolderId)oTreeNode.Tag;
                    //oTreeNode.index
                    TreeNode oNode = oTreeNode;
                    oNode.ImageIndex = 1;
                    AddFolderToTreeNode(_ExchangeService, ref oNode, oFolderId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Unable to expand the list {0}: {1}", oTreeNode.FullPath, ex.ToString()));
            }

        }

        public bool AddFolderToTreeNode(ExchangeService oExchangeService, ref TreeNode oNode, FolderId oFolder)
        {
            bool bRet = false;
            try
            {
                FolderView oView = new FolderView(9999);
                

                Folder folder = Folder.Bind(oExchangeService, oFolder);
                FindFoldersResults oResults = null;
                oResults = folder.FindFolders(oView);
                TreeNode xNode = null;
                foreach (Folder o in oResults)
                {
                    xNode = new TreeNode(o.DisplayName);
                    xNode.Tag = o.Id;
                    xNode.ImageIndex = 1;
                    //xNode.Tag = new FolderTag(o.Id, o.FolderClass);
                    oNode.Nodes.Add(xNode);
                    if (o.ChildFolderCount > 0 )
                        xNode.Nodes.Add("");

                   

                    if (o.DisplayName == "Top of Information Store")
                    {
 
                        FolderTreeView.SelectedNode = xNode;
                        xNode.Expand();
                    }

                    xNode = null;
                }
                folder = null;
                oResults = null;
                xNode = null;
                oView = null;
                bRet = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Reading Folder");
                bRet = false;
            }
            return bRet;
        }

        private void FolderTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            TreeNode oTreeNode = e.Node;

            AddFoldersToTreeView(ref oTreeNode, false);
            oTreeNode = null;

            this.Cursor = Cursors.Default;

        }

        private void FolderTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.FolderTreeView.SelectedNode != e.Node)
                {
                    this.FolderTreeView.SelectedNode = e.Node;
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void FolderTreeView_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
 
        }

        private void FolderTreeView_Click(object sender, EventArgs e)
        {
        
 
        }

        private void SelectFolder_Load(object sender, EventArgs e)
        {
            TreeNode oParentTreeNode = AddRootFolderToTreeView(_ExchangeService, RootFolderId);

            AddFoldersToTreeView(ref oParentTreeNode, true);

            //AddFolderToTreeNode(ExchangeService oExchangeService, ref TreeNode, FolderId oFolder)
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ChoseOK = true;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ChoseOK = false;
            Close();
        }
    }
}
