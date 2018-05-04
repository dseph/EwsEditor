using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using EWSEditor.Common;
using EWSEditor.Common.Extensions;
using EWSEditor.Resources;
using Microsoft.Exchange.WebServices.Data;
using System.Net;
using System.Xml;

namespace EWSEditor.Forms 
{

 

    public partial class SearchFolders : Form
    {
        public bool ChoseOK = false;
        private ExchangeService _CurrentService = null;
        private FolderId _CurrentFolderId = null;
        private PropertySet _CurrentDetailPropertySet;

        private static ExtendedPropertyDefinition Prop_PR_FOLDER_PATH = new ExtendedPropertyDefinition(0x66B5, MapiPropertyType.String);   // Folder Path - PR_Folder_Path
        private static ExtendedPropertyDefinition Prop_PR_IS_HIDDEN = new ExtendedPropertyDefinition(0x10f4, MapiPropertyType.Boolean);


        public SearchFolders()
        {
            InitializeComponent();
        }

        public SearchFolders(ExchangeService oExchangeService, FolderId oCurrentFolderId, PropertySet CurrentDetailPropertySet)
        {
            _CurrentService = oExchangeService;
            _CurrentFolderId = oCurrentFolderId;
            _CurrentDetailPropertySet = CurrentDetailPropertySet;

            InitializeComponent();
 
        }


        private void SearchFolders_Load(object sender, EventArgs e)
        {
            cmboSearchType.Text = "More Available";
            cmboSearchDepth.Text = "Shallow";

            cmboClassConditional.Text = "ContainsSubstring";
            cmboDisplayNameConditional.Text = "ContainsSubstring";

            cmboLogicalOperation.Text = "And";


            SetCheckboxes();
        }

            


        private void SetCheckboxes()
        {
          

            this.chkDisplayName.Enabled = true;
            this.chkClass.Enabled = true;
            this.txtDisplayName.Enabled = true;
            this.txtClass.Enabled = true;

            this.txtDisplayName.Enabled = chkDisplayName.Checked;
            this.txtClass.Enabled = chkClass.Checked;


        }

        private bool CheckFields()
        {
            bool bRet = true;
            if (this.chkDisplayName.Checked == true)
                if (this.txtDisplayName.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Subject line text cannot be blank");
                }


            if (this.chkClass.Checked == true)
                if (this.txtClass.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Class line text cannot be blank");
                }

             

            return bRet;

        }

        private void rdoAqsSearch_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckboxes();
        }

        private void rdoFindItemSearch_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void chkSubject_CheckedChanged(object sender, EventArgs e)
        {
            this.txtDisplayName.Enabled = this.chkDisplayName.Checked;
            this.cmboDisplayNameConditional.Enabled = this.chkDisplayName.Checked;
        }

        private void chkTo_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void chkCC_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void chkClass_CheckedChanged(object sender, EventArgs e)
        {
            this.txtClass.Enabled = this.chkClass.Checked;
            this.cmboClassConditional.Enabled = this.chkClass.Checked;
        }

        private void cmboSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int iPageSize = 100;
            iPageSize = (int)this.numPageSize.Value;
            this.Cursor = Cursors.WaitCursor;
            ProcessSearch(_CurrentFolderId, iPageSize);
            this.Cursor = Cursors.Default;
        }
 
        private void DisplayFolderInfo()
        {
            if (lvItems.SelectedItems.Count > 0)
            {
   

                StringBuilder oSB = new StringBuilder();
                oSB.AppendFormat("DisplayName: {0}\r\n", lvItems.SelectedItems[0].SubItems[1].Text);
                oSB.AppendFormat("FolderClass: {0}\r\n", lvItems.SelectedItems[0].SubItems[2].Text);
                oSB.AppendFormat("Folder Path: {0}\r\n", lvItems.SelectedItems[0].SubItems[6].Text);
                oSB.AppendFormat("UniqueId:    {0}\r\n", lvItems.SelectedItems[0].SubItems[7].Text);


                ShowTextDocument oForm = new ShowTextDocument();
                oForm.txtEntry.WordWrap = false;
                oForm.Text = "Folder";
                oForm.txtEntry.Text = oSB.ToString();
                oForm.Show();
           
            }
        }

        private void DispalyFolder()
        {
            if (lvItems.SelectedItems.Count > 0)
            {
                FolderId oFolderId = new FolderId(lvItems.SelectedItems[0].SubItems[5].Text);
                //oFolder.Id.UniqueId = lvItems.SelectedItems[0].SubItems[5].Text;
                DisplayFolder(oFolderId);
            }
        }

        private void DisplayFolder(FolderId folderId)
        {
            _CurrentService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID  
            Folder oFolder = Folder.Bind(
                _CurrentService,
                folderId,
                _CurrentDetailPropertySet);

            FolderContentForm.Show(
                string.Format(DisplayStrings.TITLE_CONTENTS_FOLDER, oFolder.DisplayName),
                oFolder,
                ItemTraversal.Shallow,
                _CurrentService,
                this);
  
           
        }

        private void ProcessSearch(FolderId oFolderId, int iPageSize)
        {

            int iLines = 0;

            bool bError = false;

            int iCount = 0;
            FindFoldersResults oFindFoldersResults = null;
 
            if (oFolderId != null)
            {
                //FindItemsResults<Item> oFindFoldersResults = null;


                if (this.cmboSearchType.Text == "Direct")
                {

                    
                    List<SearchFilter> searchFilterCollection = new List<SearchFilter>();
                    FolderView oFolderView = new FolderView(iPageSize);

                    oFolderView.PropertySet = new PropertySet(BasePropertySet.IdOnly,
                            FolderSchema.DisplayName,
                            FolderSchema.FolderClass,
                            FolderSchema.TotalCount,
                            FolderSchema.UnreadCount,
                            Prop_PR_FOLDER_PATH,
                            Prop_PR_IS_HIDDEN
                            );


                    //oFolderView.OrderBy.Add(FolderSchema.DisplayName SortDirection.Descending);

                    SetSearchDepth(ref oFolderView);


        
                        if (this.chkClass.Checked == true)
                             AddCondition(ref searchFilterCollection, FolderSchema.FolderClass, this.txtClass.Text, cmboClassConditional.Text);

                        if (this.chkDisplayName.Checked == true)
                            AddCondition(ref searchFilterCollection, FolderSchema.DisplayName, this.txtDisplayName.Text, cmboDisplayNameConditional.Text);

 

                        SearchFilter searchFilter = null;
                        if (searchFilterCollection.Count == 0)
                        {
 
                            try
                            {
                                _CurrentService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID. 
                                oFindFoldersResults = _CurrentService.FindFolders(oFolderId, oFolderView);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString(), "Error calling FindFolders");
                                bError = true;
                            }
                        }
                        else
                        {
                            if (cmboLogicalOperation.Text == "And")
                                searchFilter = new SearchFilter.SearchFilterCollection(LogicalOperator.And, searchFilterCollection.ToArray());
                            if (cmboLogicalOperation.Text == "Or")
                                searchFilter = new SearchFilter.SearchFilterCollection(LogicalOperator.Or, searchFilterCollection.ToArray());

                            
                            try
                            {
                                _CurrentService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID. 
                                oFindFoldersResults = _CurrentService.FindFolders(oFolderId, searchFilter, oFolderView);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString(), "Error calling FindFolders");
                                bError = true;
                            }
                        }

                    

                    if (bError == true)
                        return;

                    SetHeaders(this.cmboSearchType.Text);  // Driect

                    ListViewItem oListItem = null;
                    iCount = 0;
                    foreach (Folder oFolder in oFindFoldersResults.Folders)
                    {
                        iCount++;

                        oListItem = new ListViewItem(iCount.ToString(), 0);

                        oListItem.SubItems.Add(oFolder.DisplayName);
                        oListItem.SubItems.Add(oFolder.FolderClass);
                        oListItem.SubItems.Add(oFolder.TotalCount.ToString());
                        oListItem.SubItems.Add(oFolder.UnreadCount.ToString());

                        Object oHidden = null;
                        bool bHidden = false;
                        if (oFolder.TryGetProperty(Prop_PR_IS_HIDDEN, out oHidden))
                        {
                            bHidden = (bool)oHidden;
                            oListItem.SubItems.Add(bHidden.ToString());
                        }
                        else
                        {
                            oListItem.SubItems.Add("");
                        }

  
                        string sPath = string.Empty;
                        EwsFolderHelper.GetFolderPath(oFolder, ref sPath);
                        oListItem.SubItems.Add(sPath);

                        oListItem.SubItems.Add(oFolder.Id.UniqueId);


 
                        oListItem.Tag = new FolderTag(oFolder.Id, oFolder.FolderClass);
                        lvItems.Items.AddRange(new ListViewItem[] { oListItem }); ;
                        oListItem = null;
                        //}

                        iLines++;

                    }

                    oListItem = null;
                }


                if (this.cmboSearchType.Text == "More Available")
                {
 
                    // http://msdn.microsoft.com/en-us/library/exchange/dd633698(v=exchg.80).aspx

                    int offset = 0;
                                        
                    List<SearchFilter> searchFilterCollection = new List<SearchFilter>();

                    FolderView oFolderView = null;


                    bool MoreItems = true;
                    ListViewItem oListItem = null;

                    SetHeaders(this.cmboSearchType.Text);  // more availible

                    int iCountMore = 0;

                    while (MoreItems)
                    {
                        iCountMore++;

                        oFolderView = new FolderView(iPageSize, offset, OffsetBasePoint.Beginning);

                        oFolderView.PropertySet = new PropertySet(BasePropertySet.IdOnly,
                                FolderSchema.DisplayName,
                                FolderSchema.FolderClass,
                                FolderSchema.TotalCount,
                                FolderSchema.UnreadCount,
                                Prop_PR_FOLDER_PATH,
                                Prop_PR_IS_HIDDEN
                                );

                        SetSearchDepth(ref oFolderView);

 
                        if (this.chkClass.Checked == true)
                            AddCondition(ref searchFilterCollection, FolderSchema.FolderClass, this.txtClass.Text, cmboClassConditional.Text);
 
                        if (this.chkDisplayName.Checked == true)
                            AddCondition(ref searchFilterCollection, FolderSchema.DisplayName, this.txtDisplayName.Text, cmboDisplayNameConditional.Text);

                        SearchFilter searchFilter = null;
                        //Array arrCollection = searchFilterCollection.ToArray();
                        if (searchFilterCollection.Count == 0)
                        {
 
                            try
                            {
                                _CurrentService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID. 
                                oFindFoldersResults = _CurrentService.FindFolders(oFolderId, oFolderView);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString(), "Error calling FindFolders");
                                bError = true;
                            }
                        }
                        else
                        {
                            if (cmboLogicalOperation.Text == "And")
                                searchFilter = new SearchFilter.SearchFilterCollection(LogicalOperator.And, searchFilterCollection.ToArray());
                            if (cmboLogicalOperation.Text == "Or")
                                searchFilter = new SearchFilter.SearchFilterCollection(LogicalOperator.Or, searchFilterCollection.ToArray());
 
                            try
                            {
                                _CurrentService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID. 
                                oFindFoldersResults = _CurrentService.FindFolders(oFolderId, searchFilter, oFolderView);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString(), "Error calling FindFolders");
                                bError = true;
                            }

                        }
                                                           
 

                        if (bError == true)
                            return;

                        iCount = 0;
                        foreach (Folder oFolder in oFindFoldersResults.Folders)
                        {
                            iCount++;

  
                            oListItem = new ListViewItem(iCountMore.ToString() + ":" + iCount.ToString(), 0);

                            oListItem.SubItems.Add(oFolder.DisplayName);
                            oListItem.SubItems.Add(oFolder.FolderClass);
                            oListItem.SubItems.Add(oFolder.TotalCount.ToString());
                            oListItem.SubItems.Add(oFolder.UnreadCount.ToString());

                            Object oHidden = null;
                            bool bHidden = false;
                            if (oFolder.TryGetProperty(Prop_PR_IS_HIDDEN, out oHidden))
                            {
                                bHidden = (bool)oHidden;
                                oListItem.SubItems.Add(bHidden.ToString());
                            }
                            else
                            {
                                oListItem.SubItems.Add("");
                            }

                            string sPath = string.Empty;
                            EwsFolderHelper.GetFolderPath(oFolder, ref sPath);
                            oListItem.SubItems.Add(sPath);

                            oListItem.SubItems.Add(oFolder.Id.UniqueId);

 
                            oListItem.Tag = new FolderTag(oFolder.Id, oFolder.FolderClass);
                            lvItems.Items.AddRange(new ListViewItem[] { oListItem }); ;
                            oListItem = null;
                        

                            iLines++;
                        }

                        // Set the flag to discontinue paging.
                        if (!oFindFoldersResults.MoreAvailable)
                        {
                            MoreItems = false;
                        }

                        // Update the offset if there are more items to page.
                        if (MoreItems)
                        {
                            offset += iPageSize;
                        }

                    }


                }
            }
        }

        private void SetSearchDepth(ref FolderView oFolderView)
        {

            switch (cmboSearchDepth.Text)
            {
                case "Shallow":
                    oFolderView.Traversal = FolderTraversal.Shallow; // Shallow, Deep, SoftDeleted
                    break;
                case "Deep":
                    oFolderView.Traversal = FolderTraversal.Deep; // Shallow, Deep, SoftDeleted
                    break;
                case "SoftDeleted":
                    oFolderView.Traversal = FolderTraversal.SoftDeleted; // Shallow, Deep, SoftDeleted
                    break;
            }
        }

        private void SetHeaders(string sSearchType)
        {
            lvItems.Clear();
            lvItems.View = View.Details;
            lvItems.GridLines = true;
          

            if (sSearchType == "Direct")
                lvItems.Columns.Add("Count", 100, HorizontalAlignment.Left);
            else
                lvItems.Columns.Add("Frame:Count", 100, HorizontalAlignment.Left);
            lvItems.Columns.Add("DisplayName", 170, HorizontalAlignment.Left);
            lvItems.Columns.Add("FolderClass", 80, HorizontalAlignment.Left);
            lvItems.Columns.Add("TotalCount", 80, HorizontalAlignment.Left);
            lvItems.Columns.Add("UnreadCount", 80, HorizontalAlignment.Left);
            lvItems.Columns.Add("Read Only", 80, HorizontalAlignment.Left);
            lvItems.Columns.Add("Folder Path", 250, HorizontalAlignment.Left);
            lvItems.Columns.Add("UniqueId", 250, HorizontalAlignment.Left);

        }

       private void AddCondition(ref List<SearchFilter> searchFilterCollection,  PropertyDefinitionBase oProp, string sValue, string sConditional)
        {
            switch (sConditional)
            {
                case "ContainsSubstring":
                    searchFilterCollection.Add(new SearchFilter.ContainsSubstring(oProp, sValue));
                    break;
                case "IsEqualTo":
                    searchFilterCollection.Add(new SearchFilter.IsEqualTo(oProp, sValue));
                    break;
                case "IsGreaterThan":
                    searchFilterCollection.Add(new SearchFilter.IsGreaterThan(oProp, sValue));
                    break;
                case "IsGreaterThanOrEqualTo":
                    searchFilterCollection.Add(new SearchFilter.IsGreaterThanOrEqualTo(oProp, sValue));
                    break;
                case "IsLessThan":
                    searchFilterCollection.Add(new SearchFilter.IsLessThan(oProp, sValue));
                    break;
                case "IsLessThanOrEqualTo":
                    searchFilterCollection.Add(new SearchFilter.IsLessThanOrEqualTo(oProp, sValue));
                    break;
                case "IsNotEqualTo":
                    searchFilterCollection.Add(new SearchFilter.IsNotEqualTo(oProp, sValue));
                    break;

            }   
        }
        private void cmboSearchDepth_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void mnuFolderStripFolderProperties_Click(object sender, EventArgs e)
        {
            DisplayFolderInfo();
        }

        private void lvItems_DoubleClick(object sender, EventArgs e)
        {
            if (lvItems.SelectedItems.Count > 0)
            {

                FolderId oFolderId = new FolderId(lvItems.SelectedItems[0].SubItems[7].Text);

                DisplayFolder(oFolderId);
            }
        }

        private void lvItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
