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

    using System.Net;

    using Microsoft.Exchange.WebServices.Data;

    public partial class BrowserForm : CountedForm
    {
        private PropertySet defaultDetailPropertySet = new PropertySet(BasePropertySet.IdOnly);
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
                this.SetServiceLabel(value);
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
            // Attempt to resolve the Act As account name.  If there is only one
            // hit from ResolveNames then assume it is the right one.
            NameResolutionCollection names = 
                this.CurrentService.ResolveName(this.CurrentService.GetActAsAccountName());

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
            ResolveNameDialog.ShowDialog(this.CurrentService);
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
            NameResolutionCollection names = null;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // If there is no CurrentService then we can't do anything
                if (this.CurrentService == null)
                {
                    return;
                }

                // Attempt to resolve the Act As account name.  If there is only one
                // hit from ResolveNames then assume it is the right one.
                names = this.CurrentService.ResolveName(
                    this.CurrentService.GetActAsAccountName());
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

        /// <summary>
        /// Display the AvailabilityForm
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private void MnuAvailability_Click(object sender, EventArgs e)
        {
            AvailabilityForm.Show(this.CurrentService);
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
            if (ItemIdDialog.ShowDialog(out itemId) == DialogResult.OK)
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
            FolderId folderId = null;
            if (FolderIdDialog.ShowDialog(ref folderId) == DialogResult.OK && folderId != null)
            {
                Folder folder = Folder.Bind(
                    this.CurrentService,
                    folderId,
                    this.CurrentDetailPropertySet);
                 
                FolderContentForm.Show(
                    string.Format(DisplayStrings.TITLE_CONTENTS_FOLDER, folder.DisplayName),
                    folder,
                    ItemTraversal.Shallow,
                    this.CurrentService,
                    this);
            }
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
            if (this.CurrentService != null)
            {
                TimeZonesForm oTimeZonesForm = new TimeZonesForm(this.CurrentService);
                oTimeZonesForm.ShowDialog();
            }

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

        private void mnuMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

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
            oSB.AppendFormat("DisplayName: {0}\r\n", UserPrincipal.Current.DisplayName);
            oSB.AppendFormat("GivenName: {0}\r\n", UserPrincipal.Current.GivenName);
            oSB.AppendFormat("DistinguishedName: {0}\r\n", UserPrincipal.Current.DistinguishedName);
            oSB.AppendFormat("Name: {0}\r\n", UserPrincipal.Current.Name);
            oSB.AppendFormat("MiddleName: {0}\r\n", UserPrincipal.Current.MiddleName);
            oSB.AppendFormat("\r\n");
            oSB.AppendFormat("EmailAddress: {0}\r\n", UserPrincipal.Current.EmailAddress);
            oSB.AppendFormat("SamAccountName: {0}\r\n", UserPrincipal.Current.SamAccountName);
            oSB.AppendFormat("Sid: {0}\r\n", UserPrincipal.Current.Sid.Value);
            oSB.AppendFormat("\r\n");
            oSB.AppendFormat("PasswordNeverExpires: {0}\r\n", UserPrincipal.Current.PasswordNeverExpires.ToString());
            oSB.AppendFormat("PasswordNotRequired: {0}\r\n", UserPrincipal.Current.PasswordNotRequired.ToString());
            oSB.AppendFormat("UserCannotChangePassword: {0}\r\n", UserPrincipal.Current.UserCannotChangePassword.ToString());
            oSB.AppendFormat("SmartcardLogonRequired: {0}\r\n", UserPrincipal.Current.SmartcardLogonRequired.ToString());
 
            if (UserPrincipal.Current.AccountExpirationDate.HasValue)
                oSB.AppendFormat("AccountExpirationDate: {0}\r\n", UserPrincipal.Current.AccountExpirationDate.ToString());
            if (UserPrincipal.Current.AccountLockoutTime.HasValue)
                oSB.AppendFormat("AccountLockoutTime: {0}\r\n", UserPrincipal.Current.AccountLockoutTime.ToString());

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

             

            string sContent = oSB.ToString();

            ShowTextDocument oForm = new ShowTextDocument();
            oForm.txtEntry.WordWrap = false;
            oForm.Text = "Current Windows User Information";
            oForm.txtEntry.Text = sContent;
            oForm.ShowDialog();
 
        }

        private void mnuSnmClient_Click(object sender, EventArgs e)
        {
            
        }

        private void mnuSnmClient_Click_1(object sender, EventArgs e)
        {
            SystemNetMainForm oForm = new SystemNetMainForm();
            oForm.ShowDialog();
        }

        private void mnuEncode_Click(object sender, EventArgs e)
        {
            EncodeForm oForm = new EncodeForm();
            oForm.ShowDialog();
        }

        private void UserConfigurationMenuItem_Click(object sender, EventArgs e)
        {
            UserConfigForm oForm = new UserConfigForm(this.CurrentService);
            oForm.ShowDialog();
        }

        private void eDiscoverySearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EDiscoverySearchForm oForm = new EDiscoverySearchForm(this.CurrentService);
            oForm.ShowDialog();
        }
    }
}
