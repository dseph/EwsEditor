namespace EWSEditor.Forms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.DirectoryServices.AccountManagement;
   
    using System.Collections.ObjectModel;

    using EWSEditor.Common;
    using EWSEditor.Common.Extensions;
    using EWSEditor.Resources;
    using EWSEditor.Forms.Dialogs;
    using EWSEditor.Forms.ToolsForms;
    using System.Net;

    using Microsoft.Exchange.WebServices.Data;
    using System.DirectoryServices;

    using Microsoft.Win32;
    using System.Globalization;
    

    public partial class BrowserForm : CountedForm
    {
        private static ExtendedPropertyDefinition Prop_PR_FOLDER_PATH = new ExtendedPropertyDefinition(0x66B5, MapiPropertyType.String);   // Folder Path - PR_Folder_Path
        private static ExtendedPropertyDefinition PidLidCleanGlobalObjectId = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Meeting, 0x0023, MapiPropertyType.Binary);
        private static ExtendedPropertyDefinition PidLidGlobalObjectId = new ExtendedPropertyDefinition(DefaultExtendedPropertySet.Meeting, 0x0003, MapiPropertyType.Binary);
        private static ExtendedPropertyDefinition Prop_PR_STORE_ENTRYID = new ExtendedPropertyDefinition(0x0FFB, MapiPropertyType.Binary);  // PidTagStoreEntryId
        private static ExtendedPropertyDefinition Prop_PR_IS_HIDDEN = new ExtendedPropertyDefinition(0x10f4, MapiPropertyType.Boolean);
        private static ExtendedPropertyDefinition Prop_PR_POLICY_TAG = new ExtendedPropertyDefinition(0x301B, MapiPropertyType.Binary);  // PR_POLICY_TAG 0x3019   Data type: PtypBinary, 0x0102
        private static ExtendedPropertyDefinition Prop_PR_ARCHIVE_TAG = new ExtendedPropertyDefinition(0x3018, MapiPropertyType.Binary);
        private static ExtendedPropertyDefinition PidLidClientIntent = new ExtendedPropertyDefinition(new Guid("11000E07-B51B-40D6-AF21-CAA85EDAB1D0"), 0x0015, MapiPropertyType.Integer); // dispidClientIntent

        private static ExtendedPropertyDefinition ClientInfoString = new ExtendedPropertyDefinition(new Guid("11000e07-b51b-40d6-af21-caa85edab1d0"), 0x000B, MapiPropertyType.String); //  


        private PropertySet defaultDetailPropertySet = new PropertySet(BasePropertySet.IdOnly);
        //private PropertySet defaultDetailPropertySet = new PropertySet(BasePropertySet.FirstClassProperties,
        //    Prop_PR_STORE_ENTRYID,
        //    Prop_PR_IS_HIDDEN,
        //    Prop_PR_FOLDER_PATH,
        //    PidLidCleanGlobalObjectId,
        //    PidLidGlobalObjectId);
 

        private PropertySet currentDetailPropertySet = null;
         

        public BrowserForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the default PropertySet used to get
        /// details of a content row if no other PropertySet
        /// is specified.
        /// </summary>
        public PropertySet DefaultDetailPropertySet
        {
            get
            {
                return this.defaultDetailPropertySet;
            }

            set
            {
                this.defaultDetailPropertySet = value;
            }
        }

        /// <summary>
        /// Gets or sets the PropertySet to used to get
        /// details of a content row.
        /// </summary>
        public PropertySet CurrentDetailPropertySet
        {
            get
            {
                if (this.currentDetailPropertySet == null)
                {
                    this.ResetCurrentPropertySet();
                }

                return this.currentDetailPropertySet;
            }

            set
            {
                this.currentDetailPropertySet = value;
            }
        }

        /// <summary>
        /// Gets or sets the ExchangeService currently selected.
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
                //this.SetServiceLabel(value);

            }
        }


        public void SetServiceLabel(ExchangeService service)
        {
            if (service != null)
            {
                if (service.Url != null)
                {
                    this.lblExchangeService.Text = string.Format(
                        System.Globalization.CultureInfo.CurrentCulture,
                        "Current service, '{0}', contacting {1}.",
                        PropertyInformation.PropertyInterpretation.GetPropertyValue(service),
                        service.Url.Host);
                }
                else
                {
                    this.lblExchangeService.Text = string.Format(
                        System.Globalization.CultureInfo.CurrentCulture,
                        "Current service, '{0}'.",
                        PropertyInformation.PropertyInterpretation.GetPropertyValue(service));
                }
            }
            else
            {
                this.lblExchangeService.Text = string.Empty;
            }
        }

        public void SetServiceLabel(EwsEditorAppSettings oAppSettings)
        {

            string sInfo = string.Empty;

            if (oAppSettings != null)
            {

                
                if (oAppSettings != null)
                {
                    if (oAppSettings.UserImpersonationSelected == true)
                    {
                        // With Impersonation = "ServiceAccount contacting HostName as ActAsAccount"
                        sInfo = string.Format(
                            System.Globalization.CultureInfo.CurrentCulture,
                            "Service account '{0}' is contacting mailbox '{1}' via {2} as account '{3}'.",
                            oAppSettings.AccountAccessingMailbox,
                            oAppSettings.MailboxBeingAccessed,
                            oAppSettings.UrlHost,
                            oAppSettings.ImpersonatedId);
                    }
                    else
                    {
                        sInfo = string.Format(
                            System.Globalization.CultureInfo.CurrentCulture,
                            "Service account '{0}' is contacting mailbox '{1}' via {2}.",
                            oAppSettings.AccountAccessingMailbox,
                            oAppSettings.MailboxBeingAccessed,
                            oAppSettings.UrlHost);
                    }

                    this.lblExchangeService.Text = sInfo;
                }
            }

            this.lblExchangeService.Text = sInfo;
              
        }

        /// <summary>
        /// Resets the CurrentDetailPropertySet back to the
        /// DefaultDetailPropertySet.
        /// </summary>
        public void ResetCurrentPropertySet()
        {
            this.currentDetailPropertySet = new PropertySet();
            this.currentDetailPropertySet.BasePropertySet = this.DefaultDetailPropertySet.BasePropertySet;
            this.currentDetailPropertySet.FilterHtmlContent = this.DefaultDetailPropertySet.FilterHtmlContent;
            this.currentDetailPropertySet.RequestedBodyType = this.DefaultDetailPropertySet.RequestedBodyType;
            if (this.DefaultDetailPropertySet.Count > 0)
            {
                this.currentDetailPropertySet.AddRange(this.DefaultDetailPropertySet);
            }
        }

        #region File Menu Events

        /// <summary>
        /// Close this form
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void MnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region View Menu Events

        /// <summary>
        /// Display PropertySetDialog to configure the PropertySet used
        /// to populate the details grid
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void MnuPropertySet_Click(object sender, EventArgs e)
        {
            try
            {
                // Display PropertiesDialog
                PropertySet propSet = this.CurrentDetailPropertySet;
                if (PropertySetDialog.Show(ref propSet) == DialogResult.OK)
                {
                    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                    this.CurrentDetailPropertySet = propSet;

                    // If there is a handler for mnuRefresh, now would be a good time to
                    // call it.
                    this.mnuRefresh.PerformClick();
                }
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        /// <summary>
        /// Reset the details PropertySet back to its original value.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void MnuRestorePropertySet_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                this.ResetCurrentPropertySet();

                // If there is a handler for mnuRefresh, now would be a good time to
                // call it.
                this.mnuRefresh.PerformClick();
            }
            finally
            {
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        #endregion

        #region Tools Menu Events

        /// <summary>
        /// Display the DelegateDialog for the current mailbox.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void MnuDelegateInformation_Click(object sender, EventArgs e)
        {
            NameResolutionCollection names = null;

            // Attempt to resolve the Act As account name.  If there is only one
            // hit from ResolveNames then assume it is the right one.
            if (this.CurrentAppSettings != null)
            {
                if (this.CurrentAppSettings.AuthenticationMethod == RequestedAuthType.oAuth)
                {
                    names = this.CurrentService.ResolveName(this.CurrentAppSettings.MailboxBeingAccessed);
                }
                else
                {
                    names = this.CurrentService.ResolveName(this.CurrentService.GetActAsAccountName());

                }
            }
            else
            {
                names = this.CurrentService.ResolveName(this.CurrentService.GetActAsAccountName());
                //this.CurrentAppSettings.MailboxBeingAccessed;
            }
             
            if (names.Count == 1)
            {
                DialogResult res = DelegateDialog.ShowDialog(
                    this.CurrentService,
                    new Mailbox(names[0].Mailbox.Address));
            }
            else
            {
                DialogResult res = DelegateDialog.ShowDialog(this.CurrentService);
            }
        }

        /// <summary>
        /// Display the ResolvNameDialog
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void MnuResolveName_Click(object sender, EventArgs e)
        {
            ResolveNameForm.Show(CurrentService, this);
        }

        /// <summary>
        /// Display the PullNotificationForm
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void MnuNotification_Click(object sender, EventArgs e)
        {
            PullNotificationForm.Show(this.CurrentService);
        }

        /// <summary>
        /// Display the PullNotificationForm
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void MnuStreamingNotification_Click(object sender, EventArgs e)
        {
            StreamingNotificationForm.Show();
        }

        /// <summary>
        /// Display the SyncFolderItemsForm
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void MnuSynchronization_Click(object sender, EventArgs e)
        {
            SyncFolderItemsForm.Show(this.CurrentService);
        }

        /// <summary>
        /// Display the ExtendedPropertyDialog
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void MnuResolveExProp_Click(object sender, EventArgs e)
        {
            ExtendedPropertyDefinition epd = null;
            ExtendedPropertyDialog.ShowDialog(ref epd);
        }

        /// <summary>
        /// Display the OofForm with for the current mailbox if
        /// available.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void MnuOOFSettings_Click(object sender, EventArgs e)
        {
            //NameResolutionCollection names = null;
            //try
            //{
            //    this.Cursor = Cursors.WaitCursor;

            //    // If there is no CurrentService then we can't do anything
            //    if (this.CurrentService == null)
            //    {
            //        return;
            //    }
            //    if (this.CurrentAppSettings != null)
            //    {
            //        if (this.CurrentAppSettings.AuthenticationMethod == RequestedAuthType.oAuth)
            //        {
            //            names = this.CurrentService.ResolveName(this.CurrentAppSettings.MailboxBeingAccessed);
            //        }
            //        else
            //        {
            //            // Attempt to resolve the Act As account name.  If there is only one
            //            // hit from ResolveNames then assume it is the right one.
            //            names = this.CurrentService.ResolveName(this.CurrentService.GetActAsAccountName());
            //        }
            //    }
            //    else
            //    {
            //        names = this.CurrentService.ResolveName(this.CurrentService.GetActAsAccountName());
            //    }
            //}
            //finally
            //{
            //    this.Cursor = Cursors.Default;
            //}

            //if (names != null && names.Count == 1)
            //{
            //    OofForm.ShowDialog(
            //        this.CurrentService,
            //        new Mailbox(names[0].Mailbox.Address));
            //}
            //else
            //{
            //    OofForm.ShowDialog(this.CurrentService);
            //}

 

        }

        /// <summary>
        /// Display the AvailabilityForm
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void MnuAvailability_Click(object sender, EventArgs e)
        {
           // AvailabilityForm.Show(this.CurrentService);
        }

        /// <summary>
        /// Display the AutodiscoverViewerForm
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void MnuAutoDiscoverView_Click(object sender, EventArgs e)
        {
            AutodiscoverViewerForm.Show();
        }

        /// <summary>
        /// Display the RawHttpCall
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void mnuEwsPost_Click(object sender, EventArgs e)
        {
            PostForm oPostForm = new PostForm();
            oPostForm.Show();
 
        }

         
        private void OptionsMenuItem_Click(object sender, EventArgs e)
        {
            OptionsDialog.ShowDialog();
        }

        private void ConvertIdMenu_Click(object sender, EventArgs e)
        {
            ConvertIdForm.Show(this, this.CurrentService);
        }

        private void DebugLogVeiwerMenuItem_Click(object sender, EventArgs e)
        {
            DebugLogViewerForm.Show();
        }

        #endregion

        #region Other Menu Events

        /// <summary>
        /// Allow the user to input an ItemId and display its properites
        /// in FolderContentsForm.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void MnuOpenItemById_Click(object sender, EventArgs e)
        {
            ItemId itemId = null;
            if (ItemIdDialog.ShowDialog(out itemId, this.CurrentService) == DialogResult.OK)
            {
                List<ItemId> item = new List<ItemId>();
                item.Add(itemId);

                ItemsContentForm.Show(
                    "Displaying item by ItemId",
                    item,
                    this.CurrentService,
                    this);
            }
        }

        /// <summary>
        /// Allow the user to input an FolderId and display folder items
        /// in FolderContentsForm.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void MnuOpenFolderById_Click(object sender, EventArgs e)
        {
            FolderIdDialog oForm = new FolderIdDialog(this.CurrentService);
            oForm.ShowDialog();
            if (oForm.ChoseOK == true && oForm.ChosenFolderId != null)
            {
                //oForm.ChosenFolderId 
                this.CurrentService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID

                Folder folder = Folder.Bind(
                    this.CurrentService,
                    oForm.ChosenFolderId,
                    this.CurrentDetailPropertySet);

                FolderContentForm.Show(
                    string.Format(DisplayStrings.TITLE_CONTENTS_FOLDER, folder.DisplayName),
                    folder,
                    ItemTraversal.Shallow,
                    this.CurrentService,
                    this);
            }

            //FolderId folderId = null;
            //if (FolderIdDialog.ShowDialog(ref folderId) == DialogResult.OK && folderId != null)
            //{
            //    Folder folder = Folder.Bind(
            //        this.CurrentService,
            //        folderId,
            //        this.CurrentDetailPropertySet);
                 
            //    FolderContentForm.Show(
            //        string.Format(DisplayStrings.TITLE_CONTENTS_FOLDER, folder.DisplayName),
            //        folder,
            //        ItemTraversal.Shallow,
            //        this.CurrentService,
            //        this);
            //}
        }

        /// <summary>
        /// Display CalendarViewDialog to gather search criteria then
        /// open the ContentsForm and display search results.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void MnuFindAppointments_Click(object sender, EventArgs e)
        {
            List<ItemId> appts = null;
            FindAppointmentsDialog.ShowDialog(this.CurrentService, ref appts);

            if (appts != null)
            {
                ItemsContentForm.Show("CalendarView results.", appts, this.CurrentService, this);
            }
        }

        #endregion

        #region Help Menu

        private void MnuAbout_Click(object sender, EventArgs e)
        {
            AboutDialog.ShowDialog();
        }

        #endregion

        private void TimeZonemenuitem_Click(object sender, EventArgs e)
        {
            //this.Cursor = Cursors.WaitCursor;

            // If there is no CurrentService then we can't do anything
            //if (this.CurrentService != null)
            //{
                TimeZonesForm oTimeZonesForm = new TimeZonesForm();
                oTimeZonesForm.ShowDialog();
            //}

            //this.Cursor = Cursors.Default;

        }

        private void BrowserForm_Load(object sender, EventArgs e)
        {

        }

        private void BrowserForm_Load_1(object sender, EventArgs e)
        {
             
        }

        private void MeetingRoomsMenuItem_Click(object sender, EventArgs e)
        {
            if (this.CurrentService != null)
            {
                RoomsForm oRoomsForm = new RoomsForm(this.CurrentService);
                oRoomsForm.ShowDialog();
            }
        }

        private void DistributionListMenuItem_Click(object sender, EventArgs e)
        {
            if (this.CurrentService != null)
            {
                DistributionListExpansionForm oDistributionListForm = new DistributionListExpansionForm(this.CurrentService);
                oDistributionListForm.ShowDialog();
            }
        }
        
        private void InboxRulesMenuItem_Click(object sender, EventArgs e)
        {
            if (this.CurrentService != null)
            {
                InboxRulesForm oInboxRulesForm = new InboxRulesForm(this.CurrentService);
                oInboxRulesForm.ShowDialog();
            }
        }

   

        private void mnuFile_Click(object sender, EventArgs e)
        {

        }

        private void checkForErrorsLoadingPropertiesOnFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.CurrentService != null)
            {
                //CheckFolderItemsForPropertyLoadingIssues oCheckFolderItemsForPropertyLoadingIssues = new CheckFolderItemsForPropertyLoadingIssues();
                //oCheckFolderItemsForPropertyLoadingIssues.Show();
                CheckFolderItemsForPropertyLoadingIssues.Show(this.CurrentService);
            }
        }

        private void mnuGetConversationItems_Click(object sender, EventArgs e)
        {
            List<ItemId> oConversationItems = new List<ItemId>();

            PropertySet oPropertySet = null;
            ConversationId oConversationId = null;
            FolderId oFolderId = null; 
 
            ConversationIdDialog oConversationIdDialog = new ConversationIdDialog();
            oConversationIdDialog.ShowDialog();

            this.Cursor = Cursors.WaitCursor; 
             
            if (oConversationIdDialog.ChoseOK == true)
            {
                 
                oPropertySet = oConversationIdDialog.CurrentPropertySet;
                oConversationId = oConversationIdDialog.CurrentConversationId;
                oFolderId = oConversationIdDialog.CurrentFolderId;

                List<FolderId> folder = new List<FolderId>();
                folder.Add(oFolderId);

                // Identify the folders to ignore.
                Collection<FolderId> foldersToIgnore =
                        new  Collection<FolderId>() { WellKnownFolderName.DeletedItems, WellKnownFolderName.Drafts };
 
                ConversationResponse oResponses = null;
                oResponses = CurrentService.GetConversationItems(
                        oConversationId,
                        oPropertySet, 
                        null,
                        foldersToIgnore, 
                        ConversationSortOrder.TreeOrderDescending
                        );
       
                //Console.WriteLine("SyncState: " + oResponses.SyncState); // Get the synchronization state of the conversation.

                 
                try {
 
                    foreach (ConversationNode node in oResponses.ConversationNodes) // Process each node of conversation items.
                    {
                        //Console.WriteLine("Parent conversation index: " + node.ParentConversationIndex);
                        //Console.WriteLine("Conversation index: " + node.ConversationIndex);
                        //Console.WriteLine("Conversation node items:");

                        // Process each item in the conversation node.
                        foreach (Item item in node.Items)
                        {
                        //Console.WriteLine("   Item ID: " + item.Id.UniqueId);
                        //Console.WriteLine("   Subject: " + item.Subject);
                        //Console.WriteLine("   Received: " + item.DateTimeReceived);
                        oConversationItems.Add(item.Id);
                        }
                    }
                }
                catch (ServerBusyException srBusyException)  // 2013+
                {
                    Console.WriteLine(srBusyException);
                }
                // This exception may occur if there is an error with the service.
                catch (ServiceResponseException srException)
                {
                  Console.WriteLine(srException);
                }
                this.Cursor = Cursors.Default;

                ItemsContentForm.Show(
                    "Displaying item by Conversation",
                    oConversationItems,
                    this.CurrentService,
                    this);
 
            }
        }

        private void mnuWindowsUserInformation_Click(object sender, EventArgs e)
        {
            string sInfo = string.Empty;
            StringBuilder oSB = new StringBuilder();
            oSB.AppendFormat("From UserPrincipal: \r\n");
            oSB.AppendFormat("  DisplayName: {0}\r\n", UserPrincipal.Current.DisplayName);
            oSB.AppendFormat("  GivenName: {0}\r\n", UserPrincipal.Current.GivenName);
            oSB.AppendFormat("  DistinguishedName: {0}\r\n", UserPrincipal.Current.DistinguishedName);
            oSB.AppendFormat("  Name: {0}\r\n", UserPrincipal.Current.Name);
            if (UserPrincipal.Current.MiddleName != null)
                oSB.AppendFormat("  MiddleName: {0}\r\n", UserPrincipal.Current.MiddleName);
            oSB.AppendFormat("\r\n");
            if (UserPrincipal.Current.EmailAddress != null)
                oSB.AppendFormat("  EmailAddress: {0}\r\n", UserPrincipal.Current.EmailAddress);
            if (UserPrincipal.Current.SamAccountName != null)
                oSB.AppendFormat("  SamAccountName: {0}\r\n", UserPrincipal.Current.SamAccountName);
            if (UserPrincipal.Current.Sid != null)
                oSB.AppendFormat("  Sid: {0}\r\n", UserPrincipal.Current.Sid.Value);
            if (UserPrincipal.Current.UserPrincipalName != null)
                oSB.AppendFormat("  UserPrincipalName: {0}\r\n", UserPrincipal.Current.UserPrincipalName);
            if (UserPrincipal.Current.Surname != null)
                oSB.AppendFormat("  Surname: {0}\r\n", UserPrincipal.Current.Surname);
            if (UserPrincipal.Current.VoiceTelephoneNumber != null)
                oSB.AppendFormat("  VoiceTelephoneNumber: {0}\r\n", UserPrincipal.Current.VoiceTelephoneNumber);
            if (UserPrincipal.Current.HomeDirectory != null)
                oSB.AppendFormat("  HomeDirectory: {0}\r\n", UserPrincipal.Current.HomeDirectory);
            if (UserPrincipal.Current.Guid != null)
                oSB.AppendFormat("  Guid: {0}\r\n", UserPrincipal.Current.Guid.ToString());
            if (UserPrincipal.Current.Description != null)
                oSB.AppendFormat("  Description: {0}\r\n", UserPrincipal.Current.Description.ToString());
 
 
            oSB.AppendFormat("\r\n");
            oSB.AppendFormat("  PasswordNeverExpires: {0}\r\n", UserPrincipal.Current.PasswordNeverExpires.ToString());
            oSB.AppendFormat("  PasswordNotRequired: {0}\r\n", UserPrincipal.Current.PasswordNotRequired.ToString());
            oSB.AppendFormat("  UserCannotChangePassword: {0}\r\n", UserPrincipal.Current.UserCannotChangePassword.ToString());
            oSB.AppendFormat("  SmartcardLogonRequired: {0}\r\n", UserPrincipal.Current.SmartcardLogonRequired.ToString());
            oSB.AppendFormat("\r\n");
            if (UserPrincipal.Current.AccountExpirationDate.HasValue)
                oSB.AppendFormat("  AccountExpirationDate: {0}\r\n", UserPrincipal.Current.AccountExpirationDate.ToString());
            if (UserPrincipal.Current.AccountLockoutTime.HasValue)
                oSB.AppendFormat("  AccountLockoutTime: {0}\r\n", UserPrincipal.Current.AccountLockoutTime.ToString());
           
             
            //string sUserName = UserPrincipal.Current.SamAccountName;
            //DirectorySearcher oDirectorySearcher = new DirectorySearcher();
            //oDirectorySearcher.Filter = String.Format("(SAMAccountName={0})", sUserName);
            //oDirectorySearcher.PropertiesToLoad.Add("cn");
            //oDirectorySearcher.PropertiesToLoad.Add("samaccountname");
            //oDirectorySearcher.PropertiesToLoad.Add("givenname");
            //oDirectorySearcher.PropertiesToLoad.Add("displayname");
            //oDirectorySearcher.PropertiesToLoad.Add("mail");
            //oDirectorySearcher.PropertiesToLoad.Add("userPrincipalName");
            //oDirectorySearcher.PropertiesToLoad.Add("distinguishedName");
            //SearchResult oSearchResult = oDirectorySearcher.FindOne();
            //oSB.AppendFormat("From AD Search on SAMAccountName: \r\n");
            //if (oSearchResult!= null)
            //{

            //    oSearchResult.Properties["displayname"][0].ToString();
            //}
            //else
            //{
            //    oSB.AppendFormat("AD Search on SAMAccountName failed to return results. \r\n");
            //}


            // Machine Information:
            try
            {
                oSB.AppendFormat("\r\n");
                string sHostMachineName = Dns.GetHostName();
                IPHostEntry hostInfo = Dns.GetHostEntry(sHostMachineName);
                IPAddress[] address = hostInfo.AddressList;
                String[] alias = hostInfo.Aliases;

                oSB.AppendFormat("Machine Name: {0}\r\n", sHostMachineName);

                oSB.AppendFormat("Aliases :\r\n");
                for (int index = 0; index < alias.Length; index++)
                {
                     
                    oSB.AppendFormat("    {0}\r\n", alias[index]);
                }

                oSB.AppendFormat("IP address list : \r\n");
                for (int index = 0; index < address.Length; index++)
                {
                    oSB.AppendFormat("    {0}\r\n", address[index] );
                }
         

            }
            catch(Exception ex)
            {
                oSB.AppendFormat("\r\n");
                oSB.AppendFormat("Error trying to retrieve Host information for this machine:\r\n");
                oSB.AppendFormat("{0}\r\n", ex.Source);
                oSB.AppendFormat("{0}\r\n", ex.Message);
            }

            oSB.AppendLine("");
            oSB.AppendLine(MachineInfo());

            oSB.AppendLine("");
            oSB.AppendLine(ProcessInfo());
      

            oSB.AppendLine("");
            oSB.AppendLine(GetDotNetInfo());

            //oSB.AppendLine("");
            //oSB.AppendLine(GetComputerTimeValues());


            string sContent = oSB.ToString();

            ShowTextDocument oForm = new ShowTextDocument();
            oForm.txtEntry.WordWrap = false;
            oForm.Text = "Run-time Information";
            oForm.txtEntry.Text = sContent;
            oForm.Show();
 
        }

        private string MachineInfo()
        {
            StringBuilder oSB = new StringBuilder();
            oSB.AppendLine("Environment Information: ");
            oSB.AppendLine("  MachineName: " + Environment.MachineName);
            oSB.AppendLine("  UserDomainName: " + Environment.UserDomainName);
            oSB.AppendLine("  UserName: " + Environment.UserName);
            oSB.AppendLine("  .NET version currently used: " + Environment.Version);
            oSB.AppendLine("  Is64BitOperatingSystem: " + Environment.Is64BitOperatingSystem);
            oSB.AppendLine("  Is64BitProcess: " + Environment.Is64BitProcess);
            oSB.AppendLine("  OSVersion: " + Environment.OSVersion.VersionString);
            oSB.AppendLine("  ProcessorCount: " + Environment.ProcessorCount.ToString());             
            oSB.AppendLine("  WorkingSet (Memory mapped to this process context): " + Environment.WorkingSet.ToString());
            oSB.AppendLine("  SystemPageSize: " + Environment.SystemPageSize);
            oSB.AppendLine("  SystemDirectory: " + Environment.SystemDirectory);
            oSB.AppendLine("  CurrentDirectory: " + Environment.CurrentDirectory); 
            oSB.AppendLine("  CommandLine: " + Environment.CommandLine);
 

            string[] logicalDrives = Environment.GetLogicalDrives();
            oSB.AppendLine("  Drives: ");
            foreach (string sDrive in logicalDrives)
            {
                oSB.AppendLine("    " + sDrive);
            }
 
            
            return oSB.ToString();
        }

        private string ProcessInfo()
        {
            System.Diagnostics.Process oProc =  System.Diagnostics.Process.GetCurrentProcess();

            StringBuilder oSB = new StringBuilder();
            oSB.AppendLine("Process Information: ");
            oSB.AppendLine("  MachineName: " + oProc.MachineName);
            oSB.AppendLine("  ProcessName: " + oProc.ProcessName);
            oSB.AppendLine("  ID: " + oProc.Id.ToString());
            oSB.AppendLine("  StartTime: " + oProc.StartTime.ToString());
            oSB.AppendLine("  TotalProcessorTime: " + oProc.TotalProcessorTime.ToString());
            oSB.AppendLine("  UserProcessorTime: " + oProc.UserProcessorTime.ToString());
            //oSB.AppendLine("  VirtualMemorySize: " + oProc.VirtualMemorySize.ToString());
            oSB.AppendLine("  VirtualMemorySize64: " + oProc.VirtualMemorySize64.ToString());
            //oSB.AppendLine("  WorkingSet: " + oProc.WorkingSet.ToString());
            oSB.AppendLine("  WorkingSet64: " + oProc.WorkingSet64.ToString());
            oSB.AppendLine("  UserName: " + Environment.UserName);
            oSB.AppendLine("  .NET version currently used: " + Environment.Version);
            oSB.AppendLine("  Is64BitOperatingSystem: " + Environment.Is64BitOperatingSystem);
            oSB.AppendLine("  Is64BitProcess: " + Environment.Is64BitProcess);
            oSB.AppendLine("  OSVersion: " + Environment.OSVersion.VersionString);
            oSB.AppendLine("  ProcessorCount: " + Environment.ProcessorCount.ToString());
            oSB.AppendLine("  WorkingSet (Memory mapped to this process context): " + Environment.WorkingSet.ToString());
            oSB.AppendLine("  SystemPageSize: " + Environment.SystemPageSize);
            oSB.AppendLine("  SystemDirectory: " + Environment.SystemDirectory);
            oSB.AppendLine("  CurrentDirectory: " + Environment.CurrentDirectory);
            oSB.AppendLine("  CommandLine: " + Environment.CommandLine);
            oSB.AppendLine("  MainModule: ");
            oSB.AppendLine("    FileName: " + oProc.MainModule.FileName);
            oSB.AppendLine("    FileVersionInfo: "  );
            oSB.AppendLine("      InternalName: " + oProc.MainModule.FileVersionInfo.InternalName);
            oSB.AppendLine("      OriginalFilename: " + oProc.MainModule.FileVersionInfo.OriginalFilename);
            oSB.AppendLine("      FileVersion: " + oProc.MainModule.FileVersionInfo.FileVersion);
            oSB.AppendLine("      FileDescription: " + oProc.MainModule.FileVersionInfo.FileDescription);
            oSB.AppendLine("      Product: " + oProc.MainModule.FileVersionInfo.ProductName);
            oSB.AppendLine("      ProductVersion: " + oProc.MainModule.FileVersionInfo.ProductVersion);
            oSB.AppendLine("      IsPatched: " + oProc.MainModule.FileVersionInfo.IsPatched.ToString());
            oSB.AppendLine("      InternalName: " + oProc.MainModule.FileVersionInfo.InternalName);
            oSB.AppendLine("      IsPreRelease: " + oProc.MainModule.FileVersionInfo.IsPreRelease.ToString());
            oSB.AppendLine("      PrivateBuild: " + oProc.MainModule.FileVersionInfo.PrivateBuild);
            oSB.AppendLine("      SpecialBuild: " + oProc.MainModule.FileVersionInfo.SpecialBuild);
            oSB.AppendLine("      Language: " + oProc.MainModule.FileVersionInfo.Language);
            oSB.AppendLine("    ModuleName: " + oProc.MainModule.ModuleName.ToString());
            oSB.AppendLine("    ModuleMemorySize: " + oProc.MainModule.ModuleMemorySize.ToString());
            if (oProc.MainModule.Site != null)
            { 
                oSB.AppendLine("    Site:");
                oSB.AppendLine("      Name: " + oProc.MainModule.Site.Name);
            }
            oSB.AppendLine("  StartInfo: ");
            oSB.AppendLine("    Arguments: " + oProc.StartInfo.Arguments);
            oSB.AppendLine("    Domain: " + oProc.StartInfo.Domain);
            oSB.AppendLine("    FileName: " + oProc.StartInfo.FileName);
            oSB.AppendLine("    LoadUserProfile: " + oProc.StartInfo.LoadUserProfile.ToString());
            oSB.AppendLine("    UserName: " + oProc.StartInfo.UserName);
            oSB.AppendLine("    Verb: " + oProc.StartInfo.Verb);
            oSB.AppendLine("    WorkingDirectory: " + oProc.StartInfo.WorkingDirectory);

 
            return oSB.ToString();
        }

        private string GetDotNetInfo()
        {
            StringBuilder oSB = new StringBuilder();

            oSB.AppendLine(".NET version currently used:: " + Environment.Version.ToString());

            oSB.AppendLine("");
            oSB.AppendLine(DotNetUpdateInfo());

            return oSB.ToString();
             
        }


        // DotNetUpdateInfo() - Returns .NET updates installed on the machine.
        // https://msdn.microsoft.com/en-us/library/hh925567(v=vs.110).aspx
        private string DotNetUpdateInfo()
        {
            StringBuilder oSB = new StringBuilder();

            oSB.AppendLine(".NET Updates (Only returned if you are running with administrative credentials):");
            oSB.AppendLine("");
            try
            {

                using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\Updates"))
                {
                    foreach (string baseKeyName in baseKey.GetSubKeyNames())
                    {
                        if (baseKeyName.Contains(".NET Framework") || baseKeyName.StartsWith("KB") || baseKeyName.Contains(".NETFramework"))
                        {

                            using (RegistryKey updateKey = baseKey.OpenSubKey(baseKeyName))
                            {
                                string name = (string)updateKey.GetValue("PackageName", "");
                                oSB.AppendLine(baseKeyName + "  " + name);
                                foreach (string kbKeyName in updateKey.GetSubKeyNames())
                                {
                                    using (RegistryKey kbKey = updateKey.OpenSubKey(kbKeyName))
                                    {
                                        name = (string)kbKey.GetValue("PackageName", "");
                                        oSB.AppendLine("  " + kbKeyName + "  " + name);

                                        if (kbKey.SubKeyCount > 0)
                                        {
                                            foreach (string sbKeyName in kbKey.GetSubKeyNames())
                                            {
                                                using (RegistryKey sbSubKey = kbKey.OpenSubKey(sbKeyName))
                                                {
                                                    name = (string)sbSubKey.GetValue("PackageName", "");
                                                    if (name == "")
                                                        name = (string)sbSubKey.GetValue("Description", "");
                                                    oSB.AppendLine("    " + sbKeyName + "  " + name);

                                                }
                                            }
                                        }
                                    }
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            };

            return oSB.ToString();

        }

        //private string OtherInfo()
        //{
        //    CultureInfo culture;
        //    Console.WriteLine("Culture Name:    {0}", culture.Name);
        //    Console.WriteLine("User Overrides:  {0}", culture.UseUserOverride);
        //    Console.WriteLine("Currency Symbol: {0}\n", culture.NumberFormat.CurrencySymbol);
        //}

        private void mnuSnmClient_Click(object sender, EventArgs e)
        {
            
        }

        private void mnuSnmClient_Click_1(object sender, EventArgs e)
        {
            SystemNetMainForm oForm = new SystemNetMainForm();
            oForm.Show();
        }

        private void mnuEncode_Click(object sender, EventArgs e)
        {
            EncodeForm oForm = new EncodeForm();
            oForm.Show();
        }

        private void UserConfigurationMenuItem_Click(object sender, EventArgs e)
        {
            //UserConfigForm oForm = new UserConfigForm(this.CurrentService);
            //oForm.ShowDialog();
        }

        private void eDiscoverySearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EDiscoverySearchForm oForm = new EDiscoverySearchForm(this.CurrentService);
            oForm.ShowDialog();
        }

        private void serverTimeZoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime oDateTime = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);

            StringBuilder oSB = new StringBuilder();
            oSB.AppendLine("Server TimeZoneInfo:");
            oSB.AppendLine(TimeHelper.GetValuesFromTimeZoneInfo(CurrentService.TimeZone));
            oSB.AppendLine("");

            ShowTextDocument oForm = new ShowTextDocument();
            oForm.txtEntry.WordWrap = false;
            oForm.Text = "Server TimeZone";
            oForm.txtEntry.Text = oSB.ToString();
            oForm.Show();
           
             
        }

        private void mailAppsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MailApps oForm = new MailApps(CurrentService);
            oForm.ShowDialog();
        }

        private void mnuFileContentHelper_Click(object sender, EventArgs e)
        {
            FileContentHelper oForm = new FileContentHelper();
            oForm.Show();
        }

        private void mnuMailTips_Click(object sender, EventArgs e)
        {
            GetMailTipsForm oForm = new GetMailTipsForm();
            oForm.Show();
            oForm = null;
        }

        private void mnuSharedCalendars_Click(object sender, EventArgs e)
        {
            //string sInfo = string.Empty;
            //sInfo = SharedCalendarsHelper.Test(CurrentService, "x@microsoft.com");

            ////sInfo = SharedCalendarsHelper.Test(CurrentService, CurrentAppSettings.MailboxBeingAccessed);

            //ShowTextDocument oForm = new ShowTextDocument();
            //oForm.txtEntry.WordWrap = false;
            //oForm.Text = "Shared Calendars";
            //oForm.txtEntry.Text = sInfo;
            //oForm.ShowDialog();
        }

        private void viewHTMLInBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewInBrowser oForm = new ViewInBrowser();
            oForm.Show();
        }

        private void developerToolsTestWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeveloperServiceTestForm oForm = new DeveloperServiceTestForm(CurrentService);
            oForm.Show();
            
        }

        private void mnuDomainSettings_Click(object sender, EventArgs e)
        {
            DomainSettingsForm oForm = new DomainSettingsForm();
            oForm.Show();
        }

        private void mnuToolsDiscoveryAutodiscoverViewer_Click(object sender, EventArgs e)
        {
            AutodiscoverViewerForm.Show();
        }

        private void mnuToolsDiscoveryDomainSettings_Click(object sender, EventArgs e)
        {
            DomainSettingsForm oForm = new DomainSettingsForm();
            oForm.Show();
        }

        private void mnuToolsDiscoveryScpLookups_Click(object sender, EventArgs e)
        {
            
            ScpLookupForm oForm = new ScpLookupForm();
            oForm.Show();
        }

        private void mnuToolsNotificationsPullNotificationsViewer_Click(object sender, EventArgs e)
        {
            PullNotificationForm.Show(this.CurrentService);
        }

        private void mnuToolsNotificationsStreamingNotificationsViewer_Click(object sender, EventArgs e)
        {
            StreamingNotificationForm.Show();
        }

        private void mnuToolsNotificationsItemSynchronizationViewer_Click(object sender, EventArgs e)
        {
            SyncFolderItemsForm.Show(this.CurrentService);
        }

        private void mnuMimeParser_Click(object sender, EventArgs e)
        {
            MimeParserForm oForm = new MimeParserForm();
            oForm.Show();
        }

        private void mnuUserSettingsUserOofSettings_Click(object sender, EventArgs e)
        {
            NameResolutionCollection names = null;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // If there is no CurrentService then we can't do anything
                if (this.CurrentService == null)
                {
                    return;
                }
                if (this.CurrentAppSettings != null)
                {
                    if (this.CurrentAppSettings.AuthenticationMethod == RequestedAuthType.oAuth)
                    {
                        names = this.CurrentService.ResolveName(this.CurrentAppSettings.MailboxBeingAccessed);
                    }
                    else
                    {
                        // Attempt to resolve the Act As account name.  If there is only one
                        // hit from ResolveNames then assume it is the right one.
                        names = this.CurrentService.ResolveName(this.CurrentService.GetActAsAccountName());
                    }
                }
                else
                {
                    names = this.CurrentService.ResolveName(this.CurrentService.GetActAsAccountName());
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

            if (names != null && names.Count == 1)
            {
                OofForm.ShowDialog(
                    this.CurrentService,
                    new Mailbox(names[0].Mailbox.Address));
            }
            else
            {
                OofForm.ShowDialog(this.CurrentService);
            }

        }

        private void mnuUserSettingsUserAvailability_Click(object sender, EventArgs e)
        {
            AvailabilityForm.Show(this.CurrentService);

        }

        private void mnuUserSettingsUserRetentionTags_Click(object sender, EventArgs e)
        {
            UserRetentionTagPolicyTagsForm oForm = new UserRetentionTagPolicyTagsForm(CurrentService);
            oForm.Show();
        }

        private void mnuUserSettingsUserConfiguration_Click(object sender, EventArgs e)
        {
            UserConfigForm oForm = new UserConfigForm(this.CurrentService);
            oForm.ShowDialog();
        }

        private void mnuUserSettings_Click(object sender, EventArgs e)
        {

        }

        private void mnuCredentialCache_Click(object sender, EventArgs e)
        {
            CredentialCacheForm oForm = new CredentialCacheForm();
            oForm.Show();
        }
    }
}
