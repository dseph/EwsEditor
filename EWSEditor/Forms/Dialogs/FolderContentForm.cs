using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EWSEditor.Exchange;
using EWSEditor.PropertyInformation;
using EWSEditor.Resources;
using EWSEditor.Settings;
using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.Forms
{
    public partial class FolderContentForm : ItemsContentForm
    {
        private Folder currentFolder = null;
        private ToolStripMenuItem mnuCreateFromStream = new ToolStripMenuItem();

        private FolderContentForm()
        {
            InitializeComponent();
        }

        public static void Show(
            string caption,
            Folder folder,
            ItemTraversal contentTraversal,
            ExchangeService service,
            Form parentForm)
        {
            FolderContentForm form = new FolderContentForm();

            form.ContentItemView.Traversal = contentTraversal;
            form.CurrentService = service;
            form.currentFolder = folder;
            form.PropertyDetailsGrid.CurrentService = service;
            form.Text = caption.Length == 0 ? "''" : caption;
            form.CallingForm = parentForm;
            form.Show();
        }

        protected override void SetupForm()
        {
            int viewMenu = this.mnuMain.Items.IndexOf(this.mnuTools);
            this.mnuMain.Items.Insert(viewMenu, this.mnuFolder);

            this.mnuFolder.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] 
            {
                this.mnuItems,
                this.mnuAssociatedItems,
                this.mnuSoftDeletedItems,
                this.mnuFolderSplit1,
                this.mnuCreateFromMimeFile,
                this.mnuCreateFromMimeEntry,
                this.mnuCreateFromStream,
                this.mnuFolderSplit2,
                this.mnuPermissions,
                this.mnuFolderSplit3,
                this.mnuDumpFolder,
                this.mnuDumpFolderXML,
                this.mnuFolderSplit4,
                this.mnuFolderNotifications,
                this.mnuFolderSynchronize
            });

            this.mnuFolder.Name = "mnuFolder";
            this.mnuFolder.Size = new System.Drawing.Size(52, 20);
            this.mnuFolder.Text = "Folder";

            this.mnuItems.Name = "mnuItems";
            this.mnuItems.Size = new System.Drawing.Size(305, 22);
            this.mnuItems.Text = "Open Items...";
            this.mnuItems.Click += new System.EventHandler(this.MnuItems_Click);

            this.mnuAssociatedItems.Name = "mnuAssociatedItems";
            this.mnuAssociatedItems.Size = new System.Drawing.Size(305, 22);
            this.mnuAssociatedItems.Text = "Open Associated Items...";
            this.mnuAssociatedItems.Click += new System.EventHandler(this.MnuAssociatedItems_Click);

            this.mnuSoftDeletedItems.Name = "mnuSoftDeletedItems";
            this.mnuSoftDeletedItems.Size = new System.Drawing.Size(305, 22);
            this.mnuSoftDeletedItems.Text = "Open Soft Deleted Items...";
            this.mnuSoftDeletedItems.Click += new System.EventHandler(this.MnuSoftDeletedItems_Click);

            this.mnuFolderSplit1.Name = "mnuFolderSplit1";
            this.mnuFolderSplit1.Size = new System.Drawing.Size(302, 6);
 
            this.mnuCreateFromMimeFile.Name = "mnuCreateFromMIMEFile";
            this.mnuCreateFromMimeFile.Size = new System.Drawing.Size(305, 22);
            this.mnuCreateFromMimeFile.Text = "Create Item From MIME (File)...";
            this.mnuCreateFromMimeFile.Click += new System.EventHandler(this.MnuCreateFromMimeFile_Click);

            this.mnuCreateFromMimeEntry.Name = "mnuCreateFromMIMEEntry";
            this.mnuCreateFromMimeEntry.Size = new System.Drawing.Size(305, 22);
            this.mnuCreateFromMimeEntry.Text = "Create Item From MIME (Entry)...";
            this.mnuCreateFromMimeEntry.Click += new System.EventHandler(this.MnuCreateFromMimeEntry_Click);

            this.mnuCreateFromStream.Name = "mnuCreateFromStream";
            this.mnuCreateFromStream.Size = new System.Drawing.Size(305, 22);
            this.mnuCreateFromStream.Text = "Create Item From Stream...";
            this.mnuCreateFromStream.Click += new System.EventHandler(this.MnuCreateFromStream_Click);

            this.mnuFolderSplit2.Name = "mnuFolderSplit2";
            this.mnuFolderSplit2.Size = new System.Drawing.Size(302, 6);

            this.mnuPermissions.Name = "mnuPermissions";
            this.mnuPermissions.Size = new System.Drawing.Size(305, 22);
            this.mnuPermissions.Text = "Display Permissions...";
            this.mnuPermissions.Click += new System.EventHandler(this.MnuPermissions_Click);

            this.mnuFolderSplit3.Name = "mnuFolderSplit3";
            this.mnuFolderSplit3.Size = new System.Drawing.Size(302, 6);

            this.mnuDumpFolder.Name = "mnuDumpFolder";
            this.mnuDumpFolder.Size = new System.Drawing.Size(305, 22);
            this.mnuDumpFolder.Text = "Save Contents as MIME...";
            this.mnuDumpFolder.Click += new System.EventHandler(this.MnuDumpFolder_Click);

            this.mnuDumpFolderXML.Name = "mnuDumpFolderXML";
            this.mnuDumpFolderXML.Size = new System.Drawing.Size(305, 22);
            this.mnuDumpFolderXML.Text = "Save Contents as XML...";
            this.mnuDumpFolderXML.Click += new System.EventHandler(this.MnuDumpFolderXML_Click);

            this.mnuFolderSplit4.Name = "mnuFolderSplit4";
            this.mnuFolderSplit4.Size = new System.Drawing.Size(302, 6);

            this.mnuFolderNotifications.Name = "mnuFolderNotifications";
            this.mnuFolderNotifications.Size = new System.Drawing.Size(305, 22);
            this.mnuFolderNotifications.Text = "Pull Notifications Viewer... (This Folder)";
            this.mnuFolderNotifications.Click += new System.EventHandler(this.MnuNotifications_Click);

            this.mnuFolderNotifications.Name = "mnuFolderStreamingNotifications";
            this.mnuFolderNotifications.Size = new System.Drawing.Size(305, 22);
            this.mnuFolderNotifications.Text = "Streaming Notifications Viewer... (This Folder)";
            this.mnuFolderNotifications.Click += new System.EventHandler(this.MnuStreamingNotifications_Click);

            this.mnuFolderSynchronize.Name = "mnuFolderSynchronize";
            this.mnuFolderSynchronize.Size = new System.Drawing.Size(305, 22);
            this.mnuFolderSynchronize.Text = "Item Synchronization Viewer... (This Folder) ";
            this.mnuFolderSynchronize.Click += new System.EventHandler(this.MnuSyncState_Click);

            this.mnuFolderSplit4.Name = "mnuFolderSplit5";
            this.mnuFolderSplit4.Size = new System.Drawing.Size(302, 6);

 

             

            base.SetupForm();
        }

        private void MnuStreamingNotifications_Click(object sender, EventArgs e)
        {
            StreamingNotificationForm.Show(
                string.Format(DisplayStrings.TITLE_NOTIFICATIONS_FOLDER, this.currentFolder.DisplayName),
                this.currentFolder.Id);
        }

        protected override void LoadContents()
        {
            FindItemsResults<Item> findResults = null;
            this.ContentItemView.Offset = 0;

            List<Item> folderItems = new List<Item>();
            while ((findResults == null || findResults.MoreAvailable) && folderItems.Count < 1000)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    this.currentFolder.Service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.   
                    findResults = this.currentFolder.FindItems(this.ContentItemView);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }

                this.ContentItemView.Offset = this.ContentItemView.Offset + GlobalSettings.FindItemViewSize;

                foreach (Item item in findResults.Items)
                {
                    this.AddContentItem(item);
                }
            }

            if (findResults.MoreAvailable && folderItems.Count == 1000)
            {
                ErrorDialog.ShowWarning(DisplayStrings.WARN_ITEM_VIEW_COUNT_LIMIT);
            }
        }

        #region Folder Menu

        private void MnuDumpFolder_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                FormsUtil.DumpMimeContents(this.CurrentService, this.currentFolder);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void MnuDumpFolderXML_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                FormsUtil.DumpXmlContents(this.CurrentService, this.currentFolder);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void MnuNotifications_Click(object sender, EventArgs e)
        {
            PullNotificationForm.Show(
                string.Format(DisplayStrings.TITLE_NOTIFICATIONS_FOLDER, this.currentFolder.DisplayName),
                this.currentFolder.Id, 
                this.CurrentService);
        }

        private void MnuSyncState_Click(object sender, EventArgs e)
        {
            SyncFolderItemsForm.Show(this.CurrentService, this.currentFolder.Id);
        }

 

        private void MnuItems_Click(object sender, EventArgs e)
        {
            FolderContentForm.Show(
                string.Format(DisplayStrings.TITLE_CONTENTS_FOLDER, this.currentFolder.DisplayName),
                this.currentFolder,
                ItemTraversal.Shallow,
                this.CurrentService,
                this);


        }

        private void MnuSoftDeletedItems_Click(object sender, EventArgs e)
        {
            FolderContentForm.Show(
                string.Format(DisplayStrings.TITLE_CONTENTS_SOFT, this.currentFolder.DisplayName),
                this.currentFolder,
                ItemTraversal.SoftDeleted,
                this.CurrentService,
                this);
        }

        private void MnuAssociatedItems_Click(object sender, EventArgs e)
        {
            FolderContentForm.Show(
                string.Format(DisplayStrings.TITLE_CONTENTS_ASSOC, this.currentFolder.DisplayName),
                this.currentFolder,
                ItemTraversal.Associated,
                this.CurrentService,
                this);
        }

        /// <summary>
        /// Open the PermissionsDialog for the selected folder.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void MnuPermissions_Click(object sender, EventArgs e)
        {
            PermissionsDialog.Show(this.CurrentService, this.currentFolder.Id);
        }

        /// <summary>
        /// Demonstrate the creation of an IPM.StickyNote base on
        /// http://download.microsoft.com/download/5/d/d/5dd33fdf-91f5-496d-9884-0a0b0ee698bb/%5bMS-OXONOTE%5d.pdf
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void MnuCreateStickyNote_Click(object sender, EventArgs e)
        {
            // TODO: Implement a form here
            try
            {
                this.Cursor = Cursors.WaitCursor;

                EmailMessage message = new EmailMessage(this.CurrentService);

                message.SetExtendedProperty(KnownExtendedProperties.Instance().PidLidNoteColor, "3");
                message.SetExtendedProperty(KnownExtendedProperties.Instance().PidLidNoteWidth, Convert.ToString(0x000000C8));
                message.SetExtendedProperty(KnownExtendedProperties.Instance().PidLidNoteHeight, Convert.ToString(0x000000A6));
                message.SetExtendedProperty(KnownExtendedProperties.Instance().PidLidNoteX, Convert.ToString(0x0000006E));
                message.SetExtendedProperty(KnownExtendedProperties.Instance().PidLidNoteY, Convert.ToString(0x0000006E));

                message.SetExtendedProperty(KnownExtendedProperties.Instance().PidTagIconIndex, Convert.ToString(0x00000300));
                message.SetExtendedProperty(KnownExtendedProperties.Instance().PidLidSideEffects, Convert.ToString(0x110));

                message.ItemClass = "IPM.StickyNote";
                message.Subject = "Test Note.";

                message.Save(this.currentFolder.Id);

                // Refresh the view
                this.RefreshContentAndDetails();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            this.Cursor = Cursors.Default;
        }

        private void PropertyDetailsGrid_PropertyChanged(object sender, EventArgs e)
        {
            this.RefreshContentAndDetails();
        }

        private void MnuCreateFromStream_Click(object sender, EventArgs e)
        {
            UploadItemForm oUploadItemForm = new UploadItemForm();
            oUploadItemForm.ShowDialog();

            //OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Title = "Choose an export stream file to import...";
            //ofd.Multiselect = false;
            //ofd.CheckFileExists = true;
            //ofd.CheckPathExists = true;

            //if (ofd.ShowDialog() != DialogResult.OK)
            //{
            //    return;
            //}

            if (oUploadItemForm.ChoseOk == false)
                return;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                //byte[] data = System.IO.File.ReadAllBytes(oUploadItemForm.ChoseFileToUpload);

                 
 

                ExportUploadHelper.UploadItemPost(
                    this.CurrentService.RequestedServerVersion.ToString(),
                    this.currentFolder.Id,
                    oUploadItemForm.ChoseCreateActionType,
                    oUploadItemForm.ChoseItemId,
                    oUploadItemForm.ChoseFileToUpload);

                this.RefreshContentAndDetails();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            this.Cursor = Cursors.Default;
        }



        /// <summary>
        /// Create a new item in a folder based on a input MIME stream stored in a file
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void MnuCreateFromMimeFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Choose a MIME file to import...";
            ofd.Multiselect = false;
            this.Cursor = Cursors.WaitCursor;

            // The dialog doesn't return OK, bail out...
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                this.Cursor = Cursors.Default;
                return;
            }
            bool bItemSaved = false;

            // Defeat warnings on bItemSaved - end
            bool bjunk = false;
            bItemSaved = bjunk;
            bjunk = bItemSaved;
            // Defeat warnings on bItemSaved - end

            bool bSupportedFolderType = false;

            if (this.currentFolder.FolderClass.StartsWith("IPF.Appointment"))
            {
                bSupportedFolderType = true;
                Appointment item = new Appointment(this.CurrentService);
                item.MimeContent = new MimeContent();

                DialogResult res = MessageBox.Show("Is the MIME Base64 encoded?", "MIME Encoding", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                    item.MimeContent.Content = Convert.FromBase64String(System.IO.File.ReadAllText(ofd.FileName));
                else
                    item.MimeContent.Content = System.IO.File.ReadAllBytes(ofd.FileName);
                item.Save(this.currentFolder.Id);
                this.RefreshContentAndDetails();
                bItemSaved = true;
            }
            if (this.currentFolder.FolderClass.StartsWith("IPF.Contact"))
            {
                bSupportedFolderType = true;
                Contact item = new Contact(this.CurrentService);
                item.MimeContent = new MimeContent();

                DialogResult res = MessageBox.Show("Is the MIME Base64 encoded?", "MIME Encoding", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                    item.MimeContent.Content = Convert.FromBase64String(System.IO.File.ReadAllText(ofd.FileName));
                else
                    item.MimeContent.Content = System.IO.File.ReadAllBytes(ofd.FileName);
                item.Save(this.currentFolder.Id);
                this.RefreshContentAndDetails();
                bItemSaved = true;
            }
            if (this.currentFolder.FolderClass.StartsWith("IPF.Note"))
            {
                bSupportedFolderType = true;
                EmailMessage item = new EmailMessage(this.CurrentService);
                item.MimeContent = new MimeContent();

                DialogResult res = MessageBox.Show("Is the MIME Base64 encoded?", "MIME Encoding", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                    item.MimeContent.Content = Convert.FromBase64String(System.IO.File.ReadAllText(ofd.FileName));
                else
                    item.MimeContent.Content = System.IO.File.ReadAllBytes(ofd.FileName);
                item.Save(this.currentFolder.Id);
                this.RefreshContentAndDetails();
                bItemSaved = true;
            }
            if (bSupportedFolderType == false)
            {
                MessageBox.Show("Loading for this folder type not implemented.");
            }
 
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Create a new item in a folder based on a input MIME stream entered by user
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void MnuCreateFromMimeEntry_Click(object sender, EventArgs e)
        {
            //OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Title = "Choose a MIME file to import...";
            //ofd.Multiselect = false;
            this.Cursor = Cursors.WaitCursor;
 
            bool bItemCreated = false;

            // Defeat warnings on bItemSaved - end
            bool bjunk = false;
            bItemCreated = bjunk;
            bjunk = bItemCreated;
            // Defeat warnings on bItemSaved - end
             
            bool bSupportedFolderType = false;

            string sFolderClass = this.currentFolder.FolderClass;

            if (sFolderClass.StartsWith("IPF.Appointment") ||
                sFolderClass.StartsWith("IPF.Contact") ||
                sFolderClass.StartsWith("IPF.Note")  
                )
            {
                bSupportedFolderType = true;
                MimeEntry oMimeEntry = new MimeEntry(this.CurrentService, this.currentFolder);
                oMimeEntry.ShowDialog();

                if (oMimeEntry.ItemCreated == true)
                    this.RefreshContentAndDetails();
            }

            //if (this.currentFolder.FolderClass.StartsWith("IPF.Appointment"))
            //{
            //    bSupportedFolderType = true;
            //    Appointment item = new Appointment(this.CurrentService);
            //    item.MimeContent = new MimeContent();

            //    MimeEntry oMimeEntry = new MimeEntry();
            //    oMimeEntry.ShowDialog();
            //    string sContent = string.Empty;
                 
            //    if (oMimeEntry.ChoseOK == true)
            //    {
            //        if (oMimeEntry.chkIsBase64Encoded.Checked == true)
            //            item.MimeContent.Content = Convert.FromBase64String(oMimeEntry.txtEntry.Text.Trim());
            //        else
            //            item.MimeContent.Content = System.Text.Encoding.UTF8.GetBytes(oMimeEntry.txtEntry.Text);

            //        item.Save(this.currentFolder.Id);
            //        this.RefreshContentAndDetails();
            //    }

            //    bItemCreated = true;
            //    item = null;
                 
            //}
            //if (this.currentFolder.FolderClass.StartsWith("IPF.Contact"))
            //{
            //    bSupportedFolderType = true;
            //    Contact item = new Contact(this.CurrentService);
            //    item.MimeContent = new MimeContent();

            //    MimeEntry oMimeEntry = new MimeEntry();
            //    oMimeEntry.ShowDialog();
            //    if (oMimeEntry.ChoseOK == true)
            //    {
            //        if (oMimeEntry.chkIsBase64Encoded.Checked == true)
            //            item.MimeContent.Content = Convert.FromBase64String(oMimeEntry.txtEntry.Text.Trim());
            //        else
            //            item.MimeContent.Content = System.Text.Encoding.UTF8.GetBytes(oMimeEntry.txtEntry.Text);

            //        item.Save(this.currentFolder.Id);
            //        this.RefreshContentAndDetails();

            //    }

            //    bItemCreated = true;
            //    item = null;
            //}
            //if (this.currentFolder.FolderClass.StartsWith("IPF.Note"))
            //{
            //    bSupportedFolderType = true;
            //    EmailMessage item = new EmailMessage(this.CurrentService);
            //    item.MimeContent = new MimeContent();

            //    MimeEntry oMimeEntry = new MimeEntry();

            //    oMimeEntry.ShowDialog();
            //    if (oMimeEntry.ChoseOK == true)
            //    {
            //        if (oMimeEntry.chkIsBase64Encoded.Checked == true)
            //            item.MimeContent.Content = Convert.FromBase64String(oMimeEntry.txtEntry.Text.Trim());
            //        else
            //            item.MimeContent.Content = System.Text.Encoding.UTF8.GetBytes(oMimeEntry.txtEntry.Text);

            //        item.Save(this.currentFolder.Id);
            //        this.RefreshContentAndDetails();

            //    }

            //    bItemCreated = true;
            //    item = null;

            //}

            // Tasks are not standarding messaging items and there is no MIME for them. EWS can generate a MIME type 
            // string for a Task but not create an item using MIME. Tasks are Outlook items.
          
            if (bSupportedFolderType == false)
            {
                if (this.currentFolder.FolderClass.StartsWith("IPF.Note"))  // Task specific error...
                {
                    string s = 
                        "Tasks are not standarding messaging items and there is no MIME for them. " +
                        "EWS can generate a MIME type string for a Task but not create an item using MIME. " +
                        "Tasks are Outlook items.";

                    MessageBox.Show(s, "MIME loading for Tasks type items not implemented.");
                }
                else 
                {
                    string s2 =
                        "MIME loading for this folder type not implemented. " +
                        "Note that not all items have a MIME type. " +
                        "Some items such as Tasks are Outlook items and not standard messaging items which have a MIME form.";
                    MessageBox.Show(s2, "MIME loading for this folder type not implemented.");
                }
            }
 
            this.Cursor = Cursors.Default;
        }

        #endregion

        private void ContentsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ContentsGrid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ContentsGrid_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ContentsGrid_CellContentClick_3(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ContentsGrid_CellContentClick_4(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ContentsGrid_CellContentClick_5(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ContentsGrid_CellContentClick_6(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ContentsGrid_CellContentClick_7(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
