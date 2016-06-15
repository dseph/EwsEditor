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
    public partial class SearchForm : Form
    {
        public bool ChoseOK = false;
        private ExchangeService _CurrentService = null;
        private FolderId _CurrentFolderId = null;

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

                this.chkSubject.Enabled = false;
                this.chkTo.Enabled = false;
                this.chkCC.Enabled = false;
                this.chkBody.Enabled = false;
                this.txtClass.Enabled = false;
                this.chkClass.Enabled = false;

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
            txtAQS.Enabled = this.rdoAqsSearch.Enabled;
        }

        private void chkSubject_CheckedChanged(object sender, EventArgs e)
        {
            txtSubject.Enabled = chkSubject.Enabled;
        }

        private void chkTo_CheckedChanged(object sender, EventArgs e)
        {
            txtTo.Enabled = chkTo.Enabled;
        }

        private void chkCC_CheckedChanged(object sender, EventArgs e)
        {
            txtCC.Enabled = chkCC.Enabled;
        }

        private void ProcessSearch(FolderId oFolderId, int iPageSize)
        {
            int iCount = 0;

            if (oFolderId != null)
            {
 
                FindItemsResults<Item> oFindItemsResults = null;

                if (this.cmboSearchType.Text == "Direct")
                {
                    List<SearchFilter> searchFilterCollection = new List<SearchFilter>();
                    ItemView oItemView = new ItemView(iPageSize);
                    oItemView.PropertySet = new PropertySet(BasePropertySet.IdOnly,
                                        ItemSchema.Subject,
                                        ItemSchema.DisplayTo,
                                        ItemSchema.Subject,
                                        ItemSchema.DisplayCc,
                                        ItemSchema.DateTimeReceived,
                                        ItemSchema.HasAttachments,
                                        ItemSchema.ItemClass
                                        );

                    // Examples of requesting extended properties:
                    //oItemView.PropertySet.Add(new ExtendedPropertyDefinition(0x1000, MapiPropertyType.String)); // PR_BODY
                    //oItemView.PropertySet.Add(new ExtendedPropertyDefinition(0x1035, MapiPropertyType.String)); // CdoPR_INTERNET_MESSAGE_ID 
                    //oItemView.PropertySet.Add(new ExtendedPropertyDefinition(0x0C1A, MapiPropertyType.String)); // CdoPR_SENDER_NAME

                    oItemView.OrderBy.Add(ItemSchema.DateTimeReceived, SortDirection.Descending);
                    oItemView.Traversal = ItemTraversal.Shallow; // shallow, associated, soft deleted
 
                    if (this.rdoAqsSearch.Checked == true)
                    {
                        oFindItemsResults = _CurrentService.FindItems(oFolderId, this.txtAQS.Text, oItemView);

                    }
                    else
                    {
                        if (this.chkClass.Checked == true)
                            if (this.txtClass.Text.Length != 0)
                                searchFilterCollection.Add(new SearchFilter.ContainsSubstring(ItemSchema.ItemClass, this.txtClass.Text));
                        if (this.chkSubject.Checked == true)
                            if (this.txtSubject.Text.Length != 0)
                                searchFilterCollection.Add(new SearchFilter.ContainsSubstring(ItemSchema.Subject, this.txtSubject.Text));
                        if (this.chkTo.Checked == true)
                            if (this.txtTo.Text.Length != 0)
                                searchFilterCollection.Add(new SearchFilter.ContainsSubstring(ItemSchema.DisplayTo, this.txtTo.Text));
                        if (this.chkCC.Checked == true)
                            if (this.txtCC.Text.Length != 0)
                                searchFilterCollection.Add(new SearchFilter.ContainsSubstring(ItemSchema.DisplayCc, this.txtCC.Text));
                        if (this.chkBody.Checked == true)
                            if (this.txtBody.Text.Length != 0)
                                searchFilterCollection.Add(new SearchFilter.ContainsSubstring(ItemSchema.Body, this.txtBody.Text));


                        SearchFilter searchFilter = new SearchFilter.SearchFilterCollection(LogicalOperator.Or, searchFilterCollection.ToArray());

                        oFindItemsResults = _CurrentService.FindItems(oFolderId, searchFilter, oItemView);

                    }

                    lvItems.Clear();
                    lvItems.View = View.Details;
                    lvItems.GridLines = true;
                    //lvItems.Dock = DockStyle.Fill;

                    lvItems.Columns.Add("Frame:Count", 100, HorizontalAlignment.Left);
                    lvItems.Columns.Add("Subject", 170, HorizontalAlignment.Left);
                    lvItems.Columns.Add("Class", 150, HorizontalAlignment.Left);
                    lvItems.Columns.Add("DisplayTo", 100, HorizontalAlignment.Left);
                    lvItems.Columns.Add("Attatch", 50, HorizontalAlignment.Left);
                    //lvItems.Columns.Add("Id", 50, HorizontalAlignment.Left);
                    lvItems.Columns.Add("UniqueId", 250, HorizontalAlignment.Left);
                    lvItems.Columns.Add("ChangeKey", 250, HorizontalAlignment.Left);
 

                    ListViewItem oListItem = null;
                    iCount = 0;
                    foreach (Item oItem in oFindItemsResults.Items)
                    {
                        iCount++;
                        //if (oItem is EmailMessage || oItem is MeetingRequest || oItem is Contact)
                        //{
                            oListItem = new ListViewItem(iCount.ToString(), 0);
                                
                            oListItem.SubItems.Add(oItem.Subject);
                            oListItem.SubItems.Add(oItem.ItemClass);
                            oListItem.SubItems.Add(oItem.DisplayTo);
                            oListItem.SubItems.Add(oItem.HasAttachments.ToString());
                            oListItem.SubItems.Add(oItem.Id.UniqueId);
                            oListItem.SubItems.Add(oItem.Id.ChangeKey);

                            oListItem.Tag = new ItemTag(oItem.Id, oItem.ItemClass);
                            lvItems.Items.AddRange(new ListViewItem[] { oListItem }); ;
                            oListItem = null;
                        //}

                    }

                    oListItem = null;
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
                    lvItems.Columns.Add("Attatch", 50, HorizontalAlignment.Left);
                    //lvItems.Columns.Add("Id", 50, HorizontalAlignment.Left);
                    lvItems.Columns.Add("UniqueId", 250, HorizontalAlignment.Left);
                    lvItems.Columns.Add("ChangeKey", 250, HorizontalAlignment.Left);

                    int iCountMore = 0;

                    while (MoreItems)
                    {
                        iCountMore++;

                        List<SearchFilter> searchFilterCollection = new List<SearchFilter>();
                        ItemView oItemView = new ItemView(iPageSize, offset, OffsetBasePoint.Beginning);
                        oItemView.PropertySet = new PropertySet(BasePropertySet.IdOnly,
                                            ItemSchema.Subject,
                                            ItemSchema.DisplayTo,
                                            ItemSchema.DisplayCc,
                                            ItemSchema.DateTimeReceived,
                                            ItemSchema.HasAttachments,
                                            ItemSchema.ItemClass
                                            );

                        // Examples of requesting extended properties:
                        //oItemView.PropertySet.Add(new ExtendedPropertyDefinition(0x1000, MapiPropertyType.String)); // PR_BODY
                        //oItemView.PropertySet.Add(new ExtendedPropertyDefinition(0x1035, MapiPropertyType.String)); // CdoPR_INTERNET_MESSAGE_ID 
                        //oItemView.PropertySet.Add(new ExtendedPropertyDefinition(0x0C1A, MapiPropertyType.String)); // CdoPR_SENDER_NAME

                        oItemView.OrderBy.Add(ContactSchema.DisplayName, SortDirection.Ascending);
                        oItemView.Traversal = ItemTraversal.Shallow; // shallow, associated, soft deleted

                        if (this.rdoAqsSearch.Checked == true)
                        {
                            oFindItemsResults = _CurrentService.FindItems(oFolderId, this.txtAQS.Text, oItemView);

                        }
                        else
                        {
                            if (this.chkClass.Checked == true)
                                if (this.txtClass.Text.Length != 0)
                                    searchFilterCollection.Add(new SearchFilter.ContainsSubstring(ItemSchema.ItemClass, this.txtClass.Text));
                            if (this.chkSubject.Checked == true)
                                if (this.txtSubject.Text.Length != 0)
                                    searchFilterCollection.Add(new SearchFilter.ContainsSubstring(ItemSchema.Subject, this.txtSubject.Text));
                            if (this.chkTo.Checked == true)
                                if (this.txtTo.Text.Length != 0)
                                    searchFilterCollection.Add(new SearchFilter.ContainsSubstring(ItemSchema.DisplayTo, this.txtTo.Text));
                            if (this.chkCC.Checked == true)
                                if (this.txtCC.Text.Length != 0)
                                    searchFilterCollection.Add(new SearchFilter.ContainsSubstring(ItemSchema.DisplayCc, this.txtCC.Text));
                            if (this.chkBody.Checked == true)
                                if (this.txtBody.Text.Length != 0)
                                    searchFilterCollection.Add(new SearchFilter.ContainsSubstring(ItemSchema.Body, this.txtBody.Text));

                            SearchFilter searchFilter = new SearchFilter.SearchFilterCollection(LogicalOperator.Or, searchFilterCollection.ToArray());

                            oFindItemsResults = _CurrentService.FindItems(oFolderId, searchFilter, oItemView);

                        }

 
                        iCount = 0;
                        foreach (Item oItem in oFindItemsResults.Items)
                        {
                            iCount++;
                             
                            //if (oItem is EmailMessage || oItem is MeetingRequest || oItem is Contact)
                            //{

                                oListItem = new ListViewItem(iCountMore.ToString() + ":" +iCount.ToString(), 0);

                                oListItem.SubItems.Add(oItem.Subject);
                                oListItem.SubItems.Add(oItem.ItemClass);
                                oListItem.SubItems.Add(oItem.DisplayTo);
                                oListItem.SubItems.Add(oItem.HasAttachments.ToString());
                                oListItem.SubItems.Add(oItem.Id.UniqueId);
                                oListItem.SubItems.Add(oItem.Id.ChangeKey);
 

                                oListItem.Tag = new ItemTag(oItem.Id, oItem.ItemClass);
                                lvItems.Items.AddRange(new ListViewItem[] { oListItem }); ;
                                oListItem = null;
                            //}
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


                }
            }
 
 

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
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
            this.txtBody.Enabled = this.chkBody.Enabled;
        }

        private void btnMailboxSearch_Click(object sender, EventArgs e)
        {
            //DoMailboxSearch();
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
     
                string sId = lvItems.SelectedItems[0].SubItems[5].Text;
                ItemId oItemId = new ItemId(sId);


                List<ItemId> item = new List<ItemId>();
                item.Add(oItemId);

                ItemsContentForm.Show(
                    "Displaying item",
                    item,
                    _CurrentService,
                    this);
            }
        }
    }
}
