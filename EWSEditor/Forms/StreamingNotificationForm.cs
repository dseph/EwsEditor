using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Exchange.WebServices.Data;
using System.Threading;

using EWSEditor.Resources;
using EWSEditor.Logging;
using EWSEditor.Exchange;

namespace EWSEditor.Forms
{
    public partial class StreamingNotificationForm : CountedForm
    {
        private FolderId CurrentFolderId = null;
        private List<Thread> WorkThreads = new List<Thread>();
        private List<StreamingSubscription> ActiveSubscriptions = new List<StreamingSubscription>();
        private List<StreamingSubscriptionConnection> ActiveConnections = new List<StreamingSubscriptionConnection>();

        private Mutex mutConnection = new Mutex();

        private List<EventType> EventTypes = null;
        private bool SubscriptionsRunning = false;

        private static EventWaitHandle ShutdownThreads = new EventWaitHandle(true, EventResetMode.ManualReset);

        public StreamingNotificationForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Show the StreamingNotificationForm non-modal
        /// </summary>
        /// <param name="service">EwsProxyFactory for creating new services to use when making calls.</param>
        public new static void Show()
        {
            Show(DisplayStrings.TITLE_NOTIFICATIONS, null
                );
        }

        /// <summary>
        /// Show the form and default to the given folder.
        /// </summary>
        /// <param name="caption">Form caption to display</param>
        /// <param name="service">ExchangeService to clone when making calls.</param>
        /// <param name="folder">Folder to display events from by default</param>
        public static void Show(string caption,
            FolderId folderId)
        {
            StreamingNotificationForm diag = new StreamingNotificationForm();

            // Only try to populate CurrentFolderId if we were passed a value
            if (folderId != null)
            {
                diag.SetAndDisplayFolderId(folderId);
            }
            diag.Text = caption.Length == 0 ? "''" : caption;

            ((Control)diag).Show();
        }

        /// <summary>
        /// Gather form input and create StreamingSubscription
        /// </summary>
        private void btnSubscribe_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            SubscriptionsRunning = true;
            SetControls(subscriptionrunning: true);
            EventTypes = GetEventTypes();

            ShutdownThreads.Reset();

            for (int i = 0; i < numThreads.Value; i++)
            {
                Thread WorkThread = new Thread(new ThreadStart(StreamingSubscribeWork));
                WorkThread.Start();
            }
            
            Cursor = Cursors.Default;

        }

        private List<EventType> GetEventTypes()
        {
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
            if (this.chkFreeBusyChangedEvent.Checked)
            {
                eventTypes.Add(EventType.FreeBusyChanged);
            }


            return (eventTypes);

        }

        ////DJB
        //private void GetGroupingInfo(ExchangeService oExchangeService, string DiscoverMailbox)
        //{
        //    //oExchangeService.get
        //    string UseVersion = oExchangeService.RequestedServerVersion.ToString();
        //    string UseUrl = oExchangeService.Url.ToString();  // djb - need to fix it to the autodiscover url.
 
        //    string EwsRequest = EwsRequests.GroupingInformationTemplateRequest;
        //    EwsRequest =  EwsRequest.Replace("XXXExchangeVersionXXX",  UseVersion);
        //    EwsRequest =  EwsRequest.Replace("XXXAutoDiscoverServiceServerXXX", UseUrl);
        //    EwsRequest =  EwsRequest.Replace("XXXMailboxSmtpXXX", DiscoverMailbox);

        //    // DO raw post 
        //    // string sResponse
        //    // if (DoRawPost(UseUrl, oExchangeService.ServerCredentials, EwsRequest, ref sResponse));
        //    // {
        //    //    Extract GroupingInformation and external url from sResponse);
        //    // }
        //    // else
        //    // {
        //    //    return error;
        //    // }

 
        //}
 
        private void StreamingSubscribeWork()
        {

            // djb
            // get a list of maiboxes, thier external ews urls and grouping info
            // list of items = GetGroupingInfo(ExchangeService oExchangeService, string DiscoverMailbox);
            // Sort list of items by url + GroupingInformaiton
            // 

            try
            {
                lock (WorkThreads)
                {
                    WorkThreads.Add(Thread.CurrentThread);
                    SetControlText(ThreadCount, WorkThreads.Count.ToString());
                }

                if (chkSerialize.Checked)
                    mutConnection.WaitOne();

                string TID = Thread.CurrentThread.ManagedThreadId.ToString("[0]");
                ListViewItem item = new ListViewItem();
                item.Tag = "[local]ThreadStart";
                item.Text = "[local]ThreadStart";
                item.SubItems.Add(TID);
                item.SubItems.Add(DateTime.Now.ToString());
                AddToDisplay(lstEvents, item);

                ExchangeService ThreadLocalService = EwsProxyFactory.CreateExchangeService();

                List<StreamingSubscription> ThreadLocalSubscriptions = new List<StreamingSubscription>();

                // Create the subscriptions based on the form settings
                for (int i = 0; i < numSubs.Value; i++)
                {
                    try
                    {
                        StreamingSubscription CurrentSubscription = null;
                        if (chkAllFoldes.Checked == false)
                        {
                            CurrentSubscription = ThreadLocalService.SubscribeToStreamingNotifications(
                                                                                new FolderId[] { this.CurrentFolderId },
                                                                                EventTypes.ToArray());
                        }
                        else
                        {
                            CurrentSubscription = ThreadLocalService.SubscribeToStreamingNotificationsOnAllFolders(
                                                                                 EventTypes.ToArray());
                        }

                        ThreadLocalSubscriptions.Add(CurrentSubscription);
                        lock (ActiveSubscriptions)
                        {
                            ActiveSubscriptions.Add(CurrentSubscription);
                            SetControlText(SubscriptionCount, ActiveSubscriptions.Count.ToString());
                        }

                    }
                    catch (Exception ex)
                    {
                        DebugLog.WriteException("Error Subscribe or Add [TID:"
                            + TID + "]", ex);
                        item = new ListViewItem();
                        item.Tag = "[local]SubscribeError";
                        item.Text = "[local]SubscribeError";
                        item.ToolTipText = ex.ToString();
                        item.SubItems.Add(TID);
                        item.SubItems.Add(DateTime.Now.ToString());
                        AddToDisplay(lstEvents, item);

                    }
                }

                // Create a new StreamingSubscriptionConnection
                StreamingSubscriptionConnection CurrentConnection = new StreamingSubscriptionConnection(ThreadLocalService, (int)SubscriptionLifetime.Value);
               
                lock (ActiveConnections)
                {
                    ActiveConnections.Add(CurrentConnection);
                    SetControlText(ConnectionCount, ActiveConnections.Count.ToString());
                }

                // Add Handlers 
                CurrentConnection.OnDisconnect += OnDisconnect;
                CurrentConnection.OnSubscriptionError += OnSubscriptionError;
                CurrentConnection.OnNotificationEvent += OnStreamingEvent;
                 

                // Add the Subscriptions to the Connection
                foreach (StreamingSubscription CurrentSubscription in ThreadLocalSubscriptions)
                    CurrentConnection.AddSubscription(CurrentSubscription);

                if (chkSerialize.Checked)
                    mutConnection.ReleaseMutex();

                // Open the Connection
                try
                {
                    if (ThreadLocalService.CookieContainer.Count > 0)
                    {
                        System.Net.CookieCollection MyCookies = ThreadLocalService.CookieContainer.GetCookies(ThreadLocalService.Url);
                         
                    }
                    CurrentConnection.Open();
                    
                    ShutdownThreads.WaitOne();
                }
                catch (Exception ex)
                {
                    DebugLog.WriteException("Error Opening StreamingSubscriptionConnection [TID:"
                        + Thread.CurrentThread.ManagedThreadId.ToString() + "]", ex);
                    item = new ListViewItem();
                    item.Tag = "[local]OpenError";
                    item.Text = "[local]OpenError";
                    item.ToolTipText = ex.ToString();
                    item.SubItems.Add(TID);
                    item.SubItems.Add(DateTime.Now.ToString());
                    AddToDisplay(lstEvents, item);

                }

                try
                {
                    //  Close Connection
                    if (CurrentConnection.IsOpen)
                    {
                        CurrentConnection.Close();
//                        Thread.Sleep(500);
                    }

                }
                catch (Exception ex)
                {
                    DebugLog.WriteException("Error Closing Streaming Connection [TID:" + Thread.CurrentThread.ManagedThreadId.ToString() + "]", ex);
                    item = new ListViewItem();
                    item.Tag = "[local]CloseError";
                    item.Text = "[local]CloseError";
                    item.ToolTipText = ex.ToString();
                    item.SubItems.Add(TID);
                    item.SubItems.Add(DateTime.Now.ToString());
                    AddToDisplay(lstEvents, item);

                }
                finally
                {
                    lock (ActiveConnections)
                    {
                        ActiveConnections.Remove(CurrentConnection);
                        SetControlText(ConnectionCount, ActiveConnections.Count.ToString());
                    }
                }

                //  Remove Handlers
                CurrentConnection.OnDisconnect -= OnDisconnect;
                CurrentConnection.OnSubscriptionError -= OnSubscriptionError;
                CurrentConnection.OnNotificationEvent -= OnStreamingEvent;

                foreach (StreamingSubscription CurrentSubscription in ThreadLocalSubscriptions)
                {
                    try
                    {
                        CurrentConnection.RemoveSubscription(CurrentSubscription);
                        CurrentSubscription.Unsubscribe();
                    }
                    catch (Exception ex)
                    {
                        DebugLog.WriteException("Error Removing/Unsubscribing StreamingSubscription Elements [TID:"
                            + Thread.CurrentThread.ManagedThreadId.ToString() + "]", ex);
                        item = new ListViewItem();
                        item.Tag = "[local]UnsubscribeError";
                        item.Text = "[local]UnsubscribeError";
                        item.ToolTipText = ex.ToString();
                        item.SubItems.Add(TID);
                        item.SubItems.Add(DateTime.Now.ToString());
                        AddToDisplay(lstEvents, item);

                    }
                    finally
                    {
                        lock (ActiveSubscriptions)
                        {
                            ActiveSubscriptions.Remove(CurrentSubscription);
                            SetControlText(SubscriptionCount, ActiveSubscriptions.Count.ToString());
                        }
                    }

                }

                lock (WorkThreads)
                {
                    WorkThreads.Remove(Thread.CurrentThread);
                }
                SetControlText(ThreadCount, WorkThreads.Count.ToString());
            }
            catch(Exception ex) { DebugLog.WriteException("Unexpected Exception in WorkerThread", ex); }
            finally { }
        }

        private void OnSubscriptionError(object sender, SubscriptionErrorEventArgs args)
        {
            DebugLog.WriteException("SubscriptionError", args.Exception);
            ListViewItem item = new ListViewItem();
            item.Tag = "[local]OnSubscriptionError";
            item.Text = "[local]OnSubscriptionError";
            item.ToolTipText = args.Exception.ToString();
            item.SubItems.Add(Thread.CurrentThread.ManagedThreadId.ToString("[0]"));
            item.SubItems.Add(DateTime.Now.ToString());
            AddToDisplay(lstEvents, item);

        }

        private void OnDisconnect(object sender, SubscriptionErrorEventArgs args)
        {
            string TID = Thread.CurrentThread.ManagedThreadId.ToString("[0]");
            if (SubscriptionsRunning)
            {
                StreamingSubscriptionConnection CurrentConnection = (StreamingSubscriptionConnection)sender;
                ListViewItem item = new ListViewItem();
                item.Tag = "[local]Reconnect";
                item.Text = "[local]Reconnect";
                item.SubItems.Add(TID);
                item.SubItems.Add(DateTime.Now.ToString());
                AddToDisplay(lstEvents, item);

                try
                {
                    CurrentConnection.Open();
                }
                catch (Exception ex)
                {
                    DebugLog.WriteException("OnDisconnectError", ex);
                    item = new ListViewItem();
                    item.Tag = "[local]ReconnectError";
                    item.Text = "[local]ReconnectError";
                    item.ToolTipText = ex.ToString();
                    item.SubItems.Add(Thread.CurrentThread.ManagedThreadId.ToString("[0]"));
                    item.SubItems.Add(DateTime.Now.ToString());
                    AddToDisplay(lstEvents, item);
                }
            }
        }


        private delegate void ControlInvokeDelegate<T,S>(T control,S item);

        private void AddToDisplay(ListView listview, ListViewItem item)
        {
            if (listview.InvokeRequired)
                listview.Invoke(new ControlInvokeDelegate<ListView,ListViewItem>(AddToDisplay), listview, item);
            else
            {
                listview.Items.Add(item);
                SetControlText(EventCount,lstEvents.Items.Count.ToString());
            }
        }

        private void SetControlText(Control C, string T)
        {
            if (C.InvokeRequired)
            {
                C.Invoke(new ControlInvokeDelegate<Control, string>(SetControlText), C, T);
            }
            else
            {
                C.Text = T;
            }

        }

        private void OnStreamingEvent(object sender, NotificationEventArgs args)
        {
            string TID = Thread.CurrentThread.ManagedThreadId.ToString("[0]");

             

            foreach (NotificationEvent evt in args.Events)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = evt;
                item.Text = evt.GetType().Name;   

                ItemEvent itemevt = (evt is ItemEvent) ? (ItemEvent)evt : null;

                FolderEvent folderevt = (evt is FolderEvent) ? (FolderEvent)evt : null;

                item.SubItems.Add(TID);
                item.SubItems.Add(evt.TimeStamp.ToString());
                item.SubItems.Add(evt.EventType.ToString());

                item.SubItems.Add(
                    evt.ParentFolderId == null ? "" :
                    PropertyInformation.PropertyInterpretation.GetPropertyValue(evt.ParentFolderId));

                item.SubItems.Add(
                    evt.OldParentFolderId == null ? "" :
                    PropertyInformation.PropertyInterpretation.GetPropertyValue(evt.OldParentFolderId));

                // Add ItemEvent Specific Fields
                item.SubItems.Add(
                    itemevt == null || itemevt.ItemId == null ? "" :
                    PropertyInformation.PropertyInterpretation.GetPropertyValue(itemevt.ItemId));

                item.SubItems.Add(
                    itemevt == null || itemevt.OldItemId == null ? "" :
                    PropertyInformation.PropertyInterpretation.GetPropertyValue(itemevt.OldItemId));

                // Add FolderEvent Specific Fields

                item.SubItems.Add(
                        folderevt == null || folderevt.FolderId == null ? "" :
                        PropertyInformation.PropertyInterpretation.GetPropertyValue(folderevt.FolderId));

                item.SubItems.Add(
                        folderevt == null || folderevt.OldFolderId == null ? "" :
                        PropertyInformation.PropertyInterpretation.GetPropertyValue(folderevt.OldFolderId));

                item.SubItems.Add(
                        folderevt == null || folderevt.UnreadCount == null ? "" : folderevt.UnreadCount.ToString());

                //StreamingEventLine oLine = new StreamingEventLine();
                //oLine.StreamingEventType = item.Text;
                //oLine.OnThread = item.SubItems[1].Text;
                //oLine.TimeStamp = item.SubItems[2].Text;
                //oLine.EventType  =  item.SubItems[3].Text;
                //oLine.ParentFolderId = evt.ParentFolderId.UniqueId.ToString();
                //oLine.ParentFolderChangeKey = evt.ParentFolderId.ChangeKey.ToString();
                //oLine.OldParentFolderId = evt.OldParentFolderId.UniqueId.ToString();
                //oLine.OldParentFolderChangeKey = evt.OldParentFolderId.ChangeKey.ToString();
                //oLine.Item_ItemId = itemevt.ItemId.UniqueId.ToString();
                //oLine.Item_ItemChangeKey = itemevt.ItemId.ChangeKey.ToString();
                //oLine.Item_OldItemId = itemevt.OldItemId.UniqueId.ToString();
                //oLine.Item_OldItemChangeKey = itemevt.OldItemId.ChangeKey.ToString();
                //oLine.FolderEvent_FolderId = folderevt.FolderId.UniqueId.ToString();
                //oLine.FolderEvent_FolderChangeKey = folderevt.FolderId.ChangeKey.ToString();
                //oLine.Folder_OldFolderId = folderevt.OldFolderId.UniqueId.ToString();
                //oLine.Folder_OldFolderChangeKey = folderevt.OldFolderId.ChangeKey.ToString();
                //oLine.FolderEvent_UnreadCount = folderevt.UnreadCount.ToString();

                //item/

                AddToDisplay(lstEvents,item);

              
 

            }



        }






        /// <summary>
        /// Call Unsubscribe() and reset the form.
        /// </summary>
        private void btnUnsubscribe_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            SubscriptionsRunning = false;
            ShutdownSubscriptionThreads();

            // Enable/Disable form controls for no active subscription
            SetControls(subscriptionrunning: false);
            Cursor = Cursors.Default;
        }

        private void ShutdownSubscriptionThreads()
        {
            ShutdownThreads.Set();
        }

        private void SetControls(bool subscriptionrunning)
        {
            foreach (Control c in grpSynchronize.Controls)
                c.Enabled = !subscriptionrunning;
            this.btnUnsubscribe.Enabled = subscriptionrunning;
            this.btnSubscribe.Enabled = !subscriptionrunning;

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
            ShutdownSubscriptionThreads();
            this.Close();
        }

        private void StreamingNotificationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ShutdownSubscriptionThreads();
        }


        private void btnClearEvents_Click(object sender, EventArgs e)
        {
            this.lstEvents.Items.Clear();
            EventCount.Text = "";
        }

        private void ThreadCountLabel_DoubleClick(object sender, EventArgs e)
        {
            foreach (Thread t in WorkThreads)
            {
                t.Abort();
            }
        }

        private void grpSynchronize_Enter(object sender, EventArgs e)
        {

        }

        private void StreamingNotificationForm_Load(object sender, EventArgs e)
        {
            SetROchkAllFoldes();
        }

        private void chkAllFoldes_CheckedChanged(object sender, EventArgs e)
        {
            SetROchkAllFoldes();
        }

        private void SetROchkAllFoldes()
        {
            bool bChecked = false;
            if (chkAllFoldes.Checked == false)
                bChecked = true;

            txtFolderId.Enabled = bChecked;
            btnGetFolderId.Enabled = bChecked;
        }

        private void lstEvents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstEvents_DoubleClick(object sender, EventArgs e)
        {
            string ParentFolderName = string.Empty;
            string ParentFolderClass = string.Empty;
            string OldParentFolderName = string.Empty;
            string OldParentFolderClass = string.Empty;

            string ItemName = string.Empty;
            string ItemClass = string.Empty;
            string OldItemName = string.Empty;
            string OldItemClass = string.Empty;

            string FolderEvent_FolderName  = string.Empty;
            string FolderEvent_FolderClass  = string.Empty;
            string Folder_OldFolderName  = string.Empty;
            string Folder_OldFolderClass  = string.Empty;
 
            Folder oFolderId = null;
            Item oItem = null;
            ExchangeService oExchangeService = null;

            

            if (lstEvents.SelectedItems.Count > 0)
            {
                if (lstEvents.SelectedItems[0].Tag.ToString().StartsWith("[") == false)
                {
                    NotificationEvent evt = (NotificationEvent)lstEvents.SelectedItems[0].Tag;

                    ItemEvent itemevt = (evt is ItemEvent) ? (ItemEvent)evt : null;

                    FolderEvent folderevt = (evt is FolderEvent) ? (FolderEvent)evt : null;

                    oExchangeService = EwsProxyFactory.CreateExchangeService();
                    if (lstEvents.SelectedItems[0].SubItems[4].Text.TrimEnd().Length != 0)
                    {
                        try
                        {
                            oFolderId = Folder.Bind(oExchangeService, new FolderId(evt.ParentFolderId.UniqueId));
                            if (oFolderId != null)
                            {
                                ParentFolderName = oFolderId.DisplayName;
                                ParentFolderClass = oFolderId.FolderClass;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.ToString());
                        }
                    }
                    if (lstEvents.SelectedItems[0].SubItems[5].Text.TrimEnd().Length != 0)
                    {
                        try
                        {
                            oFolderId = Folder.Bind(oExchangeService, new FolderId(evt.OldParentFolderId.UniqueId));
                            if (oFolderId != null)
                            {
                                OldParentFolderName = oFolderId.DisplayName;
                                OldParentFolderClass = oFolderId.FolderClass;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.ToString());
                        }
                    }
                    if (lstEvents.SelectedItems[0].SubItems[6].Text.TrimEnd().Length != 0)
                    {
                        try
                        {
                            oItem = Item.Bind(oExchangeService, new ItemId(itemevt.ItemId.UniqueId));
                            if (oItem != null)
                            {
                                ItemName = oItem.Subject;
                                ItemClass = oItem.ItemClass;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.ToString());
                        }
                    }
                    if (lstEvents.SelectedItems[0].SubItems[7].Text.TrimEnd().Length != 0)
                    {
                        try
                        {
                            oItem = Item.Bind(oExchangeService, new ItemId(itemevt.OldItemId.UniqueId));
                            if (oItem != null)
                            {
                                OldItemName = oItem.Subject;
                                OldItemClass = oItem.ItemClass;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.ToString());
                        }
                    }
                    if (lstEvents.SelectedItems[0].SubItems[8].Text.TrimEnd().Length != 0)
                    {
                        try
                        {
                            oFolderId = Folder.Bind(oExchangeService, new FolderId(folderevt.ParentFolderId.UniqueId));
                            if (oFolderId != null)
                            {
                                FolderEvent_FolderName = oFolderId.DisplayName;
                                FolderEvent_FolderClass = oFolderId.FolderClass;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.ToString());
                        }
                    }
                    if (lstEvents.SelectedItems[0].SubItems[9].Text.TrimEnd().Length != 0)
                    {
                        try
                        {
                            oFolderId = Folder.Bind(oExchangeService, new FolderId(folderevt.OldParentFolderId.UniqueId));
                            if (oFolderId != null)
                            {
                                Folder_OldFolderName = oFolderId.DisplayName;
                                Folder_OldFolderClass = oFolderId.FolderClass;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: " + ex.ToString());
                        }
                    }

                    StringBuilder oSB = new StringBuilder();
                    oSB.AppendFormat("EventType:                \r\n    {0}\r\n", lstEvents.SelectedItems[0].Text);
                    oSB.AppendFormat("\r\n");
                    oSB.AppendFormat("Thread:                   \r\n    {0}\r\n", lstEvents.SelectedItems[0].SubItems[1].Text);
                    oSB.AppendFormat("\r\n");
                    oSB.AppendFormat("TimeStamp:                \r\n    {0}\r\n", lstEvents.SelectedItems[0].SubItems[2].Text);
                    oSB.AppendFormat("\r\n");
                    oSB.AppendFormat("EventType:                \r\n    {0}\r\n", lstEvents.SelectedItems[0].SubItems[3].Text);
                    oSB.AppendFormat("\r\n");

                    oSB.AppendFormat("ParentFolderId:\r\n");
                    if (evt != null)
                    {
                        if (evt.ParentFolderId != null)
                        {
                            oSB.AppendFormat("    UniqueId:  {0}\r\n", evt.ParentFolderId.UniqueId.ToString());
                            oSB.AppendFormat("    ChangeKey: {0}\r\n", evt.ParentFolderId.ChangeKey.ToString());
                            oSB.AppendFormat("    Name:      {0}\r\n", ParentFolderName);
                            oSB.AppendFormat("    Class:     {0}\r\n", ParentFolderClass);
                        }
                    }
                    oSB.AppendFormat("\r\n");

                    oSB.AppendFormat("OldParentFolderId:\r\n");
                    if (evt != null)
                    {
                        if (evt.OldParentFolderId != null)
                        {
                            oSB.AppendFormat("    UniqueId:  {0}\r\n", evt.OldParentFolderId.UniqueId.ToString());
                            oSB.AppendFormat("    ChangeKey: {0}\r\n", evt.OldParentFolderId.ChangeKey.ToString());
                            oSB.AppendFormat("    Name:      {0}\r\n", OldParentFolderName);
                            oSB.AppendFormat("    Class:     {0}\r\n", OldParentFolderClass);
                        }
                    }
                    oSB.AppendFormat("\r\n");

                    oSB.AppendFormat("Item.ItemId:\r\n");
                    if (itemevt != null)
                    {
                        if (itemevt.ItemId != null)
                        {
                            oSB.AppendFormat("    UniqueId:  {0}\r\n", itemevt.ItemId.UniqueId.ToString());
                            oSB.AppendFormat("    ChangeKey: {0}\r\n", itemevt.ItemId.ChangeKey.ToString());
                            oSB.AppendFormat("    Name:      {0}\r\n", ItemName);
                            oSB.AppendFormat("    Class:     {0}\r\n", ItemClass);
                        }
                    }
                    oSB.AppendFormat("\r\n");

                    oSB.AppendFormat("Item.OldItemId:\r\n");
                    if (itemevt != null)
                    {
                        if (itemevt.OldItemId != null)
                        {
                            oSB.AppendFormat("    UniqueId:  {0}\r\n", itemevt.OldItemId.UniqueId.ToString());
                            oSB.AppendFormat("    ChangeKey: {0}\r\n", itemevt.OldItemId.ChangeKey.ToString());
                            oSB.AppendFormat("    Name:      {0}\r\n", OldItemName);
                            oSB.AppendFormat("    Class:     {0}\r\n", OldItemClass);
                        }
                    }
                    oSB.AppendFormat("\r\n");


                    oSB.AppendFormat("FolderEvent.FolderId:\r\n");
                    if (folderevt != null)
                    {
                        if (folderevt.ParentFolderId != null)
                        {
                            oSB.AppendFormat("    UniqueId:  {0}\r\n", folderevt.ParentFolderId.UniqueId.ToString());
                            oSB.AppendFormat("    ChangeKey: {0}\r\n", folderevt.ParentFolderId.ChangeKey.ToString());
                            oSB.AppendFormat("    Name:      {0}\r\n", FolderEvent_FolderName);
                            oSB.AppendFormat("    Class:     {0}\r\n", FolderEvent_FolderClass);
                        }
                    }
                    oSB.AppendFormat("\r\n");

                    oSB.AppendFormat("Folder.OldFolderId:\r\n");
                    if (folderevt != null)
                    {
                        if (folderevt.OldParentFolderId != null)
                        {
                            oSB.AppendFormat("    UniqueId:  {0}\r\n", folderevt.OldParentFolderId.UniqueId.ToString());
                            oSB.AppendFormat("    ChangeKey: {0}\r\n", folderevt.OldParentFolderId.ChangeKey.ToString());
                            oSB.AppendFormat("    Name:      {0}\r\n", Folder_OldFolderName);
                            oSB.AppendFormat("    Class:     {0}\r\n", Folder_OldFolderClass);
                        }
                    }
                    oSB.AppendFormat("\r\n");

                    //oSB.AppendFormat("ParentFolderId:           \r\n    {0}\r\n", lstEvents.SelectedItems[0].SubItems[4].Text.TrimEnd().Replace("ChangeKey:", "\r\n    ChangeKey:"));
                    //oSB.AppendFormat("\r\n");
                    //oSB.AppendFormat("OldParentFolderId:        \r\n    {0}\r\n", lstEvents.SelectedItems[0].SubItems[5].Text.TrimEnd().Replace("ChangeKey:", "\r\n    ChangeKey:"));
                    //oSB.AppendFormat("\r\n");

                    //oSB.AppendFormat("Item.ItemId:              \r\n    {0}\r\n", lstEvents.SelectedItems[0].SubItems[6].Text.TrimEnd().Replace("ChangeKey:", "    ChangeKey:"));
                    //oSB.AppendFormat("\r\n");
                    //oSB.AppendFormat("Item.OldItemId:           \r\n    {0}\r\n", lstEvents.SelectedItems[0].SubItems[7].Text.TrimEnd().Replace("ChangeKey:", "    ChangeKey:"));
                    //oSB.AppendFormat("\r\n");

                    //oSB.AppendFormat("FolderEvent.FolderId:     \r\n    {0}\r\n", lstEvents.SelectedItems[0].SubItems[8].Text.TrimEnd().Replace("ChangeKey:", "\r\n    ChangeKey:"));
                    //oSB.AppendFormat("\r\n");
                    //oSB.AppendFormat("Folder.OldFolderId:       \r\n    {0}\r\n", lstEvents.SelectedItems[0].SubItems[9].Text.TrimEnd().Replace("ChangeKey:", "    ChangeKey:"));
                    //oSB.AppendFormat("\r\n");

                    oSB.AppendFormat("FolderEvent.UnreadCount:  \r\n    {0}\r\n", lstEvents.SelectedItems[0].SubItems[10].Text);

                    string sContent = oSB.ToString();

                    ShowTextDocument oForm = new ShowTextDocument();
                    oForm.txtEntry.WordWrap = false;
                    oForm.Text = "Information";
                    oForm.txtEntry.Text = sContent;
                    oForm.ShowDialog();

                }
            }
        }

       //private class StreamingEventLine
       // {
          
       //     public String StreamingEventType = string.Empty;
       //     public String OnThread = string.Empty;
       //     public String TimeStamp = string.Empty;
       //     public String EventType = string.Empty;
       //     public String ParentFolderId = string.Empty;
       //     public String ParentFolderChangeKey = string.Empty;
       //     public String OldParentFolderId = string.Empty;
       //     public String OldParentFolderChangeKey = string.Empty;
       //     public String Item_ItemId = string.Empty;
       //     public String Item_ItemChangeKey = string.Empty;
       //     public String Item_OldItemId = string.Empty;
       //     public String Item_OldItemChangeKey = string.Empty;
       //     public String FolderEvent_FolderId = string.Empty;
       //     public String FolderEvent_FolderChangeKey = string.Empty;
       //     public String Folder_OldFolderId = string.Empty;
       //     public String Folder_OldFolderChangeKey = string.Empty;
       //     public String FolderEvent_UnreadCount = string.Empty;
                
       // }

    }

  
}
