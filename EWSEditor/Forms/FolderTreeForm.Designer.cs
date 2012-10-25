namespace EWSEditor.Forms
{
    partial class FolderTreeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FolderTreeForm));
            this.splitter = new System.Windows.Forms.SplitContainer();
            this.FolderTreeView = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.FolderPropertyDetailsGrid = new EWSEditor.Forms.Controls.PropertyDetialsGrid();
            this.cmsFolderMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuOpenContents = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenAssocContents = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenSoftDelItems = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuOpenStreamingNotifications = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPermissions = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCreateSubFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteHardMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteSoftMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteMoveMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCopyFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMoveFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDumpMIMEContents = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDumpXMLContents = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.addExtendedPropertyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertyListItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.mnuServiceContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuEditExchangeService = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuAddRootFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuContextCloseExchangeService = new System.Windows.Forms.ToolStripMenuItem();
            this.splitter.Panel1.SuspendLayout();
            this.splitter.Panel2.SuspendLayout();
            this.splitter.SuspendLayout();
            this.cmsFolderMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.propertyListItemBindingSource)).BeginInit();
            this.mnuServiceContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitter
            // 
            this.splitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitter.Location = new System.Drawing.Point(0, 24);
            this.splitter.Name = "splitter";
            // 
            // splitter.Panel1
            // 
            this.splitter.Panel1.Controls.Add(this.FolderTreeView);
            // 
            // splitter.Panel2
            // 
            this.splitter.Panel2.Controls.Add(this.FolderPropertyDetailsGrid);
            this.splitter.Size = new System.Drawing.Size(890, 645);
            this.splitter.SplitterDistance = 228;
            this.splitter.TabIndex = 4;
            // 
            // FolderTreeView
            // 
            this.FolderTreeView.BackColor = System.Drawing.SystemColors.Window;
            this.FolderTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FolderTreeView.FullRowSelect = true;
            this.FolderTreeView.HideSelection = false;
            this.FolderTreeView.ImageIndex = 1;
            this.FolderTreeView.ImageList = this.imageList;
            this.FolderTreeView.ItemHeight = 16;
            this.FolderTreeView.Location = new System.Drawing.Point(0, 0);
            this.FolderTreeView.Name = "FolderTreeView";
            this.FolderTreeView.SelectedImageIndex = 1;
            this.FolderTreeView.ShowNodeToolTips = true;
            this.FolderTreeView.Size = new System.Drawing.Size(228, 645);
            this.FolderTreeView.TabIndex = 0;
            this.FolderTreeView.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.FolderTreeView_BeforeCollapse);
            this.FolderTreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.FolderTreeView_BeforeExpand);
            this.FolderTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.FolderTreeView_AfterSelect);
            this.FolderTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.FolderTreeView_NodeMouseClick);
            this.FolderTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.FolderTreeView_NodeMouseDoubleClick);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.HotPink;
            this.imageList.Images.SetKeyName(0, "ServerConfig.png");
            this.imageList.Images.SetKeyName(1, "folder.ico");
            this.imageList.Images.SetKeyName(2, "calendar.png");
            this.imageList.Images.SetKeyName(3, "contact.png");
            this.imageList.Images.SetKeyName(4, "task.png");
            this.imageList.Images.SetKeyName(5, "journal.png");
            this.imageList.Images.SetKeyName(6, "mail.png");
            this.imageList.Images.SetKeyName(7, "post.png");
            this.imageList.Images.SetKeyName(8, "sticknote.png");
            // 
            // FolderPropertyDetailsGrid
            // 
            this.FolderPropertyDetailsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FolderPropertyDetailsGrid.Location = new System.Drawing.Point(0, 0);
            this.FolderPropertyDetailsGrid.Name = "FolderPropertyDetailsGrid";
            this.FolderPropertyDetailsGrid.Size = new System.Drawing.Size(658, 645);
            this.FolderPropertyDetailsGrid.TabIndex = 0;
            this.FolderPropertyDetailsGrid.PropertyChanged += new EWSEditor.Forms.Controls.PropertyDetialsGrid.PropertyChangedEventHandler(this.FolderPropertyDetailsGrid_PropertyChanged);
            // 
            // cmsFolderMenu
            // 
            this.cmsFolderMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpenContents,
            this.mnuOpenAssocContents,
            this.mnuOpenSoftDelItems,
            this.toolStripMenuItem4,
            this.mnuOpenStreamingNotifications,
            this.toolStripSeparator2,
            this.mnuPermissions,
            this.toolStripMenuItem13,
            this.mnuCreateSubFolder,
            this.mnuDeleteFolder,
            this.toolStripSeparator1,
            this.mnuCopyFolder,
            this.mnuMoveFolder,
            this.toolStripMenuItem12,
            this.mnuDumpMIMEContents,
            this.mnuDumpXMLContents,
            this.toolStripMenuItem1,
            this.addExtendedPropertyToolStripMenuItem});
            this.cmsFolderMenu.Name = "cmsFolderMenu";
            this.cmsFolderMenu.Size = new System.Drawing.Size(270, 326);
            // 
            // mnuOpenContents
            // 
            this.mnuOpenContents.Name = "mnuOpenContents";
            this.mnuOpenContents.Size = new System.Drawing.Size(269, 22);
            this.mnuOpenContents.Tag = "Folder";
            this.mnuOpenContents.Text = "Open Items...";
            this.mnuOpenContents.Click += new System.EventHandler(this.OpenContentsMenu_Click);
            // 
            // mnuOpenAssocContents
            // 
            this.mnuOpenAssocContents.Name = "mnuOpenAssocContents";
            this.mnuOpenAssocContents.Size = new System.Drawing.Size(269, 22);
            this.mnuOpenAssocContents.Tag = "Folder";
            this.mnuOpenAssocContents.Text = "Open Associated Items...";
            this.mnuOpenAssocContents.Click += new System.EventHandler(this.OpenAssocContentsMenu_Click);
            // 
            // mnuOpenSoftDelItems
            // 
            this.mnuOpenSoftDelItems.Name = "mnuOpenSoftDelItems";
            this.mnuOpenSoftDelItems.Size = new System.Drawing.Size(269, 22);
            this.mnuOpenSoftDelItems.Text = "Open Soft Deleted Items...";
            this.mnuOpenSoftDelItems.Click += new System.EventHandler(this.OpenSoftDelItemsMenu_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(266, 6);
            // 
            // mnuOpenStreamingNotifications
            // 
            this.mnuOpenStreamingNotifications.Name = "mnuOpenStreamingNotifications";
            this.mnuOpenStreamingNotifications.Size = new System.Drawing.Size(269, 22);
            this.mnuOpenStreamingNotifications.Text = "Open Streaming Notifications Viewer";
            this.mnuOpenStreamingNotifications.Click += new System.EventHandler(this.mnuOpenStreamingNotifications_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(266, 6);
            // 
            // mnuPermissions
            // 
            this.mnuPermissions.Name = "mnuPermissions";
            this.mnuPermissions.Size = new System.Drawing.Size(269, 22);
            this.mnuPermissions.Text = "Display Permissions...";
            this.mnuPermissions.Click += new System.EventHandler(this.PermissionsMenu_Click);
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(266, 6);
            // 
            // mnuCreateSubFolder
            // 
            this.mnuCreateSubFolder.Name = "mnuCreateSubFolder";
            this.mnuCreateSubFolder.Size = new System.Drawing.Size(269, 22);
            this.mnuCreateSubFolder.Text = "Create SubFolder...";
            this.mnuCreateSubFolder.Click += new System.EventHandler(this.CreateSubFolderMenu_Click);
            // 
            // mnuDeleteFolder
            // 
            this.mnuDeleteFolder.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteHardMenu,
            this.DeleteSoftMenu,
            this.DeleteMoveMenu});
            this.mnuDeleteFolder.Name = "mnuDeleteFolder";
            this.mnuDeleteFolder.Size = new System.Drawing.Size(269, 22);
            this.mnuDeleteFolder.Text = "Delete Folder";
            // 
            // DeleteHardMenu
            // 
            this.DeleteHardMenu.Name = "DeleteHardMenu";
            this.DeleteHardMenu.Size = new System.Drawing.Size(193, 22);
            this.DeleteHardMenu.Text = "Hard Delete";
            this.DeleteHardMenu.Click += new System.EventHandler(this.DeleteFolderMenu_Click);
            // 
            // DeleteSoftMenu
            // 
            this.DeleteSoftMenu.Name = "DeleteSoftMenu";
            this.DeleteSoftMenu.Size = new System.Drawing.Size(193, 22);
            this.DeleteSoftMenu.Text = "Soft Delete";
            this.DeleteSoftMenu.Click += new System.EventHandler(this.DeleteFolderMenu_Click);
            // 
            // DeleteMoveMenu
            // 
            this.DeleteMoveMenu.Name = "DeleteMoveMenu";
            this.DeleteMoveMenu.Size = new System.Drawing.Size(193, 22);
            this.DeleteMoveMenu.Text = "Move to Deleted Items";
            this.DeleteMoveMenu.Click += new System.EventHandler(this.DeleteFolderMenu_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(266, 6);
            // 
            // mnuCopyFolder
            // 
            this.mnuCopyFolder.Name = "mnuCopyFolder";
            this.mnuCopyFolder.Size = new System.Drawing.Size(269, 22);
            this.mnuCopyFolder.Text = "Copy Folder...";
            this.mnuCopyFolder.Click += new System.EventHandler(this.CopyFolderMenu_Click);
            // 
            // mnuMoveFolder
            // 
            this.mnuMoveFolder.Name = "mnuMoveFolder";
            this.mnuMoveFolder.Size = new System.Drawing.Size(269, 22);
            this.mnuMoveFolder.Text = "Move Folder...";
            this.mnuMoveFolder.Click += new System.EventHandler(this.MoveFolderMenu_Click);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(266, 6);
            // 
            // mnuDumpMIMEContents
            // 
            this.mnuDumpMIMEContents.Name = "mnuDumpMIMEContents";
            this.mnuDumpMIMEContents.Size = new System.Drawing.Size(269, 22);
            this.mnuDumpMIMEContents.Text = "Save Folder Contents as MIME...";
            this.mnuDumpMIMEContents.Click += new System.EventHandler(this.DumpMimeContentsMenu_Click);
            // 
            // mnuDumpXMLContents
            // 
            this.mnuDumpXMLContents.Name = "mnuDumpXMLContents";
            this.mnuDumpXMLContents.Size = new System.Drawing.Size(269, 22);
            this.mnuDumpXMLContents.Text = "Save Folder Contents as XML...";
            this.mnuDumpXMLContents.Click += new System.EventHandler(this.DumpXmlContentsMenu_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(266, 6);
            // 
            // addExtendedPropertyToolStripMenuItem
            // 
            this.addExtendedPropertyToolStripMenuItem.Name = "addExtendedPropertyToolStripMenuItem";
            this.addExtendedPropertyToolStripMenuItem.Size = new System.Drawing.Size(269, 22);
            this.addExtendedPropertyToolStripMenuItem.Text = "Add Extended Property...";
            this.addExtendedPropertyToolStripMenuItem.Click += new System.EventHandler(this.AddExtendedPropertyToolStripMenuItem_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "EWS Editor Services Profile Files|*.mmp";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "EWS Editor Services Profile Files|*.mmp";
            // 
            // mnuServiceContext
            // 
            this.mnuServiceContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditExchangeService,
            this.toolStripMenuItem10,
            this.mnuAddRootFolder,
            this.toolStripMenuItem6,
            this.mnuContextCloseExchangeService});
            this.mnuServiceContext.Name = "mnuServiceContext";
            this.mnuServiceContext.Size = new System.Drawing.Size(197, 82);
            // 
            // mnuEditExchangeService
            // 
            this.mnuEditExchangeService.Name = "mnuEditExchangeService";
            this.mnuEditExchangeService.Size = new System.Drawing.Size(196, 22);
            this.mnuEditExchangeService.Text = "Edit Exchange Service...";
            this.mnuEditExchangeService.Click += new System.EventHandler(this.EditExchangeServiceMenu_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(193, 6);
            // 
            // mnuAddRootFolder
            // 
            this.mnuAddRootFolder.Name = "mnuAddRootFolder";
            this.mnuAddRootFolder.Size = new System.Drawing.Size(196, 22);
            this.mnuAddRootFolder.Text = "Add Root Folder...";
            this.mnuAddRootFolder.Click += new System.EventHandler(this.AddRootFolderMenu_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(193, 6);
            // 
            // mnuContextCloseExchangeService
            // 
            this.mnuContextCloseExchangeService.Name = "mnuContextCloseExchangeService";
            this.mnuContextCloseExchangeService.Size = new System.Drawing.Size(196, 22);
            this.mnuContextCloseExchangeService.Text = "Close ExchangeService";
            this.mnuContextCloseExchangeService.Click += new System.EventHandler(this.CloseExchangeServiceButton_Click);
            // 
            // FolderTreeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 691);
            this.Controls.Add(this.splitter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FolderTreeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FolderTreeForm_Load);
            this.Controls.SetChildIndex(this.splitter, 0);
            this.splitter.Panel1.ResumeLayout(false);
            this.splitter.Panel2.ResumeLayout(false);
            this.splitter.ResumeLayout(false);
            this.cmsFolderMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.propertyListItemBindingSource)).EndInit();
            this.mnuServiceContext.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitter;
        private System.Windows.Forms.TreeView FolderTreeView;
        private System.Windows.Forms.BindingSource propertyListItemBindingSource;
        private System.Windows.Forms.ImageList imageList;
        private EWSEditor.Forms.Controls.PropertyDetialsGrid FolderPropertyDetailsGrid;
        private System.Windows.Forms.ContextMenuStrip cmsFolderMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenAssocContents;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenContents;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem mnuDumpMIMEContents;
        private System.Windows.Forms.ToolStripMenuItem mnuPermissions;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenSoftDelItems;
        private System.Windows.Forms.ContextMenuStrip mnuServiceContext;
        private System.Windows.Forms.ToolStripMenuItem mnuAddRootFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem mnuContextCloseExchangeService;
        private System.Windows.Forms.ToolStripMenuItem mnuCreateSubFolder;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem12;
        private System.Windows.Forms.ToolStripMenuItem DeleteHardMenu;
        private System.Windows.Forms.ToolStripMenuItem DeleteSoftMenu;
        private System.Windows.Forms.ToolStripMenuItem DeleteMoveMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem13;
        private System.Windows.Forms.ToolStripMenuItem mnuMoveFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuEditExchangeService;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem mnuDumpXMLContents;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addExtendedPropertyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenStreamingNotifications;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}
