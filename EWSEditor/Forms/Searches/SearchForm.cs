using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using EWSEditor.Common.Exports;
using EWSEditor.Common;
using EWSEditor.Common.Extensions;
using EWSEditor.Resources;
using Microsoft.Exchange.WebServices.Data;
using System.Net;
using System.Xml;

 

namespace EWSEditor.Forms
{
    public partial class SearchForm : Form
    {
        public bool ChoseOK = false;
        private ExchangeService _CurrentService = null;
        private FolderId _CurrentFolderId = null;
        //private static ExtendedPropertyDefinition Prop_FolderPath = new ExtendedPropertyDefinition(0x66B5, MapiPropertyType.String);   // Folder Path - PR_Folder_Path
        //private static ExtendedPropertyDefinition Prop_PR_FOLDER_TYPE = new ExtendedPropertyDefinition(0x3601, MapiPropertyType.Integer);  // PR_FOLDER_TYPE 0x3601 (13825)


        public SearchForm()
        {
            InitializeComponent();
        }

        public SearchForm(ExchangeService oExchangeService, FolderId oCurrentFolderId)
        {
            _CurrentService = oExchangeService;
            _CurrentFolderId = oCurrentFolderId;

            InitializeComponent();
 
        }


        private void SearchForm_Load(object sender, EventArgs e)
        {
            //http://technet.microsoft.com/en-us/library/cc535025%28EXCHG.80%29.aspx

            //http://msdn.microsoft.com/en-us/library/exchange/dd633674(v=exchg.80).aspx

            // http://msdn.microsoft.com/en-us/library/exchange/dd633693(v=exchg.80).aspx 

            cmboSearchType.Text = "More Available";

            cmboSearchDepth.Text = "Shallow";
            
            cmboLogicalOperation.Text = "And";

            
            cmboSubjectConditional.Text = "ContainsSubstring";
            cmboToConditional.Text = "ContainsSubstring";
            cmboCCConditional.Text = "ContainsSubstring";
            cmboBodyConditional.Text = "ContainsSubstring";
            cmboClassConditional.Text = "ContainsSubstring";

            toolStripStatusLabel1.Text = "";

            SetCheckboxes();
           
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
 
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ChoseOK = false;
            this.Close();
        }

        private void SetCheckboxes()
        {
            if (this.rdoAqsSearch.Checked == true)
            {
    
              
                this.txtSubject.Enabled = false;
                this.txtTo.Enabled = false;
                this.txtCC.Enabled = false;
                this.txtBody.Enabled = false;
                this.txtClass.Enabled = false;

                
                this.chkSubject.Enabled = false;
                this.chkTo.Enabled = false;
                this.chkCC.Enabled = false;
                this.chkBody.Enabled = false;        
                this.chkClass.Enabled = false;

               
                cmboSubjectConditional.Enabled = false;
                cmboToConditional.Enabled = false;
                cmboCCConditional.Enabled = false;
                cmboBodyConditional.Enabled = false;
                cmboClassConditional.Enabled = false;


            }
            if (this.rdoFindItemSearch.Checked == true)
            {
                 
                this.chkSubject.Enabled = true;
                this.chkTo.Enabled = true;
                this.chkCC.Enabled = true;
                this.chkBody.Enabled = true;
                this.chkClass.Enabled = true;

               
                this.txtSubject.Enabled = true;
                this.txtTo.Enabled = true;
                this.txtCC.Enabled = true;
                this.txtBody.Enabled = true;
                this.txtClass.Enabled = true;

                cmboSubjectConditional.Enabled = chkSubject.Checked;
                
                cmboToConditional.Enabled = chkTo.Checked;
                cmboCCConditional.Enabled = chkCC.Checked;
                cmboBodyConditional.Enabled = chkBody.Checked;
                cmboClassConditional.Enabled = chkClass.Checked;

            }

            this.txtAQS.Enabled = rdoAqsSearch.Checked;

            this.txtSubject.Enabled = chkSubject.Checked;
           
            this.txtTo.Enabled  = chkTo.Checked;
            this.txtCC.Enabled  = chkCC.Checked;
            this.txtBody.Enabled = chkBody.Checked;
            this.txtClass.Enabled = chkClass.Checked;

 
        }

        private bool CheckFields()
        {
            bool bRet = true;

            if (this.chkSubject.Checked == true)
                if (this.txtSubject.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Subject line text cannot be blank");
                }

            //if (this.chkUID.Checked == true)
            //    if (this.txtUID.Text.Trim().Length == 0)
            //    {
            //        MessageBox.Show("The UID line text cannot be blank");
            //    }

            if (this.chkTo.Checked == true)
                if (this.txtTo.Text.Trim().Length == 0)
                {
                    MessageBox.Show("To line text cannot be blank");
                }

            if (this.chkCC.Checked == true)
                if (this.txtCC.Text.Trim().Length == 0)
                {
                    MessageBox.Show("CC line text cannot be blank");
                }

            if (this.chkBody.Checked == true)
                if (this.txtBody.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Body line text cannot be blank");
                }

            if (this.chkClass.Checked == true)
                if (this.txtClass.Text.Trim().Length == 0)
                {
                    MessageBox.Show("Class line text cannot be blank");
                }

            if (this.rdoAqsSearch.Checked == true)
                if (this.txtAQS.Text.Trim().Length == 0)
                {
                    MessageBox.Show("AQS line text cannot be blank");
                }

            return bRet;

        }

        private void chkAQS_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckboxes();
            txtAQS.Enabled = this.rdoAqsSearch.Checked;
        }

        private void chkSubject_CheckedChanged(object sender, EventArgs e)
        {
            txtSubject.Enabled = chkSubject.Checked;
            cmboSubjectConditional.Enabled = chkSubject.Checked;
        }

        private void chkTo_CheckedChanged(object sender, EventArgs e)
        {
            txtTo.Enabled = chkTo.Checked;
            cmboToConditional.Enabled = chkTo.Checked;
        }

        private void chkCC_CheckedChanged(object sender, EventArgs e)
        {
            txtCC.Enabled = chkCC.Checked;
            cmboCCConditional.Enabled = chkCC.Checked;
        }

        private bool ProcessSearch(FolderId oFolderId, int iPageSize)
        {
            int iCount = 0;
            bool bRet = false;
            string sItemFolderPath = string.Empty;
            ListViewItem.ListViewSubItem oLVSI = null; 
           

            if (oFolderId != null)
            {
 
                FindItemsResults<Item> oFindItemsResults = null;

                if (this.cmboSearchType.Text == "Direct")
                {
                    List<SearchFilter> searchFilterCollection = new List<SearchFilter>();
                    ItemView oItemView = new ItemView(iPageSize);

 
                    oItemView.PropertySet = new PropertySet(BasePropertySet.IdOnly,
                        ItemSchema.ParentFolderId,
                        ItemSchema.Subject,
                        ItemSchema.DisplayTo,
                        ItemSchema.Subject,
                        ItemSchema.DisplayCc,
                        ItemSchema.DateTimeReceived,
                        ItemSchema.HasAttachments,
                        ItemSchema.ItemClass,


                        ItemSchema.IsResend,
                        ItemSchema.IsDraft,
                        ItemSchema.DateTimeCreated,
                        ItemSchema.DateTimeReceived,
               
                        ItemSchema.LastModifiedName,
                        ItemSchema.LastModifiedTime,        
                        ItemSchema.Size  
 

                        );
 
                    oItemView.OrderBy.Add(ItemSchema.DateTimeReceived, SortDirection.Descending);

 
                    SetSearchDepth(ref oItemView);
 
 
                    if (this.rdoAqsSearch.Checked == true)
                    {
                        try
                        {
                            _CurrentService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.   
                            oFindItemsResults = _CurrentService.FindItems(oFolderId, this.txtAQS.Text, oItemView);
                        }   
                        catch (Exception ex)
                        {
                            this.Cursor = Cursors.Default;
                            throw ex;
                          
                        }
                    }
                    else
                    {
                        //txtUID.Enabled = chkUID.Checked;
                        //cmboUidConditional.Enabled = chkUID.Checked;

                        //if (this.chkUID.Checked == true)
                        //    AddCondition(ref searchFilterCollection, ItemSchema.UID, this.txtUID.Text, cmboUidConditional.Text);

                        //if (this.chkIsRead.Checked == true)
                        //    AddCondition(ref searchFilterCollection, ItemSchema.IsRead, this.txtIsRead.Text, cmboIsRead.Text);


                        if (this.chkClass.Checked == true)                            
                            AddCondition(ref searchFilterCollection, ItemSchema.ItemClass, this.txtClass.Text, cmboClassConditional.Text);
 
                        if (this.chkSubject.Checked == true)
                            if (this.txtSubject.Text.Length != 0)
                                AddCondition(ref searchFilterCollection, ItemSchema.Subject, this.txtSubject.Text, cmboSubjectConditional.Text); 
 
                        if (this.chkTo.Checked == true)
                            if (this.txtTo.Text.Length != 0)
                                AddCondition(ref searchFilterCollection, ItemSchema.DisplayTo, this.txtTo.Text, cmboToConditional.Text); 
                                //searchFilterCollection.Add(new SearchFilter.ContainsSubstring(ItemSchema.DisplayTo, this.txtTo.Text));
                        if (this.chkCC.Checked == true)
                            if (this.txtCC.Text.Length != 0)
                                AddCondition(ref searchFilterCollection, ItemSchema.DisplayCc, this.txtCC.Text, cmboCCConditional.Text); 
                                //searchFilterCollection.Add(new SearchFilter.ContainsSubstring(ItemSchema.DisplayCc, this.txtCC.Text));
                        if (this.chkBody.Checked == true)
                            if (this.txtBody.Text.Length != 0)
                                AddCondition(ref searchFilterCollection, ItemSchema.Body, this.txtBody.Text, cmboBodyConditional.Text);
                                //searchFilterCollection.Add(new SearchFilter.ContainsSubstring(ItemSchema.Body, this.txtBody.Text));


                        SearchFilter searchFilter = null;
                        if (searchFilterCollection.Count == 0)
                        {
                            try
                            {
                                _CurrentService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.   
                                oFindItemsResults = _CurrentService.FindItems(oFolderId, oItemView);
                            }
                            catch (Exception ex)
                            {
                                this.Cursor = Cursors.Default;
                                throw ex;
                                
                            }
                        }
                        else
                        {
                            if (cmboLogicalOperation.Text == "And")
                                searchFilter = new SearchFilter.SearchFilterCollection(LogicalOperator.And, searchFilterCollection.ToArray());
                            if (cmboLogicalOperation.Text == "Or")
                                searchFilter = new SearchFilter.SearchFilterCollection(LogicalOperator.Or, searchFilterCollection.ToArray());

                            _CurrentService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.   
                            oFindItemsResults = _CurrentService.FindItems(oFolderId, searchFilter, oItemView);
                        }

 
                    }

                    lvItems.Clear();
                    lvItems.View = View.Details;
                    lvItems.GridLines = true;
                    //lvItems.Dock = DockStyle.Fill;

                    lvItems.Columns.Add("Frame:Count", 100, HorizontalAlignment.Left);
                    lvItems.Columns.Add("Subject", 170, HorizontalAlignment.Left);
                    lvItems.Columns.Add("Class", 150, HorizontalAlignment.Left);
                    lvItems.Columns.Add("DisplayTo", 100, HorizontalAlignment.Left);
                    lvItems.Columns.Add("DisplayCc", 100, HorizontalAlignment.Left);
                    lvItems.Columns.Add("Attatch", 50, HorizontalAlignment.Left);

                    lvItems.Columns.Add("IsResend", 50, HorizontalAlignment.Left);
                    lvItems.Columns.Add("IsDraft", 50, HorizontalAlignment.Left);
                    lvItems.Columns.Add("DateTimeCreated", 50, HorizontalAlignment.Left);
                    lvItems.Columns.Add("DateTimeReceived", 100, HorizontalAlignment.Left);
                     
                    lvItems.Columns.Add("LastModifiedName", 100, HorizontalAlignment.Left);
                    lvItems.Columns.Add("LastModifiedTime", 100, HorizontalAlignment.Left);

                    lvItems.Columns.Add("Size", 50, HorizontalAlignment.Left);
                    lvItems.Columns.Add("Folder Path", 200, HorizontalAlignment.Left);

 
                    lvItems.Columns.Add("UniqueId", 250, HorizontalAlignment.Left);
                    lvItems.Columns.Add("ChangeKey", 250, HorizontalAlignment.Left);

                    lvItems.Tag = -1;

              
                     
                    ListViewItem oListItem = null;
                    iCount = 0;
                    foreach (Item oItem in oFindItemsResults.Items)
                    {
                        iCount++;
 
                        // Note:  If you change any columns then you may need to chage other code such as
                        // that for then listview property export code, which references columns by position.

                        oListItem = new ListViewItem(iCount.ToString(), 0);    // 1

                        oLVSI = oListItem.SubItems.Add(oItem.Subject);
                        oLVSI.Tag = "String";
                        oLVSI = oListItem.SubItems.Add(oItem.ItemClass);
                        oLVSI.Tag = "String";
                        oLVSI = oListItem.SubItems.Add(oItem.DisplayTo);
                        oLVSI.Tag = "String";
                        oLVSI = oListItem.SubItems.Add(oItem.DisplayCc);                // 5

                        oLVSI = oListItem.SubItems.Add(oItem.HasAttachments.ToString());
                        oLVSI.Tag = "String";

                        oLVSI = oListItem.SubItems.Add(oItem.IsResend.ToString());
                        oLVSI.Tag = "String";
                        oLVSI = oListItem.SubItems.Add(oItem.IsDraft.ToString());
                        oLVSI.Tag = "String";
                        oLVSI = oListItem.SubItems.Add(oItem.DateTimeCreated.ToString());
                        oLVSI.Tag = "String";
                        oLVSI = oListItem.SubItems.Add(oItem.DateTimeReceived.ToString());      // 10
                        oLVSI.Tag = "String";
                        oLVSI = oListItem.SubItems.Add(oItem.LastModifiedName.ToString());
                        oLVSI.Tag = "String";
                        oLVSI = oListItem.SubItems.Add(oItem.LastModifiedTime.ToString());
                        oLVSI.Tag = "String";

                        oLVSI = oListItem.SubItems.Add(oItem.Size.ToString());
                        oLVSI.Tag = "String";


                        if (EwsFolderHelper.GetFolderPath(oItem.Service, oItem.ParentFolderId, ref sItemFolderPath))  // 14
                        {
                            oLVSI = oListItem.SubItems.Add(sItemFolderPath);
                            oLVSI.Tag = "String";
                        }
                        else
                        {
                            oLVSI = oListItem.SubItems.Add("");
                            oLVSI.Tag = "String";
                        }

                        oLVSI = oListItem.SubItems.Add(oItem.Id.UniqueId);
                        oLVSI.Tag = "Binary";
                        oLVSI = oListItem.SubItems.Add(oItem.Id.ChangeKey);
                        oLVSI.Tag = "Binary";

                        oLVSI = null;

                        oListItem.Tag = new ItemTag(oItem.Id, oItem.ItemClass);
                        lvItems.Items.AddRange(new ListViewItem[] { oListItem }); ;
                        oListItem = null;     
                    }

                    oListItem = null;
                    bRet = true;
                }


                if (this.cmboSearchType.Text == "More Available")
                {

                    // http://msdn.microsoft.com/en-us/library/exchange/dd633698(v=exchg.80).aspx

                    int offset = 0;
                         
 
                    bool MoreItems = true;
                    ListViewItem oListItem = null;

                    lvItems.Clear();
                    lvItems.View = View.Details;
                    lvItems.GridLines = true;
                    lvItems.Columns.Add("Frame:Count", 100, HorizontalAlignment.Left);
                    lvItems.Columns.Add("Subject", 170, HorizontalAlignment.Left);
                    lvItems.Columns.Add("Class", 150, HorizontalAlignment.Left);
                    lvItems.Columns.Add("DisplayTo", 100, HorizontalAlignment.Left);
                    lvItems.Columns.Add("DisplayCc", 100, HorizontalAlignment.Left);
                    lvItems.Columns.Add("Attatch", 50, HorizontalAlignment.Left);

                    lvItems.Columns.Add("IsResend", 50, HorizontalAlignment.Left);
                    lvItems.Columns.Add("IsDraft", 50, HorizontalAlignment.Left);
                    lvItems.Columns.Add("DateTimeCreated", 50, HorizontalAlignment.Left);
                    lvItems.Columns.Add("DateTimeReceived", 100, HorizontalAlignment.Left);
                 
                    lvItems.Columns.Add("LastModifiedName", 100, HorizontalAlignment.Left);
                    lvItems.Columns.Add("LastModifiedTime", 100, HorizontalAlignment.Left);

                    lvItems.Columns.Add("Size", 50, HorizontalAlignment.Left);
                    lvItems.Columns.Add("Folder Path", 200, HorizontalAlignment.Left);

                    //lvItems.Columns.Add("Id", 50, HorizontalAlignment.Left);
                    lvItems.Columns.Add("UniqueId", 250, HorizontalAlignment.Left);
                    lvItems.Columns.Add("ChangeKey", 250, HorizontalAlignment.Left);

                    lvItems.Tag = -1;

                    int iCountMore = 0;

                    while (MoreItems)
                    {
                        iCountMore++;

                         
                        ItemView oItemView = new ItemView(iPageSize, offset, OffsetBasePoint.Beginning);

                        List<SearchFilter> searchFilterCollection = new List<SearchFilter>();

                        oItemView.PropertySet = new PropertySet(BasePropertySet.IdOnly,
                                            ItemSchema.ParentFolderId,
                                            ItemSchema.Subject,
                                            ItemSchema.DisplayTo,
                                            ItemSchema.DisplayCc,
                                            ItemSchema.DateTimeReceived,
                                            ItemSchema.HasAttachments,
                                            ItemSchema.ItemClass,

                                            ItemSchema.IsResend,
                                            ItemSchema.IsDraft,
                                            ItemSchema.DateTimeCreated,
                                            ItemSchema.DateTimeReceived,
                                        
                                            ItemSchema.LastModifiedName,
                                            ItemSchema.LastModifiedTime,
                                          
                                            ItemSchema.Size 
      
                                            );
 
                        oItemView.OrderBy.Add(ContactSchema.DisplayName, SortDirection.Ascending);
                        //oItemView.Traversal = ItemTraversal.Shallow; // shallow, associated, soft deleted

                        SetSearchDepth(ref oItemView);

                        if (this.rdoAqsSearch.Checked == true)
                        {
                            try
                            {
                                _CurrentService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.   
                                oFindItemsResults = _CurrentService.FindItems(oFolderId, this.txtAQS.Text, oItemView);
                            }
                            catch(Exception ex)
                            {
                                this.Cursor = Cursors.Default;
                                throw ex;
                            }
                        }
                        else
                        {

                            //if (this.chkUID.Checked == true)
                            //    AddCondition(ref searchFilterCollection, ItemSchema.UID, this.txtUID.Text, cmboUidConditional.Text);
                            
                            //if (this.chkIsRead.Checked == true)
                            //    AddCondition(ref searchFilterCollection, ItemSchema.IsRead, this.txtIsRead.Text, cmboIsRead.Text);

                            if (this.chkClass.Checked == true)
                                 AddCondition(ref searchFilterCollection, ItemSchema.ItemClass, this.txtClass.Text, cmboClassConditional.Text);
                            if (this.chkSubject.Checked == true)
                                AddCondition(ref searchFilterCollection, ItemSchema.Subject, this.txtSubject.Text, cmboSubjectConditional.Text);
                            if (this.chkTo.Checked == true)
                                AddCondition(ref searchFilterCollection, ItemSchema.DisplayTo, this.txtTo.Text, cmboToConditional.Text);
                            if (this.chkCC.Checked == true)
                                AddCondition(ref searchFilterCollection, ItemSchema.DisplayCc, this.txtCC.Text, cmboCCConditional.Text);
                            if (this.chkBody.Checked == true)
                                AddCondition(ref searchFilterCollection, ItemSchema.Body, this.txtBody.Text, cmboBodyConditional.Text);

                            SearchFilter searchFilter = null;
                            if (searchFilterCollection.Count == 0)
                            {
                                try
                                {
                                    _CurrentService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.   
                                    oFindItemsResults = _CurrentService.FindItems(oFolderId, oItemView);
                                }
                                catch(Exception ex)
                                {
                                    this.Cursor = Cursors.Default;
                                    throw ex;
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
                                    oFindItemsResults = _CurrentService.FindItems(oFolderId, searchFilter, oItemView);
                                }
                                catch(Exception ex)
                                {
                                    this.Cursor = Cursors.Default;
                                    throw ex;
                                }
                            }
                        }

 
                        iCount = 0;
                        foreach (Item oItem in oFindItemsResults.Items)
                        {
                            iCount++;

                            // Note:  If you change any columns then you may need to chage other code such as
                            // that for then listview property export code, which references columns by position.

 
                            oListItem = new ListViewItem(iCountMore.ToString() + ":" +iCount.ToString(), 0);


                            oLVSI = oListItem.SubItems.Add(oItem.Subject);
                            oLVSI.Tag = "String";
                            oLVSI = oListItem.SubItems.Add(oItem.ItemClass);
                            oLVSI.Tag = "String";
                            oLVSI = oListItem.SubItems.Add(oItem.DisplayTo);
                            oLVSI.Tag = "String";
                            oLVSI = oListItem.SubItems.Add(oItem.DisplayCc);
                            oLVSI.Tag = "String";
                            oLVSI = oListItem.SubItems.Add(oItem.HasAttachments.ToString());
                            oLVSI.Tag = "String";

                            oLVSI = oListItem.SubItems.Add(oItem.IsResend.ToString());
                            oLVSI.Tag = "String";
                            oLVSI = oListItem.SubItems.Add(oItem.IsDraft.ToString());
                            oLVSI.Tag = "String";
                            oLVSI = oListItem.SubItems.Add(oItem.DateTimeCreated.ToString());
                            oLVSI.Tag = "String";
                            try
                            {
                                oLVSI = oListItem.SubItems.Add(oItem.DateTimeReceived.ToString());
                                oLVSI.Tag = "String";
                            }
                            catch
                            {
                                oLVSI = oListItem.SubItems.Add("");
                                oLVSI.Tag = "String";
                            }

                            oLVSI = oListItem.SubItems.Add(oItem.LastModifiedName.ToString());
                            oLVSI.Tag = "String";
                            oLVSI = oListItem.SubItems.Add(oItem.LastModifiedTime.ToString());
                            oLVSI.Tag = "String";

                            oLVSI = oListItem.SubItems.Add(oItem.Size.ToString());
                            oLVSI.Tag = "String";

                            if (EwsFolderHelper.GetFolderPath(oItem.Service, oItem.ParentFolderId, ref sItemFolderPath))
                            {
                                oLVSI = oListItem.SubItems.Add(sItemFolderPath);
                                oLVSI.Tag = "String";
                            }
                            else
                            {
                                oLVSI = oListItem.SubItems.Add("");
                                oLVSI.Tag = "String";
                            }

                            oLVSI = oListItem.SubItems.Add(oItem.Id.UniqueId);
                            oLVSI.Tag = "Binary";
                            oLVSI = oListItem.SubItems.Add(oItem.Id.ChangeKey);
                            oLVSI.Tag = "Binary";

                            oLVSI = null;

                            oListItem.Tag = new ItemTag(oItem.Id, oItem.ItemClass );
                            lvItems.Items.AddRange(new ListViewItem[] { oListItem }); ;
                            oListItem = null;
                        
                        }

                        // Set the flag to discontinue paging.
                        if (!oFindItemsResults.MoreAvailable)
                        {
                            MoreItems = false;
                        }

                        // Update the offset if there are more items to page.
                        if (MoreItems)
                        {
                            offset += iPageSize;
                        }

                    }

                    bRet = true;
                }
            }
            this.Cursor = Cursors.Default;
            return bRet;

        }
 

        private void btnSearch_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
            int iPageSize = 100;
            iPageSize = (int)this.numPageSize.Value;
            this.Cursor = Cursors.WaitCursor;
            ProcessSearch(_CurrentFolderId, iPageSize);
            this.Cursor = Cursors.Default;
        }

        private void rdoAqsSearch_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckboxes();
        }

        private void rdoFindItemSearch_CheckedChanged(object sender, EventArgs e)
        {
            SetCheckboxes();
        }

        private void chkBody_CheckedChanged(object sender, EventArgs e)
        {
            this.txtBody.Enabled = this.chkBody.Checked;
            cmboBodyConditional.Enabled = this.chkBody.Checked;
      
        }

        private void btnMailboxSearch_Click(object sender, EventArgs e)
        {
           
        }

      

        private void btnListSearchableMailboxes_Click(object sender, EventArgs e)
        {
        }

        private void lvItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvItems_DoubleClick(object sender, EventArgs e)
        {
            DisplayItem();
        }

        private void DisplayItem()
        {
            if (lvItems.SelectedItems.Count > 0)
            {

 
                ItemTag oItemTag = (ItemTag)lvItems.SelectedItems[0].Tag;
                ItemId oItemId = oItemTag.Id;
                //string sId = lvItems.SelectedItems[0].SubItems[13].Text;
                //ItemId oItemId = new ItemId(sId);


                List<ItemId> item = new List<ItemId>();
                item.Add(oItemId);

                ItemsContentForm.Show(
                    "Displaying item",
                    item,
                    _CurrentService,
                    this);
            }
        }

        private void chkClass_CheckedChanged(object sender, EventArgs e)
        {
            this.txtClass.Enabled = this.chkClass.Checked;
            cmboClassConditional.Enabled = this.chkClass.Checked;
 
        }

        private void cmboSearchDepth_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SetSearchDepth(ref ItemView oItemView)
        {
            switch (cmboSearchDepth.Text)
            {
                case "Shallow":
                    oItemView.Traversal = ItemTraversal.Shallow; // Shallow, Associated, SoftDeleted
                    break;
                case "Associated":
                    oItemView.Traversal = ItemTraversal.Associated; // Shallow, Associated, SoftDeleted
                    break;
                case "SoftDeleted":
                    oItemView.Traversal = ItemTraversal.SoftDeleted; // Shallow, Associated, SoftDeleted
                    break;
            }
        }

        private void AddCondition(ref List<SearchFilter> searchFilterCollection, PropertyDefinitionBase oProp, string sValue, string sConditional)
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

        private void mnuCopyItems_Click(object sender, EventArgs e)
        {
             
            PickFolderAndCopyItems();
            
        }
         
 

        private void mnuMoveItems_Click(object sender, EventArgs e)
        {
            
            PickFolderAndMoveItems();
            
        }


        public bool PickFolderAndCopyItems()
        {
            int iCountItems = 0;

            FolderIdDialog oForm = new FolderIdDialog(_CurrentService);
            oForm.ShowDialog();
            if (oForm.ChoseOK != true)
            {
                //oForm.ChosenFolderId 
                this.Cursor = Cursors.Default;
                return false;
            }

            this.Cursor = Cursors.WaitCursor;

            //FolderId oFolderId = null;
            //if (FolderIdDialog.ShowDialog(ref oFolderId) != DialogResult.OK)
            //{
            //    return false;
            //}

            StringBuilder oSB = new StringBuilder();
            List<ItemId> oItemIds = new List<ItemId>();


            string sId = string.Empty;
            ItemId oItemId = null;
            ItemTag oItemTag = null;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                ListViewItem oListViewItem = null;
                // build list.
                for (int i = (lvItems.SelectedItems.Count - 1); i >= 0; i--)
                {
                    oListViewItem = lvItems.SelectedItems[i];

                    oItemIds.Clear();
                    oItemTag = (ItemTag)oListViewItem.Tag;
                    oItemId = oItemTag.Id;
                    oItemIds.Add(oItemId);

                    oSB = new StringBuilder();

                    if (CopyItem(oItemIds, oForm.ChosenFolderId, ref oSB) == false)
                    {
                        toolStripStatusLabel1.Text = string.Format("Error copying items.  Moved {0}", iCountItems);
                        return false;
                    }
                    else
                    {

                        iCountItems++;

                        if (iCountItems % 10 == 0)
                            toolStripStatusLabel1.Text = string.Format("Copied: {0}", iCountItems);

                        
                    }

                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error moving items.", ex.InnerException.ToString());

                ShowTextDocument oFormError = new ShowTextDocument();
                oFormError.txtEntry.WordWrap = true;
                oFormError.Text = "Error.";
                oFormError.txtEntry.Text = ex.ToString();
                oFormError.ShowDialog();

                return false;
            }
            finally
            {
                this.Cursor = Cursors.Default;
                this.Cursor = Cursors.Default;
            }

    

            ShowTextDocument oShowTextDocument = new ShowTextDocument();
            oShowTextDocument.txtEntry.WordWrap = true;
            oShowTextDocument.Text = "Move Results.";
            oShowTextDocument.txtEntry.Text = string.Format("Total Copied {0}", iCountItems); // // oSB.ToString();
            oShowTextDocument.ShowDialog();

            toolStripStatusLabel1.Text = string.Format("Total Copied {0}", iCountItems);

            this.Cursor = Cursors.Default;

            return true;
        }


        private bool CopyItem(List<ItemId> oItemIds, FolderId oFolderId, ref StringBuilder oSB)
        {

            ServiceResponseCollection<MoveCopyItemResponse> oResponses = this._CurrentService.CopyItems(
                oItemIds,
                oFolderId,
                false);
            try
            {

                if (oResponses.OverallResult != ServiceResult.Success)
                {

                    oSB.AppendFormat("Errors found in some of {0} response(s) .\r\n", oResponses.Count);

                    foreach (MoveCopyItemResponse oResponse in oResponses)
                    {
                        oSB.AppendFormat("Error copying: {0} Error: {1} - {2}\r\n",
                            oItemIds[0], oResponse.ErrorCode.ToString(), oResponse.ErrorMessage.ToString());

                        if (oResponse.ErrorDetails.Count != 0)
                        {
                            oSB.AppendFormat("    ErrorDetails: \r\n");
                            foreach (KeyValuePair<string, string> kvp in oResponse.ErrorDetails)
                            {
                                oSB.AppendFormat("         Item: {0}\r\n", kvp.Key);
                                oSB.AppendFormat("        Value: {0}\r\n", kvp.Value);
                                oSB.AppendLine();
                            }
                        }

                        if (oResponse.ErrorProperties.Count != 0)
                        {
                            oSB.AppendFormat("    ErrorProperties:  \r\n");
                            foreach (PropertyDefinitionBase oProps in oResponse.ErrorProperties)
                            {
                                oSB.AppendFormat("        Property: {0}\r\n", oProps.ToString());

                            }
                            oSB.AppendLine();
                        }
                        oSB.AppendLine();
                    }
                }
                else
                {
                    //Success!!!

                    foreach (MoveCopyItemResponse oResponse in oResponses)
                    {
                        oSB.AppendFormat("Copied: {0}\r\n\r\n", oResponse.Item.Id.UniqueId);

                        //if (oResponse.Item != null)
                        //{   // copy/moved item - null if between mailboxes or from mailbox to public folder.
                        //    oSB.AppendFormat("    Item - Id: {0}\r\n", oResponse.Item.Id.UniqueId);
                        //    //oSB.AppendFormat("           ParentFolderId: {0}\r\n", oResponse.Item.ParentFolderId);
                        //}
                    }
                }

                // Refresh the view
                //this.RefreshContentAndDetails();
            }
            catch (ServiceResponseException ex)
            {
                oSB.AppendFormat("");
                oSB.AppendFormat("Error: ");
                oSB.AppendFormat("    Item: {0}\r\n", oItemIds[0]);
                oSB.AppendFormat("    Error code: {0}\r\n", ex.ErrorCode);
                oSB.AppendFormat("    Error message: {0}\r\n", ex.Message);
                oSB.AppendFormat("    Response: {0}\r\n", ex.Response);


                StringBuilder oSB_Error = new StringBuilder();
                oSB_Error.AppendFormat("Error: ");
                oSB_Error.AppendFormat("    Item: {0}\r\n", oItemIds[0]);
                oSB_Error.AppendFormat("    Error code: {0}\r\n", ex.ErrorCode);
                oSB_Error.AppendFormat("    Error message: {0}\r\n", ex.Message);
                oSB_Error.AppendFormat("    Response: {0}\r\n", ex.Response);

                ShowTextDocument oForm = new ShowTextDocument();
                oForm.txtEntry.WordWrap = false;
                oForm.Text = "Error copy item: ";
                oForm.txtEntry.Text = oSB_Error.ToString();
                oForm.ShowDialog();

                this.Cursor = Cursors.Default;
                return false;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            return true;

        }

        public bool PickFolderAndMoveItems()
        {
            int iCountItems = 0;

            FolderIdDialog oForm = new FolderIdDialog(_CurrentService);
            oForm.ShowDialog();
            if (oForm.ChoseOK != true)
            {
                //oForm.ChosenFolderId 
                this.Cursor = Cursors.Default;
                return false;
            }

            this.Cursor = Cursors.WaitCursor;

            //FolderId oFolderId = null;
            //if (FolderIdDialog.ShowDialog(ref oFolderId) != DialogResult.OK)
            //{
            //    return false;
            //}

            StringBuilder oSB = new StringBuilder();
            List<ItemId> oItemIds = new List<ItemId>();
 

            string sId = string.Empty;
            ItemId oItemId = null;
            ItemTag oItemTag = null;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                ListViewItem oListViewItem = null;
                // build list.
                for (int i = (lvItems.SelectedItems.Count-1); i >= 0; i--) 
                {
                    oListViewItem = lvItems.SelectedItems[i];

                    oItemIds.Clear();
                    oItemTag = (ItemTag)oListViewItem.Tag;
                    oItemId = oItemTag.Id;
                    oItemIds.Add(oItemId);

                   // sId = (string)lvItems.SelectedItems[i].Tag;  

                    //oItemId = new ItemId(sId);
                    //oItemIds.Add(oItemId);

                    oSB = new StringBuilder();

                    if (MoveItem(oItemIds, oForm.ChosenFolderId, ref oSB) == false)
                    {
                        toolStripStatusLabel1.Text = string.Format("Error moving items.  Moved {0}", iCountItems);
                        return false;
                    }
                    else
                    {
                        iCountItems++;
                        if (iCountItems % 10 == 0)
                        {
                            toolStripStatusLabel1.Text = string.Format("Moved: {0}", iCountItems);
                            this._CurrentService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID. 
                            this.Update();
                        }
                         
 

                        //toolStripStatusLabel1.Text = string.Format("Moved {0}", iCountItems);

                        oListViewItem.Remove();
                    }
 
                }

            }
            catch(Exception ex)
            { 
                //MessageBox.Show("Error moving items.", ex.InnerException.ToString());

                ShowTextDocument oFormError = new ShowTextDocument();
                oFormError.txtEntry.WordWrap = true;
                oFormError.Text = "Error.";
                oFormError.txtEntry.Text = ex.ToString();
                oFormError.ShowDialog();

                return false;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            ShowTextDocument oShowTextDocument = new ShowTextDocument();
            oShowTextDocument.txtEntry.WordWrap = true;
            oShowTextDocument.Text = "Move Results.";
            oShowTextDocument.txtEntry.Text = string.Format("Total Moved {0}", iCountItems); // oSB.ToString();
            oShowTextDocument.ShowDialog();

            toolStripStatusLabel1.Text = string.Format("Total Moved {0}", iCountItems);

            this.Cursor = Cursors.Default;

            return true;
        }

        private bool MoveItem(List<ItemId> oItemIds, FolderId oFolderId, ref StringBuilder oSB)
        { 
     
            ServiceResponseCollection<MoveCopyItemResponse> oResponses = this._CurrentService.MoveItems(
                oItemIds,
                oFolderId, 
                false);
             try
             { 

                if (oResponses.OverallResult != ServiceResult.Success)
                {

                    oSB.AppendFormat("Errors found in some of {0} response(s) .\r\n", oResponses.Count);

                    foreach (MoveCopyItemResponse oResponse in oResponses)
                    {
                        oSB.AppendFormat("Error moving: {0} Error: {1} - {2}\r\n",
                            oItemIds[0], oResponse.ErrorCode.ToString(), oResponse.ErrorMessage.ToString());

                        if (oResponse.ErrorDetails.Count != 0)
                        {
                            oSB.AppendFormat("    ErrorDetails: \r\n");
                            foreach (KeyValuePair<string, string> kvp in oResponse.ErrorDetails)
                            {
                                oSB.AppendFormat("         Item: {0}\r\n", kvp.Key);
                                oSB.AppendFormat("        Value: {0}\r\n", kvp.Value);
                                oSB.AppendLine();
                            }
                        }

                        if (oResponse.ErrorProperties.Count != 0)
                        {
                            oSB.AppendFormat("    ErrorProperties:  \r\n");
                            foreach (PropertyDefinitionBase oProps in oResponse.ErrorProperties)
                            {
                                oSB.AppendFormat("        Property: {0}\r\n", oProps.ToString());

                            }
                            oSB.AppendLine();
                        }
                        oSB.AppendLine();
                    }
                }
                else
                {   
                    //Success!!!
 
                    foreach (MoveCopyItemResponse oResponse in oResponses)
                    {

                         oSB.AppendFormat("Moved: {0}\r\n\r\n", oItemIds[0].UniqueId);

                        //if (oResponse.Item != null)
                        //{   // copy/moved item - null if between mailboxes or from mailbox to public folder.
                        //    oSB.AppendFormat("    Item - Id: {0}\r\n", oResponse.Item.Id.UniqueId);
                        //    //oSB.AppendFormat("           ParentFolderId: {0}\r\n", oResponse.Item.ParentFolderId);
                        //}
                    }
                }

                // Refresh the view
                //this.RefreshContentAndDetails();
            }
            catch (ServiceResponseException ex)
            { 
                oSB.AppendFormat("");
                oSB.AppendFormat("Error: ");
                oSB.AppendFormat("    Item: {0}\r\n", oItemIds[0]);
                oSB.AppendFormat("    Error code: {0}\r\n", ex.ErrorCode);
                oSB.AppendFormat("    Error message: {0}\r\n", ex.Message);
                oSB.AppendFormat("    Response: {0}\r\n", ex.Response);
 
                 
                StringBuilder oSB_Error = new StringBuilder();
                oSB_Error.AppendFormat("Error: ");
                oSB_Error.AppendFormat("    Item: {0}\r\n", oItemIds[0]);
                oSB_Error.AppendFormat("    Error code: {0}\r\n", ex.ErrorCode);
                oSB_Error.AppendFormat("    Error message: {0}\r\n", ex.Message);
                oSB_Error.AppendFormat("    Response: {0}\r\n", ex.Response);

                ShowTextDocument oForm = new ShowTextDocument();
                oForm.txtEntry.WordWrap = false;
                oForm.Text = "Error moving item: ";
                oForm.txtEntry.Text = oSB_Error.ToString();
                oForm.ShowDialog();

                this.Cursor = Cursors.Default;
                return false;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

             return true;
 
        }

        private void mnuDeleteItems_Click(object sender, EventArgs e)
        {
            
            _CurrentService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID. 
            this.DeleteItem(DeleteMode.HardDelete);
        }

        /// <summary>
        /// There are three different delete modes, this function is called by
        /// each of the menu events passing a different mode.
        /// </summary>
        /// <param name="mode">Type of delete to peform</param>
        private void DeleteItem(DeleteMode mode)
        {
            //try
            //{
            //    this.Cursor = Cursors.WaitCursor;

            //    ItemId id = GetSelectedContentId();
            //    if (id == null)
            //    {
            //        return;
            //    }

            //    List<ItemId> item = new List<ItemId>();
            //    item.Add(id);

            //    this.CurrentService.DeleteItems(
            //        item,
            //        mode,
            //        SendCancellationsMode.SendToAllAndSaveCopy,
            //        AffectedTaskOccurrence.AllOccurrences);

            //    // Refresh the view
            //    this.RefreshContentAndDetails();
            //}
            //finally
            //{
            //    this.Cursor = Cursors.Default;
            //}
        }

        private void mnuSoftDelete_Click(object sender, EventArgs e)
        {
            //this.CurrentService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID. 
            //this.DeleteItem(DeleteMode.SoftDelete);
        }

        private void mnuMoveToDeletedItems_Click(object sender, EventArgs e)
        {
            //this.CurrentService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID. 
            //this.DeleteItem(DeleteMode.MoveToDeletedItems);
        }

        private void lvItems_ColumnClick(object sender, ColumnClickEventArgs e)
        { 
            LvColumnSort(ref lvItems, e.Column);
        }

        private void LvColumnSort(ref ListView oListView, int iClickedColumn)
        {
            this.Cursor = Cursors.WaitCursor;

            int iLastColumn = (int)oListView.Tag;
            if (iClickedColumn != iLastColumn)  //Already sorted On the clicked column?
            {
                iLastColumn = iClickedColumn;
                oListView.Tag = iLastColumn;
                oListView.Sorting = SortOrder.Ascending;
            }
            else
            {
                if (oListView.Sorting == SortOrder.Ascending)  // togle sort order if same column clicked
                    oListView.Sorting = SortOrder.Descending;
                else
                    oListView.Sorting = SortOrder.Ascending;
            }
            oListView.Sort();
            oListView.ListViewItemSorter = new EWSEditor.Common.UIHelpers.ListViewItemComparer_Dates(iClickedColumn, oListView.Sorting);
            this.Cursor = Cursors.Default;
        }

        private void btnExportCalendarItems_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Exporting...";
            this.Cursor = Cursors.WaitCursor;
            ExportItems();
            MessageBox.Show("The data export has completed.", "Export finished.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            toolStripStatusLabel1.Text = "Ready to search.";
            this.Cursor = Cursors.Default;
        }

        private void ExportItems()
        { 

            EWSEditor.Forms.Searches.SearchExportPicker oForm = new EWSEditor.Forms.Searches.SearchExportPicker();
            oForm.ShowDialog();

            this.Cursor = Cursors.WaitCursor;

            List<AdditionalPropertyDefinition> oAdditionalPropertyDefinitions = null;
            List<ExtendedPropertyDefinition> oExtendedPropertyDefinitions = null;

            CsvExportOptions oCsvExportOptions = new CsvExportOptions();

            oCsvExportOptions = oForm.ExportOptions;


            if (oForm.bChoseOk == true)
            {

                if (oForm.chkIncludeUsersAdditionalProperties.Checked == true)
                {
                    oAdditionalPropertyDefinitions = oForm.AdditionalPropertyDefinitions;
                    oExtendedPropertyDefinitions = oForm.ExtendedPropertyDefinitions;
                }

                if (oForm.rdoExportDisplayedResults.Checked == true)
                {
                    string sPath = oForm.txtDisplayedResultsFolderPath.Text.Trim();
                    string sRoot = Path.GetPathRoot(sPath);

                    if (CheckFolder(sRoot))
                    {
                        if (File.Exists(sPath))
                        {
                            MessageBox.Show("File Already Exists", "File already exists.  Choose a different file name.");
                        }
                        else
                        {
                            ExportDisplayedResults(_CurrentService, sPath, oAdditionalPropertyDefinitions, oExtendedPropertyDefinitions, oCsvExportOptions);


                        }
                    }
                }

  


                if (oForm.rdoExportItemsAsBlobs.Checked == true)
                {

                    if (CheckFolder(oForm.txtBlobFolderPath.Text.Trim()))
                        ExportItemsAsBlobs(oForm.txtBlobFolderPath.Text.Trim());
                }

            }

            this.Cursor = Cursors.Default;

        }


        private bool CheckFolder(string sFolderPath)
        {
            // validate folder path is correct.
            if (System.IO.Directory.Exists(sFolderPath) == false)
            {
                DialogResult oDlg = MessageBox.Show("Create Folder", "The folder path chosen does not exist.  Do you wish to create this folder?", MessageBoxButtons.YesNo);
                if (oDlg == System.Windows.Forms.DialogResult.Yes)
                {
                    System.IO.Directory.CreateDirectory(sFolderPath);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        private void ExportDisplayedResults(
            ExchangeService oExchangeService,
            string sFolderPath,
            List<EWSEditor.Common.Exports.AdditionalPropertyDefinition> oAdditionalPropertyDefinitions,
            List<ExtendedPropertyDefinition> oExtendedPropertyDefinitions,
             CsvExportOptions oCsvExportOptions
            )
        {
             
            ListViewExport.SaveItemListViewToCsv(oExchangeService, lvItems, sFolderPath, oAdditionalPropertyDefinitions, oExtendedPropertyDefinitions, oCsvExportOptions);
        }

        /// ExportItemsAsBlobs()
        /// Save all items in grid as blobs. These can be reloaded later with EWSEditor.
        private bool ExportItemsAsBlobs(string sFolderPath)
        {
            bool bRet = false;
            EWSEditor.Common.Exports.CalendarExport oCalendarExport = new EWSEditor.Common.Exports.CalendarExport();
            EWSEditor.Common.Exports.MeetingMessageExport oMeetingMessageExport = new EWSEditor.Common.Exports.MeetingMessageExport();


            ItemId oItemId = null;
            ItemTag oItemTag = null;
            string sFile = string.Empty;
            string sFilePath = string.Empty;
            int iCount = 0;
            string s = string.Empty;
            string sId = string.Empty;
            string sUID = string.Empty;
            string sClass = string.Empty;
            string sSubject = string.Empty;
            char[] c = Path.GetInvalidFileNameChars();

            foreach (ListViewItem oListViewItem in lvItems.Items)
            {
                if (oListViewItem.Selected == true)
                {
                    iCount++;
                    oItemTag = (ItemTag)oListViewItem.Tag;
                    sId = oItemTag.Id.UniqueId;
                    //sUID = oItemTag.ItemUid;
                    sClass = oItemTag.ItemClass.ToUpper();
                    oItemId = new ItemId(sId);
 
                    sSubject = FileHelper.SanitizeFileName(oListViewItem.SubItems[1].Text);
                    sFile = sSubject + "-" + sClass + "-" + iCount.ToString() + ".bin";

                    sFilePath = Path.Combine(sFolderPath, sFile);

                    SaveItemBlobToFolder(_CurrentService, oItemId, sFilePath);

                    bRet = true;
                }
            }

            return bRet;
        }

        public bool SaveItemBlobToFolder(ExchangeService oExchangeService, ItemId oItemId, string sFile)
        {
            string ServerVersion = oExchangeService.RequestedServerVersion.ToString();
            if (ServerVersion.StartsWith("Exchange2007") || ServerVersion == "Exchange2010")
            {
                MessageBox.Show("Exchange 2010 SP1 or later is requred to use ExportItems to do a blog export of an item.", "Invalid version for blog export using ExportItem");
                return false;
            }

            return EWSEditor.Exchange.ExportUploadHelper.ExportItemPost(ServerVersion, oItemId.UniqueId, sFile);

        }
    }
}
