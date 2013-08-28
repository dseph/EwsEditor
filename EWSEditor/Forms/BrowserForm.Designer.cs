namespace EWSEditor.Forms
{
    partial class BrowserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowserForm));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblExchangeService = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewConfigPropertySet = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewResetPropertySet = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewSplit1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.DebugLogVeiwerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuAutoDiscoverView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToolsSplit1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuResolveName = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuResolveExProp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToolsSplit2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuNotification = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStreamingNotification = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSynchronization = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToolsSplit3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDisplayDelegates = new System.Windows.Forms.ToolStripMenuItem();
            this.UserOofSettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UserAvailabilityMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConvertIdMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TimeZonemenuitem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.OptionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOther = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenItemById = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenFolderById = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOtherSplit1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFindAppointments = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.MeetingRoomsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip.SuspendLayout();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblExchangeService});
            this.statusStrip.Location = new System.Drawing.Point(0, 513);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(699, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 3;
            // 
            // lblExchangeService
            // 
            this.lblExchangeService.Name = "lblExchangeService";
            this.lblExchangeService.Size = new System.Drawing.Size(0, 17);
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuView,
            this.mnuTools,
            this.mnuOther,
            this.mnuHelp});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(699, 24);
            this.mnuMain.TabIndex = 4;
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "File";
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(92, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.MnuExit_Click);
            // 
            // mnuView
            // 
            this.mnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuViewConfigPropertySet,
            this.mnuViewResetPropertySet,
            this.mnuViewSplit1,
            this.mnuRefresh});
            this.mnuView.Name = "mnuView";
            this.mnuView.Size = new System.Drawing.Size(44, 20);
            this.mnuView.Text = "View";
            // 
            // mnuViewConfigPropertySet
            // 
            this.mnuViewConfigPropertySet.Name = "mnuViewConfigPropertySet";
            this.mnuViewConfigPropertySet.Size = new System.Drawing.Size(236, 22);
            this.mnuViewConfigPropertySet.Text = "Configure Detail Property Set...";
            this.mnuViewConfigPropertySet.Click += new System.EventHandler(this.MnuPropertySet_Click);
            // 
            // mnuViewResetPropertySet
            // 
            this.mnuViewResetPropertySet.Name = "mnuViewResetPropertySet";
            this.mnuViewResetPropertySet.Size = new System.Drawing.Size(236, 22);
            this.mnuViewResetPropertySet.Text = "Reset Detail Property Set";
            this.mnuViewResetPropertySet.Click += new System.EventHandler(this.MnuRestorePropertySet_Click);
            // 
            // mnuViewSplit1
            // 
            this.mnuViewSplit1.Name = "mnuViewSplit1";
            this.mnuViewSplit1.Size = new System.Drawing.Size(233, 6);
            // 
            // mnuRefresh
            // 
            this.mnuRefresh.Name = "mnuRefresh";
            this.mnuRefresh.Size = new System.Drawing.Size(236, 22);
            this.mnuRefresh.Text = "Refresh";
            // 
            // mnuTools
            // 
            this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DebugLogVeiwerMenuItem,
            this.toolStripMenuItem2,
            this.mnuAutoDiscoverView,
            this.mnuToolsSplit1,
            this.mnuResolveName,
            this.mnuResolveExProp,
            this.mnuToolsSplit2,
            this.mnuNotification,
            this.mnuStreamingNotification,
            this.mnuSynchronization,
            this.mnuToolsSplit3,
            this.mnuDisplayDelegates,
            this.UserOofSettingsMenuItem,
            this.UserAvailabilityMenuItem,
            this.MeetingRoomsMenuItem,
            this.ConvertIdMenuItem,
            this.TimeZonemenuitem,
            this.toolStripMenuItem1,
            this.OptionsMenuItem});
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.Size = new System.Drawing.Size(48, 20);
            this.mnuTools.Text = "Tools";
            // 
            // DebugLogVeiwerMenuItem
            // 
            this.DebugLogVeiwerMenuItem.Name = "DebugLogVeiwerMenuItem";
            this.DebugLogVeiwerMenuItem.Size = new System.Drawing.Size(246, 22);
            this.DebugLogVeiwerMenuItem.Text = "EWSEditor Log Viewer...";
            this.DebugLogVeiwerMenuItem.Click += new System.EventHandler(this.DebugLogVeiwerMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(243, 6);
            // 
            // mnuAutoDiscoverView
            // 
            this.mnuAutoDiscoverView.Name = "mnuAutoDiscoverView";
            this.mnuAutoDiscoverView.Size = new System.Drawing.Size(246, 22);
            this.mnuAutoDiscoverView.Text = "Autodiscover Viewer...";
            this.mnuAutoDiscoverView.Click += new System.EventHandler(this.MnuAutoDiscoverView_Click);
            // 
            // mnuToolsSplit1
            // 
            this.mnuToolsSplit1.Name = "mnuToolsSplit1";
            this.mnuToolsSplit1.Size = new System.Drawing.Size(243, 6);
            // 
            // mnuResolveName
            // 
            this.mnuResolveName.Name = "mnuResolveName";
            this.mnuResolveName.Size = new System.Drawing.Size(246, 22);
            this.mnuResolveName.Text = "Resolve Name...";
            this.mnuResolveName.Click += new System.EventHandler(this.MnuResolveName_Click);
            // 
            // mnuResolveExProp
            // 
            this.mnuResolveExProp.Name = "mnuResolveExProp";
            this.mnuResolveExProp.Size = new System.Drawing.Size(246, 22);
            this.mnuResolveExProp.Text = "Extended Property Resolver...";
            this.mnuResolveExProp.Click += new System.EventHandler(this.MnuResolveExProp_Click);
            // 
            // mnuToolsSplit2
            // 
            this.mnuToolsSplit2.Name = "mnuToolsSplit2";
            this.mnuToolsSplit2.Size = new System.Drawing.Size(243, 6);
            // 
            // mnuNotification
            // 
            this.mnuNotification.Name = "mnuNotification";
            this.mnuNotification.Size = new System.Drawing.Size(246, 22);
            this.mnuNotification.Text = "Pull Notifications Viewer...";
            this.mnuNotification.Click += new System.EventHandler(this.MnuNotification_Click);
            // 
            // mnuStreamingNotification
            // 
            this.mnuStreamingNotification.Name = "mnuStreamingNotification";
            this.mnuStreamingNotification.Size = new System.Drawing.Size(246, 22);
            this.mnuStreamingNotification.Text = "Streaming Notifications Viewer...";
            this.mnuStreamingNotification.Click += new System.EventHandler(this.MnuStreamingNotification_Click);
            // 
            // mnuSynchronization
            // 
            this.mnuSynchronization.Name = "mnuSynchronization";
            this.mnuSynchronization.Size = new System.Drawing.Size(246, 22);
            this.mnuSynchronization.Text = "Item Synchronization Viewer..";
            this.mnuSynchronization.Click += new System.EventHandler(this.MnuSynchronization_Click);
            // 
            // mnuToolsSplit3
            // 
            this.mnuToolsSplit3.Name = "mnuToolsSplit3";
            this.mnuToolsSplit3.Size = new System.Drawing.Size(243, 6);
            // 
            // mnuDisplayDelegates
            // 
            this.mnuDisplayDelegates.Name = "mnuDisplayDelegates";
            this.mnuDisplayDelegates.Size = new System.Drawing.Size(246, 22);
            this.mnuDisplayDelegates.Text = "Delegate Information...";
            this.mnuDisplayDelegates.Click += new System.EventHandler(this.MnuDelegateInformation_Click);
            // 
            // UserOofSettingsMenuItem
            // 
            this.UserOofSettingsMenuItem.Name = "UserOofSettingsMenuItem";
            this.UserOofSettingsMenuItem.Size = new System.Drawing.Size(246, 22);
            this.UserOofSettingsMenuItem.Text = "User OOF Settings...";
            this.UserOofSettingsMenuItem.Click += new System.EventHandler(this.MnuOOFSettings_Click);
            // 
            // UserAvailabilityMenuItem
            // 
            this.UserAvailabilityMenuItem.Name = "UserAvailabilityMenuItem";
            this.UserAvailabilityMenuItem.Size = new System.Drawing.Size(246, 22);
            this.UserAvailabilityMenuItem.Text = "User Availability...";
            this.UserAvailabilityMenuItem.Click += new System.EventHandler(this.MnuAvailability_Click);
            // 
            // ConvertIdMenuItem
            // 
            this.ConvertIdMenuItem.Name = "ConvertIdMenuItem";
            this.ConvertIdMenuItem.Size = new System.Drawing.Size(246, 22);
            this.ConvertIdMenuItem.Text = "ConvertId...";
            this.ConvertIdMenuItem.Click += new System.EventHandler(this.ConvertIdMenu_Click);
            // 
            // TimeZonemenuitem
            // 
            this.TimeZonemenuitem.Name = "TimeZonemenuitem";
            this.TimeZonemenuitem.Size = new System.Drawing.Size(246, 22);
            this.TimeZonemenuitem.Text = "TimeZone";
            this.TimeZonemenuitem.Click += new System.EventHandler(this.TimeZonemenuitem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(243, 6);
            // 
            // OptionsMenuItem
            // 
            this.OptionsMenuItem.Name = "OptionsMenuItem";
            this.OptionsMenuItem.Size = new System.Drawing.Size(246, 22);
            this.OptionsMenuItem.Text = "Options...";
            this.OptionsMenuItem.Click += new System.EventHandler(this.OptionsMenuItem_Click);
            // 
            // mnuOther
            // 
            this.mnuOther.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpenItemById,
            this.mnuOpenFolderById,
            this.mnuOtherSplit1,
            this.mnuFindAppointments});
            this.mnuOther.Name = "mnuOther";
            this.mnuOther.Size = new System.Drawing.Size(49, 20);
            this.mnuOther.Text = "Other";
            // 
            // mnuOpenItemById
            // 
            this.mnuOpenItemById.Name = "mnuOpenItemById";
            this.mnuOpenItemById.Size = new System.Drawing.Size(268, 22);
            this.mnuOpenItemById.Text = "Open Item by Id...";
            this.mnuOpenItemById.Click += new System.EventHandler(this.MnuOpenItemById_Click);
            // 
            // mnuOpenFolderById
            // 
            this.mnuOpenFolderById.Name = "mnuOpenFolderById";
            this.mnuOpenFolderById.Size = new System.Drawing.Size(268, 22);
            this.mnuOpenFolderById.Text = "Open Folder by Id...";
            this.mnuOpenFolderById.Click += new System.EventHandler(this.MnuOpenFolderById_Click);
            // 
            // mnuOtherSplit1
            // 
            this.mnuOtherSplit1.Name = "mnuOtherSplit1";
            this.mnuOtherSplit1.Size = new System.Drawing.Size(265, 6);
            // 
            // mnuFindAppointments
            // 
            this.mnuFindAppointments.Name = "mnuFindAppointments";
            this.mnuFindAppointments.Size = new System.Drawing.Size(268, 22);
            this.mnuFindAppointments.Text = "Find Appointments (CalendarView)...";
            this.mnuFindAppointments.Click += new System.EventHandler(this.MnuFindAppointments_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(44, 20);
            this.mnuHelp.Text = "Help";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(164, 22);
            this.mnuAbout.Text = "About EWSEditor";
            this.mnuAbout.Click += new System.EventHandler(this.MnuAbout_Click);
            // 
            // MeetingRoomsMenuItem
            // 
            this.MeetingRoomsMenuItem.Name = "MeetingRoomsMenuItem";
            this.MeetingRoomsMenuItem.Size = new System.Drawing.Size(246, 22);
            this.MeetingRoomsMenuItem.Text = "Meeting Rooms";
            this.MeetingRoomsMenuItem.Click += new System.EventHandler(this.MeetingRoomsMenuItem_Click);
            // 
            // BrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 535);
            this.Controls.Add(this.mnuMain);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BrowserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.BrowserForm_Load_1);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblExchangeService;
        public System.Windows.Forms.MenuStrip mnuMain;
        public System.Windows.Forms.ToolStripMenuItem mnuFile;
        public System.Windows.Forms.ToolStripMenuItem mnuExit;
        public System.Windows.Forms.ToolStripMenuItem mnuView;
        public System.Windows.Forms.ToolStripMenuItem mnuViewConfigPropertySet;
        public System.Windows.Forms.ToolStripMenuItem mnuViewResetPropertySet;
        public System.Windows.Forms.ToolStripSeparator mnuViewSplit1;
        public System.Windows.Forms.ToolStripMenuItem mnuRefresh;
        public System.Windows.Forms.ToolStripSeparator mnuToolsSplit1;
        public System.Windows.Forms.ToolStripMenuItem mnuResolveName;
        public System.Windows.Forms.ToolStripMenuItem mnuResolveExProp;
        public System.Windows.Forms.ToolStripSeparator mnuToolsSplit2;
        public System.Windows.Forms.ToolStripMenuItem mnuNotification;
        public System.Windows.Forms.ToolStripMenuItem mnuSynchronization;
        public System.Windows.Forms.ToolStripSeparator mnuToolsSplit3;
        public System.Windows.Forms.ToolStripMenuItem mnuDisplayDelegates;
        public System.Windows.Forms.ToolStripMenuItem mnuOther;
        public System.Windows.Forms.ToolStripMenuItem mnuOpenItemById;
        public System.Windows.Forms.ToolStripMenuItem mnuOpenFolderById;
        public System.Windows.Forms.ToolStripSeparator mnuOtherSplit1;
        public System.Windows.Forms.ToolStripMenuItem mnuFindAppointments;
        public System.Windows.Forms.ToolStripMenuItem mnuHelp;
        public System.Windows.Forms.ToolStripMenuItem mnuAbout;
        public System.Windows.Forms.ToolStripMenuItem mnuTools;
        private System.Windows.Forms.ToolStripMenuItem mnuAutoDiscoverView;
        protected System.Windows.Forms.ToolStripMenuItem UserOofSettingsMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem UserAvailabilityMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem ConvertIdMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem OptionsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DebugLogVeiwerMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        public System.Windows.Forms.ToolStripMenuItem mnuStreamingNotification;
        private System.Windows.Forms.ToolStripMenuItem TimeZonemenuitem;
        private System.Windows.Forms.ToolStripMenuItem MeetingRoomsMenuItem;
    }
}
