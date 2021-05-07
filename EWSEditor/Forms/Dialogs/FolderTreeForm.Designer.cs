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
            this.mnuFolderArchiveFlags = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFolderRetentionFlags = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuCreateSubFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEmptyFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteHardMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteSoftMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteMoveMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.EmptyFolderMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEmptyTheFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopyFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMoveFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDumpMIMEContents = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDumpXMLContents = new System.Windows.Forms.ToolStripMenuItem();
            this.addExtendedPropertyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFolderCalendarView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFolderCalendarItemsBreakdown = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchFoldersMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchItemsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchForCalendarItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.developerFolderTestFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.propertyListItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.mnuServiceContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuEditExchangeService = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuAddRootFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuContextCloseExchangeService = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitter)).BeginInit();
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
            this.splitter.Location = new System.Drawing.Point(0, 48);
            this.splitter.Margin = new System.Windows.Forms.Padding(6);
            this.splitter.Name = "splitter";
            // 
            // splitter.Panel1
            // 
            this.splitter.Panel1.Controls.Add(this.FolderTreeView);
            // 
            // splitter.Panel2
            // 
            this.splitter.Panel2.Controls.Add(this.FolderPropertyDetailsGrid);
            this.splitter.Size = new System.Drawing.Size(1416, 821);
            this.splitter.SplitterDistance = 228;
            this.splitter.SplitterWidth = 8;
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
            this.FolderTreeView.Margin = new System.Windows.Forms.Padding(6);
            this.FolderTreeView.Name = "FolderTreeView";
            this.FolderTreeView.SelectedImageIndex = 1;
            this.FolderTreeView.ShowNodeToolTips = true;
            this.FolderTreeView.Size = new System.Drawing.Size(228, 821);
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
            this.FolderPropertyDetailsGrid.Margin = new System.Windows.Forms.Padding(8);
            this.FolderPropertyDetailsGrid.Name = "FolderPropertyDetailsGrid";
            this.FolderPropertyDetailsGrid.Size = new System.Drawing.Size(1180, 821);
            this.FolderPropertyDetailsGrid.TabIndex = 0;
            this.FolderPropertyDetailsGrid.PropertyChanged += new EWSEditor.Forms.Controls.PropertyDetialsGrid.PropertyChangedEventHandler(this.FolderPropertyDetailsGrid_PropertyChanged);
            this.FolderPropertyDetailsGrid.Load += new System.EventHandler(this.FolderPropertyDetailsGrid_Load);
            // 
            // cmsFolderMenu
            // 
            this.cmsFolderMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsFolderMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpenContents,
            this.mnuOpenAssocContents,
            this.mnuOpenSoftDelItems,
            this.toolStripMenuItem4,
            this.mnuOpenStreamingNotifications,
            this.toolStripSeparator2,
            this.mnuPermissions,
            this.mnuFolderArchiveFlags,
            this.mnuFolderRetentionFlags,
            this.toolStripMenuItem13,
            this.mnuCreateSubFolder,
            this.mnuEmptyFolder,
            this.mnuEmptyTheFolder,
            this.mnuCopyFolder,
            this.mnuMoveFolder,
            this.toolStripMenuItem12,
            this.mnuDumpMIMEContents,
            this.mnuDumpXMLContents,
            this.addExtendedPropertyToolStripMenuItem,
            this.toolStripMenuItem14,
            this.mnuFolderCalendarView,
            this.mnuFolderCalendarItemsBreakdown,
            this.mnuNewItem,
            this.SearchFoldersMenuItem,
            this.SearchItemsMenuItem,
            this.SearchForCalendarItemsToolStripMenuItem,
            this.toolStripSeparator3,
            this.developerFolderTestFormToolStripMenuItem});
            this.cmsFolderMenu.Name = "cmsFolderMenu";
            this.cmsFolderMenu.Size = new System.Drawing.Size(486, 876);
            // 
            // mnuOpenContents
            // 
            this.mnuOpenContents.Name = "mnuOpenContents";
            this.mnuOpenContents.Size = new System.Drawing.Size(485, 38);
            this.mnuOpenContents.Tag = "Folder";
            this.mnuOpenContents.Text = "Open Items...";
            this.mnuOpenContents.Click += new System.EventHandler(this.OpenContentsMenu_Click);
            // 
            // mnuOpenAssocContents
            // 
            this.mnuOpenAssocContents.Name = "mnuOpenAssocContents";
            this.mnuOpenAssocContents.Size = new System.Drawing.Size(485, 38);
            this.mnuOpenAssocContents.Tag = "Folder";
            this.mnuOpenAssocContents.Text = "Open Associated Items...";
            this.mnuOpenAssocContents.Click += new System.EventHandler(this.OpenAssocContentsMenu_Click);
            // 
            // mnuOpenSoftDelItems
            // 
            this.mnuOpenSoftDelItems.Name = "mnuOpenSoftDelItems";
            this.mnuOpenSoftDelItems.Size = new System.Drawing.Size(485, 38);
            this.mnuOpenSoftDelItems.Text = "Open Soft Deleted Items...";
            this.mnuOpenSoftDelItems.Click += new System.EventHandler(this.OpenSoftDelItemsMenu_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(482, 6);
            // 
            // mnuOpenStreamingNotifications
            // 
            this.mnuOpenStreamingNotifications.Name = "mnuOpenStreamingNotifications";
            this.mnuOpenStreamingNotifications.Size = new System.Drawing.Size(485, 38);
            this.mnuOpenStreamingNotifications.Text = "Open Streaming Notifications Viewer";
            this.mnuOpenStreamingNotifications.Click += new System.EventHandler(this.mnuOpenStreamingNotifications_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(482, 6);
            // 
            // mnuPermissions
            // 
            this.mnuPermissions.Name = "mnuPermissions";
            this.mnuPermissions.Size = new System.Drawing.Size(485, 38);
            this.mnuPermissions.Text = "Display Permissions...";
            this.mnuPermissions.Click += new System.EventHandler(this.PermissionsMenu_Click);
            // 
            // mnuFolderArchiveFlags
            // 
            this.mnuFolderArchiveFlags.Name = "mnuFolderArchiveFlags";
            this.mnuFolderArchiveFlags.Size = new System.Drawing.Size(485, 38);
            this.mnuFolderArchiveFlags.Text = "Folder Archive Settings";
            this.mnuFolderArchiveFlags.Click += new System.EventHandler(this.mnuFolderArchiveFlags_Click);
            // 
            // mnuFolderRetentionFlags
            // 
            this.mnuFolderRetentionFlags.Name = "mnuFolderRetentionFlags";
            this.mnuFolderRetentionFlags.Size = new System.Drawing.Size(485, 38);
            this.mnuFolderRetentionFlags.Text = "Folder Retention Settings...";
            this.mnuFolderRetentionFlags.Click += new System.EventHandler(this.mnuFolderRetentionFlags_Click);
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(482, 6);
            // 
            // mnuCreateSubFolder
            // 
            this.mnuCreateSubFolder.Name = "mnuCreateSubFolder";
            this.mnuCreateSubFolder.Size = new System.Drawing.Size(485, 38);
            this.mnuCreateSubFolder.Text = "Create SubFolder...";
            this.mnuCreateSubFolder.Click += new System.EventHandler(this.CreateSubFolderMenu_Click);
            // 
            // mnuEmptyFolder
            // 
            this.mnuEmptyFolder.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteHardMenu,
            this.DeleteSoftMenu,
            this.DeleteMoveMenu,
            this.EmptyFolderMenu});
            this.mnuEmptyFolder.Name = "mnuEmptyFolder";
            this.mnuEmptyFolder.Size = new System.Drawing.Size(485, 38);
            this.mnuEmptyFolder.Text = "Delete Folder";
            this.mnuEmptyFolder.Click += new System.EventHandler(this.mnuDeleteFolder_Click);
            // 
            // DeleteHardMenu
            // 
            this.DeleteHardMenu.Name = "DeleteHardMenu";
            this.DeleteHardMenu.Size = new System.Drawing.Size(395, 44);
            this.DeleteHardMenu.Text = "Hard Delete";
            this.DeleteHardMenu.Click += new System.EventHandler(this.DeleteFolderMenu_Click);
            // 
            // DeleteSoftMenu
            // 
            this.DeleteSoftMenu.Name = "DeleteSoftMenu";
            this.DeleteSoftMenu.Size = new System.Drawing.Size(395, 44);
            this.DeleteSoftMenu.Text = "Soft Delete";
            this.DeleteSoftMenu.Click += new System.EventHandler(this.DeleteFolderMenu_Click);
            // 
            // DeleteMoveMenu
            // 
            this.DeleteMoveMenu.Name = "DeleteMoveMenu";
            this.DeleteMoveMenu.Size = new System.Drawing.Size(395, 44);
            this.DeleteMoveMenu.Text = "Move to Deleted Items";
            this.DeleteMoveMenu.Click += new System.EventHandler(this.DeleteFolderMenu_Click);
            // 
            // EmptyFolderMenu
            // 
            this.EmptyFolderMenu.Name = "EmptyFolderMenu";
            this.EmptyFolderMenu.Size = new System.Drawing.Size(395, 44);
            this.EmptyFolderMenu.Text = "Empty Folder";
            this.EmptyFolderMenu.Click += new System.EventHandler(this.EmptyFolderHardDeletMenu_Click);
            // 
            // mnuEmptyTheFolder
            // 
            this.mnuEmptyTheFolder.Name = "mnuEmptyTheFolder";
            this.mnuEmptyTheFolder.Size = new System.Drawing.Size(485, 38);
            this.mnuEmptyTheFolder.Text = "Empty Folder";
            this.mnuEmptyTheFolder.Click += new System.EventHandler(this.mnuEmptyTheFolder_Click);
            // 
            // mnuCopyFolder
            // 
            this.mnuCopyFolder.Name = "mnuCopyFolder";
            this.mnuCopyFolder.Size = new System.Drawing.Size(485, 38);
            this.mnuCopyFolder.Text = "Copy Folder...";
            this.mnuCopyFolder.Click += new System.EventHandler(this.CopyFolderMenu_Click);
            // 
            // mnuMoveFolder
            // 
            this.mnuMoveFolder.Name = "mnuMoveFolder";
            this.mnuMoveFolder.Size = new System.Drawing.Size(485, 38);
            this.mnuMoveFolder.Text = "Move Folder...";
            this.mnuMoveFolder.Click += new System.EventHandler(this.MoveFolderMenu_Click);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(482, 6);
            // 
            // mnuDumpMIMEContents
            // 
            this.mnuDumpMIMEContents.Name = "mnuDumpMIMEContents";
            this.mnuDumpMIMEContents.Size = new System.Drawing.Size(485, 38);
            this.mnuDumpMIMEContents.Text = "Save Folder Contents as MIME...";
            this.mnuDumpMIMEContents.Click += new System.EventHandler(this.DumpMimeContentsMenu_Click);
            // 
            // mnuDumpXMLContents
            // 
            this.mnuDumpXMLContents.Name = "mnuDumpXMLContents";
            this.mnuDumpXMLContents.Size = new System.Drawing.Size(485, 38);
            this.mnuDumpXMLContents.Text = "Save Folder Contents as XML...";
            this.mnuDumpXMLContents.Click += new System.EventHandler(this.DumpXmlContentsMenu_Click);
            // 
            // addExtendedPropertyToolStripMenuItem
            // 
            this.addExtendedPropertyToolStripMenuItem.Name = "addExtendedPropertyToolStripMenuItem";
            this.addExtendedPropertyToolStripMenuItem.Size = new System.Drawing.Size(485, 38);
            this.addExtendedPropertyToolStripMenuItem.Text = "Add Extended Property...";
            this.addExtendedPropertyToolStripMenuItem.Click += new System.EventHandler(this.AddExtendedPropertyToolStripMenuItem_Click);
            // 
            // toolStripMenuItem14
            // 
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            this.toolStripMenuItem14.Size = new System.Drawing.Size(482, 6);
            // 
            // mnuFolderCalendarView
            // 
            this.mnuFolderCalendarView.Name = "mnuFolderCalendarView";
            this.mnuFolderCalendarView.Size = new System.Drawing.Size(485, 38);
            this.mnuFolderCalendarView.Text = "CalendarView... ";
            this.mnuFolderCalendarView.Click += new System.EventHandler(this.MnuFolderCalendarView_Click);
            // 
            // mnuFolderCalendarItemsBreakdown
            // 
            this.mnuFolderCalendarItemsBreakdown.Name = "mnuFolderCalendarItemsBreakdown";
            this.mnuFolderCalendarItemsBreakdown.Size = new System.Drawing.Size(485, 38);
            this.mnuFolderCalendarItemsBreakdown.Text = "Calendar Items Breakdown...";
            this.mnuFolderCalendarItemsBreakdown.Visible = false;
            this.mnuFolderCalendarItemsBreakdown.Click += new System.EventHandler(this.mnuFolderCalendarItemsBreakdown_Click);
            // 
            // mnuNewItem
            // 
            this.mnuNewItem.Name = "mnuNewItem";
            this.mnuNewItem.Size = new System.Drawing.Size(485, 38);
            this.mnuNewItem.Text = "New... ";
            this.mnuNewItem.Click += new System.EventHandler(this.MnuNewItem_Click);
            // 
            // SearchFoldersMenuItem
            // 
            this.SearchFoldersMenuItem.Name = "SearchFoldersMenuItem";
            this.SearchFoldersMenuItem.Size = new System.Drawing.Size(485, 38);
            this.SearchFoldersMenuItem.Text = "Search For Folders...";
            this.SearchFoldersMenuItem.Click += new System.EventHandler(this.SearchFoldersMenuItem_Click);
            // 
            // SearchItemsMenuItem
            // 
            this.SearchItemsMenuItem.Name = "SearchItemsMenuItem";
            this.SearchItemsMenuItem.Size = new System.Drawing.Size(485, 38);
            this.SearchItemsMenuItem.Text = "Search For Items...";
            this.SearchItemsMenuItem.Click += new System.EventHandler(this.SearchItemsMenuItem_Click);
            // 
            // SearchForCalendarItemsToolStripMenuItem
            // 
            this.SearchForCalendarItemsToolStripMenuItem.Name = "SearchForCalendarItemsToolStripMenuItem";
            this.SearchForCalendarItemsToolStripMenuItem.Size = new System.Drawing.Size(485, 38);
            this.SearchForCalendarItemsToolStripMenuItem.Text = "Search For Calendar Items...";
            this.SearchForCalendarItemsToolStripMenuItem.Click += new System.EventHandler(this.SearchForCalendarItemsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(482, 6);
            // 
            // developerFolderTestFormToolStripMenuItem
            // 
            this.developerFolderTestFormToolStripMenuItem.Name = "developerFolderTestFormToolStripMenuItem";
            this.developerFolderTestFormToolStripMenuItem.Size = new System.Drawing.Size(485, 38);
            this.developerFolderTestFormToolStripMenuItem.Text = "Developer Folder Test  Form....";
            this.developerFolderTestFormToolStripMenuItem.Click += new System.EventHandler(this.developerFolderTestFormToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(266, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(266, 6);
            // 
            // propertyListItemBindingSource
            // 
            this.propertyListItemBindingSource.CurrentChanged += new System.EventHandler(this.propertyListItemBindingSource_CurrentChanged);
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
            this.mnuServiceContext.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mnuServiceContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditExchangeService,
            this.toolStripMenuItem10,
            this.mnuAddRootFolder,
            this.toolStripMenuItem6,
            this.mnuContextCloseExchangeService});
            this.mnuServiceContext.Name = "mnuServiceContext";
            this.mnuServiceContext.Size = new System.Drawing.Size(337, 130);
            // 
            // mnuEditExchangeService
            // 
            this.mnuEditExchangeService.Name = "mnuEditExchangeService";
            this.mnuEditExchangeService.Size = new System.Drawing.Size(336, 38);
            this.mnuEditExchangeService.Text = "Edit Exchange Service...";
            this.mnuEditExchangeService.Click += new System.EventHandler(this.EditExchangeServiceMenu_Click);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(333, 6);
            // 
            // mnuAddRootFolder
            // 
            this.mnuAddRootFolder.Name = "mnuAddRootFolder";
            this.mnuAddRootFolder.Size = new System.Drawing.Size(336, 38);
            this.mnuAddRootFolder.Text = "Add Root Folder...";
            this.mnuAddRootFolder.Click += new System.EventHandler(this.AddRootFolderMenu_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(333, 6);
            // 
            // mnuContextCloseExchangeService
            // 
            this.mnuContextCloseExchangeService.Name = "mnuContextCloseExchangeService";
            this.mnuContextCloseExchangeService.Size = new System.Drawing.Size(336, 38);
            this.mnuContextCloseExchangeService.Text = "Close ExchangeService";
            this.mnuContextCloseExchangeService.Click += new System.EventHandler(this.CloseExchangeServiceButton_Click);
            // 
            // FolderTreeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1416, 891);
            this.Controls.Add(this.splitter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(14, 11, 14, 11);
            this.Name = "FolderTreeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FolderTreeForm_Load);
            this.Controls.SetChildIndex(this.splitter, 0);
            this.splitter.Panel1.ResumeLayout(false);
            this.splitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitter)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem mnuEmptyFolder;
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

        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem14;
        private System.Windows.Forms.ToolStripMenuItem mnuFolderCalendarView; 
        private System.Windows.Forms.ToolStripMenuItem mnuNewItem;
        private System.Windows.Forms.ToolStripMenuItem SearchItemsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EmptyFolderMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuEmptyTheFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem developerFolderTestFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SearchFoldersMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFolderCalendarItemsBreakdown;
        private System.Windows.Forms.ToolStripMenuItem SearchForCalendarItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFolderRetentionFlags;
        private System.Windows.Forms.ToolStripMenuItem mnuFolderArchiveFlags;
    }
}
