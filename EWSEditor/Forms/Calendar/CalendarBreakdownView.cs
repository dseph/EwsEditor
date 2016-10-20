using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
 
using System.Collections;
using System.Collections.ObjectModel;

using Microsoft.Exchange.WebServices.Data;
using EWSEditor.Forms;
using EWSEditor.Forms.Controls;
using EWSEditor.Logging;
using EWSEditor.Common;
using EWSEditor.Forms.Dialogs;

namespace EWSEditor.Forms // .Calendar
{
    public partial class CalendarBreakdownView : Form
    {
        private ExchangeService _ExchangeService = null;
        //private Appointment _Appointment = null;
        private FolderId _FolderId = null;



        PropertySet BasicCalProps = new PropertySet(BasePropertySet.IdOnly,
                            AppointmentSchema.ParentFolderId,
                            AppointmentSchema.AppointmentType,
                            AppointmentSchema.Subject,
                            AppointmentSchema.Start,
                            AppointmentSchema.End,
                            AppointmentSchema.ItemClass,
                            AppointmentSchema.ICalUid,
                            AppointmentSchema.IsRecurring,
                            AppointmentSchema.Size,
                            AppointmentSchema.Duration,
                            AppointmentSchema.Recurrence 
                             
                            );

        PropertySet RecurrCalProps = new PropertySet(BasePropertySet.IdOnly,
                    AppointmentSchema.ParentFolderId,
                    AppointmentSchema.AppointmentType,
                    AppointmentSchema.Subject,
                    AppointmentSchema.Start,
                    AppointmentSchema.End,
                    AppointmentSchema.ItemClass,
                    AppointmentSchema.ICalUid,
                    AppointmentSchema.IsRecurring,
                    AppointmentSchema.Size,
                    AppointmentSchema.Duration,
                    AppointmentSchema.Recurrence,
                    AppointmentSchema.FirstOccurrence,
                    AppointmentSchema.LastOccurrence,
                    AppointmentSchema.ModifiedOccurrences,
                    AppointmentSchema.DeletedOccurrences
                    );

        //PropertySet props = new PropertySet(AppointmentSchema.AppointmentType,
        //                            AppointmentSchema.Subject,
        //                            AppointmentSchema.Start,
        //                            AppointmentSchema.End,
        //                            AppointmentSchema.ItemClass,
        //                            AppointmentSchema.ICalUid,
        //                            AppointmentSchema.FirstOccurrence,
        //                            AppointmentSchema.LastOccurrence,
        //                            AppointmentSchema.ModifiedOccurrences,
        //                            AppointmentSchema.DeletedOccurrences);

 // https://msdn.microsoft.com/en-us/library/office/dn643672(v=exchg.150).aspx

 


        public CalendarBreakdownView()
        {
            InitializeComponent();
        }

        public CalendarBreakdownView(ExchangeService oExchangeService, FolderId oFolderId)
        {
            InitializeComponent();

            _ExchangeService = oExchangeService;
            _FolderId = oFolderId;
        }

        private void CalendarBreakdownView_Load(object sender, EventArgs e)
        {
            PopulateTreeBase(_ExchangeService, _FolderId);

        }

        public bool PopulateTreeBase(ExchangeService service, FolderId oFolder) 
        {
            Collection<Appointment> foundAppointments = new Collection<Appointment>();

            // Create a search filter based on the start search date.
            SearchFilter.SearchFilterCollection searchFilter = new SearchFilter.SearchFilterCollection();
            //searchFilter.Add(new SearchFilter.IsGreaterThanOrEqualTo(AppointmentSchema.Start, startSearchDate));

            // Create an item view to specify which properties to return.
            ItemView view = new ItemView(10000);
            //view.PropertySet = new PropertySet(BasePropertySet.IdOnly,
            //                                    AppointmentSchema.Subject,
            //                                    AppointmentSchema.Start,
            //                                    AppointmentSchema.End,
            //                                    AppointmentSchema.AppointmentType,
            //                                    AppointmentSchema.IsRecurring,
            //                                    AppointmentSchema.Size 
            //                                   );

            // Get the appointment items from the server with the properties we specified.
            FindItemsResults<Item> findResults = service.FindItems(oFolder, view);

            TreeNode oParentNode = null;
            TreeNode oNode = null;

            try
            {
                // Add each of the appointments of the type you want to the collection.
                foreach (Item item in findResults.Items)
                {
                    Appointment appt = item as Appointment;
 
                    if (appt.AppointmentType == AppointmentType.Single)
                    {
                        oParentNode = tvItems.Nodes.Add("Single: " + appt.Subject + " (" + appt.Start.ToString());
                        oParentNode.Tag = appt.Id.UniqueId;
                    }

                    if (appt.AppointmentType == AppointmentType.RecurringMaster)
                    {

                        try
                        {
 
                            Appointment recurrMaster = Appointment.Bind(service, item.Id, BasicCalProps);
                            recurrMaster.Load(RecurrCalProps);

                            //try  // debug test
                            //{
                            //    if (recurrMaster.Recurrence == null)
                            //        MessageBox.Show("Null Recurrence: " + recurrMaster.Subject);
                            //}
                            //catch (Exception ex)
                            //{
                            //    MessageBox.Show("Error: " + ex.ToString());
                            //}

                            //if (appt.Recurrence!= null)
                            //{
                            string sStart = recurrMaster.FirstOccurrence.ToString();
                            string sEnd = recurrMaster.LastOccurrence.ToString();

                            string sInfo = string.Empty; //= "Recurring Master: " + recurrMaster.Subject + "(" + recurrMaster.Recurrence.StartDate.ToString() + " - ";
                            sInfo = "Recurring Master: " + recurrMaster.Subject + "(" + sStart + " - " + sEnd + ")";

                            if (recurrMaster.Recurrence.NumberOfOccurrences == null && recurrMaster.Recurrence.EndDate == null)
                                sInfo += "  Warning - This pattern has no end.";



                            //if (recurrMaster.Recurrence.NumberOfOccurrences != null)
                            //    sInfo += "  This has a fixed number of " + recurrMaster.Recurrence.NumberOfOccurrences.ToString() + " instances.";

                            oParentNode = tvItems.Nodes.Add(sInfo);
                            //}
                            //else
                            //    oParentNode = tvItems.Nodes.Add("Recurring Master: " + recurrMaster.Subject + " - NOTE: This has no recurrence pattern.");

                            oParentNode.Tag = recurrMaster.Id.UniqueId;
                            oNode = oParentNode.Nodes.Add("Occurences");
                            oNode.Tag = recurrMaster.Id.UniqueId;
                            oNode = oParentNode.Nodes.Add("Exceptions");
                            oNode.Tag = recurrMaster.Id.UniqueId;

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.ToString());
                            return false;
                        }

                    }
         
 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
 
            }

            return true;
     
        }

        private void tvItems_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string sId = (string)tvItems.SelectedNode.Tag;

            ItemId oItemId = new ItemId(sId);
            //oItemId.UniqueId = sId;

            if (sId.Length != 0)
            {  // Recurring
                if (tvItems.SelectedNode.Text.StartsWith("Single"))
                {
                    PopulateLV(_ExchangeService, oItemId, AppointmentType.Single);
                }

                if (tvItems.SelectedNode.Text.StartsWith("Recurring Master"))
                {
                    PopulateLV(_ExchangeService, oItemId, AppointmentType.Single);
                }

                if (tvItems.SelectedNode.Text.StartsWith("Occurences"))
                {
                    PopulateLV(_ExchangeService, oItemId, AppointmentType.Occurrence);
                }

                if (tvItems.SelectedNode.Text.StartsWith("Exceptions"))
                {
                    PopulateLV(_ExchangeService, oItemId, AppointmentType.Exception);
                }

            }

        }

        private void ResetListView() 
        {
            lvItems.Clear();
            lvItems.View = View.Details;
            lvItems.GridLines = true;
            lvItems.Dock = DockStyle.Fill;

            lvItems.Columns.Add("UniqueId", 200, HorizontalAlignment.Left);
            lvItems.Columns.Add("ItemClass", 200, HorizontalAlignment.Left);
            lvItems.Columns.Add("AppointmentType", 100, HorizontalAlignment.Left);
            lvItems.Columns.Add("Subject", 250, HorizontalAlignment.Left);
            lvItems.Columns.Add("Start", 150, HorizontalAlignment.Left);
            lvItems.Columns.Add("End", 150, HorizontalAlignment.Left);
            //oListView.Columns.Add("ICalUid", 50, HorizontalAlignment.Left);
            //lvItems.Columns.Add("UniqueId", 250, HorizontalAlignment.Left);
        }


        private bool PopulateLV(ExchangeService service, ItemId oItemId, AppointmentType oType)
        {

            ResetListView();

            bool bRet = true;

            Appointment calendarItem = Appointment.Bind(service, oItemId, new PropertySet(BasicCalProps)); //new PropertySet(AppointmentSchema.AppointmentType));  
            Appointment recurrMaster = null;
 
 
            ListViewItem oListItem = null;

            if (oType == AppointmentType.Single )
            {
                try
                {
                    //recurrMaster = Appointment.Bind(service, oItemId, BasicCalProps);
                    oListItem = new ListViewItem(calendarItem.Id.UniqueId, 0);
                    oListItem.SubItems.Add(calendarItem.ItemClass);
                    oListItem.SubItems.Add(calendarItem.AppointmentType.ToString());
                    oListItem.SubItems.Add(calendarItem.Subject);
                    oListItem.SubItems.Add(calendarItem.Start.ToString());
                    oListItem.SubItems.Add(calendarItem.End.ToString());

                    oListItem.Tag = oItemId;
                    lvItems.Items.AddRange(new ListViewItem[] { oListItem });
                    oListItem = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Item: " + calendarItem.Id.UniqueId + ex.ToString() + "\r\n\r\n", "Error adding item to listview.");
                    bRet = false;
                }
            }

            if (oType == AppointmentType.RecurringMaster)
            {
                try
                { 
                    recurrMaster = Appointment.Bind(service, oItemId, BasicCalProps);
                    recurrMaster.Load(RecurrCalProps);

                    //recurrMaster = Appointment.Bind(service, oItemId, BasicCalProps);
                    oListItem = new ListViewItem(recurrMaster.Id.UniqueId, 0);
                    oListItem.SubItems.Add(recurrMaster.ItemClass);
                    oListItem.SubItems.Add(recurrMaster.AppointmentType.ToString());
                    oListItem.SubItems.Add(recurrMaster.Subject);
                    oListItem.SubItems.Add(recurrMaster.Start.ToString());
                    oListItem.SubItems.Add(recurrMaster.End.ToString());

                    oListItem.Tag = oItemId;
                    lvItems.Items.AddRange(new ListViewItem[] { oListItem });
                    oListItem = null;

                }          
                catch (Exception ex)
                {
                    MessageBox.Show("Item: " + calendarItem.Id.UniqueId + ex.ToString() + "\r\n\r\n", "Error adding item to listview.");
                    bRet = false;
                }
            }

            // http://stackoverflow.com/questions/24143970/ews-getting-all-occurences-from-a-master-recurrence-appointment
            if (oType == AppointmentType.Occurrence)
            {
                //recurrMaster = Appointment.Bind(service, oItemId, BasicCalProps);
                recurrMaster = Appointment.Bind(service, oItemId, BasicCalProps);
                recurrMaster.Load(RecurrCalProps);

                try
                { 
                    PopulateLVRelatedOccurrences(service, recurrMaster);
                }          
                catch (Exception ex)
                {
                    MessageBox.Show("Item: " + calendarItem.Id.UniqueId + ex.ToString() + "\r\n\r\n", "Error adding item to listview.");
                    bRet = false;
                }
 
            }

            if (oType == AppointmentType.Exception)
            {
                //recurrMaster = Appointment.Bind(service, oItemId, BasicCalProps);
                recurrMaster = Appointment.Bind(service, oItemId, BasicCalProps);
                recurrMaster.Load(RecurrCalProps);

                try
                {
                    PopulateLVRelatedExceptions(service, recurrMaster);
                }          
                catch (Exception ex)
                {
                    MessageBox.Show("Item: " + calendarItem.Id.UniqueId + ex.ToString() + "\r\n\r\n", "Error adding item to listview.");
                    bRet = false;
                }
                
            }

            return bRet;
 
        }

        public void PopulateLVRelatedOccurrences(ExchangeService service, 
                                                Appointment recurrMaster
                                                )
        {

            Collection<Appointment> foundAppointments = new Collection<Appointment>();
            //DateTime oEnd = null;
            //DateTime oStart = recurrMaster.Recurrence.StartDate;
            //if (recurrMaster.Recurrence.EndDate != null)
            //    oEnd =  recurrMaster.Recurrence.EndDate;
    
            //
                    //            string sInfo = "Recurring Master: " + appt.Subject + "(" + appt.Recurrence.StartDate.ToString()  + " - " ;
                    //if (appt.Recurrence.NumberOfOccurrences == null  && appt.Recurrence.EndDate == null)
                    //    sInfo += "Warning - This pattern has no end.";
                    //if (appt.Recurrence.NumberOfOccurrences !=  null)
                    //    sInfo += "This has a fixed number of " + appt.Recurrence.NumberOfOccurrences.ToString() + " instances.";
            //
            CalendarView calView = new CalendarView(recurrMaster.Start, recurrMaster.End);
            calView.PropertySet = BasicCalProps;

            FindItemsResults<Appointment> findResults = service.FindAppointments(recurrMaster.ParentFolderId, calView);

            ListViewItem oListItem = null;
            Appointment oAppt = null;

            // Add all calendar items in your view that are occurrences or exceptions to your collection.
            foreach (Appointment appt in findResults.Items)
            {
                if (appt.AppointmentType == AppointmentType.Occurrence)
                {
                    oAppt = Appointment.Bind(service, appt.Id, BasicCalProps);
                    oListItem = new ListViewItem(oAppt.Id.UniqueId, 0);
                    oListItem.SubItems.Add(oAppt.ItemClass);
                    oListItem.SubItems.Add(oAppt.AppointmentType.ToString());
                    oListItem.SubItems.Add(oAppt.Subject);
                    oListItem.SubItems.Add(oAppt.Start.ToString());
                    oListItem.SubItems.Add(oAppt.End.ToString());

                    oListItem.Tag = oAppt.Id.UniqueId;
                    lvItems.Items.AddRange(new ListViewItem[] { oListItem });
                    oListItem = null;
                }
            }

        }

        public void PopulateLVRelatedExceptions(ExchangeService service,
                                        Appointment recurrMaster
                                        )
        {

            Collection<Appointment> foundAppointments = new Collection<Appointment>();
            CalendarView calView = new CalendarView(recurrMaster.Start, recurrMaster.End);
            calView.PropertySet = BasicCalProps;

            FindItemsResults<Appointment> findResults = service.FindAppointments(recurrMaster.ParentFolderId, calView);

            ListViewItem oListItem = null;
            Appointment oAppt = null;

            // Add all calendar items in your view that are occurrences or exceptions to your collection.
            foreach (Appointment appt in findResults.Items)
            {
                if (appt.AppointmentType == AppointmentType.Exception)
                {
                    oAppt = Appointment.Bind(service, appt.Id, BasicCalProps);
                    oListItem = new ListViewItem(oAppt.Id.UniqueId, 0);
                    oListItem.SubItems.Add(oAppt.ItemClass);
                    oListItem.SubItems.Add(oAppt.AppointmentType.ToString());
                    oListItem.SubItems.Add(oAppt.Subject);
                    oListItem.SubItems.Add(oAppt.Start.ToString());
                    oListItem.SubItems.Add(oAppt.End.ToString());

                    oListItem.Tag = oAppt.Id.UniqueId;
                    lvItems.Items.AddRange(new ListViewItem[] { oListItem });
                    oListItem = null;
                }
            }

        }

        //public void FindRecurringCalendarRelatedItems(ExchangeService service,
        //                                Appointment recurrMaster,
        //                                ref  Collection<Appointment> ApptOccurrences,
        //                                ref  Collection<Appointment> ApptExceptions
        //                                )
        //{

        //    Collection<Appointment> foundAppointments = new Collection<Appointment>();
        //    CalendarView calView = new CalendarView(recurrMaster.Start, recurrMaster.End);
        //    calView.PropertySet = BasicCalProps;
        //    FindItemsResults<Appointment> findResults = service.FindAppointments(recurrMaster.ParentFolderId, calView);

        //    // Add all calendar items in your view that are occurrences or exceptions to your collection.
        //    foreach (Appointment appt in findResults.Items)
        //    {
        //        if (appt.AppointmentType == AppointmentType.Occurrence || appt.AppointmentType == AppointmentType.Exception)
        //            ApptOccurrences.Add(appt);
        //        if (appt.AppointmentType == AppointmentType.Exception)
        //            ApptExceptions.Add(appt);
        //    }

        //}

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
