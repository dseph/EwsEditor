namespace EWSEditor.Forms
{
    partial class AttachmentsByTypeForm
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
            this.lvFileAttachments = new System.Windows.Forms.ListView();
            this.cmsFileAttachments = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsFileAttachmentsSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsFileAttachmentsViewMime = new System.Windows.Forms.ToolStripMenuItem();
            this.lvInlineFileAttachments = new System.Windows.Forms.ListView();
            this.cmsInlineFileAttachments = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsInlineFileAttachmentsSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsInlineFileAttachmentsViewMime = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lvEmbededItemsAttachments = new System.Windows.Forms.ListView();
            this.cmsEmbededItemsAttachments = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsEmbededItemsAttachmentsSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsEmbededItemsAttachmentsViewsWithOutlook = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsEmbededItemsAttachmentsViewMime = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.cmsFileAttachments.SuspendLayout();
            this.cmsInlineFileAttachments.SuspendLayout();
            this.cmsEmbededItemsAttachments.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvFileAttachments
            // 
            this.lvFileAttachments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvFileAttachments.ContextMenuStrip = this.cmsFileAttachments;
            this.lvFileAttachments.Location = new System.Drawing.Point(13, 30);
            this.lvFileAttachments.Margin = new System.Windows.Forms.Padding(4);
            this.lvFileAttachments.Name = "lvFileAttachments";
            this.lvFileAttachments.Size = new System.Drawing.Size(1120, 147);
            this.lvFileAttachments.TabIndex = 1;
            this.lvFileAttachments.UseCompatibleStateImageBehavior = false;
            this.lvFileAttachments.SelectedIndexChanged += new System.EventHandler(this.lvFileAttachments_SelectedIndexChanged);
            // 
            // cmsFileAttachments
            // 
            this.cmsFileAttachments.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsFileAttachments.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsFileAttachmentsSaveAs,
            this.cmsFileAttachmentsViewMime});
            this.cmsFileAttachments.Name = "cmsFileAttachments";
            this.cmsFileAttachments.Size = new System.Drawing.Size(159, 56);
            // 
            // cmsFileAttachmentsSaveAs
            // 
            this.cmsFileAttachmentsSaveAs.Name = "cmsFileAttachmentsSaveAs";
            this.cmsFileAttachmentsSaveAs.Size = new System.Drawing.Size(158, 26);
            this.cmsFileAttachmentsSaveAs.Text = "Save As";
            this.cmsFileAttachmentsSaveAs.Click += new System.EventHandler(this.cmsFileAttachmentsSaveAs_Click);
            // 
            // cmsFileAttachmentsViewMime
            // 
            this.cmsFileAttachmentsViewMime.Name = "cmsFileAttachmentsViewMime";
            this.cmsFileAttachmentsViewMime.Size = new System.Drawing.Size(158, 26);
            this.cmsFileAttachmentsViewMime.Text = "View MIME";
            this.cmsFileAttachmentsViewMime.Click += new System.EventHandler(this.cmsFileAttachmentsViewMime_Click);
            // 
            // lvInlineFileAttachments
            // 
            this.lvInlineFileAttachments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvInlineFileAttachments.ContextMenuStrip = this.cmsInlineFileAttachments;
            this.lvInlineFileAttachments.Location = new System.Drawing.Point(13, 202);
            this.lvInlineFileAttachments.Margin = new System.Windows.Forms.Padding(4);
            this.lvInlineFileAttachments.Name = "lvInlineFileAttachments";
            this.lvInlineFileAttachments.Size = new System.Drawing.Size(1120, 144);
            this.lvInlineFileAttachments.TabIndex = 3;
            this.lvInlineFileAttachments.UseCompatibleStateImageBehavior = false;
            this.lvInlineFileAttachments.SelectedIndexChanged += new System.EventHandler(this.lvInlineFileAttachments_SelectedIndexChanged);
            // 
            // cmsInlineFileAttachments
            // 
            this.cmsInlineFileAttachments.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsInlineFileAttachments.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsInlineFileAttachmentsSaveAs,
            this.cmsInlineFileAttachmentsViewMime});
            this.cmsInlineFileAttachments.Name = "cmsFileAttachments";
            this.cmsInlineFileAttachments.Size = new System.Drawing.Size(159, 56);
            // 
            // cmsInlineFileAttachmentsSaveAs
            // 
            this.cmsInlineFileAttachmentsSaveAs.Name = "cmsInlineFileAttachmentsSaveAs";
            this.cmsInlineFileAttachmentsSaveAs.Size = new System.Drawing.Size(158, 26);
            this.cmsInlineFileAttachmentsSaveAs.Text = "Save As";
            this.cmsInlineFileAttachmentsSaveAs.Click += new System.EventHandler(this.cmsInlineFileAttachmentsSaveAs_Click);
            // 
            // cmsInlineFileAttachmentsViewMime
            // 
            this.cmsInlineFileAttachmentsViewMime.Name = "cmsInlineFileAttachmentsViewMime";
            this.cmsInlineFileAttachmentsViewMime.Size = new System.Drawing.Size(158, 26);
            this.cmsInlineFileAttachmentsViewMime.Text = "View MIME";
            this.cmsInlineFileAttachmentsViewMime.Visible = false;
            this.cmsInlineFileAttachmentsViewMime.Click += new System.EventHandler(this.cmsInlineFileAttachmentsViewMime_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "File:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 181);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Inline File:";
            // 
            // lvEmbededItemsAttachments
            // 
            this.lvEmbededItemsAttachments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvEmbededItemsAttachments.ContextMenuStrip = this.cmsEmbededItemsAttachments;
            this.lvEmbededItemsAttachments.Location = new System.Drawing.Point(13, 371);
            this.lvEmbededItemsAttachments.Margin = new System.Windows.Forms.Padding(4);
            this.lvEmbededItemsAttachments.Name = "lvEmbededItemsAttachments";
            this.lvEmbededItemsAttachments.Size = new System.Drawing.Size(1123, 148);
            this.lvEmbededItemsAttachments.TabIndex = 5;
            this.lvEmbededItemsAttachments.UseCompatibleStateImageBehavior = false;
            this.lvEmbededItemsAttachments.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // cmsEmbededItemsAttachments
            // 
            this.cmsEmbededItemsAttachments.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsEmbededItemsAttachments.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsEmbededItemsAttachmentsSaveAs,
            this.cmsEmbededItemsAttachmentsViewsWithOutlook,
            this.cmsEmbededItemsAttachmentsViewMime});
            this.cmsEmbededItemsAttachments.Name = "cmsFileAttachments";
            this.cmsEmbededItemsAttachments.Size = new System.Drawing.Size(205, 82);
            this.cmsEmbededItemsAttachments.Opening += new System.ComponentModel.CancelEventHandler(this.cmsEmbededItemsAttachments_Opening);
            // 
            // cmsEmbededItemsAttachmentsSaveAs
            // 
            this.cmsEmbededItemsAttachmentsSaveAs.Name = "cmsEmbededItemsAttachmentsSaveAs";
            this.cmsEmbededItemsAttachmentsSaveAs.Size = new System.Drawing.Size(204, 26);
            this.cmsEmbededItemsAttachmentsSaveAs.Text = "Save As";
            this.cmsEmbededItemsAttachmentsSaveAs.Visible = false;
            this.cmsEmbededItemsAttachmentsSaveAs.Click += new System.EventHandler(this.cmsEmbededItemsAttachmentsSaveAs_Click);
            // 
            // cmsEmbededItemsAttachmentsViewsWithOutlook
            // 
            this.cmsEmbededItemsAttachmentsViewsWithOutlook.Name = "cmsEmbededItemsAttachmentsViewsWithOutlook";
            this.cmsEmbededItemsAttachmentsViewsWithOutlook.Size = new System.Drawing.Size(204, 26);
            this.cmsEmbededItemsAttachmentsViewsWithOutlook.Text = "ViewWith Outlook";
            this.cmsEmbededItemsAttachmentsViewsWithOutlook.Visible = false;
            this.cmsEmbededItemsAttachmentsViewsWithOutlook.Click += new System.EventHandler(this.cmsEmbededItemsAttachmentsViewsWithOutlook_Click);
            // 
            // cmsEmbededItemsAttachmentsViewMime
            // 
            this.cmsEmbededItemsAttachmentsViewMime.Name = "cmsEmbededItemsAttachmentsViewMime";
            this.cmsEmbededItemsAttachmentsViewMime.Size = new System.Drawing.Size(204, 26);
            this.cmsEmbededItemsAttachmentsViewMime.Text = "View MIME";
            this.cmsEmbededItemsAttachmentsViewMime.Visible = false;
            this.cmsEmbededItemsAttachmentsViewMime.Click += new System.EventHandler(this.cmsEmbededItemsAttachmentsViewMime_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 350);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Embeded Item:";
            // 
            // AttachmentsByTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1141, 529);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lvEmbededItemsAttachments);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvInlineFileAttachments);
            this.Controls.Add(this.lvFileAttachments);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AttachmentsByTypeForm";
            this.Text = "Attachments By Type Form";
            this.Load += new System.EventHandler(this.AttachmentsForm_Load);
            this.cmsFileAttachments.ResumeLayout(false);
            this.cmsInlineFileAttachments.ResumeLayout(false);
            this.cmsEmbededItemsAttachments.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvFileAttachments;
        private System.Windows.Forms.ListView lvInlineFileAttachments;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvEmbededItemsAttachments;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip cmsFileAttachments;
        private System.Windows.Forms.ToolStripMenuItem cmsFileAttachmentsSaveAs;
        private System.Windows.Forms.ContextMenuStrip cmsInlineFileAttachments;
        private System.Windows.Forms.ToolStripMenuItem cmsInlineFileAttachmentsSaveAs;
        private System.Windows.Forms.ContextMenuStrip cmsEmbededItemsAttachments;
        private System.Windows.Forms.ToolStripMenuItem cmsEmbededItemsAttachmentsSaveAs;
        private System.Windows.Forms.ToolStripMenuItem cmsEmbededItemsAttachmentsViewsWithOutlook;
        private System.Windows.Forms.ToolStripMenuItem cmsFileAttachmentsViewMime;
        private System.Windows.Forms.ToolStripMenuItem cmsInlineFileAttachmentsViewMime;
        private System.Windows.Forms.ToolStripMenuItem cmsEmbededItemsAttachmentsViewMime;
    }
}