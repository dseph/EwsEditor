namespace EWSEditor.Forms
{
    partial class ItemsContentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemsContentForm));
            this.mnuItemContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAttachments = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddFileAttach = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddItemAttach = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemSplit1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuClientEditItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMoveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopyItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHardDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSoftDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMoveToDeleted = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemSplit2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExportItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExportMIMEContent = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExportXml = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToStreamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewMIMEContent = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemSplit3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuResponse = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMeetingAccept = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMeetingDecline = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMeetingTentative = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuItemContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuItemContext
            // 
            this.mnuItemContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAttachments,
            this.mnuAddFileAttach,
            this.mnuAddItemAttach,
            this.mnuItemSplit1,
            this.mnuClientEditItem,
            this.mnuMoveItem,
            this.mnuCopyItem,
            this.mnuDelete,
            this.mnuItemSplit2,
            this.mnuExportItem,
            this.mnuItemSplit3,
            this.mnuResponse});
            this.mnuItemContext.Name = "mnuItemContext";
            this.mnuItemContext.Size = new System.Drawing.Size(196, 242);
            this.mnuItemContext.Opening += new System.ComponentModel.CancelEventHandler(this.mnuItemContext_Opening);
            this.mnuItemContext.Click += new System.EventHandler(this.mnuItemContext_Click);
            // 
            // mnuAttachments
            // 
            this.mnuAttachments.Name = "mnuAttachments";
            this.mnuAttachments.Size = new System.Drawing.Size(195, 22);
            this.mnuAttachments.Text = "Display Attachments...";
            this.mnuAttachments.Click += new System.EventHandler(this.MnuAttachments_Click);
            // 
            // mnuAddFileAttach
            // 
            this.mnuAddFileAttach.Name = "mnuAddFileAttach";
            this.mnuAddFileAttach.Size = new System.Drawing.Size(195, 22);
            this.mnuAddFileAttach.Text = "Add FileAttachment...";
            this.mnuAddFileAttach.Click += new System.EventHandler(this.MnuAddFileAttach_Click);
            // 
            // mnuAddItemAttach
            // 
            this.mnuAddItemAttach.Name = "mnuAddItemAttach";
            this.mnuAddItemAttach.Size = new System.Drawing.Size(195, 22);
            this.mnuAddItemAttach.Text = "Add ItemAttachment...";
            this.mnuAddItemAttach.Visible = false;
            // 
            // mnuItemSplit1
            // 
            this.mnuItemSplit1.Name = "mnuItemSplit1";
            this.mnuItemSplit1.Size = new System.Drawing.Size(192, 6);
            // 
            // mnuClientEditItem
            // 
            this.mnuClientEditItem.Name = "mnuClientEditItem";
            this.mnuClientEditItem.Size = new System.Drawing.Size(195, 22);
            this.mnuClientEditItem.Text = "Edit Item";
            this.mnuClientEditItem.Click += new System.EventHandler(this.mnuClientEditItem_Click);
            // 
            // mnuMoveItem
            // 
            this.mnuMoveItem.Name = "mnuMoveItem";
            this.mnuMoveItem.Size = new System.Drawing.Size(195, 22);
            this.mnuMoveItem.Text = "Move Item...";
            this.mnuMoveItem.Click += new System.EventHandler(this.MnuMoveItem_Click);
            // 
            // mnuCopyItem
            // 
            this.mnuCopyItem.Name = "mnuCopyItem";
            this.mnuCopyItem.Size = new System.Drawing.Size(195, 22);
            this.mnuCopyItem.Text = "Copy Item...";
            this.mnuCopyItem.Click += new System.EventHandler(this.mnuCopyItem_Click);
            // 
            // mnuDelete
            // 
            this.mnuDelete.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHardDelete,
            this.mnuSoftDelete,
            this.mnuMoveToDeleted});
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(195, 22);
            this.mnuDelete.Text = "Delete Item";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // mnuHardDelete
            // 
            this.mnuHardDelete.Name = "mnuHardDelete";
            this.mnuHardDelete.Size = new System.Drawing.Size(193, 22);
            this.mnuHardDelete.Text = "Hard Delete";
            this.mnuHardDelete.Click += new System.EventHandler(this.MnuHardDelete_Click);
            // 
            // mnuSoftDelete
            // 
            this.mnuSoftDelete.Name = "mnuSoftDelete";
            this.mnuSoftDelete.Size = new System.Drawing.Size(193, 22);
            this.mnuSoftDelete.Text = "Soft Delete";
            this.mnuSoftDelete.Click += new System.EventHandler(this.MnuSoftDelete_Click);
            // 
            // mnuMoveToDeleted
            // 
            this.mnuMoveToDeleted.Name = "mnuMoveToDeleted";
            this.mnuMoveToDeleted.Size = new System.Drawing.Size(193, 22);
            this.mnuMoveToDeleted.Text = "Move to Deleted Items";
            this.mnuMoveToDeleted.Click += new System.EventHandler(this.MnuMoveToDeleted_Click);
            // 
            // mnuItemSplit2
            // 
            this.mnuItemSplit2.Name = "mnuItemSplit2";
            this.mnuItemSplit2.Size = new System.Drawing.Size(192, 6);
            // 
            // mnuExportItem
            // 
            this.mnuExportItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExportMIMEContent,
            this.mnuExportXml,
            this.exportToStreamToolStripMenuItem,
            this.mnuViewMIMEContent});
            this.mnuExportItem.Name = "mnuExportItem";
            this.mnuExportItem.Size = new System.Drawing.Size(195, 22);
            this.mnuExportItem.Text = "Export Item";
            // 
            // mnuExportMIMEContent
            // 
            this.mnuExportMIMEContent.Name = "mnuExportMIMEContent";
            this.mnuExportMIMEContent.Size = new System.Drawing.Size(196, 22);
            this.mnuExportMIMEContent.Text = "Export MIME Content...";
            this.mnuExportMIMEContent.Click += new System.EventHandler(this.MnuExportMIMEContent_Click);
            // 
            // mnuExportXml
            // 
            this.mnuExportXml.Name = "mnuExportXml";
            this.mnuExportXml.Size = new System.Drawing.Size(196, 22);
            this.mnuExportXml.Text = "Export to XML...";
            this.mnuExportXml.Click += new System.EventHandler(this.MnuExportXml_Click);
            // 
            // exportToStreamToolStripMenuItem
            // 
            this.exportToStreamToolStripMenuItem.Name = "exportToStreamToolStripMenuItem";
            this.exportToStreamToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.exportToStreamToolStripMenuItem.Text = "Export to Stream...";
            this.exportToStreamToolStripMenuItem.Click += new System.EventHandler(this.MnuExportToStream_Click);
            // 
            // mnuViewMIMEContent
            // 
            this.mnuViewMIMEContent.Name = "mnuViewMIMEContent";
            this.mnuViewMIMEContent.Size = new System.Drawing.Size(196, 22);
            this.mnuViewMIMEContent.Text = "View Mime Content...";
            this.mnuViewMIMEContent.Click += new System.EventHandler(this.mnuViewMIMEContent_Click);
            // 
            // mnuItemSplit3
            // 
            this.mnuItemSplit3.Name = "mnuItemSplit3";
            this.mnuItemSplit3.Size = new System.Drawing.Size(192, 6);
            // 
            // mnuResponse
            // 
            this.mnuResponse.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMeetingAccept,
            this.mnuMeetingDecline,
            this.mnuMeetingTentative});
            this.mnuResponse.Name = "mnuResponse";
            this.mnuResponse.Size = new System.Drawing.Size(195, 22);
            this.mnuResponse.Text = "Meeting Response";
            // 
            // mnuMeetingAccept
            // 
            this.mnuMeetingAccept.Name = "mnuMeetingAccept";
            this.mnuMeetingAccept.Size = new System.Drawing.Size(172, 22);
            this.mnuMeetingAccept.Text = "Accept";
            this.mnuMeetingAccept.Click += new System.EventHandler(this.MnuMeetingAccept_Click);
            // 
            // mnuMeetingDecline
            // 
            this.mnuMeetingDecline.Name = "mnuMeetingDecline";
            this.mnuMeetingDecline.Size = new System.Drawing.Size(172, 22);
            this.mnuMeetingDecline.Text = "Decline";
            this.mnuMeetingDecline.Click += new System.EventHandler(this.MnuMeetingDecline_Click);
            // 
            // mnuMeetingTentative
            // 
            this.mnuMeetingTentative.Name = "mnuMeetingTentative";
            this.mnuMeetingTentative.Size = new System.Drawing.Size(172, 22);
            this.mnuMeetingTentative.Text = "Accept Tentatively";
            this.mnuMeetingTentative.Click += new System.EventHandler(this.MnuMeetingTenative_Click);
            // 
            // ItemsContentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(981, 675);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "ItemsContentForm";
            this.mnuItemContext.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip mnuItemContext;
        private System.Windows.Forms.ToolStripMenuItem mnuAddFileAttach;
        private System.Windows.Forms.ToolStripMenuItem mnuAttachments;
        private System.Windows.Forms.ToolStripSeparator mnuItemSplit1;
        private System.Windows.Forms.ToolStripMenuItem mnuMoveItem;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuHardDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuSoftDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuMoveToDeleted;
        private System.Windows.Forms.ToolStripSeparator mnuItemSplit2;
        private System.Windows.Forms.ToolStripMenuItem mnuExportItem;
        private System.Windows.Forms.ToolStripMenuItem mnuExportMIMEContent;
        private System.Windows.Forms.ToolStripSeparator mnuItemSplit3;
        private System.Windows.Forms.ToolStripMenuItem mnuResponse;
        private System.Windows.Forms.ToolStripMenuItem mnuMeetingAccept;
        private System.Windows.Forms.ToolStripMenuItem mnuMeetingDecline;
        private System.Windows.Forms.ToolStripMenuItem mnuMeetingTentative;
        private System.Windows.Forms.ToolStripMenuItem mnuAddItemAttach;
        private System.Windows.Forms.ToolStripMenuItem mnuExportXml;
        private System.Windows.Forms.ToolStripMenuItem exportToStreamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuViewMIMEContent;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyItem;
        private System.Windows.Forms.ToolStripMenuItem mnuClientEditItem;
    }
}
