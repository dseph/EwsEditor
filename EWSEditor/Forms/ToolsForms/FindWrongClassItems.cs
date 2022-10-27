using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.Forms.ToolsForms
{
    public partial class FindWrongClassItems : Form
    {
  
        private PropertySet CurrentPropertySet = new PropertySet();
        private FolderId CurrentFolderId;
        private ExchangeService _Service;

        public FindWrongClassItems()
        {
            InitializeComponent();
        }

        public FindWrongClassItems(ExchangeService oService)
        {
            InitializeComponent();
            _Service = oService;
        }


        private void btnGetFolderId_Click(object sender, EventArgs e)
        {

            FolderIdDialog oForm = new FolderIdDialog(_Service);
            oForm.ShowDialog();
            if (oForm.ChoseOK == true)
            {
                SetAndDisplayFolderId(oForm.ChosenFolderId);
            }

        }
        private void SetAndDisplayFolderId(FolderId folderId)
        {
            this.txtFolderId.Text = PropertyInformation.TypeValues.FolderIdTypeValue.GetValue(folderId, true);
            this.CurrentFolderId = folderId;
 
            // Reset form elements

            this.lstErrors.Items.Clear();
            //this.txtErrorInfo.Text = string.Empty;
        }
        private void btnRunTest_Click(object sender, EventArgs e)
        {
            if (CurrentFolderId == null)
                MessageBox.Show("Entry Error", "Folder must be selected.");
            else
                DoSearch();
        }
        private SearchFilter GetItemFilter(string sItemClass)
        {
            SearchFilter oFilter = new SearchFilter.Not (new SearchFilter.ContainsSubstring(ItemSchema.ItemClass,
                    sItemClass, ContainmentMode.Substring, ComparisonMode.IgnoreCase));
           
            return oFilter;
        }


        private void DoSearch()
        {
            //    Guid SearchTestGUID = new Guid("{AA3DF801-4FC7-401F-BBC1-7C93D6498C2E}");
            //    ExtendedPropertyDefinition customPropDefinition =
            //        new ExtendedPropertyDefinition(SearchTestGUID, "ItemIndex", MapiPropertyType.Integer);

            ExtendedPropertyDefinition Prop_PR_IS_HIDDEN = new ExtendedPropertyDefinition(0x10f4, MapiPropertyType.Boolean);
            //PropertySet propSet = new PropertySet(Prop_PR_IS_HIDDEN);

            int MaxToProcess = Int32.Parse(textMax.Text.Trim());


            this.lstErrors.Items.Clear(); 
            this.txtErrorInfo.Text = string.Empty;

 
            //SearchFilter notsearchFilter = new SearchFilter.Not(new SearchFilter.ContainsSubstring(ItemSchema.ItemClass, "IPM.Note"));

           

            // Search filters:
            SearchFilter.SearchFilterCollection compoundFilter = new SearchFilter.SearchFilterCollection(LogicalOperator.And);
            if (txtType1.Text.Trim() != string.Empty)
                compoundFilter.Add(GetItemFilter(txtType1.Text.Trim()));
            if (txtType2.Text.Trim() != string.Empty)
                compoundFilter.Add(GetItemFilter(txtType2.Text.Trim()));
            if (txtType3.Text.Trim() != string.Empty)
                compoundFilter.Add(GetItemFilter(txtType3.Text.Trim()));
            if (txtType4.Text.Trim() != string.Empty)
                compoundFilter.Add(GetItemFilter(txtType4.Text.Trim()));
            if (txtType5.Text.Trim() != string.Empty)
                compoundFilter.Add(GetItemFilter(txtType5.Text.Trim()));
            if (txtType6.Text.Trim() != string.Empty)
                compoundFilter.Add(GetItemFilter(txtType6.Text.Trim()));
            if (txtType7.Text.Trim() != string.Empty)
                compoundFilter.Add(GetItemFilter(txtType7.Text.Trim()));
            if (txtType8.Text.Trim() != string.Empty)
                compoundFilter.Add(GetItemFilter(txtType8.Text.Trim()));
            if (txtType9.Text.Trim() != string.Empty)
                compoundFilter.Add(GetItemFilter(txtType9.Text.Trim()));
            if (txtType10.Text.Trim() != string.Empty)
                compoundFilter.Add(GetItemFilter(txtType10.Text.Trim()));


            //SearchFilter.SearchFilterCollection compoundFilter =
            //    new SearchFilter.SearchFilterCollection(LogicalOperator.And, testFilter1, testFilter2);

            // Searching for items which do not satisfy the above.
            //SearchFilter.Not TestingFilter = new SearchFilter.Not(compoundFilter);

            PropertySet oPropertySet = new PropertySet(
                ItemSchema.ItemClass,
                ItemSchema.Subject,
                Prop_PR_IS_HIDDEN
                );

            int offset = 0;
            const int pageSize = 100;
            bool MoreItems = true;

            ItemView oView = new ItemView(pageSize + 1, offset);
            oView.PropertySet = oPropertySet;
            oView.Traversal = ItemTraversal.Shallow;

            oView.OrderBy.Add(ItemSchema.ItemClass, SortDirection.Descending);


            ItemId anchorId = null;

            ListViewItem oListItem = null;
            ListViewItem.ListViewSubItem oLVSI = null;
            bool isHidden = true;

            this.Cursor = Cursors.WaitCursor;
            bool bTimeToExit = false;
            int iCount = 0;

            while (MoreItems && bTimeToExit == false)
            {
                try
                {
                    FindItemsResults<Item> results = _Service.FindItems(CurrentFolderId, compoundFilter, oView);
                    MoreItems = results.MoreAvailable;
                    //if (MoreItems && anchorId != null)
                    //{
                    //    // Check the first result to make sure it matches
                    //    // the last result (anchor) from the previous page.
                    //    // If it doesn't, that means that something was added
                    //    // or deleted since you started the search.
                    //    if (results.Items.First<Item>().Id != anchorId)
                    //    {
                    //        Console.WriteLine("The collection has changed while paging. Some results may be missed.");
                    //        MessageBox.Show("The collection has changed while paging. Some results may be missed.", "Warning");
                    //    }
                    //}
                    if (MoreItems)
                        oView.Offset += pageSize;

                    //anchorId = results.Items.Last<Item>().Id;

                    // Because you're including an additional item on the end of your results
                    // as an anchor, you don't want to display it.
                    // Set the number to loop as the smaller value between
                    // the number of items in the collection and the page size.
                    int displayCount = 0;

                    if ((results.MoreAvailable == false && results.Items.Count > pageSize) || (results.Items.Count < pageSize))
                    {
                        displayCount = results.Items.Count;
                    }
                    else
                    {
                        displayCount = pageSize;
                    }

                    for (int i = 0; i < displayCount; i++)
                    {
                        iCount++;

                        Item oItem = results.Items[i];
                        //Console.WriteLine("Subject: {0}", item.Subject);
                        //Console.WriteLine("Id: {0}\n", item.Id.ToString());
 
                        lblStatus.Text = iCount.ToString();
                        lblStatus.Update();

                        oItem.TryGetProperty(Prop_PR_IS_HIDDEN, out isHidden);
                        oListItem = new ListViewItem(isHidden.ToString(), 0);    // 1
 

                        oLVSI = oListItem.SubItems.Add(oItem.ItemClass);
                        //oLVSI.Tag = "String";

                        oLVSI = oListItem.SubItems.Add(oItem.Subject);
                        //oLVSI.Tag = "String";

                        oLVSI = oListItem.SubItems.Add(oItem.Id.ToString());
                        //oLVSI.Tag = "String";
                        oLVSI = null;

                        //oListItem.Tag = new ItemTag(oItem.Id, oItem.ItemClass);
                        lstErrors.Items.AddRange(new ListViewItem[] { oListItem }); ;
                        oListItem = null;

                         

                        if (MaxToProcess != 0 && MaxToProcess == iCount)
                        {
                            bTimeToExit = true;
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Error while paging results"   );
                    MoreItems = false;
                }


 
            }

            this.Cursor = Cursors.Default;
            MessageBox.Show("Search complete.", "Processing finished.");
        }

 

        private void btnMessageFolderSet_Click(object sender, EventArgs e)
        {
            txtType1.Text = "IPM.Note";
            txtType2.Text = "IPM.Schedule";
            txtType3.Text = "";
            txtType4.Text = "";
            txtType5.Text = "";
            txtType6.Text = "";
            txtType7.Text = "";
            txtType8.Text = "";
            txtType9.Text = "";
            txtType10.Text = "";
        }

        private void btnCalendarFolderSet_Click(object sender, EventArgs e)
        {
            txtType1.Text = "IPM.Appointment";
            txtType2.Text = "";
            txtType3.Text = "";
            txtType4.Text = "";
            txtType5.Text = "";
            txtType6.Text = "";
            txtType7.Text = "";
            txtType8.Text = "";
            txtType9.Text = "";
            txtType10.Text = "";
        }

        private void btnContactsFolderSet_Click(object sender, EventArgs e)
        {
            txtType1.Text = "IPM.Contact";
            txtType2.Text = "";
            txtType3.Text = "";
            txtType4.Text = "";
            txtType5.Text = "";
            txtType6.Text = "";
            txtType7.Text = "";
            txtType8.Text = "";
            txtType9.Text = "";
            txtType10.Text = "";
        }

        private void FindWrongClassItems_Load(object sender, EventArgs e)
        {
            string sText = "This window is used to find items which do not have an appropriate item class in the selected folder.  " +
                " Items which are of the wrong type for a folder can cause issues with API calls and break applications. " +
                "APIs and applications expect certain data in items in folders and if its not what is epexpected then the calling API may throw an error and such " +
                "happens if the wrong type of item is in a folder - like a calendar item in the inbox or an email in the calendar folder." +
                "The item class should be appropriate for the folder - for example an IPM.Note and IPM.Schedule is appropriate for the inbox but not an IPM.Calendar type.  " +
                "This window will search for items which do NOT have item classes containing specified text and will display them so that you can identify problem ones. " +
                "This means you should specify the message classes you want this search to ignore.  " +
                "Hidden items should be ignored by code unless the item belogs to the application invovled.";
            txtHelp.Text = sText;

            lstErrors.Tag = -1;
        }

        private void lstErrors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstErrors.SelectedItems.Count > 0)
            {
                string sInfo =
                    "IsHidden:  " + lstErrors.SelectedItems[0].SubItems[0].Text + "\r\n" +
                    "ItemClass: " + lstErrors.SelectedItems[0].SubItems[1].Text + "\r\n" +
                    "Subject:   " + lstErrors.SelectedItems[0].SubItems[2].Text + "\r\n" +
                    "Id:        " + lstErrors.SelectedItems[0].SubItems[3].Text + "\r\n";
                txtErrorInfo.Text = sInfo;
            }
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

        private void lstErrors_DoubleClick(object sender, EventArgs e)
        {
            if (lstErrors.SelectedItems.Count > 0)
            {

                string sItem = lstErrors.SelectedItems[0].SubItems[3].Text;
                ItemId itemId = new ItemId(sItem);

                List<ItemId> item = new List<ItemId>();
                item.Add(itemId);

                ItemsContentForm.Show(
                    "Displaying item by ItemId",
                    item,
                    _Service,
                    this);

            }
        }

        private void lstErrors_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //LvColumnSort(ref lstErrors, e.Column);
        }

        private void textMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)  )
            {
                e.Handled = true;
            }
        }

        private void textMax_Validating(object sender, CancelEventArgs e)
        {
            if (textMax.Text.Trim() == string.Empty)
                textMax.Text = "0";
        }
    }
}
