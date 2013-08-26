using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Exchange.WebServices.Data;
using EWSEditor.Forms.Controls;
using EWSEditor.Logging;
using EWSEditor.Common;
 
namespace EWSEditor.Forms
{
    public partial class CalendarMonthView : Form
    {
        private ExchangeService CurrentService = null;
        private FolderId _SelectedFolder = null;
        private bool _IsInitializingCalendar = true;

        public CalendarMonthView()
        {
            InitializeComponent();
 
        }

        public CalendarMonthView(Form parent, ExchangeService oExchangeService, FolderId oFolderId) 
        {

            CurrentService = oExchangeService;

            _SelectedFolder = oFolderId;

            InitializeComponent();

            //mcSelect.ShowToday = true;
            //mcSelect.ShowTodayCircle = true;
            //mcSelect.MaxSelectionCount = 1;

 
            //// Set the default displayed meetings to todays.
            //DateTime oDateTime= new DateTime();
            //oDateTime = DateTime.Now;
            //DateTime oDateTimeStart = TimeHelper.StartTimeOfDate(oDateTime);
            //DateTime oDateTimeEnd =  TimeHelper.EndTimeOfDate(oDateTime);

  
            //_IsInitializingCalendar = true;
            //mcSelect.SelectionStart = oDateTimeStart;
            //mcSelect.SelectionEnd = oDateTimeEnd;
            //_IsInitializingCalendar = false;

            //ListViewItemHelper.LoadCalendarInstances(CurrentService, _SelectedFolder, 
            //        ref lvItems,
            //        mcSelect.SelectionStart, mcSelect.SelectionEnd);

             

        }


        private void CalendarMonthView_Load(object sender, EventArgs e)
        {
            mcSelect.ShowToday = true;
            mcSelect.ShowTodayCircle = true;
            mcSelect.MaxSelectionCount = 1;


            // Set the default displayed meetings to todays.
            DateTime oDateTime = new DateTime();
            oDateTime = DateTime.Now;
            DateTime oDateTimeStart = TimeHelper.StartTimeOfDate(oDateTime);
            DateTime oDateTimeEnd = TimeHelper.EndTimeOfDate(oDateTime);


            _IsInitializingCalendar = true;
            mcSelect.SelectionStart = oDateTimeStart;
            mcSelect.SelectionEnd = oDateTimeEnd;
            _IsInitializingCalendar = false;

            ListViewItemHelper.LoadCalendarInstances(CurrentService, _SelectedFolder,
                    ref lvItems,
                    mcSelect.SelectionStart, mcSelect.SelectionEnd);
 
        }

        private void ClearForm()
        {
 
 
 
        }

        private void InitializeCalendarViewForm()
        {
 

        }

 

        private void mcSelect_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (_IsInitializingCalendar == false)
                ListViewItemHelper.LoadCalendarInstances(CurrentService, _SelectedFolder, 
                            ref lvItems, 
                            e.Start, e.End);
        }

        private void lvItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvItems_DoubleClick(object sender, EventArgs e)
        {

            EditSelectedCalendarItem();
        }

        private void EditSelectedCalendarItem()
        {
            if (lvItems.SelectedItems.Count > 0)
            {
                ItemTag oItemTag = null;
                oItemTag = (ItemTag)lvItems.SelectedItems[0].Tag;
                //Item oSomeItem = Item.Bind(CurrentService, oItemTag.Id);
                Appointment oSomeAppointment = Appointment.Bind(CurrentService, oItemTag.Id);
                string sAppointmentType = oSomeAppointment.AppointmentType.ToString();
                if (sAppointmentType == "Single")
                {
                    CalendarForm oForm = new CalendarForm(CurrentService, oSomeAppointment.Id);
                    oForm.ShowDialog();
                    oForm = null;
                }
                else
                {
                    CalendarInstanceForm oForm = new CalendarInstanceForm(CurrentService, oSomeAppointment.Id);
                    oForm.ShowDialog();
                    oForm = null;
                }
 
                oItemTag = null;
            }
        }


        private void btnNew_Click(object sender, EventArgs e)
        {

            CalendarForm oForm = new CalendarForm(CurrentService, _SelectedFolder);
            oForm.ShowDialog();
            oForm = null;
 
        }
 

        private void cmsItems_Opening(object sender, CancelEventArgs e)
        {

        }

        private void cmsItemsViewMimeText_Click(object sender, EventArgs e)
        {
            ItemHelper.DisplaySelectedItemMIMEasText(CurrentService, lvItems);
        }

        private void cmsItemsViewMimeHexDump_Click(object sender, EventArgs e)
        {
            ItemHelper.DisplaySelectedItemMIMEasHexDump(CurrentService, lvItems);
        }

        private void cmsItemsProperties_Click(object sender, EventArgs e)
        {
            ItemHelper.DisplaySelectedItemProperties(CurrentService, lvItems);
        }

        private void cmsItemsAttachments_Click(object sender, EventArgs e)
        {
            ItemHelper.DisplaySelectedItemAttachments(CurrentService, ref lvItems);
        }

        private void cmsItemsEdit_Click(object sender, EventArgs e)
        {
            EditSelectedCalendarItem();
        }

        private void cmsItemsAdd_Click(object sender, EventArgs e)
        {
            ItemHelper.NewItemByFolderClass("IPF.Appointment", CurrentService, _SelectedFolder);
        }

        private void cmsItemsAttendeeStatus_Click(object sender, EventArgs e)
        {
            if (lvItems.SelectedItems.Count > 0)
            {
                string sInfo = string.Empty;
                ItemTag oItemTag = (ItemTag)this.lvItems.SelectedItems[0].Tag;

                oItemTag = (ItemTag)lvItems.SelectedItems[0].Tag;
                Appointment oAppointment = Appointment.Bind(CurrentService, oItemTag.Id);
                string s = AppointmentHelper.GetAttendeeStatusAsInfoString(oAppointment);

                ShowTextDocument oForm = new ShowTextDocument();
                oForm.Text = "Attendee Status";
                oForm.txtEntry.Text = s;
                oForm.ShowDialog();
                oForm = null;
 
            }
        }

 

        private void openMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvItems.SelectedItems.Count > 0)
            {
                ItemTag oItemTag = null;
                oItemTag = (ItemTag)lvItems.SelectedItems[0].Tag;
                Appointment oAppointment = Appointment.BindToRecurringMaster(CurrentService, oItemTag.Id);

                CalendarForm oForm = new CalendarForm(CurrentService, oAppointment.Id);
                oForm.ShowDialog();
                oForm = null;
                oItemTag = null;
            }
        }
 
            
    }
}
