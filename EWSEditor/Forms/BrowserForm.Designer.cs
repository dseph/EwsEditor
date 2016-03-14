﻿namespace EWSEditor.Forms
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
            this.mnuEwsPost = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToolsSplit1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuResolveName = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuResolveExProp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToolsSplit2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuNotification = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStreamingNotification = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSynchronization = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuToolsSplit3 = new System.Windows.Forms.ToolStripSeparator();
            this.checkForErrorsLoadingPropertiesOnFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDisplayDelegates = new System.Windows.Forms.ToolStripMenuItem();
            this.UserOofSettingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UserAvailabilityMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MeetingRoomsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DistributionListMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InboxRulesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConvertIdMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serverTimeZoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TimeZonemenuitem = new System.Windows.Forms.ToolStripMenuItem();
            this.UserConfigurationMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eDiscoverySearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mailAppsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMailTips = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.OptionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSharedCalendars = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOther = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenItemById = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenFolderById = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGetConversationItems = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOtherSplit1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFindAppointments = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuWindowsUserInformation = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSnmClient = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEncodingHelper = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileContentHelper = new System.Windows.Forms.ToolStripMenuItem();
            this.viewHTMLInBrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip.SuspendLayout();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblExchangeService});
            this.statusStrip.Location = new System.Drawing.Point(0, 636);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip.Size = new System.Drawing.Size(932, 22);
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
            this.mnuMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuView,
            this.mnuTools,
            this.mnuOther,
            this.mnuHelp});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.mnuMain.Size = new System.Drawing.Size(932, 24);
            this.mnuMain.TabIndex = 4;
            this.mnuMain.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnuMain_ItemClicked);
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "File";
            this.mnuFile.Click += new System.EventHandler(this.mnuFile_Click);
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
            this.mnuEwsPost,
            this.mnuToolsSplit1,
            this.mnuResolveName,
            this.mnuResolveExProp,
            this.mnuToolsSplit2,
            this.mnuNotification,
            this.mnuStreamingNotification,
            this.mnuSynchronization,
            this.mnuToolsSplit3,
            this.checkForErrorsLoadingPropertiesOnFolderToolStripMenuItem,
            this.mnuDisplayDelegates,
            this.UserOofSettingsMenuItem,
            this.UserAvailabilityMenuItem,
            this.MeetingRoomsMenuItem,
            this.DistributionListMenuItem,
            this.InboxRulesMenuItem,
            this.ConvertIdMenuItem,
            this.serverTimeZoneToolStripMenuItem,
            this.TimeZonemenuitem,
            this.UserConfigurationMenuItem,
            this.eDiscoverySearchToolStripMenuItem,
            this.mailAppsToolStripMenuItem,
            this.mnuMailTips,
            this.toolStripMenuItem1,
            this.OptionsMenuItem,
            this.mnuSharedCalendars});
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.Size = new System.Drawing.Size(47, 20);
            this.mnuTools.Text = "Tools";
            // 
            // DebugLogVeiwerMenuItem
            // 
            this.DebugLogVeiwerMenuItem.Name = "DebugLogVeiwerMenuItem";
            this.DebugLogVeiwerMenuItem.Size = new System.Drawing.Size(315, 22);
            this.DebugLogVeiwerMenuItem.Text = "EWSEditor Log Viewer...";
            this.DebugLogVeiwerMenuItem.Click += new System.EventHandler(this.DebugLogVeiwerMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(312, 6);
            // 
            // mnuAutoDiscoverView
            // 
            this.mnuAutoDiscoverView.Name = "mnuAutoDiscoverView";
            this.mnuAutoDiscoverView.Size = new System.Drawing.Size(315, 22);
            this.mnuAutoDiscoverView.Text = "Autodiscover Viewer...";
            this.mnuAutoDiscoverView.Click += new System.EventHandler(this.MnuAutoDiscoverView_Click);
            // 
            // mnuEwsPost
            // 
            this.mnuEwsPost.Name = "mnuEwsPost";
            this.mnuEwsPost.Size = new System.Drawing.Size(315, 22);
            this.mnuEwsPost.Text = "EWS POST...";
            this.mnuEwsPost.Click += new System.EventHandler(this.mnuEwsPost_Click);
            // 
            // mnuToolsSplit1
            // 
            this.mnuToolsSplit1.Name = "mnuToolsSplit1";
            this.mnuToolsSplit1.Size = new System.Drawing.Size(312, 6);
            // 
            // mnuResolveName
            // 
            this.mnuResolveName.Name = "mnuResolveName";
            this.mnuResolveName.Size = new System.Drawing.Size(315, 22);
            this.mnuResolveName.Text = "Resolve Name...";
            this.mnuResolveName.Click += new System.EventHandler(this.MnuResolveName_Click);
            // 
            // mnuResolveExProp
            // 
            this.mnuResolveExProp.Name = "mnuResolveExProp";
            this.mnuResolveExProp.Size = new System.Drawing.Size(315, 22);
            this.mnuResolveExProp.Text = "Extended Property Resolver...";
            this.mnuResolveExProp.Click += new System.EventHandler(this.MnuResolveExProp_Click);
            // 
            // mnuToolsSplit2
            // 
            this.mnuToolsSplit2.Name = "mnuToolsSplit2";
            this.mnuToolsSplit2.Size = new System.Drawing.Size(312, 6);
            // 
            // mnuNotification
            // 
            this.mnuNotification.Name = "mnuNotification";
            this.mnuNotification.Size = new System.Drawing.Size(315, 22);
            this.mnuNotification.Text = "Pull Notifications Viewer...";
            this.mnuNotification.Click += new System.EventHandler(this.MnuNotification_Click);
            // 
            // mnuStreamingNotification
            // 
            this.mnuStreamingNotification.Name = "mnuStreamingNotification";
            this.mnuStreamingNotification.Size = new System.Drawing.Size(315, 22);
            this.mnuStreamingNotification.Text = "Streaming Notifications Viewer...";
            this.mnuStreamingNotification.Click += new System.EventHandler(this.MnuStreamingNotification_Click);
            // 
            // mnuSynchronization
            // 
            this.mnuSynchronization.Name = "mnuSynchronization";
            this.mnuSynchronization.Size = new System.Drawing.Size(315, 22);
            this.mnuSynchronization.Text = "Item Synchronization Viewer..";
            this.mnuSynchronization.Click += new System.EventHandler(this.MnuSynchronization_Click);
            // 
            // mnuToolsSplit3
            // 
            this.mnuToolsSplit3.Name = "mnuToolsSplit3";
            this.mnuToolsSplit3.Size = new System.Drawing.Size(312, 6);
            // 
            // checkForErrorsLoadingPropertiesOnFolderToolStripMenuItem
            // 
            this.checkForErrorsLoadingPropertiesOnFolderToolStripMenuItem.Name = "checkForErrorsLoadingPropertiesOnFolderToolStripMenuItem";
            this.checkForErrorsLoadingPropertiesOnFolderToolStripMenuItem.Size = new System.Drawing.Size(315, 22);
            this.checkForErrorsLoadingPropertiesOnFolderToolStripMenuItem.Text = "Check for errors loading properties on Items...";
            this.checkForErrorsLoadingPropertiesOnFolderToolStripMenuItem.Click += new System.EventHandler(this.checkForErrorsLoadingPropertiesOnFolderToolStripMenuItem_Click);
            // 
            // mnuDisplayDelegates
            // 
            this.mnuDisplayDelegates.Name = "mnuDisplayDelegates";
            this.mnuDisplayDelegates.Size = new System.Drawing.Size(315, 22);
            this.mnuDisplayDelegates.Text = "Delegate Information...";
            this.mnuDisplayDelegates.Click += new System.EventHandler(this.MnuDelegateInformation_Click);
            // 
            // UserOofSettingsMenuItem
            // 
            this.UserOofSettingsMenuItem.Name = "UserOofSettingsMenuItem";
            this.UserOofSettingsMenuItem.Size = new System.Drawing.Size(315, 22);
            this.UserOofSettingsMenuItem.Text = "User OOF Settings...";
            this.UserOofSettingsMenuItem.Click += new System.EventHandler(this.MnuOOFSettings_Click);
            // 
            // UserAvailabilityMenuItem
            // 
            this.UserAvailabilityMenuItem.Name = "UserAvailabilityMenuItem";
            this.UserAvailabilityMenuItem.Size = new System.Drawing.Size(315, 22);
            this.UserAvailabilityMenuItem.Text = "User Availability...";
            this.UserAvailabilityMenuItem.Click += new System.EventHandler(this.MnuAvailability_Click);
            // 
            // MeetingRoomsMenuItem
            // 
            this.MeetingRoomsMenuItem.Name = "MeetingRoomsMenuItem";
            this.MeetingRoomsMenuItem.Size = new System.Drawing.Size(315, 22);
            this.MeetingRoomsMenuItem.Text = "Meeting Rooms...";
            this.MeetingRoomsMenuItem.Click += new System.EventHandler(this.MeetingRoomsMenuItem_Click);
            // 
            // DistributionListMenuItem
            // 
            this.DistributionListMenuItem.Name = "DistributionListMenuItem";
            this.DistributionListMenuItem.Size = new System.Drawing.Size(315, 22);
            this.DistributionListMenuItem.Text = "Distibution List Expansion...";
            this.DistributionListMenuItem.Click += new System.EventHandler(this.DistributionListMenuItem_Click);
            // 
            // InboxRulesMenuItem
            // 
            this.InboxRulesMenuItem.Name = "InboxRulesMenuItem";
            this.InboxRulesMenuItem.Size = new System.Drawing.Size(315, 22);
            this.InboxRulesMenuItem.Text = "Inbox Rules...";
            this.InboxRulesMenuItem.Click += new System.EventHandler(this.InboxRulesMenuItem_Click);
            // 
            // ConvertIdMenuItem
            // 
            this.ConvertIdMenuItem.Name = "ConvertIdMenuItem";
            this.ConvertIdMenuItem.Size = new System.Drawing.Size(315, 22);
            this.ConvertIdMenuItem.Text = "ConvertId...";
            this.ConvertIdMenuItem.Click += new System.EventHandler(this.ConvertIdMenu_Click);
            // 
            // serverTimeZoneToolStripMenuItem
            // 
            this.serverTimeZoneToolStripMenuItem.Name = "serverTimeZoneToolStripMenuItem";
            this.serverTimeZoneToolStripMenuItem.Size = new System.Drawing.Size(315, 22);
            this.serverTimeZoneToolStripMenuItem.Text = "Server TimeZone";
            this.serverTimeZoneToolStripMenuItem.Click += new System.EventHandler(this.serverTimeZoneToolStripMenuItem_Click);
            // 
            // TimeZonemenuitem
            // 
            this.TimeZonemenuitem.Name = "TimeZonemenuitem";
            this.TimeZonemenuitem.Size = new System.Drawing.Size(315, 22);
            this.TimeZonemenuitem.Text = "TimeZone Helper...";
            this.TimeZonemenuitem.Click += new System.EventHandler(this.TimeZonemenuitem_Click);
            // 
            // UserConfigurationMenuItem
            // 
            this.UserConfigurationMenuItem.Name = "UserConfigurationMenuItem";
            this.UserConfigurationMenuItem.Size = new System.Drawing.Size(315, 22);
            this.UserConfigurationMenuItem.Text = "User Configuration";
            this.UserConfigurationMenuItem.Click += new System.EventHandler(this.UserConfigurationMenuItem_Click);
            // 
            // eDiscoverySearchToolStripMenuItem
            // 
            this.eDiscoverySearchToolStripMenuItem.Name = "eDiscoverySearchToolStripMenuItem";
            this.eDiscoverySearchToolStripMenuItem.Size = new System.Drawing.Size(315, 22);
            this.eDiscoverySearchToolStripMenuItem.Text = "eDiscoverySearch";
            this.eDiscoverySearchToolStripMenuItem.Click += new System.EventHandler(this.eDiscoverySearchToolStripMenuItem_Click);
            // 
            // mailAppsToolStripMenuItem
            // 
            this.mailAppsToolStripMenuItem.Name = "mailAppsToolStripMenuItem";
            this.mailAppsToolStripMenuItem.Size = new System.Drawing.Size(315, 22);
            this.mailAppsToolStripMenuItem.Text = "Mail Apps";
            this.mailAppsToolStripMenuItem.Click += new System.EventHandler(this.mailAppsToolStripMenuItem_Click);
            // 
            // mnuMailTips
            // 
            this.mnuMailTips.Name = "mnuMailTips";
            this.mnuMailTips.Size = new System.Drawing.Size(315, 22);
            this.mnuMailTips.Text = "Mail Tips";
            this.mnuMailTips.Click += new System.EventHandler(this.mnuMailTips_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(312, 6);
            // 
            // OptionsMenuItem
            // 
            this.OptionsMenuItem.Name = "OptionsMenuItem";
            this.OptionsMenuItem.Size = new System.Drawing.Size(315, 22);
            this.OptionsMenuItem.Text = "Options...";
            this.OptionsMenuItem.Click += new System.EventHandler(this.OptionsMenuItem_Click);
            // 
            // mnuSharedCalendars
            // 
            this.mnuSharedCalendars.Name = "mnuSharedCalendars";
            this.mnuSharedCalendars.Size = new System.Drawing.Size(315, 22);
            this.mnuSharedCalendars.Text = "Test";
            this.mnuSharedCalendars.Click += new System.EventHandler(this.mnuSharedCalendars_Click);
            // 
            // mnuOther
            // 
            this.mnuOther.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpenItemById,
            this.mnuOpenFolderById,
            this.mnuGetConversationItems,
            this.mnuOtherSplit1,
            this.mnuFindAppointments,
            this.toolStripSeparator1,
            this.mnuWindowsUserInformation,
            this.mnuSnmClient,
            this.mnuEncodingHelper,
            this.mnuFileContentHelper,
            this.viewHTMLInBrowserToolStripMenuItem});
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
            // mnuGetConversationItems
            // 
            this.mnuGetConversationItems.Name = "mnuGetConversationItems";
            this.mnuGetConversationItems.Size = new System.Drawing.Size(268, 22);
            this.mnuGetConversationItems.Text = "Get Items by Conversation Id...";
            this.mnuGetConversationItems.Click += new System.EventHandler(this.mnuGetConversationItems_Click);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(265, 6);
            // 
            // mnuWindowsUserInformation
            // 
            this.mnuWindowsUserInformation.Name = "mnuWindowsUserInformation";
            this.mnuWindowsUserInformation.Size = new System.Drawing.Size(268, 22);
            this.mnuWindowsUserInformation.Text = "Run-time Information...";
            this.mnuWindowsUserInformation.Click += new System.EventHandler(this.mnuWindowsUserInformation_Click);
            // 
            // mnuSnmClient
            // 
            this.mnuSnmClient.Name = "mnuSnmClient";
            this.mnuSnmClient.Size = new System.Drawing.Size(268, 22);
            this.mnuSnmClient.Text = "System.Net.Mail Client...";
            this.mnuSnmClient.Click += new System.EventHandler(this.mnuSnmClient_Click_1);
            // 
            // mnuEncodingHelper
            // 
            this.mnuEncodingHelper.Name = "mnuEncodingHelper";
            this.mnuEncodingHelper.Size = new System.Drawing.Size(268, 22);
            this.mnuEncodingHelper.Text = "Encoding Helper...";
            this.mnuEncodingHelper.Click += new System.EventHandler(this.mnuEncode_Click);
            // 
            // mnuFileContentHelper
            // 
            this.mnuFileContentHelper.Name = "mnuFileContentHelper";
            this.mnuFileContentHelper.Size = new System.Drawing.Size(268, 22);
            this.mnuFileContentHelper.Text = "File Content Helper...";
            this.mnuFileContentHelper.Click += new System.EventHandler(this.mnuFileContentHelper_Click);
            // 
            // viewHTMLInBrowserToolStripMenuItem
            // 
            this.viewHTMLInBrowserToolStripMenuItem.Name = "viewHTMLInBrowserToolStripMenuItem";
            this.viewHTMLInBrowserToolStripMenuItem.Size = new System.Drawing.Size(268, 22);
            this.viewHTMLInBrowserToolStripMenuItem.Text = "View In Browser";
            this.viewHTMLInBrowserToolStripMenuItem.Click += new System.EventHandler(this.viewHTMLInBrowserToolStripMenuItem_Click);
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
            // BrowserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 658);
            this.Controls.Add(this.mnuMain);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
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
        public System.Windows.Forms.ToolStripMenuItem mnuAutoDiscoverView;
        public System.Windows.Forms.ToolStripMenuItem mnuEwsPost;
        public System.Windows.Forms.ToolStripMenuItem UserOofSettingsMenuItem;
        public System.Windows.Forms.ToolStripMenuItem UserAvailabilityMenuItem;
        public System.Windows.Forms.ToolStripMenuItem ConvertIdMenuItem;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem OptionsMenuItem;
        public System.Windows.Forms.ToolStripMenuItem DebugLogVeiwerMenuItem;
        public System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        public System.Windows.Forms.ToolStripMenuItem mnuStreamingNotification;
        public System.Windows.Forms.ToolStripMenuItem TimeZonemenuitem;
        public System.Windows.Forms.ToolStripMenuItem MeetingRoomsMenuItem;
        public System.Windows.Forms.ToolStripMenuItem DistributionListMenuItem;
        public System.Windows.Forms.ToolStripMenuItem InboxRulesMenuItem;
        public System.Windows.Forms.ToolStripMenuItem checkForErrorsLoadingPropertiesOnFolderToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem mnuGetConversationItems;
        public System.Windows.Forms.ToolStripMenuItem mnuWindowsUserInformation;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuSnmClient;
        private System.Windows.Forms.ToolStripMenuItem mnuEncodingHelper;
        public System.Windows.Forms.ToolStripMenuItem UserConfigurationMenuItem;
        public System.Windows.Forms.ToolStripMenuItem eDiscoverySearchToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem serverTimeZoneToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem mailAppsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileContentHelper;
        public System.Windows.Forms.ToolStripMenuItem mnuMailTips;
        private System.Windows.Forms.ToolStripMenuItem mnuSharedCalendars;
        private System.Windows.Forms.ToolStripMenuItem viewHTMLInBrowserToolStripMenuItem;
    }
}
