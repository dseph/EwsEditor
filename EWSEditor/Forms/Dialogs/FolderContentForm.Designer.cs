using System;
using System.Windows.Forms;

namespace EWSEditor.Forms
{
    partial class FolderContentForm
    {
        private ToolStripMenuItem mnuFolder = new ToolStripMenuItem();
        private ToolStripMenuItem mnuItems = new ToolStripMenuItem();
        private ToolStripMenuItem mnuAssociatedItems = new ToolStripMenuItem();
        private ToolStripMenuItem mnuSoftDeletedItems = new ToolStripMenuItem();
        private ToolStripSeparator mnuFolderSplit1 = new ToolStripSeparator();
        private ToolStripMenuItem mnuCreateStdItems = new ToolStripMenuItem();
        private ToolStripMenuItem mnuCreateSpcItems = new ToolStripMenuItem();
        private ToolStripMenuItem mnuCreateFromMimeFile = new ToolStripMenuItem();
        private ToolStripMenuItem mnuCreateFromMimeEntry = new ToolStripMenuItem();
        private ToolStripSeparator mnuFolderSplit2 = new ToolStripSeparator();
        private ToolStripMenuItem mnuPermissions = new ToolStripMenuItem();
        private ToolStripSeparator mnuFolderSplit3 = new ToolStripSeparator();
        private ToolStripMenuItem mnuDumpFolder = new ToolStripMenuItem();
        private ToolStripMenuItem mnuDumpFolderXML = new ToolStripMenuItem();
        private ToolStripSeparator mnuFolderSplit4 = new ToolStripSeparator();
        private ToolStripMenuItem mnuFolderNotifications = new ToolStripMenuItem();
        private ToolStripMenuItem mnuFolderSynchronize = new ToolStripMenuItem();
        private ToolStripMenuItem mnuCreateAppointment = new ToolStripMenuItem();
        private ToolStripMenuItem mnuCreateContact = new ToolStripMenuItem();
        private ToolStripMenuItem mnuCreateStickyNote = new ToolStripMenuItem();

        private ToolStripSeparator mnuFolderSplit5 = new ToolStripSeparator();
     

 

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FolderContentForm));
            this.SuspendLayout();
            // 
            // PropertyDetailsGrid
            // 
            this.PropertyDetailsGrid.PropertyChanged += new EWSEditor.Forms.Controls.PropertyDetialsGrid.PropertyChangedEventHandler(this.PropertyDetailsGrid_PropertyChanged);
            // 
            // FolderContentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(981, 675);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FolderContentForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

    }
}