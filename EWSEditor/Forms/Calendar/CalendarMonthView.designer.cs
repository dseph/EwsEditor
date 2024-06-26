﻿namespace EWSEditor.Forms
{
    partial class CalendarMonthView
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
            this.mcSelect = new System.Windows.Forms.MonthCalendar();
            this.lvItems = new System.Windows.Forms.ListView();
            this.cmsItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsItemsViewMime = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItemsViewMimeText = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItemsViewMimeHexDump = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItemsAttachments = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItemsEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItemsAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItemsAttendeeStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.openMasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // mcSelect
            // 
            this.mcSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mcSelect.CalendarDimensions = new System.Drawing.Size(4, 1);
            this.mcSelect.Location = new System.Drawing.Point(13, 13);
            this.mcSelect.Margin = new System.Windows.Forms.Padding(19, 18, 19, 18);
            this.mcSelect.Name = "mcSelect";
            this.mcSelect.TabIndex = 0;
            this.mcSelect.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mcSelect_DateChanged);
            // 
            // lvItems
            // 
            this.lvItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvItems.ContextMenuStrip = this.cmsItems;
            this.lvItems.HideSelection = false;
            this.lvItems.Location = new System.Drawing.Point(32, 290);
            this.lvItems.Margin = new System.Windows.Forms.Padding(6);
            this.lvItems.Name = "lvItems";
            this.lvItems.Size = new System.Drawing.Size(1692, 494);
            this.lvItems.TabIndex = 1;
            this.lvItems.UseCompatibleStateImageBehavior = false;
            this.lvItems.SelectedIndexChanged += new System.EventHandler(this.lvItems_SelectedIndexChanged);
            this.lvItems.DoubleClick += new System.EventHandler(this.lvItems_DoubleClick);
            // 
            // cmsItems
            // 
            this.cmsItems.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsItemsViewMime,
            this.cmsItemsAttachments,
            this.cmsItemsEdit,
            this.cmsItemsAdd,
            this.cmsItemsAttendeeStatus,
            this.openMasterToolStripMenuItem,
            this.openItemToolStripMenuItem});
            this.cmsItems.Name = "cmsItems";
            this.cmsItems.Size = new System.Drawing.Size(266, 270);
            this.cmsItems.Opening += new System.ComponentModel.CancelEventHandler(this.cmsItems_Opening);
            // 
            // cmsItemsViewMime
            // 
            this.cmsItemsViewMime.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsItemsViewMimeText,
            this.cmsItemsViewMimeHexDump});
            this.cmsItemsViewMime.Name = "cmsItemsViewMime";
            this.cmsItemsViewMime.Size = new System.Drawing.Size(300, 38);
            this.cmsItemsViewMime.Text = "View Mime...";
            // 
            // cmsItemsViewMimeText
            // 
            this.cmsItemsViewMimeText.Name = "cmsItemsViewMimeText";
            this.cmsItemsViewMimeText.Size = new System.Drawing.Size(359, 44);
            this.cmsItemsViewMimeText.Text = "Text";
            this.cmsItemsViewMimeText.Click += new System.EventHandler(this.cmsItemsViewMimeText_Click);
            // 
            // cmsItemsViewMimeHexDump
            // 
            this.cmsItemsViewMimeHexDump.Name = "cmsItemsViewMimeHexDump";
            this.cmsItemsViewMimeHexDump.Size = new System.Drawing.Size(359, 44);
            this.cmsItemsViewMimeHexDump.Text = "Hex Dump";
            this.cmsItemsViewMimeHexDump.Click += new System.EventHandler(this.cmsItemsViewMimeHexDump_Click);
            // 
            // cmsItemsAttachments
            // 
            this.cmsItemsAttachments.Name = "cmsItemsAttachments";
            this.cmsItemsAttachments.Size = new System.Drawing.Size(300, 38);
            this.cmsItemsAttachments.Text = "Attachments...";
            this.cmsItemsAttachments.Click += new System.EventHandler(this.cmsItemsAttachments_Click);
            // 
            // cmsItemsEdit
            // 
            this.cmsItemsEdit.Name = "cmsItemsEdit";
            this.cmsItemsEdit.Size = new System.Drawing.Size(300, 38);
            this.cmsItemsEdit.Text = "Edit...";
            this.cmsItemsEdit.Click += new System.EventHandler(this.cmsItemsEdit_Click);
            // 
            // cmsItemsAdd
            // 
            this.cmsItemsAdd.Name = "cmsItemsAdd";
            this.cmsItemsAdd.Size = new System.Drawing.Size(300, 38);
            this.cmsItemsAdd.Text = "Add...";
            this.cmsItemsAdd.Click += new System.EventHandler(this.cmsItemsAdd_Click);
            // 
            // cmsItemsAttendeeStatus
            // 
            this.cmsItemsAttendeeStatus.Name = "cmsItemsAttendeeStatus";
            this.cmsItemsAttendeeStatus.Size = new System.Drawing.Size(300, 38);
            this.cmsItemsAttendeeStatus.Text = "AttendeeStatus...";
            this.cmsItemsAttendeeStatus.Click += new System.EventHandler(this.cmsItemsAttendeeStatus_Click);
            // 
            // openMasterToolStripMenuItem
            // 
            this.openMasterToolStripMenuItem.Name = "openMasterToolStripMenuItem";
            this.openMasterToolStripMenuItem.Size = new System.Drawing.Size(300, 38);
            this.openMasterToolStripMenuItem.Text = "Open Master...";
            this.openMasterToolStripMenuItem.Click += new System.EventHandler(this.openMasterToolStripMenuItem_Click);
            // 
            // openItemToolStripMenuItem
            // 
            this.openItemToolStripMenuItem.Name = "openItemToolStripMenuItem";
            this.openItemToolStripMenuItem.Size = new System.Drawing.Size(300, 38);
            this.openItemToolStripMenuItem.Text = "Open Item...";
            this.openItemToolStripMenuItem.Click += new System.EventHandler(this.openItemToolStripMenuItem_Click);
            // 
            // CalendarMonthView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1715, 885);
            this.Controls.Add(this.lvItems);
            this.Controls.Add(this.mcSelect);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "CalendarMonthView";
            this.Text = "CalendarMonthView";
            this.Load += new System.EventHandler(this.CalendarMonthView_Load);
            this.cmsItems.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar mcSelect;
        private System.Windows.Forms.ListView lvItems;
        private System.Windows.Forms.ContextMenuStrip cmsItems;
        private System.Windows.Forms.ToolStripMenuItem cmsItemsViewMime;
        private System.Windows.Forms.ToolStripMenuItem cmsItemsViewMimeText;
        private System.Windows.Forms.ToolStripMenuItem cmsItemsViewMimeHexDump;
        private System.Windows.Forms.ToolStripMenuItem cmsItemsAttachments;
        private System.Windows.Forms.ToolStripMenuItem cmsItemsEdit;
        private System.Windows.Forms.ToolStripMenuItem cmsItemsAdd;
        private System.Windows.Forms.ToolStripMenuItem cmsItemsAttendeeStatus;
        private System.Windows.Forms.ToolStripMenuItem openMasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openItemToolStripMenuItem;
    }
}