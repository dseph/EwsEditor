using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EWSEditor.Common.Extensions;
using EWSEditor.Common.ServiceProfiles;
using EWSEditor.Logging;
using EWSEditor.PropertyInformation;
using EWSEditor.Resources;
using EWSEditor.Settings;
using Microsoft.Exchange.WebServices.Data;
using EWSEditor.Exchange;
using EWSEditor.Common;

namespace EWSEditor.Forms
{
    public partial class FolderTreeForm : BrowserForm
    {
        private const int ExchangeServiceImageIndex = 0;
        private const int FolderImageIndex = 1;
        private const int CalendarFolderImageIndex = 2;
        private const int ContactFolderImageIndex = 3;
        private const int TaskFolderImageIndex = 4;

        // EWSEditor:5554 Add a timer to the BeforeExpand event of the tree view to give the
        // NodeMouseDoubleClick event time to fire.  If it does, then don't expand.
        private const int DeferredTreeViewActionInterval = 100;
        private Timer deferredTreeViewActionTimer = null;
        private TreeViewAction? deferredTreeViewAction = null;

        // https://blogs.msdn.microsoft.com/akashb/2011/08/10/stamping-retention-policy-tag-using-ews-managed-api-1-1-from-powershellexchange-2010/

        //private static ExtendedPropertyDefinition Prop_IsHidden = new ExtendedPropertyDefinition(0x10f4, MapiPropertyType.Boolean);

        private static ExtendedPropertyDefinition Prop_PR_IS_HIDDEN = new ExtendedPropertyDefinition(0x10f4, MapiPropertyType.Boolean);
        private static ExtendedPropertyDefinition Prop_FolderPath = new ExtendedPropertyDefinition(0x66B5, MapiPropertyType.String);                 // Folder Path - PR_Folder_Path
        // private static ExtendedPropertyDefinition Prop_PR_RETENTION_FLAGS = new ExtendedPropertyDefinition(0x301D, MapiPropertyType.Integer);        //  Item - PidTagRetentionFlags - PR_RETENTION_FLAGS 0x301D   
        // private static ExtendedPropertyDefinition Prop_PR_RETENTION_PERIOD = new ExtendedPropertyDefinition(0x301A, MapiPropertyType.Integer);      //  Item - PidTagRetentionPeriod - PR_RETENTION_PERIOD 0x301A
        // private static ExtendedPropertyDefinition Prop_PR_ATTACH_ON_NORMAL_MSG_COUNT = new ExtendedPropertyDefinition(0x66B1, MapiPropertyType.Long);    // PR_ATTACH_ON_NORMAL_MSG_COUNT 0x66B1

        // private static ExtendedPropertyDefinition Prop_PidTagMessageSizeExtended = new ExtendedPropertyDefinition(0xe08, MapiPropertyType.Long);        // Message - PidTagMessageSizeExtended - PR_MESSAGE_SIZE_EXTENDED
        private static ExtendedPropertyDefinition Prop_PidTagDeletedOn = new ExtendedPropertyDefinition(0x668F, MapiPropertyType.SystemTime);           // Folder/Item - PidTagDeletedOn - PR_DELETED_ON
        private static ExtendedPropertyDefinition Prop_PidTagFolderFlags = new ExtendedPropertyDefinition(0x66A8, MapiPropertyType.Integer);            // Folder - PidTagFolderFlags - PR_FOLDER_FLAGS
        private static ExtendedPropertyDefinition Prop_PidTagLocalCommitTime = new ExtendedPropertyDefinition(0x6709, MapiPropertyType.SystemTime);     // Folder/item - PidTagLocalCommitTime - PR_LOCAL_COMMIT_TIME
        private static ExtendedPropertyDefinition Prop_PidTagLocalCommitTimeMax = new ExtendedPropertyDefinition(0x670A, MapiPropertyType.SystemTime);  // Folder/item - PidTagLocalCommitTimeMax - PR_LOCAL_COMMIT_TIME_MAX
        private static ExtendedPropertyDefinition Prop_PidTagDeletedCountTotal = new ExtendedPropertyDefinition(0x0003, MapiPropertyType.Integer);      // Folder - PidTagDeletedCountTotal - PR_DELETED_COUNT_TOTAL

        // private static ExtendedPropertyDefinition Prop_PidTagArchiveTag = new ExtendedPropertyDefinition(0x3018, MapiPropertyType.Binary);              // Guid of Archive tag - PR_ARCHIVE_TAG - PidTagArchiveTag 
        // private static ExtendedPropertyDefinition Prop_PidTagPolicyTag = new ExtendedPropertyDefinition(0x3019, MapiPropertyType.Integer);              // Item - PidTagPolicyTag - PR_POLICY_TAG
        // private static ExtendedPropertyDefinition Prop_PidTagRetentionPeriod = new ExtendedPropertyDefinition(0x301A, MapiPropertyType.Integer);        // Message - PidTagRetentionPeriod - PR_RETENTION_PERIOD 
        // ?? https://blogs.msdn.microsoft.com/akashb/2011/08/10/stamping-retention-policy-tag-using-ews-managed-api-1-1-from-powershellexchange-2010/

        //  PR_COMMENT_W, PidTagComment http://schemas.microsoft.com/mapi/proptag/0x3004001E
        // PR_CREATION_TIME, PidTagCreationTime, ptagCreationTime http://schemas.microsoft.com/mapi/proptag/0x30070040
        // PR_HAS_RULES, PidTagHasRules, ptagHasRules   http://schemas.microsoft.com/mapi/proptag/0x663A000B
        // PR_LAST_MODIFICATION_TIME, PidTagLastModificationTime, ptagLastModificationTime  0x30080040

        private static ExtendedPropertyDefinition Prop_PR_COMMENT_W = new ExtendedPropertyDefinition(0x3004, MapiPropertyType.String);
        private static ExtendedPropertyDefinition Prop_PR_CREATION_TIME = new ExtendedPropertyDefinition(0x300, MapiPropertyType.SystemTime);
        private static ExtendedPropertyDefinition Prop_PR_HAS_RULES = new ExtendedPropertyDefinition(0x663A, MapiPropertyType.Boolean);
        private static ExtendedPropertyDefinition Prop_PR_LAST_MODIFICATION_TIME = new ExtendedPropertyDefinition(0x3008, MapiPropertyType.SystemTime);

        // PR_POLICY_TAG 0x3019   Data type: PtypBinary, 0x0102
        private static ExtendedPropertyDefinition Prop_PR_POLICY_TAG = new ExtendedPropertyDefinition(0x3019, MapiPropertyType.Binary);
        // PR_RETENTION_FLAGS 0x301D (12317)  PtypInteger32
        private static ExtendedPropertyDefinition Prop_Retention_Flags = new ExtendedPropertyDefinition(0x301D, MapiPropertyType.Integer);
        // PR_RETENTION_PERIOD 0x301A (12314)  PtypInteger32, 0x0003
        private static ExtendedPropertyDefinition Prop_Retention_Period = new ExtendedPropertyDefinition(0x301A, MapiPropertyType.Integer);
        // PR_FOLDER_TYPE 0x3601 (13825)
        private static ExtendedPropertyDefinition Prop_PR_FOLDER_TYPE = new ExtendedPropertyDefinition(0x3601, MapiPropertyType.Integer);


        private PropertySet folderNodePropertySet = new PropertySet(
            BasePropertySet.FirstClassProperties,
            new PropertyDefinitionBase[] { 
                FolderSchema.DisplayName, 
                FolderSchema.ChildFolderCount,
 
                FolderSchema.FolderClass, 
                FolderSchema.ManagedFolderInformation,  
    
                FolderSchema.TotalCount,  
                FolderSchema.UnreadCount,  
                FolderSchema.EffectiveRights,
 
                Prop_PR_IS_HIDDEN,
                Prop_FolderPath,
                Prop_PR_CREATION_TIME,
                Prop_PR_LAST_MODIFICATION_TIME,
                Prop_PR_POLICY_TAG,

                Prop_PR_COMMENT_W,
                Prop_PR_HAS_RULES,

                Prop_PR_FOLDER_TYPE,
                Prop_Retention_Period,
                Prop_Retention_Flags
 
 


                //Prop_Retention_Period,
                //Prop_RetentionFlags,
                //Prop_PidTagMessageSizeExtended,
                //Prop_PidTagDeletedOn,
                //Prop_PidTagFolderFlag,
                //Prop_PidTagLocalCommitTime,
                //Prop_PidTagLocalCommitTimeMax,
                //Prop_PidTagDeletedCountTotal,
                //Prop_PR_ATTACH_ON_NORMAL_MSG_COUNT,
                //Prop_PidTagArchiveTag,
                //Prop_PidTagPolicyTag,
                //Prop_PidTagRetentionPeriod
  
                // FolderSchema.WellKnownFolderName 
                // FolderSchema.PolicyTag,  
                // FolderSchema.ArchiveTag, 

 

            });

         //                   FolderSchema.ArchiveTag, 
   
 

        // MenuItems to add to the File menu
        private System.Windows.Forms.ToolStripMenuItem newExchangeServiceMenu = new ToolStripMenuItem();
        private System.Windows.Forms.ToolStripMenuItem openDefaultExchangeServiceMenu = new ToolStripMenuItem();
        private System.Windows.Forms.ToolStripMenuItem closeExchangeServiceMenu = new ToolStripMenuItem();
        private System.Windows.Forms.ToolStripSeparator fileSplitMenu1 = new ToolStripSeparator();
        private System.Windows.Forms.ToolStripMenuItem openProfileMenu = new ToolStripMenuItem();
        private System.Windows.Forms.ToolStripMenuItem saveProfileMenu = new ToolStripMenuItem();
        private System.Windows.Forms.ToolStripSeparator fileSplitMenu2 = new ToolStripSeparator();

        #region Constructors

        public FolderTreeForm()
        {
            InitializeComponent();
            this.InitializeFileMenu();
        }

        /// <summary>
        /// Initializes a new instance of the FolderTreeForm class and loads the 
        /// tree view based on the profile information passed in from the command line.
        /// </summary>
        /// <param name="profilePath">Path to the profile to load</param>
        public FolderTreeForm(string profilePath)
        {
            InitializeComponent();
            this.InitializeFileMenu();

            // Make sure the file exists
            if (!System.IO.File.Exists(profilePath))
            {
                DebugLog.WriteVerbose(string.Format("Leave: Profile path, {0}, does not exist", profilePath));
                return;
            }

            // Load the file into a ServiceProfile
            ServiceProfile profile = new ServiceProfile(profilePath, true, true);
            foreach (ServiceProfileItem item in profile.Items)
            {   
                TreeNode serviceNode = this.AddServiceToTreeView(item.Service, item.AppSettings, false);

                foreach (FolderId folder in item.RootFolderIds)
                {
                    try
                    {
                        this.AddRootFolderToTreeView(item.Service, item.AppSettings, folder, serviceNode);
                    }
                    catch (Exception ex)
                    {
                        // Keep going through the loop after showing exception
                        ErrorDialog.ShowError(ex);
                        DebugLog.WriteVerbose("Handled exception when adding root folders to service.", ex);
                    }
                }
            }

            // Ensure that the root node is selected
            if (this.FolderTreeView.Nodes.Count > 0)
            {
                this.FolderTreeView.SelectedNode = this.FolderTreeView.Nodes[0];
            }
        }

        #endregion

        public new EWSEditor.Common.EwsSession CurrentEwsSessionSettings
        {
            get
            {
                return base.CurrentEwsSessionSettings;
            }

            set
            {
                base.CurrentEwsSessionSettings = value;
            }
        }

        public new EWSEditor.Common.EwsEditorAppSettings CurrentAppSettings
        {
            get
            {
                return base.CurrentAppSettings;
            }

            set
            {
                base.CurrentAppSettings = value;
            }
        }

        /// <summary>
        /// Gets or sets the current ExchangeService selected in the TreeView.  When
        /// CurrentService is set to an ExchangeService enable certain controls and
        /// when set to null, disable the controls.
        /// </summary>
        public new ExchangeService CurrentService
        {
            get
            {
                return base.CurrentService;
            }

            set
            {
                base.CurrentService = value;

                // Is there a CurrentService set?
                bool isCurrentService = base.CurrentService != null;

                // Clear the property details grid if there is no service
                if (!isCurrentService)
                {
                    FolderPropertyDetailsGrid.Clear();
                }

                // Enable the following controls when connected...
                this.saveProfileMenu.Enabled = isCurrentService;
                this.closeExchangeServiceMenu.Enabled = isCurrentService;
                
                this.openDefaultExchangeServiceMenu.Enabled = !isCurrentService;
                this.openProfileMenu.Enabled = !isCurrentService;
                this.newExchangeServiceMenu.Enabled = !isCurrentService;

                // Actions Menu
                this.mnuOpenItemById.Enabled = isCurrentService;
                this.mnuOpenFolderById.Enabled = isCurrentService;
                this.mnuResolveName.Enabled = isCurrentService;
                this.mnuFindAppointments.Enabled = isCurrentService;
                //this.mnuGetConversationItems.Enabled = isCurrentService;
 
                // View Menu
                this.mnuRefresh.Enabled = isCurrentService;
                this.mnuViewResetPropertySet.Enabled = isCurrentService;
                this.mnuViewConfigPropertySet.Enabled = isCurrentService;

                // Tools Menu
                 
                this.mnuToolsNotificationsPullNotificationsViewer.Enabled = isCurrentService;
                this.mnuToolsNotificationsStreamingNotificationsViewer.Enabled = isCurrentService;
                this.mnuToolsNotificationsItemSynchronizationViewer.Enabled = isCurrentService && CurrentService.RequestedServerVersion.CompareTo(ExchangeVersion.Exchange2010_SP1) >= 0;  // Only enable streaming notifications for 2k10 SP1+

                //this.mnuNotification.Enabled = isCurrentService; // pull
                //this.mnuToolsNotificationsPullNotificationsViewer.Enabled = isCurrentService;
                //this.mnuStreamingNotification.Enabled = isCurrentService && CurrentService.RequestedServerVersion.CompareTo(ExchangeVersion.Exchange2010_SP1) >= 0;  // Only enable streaming notifications for 2k10 SP1+
       
                this.mnuToolsNotifications.Enabled = isCurrentService;
                this.mnuToolsNotificationsPullNotificationsViewer.Enabled = isCurrentService;
                this.mnuToolsNotificationsStreamingNotificationsViewer.Enabled = isCurrentService && CurrentService.RequestedServerVersion.CompareTo(ExchangeVersion.Exchange2010_SP1) >= 0;  // Only enable streaming notifications for 2k10 SP1+
                this.mnuToolsNotificationsItemSynchronizationViewer.Enabled = isCurrentService;


                this.mnuDisplayDelegates.Enabled = isCurrentService;
                this.UserAvailabilityMenuItem.Enabled = isCurrentService;
                this.UserOofSettingsMenuItem.Enabled = isCurrentService;
                this.ConvertIdMenuItem.Enabled = isCurrentService;
                this.InboxRulesMenuItem.Enabled = isCurrentService;
                this.UserConfigurationMenuItem.Enabled = isCurrentService;

                this.mnuResolveName.Enabled = isCurrentService;
                this.mnuResolveExProp.Enabled = isCurrentService;

                this.serverTimeZoneToolStripMenuItem.Enabled = isCurrentService;
                //this.TimeZonemenuitem.Enabled = isCurrentService;
                this.MeetingRoomsMenuItem.Enabled = isCurrentService;
                this.DistributionListMenuItem.Enabled = isCurrentService;
         
                this.checkForErrorsLoadingPropertiesOnFolderToolStripMenuItem.Enabled = isCurrentService;
                this.mnuGetConversationItems.Enabled = isCurrentService;
                this.eDiscoverySearchToolStripMenuItem.Enabled = isCurrentService;
                this.mailAppsToolStripMenuItem.Enabled = isCurrentService;
                this.mnuMailTips.Enabled = isCurrentService;
                this.developerToolsTestWindowToolStripMenuItem.Enabled = isCurrentService;

                 
            }
        }

        /// <summary>
        /// Gets the Timer used to defer TreeViewActions and initializes
        /// it if necessary.
        /// </summary>
        private Timer DeferredTreeViewActionTimer
        {
            get
            {
                if (this.deferredTreeViewActionTimer == null)
                {
                    this.deferredTreeViewActionTimer = new Timer();
                    this.DeferredTreeViewActionTimer.Tick += new EventHandler(this.DoDeferredTreeViewAction);
                    this.DeferredTreeViewActionTimer.Interval = DeferredTreeViewActionInterval;
                }

                return this.deferredTreeViewActionTimer;
            }
        }

        #region Private Static Methods

        private static TreeNode GetRootOfNode(TreeNode node)
        {
            if (node == null)
            {
                DebugLog.WriteVerbose("Leave: node is null");
                return null;
            }

            if (node.Parent != null)
            {
                return GetRootOfNode(node.Parent);
            }
            else
            {
                DebugLog.WriteVerbose("Leave: node.Parent is null");
                return node;
            }
        }

        private static Folder GetFolderFromNode(TreeNode node)
        {
            if ((node != null) && (node.Tag is RootFolderNodeTag))
            {
                return ((RootFolderNodeTag)node.Tag).FolderObject;
            }
            else if ((node != null) && (node.Tag is Folder))
            {
                return (Folder)node.Tag;
            }
            else
            {
                return null;
            }
        }

        private static EwsEditorAppSettings GetOptionsFromNode(TreeNode node)
        {

             
            //oSession.SessionService = service;
            //oSession.SessionEwsEditorAppSettings = oAppSettings;
            //serviceRootNode.Tag = oSession;

            if ((node != null) && (node.Tag is RootFolderNodeTag))
            {
                //EWSEditor.Common.EwsSession oSession = (EWSEditor.Common.EwsSession)node.Tag;
                return  ((RootFolderNodeTag)node.Tag).oAppSettings;
     
                //return null; //((RootFolderNodeTag)node.Tag).FolderObject;
 
            }
            else if ((node != null) && (node.Tag is Folder))
            {
                TreeNode oTreeNode;
                oTreeNode = node; 
                // Search parents (ancestors) to find the root folde.
                bool bFound = false;
                while (bFound == true)
                {
                    oTreeNode = oTreeNode.Parent;

                    if (oTreeNode.Tag is RootFolderNodeTag)
                    {
                        return  ((RootFolderNodeTag)oTreeNode.Tag).oAppSettings;

                        //this.CurrentAppSettings = GetOptionsFromNode(this.FolderTreeView.SelectedNode);
                        bFound = true;
                    }

                }

                //EWSEditor.Common.EwsSession oSession = (EWSEditor.Common.EwsSession)node.Tag;
               // return oSession.SessionEwsEditorAppSettings;
            }
            else
            {
                return null;
            }

            return null;
        }

        private static void GetFolderNodeText(Folder folder, FolderId origFolderId, out string nodeText, out string nodeToolTip)
        {
            // Initialize output
            nodeText = string.Empty;
            nodeToolTip = string.Empty;

            // HACK? If we see the FolderName is MsgFolderRoot we know for sure we are doing the right
            // thing to return 'MsgFolderRoot' as the folder name.  However, if we opened this folder
            // by FolderId and just have an empty DisplayName then we are really just assuming this the
            // root folder.
            if (folder.Id.FolderName.HasValue && folder.Id.FolderName.Value == WellKnownFolderName.MsgFolderRoot)
            {
                nodeText = System.Enum.GetName(typeof(WellKnownFolderName), WellKnownFolderName.MsgFolderRoot);
            }
            else if (folder.DisplayName == null || folder.DisplayName.Length == 0)
            {
                nodeText = System.Enum.GetName(typeof(WellKnownFolderName), WellKnownFolderName.MsgFolderRoot);
            }
            else
            {
                nodeText = folder.DisplayName;
            }

            // If origFolderId is NULL then we're done, there's no root folder
            // naming to do
            if (origFolderId == null)
            {
                return;
            }

            // Root Folder Naming - mstehle 7/28/2009
            // Depending on how the user created the FolderId, we want to indicate in
            // the tree view if we can that the folder may be in another mailbox.  If
            // the FolderId is specified by WellKnownName with a MailboxAddress it is
            // easy to call out the mailbox.  If the FolderId is specified by id then
            // we can't tell if this folder is in the act as account's mailbox or not.
            //
            // Folder by Name with Mailbox = "FolderName [MailboxAddress]"
            // Folder by Name without Mailbox = "FolderName"
            // Folder by Id = "FolderName*"
            if (origFolderId.Mailbox != null && origFolderId.FolderName.HasValue)
            {
                nodeText = string.Format(
                    System.Globalization.CultureInfo.CurrentCulture,
                    "{0} [{1}]",
                    nodeText,
                    origFolderId.Mailbox.Address);

                nodeToolTip = string.Format(
                    System.Globalization.CultureInfo.CurrentCulture,
                    "WellKnownFolder '{0}' in the '{1}' mailbox.",
                    System.Enum.GetName(typeof(WellKnownFolderName), origFolderId.FolderName.Value),
                    origFolderId.Mailbox.Address);
            }
            else if (origFolderId.Mailbox == null && origFolderId.FolderName.HasValue)
            {
                nodeToolTip = string.Format(
                    System.Globalization.CultureInfo.CurrentCulture,
                    "WellKnownFolder '{0}' in the '{1}' mailbox.",
                    System.Enum.GetName(typeof(WellKnownFolderName), origFolderId.FolderName.Value),
                    folder.Service.GetActAsAccountName());
            }
            else if (!origFolderId.FolderName.HasValue)
            {
                nodeText = string.Format(
                    System.Globalization.CultureInfo.CurrentCulture,
                    "{0}*",
                    nodeText);

                nodeToolTip = string.Format(
                    System.Globalization.CultureInfo.CurrentCulture,
                    "Folder '{0}' was added by Id and could reside in another mailbox.",
                    nodeText);
            }
        }

        #endregion

        private void InitializeFileMenu()
        {
            this.newExchangeServiceMenu.Name = "mnuNewBinding";
            this.newExchangeServiceMenu.Size = new System.Drawing.Size(237, 22);
            this.newExchangeServiceMenu.Text = "New Exchange Service...";
            this.newExchangeServiceMenu.Click += new System.EventHandler(this.NewExchangeServiceMenu_Click);

            this.openDefaultExchangeServiceMenu.Name = "mnuOpenDefaultBinding";
            this.openDefaultExchangeServiceMenu.Size = new System.Drawing.Size(237, 22);
            this.openDefaultExchangeServiceMenu.Text = "Open Default Exchange Service";
            this.openDefaultExchangeServiceMenu.Click += new System.EventHandler(this.OpenDefaultExchangeServiceMenu_Click);

            this.closeExchangeServiceMenu.Name = "mnuCloseBinding";
            this.closeExchangeServiceMenu.Size = new System.Drawing.Size(237, 22);
            this.closeExchangeServiceMenu.Text = "Close Exchange Service";
            this.closeExchangeServiceMenu.Click += new System.EventHandler(this.CloseExchangeServiceButton_Click);

            this.openProfileMenu.Name = "mnuOpenProfile";
            this.openProfileMenu.Size = new System.Drawing.Size(237, 22);
            this.openProfileMenu.Text = "Open Services Profile...";
            this.openProfileMenu.Click += new System.EventHandler(this.OpenProfileMenu_Click);

            this.saveProfileMenu.Name = "mnuSaveProfile";
            this.saveProfileMenu.Size = new System.Drawing.Size(237, 22);
            this.saveProfileMenu.Text = "Save Services Profile...";
            this.saveProfileMenu.Click += new System.EventHandler(this.SaveProfileMenu_Click);

            int exit = this.mnuFile.DropDownItems.IndexOfKey(this.mnuExit.Name);
            this.mnuFile.DropDownItems.Insert(exit, this.fileSplitMenu2);
            
            // Saving and loading profiles are no longer supported directly off the menu.
            // The work to get it to funciton properly will take too much work and complex.
            // Saving and loading my be added to the main New Service window in the future, however
            // that will also require a lot of work since many login and config settings are tied 
            // to the Options window.
            //this.mnuFile.DropDownItems.Insert(exit, this.saveProfileMenu);
            //this.mnuFile.DropDownItems.Insert(exit, this.fileSplitMenu1);  
            //this.mnuFile.DropDownItems.Insert(exit, this.openProfileMenu);
            this.mnuFile.DropDownItems.Insert(exit, this.closeExchangeServiceMenu);
            this.mnuFile.DropDownItems.Insert(exit, this.openDefaultExchangeServiceMenu);
            this.mnuFile.DropDownItems.Insert(exit, this.newExchangeServiceMenu);
        }

        private void FolderTreeForm_Load(object sender, EventArgs e)
        {
            this.CurrentService = null;
            this.CurrentAppSettings = null;

            this.Text = string.Empty;
            this.mnuRefresh.Click += new EventHandler(this.RefreshMenu_Click);

            this.DefaultDetailPropertySet.BasePropertySet = BasePropertySet.FirstClassProperties;
        }

        #region File Menu

        /// <summary>
        /// Add a new service binding to the tree view
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void NewExchangeServiceMenu_Click(object sender, EventArgs e)
        {
            try
            {

                // New service and appsettings.
                EWSEditor.Common.EwsEditorAppSettings oAppSettings = null; 
                ExchangeService service = null;
                DialogResult result = ServiceDialog.ShowDialog(ref service, ref oAppSettings);
                //CurrentAppSettings = oAppSettings;

                if (result != DialogResult.OK)
                {
                    DebugLog.WriteVerbose(string.Format("Leave: ServiceDialog returned {0}", result));
                    return;
                }

                if (service == null)
                {
                    DebugLog.WriteVerbose(string.Format("Leave: ExchangeService is null"));
                    return;
                }

                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                TreeNode serviceNode = this.AddServiceToTreeView(service, oAppSettings);
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        /// <summary>
        /// Close the selected ExchangeService and remove it from the tree view
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void CloseExchangeServiceButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                if (this.FolderTreeView.SelectedNode == null)
                {
                    DebugLog.WriteVerbose("Leave: this.FolderTreeView.SelectedNode is null.");
                    return;
                }

                TreeNode rootNode = GetRootOfNode(FolderTreeView.SelectedNode);
                if (rootNode == null)
                {
                    DebugLog.WriteVerbose("Leave: Root node is null.");
                    return;
                }

                // Select the next sibling ExchangeService if one is available
                if (rootNode.NextNode != null)
                {
                    this.FolderTreeView.SelectedNode = rootNode.NextNode;
                }
                else 
                {
                    this.CurrentService = null;
                    this.CurrentAppSettings = null;
                }

                rootNode.Remove();
                this.FolderPropertyDetailsGrid.Clear();
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        /// <summary>
        /// Load the ExchangeServices and root folders to a ServiceProfile persist
        /// it to a file.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void SaveProfileMenu_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog.ShowDialog();
            if (result != DialogResult.OK) 
            {
                DebugLog.WriteVerbose(string.Format("Leave: SaveFileDialog result was {0}.", result));
                return; 
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;

                ServiceProfile profile = new ServiceProfile();
                TreeNode serviceNode = FolderTreeView.TopNode;
                FolderId originalFolderId = null; 
                while (serviceNode != null) 
                {
                    // all at this level should be RootFolderNodeTag.
                    if (FolderTreeView.SelectedNode.Tag is RootFolderNodeTag)
                    {
                          
                        originalFolderId = ((RootFolderNodeTag)serviceNode.Tag).OriginalFolderId;

                        
                        int a = 0;
                    }

                    ExchangeService service = null;

                    EWSEditor.Common.EwsSession oSession = null;
                    oSession = (EWSEditor.Common.EwsSession)serviceNode.Tag;
                    service = oSession.SessionService;
                    //service = (ExchangeService)serviceNode.Tag;  // Todo: - extact both ExchangeService and EwsEditorAppSettings from tag
                    //ExchangeService service = (ExchangeService)serviceNode.Tag;  // Todo: - extact both ExchangeService and EwsEditorAppSettings from tag

                   // EWSEditor.Common.EwsSession oSession = null
                   // EWSEditor.Common.EwsSession oSession = (EWSEditor.Common.EwsSession)serviceNode.Tag;
                    //ExchangeService service = oSession.SessionService;
                   // EWSEditor.Common.EwsEditorAppSettings oAppSettings = oSession.SessionEwsEditorAppSettings;

 
                    //ExchangeService service = (ExchangeService)serviceNode.Tag;  // Todo: - extact both ExchangeService and EwsEditorAppSettings from tag
                    //EWSEditor.Common.EwsSession oSession = null;
                    EwsEditorAppSettings  oAppSettings  = GetOptionsFromNode(this.FolderTreeView.SelectedNode); 
 
                    //oSession = (EWSEditor.Common.EwsSession)serviceNode.Tag;
                    //ExchangeService service = oSession.SessionService;
                    //EWSEditor.Common.EwsEditorAppSettings oAppSettings = oSession.SessionEwsEditorAppSettings;

                    // Each Service in a ServiceProfile can have multiple root folders
                    List<FolderId> rootFolderIds = new List<FolderId>();
                    foreach (TreeNode rootFolderNode in serviceNode.Nodes)
                    {
                        if (rootFolderNode.Tag is RootFolderNodeTag)
                        {
                            rootFolderIds.Add(((RootFolderNodeTag)rootFolderNode.Tag).OriginalFolderId);
                        }
                    }

                    profile.AddServiceToProfile(service, rootFolderIds.ToArray(), oAppSettings);

                    // Go to the next ExchangeService node
                    serviceNode = serviceNode.NextNode;
                }

                profile.SaveProfile(saveFileDialog.FileName);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Open a profile to load the ExchangeServices and root folders 
        /// into the FolderTreeView
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void OpenProfileMenu_Click(object sender, EventArgs e)
        {
            try
            {
                // Warn the user if there is at least one ExchangeServices listed
                if (FolderTreeView.Nodes.Count > 1)
                {
                    DialogResult msgResult = MessageBox.Show(
                        "Opening a Service Profile will close all current ExchangeServices.  Do you want to continue?",
                        "EWS Editor - Open Profile",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1);

                    if (msgResult == DialogResult.Yes)
                    {
                        this.CurrentService = null;
                        this.CurrentAppSettings = null;
                        this.FolderTreeView.Nodes.Clear();
                        this.FolderPropertyDetailsGrid.Clear();
                    }
                    else
                    {
                        DebugLog.WriteVerbose("Leave: Don't open ServiceProfile and close existing ExchangeServices.");
                        return;
                    }
                }

                // Get the file path to open, if the user cancels bail out
                DialogResult fileResult = this.openFileDialog.ShowDialog();
                if (fileResult != DialogResult.OK) 
                {
                    DebugLog.WriteVerbose(string.Format("Leave: OpenFileDialog result was {0}.", fileResult));
                    return; 
                }

                if (!System.IO.File.Exists(this.openFileDialog.FileName))
                {
                    DebugLog.WriteVerbose(string.Format("Leave: OpenFileDialog file name, {0}, does not exist.", this.openFileDialog.FileName));
                    return;
                }

                this.Cursor = Cursors.WaitCursor;

                ServiceProfile profile = new ServiceProfile(this.openFileDialog.FileName, true, true);
                foreach (ServiceProfileItem item in profile.Items)
                {
                    TreeNode serviceNode = this.AddServiceToTreeView(item.Service, item.AppSettings, false);
                    foreach (FolderId folder in item.RootFolderIds)
                    {
                        try
                        {
                            this.AddRootFolderToTreeView(item.Service, item.AppSettings, folder, serviceNode);
                        }
                        catch (Exception ex)
                        {
                            ApplicationException appEx = new ApplicationException(
                                string.Format(
                                    System.Globalization.CultureInfo.CurrentCulture, 
                                    "Error adding a root folder to tree view. Service: {0} Folder: {1}", 
                                    serviceNode.Text, 
                                    folder.ToString()),
                                ex);
                            ErrorDialog.ShowError(appEx);

                            DebugLog.WriteVerbose("Handled exception when adding root folders to service.", ex);
                        }
                    }
                }

                // Select the first node
                this.FolderTreeView.SelectedNode = this.FolderTreeView.TopNode;
            }
            catch
            {
                // If we fail anywhere in here clear the tree view and bail out
                this.CurrentService = null;
                this.CurrentAppSettings = null;
                this.FolderTreeView.Nodes.Clear();
                throw;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Open an ExchangeService with no input
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void OpenDefaultExchangeServiceMenu_Click(object sender, EventArgs e)
        {
            try
            {
                this.CurrentAppSettings = new EWSEditor.Common.EwsEditorAppSettings();

                this.Cursor = Cursors.WaitCursor;
                EwsProxyFactory.InitializeWithDefaults();

                // New service and app settings.
                ExchangeService service = EwsProxyFactory.CreateExchangeService();
                
                EWSEditor.Common.EwsEditorAppSettings oAppSettings = new EwsEditorAppSettings();
                EwsProxyFactory.SetAppSettingsFromProxyFactory(ref oAppSettings);
                CurrentAppSettings = oAppSettings;


                TreeNode newNode = this.AddServiceToTreeView(service, CurrentAppSettings);
                this.FolderTreeView.SelectedNode = newNode;
                this.CurrentService = service;

                 
            }
            catch
            {
                // If we fail anywhere in here clear the tree view and bail out
                FolderTreeView.Nodes.Clear();
                throw;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        #endregion

        #region TreeView Events

        private void FolderTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
             
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // Set the server version and update the status bar...
                this.BindSelectedNode();


                // Specific folder type configurations
                Folder oFolder = (GetFolderFromNode(e.Node));
                bool bShowStrip = false;
                if (oFolder != null)
                {
                    // Calendar folders get the calendar view folder
                    if (oFolder.FolderClass == "IPF.Appointment")
                    {
                        mnuFolderCalendarView.Visible = true;
                        toolStripMenuItem14.Visible = true;
                        bShowStrip = true;
                    }
                    else
                    {
                        mnuFolderCalendarView.Visible = false;
                        toolStripMenuItem14.Visible = false;
                    }
                    

                    if (oFolder.FolderClass == "IPF.Note" ||
                        oFolder.FolderClass == "IPF.Appointment" ||
                        oFolder.FolderClass == "IPF.Contact" ||
                        oFolder.FolderClass == "IPF.Task")
                    {
                        mnuNewItem.Visible = true;
                        bShowStrip = true;
                    }
                    else
                    {
                        mnuNewItem.Visible = false;
                    }

                   
                    toolStripMenuItem14.Visible = bShowStrip;


                    oFolder = null;
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void FolderTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.FolderTreeView.SelectedNode != e.Node)
                {
                    this.FolderTreeView.SelectedNode = e.Node;
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// If the user double clicks a node display the 'regular' folder 
        /// contents, *NOT* to expand/collapse the TreeViewNode.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void FolderTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Folder folder = GetFolderFromNode(e.Node);
            if (folder != null)
            {
                DebugLog.WriteVerbose(string.Format("Double click on '{0}' node, cancelling deferred actions and showing contents", e.Node.Text));

                // Cancel any deferred actions
                this.deferredTreeViewAction = null;

                FolderContentForm.Show(
                    string.Format(DisplayStrings.TITLE_CONTENTS_FOLDER, folder.DisplayName),
                    folder,
                    ItemTraversal.Shallow,
                    this.CurrentService, 
                    this);
            }
        }

        /// <summary>
        /// Double clicking a folder tree node should display the contents table,
        /// *NOT* expand the node.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">TreeViewCancelEventArgs show us which node is attempting to expand.</param>
        private void FolderTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            // Only defer actions for nodes representing a folder.
            if (GetFolderFromNode(e.Node) != null)
            {
                this.DeferTreeViewAction(e);
                DebugLog.WriteVerbose(string.Format("TreeViewAction, {0}, {1} cancelled and deferred.", e.Action, e.Cancel ? "was" : "was not"));
            }


            //Folder oFolder = (GetFolderFromNode(e.Node));
            //if (oFolder != null)
            //{
            //    if (oFolder.FolderClass == "IPF.Appointment")
            //        mnuFolderCalendarView.Visible = true;
            //    else
            //        mnuFolderCalendarView.Visible = false;
            //    oFolder = null;
            //}
 
        }

        /// <summary>
        /// Double clicking a folder tree node should display the contents table,
        /// *NOT* collapse the node.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">TreeViewCancelEventArgs show us which node is attempting to expand.</param>
        private void FolderTreeView_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            // Only defer actions for nodes representing a folder.
            if (GetFolderFromNode(e.Node) != null)
            {
                this.DeferTreeViewAction(e);
                DebugLog.WriteVerbose(string.Format("TreeViewAction, {0}, {1} cancelled and deferred.", e.Action, e.Cancel ? "was" : "was not"));
            }
        }

        #endregion

        #region View Menu

        /// <summary>
        /// Rebind to the selected node in the TreeView
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void RefreshMenu_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                this.BindSelectedNode();
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        #endregion

        #region Right Click Context Menu


        private void AddExtendedPropertyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Folder folder = GetFolderFromNode(FolderTreeView.SelectedNode);

            ExtendedPropertyDefinition propDef = null;
            if (ExtendedPropertyDialog.ShowDialog(ref propDef) == DialogResult.OK)
            {
                folder.SetExtendedProperty(propDef, "Blah");
                folder.Update();
            }
        }

        private void EditExchangeServiceMenu_Click(object sender, EventArgs e)
        {
            ExchangeService service = this.CurrentService;

            EWSEditor.Common.EwsEditorAppSettings oCurrentAppSettings = this.CurrentAppSettings;
  
 
            if (ServiceDialog.ShowDialog(ref service, ref oCurrentAppSettings) == DialogResult.OK)
            {
                if (!service.IsEqual(this.CurrentService))
                {
                    // TODO: What to do if the ExchangeService was changed?
                }
            }
        }

        /// <summary>
        /// ExchangeService node context menu option to add a
        /// root folder to the view.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void AddRootFolderMenu_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                FolderId folderId = null;
                if (FolderIdDialog.ShowDialog(ref folderId) == DialogResult.OK)
                {
                    this.AddRootFolderToTreeView(folderId, FolderTreeView.SelectedNode);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Open the FolderContentsForm for the contents of the
        /// selected folder.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void OpenContentsMenu_Click(object sender, EventArgs e)
        {
            Folder folder = GetFolderFromNode(FolderTreeView.SelectedNode);
            if (folder != null)
            {
                FolderContentForm.Show(
                    string.Format(DisplayStrings.TITLE_CONTENTS_FOLDER, folder.DisplayName),
                    folder, 
                    ItemTraversal.Shallow, 
                    this.CurrentService, 
                    this);
            }
        }

        /// <summary>
        /// Open the FolderContentsForm for the associated contents 
        /// table for the selected folder.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void OpenAssocContentsMenu_Click(object sender, EventArgs e)
        {
            Folder folder = GetFolderFromNode(FolderTreeView.SelectedNode);
            if (folder != null)
            {
                FolderContentForm.Show(
                    string.Format(DisplayStrings.TITLE_CONTENTS_ASSOC, folder.DisplayName),
                    folder, 
                    ItemTraversal.Associated, 
                    this.CurrentService, 
                    this);
            }
        }

        /// <summary>
        /// Open the FolderContensForm for the soft deleted contents
        /// table for the selected folder
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void OpenSoftDelItemsMenu_Click(object sender, EventArgs e)
        {
            Folder folder = GetFolderFromNode(FolderTreeView.SelectedNode);
            if (folder != null)
            {
                FolderContentForm.Show(
                    string.Format(DisplayStrings.TITLE_CONTENTS_SOFT, folder.DisplayName),
                    folder, 
                    ItemTraversal.SoftDeleted, 
                    this.CurrentService, 
                    this);
            }
        }

        /// <summary>
        /// Open Calendar series view.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void MnuFolderCalendarView_Click(object sender, EventArgs e)
        {
            Folder folder = GetFolderFromNode(FolderTreeView.SelectedNode);
            if (folder != null)
            {
                if (folder.FolderClass == "IPF.Appointment")
                {
                    
                    CalendarMonthView oForm = new CalendarMonthView(this, this.CurrentService, folder.Id);
                    oForm.ShowDialog();
                    oForm = null;


                }

 
            }
 
 
        }

            /// <summary>
        /// Open Calendar series view.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void MnuNewItem_Click(object sender, EventArgs e)
        {
            Folder folder = GetFolderFromNode(FolderTreeView.SelectedNode);
            if (folder != null)
            {

                ItemHelper.NewItemByFolderClass(folder.FolderClass, this.CurrentService, folder.Id);

                //if (folder.FolderClass == "IPF.Appointment")
                //{
                //    CalendarForm oForm = new CalendarForm(this.CurrentService, folder.Id);
                //    oForm.ShowDialog();
                //    oForm = null;
                //}
                //if (folder.FolderClass == "IPF.Note")
                //{
                //    MessageForm oForm = new MessageForm(this.CurrentService, WellKnownFolderName.Drafts);
                //    oForm.ShowDialog();   
                //    oForm = null;
                //}
                //if (folder.FolderClass == "IPF.Contact")
                //{
                //    ContactsForm oForm = new ContactsForm(this.CurrentService, folder.Id);
                //    oForm.ShowDialog();
                //    oForm = null;
                //}

                //if (folder.FolderClass == "IPF.Task")
                //{
                //    TaskForm oForm = new TaskForm(this.CurrentService, folder.Id);
                //    oForm.ShowDialog();
                //    oForm = null;
                //}
       
 
            }
 
 
        }
     

        /// <summary>
        /// Open the PermissionsDialog for the selected folder.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void PermissionsMenu_Click(object sender, EventArgs e)
        {
            Folder folder = GetFolderFromNode(FolderTreeView.SelectedNode);
            if (folder != null)
            {
                PermissionsDialog.Show(this.CurrentService, folder.Id);
            }
        }

        private void DumpMimeContentsMenu_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Folder folder = GetFolderFromNode(FolderTreeView.SelectedNode);
                FormsUtil.DumpMimeContents(this.CurrentService, folder);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void DumpXmlContentsMenu_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Folder folder = GetFolderFromNode(FolderTreeView.SelectedNode);
                FormsUtil.DumpXmlContents(this.CurrentService, folder);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Create a new folder underneath the currently selected folder.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void CreateSubFolderMenu_Click(object sender, EventArgs e)
        {
            Folder parentFolder = GetFolderFromNode(this.FolderTreeView.SelectedNode);
            if (parentFolder != null)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    string sFolderName = "NewFolder";
                    string sFolderClass = "IPF.Note";
 

                    NewFolderForm oForm = new NewFolderForm();
                    oForm.ShowDialog();

                    if (oForm.ChoseOK == true)
                    {

                        sFolderName = oForm.ChosenFolderName;
                        sFolderClass = oForm.ChosenFolderClass;

                        Folder folder = new Folder(this.CurrentService);

                        folder.DisplayName = sFolderName;
                        if (sFolderClass.Trim().Length != 0)
                            folder.FolderClass = sFolderClass;

                        folder.Save(parentFolder.Id);
 
                        //// Load the current PropertySet for this new folder
                        //folder.Load(this.CurrentDetailPropertySet);  // not working if folder class is set
                        //TreeNode newNode = this.AddFolderToTreeView(folder, this.FolderTreeView.SelectedNode);
                        //this.FolderTreeView.SelectedNode = newNode;

                        Folder folder2 = Folder.Bind(this.CurrentService, folder.Id);
                        folder2.Load(this.CurrentDetailPropertySet);
                        TreeNode newNode = this.AddFolderToTreeView(folder2, this.FolderTreeView.SelectedNode);
                        this.FolderTreeView.SelectedNode = newNode;

                        // Refresh the tree view node
                        this.BindSelectedNode();

                        // Calendar items
                        // Contact items
                        // Mail and post items
                        // InfoPath  Form items
                        // Journal items
                        // Note items
                        // Task Items
                    }

                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }

                this.Cursor = Cursors.Default;
            }
        }

        private void DeleteFolderMenu_Click(object sender, EventArgs e)
        {
            Folder folder = GetFolderFromNode(FolderTreeView.SelectedNode);
            if (folder != null)
            {
                ToolStripItem item = sender as ToolStripItem;
                if (item != null)
                {
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;

                        // Delete the folder in the manner selected in the context menu
                        if (item.Name == this.DeleteHardMenu.Name)
                        {
                            folder.Delete(DeleteMode.HardDelete);
                        }
                        else if (item.Name == this.DeleteSoftMenu.Name)
                        {
                            folder.Delete(DeleteMode.SoftDelete);
                        }
                        else if (item.Name == this.DeleteMoveMenu.Name)
                        {
                            folder.Delete(DeleteMode.MoveToDeletedItems);
                        }

                        // Remove deleted node from tree view
                        TreeNode deletedNode = this.FolderTreeView.SelectedNode;
                        this.FolderTreeView.SelectedNode = deletedNode.Parent;
                        deletedNode.Remove();

                        this.BindSelectedNode();
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
                }
            }
        }

        /// <summary>
        /// Display a dialog for the user to identify a target folder
        /// for the move and peform the move, if successful remove 
        /// the tree view node.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void MoveFolderMenu_Click(object sender, EventArgs e)
        {
            Folder folder = GetFolderFromNode(this.FolderTreeView.SelectedNode);
            if (folder == null)
            {
                DebugLog.WriteVerbose("Could not get Folder from this.FolderTreeView.SelectedNode");
                return;
            }

            FolderId targetFolderId = null;
            if (FolderIdDialog.ShowDialog(ref targetFolderId) == DialogResult.OK)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    folder.Move(targetFolderId);

                    // Remove moved node from tree view
                    TreeNode movedNode = this.FolderTreeView.SelectedNode;
                    this.FolderTreeView.SelectedNode = movedNode.Parent;
                    movedNode.Remove();

                    this.BindSelectedNode();
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        /// <summary>
        /// Display a dialog for the user to identify a target folder
        /// to copy the selected folder to and perform the copy.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void CopyFolderMenu_Click(object sender, EventArgs e)
        {
            Folder folder = GetFolderFromNode(this.FolderTreeView.SelectedNode);
            if (folder == null)
            {
                DebugLog.WriteVerbose("Could not get Folder from this.FolderTreeView.SelectedNode");
                return;
            }

            FolderId targetFolderId = null;
            if (FolderIdDialog.ShowDialog(ref targetFolderId) == DialogResult.OK)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    folder.Copy(targetFolderId);

                    this.BindSelectedNode();
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        #endregion

        #region PropertyDetailsGrid Events

        private void FolderPropertyDetailsGrid_PropertyChanged(object sender, System.EventArgs e)
        {
            this.BindSelectedNode();
        }

        #endregion

        #region Private Methods

        private TreeNode AddServiceToTreeView(ExchangeService service, EWSEditor.Common.EwsEditorAppSettings oAppSettings)
        {
            return this.AddServiceToTreeView(service, oAppSettings, true);
        }

        private TreeNode AddServiceToTreeView(ExchangeService service, EWSEditor.Common.EwsEditorAppSettings oAppSettings, bool offerRootFolder)
        {
            TreeNode serviceRootNode = null;

            // Create a root node for the ExchangeService
            serviceRootNode = FolderTreeView.Nodes.Add(PropertyInterpretation.GetPropertyValue(service));
            //serviceRootNode.Tag = service; 

            //MessageBox.Show("todo");
            EWSEditor.Common.EwsSession oSession = new EwsSession();
            oSession.SessionService = service;
            oSession.SessionEwsEditorAppSettings = oAppSettings;
            serviceRootNode.Tag = oSession;
            

            // ExchangeService ToolTip - mstehle 7/29/2009
            // ToolTips are used to give the user a literal definition of
            // the ExchangeService's configuration as far as what CAS server
            // the service will talk to and what account will be impersonated.
            if (service.ImpersonatedUserId != null)
            {
                // With Impersonation = "ServiceAccount contacting HostName as ActAsAccount"
                serviceRootNode.ToolTipText = string.Format(
                    System.Globalization.CultureInfo.CurrentCulture, 
                    "Service account '{0}' is contacting '{1}' as account '{2}'.",
                    service.GetServiceAccountName(),
                    service.Url.Host,
                    service.ImpersonatedUserId.Id);
            }
            else
            {
                //// Without Impersonation = "ServiceAccount contacting HostName"
                serviceRootNode.ToolTipText = string.Format(
                    System.Globalization.CultureInfo.CurrentCulture,
                    "Service account '{0}' is contacting '{1}'.",
                    service.GetServiceAccountName(),
                    service.Url.Host);

                //serviceRootNode.ToolTipText = string.Format(
                //    System.Globalization.CultureInfo.CurrentCulture, 
                //    "Service account '{0}' is contacting '{1}'.",
                //    oAppSettings.MailboxBeingAccessed,
                //    service.Url.Host);

                 
            }

            // Set the node image, don't show a different image when selected
            serviceRootNode.ImageIndex = ExchangeServiceImageIndex;
            serviceRootNode.SelectedImageIndex = serviceRootNode.ImageIndex;

            serviceRootNode.ContextMenuStrip = this.mnuServiceContext;

            if (offerRootFolder)
            {
                DialogResult res = MessageBox.Show(
                    "Do you want to automatically add the mailbox root to the tree view?",
                    "EWSEditor",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    FolderId oNewFodler = new FolderId(WellKnownFolderName.Root);
                    this.AddRootFolderToTreeView(
                        service,
                        oAppSettings,
                        oNewFodler,
                        serviceRootNode);
                }
            }

            return serviceRootNode;
        }

        private TreeNode AddRootFolderToTreeView(FolderId folderId, TreeNode parent)
        {
            return this.AddRootFolderToTreeView(this.CurrentService, this.CurrentAppSettings, folderId, parent);
        }

        private TreeNode AddRootFolderToTreeView(ExchangeService service, EWSEditor.Common.EwsEditorAppSettings oAppSettings,  FolderId folderId, TreeNode parent)
        {
            Folder folder = Folder.Bind(
                service,
                folderId,
                this.folderNodePropertySet);

            string nodeText = string.Empty;
            string nodeToolTip = string.Empty;

            GetFolderNodeText(folder, folderId, out nodeText, out nodeToolTip);

            //nodeText  is the name of the root folder- such as the top of information store

            return this.AddFolderToTreeView(folderId, folder, parent, nodeText, nodeToolTip);
        }

        private TreeNode AddFolderToTreeView(Folder folder, TreeNode parent)
        {
            return this.AddFolderToTreeView(folder, parent, string.Empty, string.Empty);
        }

        private TreeNode AddFolderToTreeView(Folder folder, TreeNode parent, string nodeText, string nodeToolTip)
        {
            return this.AddFolderToTreeView(null, folder, parent, nodeText, nodeToolTip);
        }

        private TreeNode AddFolderToTreeView(FolderId origId, Folder folder, TreeNode parentNode, string nodeText, string nodeToolTip)
        {
            TreeNode newNode = null;

            // If there is no suggested node text either then give it a default name of the folder.
            if (nodeText != null && nodeText.Length > 0)
            {
                newNode = parentNode.Nodes.Add(nodeText);
            }
            else
            {
                nodeText = string.Empty;
                nodeToolTip = string.Empty;

                GetFolderNodeText(folder, origId, out nodeText, out nodeToolTip);
                newNode = parentNode.Nodes.Add(nodeText);
                newNode.ToolTipText = nodeToolTip;
            }

            newNode.ContextMenuStrip = this.cmsFolderMenu;
            
            // RootFolderNodeTag - 10/26/2009 mstehle
            // Only add the RootFolderNodeTag to root folders underneath an
            // ExchangeService node.

            //EWSEditor.Common.EwsSession oSession = new EwsSession();
            //oSession.SessionService = service;
            //oSession.SessionEwsEditorAppSettings = oAppSettings;
            //serviceRootNode.Tag = oSession;

            //             if (parentNode.Tag is ExchangeService)
            if (parentNode.Tag is EwsSession)
            {
                EWSEditor.Common.EwsSession oSession = (EWSEditor.Common.EwsSession)parentNode.Tag;

                RootFolderNodeTag tag = new RootFolderNodeTag();
                tag.FolderObject = folder;
                if (origId != null)
                {
                    tag.OriginalFolderId = origId;
                    tag.oAppSettings = oSession.SessionEwsEditorAppSettings;
                }
                else
                {
                    tag.OriginalFolderId = folder.Id;
                    tag.oAppSettings = oSession.SessionEwsEditorAppSettings;
                }

                newNode.Tag = tag;
            }
            else
            {
                newNode.Tag = folder;
            }

            // Only set a tool tip if we explicitly define one
            if (nodeToolTip != null && nodeToolTip.Length > 0)
            {
                newNode.ToolTipText = nodeToolTip;
            }

            //// TODO: At some point it might be nice to give folders specific icons
            //// based on folder class.
            ////if (folder.FolderClass == "IPF.Appointment")
            ////{
            ////    newNode.ImageIndex = IMAGE_CALENDAR;
            ////}
            ////else if (folder.FolderClass == "IPF.Contact")
            ////{
            ////    newNode.ImageIndex = IMAGE_CONTACT;
            ////}
            ////else if (folder.FolderClass == "IPF.Task")
            ////{
            ////    newNode.ImageIndex = IMAGE_TASK;
            ////}

            // The node image shouldn't change when selected
            newNode.SelectedImageIndex = newNode.ImageIndex;

            if (folder.ChildFolderCount > 0)
            {
                newNode.Nodes.Add("[PLACEHOLDER]");
            }

            // If the new node is a root folder node and the parent
            // node is not yet expanded, expand it so the user can
            // see it.
            if (newNode.Tag is RootFolderNodeTag && 
                !newNode.Parent.IsExpanded)
            {
                newNode.Parent.Expand();
            }

            return newNode;
        }

        /// <summary>
        /// If a folder in the tree view is selected, display
        /// its properties in the property grid.
        /// </summary>
        private void BindSelectedNode()
        {
            // If no node is selected, bail out
            if (this.FolderTreeView.SelectedNode == null) 
            {
                DebugLog.WriteVerbose("Leave: this.FolderTreeView.SelectedNode is null");
                return; 
            }

            if (GetFolderFromNode(this.FolderTreeView.SelectedNode) != null)
            {
                Folder folder = GetFolderFromNode(this.FolderTreeView.SelectedNode);

                // If this folder is a root folder node then we can get an
                // original FolderId which we'll pass to GetFolderNodeText()
                FolderId originalFolderId = null;
                if (FolderTreeView.SelectedNode.Tag is RootFolderNodeTag)
                {
                    originalFolderId = ((RootFolderNodeTag)FolderTreeView.SelectedNode.Tag).OriginalFolderId;

                    this.CurrentAppSettings = GetOptionsFromNode(this.FolderTreeView.SelectedNode); 
                }
                else
                {
                    this.CurrentAppSettings = GetOptionsFromNode(this.FolderTreeView.SelectedNode); 
                }

                 

                // Ensure that the form is setup properly
                this.mnuViewConfigPropertySet.Enabled = true;
                this.CurrentService = folder.Service;
                //TreeNode x = FolderTreeView.SelectedNode;
 
                //this.CurrentAppSettings = folder.  // TODO Load settings
 
                // Reload folder with the current property set
                //EWSEditor.Forms.FormsUtil.PerformRetryableLoad(folder as ServiceObject, this.CurrentDetailPropertySet);

                // The wrong propertyset was being used - changed from item to folder.
                EWSEditor.Forms.FormsUtil.PerformRetryableLoad(folder as ServiceObject, this.folderNodePropertySet);
            
                // If this folder didn't have subfolders before, put a placeholder folder there to be
                // expanded later
                if (this.FolderTreeView.SelectedNode.Nodes.Count == 0 && folder.ChildFolderCount > 0)
                {
                    this.FolderTreeView.SelectedNode.Nodes.Add("[PLACEHOLDER]");
                    this.FolderTreeView.SelectedNode.Collapse();
                }

                // Refresh the folder name in the tree view
                string nodeText = string.Empty;
                string nodeToolTip = string.Empty;

                GetFolderNodeText(
                    folder,
                    originalFolderId, 
                    out nodeText, 
                    out nodeToolTip);

                this.FolderTreeView.SelectedNode.Text = nodeText;
                this.FolderTreeView.SelectedNode.ToolTipText = nodeToolTip;

                // Reload the property grid
                this.FolderPropertyDetailsGrid.LoadObject(folder);
            }
            else if (FolderTreeView.SelectedNode.Tag is EWSEditor.Common.EwsSession)
            {
                EwsSession oSession = (EwsSession) FolderTreeView.SelectedNode.Tag;    
                this.CurrentAppSettings = oSession.SessionEwsEditorAppSettings;
                this.CurrentService = oSession.SessionService;;
                this.FolderPropertyDetailsGrid.LoadObject(this.CurrentService);
            }

            //else if (FolderTreeView.SelectedNode.Tag is ExchangeService)
            //{
            //    this.CurrentService = FolderTreeView.SelectedNode.Tag as ExchangeService;
            //    this.FolderPropertyDetailsGrid.LoadObject(this.CurrentService);
            //}
        }

        #endregion
        
        /// <summary>
        /// Given the event timing we can't tell the difference between a 
        /// TreeViewAction.Collapse or TreeViewAction.Expand coming from a double 
        /// click on a node and an expansion change coming from clicking the '+' 
        /// without deferring the Expand and Collapse actions until after
        /// FolderTreeView_NodeMouseDoubleClick has a chance to fire.
        /// </summary>
        /// <param name="e">TreeViewCancelEventArgs used to cancel and defer the TreeViewAction</param>
        private void DeferTreeViewAction(TreeViewCancelEventArgs e)
        {
            if (this.deferredTreeViewAction != null)
            {
                DebugLog.WriteVerbose(string.Format("Leave: {0}, is already deferred will skip deferring passed action, {1}", this.deferredTreeViewAction, e.Action));
                return;
            }

            // If the action is already pending then we don't need to do anything
            if (this.deferredTreeViewAction != e.Action)
            {
                switch (e.Action)
                {
                    case TreeViewAction.Collapse:
                    case TreeViewAction.Expand:
                        // Cancel the action
                        e.Cancel = true;
                        this.deferredTreeViewAction = e.Action;
                        this.DeferredTreeViewActionTimer.Start();
                        DebugLog.WriteVerbose(string.Format("Deferred {0} on node, '{1}'", this.deferredTreeViewAction, e.Node.Text));
                        break;
                    default:
                        DebugLog.WriteVerbose("Leave: TreeViewAction not deferrable");
                        break;
                }
            }
        }

        private void DoDeferredTreeViewAction(object sender, EventArgs e)
        {
            DebugLog.WriteVerbose(string.Format("Enter: this.deferredTreeViewAction = {0}", this.deferredTreeViewAction));

            try
            {
                // Only expand/collapse the TreeViewNode if the user *didn't* 
                // double click the node
                if (!this.deferredTreeViewAction.HasValue)
                {
                    DebugLog.WriteVerbose("Leave: There is no deferred action");
                    return;
                }

                this.Cursor = Cursors.WaitCursor;

                switch (this.deferredTreeViewAction.Value)
                {
                    case TreeViewAction.Collapse:
                        this.FolderTreeView.SelectedNode.Collapse();
                        break;
                    case TreeViewAction.Expand:
                        this.ExpandSelectedTreeNode();
                        break;
                    default:
                        // We shouldn't get here, but don't fail if we do
                        DebugLog.WriteVerbose(string.Format("Unexpected this.deferredTreeViewAction.Value, {0}", this.deferredTreeViewAction.Value));
                        break;
                }
            }
            finally
            {
                // Reset deferred actions
                this.deferredTreeViewAction = null;
                this.DeferredTreeViewActionTimer.Stop();
                
                this.Cursor = Cursors.Default;
            }

            DebugLog.WriteVerbose("Leave");
        }

        private void ExpandSelectedTreeNode()
        {
            TreeNode node = this.FolderTreeView.SelectedNode;
            if (node == null)
            {
                DebugLog.WriteVerbose("Leave: this.FolderTreeView.SelectedNode is null");
                return;
            }
            
            Folder parentFolder = GetFolderFromNode(node);
            if (parentFolder == null)
            {
                DebugLog.WriteVerbose(string.Format("Leave: No folder for this.FolderTreeView.SelectedNode, '{0}'", this.FolderTreeView.SelectedNode.Text));
                return;
            }

            node.Nodes.Clear();

            // If the parent folder has no childern bail out
            if (parentFolder.ChildFolderCount == 0)
            {
                DebugLog.WriteVerbose(String.Format("Leave: Folder for this.FolderTreeView.SelectedNode, '{0}', has no children", this.FolderTreeView.SelectedNode.Text));
                return; 
            }

            // Find sub-folders of the parent folder
            int viewSize = GlobalSettings.FindFolderViewSize;
            bool finished = false;
            List<Folder> subFolders = new List<Folder>();
            while (!finished)
            {
                FolderView view = new FolderView(viewSize, subFolders.Count);
                FindFoldersResults results = parentFolder.FindFolders(view);
                subFolders.AddRange(results.Folders);
                finished = !results.MoreAvailable;
            }

            // Add the folders to the tree view
            foreach (Folder folder in subFolders)
            {
                this.AddFolderToTreeView(folder, node);
            }

            // Expand the selected node to show the children
            if (!node.IsExpanded)
            {
                node.Expand();
            }
        }

        /// <summary>
        /// This simple structure is used to store the Folder object itself 
        /// as well as the FolderId used to bind to it originally.
        /// </summary>
        private struct RootFolderNodeTag
        {
            internal Folder FolderObject;
            internal FolderId OriginalFolderId;  
            internal EWSEditor.Common.EwsEditorAppSettings oAppSettings;   
        }

        private void mnuOpenStreamingNotifications_Click(object sender, EventArgs e)
        {
            Folder folder = GetFolderFromNode(FolderTreeView.SelectedNode);
            if (folder != null)
            {
                StreamingNotificationForm.Show(
                    string.Format(DisplayStrings.TITLE_CONTENTS_FOLDER, folder.DisplayName),
                    folder.Id);
            }
        }

        private void FolderPropertyDetailsGrid_Load(object sender, EventArgs e)
        {
             
        }

        private void propertyListItemBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void SearchItemsMenuItem_Click(object sender, EventArgs e)
        {
            Folder oFolder = (GetFolderFromNode(FolderTreeView.SelectedNode));
            SearchForm oForm = new SearchForm(this.CurrentService, oFolder.Id);
            oForm.ShowDialog();

        }

        private void mnuDeleteFolder_Click(object sender, EventArgs e)
        {

        }

        private void EmptyFolderHardDeletMenu_Click(object sender, EventArgs e)
        {
            Folder folder = GetFolderFromNode(FolderTreeView.SelectedNode);
            if (folder != null)
            {
                ToolStripItem item = sender as ToolStripItem;
                if (item != null)
                {
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        folder.Empty(DeleteMode.HardDelete, false);

                        //// Delete the folder in the manner selected in the context menu
                        //if (item.Name == this.DeleteHardMenu.Name)
                        //{
                        //    folder.Delete(DeleteMode.HardDelete);
                        //}
                        //else if (item.Name == this.DeleteSoftMenu.Name)
                        //{
                        //    folder.Delete(DeleteMode.SoftDelete);
                        //}
                        //else if (item.Name == this.DeleteMoveMenu.Name)
                        //{
                        //    folder.Delete(DeleteMode.MoveToDeletedItems);
                        //}

                        //// Remove deleted node from tree view
                        //TreeNode deletedNode = this.FolderTreeView.SelectedNode;
                        //this.FolderTreeView.SelectedNode = deletedNode.Parent;
                        //deletedNode.Remove();

                        this.BindSelectedNode();
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
                }
            }
        }

        private void mnuEmptyTheFolder_Click(object sender, EventArgs e)
        {

             Folder oFolder = GetFolderFromNode(FolderTreeView.SelectedNode);
             if (oFolder != null)
             {

                 EmptyFolder oForm = new EmptyFolder(oFolder);
                 oForm.ShowDialog();
             }
        }

        private void developerFolderTestFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Folder oFolder = (GetFolderFromNode(FolderTreeView.SelectedNode));
            DeveloperFolderTestform oForm = new DeveloperFolderTestform(this.CurrentService, oFolder.Id);
            oForm.Show();
        }

        private void SearchFoldersMenuItem_Click(object sender, EventArgs e)
        {
            Folder oFolder = (GetFolderFromNode(FolderTreeView.SelectedNode));
            SearchFolders oForm = new SearchFolders(this.CurrentService, oFolder.Id, this.CurrentDetailPropertySet);
            oForm.ShowDialog();
        }
    }
}
