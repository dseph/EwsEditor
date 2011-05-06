using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Exchange.WebServices.Data;

using EWSEditor.Resources;

namespace EWSEditor.Forms
{
    public partial class PullNotificationForm : CountedForm
    {
        private PullSubscription CurrentSubscription = null;
        private FolderId CurrentFolderId = null;

        public PullNotificationForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Show the PullNotificationForm non-modal
        /// </summary>
        /// <param name="service">ExchangeService to use when making calls.</param>
        public static void Show(ExchangeService service)
        {
            Show(DisplayStrings.TITLE_NOTIFICATIONS,
                null,
                service);
        }

        /// <summary>
        /// Show the form and default to the given folder.
        /// </summary>
        /// <param name="caption">Form caption to display</param>
        /// <param name="service">ExchangeService to use when making calls.</param>
        /// <param name="folder">Folder to display events from by default</param>
        public static void Show(string caption,
            FolderId folderId,
            ExchangeService service)
        {
            PullNotificationForm diag = new PullNotificationForm();

            // Only try to populate CurrentFolderId if we were passed a value
            if (folderId != null)
            {
                diag.SetAndDisplayFolderId(folderId);
            }
            diag.Text = caption.Length == 0 ? "''" : caption;
            diag.CurrentService = service;

            diag.Show();
        }

        /// <summary>
        /// Gather form input and create PullSubscription
        /// </summary>
        private void btnSubscribe_Click(object sender, EventArgs e)
        {
            const int DEFAULT_NOTIFICATION_TIMEOUT = 5;

            // Convert the check box settings into an array of EventTypes
            List<EventType> eventTypes = new List<EventType>();

            if (this.chkCopiedEvent.Checked)
            {
                eventTypes.Add(EventType.Copied);
            }

            if (this.chkCreatedEvent.Checked)
            {
                eventTypes.Add(EventType.Created);
            }

            if (this.chkDeletedEvent.Checked)
            {
                eventTypes.Add(EventType.Deleted);
            }

            if (this.chkModifiedEvent.Checked)
            {
                eventTypes.Add(EventType.Modified);
            }

            if (this.chkMovedEvent.Checked)
            {
                eventTypes.Add(EventType.Moved);
            }

            if (this.chkNewMailEvent.Checked)
            {
                eventTypes.Add(EventType.NewMail);
            }

            // Create the subscription based on the form settings
            this.CurrentSubscription = this.CurrentService.SubscribeToPullNotifications(
                                                                    new FolderId[] { this.CurrentFolderId },
                                                                    DEFAULT_NOTIFICATION_TIMEOUT,
                                                                    string.Empty,
                                                                    eventTypes.ToArray());

            // Enable/Disable form controls for an active subscription
            this.btnUnsubscribe.Enabled = true;
            this.btnSubscribe.Enabled = false;
            this.btnGetEvents.Enabled = true;
        }

        /// <summary>
        /// Call Unsubscribe() and reset the form.
        /// </summary>
        private void btnUnsubscribe_Click(object sender, EventArgs e)
        {
            this.CurrentSubscription.Unsubscribe();
            this.CurrentSubscription = null;

            // Enable/Disable form controls for no active subscription
            this.btnUnsubscribe.Enabled = false;
            this.btnSubscribe.Enabled = true;
            this.btnGetEvents.Enabled = false;

            // Reset form elements
            this.lstEvents.Items.Clear();
            this.lblEventsHeader.Text = string.Empty;
        }

        /// <summary>
        /// Call GetEvents to get the new notification events and display them
        /// in the ListView.
        /// </summary>
        private void btnGetEvents_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // Guard statement to bail if we haven't subscribed
                if (this.CurrentSubscription == null) { return; }

                GetEventsResults events = this.CurrentSubscription.GetEvents();

                this.lblEventsHeader.Text = string.Format(System.Globalization.CultureInfo.CurrentCulture,
                    "{0} events returned at {1}",
                    events.AllEvents.Count,
                    DateTime.Now.ToString());

                this.lstEvents.Items.Clear();

                foreach (ItemEvent itemEvent in events.ItemEvents)
                {
                    ListViewItem item = new ListViewItem();
                    item.Tag = itemEvent;
                    item.Text = itemEvent.GetType().Name;
                    item.SubItems.Add(itemEvent.TimeStamp.ToString());
                    item.SubItems.Add(itemEvent.EventType.ToString());

                    item.SubItems.Add(
                            itemEvent.ItemId == null ? "" :
                            PropertyInformation.PropertyInterpretation.GetPropertyValue(itemEvent.ItemId));

                    item.SubItems.Add(
                        itemEvent.OldItemId == null ? "" :
                        PropertyInformation.PropertyInterpretation.GetPropertyValue(itemEvent.OldItemId));

                    item.SubItems.Add(
                        itemEvent.ParentFolderId == null ? "" :
                        PropertyInformation.PropertyInterpretation.GetPropertyValue(itemEvent.ParentFolderId));

                    item.SubItems.Add(
                        itemEvent.OldParentFolderId == null ? "" :
                        PropertyInformation.PropertyInterpretation.GetPropertyValue(itemEvent.OldParentFolderId));

                    this.lstEvents.Items.Add(item);
                }

                foreach (FolderEvent folderEvent in events.FolderEvents)
                {
                    ListViewItem item = new ListViewItem();
                    item.Tag = folderEvent;
                    item.Text = folderEvent.GetType().Name;
                    item.SubItems.Add(folderEvent.TimeStamp.ToString());
                    item.SubItems.Add(folderEvent.EventType.ToString());

                    item.SubItems.Add(
                        folderEvent.FolderId == null ? "" :
                        PropertyInformation.PropertyInterpretation.GetPropertyValue(folderEvent.FolderId));

                    item.SubItems.Add(
                        folderEvent.OldFolderId == null ? "" :
                        PropertyInformation.PropertyInterpretation.GetPropertyValue(folderEvent.OldFolderId));

                    item.SubItems.Add(
                        folderEvent.ParentFolderId == null ? "" :
                        PropertyInformation.PropertyInterpretation.GetPropertyValue(folderEvent.ParentFolderId));

                    item.SubItems.Add(
                        folderEvent.OldParentFolderId == null ? "" :
                        PropertyInformation.PropertyInterpretation.GetPropertyValue(folderEvent.OldParentFolderId));

                    this.lstEvents.Items.Add(item);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Display the GetFolderIdDialog to get a valid FolderId object and
        /// call SetAndDisplayFolderId.
        /// </summary>
        private void btnGetFolderId_Click(object sender, EventArgs e)
        {
            FolderId folderId = null;
            if (Forms.FolderIdDialog.ShowDialog(ref folderId) == DialogResult.OK)
            {
                SetAndDisplayFolderId(folderId);
            }
        }

        /// <summary>
        /// Set the class variable and disaply the proper text for the given
        /// FolderId
        /// </summary>
        /// <param name="folderId"></param>
        private void SetAndDisplayFolderId(FolderId folderId)
        {
            this.txtFolderId.Text = PropertyInformation.TypeValues.FolderIdTypeValue.GetValue(folderId, true);
            this.CurrentFolderId = folderId;
            this.Text = DisplayStrings.TITLE_NOTIFICATIONS;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
