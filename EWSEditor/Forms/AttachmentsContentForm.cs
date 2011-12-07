using System;
using System.ComponentModel;
using System.Windows.Forms;
using EWSEditor.Logging;
using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.Forms
{
    public partial class AttachmentsContentForm : BaseContentForm
    {
        private const string ColNameAttachmentId = "colAttachmentId";
        private const string ColNameAttachmentName = "colName";
        private const string ColNameAttachmentObj = "colAttachmentObject";
        private const string ColNameContentId = "colContentId";
        private const string ColNameContentType = "colContentType";
        private const string ColNameContentLocation = "colContentLocation";
        private const string ColNameAttachmentType = "colAttachmentType";

        private AttachmentCollection currentAttachments = null;
        private Item currentParentItem = null;

        private AttachmentsContentForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load the given AttachmentCollection
        /// </summary>
        /// <param name="parentItem">Item that the attachments come from.</param>
        /// <param name="service">Current ExchangeService to use.</param>
        /// <param name="parentForm">Parent form that called this method.</param>
        public static void Show(
            Item parentItem,
            ExchangeService service,
            Form parentForm)
        {
            AttachmentsContentForm form = new AttachmentsContentForm();

            form.CurrentService = service;
            form.currentAttachments = parentItem.Attachments;
            form.currentParentItem = parentItem;
            form.PropertyDetailsGrid.CurrentService = service;
            form.Text = string.Format(System.Globalization.CultureInfo.CurrentCulture, "Attachments for item, '{0}'", parentItem.Subject);
            form.CallingForm = parentForm;
            form.Show();
        }

        protected override void LoadContents()
        {
            // Clear the contents and details grids
            this.PropertyDetailsGrid.Clear();
            this.ContentsGrid.Rows.Clear();

            // Add each Attachment to the ContentsGrid with no data binding
            foreach (Attachment attach in this.currentAttachments)
            {
                int row = this.ContentsGrid.Rows.Add();
                this.ContentsGrid.Rows[row].Cells[ColNameContentId].Value = attach.ContentId;
                this.ContentsGrid.Rows[row].Cells[ColNameContentLocation].Value = attach.ContentLocation;
                this.ContentsGrid.Rows[row].Cells[ColNameContentType].Value = attach.ContentType;
                this.ContentsGrid.Rows[row].Cells[ColNameAttachmentId].Value = attach.Id;
                this.ContentsGrid.Rows[row].Cells[ColNameAttachmentName].Value = attach.Name;
                this.ContentsGrid.Rows[row].Cells[ColNameAttachmentObj].Value = attach;
                this.ContentsGrid.Rows[row].Cells[ColNameAttachmentType].Value = attach.GetType().Name;

                this.ContentsGrid.Rows[row].ContextMenuStrip = this.mnuAttachContext;
            }
        }

        protected override void LoadSelectionDetails()
        {
            // Don't do anything if a content row is not selected
            if (this.ContentsGrid.SelectedRows.Count == 0)
            {
                return;
            }

            Attachment attach = this.ContentsGrid.SelectedRows[0].Cells[ColNameAttachmentObj].Value as Attachment;

            // If we can't get the attachment object bail out
            if (attach == null)
            {
                return;
            }

            attach.Load();
            
            this.PropertyDetailsGrid.LoadObject(attach);
        }

        protected override void SetupForm()
        {
            // Hide some of the View menu because the attachments don't have
            // a PropertySet to configure.
            this.mnuViewSplit1.Visible = false;
            this.mnuViewConfigPropertySet.Visible = false;
            this.mnuViewResetPropertySet.Visible = false;

            this.ContentIdColumnName = ColNameAttachmentId;

            // Setup the this.ContentsGrid with columns for displaying item collections
            int col = 0;
            col = this.ContentsGrid.Columns.Add(ColNameAttachmentName, "Name");
            this.ContentsGrid.Columns[col].Width = 150;

            col = this.ContentsGrid.Columns.Add(ColNameAttachmentType, "Type");
            this.ContentsGrid.Columns[col].Width = 100;

            col = this.ContentsGrid.Columns.Add(ColNameContentType, "ContentType");
            this.ContentsGrid.Columns[col].Width = 100;

            col = this.ContentsGrid.Columns.Add(ColNameContentId, "ContentId");
            this.ContentsGrid.Columns[col].Width = 100;

            col = this.ContentsGrid.Columns.Add(ColNameContentLocation, "ContentLocation");
            this.ContentsGrid.Columns[col].Width = 150;

            col = this.ContentsGrid.Columns.Add(ColNameAttachmentId, "Id");
            this.ContentsGrid.Columns[col].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // This hidden column will store the original Attachment object - see LoadContents notes.
            col = this.ContentsGrid.Columns.Add(ColNameAttachmentObj, "Object");
            this.ContentsGrid.Columns[col].Visible = false;
            this.ContentsGrid.Columns[col].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Set the default sort order for the contents table.
            this.ContentsGrid.Sort(this.ContentsGrid.Columns[ColNameAttachmentName], ListSortDirection.Ascending);
        }

        private void MnuSaveAttach_Click(object sender, EventArgs e)
        {
            // Don't do anything if a content row is not selected
            if (this.ContentsGrid.SelectedRows.Count == 0)
            {
                return;
            }

            Attachment attach = this.ContentsGrid.SelectedRows[0].Cells[ColNameAttachmentObj].Value as Attachment;

            // If we can't get the attachment object bail out
            if (attach == null)
            {
                return;
            }

            // Get the file name we'll save to and bail out if we don't succeed
            string fileName = this.GetTargetFileName();
            if (fileName == string.Empty)
            {
                return;
            }

            // If the attachment is a FileAttachment then simply save the content
            FileAttachment fileAttach = attach as FileAttachment;
            if (fileAttach != null)
            {
                if (fileAttach.Content == null)
                {
                    ErrorDialog.ShowWarning("Cannot save FileAttachment because FileAttachment.Content is NULL.");
                    return;
                }

                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    System.IO.File.WriteAllBytes(fileName, fileAttach.Content);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
            else
            {
                ItemAttachment itemAttachment = attach as ItemAttachment;
                if (itemAttachment != null)
                {
                    if (itemAttachment.Item == null)
                    {
                        ErrorDialog.ShowWarning("Cannot save ItemAttachment because ItemAttachment.Item is NULL.");
                        return;
                    }

                    try
                    {
                        this.Cursor = Cursors.WaitCursor;

                        EWSEditor.Common.DumpHelper.DumpXML(
                            itemAttachment.Item,
                            fileName);
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
                }
            }
        }

        private void MnuDeleteAttach_Click(object sender, EventArgs e)
        {
            // Don't do anything if a content row is not selected
            if (this.ContentsGrid.SelectedRows.Count == 0)
            {
                return;
            }

            Attachment attach = this.ContentsGrid.SelectedRows[0].Cells[ColNameAttachmentObj].Value as Attachment;

            // If we can't get the attachment object bail out
            if (attach == null)
            {
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                this.currentParentItem.Attachments.Remove(attach);
                this.currentParentItem.Update(ConflictResolutionMode.AlwaysOverwrite);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            this.RefreshContentAndDetails();
        }

        private void MnuDisplayAsItem_Click(object sender, EventArgs e)
        {
            // Don't do anything if a content row is not selected
            if (this.ContentsGrid.SelectedRows.Count == 0)
            {
                return;
            }

            Attachment attach = this.ContentsGrid.SelectedRows[0].Cells[ColNameAttachmentObj].Value as Attachment;

            // If we can't get the attachment object bail out
            if (attach == null)
            {
                return;
            }

            ItemAttachment itemAttachment = attach as ItemAttachment;
            if (itemAttachment == null)
            {
                // Warn the user that an ItemAttachment is required?
                return;
            }

            if (itemAttachment.Item == null)
            {
                DebugLog.WriteVerbose("Cannot display ItemAttachment.Item because ItemAttachment.Item is NULL.");
                ErrorDialog.ShowWarning("Cannot display ItemAttachment.Item because ItemAttachment.Item is NULL.");
                return;
            }

            this.PropertyDetailsGrid.LoadObject(itemAttachment.Item);
        }

        private void MnuAttachContext_Opening(object sender, CancelEventArgs e)
        {
            // Don't do anything if a content row is not selected
            if (this.ContentsGrid.SelectedRows.Count == 0)
            {
                return;
            }

            Attachment attach = this.ContentsGrid.SelectedRows[0].Cells[ColNameAttachmentObj].Value as Attachment;

            // If we can't get the attachment object bail out
            if (attach == null)
            {
                return;
            }

            // Since FileAttachments can't be viewed as Items disable the option
            if (attach is FileAttachment)
            {
                this.mnuDisplayAsItem.Enabled = false;
            }
        }

        private string GetTargetFileName()
        {
            SaveFileDialog saveDiag = new SaveFileDialog();
            saveDiag.CheckPathExists = true;
            saveDiag.OverwritePrompt = true;
            saveDiag.RestoreDirectory = true;
            saveDiag.Title = "Save the attachment to a file...";
            saveDiag.ValidateNames = true;
            DialogResult res = saveDiag.ShowDialog();

            if (res != DialogResult.OK)
            {
                return string.Empty;
            }

            return saveDiag.FileName;
        }
    }
}
