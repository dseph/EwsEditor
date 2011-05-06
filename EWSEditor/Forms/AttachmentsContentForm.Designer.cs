namespace EWSEditor.Forms
{
    partial class AttachmentsContentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttachmentsContentForm));
            this.mnuAttachContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuDisplayAsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveAttach = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDeleteAttach = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAttachContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuAttachContext
            // 
            this.mnuAttachContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDisplayAsItem,
            this.mnuSaveAttach,
            this.toolStripMenuItem1,
            this.mnuDeleteAttach});
            this.mnuAttachContext.Name = "mnuAttachContext";
            this.mnuAttachContext.Size = new System.Drawing.Size(174, 98);
            this.mnuAttachContext.Opening += new System.ComponentModel.CancelEventHandler(this.MnuAttachContext_Opening);
            // 
            // mnuDisplayAsItem
            // 
            this.mnuDisplayAsItem.Name = "mnuDisplayAsItem";
            this.mnuDisplayAsItem.Size = new System.Drawing.Size(173, 22);
            this.mnuDisplayAsItem.Text = "Display as Item...";
            this.mnuDisplayAsItem.Click += new System.EventHandler(this.MnuDisplayAsItem_Click);
            // 
            // mnuSaveAttach
            // 
            this.mnuSaveAttach.Name = "mnuSaveAttach";
            this.mnuSaveAttach.Size = new System.Drawing.Size(173, 22);
            this.mnuSaveAttach.Text = "Save to File...";
            this.mnuSaveAttach.Click += new System.EventHandler(this.MnuSaveAttach_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(170, 6);
            // 
            // mnuDeleteAttach
            // 
            this.mnuDeleteAttach.Name = "mnuDeleteAttach";
            this.mnuDeleteAttach.Size = new System.Drawing.Size(173, 22);
            this.mnuDeleteAttach.Text = "Delete Attachment";
            this.mnuDeleteAttach.Click += new System.EventHandler(this.MnuDeleteAttach_Click);
            // 
            // AttachmentsContentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 675);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "AttachmentsContentForm";
            this.mnuAttachContext.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip mnuAttachContext;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteAttach;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveAttach;
        private System.Windows.Forms.ToolStripMenuItem mnuDisplayAsItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    }
}