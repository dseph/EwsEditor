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

                this.CurrentService.MoveItems(itemId, destId);

                // Refresh the view
                this.RefreshContentAndDetails();
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
                ExportUploadHelper.ExportItemPost("Exchange2013", id.UniqueId, dialog.FileName);

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

                this.CurrentService.CopyItems(itemId, destId);

                // Refresh the view
                this.RefreshContentAndDetails();
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

  


    }
}
