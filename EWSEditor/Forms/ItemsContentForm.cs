using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;


using EWSEditor.Common;
using EWSEditor.Exchange;
using EWSEditor.Logging;
using EWSEditor.Resources;
using EWSEditor.Settings;
using System.Net;
using System.Xml;
using Microsoft.Exchange.WebServices.Data;

 

namespace EWSEditor.Forms
{

    public partial class ItemsContentForm : BaseContentForm
    {
        protected const string ColNameSubject = "colSubject";
        protected const string ColNameDisplayTo = "colDisplayTo";
        protected const string ColNameItemClass = "colItemClass";
        protected const string ColNameSize = "colSize";
        protected const string ColNameHasAttach = "colHasAttachments";
        protected const string ColNameDateReceived = "colDateReceived";
        protected const string ColNameDateCreated = "colDateCreated";
        protected const string ColNameDateSent = "colDateSent";
        protected const string ColNameLastModifiedTime = "colLastModifiedTime";
        protected const string ColNameLastModifiedName = "colLastModifiedName";
        protected const string ColNameIsAssociated = "colIsAssociated";
        protected const string ColNameSensitivity = "colSensitivity";
        protected const string ColNameDisplayCc = "colDisplayCC";
        protected const string ColNameCategories = "colCategories";
        protected const string ColNameCulture = "colCulture";
        protected const string ColNameItemId = "colItemId";
        //protected const string ColNameItemId = "colTimeZone";

        private List<ItemId> currentItemIds = new List<ItemId>();
        private ItemView contentItemView = new ItemView(GlobalSettings.FindItemViewSize);

        protected ItemsContentForm()
        {
            InitializeComponent();
        }

        protected List<ItemId> CurrentItemIds
        {
            get
            {
                return this.currentItemIds;
            }
        }

        protected ItemView ContentItemView
        {
            get
            {
                return this.contentItemView;
            }
        }

        /// <summary>
        /// Load the form with each of the Items specified in the
        /// ItemId list instead of displaying the contents of a folder.
        /// </summary>
        /// <param name="caption">Text to display in form caption</param>
        /// <param name="itemIds">ItemIds of items to be displayed.</param>
        /// <param name="service">ExchangeService to use.</param>
        /// <param name="parentForm">Parent form that called this method.</param>
        public static void Show(
            string caption,
            List<ItemId> itemIds,
            ExchangeService service,
            Form parentForm)
        {
            ItemsContentForm form = new ItemsContentForm();

            form.CurrentService = service;
            form.PropertyDetailsGrid.CurrentService = service;
            form.currentItemIds = itemIds;
            form.Text = caption;
            form.CallingForm = parentForm;
            form.Show();
        }

        protected override void SetupForm()
        {
            this.ContentIdColumnName = ColNameItemId;
            this.DefaultDetailPropertySet = new PropertySet(BasePropertySet.FirstClassProperties);

            // Create the folder contents property set, including specifying *only*
            // the properties to be displayed in the data grid in order to get the
            // best response time possible.
            this.contentItemView.PropertySet = new PropertySet(BasePropertySet.IdOnly);
            this.contentItemView.PropertySet.Add(ItemSchema.Subject);
            this.contentItemView.PropertySet.Add(ItemSchema.DisplayTo);
            this.contentItemView.PropertySet.Add(ItemSchema.ItemClass);
            this.contentItemView.PropertySet.Add(ItemSchema.Size);
            this.contentItemView.PropertySet.Add(ItemSchema.HasAttachments);
            this.contentItemView.PropertySet.Add(ItemSchema.DateTimeCreated);
            this.contentItemView.PropertySet.Add(ItemSchema.DateTimeReceived);
            this.contentItemView.PropertySet.Add(ItemSchema.DateTimeSent);
            this.contentItemView.PropertySet.Add(ItemSchema.LastModifiedTime);
            this.contentItemView.PropertySet.Add(ItemSchema.LastModifiedName);

            // IsAssociated is not supported in Exchange 2007
            if (this.CurrentService != null &&
                this.CurrentService.RequestedServerVersion != ExchangeVersion.Exchange2007_SP1)
            {
                this.contentItemView.PropertySet.Add(ItemSchema.IsAssociated);
            }

            this.contentItemView.PropertySet.Add(ItemSchema.Sensitivity);
            this.contentItemView.PropertySet.Add(ItemSchema.DisplayCc);
            this.contentItemView.PropertySet.Add(ItemSchema.Categories);
            this.contentItemView.PropertySet.Add(ItemSchema.Culture);

            // Setup the this.ContentsGrid with columns for displaying item collections
            int col = 0;
            col = this.ContentsGrid.Columns.Add(ColNameSubject, "Subject");
            this.ContentsGrid.Columns[col].Width = 175;

            col = this.ContentsGrid.Columns.Add(ColNameDisplayTo, "DisplayTo");
            this.ContentsGrid.Columns[col].Width = 125;

            col = this.ContentsGrid.Columns.Add(ColNameItemClass, "ItemClass");
            this.ContentsGrid.Columns[col].Width = 175;

            col = this.ContentsGrid.Columns.Add(ColNameSize, "Size");
            this.ContentsGrid.Columns[col].Width = 50;

            col = this.ContentsGrid.Columns.Add(ColNameHasAttach, "HasAttachments");
            this.ContentsGrid.Columns[col].Width = 50;

            col = this.ContentsGrid.Columns.Add(ColNameDateReceived, "DateTimeReceived");
            this.ContentsGrid.Columns[col].ValueType = typeof(DateTime);
            this.ContentsGrid.Columns[col].Width = 150;

            col = this.ContentsGrid.Columns.Add(ColNameDateCreated, "DateTimeCreated");
            this.ContentsGrid.Columns[col].ValueType = typeof(DateTime);
            this.ContentsGrid.Columns[col].Width = 150;

            col = this.ContentsGrid.Columns.Add(ColNameDateSent, "DateTimeSent");
            this.ContentsGrid.Columns[col].ValueType = typeof(DateTime);
            this.ContentsGrid.Columns[col].Width = 150;

            col = this.ContentsGrid.Columns.Add(ColNameLastModifiedTime, "LastModifiedTime");
            this.ContentsGrid.Columns[col].ValueType = typeof(DateTime);
            this.ContentsGrid.Columns[col].Width = 150;

            col = this.ContentsGrid.Columns.Add(ColNameLastModifiedName, "LastModifiedName");
            this.ContentsGrid.Columns[col].Width = 125;

            col = this.ContentsGrid.Columns.Add(ColNameIsAssociated, "IsAssociated");
            this.ContentsGrid.Columns[col].Width = 75;

            col = this.ContentsGrid.Columns.Add(ColNameSensitivity, "Sensitivity");
            this.ContentsGrid.Columns[col].Width = 75;

            col = this.ContentsGrid.Columns.Add(ColNameDisplayCc, "DisplayCC");
            this.ContentsGrid.Columns[col].Width = 125;

            col = this.ContentsGrid.Columns.Add(ColNameCategories, "Categories");
            this.ContentsGrid.Columns[col].Width = 150;

            col = this.ContentsGrid.Columns.Add(ColNameCulture, "Culture");
            this.ContentsGrid.Columns[col].Width = 50;

            col = this.ContentsGrid.Columns.Add(ColNameItemId, "ItemId");
            this.ContentsGrid.Columns[col].Visible = false;
        }

        protected override void LoadContents()
        {
            // Make one call to get all the items.
            ServiceResponseCollection<GetItemResponse> getItems = this.CurrentService.BindToItems(
                this.currentItemIds.ToArray(), 
                this.contentItemView.PropertySet);

            // Convert the GetItemResponseCollection to an Item list.
            List<Item> items = new List<Item>();
            foreach (GetItemResponse getItem in getItems)
            {
                if (getItem.Item != null)
                {
                    Item item = getItem.Item as Item;

                    if (item != null)
                    {
                        this.AddContentItem(item);
                    }
                    else
                    {
                        DebugLog.WriteVerbose("GetItemResponse.Item is not an Item.");
                    }
                }
                else
                {
                    DebugLog.WriteVerbose(String.Format("GetItemResponse.Item is null, GetItemResponse.ErrorCode is {0}.", getItem.ErrorCode.ToString()));
                }
            }
        }

        protected override void LoadSelectionDetails()
        {
            // Only load details if a content row is selected
            if (this.ContentsGrid.SelectedRows.Count == 0 ||
                this.GetSelectedContentId().Length == 0)
            {
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                Item details = EWSEditor.Forms.FormsUtil.PerformRetryableItemBind(
                    this.CurrentService,
                    new ItemId(this.GetSelectedContentId()),
                    this.CurrentDetailPropertySet);

                if (details != null)
                {
                    this.PropertyDetailsGrid.LoadObject(details);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Add the given item to the ContentsGrid
        /// </summary>
        /// <param name="item">Item to add</param>
        protected void AddContentItem(Item item)
        {
            // TODO: Add Try/Catch blocks
            int row = this.ContentsGrid.Rows.Add();
            this.ContentsGrid.Rows[row].Cells[ColNameSubject].Value = item.Subject;
            this.ContentsGrid.Rows[row].Cells[ColNameDisplayTo].Value = item.DisplayTo;
            this.ContentsGrid.Rows[row].Cells[ColNameItemClass].Value = item.ItemClass;
            this.ContentsGrid.Rows[row].Cells[ColNameSize].Value = item.Size;
            this.ContentsGrid.Rows[row].Cells[ColNameHasAttach].Value = item.HasAttachments;

            try
            {
                this.ContentsGrid.Rows[row].Cells[ColNameDateReceived].Value = item.DateTimeReceived.ToString();
            }
            catch (Exception ex)
            {
                DebugLog.WriteVerbose("Handled exception when getting DateTimeReceived", ex);
                this.ContentsGrid.Rows[row].Cells[ColNameDateReceived].Value = ex.Message;
            }

            this.ContentsGrid.Rows[row].Cells[ColNameDateCreated].Value = item.DateTimeCreated.ToString();

            try
            {
                this.ContentsGrid.Rows[row].Cells[ColNameDateSent].Value = item.DateTimeSent.ToString();
            }
            catch (Exception ex)
            {
                DebugLog.WriteVerbose("Handled exception when getting DateTimeSent", ex);
                this.ContentsGrid.Rows[row].Cells[ColNameDateSent].Value = ex.Message;
            }

            this.ContentsGrid.Rows[row].Cells[ColNameLastModifiedTime].Value = item.LastModifiedTime.ToString();
            this.ContentsGrid.Rows[row].Cells[ColNameLastModifiedName].Value = item.LastModifiedName;

            try
            {
                this.ContentsGrid.Rows[row].Cells[ColNameIsAssociated].Value = item.IsAssociated;
            }
            catch (Exception ex)
            {
                DebugLog.WriteVerbose("Handled exception when getting IsAssociated", ex);
                this.ContentsGrid.Rows[row].Cells[ColNameIsAssociated].Value = ex.Message;
            }

            this.ContentsGrid.Rows[row].Cells[ColNameSensitivity].Value = item.Sensitivity;
            this.ContentsGrid.Rows[row].Cells[ColNameDisplayCc].Value = item.DisplayCc;
            this.ContentsGrid.Rows[row].Cells[ColNameCategories].Value = item.Categories;

            try
            {
                this.ContentsGrid.Rows[row].Cells[ColNameCulture].Value = item.Culture;
            }
            catch (Exception ex)
            {
                DebugLog.WriteVerbose("Handled exception when getting Culture", ex);
                this.ContentsGrid.Rows[row].Cells[ColNameCulture].Value = ex.Message;
            }

            this.ContentsGrid.Rows[row].Cells[ColNameItemId].Value = item.Id.UniqueId;
            this.ContentsGrid.Rows[row].ContextMenuStrip = this.mnuItemContext;
        }

        #region Item Right-Click Menu

        /// <summary>
        /// Display a file open dialog to get a file path to the
        /// file to attach to this meesage.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void MnuAddFileAttach_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select the file to attach...";
            ofd.Multiselect = false;
            DialogResult res = ofd.ShowDialog();

            if (res == DialogResult.OK && System.IO.File.Exists(ofd.FileName))
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    ItemId id = GetSelectedContentId();
                    if (id == null)
                    {
                        return;
                    }

                    Item item = Item.Bind(this.CurrentService, id, this.CurrentDetailPropertySet);
                    item.Attachments.AddFileAttachment(ofd.FileName);
                    item.Update(ConflictResolutionMode.AutoResolve);

                    // Refresh the view
                    this.RefreshContentAndDetails();
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        private void MnuAddItemAttach_Click(object sender, EventArgs e)
        {
            ItemId itemId = null;
            DialogResult res = ItemIdDialog.ShowDialog(out itemId);

            if (res == DialogResult.OK && itemId != null)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    ItemId id = GetSelectedContentId();
                    if (id == null)
                    {
                        return;
                    }

                    Item item = Item.Bind(this.CurrentService, id, this.CurrentDetailPropertySet);
                    ItemAttachment<Item> itemAttach = item.Attachments.AddItemAttachment<Item>();
 
                    item.Update(ConflictResolutionMode.AutoResolve);
          

                    // Refresh the view
                    this.RefreshContentAndDetails();
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        /// <summary>
        /// Display the ContentsForm with the item's attachments
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void MnuAttachments_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                ItemId id = GetSelectedContentId();
                if (id == null)
                {
                    return;
                }

                Item item = Item.Bind(this.CurrentService, id, this.CurrentDetailPropertySet);
                if (item.Attachments.Count == 0)
                {
                    ErrorDialog.ShowInfo(DisplayStrings.MSG_NO_ATTACHMENTS);
                    return;
                }

                AttachmentsContentForm.Show(item, this.CurrentService, this);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Move the currently seleced item to a destination folder.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void MnuMoveItem_Click(object sender, EventArgs e)
        {
            FolderId destId = null;
            if (FolderIdDialog.ShowDialog(ref destId) != DialogResult.OK)
            {
                return;
            }

            StringBuilder oSB = new StringBuilder();

            try
            {
                this.Cursor = Cursors.WaitCursor;

                ItemId id = GetSelectedContentId();
                if (id == null)
                {
                    return;
                }

                List<ItemId> itemId = new List<ItemId>();
                itemId.Add(id);

                ServiceResponseCollection<MoveCopyItemResponse> oResponses = this.CurrentService.MoveItems(itemId, destId, true);

 

                if (oResponses.OverallResult != ServiceResult.Success)
                {

                    oSB.AppendFormat("Errors found in some of {0} response(s) .\r\n", oResponses.Count);

                    foreach (MoveCopyItemResponse oResponse in oResponses)
                    {

                        oSB.AppendFormat("    Error code: {0}\r\n", oResponse.ErrorCode.ToString());
                        oSB.AppendFormat("    Item - Id: {0}\r\n", oResponse.Result.ToString());
                        oSB.AppendFormat("    ErrorMessage: {0}\r\n", oResponse.ErrorMessage.ToString());
                        if (oResponse.ErrorDetails != null)
                        {
                            oSB.AppendFormat("    ErrorDetails: \r\n");
                            foreach (KeyValuePair<string, string> kvp in oResponse.ErrorDetails)
                            {
                                oSB.AppendFormat("         Item: {0}\r\n", kvp.Key);
                                oSB.AppendFormat("        Value: {0}\r\n", kvp.Value);

                                oSB.AppendLine();
                            }
                        }


                        if (oResponse.Item != null)
                        {   // copy/moved item - null if between mailboxes or from mailbox to public folder.
                            oSB.AppendFormat("    Item - Id: {0}\r\n", oResponse.Item.Id.UniqueId);

                        }
                        if (oResponse.ErrorProperties != null)
                        {
                            oSB.AppendFormat("    ErrorProperties:  \r\n");
                            foreach (PropertyDefinitionBase oProps in oResponse.ErrorProperties)
                            {
                                oSB.AppendFormat("        Property: {0}\r\n", oProps.ToString());

                            }
                        }
                        oSB.AppendLine();
                    }
                    ShowTextDocument oForm = new ShowTextDocument();
                    oForm.txtEntry.WordWrap = false;
                    oForm.Text = "Move Results";
                    oForm.txtEntry.Text = oSB.ToString();
                    oForm.ShowDialog();
                }
                else
                {
                    oSB.AppendFormat("Operation completed.\r\n\r\n");
                    oSB.AppendFormat("Ending item IDs: \r\n");
                    foreach (MoveCopyItemResponse oResponse in oResponses)
                    {

                        if (oResponse.Item != null)
                        {   // copy/moved item - null if between mailboxes or from mailbox to public folder.
                            oSB.AppendFormat("    Item - Id: {0}\r\n", oResponse.Item.Id.UniqueId);
                            //oSB.AppendFormat("           ParentFolderId: {0}\r\n", oResponse.Item.ParentFolderId);
                        }
                    }

                    oSB.AppendLine();
                    oSB.AppendFormat("Note: Ids will not be returned when copying between mailboxes or to a public folder.\r\n");

                    ShowTextDocument oForm = new ShowTextDocument();
                    oForm.txtEntry.WordWrap = false;
                    oForm.Text = "Move Result";
                    oForm.txtEntry.Text = oSB.ToString();
                    oForm.ShowDialog();
                }

                // Refresh the view
                this.RefreshContentAndDetails();
            }
            catch (ServiceResponseException ex)
            {

                oSB.AppendFormat("Error code: {0}\r\n", ex.ErrorCode);
                oSB.AppendFormat("Error message: {0}\r\n", ex.Message);
                oSB.AppendFormat("Response: {0}\r\n", ex.Response);

                ShowTextDocument oForm = new ShowTextDocument();
                oForm.txtEntry.WordWrap = false;
                oForm.Text = "Move Error";
                oForm.txtEntry.Text = oSB.ToString();
                oForm.ShowDialog();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void MnuHardDelete_Click(object sender, EventArgs e)
        {
            this.DeleteItem(DeleteMode.HardDelete);
        }

        private void MnuSoftDelete_Click(object sender, EventArgs e)
        {
            this.DeleteItem(DeleteMode.SoftDelete);
        }

        private void MnuMoveToDeleted_Click(object sender, EventArgs e)
        {
            this.DeleteItem(DeleteMode.MoveToDeletedItems);
        }

        /// <summary>
        /// There are three different delete modes, this function is called by
        /// each of the menu events passing a different mode.
        /// </summary>
        /// <param name="mode">Type of delete to peform</param>
        private void DeleteItem(DeleteMode mode)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                ItemId id = GetSelectedContentId();
                if (id == null)
                {
                    return;
                }

                List<ItemId> item = new List<ItemId>();
                item.Add(id);

                this.CurrentService.DeleteItems(
                    item,
                    mode,
                    SendCancellationsMode.SendToAllAndSaveCopy,
                    AffectedTaskOccurrence.AllOccurrences);

                // Refresh the view
                this.RefreshContentAndDetails();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void PropertyDetailsGrid_PropertyChanged(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                // Refresh the view
                this.RefreshContentAndDetails();
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void MnuExportXml_Click(object sender, EventArgs e)
        {
            // Get the folder to save the output files to, if the user
            // cancels this dialog bail out
            FolderBrowserDialog browser = new FolderBrowserDialog();
            browser.Description = "Pick an output folder to save the XML file to.";
            if (browser.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                ItemId id = GetSelectedContentId();
                if (id == null)
                {
                    return;
                }

                DumpHelper.DumpXML(
                    new List<ItemId> { id },
                    this.CurrentDetailPropertySet,
                    browser.SelectedPath,
                    this.CurrentService);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void MnuExportMIMEContent_Click(object sender, EventArgs e)
        {
            // Get the folder to save the output files to, if the user
            // cancels this dialog bail out
            FolderBrowserDialog browser = new FolderBrowserDialog();
            browser.Description = "Pick an output folder to save the MIME file to.";
            if (browser.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                ItemId id = GetSelectedContentId();
                if (id == null)
                {
                    return;
                }

                DumpHelper.DumpMIME(
                    new List<ItemId> { id },
                    browser.SelectedPath,
                    this.CurrentService);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void MnuExportToStream_Click(object sender, EventArgs e)
        {
            // Get the currently selected item
            ItemId id = GetSelectedContentId();
            if (id == null) { return; }

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save exported stream to a file...";
            dialog.OverwritePrompt = true;
            dialog.CheckPathExists = true;
            dialog.Filter = "Binary file (*.bin)|*.bin";

            if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            try
            {
                string sVersion = this.CurrentService.RequestedServerVersion.ToString();
                // Note - I tested ExportItemPost and it worked to export and load in EwsEditor 1.7 - so, its working properly
                ExportUploadHelper.ExportItemPost(sVersion, id.UniqueId, dialog.FileName);
               
       
                //byte[] data = null;

                //ExportUploadHelper.ExportItem(
                //    this.CurrentService,
                //    id,
                //    out data);

                //System.IO.File.WriteAllBytes(
                //    dialog.FileName,
                //    data);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void MnuMeetingAccept_Click(object sender, EventArgs e) 
        { 
            this.MeetingResponse_Click(MeetingResponseType.Accept); 
        }
        
        private void MnuMeetingDecline_Click(object sender, EventArgs e) 
        {
            this.MeetingResponse_Click(MeetingResponseType.Decline); 
        }

        private void MnuMeetingTenative_Click(object sender, EventArgs e) 
        {
            this.MeetingResponse_Click(MeetingResponseType.Tentative); 
        }

        /// <summary>
        /// Handler for multiple meeting response types.  Rather than recreate our
        /// own enumeration, we "borrow" one in the Managed API to indicate which
        /// response method to call
        /// </summary>
        /// <param name="respType">
        /// Borrowed this enumeration - only Accept, Decline, and Tentative
        /// are acceptable.
        /// </param>
        private void MeetingResponse_Click(MeetingResponseType respType)
        {
            try
            {
                ItemId id = GetSelectedContentId();
                if (id == null) 
                {
                    return;
                }

                Item item = Item.Bind(this.CurrentService, id, new PropertySet(BasePropertySet.FirstClassProperties));

                MeetingRequest meeting;
                Appointment appt;

                if (null != (meeting = item as MeetingRequest))
                {
                    switch (respType)
                    {
                        case MeetingResponseType.Accept:
                            meeting.Accept(true);
                            break;
                        case MeetingResponseType.Decline:
                            meeting.Decline(true);
                            break;
                        case MeetingResponseType.Tentative:
                            meeting.AcceptTentatively(true);
                            break;
                        default:
                            // It's bad to end up here
                            throw new ApplicationException("Unexpected response type requested.");
                    }
                }
                else if (null != (appt = item as Appointment))
                {
                    switch (respType)
                    {
                        case MeetingResponseType.Accept:
                            appt.Accept(true);
                            break;
                        case MeetingResponseType.Decline:
                            appt.Decline(true);
                            break;
                        case MeetingResponseType.Tentative:
                            appt.AcceptTentatively(true);
                            break;
                        default:
                            // It's bad to end up here
                            throw new ApplicationException("Unexpected response type requested.");
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        #endregion

        private void mnuViewMIMEContent_Click(object sender, EventArgs e)
        {
            string MimeOfItem = string.Empty;
            try
            {
                ItemId id = GetSelectedContentId();
                if (id == null)
                {
                    return;
                }
 
                
                //DumpHelper.DumpMIMEToString(
                //    new List<ItemId> { id },
                //    this.CurrentService,
                //    ref MimeOfItem);
              
                DumpHelper.GetItemMime(
                    id,
                    this.CurrentService,
                    ref MimeOfItem);

                ShowTextDocument oForm = new ShowTextDocument();
                oForm.txtEntry.WordWrap = false;
                oForm.Text = "MIME";
                oForm.txtEntry.Text = MimeOfItem;
                oForm.ShowDialog();

            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
 
 
        
        }

        private void mnuItemContext_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            HandleItemMenuOpening();
        }

        private void ContentsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ContentsGrid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {

        }

        private void EditCurrentItemByType()
        {
            ItemId id = GetSelectedContentId();
            Item oItem = Item.Bind(CurrentService, id);
            string sClass = string.Empty;
            sClass = GetBaseClass(oItem.ItemClass);

            EditItemByClass(oItem, sClass);

        }

        private void EditItemByClass(Item oItem, string sClass)
        {
 
            if (sClass.Length != 0)
            {

                switch (sClass)
                {
                    case "IPM.Note":
                        MessageForm oMessageForm = new MessageForm(CurrentService, oItem.Id);
                        oMessageForm.ShowDialog();
                        oMessageForm = null;
                        break;

                    case "IPM.Contact":
                        Contact oContact = Contact.Bind(CurrentService, oItem.Id);
                        ContactsForm oContactsForm = new ContactsForm(CurrentService, ref oContact);
                        oContactsForm.ShowDialog();
                        oContactsForm = null;
                        break;

                    case "IPM.Appointment":
                        CalendarForm oCalendarForm = new CalendarForm(CurrentService, oItem.Id);
                        oCalendarForm.ShowDialog();
                        oCalendarForm = null;
                        break;

                    case "IPM.Task":
                        TaskForm oTasksForm = new TaskForm(CurrentService, oItem.Id);
                        oTasksForm.ShowDialog();
                        oTasksForm = null;
                        break;

                    //case "IPM.Activity":
                    //    TasksForm oJournalForm = new JournalForm(_EwsCaller, oItemTag.Id);
                    //    oJournalForm.ShowDialog();
                    //    oJournalForm = null;
                    //case "IPM.StickyNote":
                    //    TasksForm oStickyNoteForm = new StickyNoteForm(_EwsCaller, oItemTag.Id);
                    //    oStickyNoteForm.ShowDialog();
                    //    oStickyNoteForm = null;
                    //    break;
                    default:
                        //EditMailItem();
                        break;
                }
            }
        }

        public string GetBaseClass(string ClassName)
        {
            string sClass = string.Empty;
            char[] splitchar = { '.' };
            string[] NameParts;
             
 
            NameParts = ClassName.Split(splitchar);
            if (NameParts.Count() > 1)    
                sClass = NameParts[0] + "." + NameParts[1];
            else
                sClass = ClassName;

            return sClass;
        }

        private void mnuCopyItem_Click(object sender, EventArgs e)
        {
            FolderId destId = null;
            if (FolderIdDialog.ShowDialog(ref destId) != DialogResult.OK)
            {
                return;
            }

            StringBuilder oSB = new StringBuilder();

            try
            {
                this.Cursor = Cursors.WaitCursor;

                ItemId id = GetSelectedContentId();
                if (id == null)
                {
                    return;
                }

                List<ItemId> itemId = new List<ItemId>();
                itemId.Add(id);

                //this.CurrentService.CopyItems(itemId, destId);

                // https://msdn.microsoft.com/en-us/library/office/Dn771039(v=EXCHG.150).aspx#bk_ewsmaerrors

                 

                ServiceResponseCollection <MoveCopyItemResponse > oResponses = this.CurrentService.CopyItems(itemId, destId, true);

                if (oResponses.OverallResult != ServiceResult.Success)
                {
                    
                    oSB.AppendFormat("Errors found in some of {0} response(s) .\r\n", oResponses.Count);

                    foreach (MoveCopyItemResponse oResponse in oResponses)
                    {

                        oSB.AppendFormat("    Error code: {0}\r\n", oResponse.ErrorCode.ToString());
                        oSB.AppendFormat("    Item - Id: {0}\r\n", oResponse.Result.ToString());
                        oSB.AppendFormat("    ErrorMessage: {0}\r\n", oResponse.ErrorMessage.ToString());
                        if (oResponse.ErrorDetails != null)
                        { 
                            oSB.AppendFormat("    ErrorDetails: \r\n") ;
                            foreach (KeyValuePair<string, string> kvp in oResponse.ErrorDetails)
                            {
                                oSB.AppendFormat("         Item: {0}\r\n", kvp.Key);
                                oSB.AppendFormat("        Value: {0}\r\n", kvp.Value);

                                oSB.AppendLine();
                            }
                        }
                       

                        if (oResponse.Item != null)
                        {   // copy/moved item - null if between mailboxes or from mailbox to public folder.
                            oSB.AppendFormat("    Item - Id: {0}\r\n", oResponse.Item.Id.UniqueId);
                             
                        }
                        if (oResponse.ErrorProperties != null)
                        {
                            oSB.AppendFormat("    ErrorProperties:  \r\n" );
                            foreach (PropertyDefinitionBase oProps in oResponse.ErrorProperties)
                            {
                                oSB.AppendFormat("        Property: {0}\r\n", oProps.ToString());

                            }
                        }
                        oSB.AppendLine();
                    }
                    ShowTextDocument oForm = new ShowTextDocument();
                    oForm.txtEntry.WordWrap = false;
                    oForm.Text = "Copy Results";
                    oForm.txtEntry.Text = oSB.ToString();
                    oForm.ShowDialog();
                }
                else
                {
                    oSB.AppendFormat("Operation completed.\r\n\r\n");
                    oSB.AppendFormat("Ending item IDs: \r\n");
                    foreach (MoveCopyItemResponse oResponse in oResponses)
                    {

                        if (oResponse.Item != null)
                        {   // copy/moved item - null if between mailboxes or from mailbox to public folder.
                            oSB.AppendFormat("    Item - Id: {0}\r\n", oResponse.Item.Id.UniqueId);
                            //oSB.AppendFormat("           ParentFolderId: {0}\r\n", oResponse.Item.ParentFolderId);
                        }
                    }

                    oSB.AppendLine();
                    oSB.AppendFormat("Note: Ids will not be returned when copying between mailboxes or to a public folder.\r\n");

                    ShowTextDocument oForm = new ShowTextDocument();
                    oForm.txtEntry.WordWrap = false;
                    oForm.Text = "Copy Result";
                    oForm.txtEntry.Text = oSB.ToString();
                    oForm.ShowDialog();
                }

                // Refresh the view
                this.RefreshContentAndDetails();
            }
            catch (ServiceResponseException ex)
            {

                oSB.AppendFormat("Error code: {0}\r\n", ex.ErrorCode);
                oSB.AppendFormat("Error message: {0}\r\n", ex.Message);
                oSB.AppendFormat("Response: {0}\r\n", ex.Response);

                ShowTextDocument oForm = new ShowTextDocument();
                oForm.txtEntry.WordWrap = false;
                oForm.Text = "Copy Error";
                oForm.txtEntry.Text = oSB.ToString();
                oForm.ShowDialog();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

 
        }

        private void mnuItemContext_Click(object sender, EventArgs e)
        {

        }

        private void mnuClientEditItem_Click(object sender, EventArgs e)
        {
            EditCurrentItemByType();
        }

        private void HandleItemMenuOpening()
        {
            ItemId id = GetSelectedContentId();
            Item oItem = Item.Bind(CurrentService, id);
            string sClass = string.Empty;
            sClass = GetBaseClass(oItem.ItemClass);

            if (sClass.Length != 0)
            {

                switch (sClass)
                {
                    case "IPM.Note":
                        mnuClientEditItem.Visible = true;
                        break;
                    case "IPM.Contact":
                        mnuClientEditItem.Visible = true;
                        break;
                    case "IPM.Appointment":
                        mnuClientEditItem.Visible = true;
                        break;
                    case "IPM.Task":
                        mnuClientEditItem.Visible = true;
                        break;
                    case "IPM.StickyNote":
                        mnuClientEditItem.Visible = false;
                        break;
                    default:
                        mnuClientEditItem.Visible = false;
                        break;
                }
            }
        }

        private void ContentsGrid_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void mnuPlayOnPhone_Click(object sender, EventArgs e)
        {
 
            try
            {
                this.Cursor = Cursors.WaitCursor;

                ItemId id = GetSelectedContentId();
                if (id == null)
                {
                    return;
                }
                string sDialString = string.Empty;
                PlayItemOnPhoneForm oForm = new PlayItemOnPhoneForm(this.CurrentService, id, sDialString);
                oForm.ShowDialog();

   

                // Refresh the view
                this.RefreshContentAndDetails();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ContentsGrid_CellContentClick_3(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PropertyDetailsGrid_Load(object sender, EventArgs e)
        {

        }

        private void mnuViewItemInOWA_Click(object sender, EventArgs e)
        {

            ItemId id = GetSelectedContentId();
            if (id == null)
            {
                return;
            }

            OpenOWAFromWebClientReadFormQueryString(this.CurrentService, id);
        }



        // taken from https://msdn.microsoft.com/en-us/library/microsoft.exchange.webservices.data.item.webclientreadformquerystring(v=exchg.80).aspx
        private void OpenOWAFromWebClientReadFormQueryString(ExchangeService service, ItemId oItemId)
        {

            ExchangeServerInfo serverInfo = service.ServerInfo;
            string sWebClientReadFormQueryString = string.Empty;

            string owaReadFormQueryString = string.Empty;
            var ewsIdentifer = oItemId.UniqueId;
 
            string sClass = string.Empty; 
            Item oSomeItem = Item.Bind(service, oItemId);
            sClass =  GetBaseClass(oSomeItem.ItemClass);  // need to get class id.
            oSomeItem = null;

            Item oWorkItem = Item.Bind(service, oItemId);
            oWorkItem.Load(new PropertySet(BasePropertySet.IdOnly, ItemSchema.WebClientReadFormQueryString));
            sWebClientReadFormQueryString = oWorkItem.WebClientReadFormQueryString;
            oWorkItem = null;
           


            //if (sClass.Length != 0)
            //{

            //    switch (sClass)
            //    { 
            //        case "IPM.Note":
            //            EmailMessage oWorkEmailMessageItem = EmailMessage.Bind(service, oItemId);
            //            oWorkEmailMessageItem.Load(new PropertySet(BasePropertySet.IdOnly, EmailMessageSchema.WebClientReadFormQueryString));
            //            sWebClientReadFormQueryString = oWorkEmailMessageItem.WebClientReadFormQueryString;
            //            oWorkEmailMessageItem = null; 
            //            break;
            //        case "IPM.Contact":  
            //            Contact oWorkContactItem = Contact.Bind(service, oItemId);
            //            oWorkContactItem.Load(new PropertySet(BasePropertySet.IdOnly, ContactSchema.WebClientReadFormQueryString));
            //            sWebClientReadFormQueryString = oWorkContactItem.WebClientReadFormQueryString;
            //            oWorkContactItem = null; 
            //            break;
            //        case "IPM.Appointment":
            //            Appointment oWorkAppointmentItem = Appointment.Bind(service, oItemId);
            //            oWorkAppointmentItem.Load(new PropertySet(BasePropertySet.IdOnly, AppointmentSchema.WebClientReadFormQueryString));
            //            sWebClientReadFormQueryString = oWorkAppointmentItem.WebClientReadFormQueryString;
            //            oWorkAppointmentItem = null; 
            //            break;
            //        case "IPM.Task":
            //            Task oWorkTaskItem = Task.Bind(service, oItemId);
            //            oWorkTaskItem.Load(new PropertySet(BasePropertySet.IdOnly, TaskSchema.WebClientReadFormQueryString));
            //            sWebClientReadFormQueryString = oWorkTaskItem.WebClientReadFormQueryString;
            //            oWorkTaskItem = null; 
            //            break;
            //        default:
            //            Item oWorkItem = Item.Bind(service, oItemId);
            //            oWorkItem.Load(new PropertySet(BasePropertySet.IdOnly, ItemSchema.WebClientReadFormQueryString));
            //            sWebClientReadFormQueryString = oWorkItem.WebClientReadFormQueryString;
            //            oWorkItem = null; 
            //            break;
            //    }
            //}
 
 
            
            try
            {
 

                //Item msg = Appointment.Bind(service, oItemId);
                //msg.Load(new PropertySet(BasePropertySet.IdOnly, ItemSchema.WebClientReadFormQueryString));
                

                // Versions of Exchange starting with major version 15 and ending with Exchange Server 2013 build 15.0.775.09
                // returned a different query string fragment. This optional check is not required for applications that
                // target Exchange Online.
                if ((serverInfo.MajorVersion == 15) && (serverInfo.MajorBuildNumber < 775) && (serverInfo.MinorBuildNumber < 09))
                {
                    // If your client is connected to an Exchange 2013 server that has not been updated to CU3,
                    // this query string will be returned.
                    owaReadFormQueryString = string.Format("#viewmodel=_y.$Ep&ItemID={0}",
                      System.Web.HttpUtility.UrlEncode(ewsIdentifer, Encoding.UTF8));
                }
                else
                {
                    // If your client is connected to an Exchanger 2010, Exchange 2013 CU3, or Exchange Online server,
                    // the WebClientReadFormQueryString is used.
                    owaReadFormQueryString = sWebClientReadFormQueryString;
                }

                // Create the URL that Outlook Web App uses to open the email message.
                Uri url = service.Url;
                string owaReadAccessUrl = string.Empty;

                if (owaReadFormQueryString.StartsWith("https:") || owaReadFormQueryString.StartsWith("http:"))
                    owaReadAccessUrl = owaReadFormQueryString;
                else
                    owaReadAccessUrl = string.Format("{0}://{1}/owa/{2}", url.Scheme, url.Host, owaReadFormQueryString);
                

                if (!string.IsNullOrEmpty(owaReadAccessUrl))
                {
                    System.Diagnostics.Process.Start("IEXPLORE.EXE", owaReadAccessUrl);
                }
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRROR: Internet Explorer cannot be found.");
                //Console.WriteLine(ex.Message);
                //Console.WriteLine("ERRROR: Internet Explorer cannot be found.");
            }
        }


        private void OpenOWAFromWebClientEditFormQueryString(ExchangeService service, ItemId oItemId)
        {


            //  The WebClientEditFormQueryString element is not applicable to versions of Exchange starting with Exchange Server 2013, including Exchange Online.
            //  See:  https://msdn.microsoft.com/en-us/library/office/dd899477(v=exchg.150).aspx
            //      For versions of Exchange starting with Exchange Server 2013, including Exchange Online, 
            //      use the information from the WebClientReadFormQueryString element to open a draft item in 
            //      Outlook Web App and then use the UI to edit the draft item. The WebClientEditFormQueryString 
            //      element is not applicable to versions of Exchange starting with Exchange Server 2013, including Exchange Online.

            ExchangeServerInfo serverInfo = service.ServerInfo;
            if (serverInfo.MajorVersion == 15)
            {
                MessageBox.Show("The WebClientEditFormQueryString element is not applicable to versions of Exchange starting with Exchange Server 2013, including Exchange Online.", "Not valid for Exchange version.");
                return;
            }

             
            string owaEditFormQueryString = string.Empty;
            var ewsIdentifer = oItemId.UniqueId;

            try
            {
                string sWebClientEditFormQueryString = string.Empty;

                Item oItem = Item.Bind(service, oItemId);
                oItem.Load(new PropertySet(BasePropertySet.IdOnly, ItemSchema.WebClientEditFormQueryString));
                owaEditFormQueryString = oItem.WebClientEditFormQueryString;


                string sClass = string.Empty;
                Item oSomeItem = Item.Bind(service, oItemId);
                sClass = GetBaseClass(oSomeItem.ItemClass);  // need to get class id.
                oSomeItem = null;

                Item oWorkItem = Item.Bind(service, oItemId);
                oWorkItem.Load(new PropertySet(BasePropertySet.IdOnly, ItemSchema.WebClientEditFormQueryString));
                sWebClientEditFormQueryString = oWorkItem.WebClientEditFormQueryString;
                oWorkItem = null;
              

                //if (sClass.Length != 0)
                //{

                //    switch (sClass)
                //    {
                //        case "IPM.Note":
                //            EmailMessage oWorkEmailMessageItem = EmailMessage.Bind(service, oItemId);
                //            oWorkEmailMessageItem.Load(new PropertySet(BasePropertySet.IdOnly, EmailMessageSchema.WebClientEditFormQueryString));
                //            sWebClientEditFormQueryString = oWorkEmailMessageItem.WebClientEditFormQueryString;
                //            oWorkEmailMessageItem = null;
                //            break;
                //        case "IPM.Contact":
                //            Contact oWorkContactItem = Contact.Bind(service, oItemId);
                //            oWorkContactItem.Load(new PropertySet(BasePropertySet.IdOnly, ContactSchema.WebClientEditFormQueryString));
                //            sWebClientEditFormQueryString = oWorkContactItem.WebClientEditFormQueryString;
                //            oWorkContactItem = null;
                //            break;
                //        case "IPM.Appointment":
                //            Appointment oWorkAppointmentItem = Appointment.Bind(service, oItemId);
                //            oWorkAppointmentItem.Load(new PropertySet(BasePropertySet.IdOnly, AppointmentSchema.WebClientEditFormQueryString));
                //            sWebClientEditFormQueryString = oWorkAppointmentItem.WebClientEditFormQueryString;
                //            oWorkAppointmentItem = null;
                //            break;
                //        case "IPM.Task":
                //            Task oWorkTaskItem = Task.Bind(service, oItemId);
                //            oWorkTaskItem.Load(new PropertySet(BasePropertySet.IdOnly, TaskSchema.WebClientEditFormQueryString));
                //            sWebClientEditFormQueryString = oWorkTaskItem.WebClientEditFormQueryString;
                //            oWorkTaskItem = null;
                //            break;
                //        default:
                //            Item oWorkItem = Item.Bind(service, oItemId);
                //            oWorkItem.Load(new PropertySet(BasePropertySet.IdOnly, ItemSchema.WebClientEditFormQueryString));
                //            sWebClientEditFormQueryString = oWorkItem.WebClientEditFormQueryString;
                //            oWorkItem = null;
                //            break;
                //    }
                //}


 

                Uri url = service.Url;
                string owaEditAccessUrl = string.Empty;

                if (owaEditFormQueryString.StartsWith("https:") || owaEditFormQueryString.StartsWith("http:"))
                    owaEditAccessUrl = owaEditFormQueryString;
                else
                    owaEditAccessUrl = string.Format("{0}://{1}/owa/{2}", url.Scheme, url.Host, owaEditFormQueryString);


                if (!string.IsNullOrEmpty(owaEditAccessUrl))
                {
                    System.Diagnostics.Process.Start("IEXPLORE.EXE", owaEditAccessUrl);
                }
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                MessageBox.Show(ex.Message, "ERRROR: Internet Explorer cannot be found.");
                //Console.WriteLine(ex.Message);
                //Console.WriteLine("ERRROR: Internet Explorer cannot be found.");
            }
        }

        private void mnuEditItemInOWA_Click(object sender, EventArgs e)
        {
            ItemId id = GetSelectedContentId();
            if (id == null)
            {
                return;
            }

            OpenOWAFromWebClientEditFormQueryString(this.CurrentService, id); 
        }


    }
}
