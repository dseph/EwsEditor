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
        private ExchangeService _CurrentService = null;
        private FolderId _SelectedFolder = null;
        private bool _IsInitializingCalendar = true;

        public CalendarMonthView()
        {
            InitializeComponent();
        }

        public CalendarMonthView(Form parent, ExchangeService oExchangeService, FolderId oFolderId) 
        {

            _CurrentService = oExchangeService;

            _SelectedFolder = oFolderId;

            InitializeComponent();
 
             

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

            ListViewItemHelper.LoadCalendarInstances(_CurrentService, _SelectedFolder,
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
                ListViewItemHelper.LoadCalendarInstances(_CurrentService, _SelectedFolder, 
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
                _CurrentService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID
                Appointment oSomeAppointment = Appointment.Bind(_CurrentService, oItemTag.Id);
                string sAppointmentType = oSomeAppointment.AppointmentType.ToString();
                if (sAppointmentType == "Single")
                {
                    CalendarForm oForm = new CalendarForm(_CurrentService, oSomeAppointment.Id);
                    oForm.ShowDialog();
                    oForm = null;
                }
                else
                {
                    CalendarInstanceForm oForm = new CalendarInstanceForm(_CurrentService, oSomeAppointment.Id);
                    oForm.ShowDialog();
                    oForm = null;
                }
 
                oItemTag = null;
            }
        }


        private void btnNew_Click(object sender, EventArgs e)
        {

            CalendarForm oForm = new CalendarForm(_CurrentService, _SelectedFolder);
            oForm.ShowDialog();
            oForm = null;
 
        }
 

        private void cmsItems_Opening(object sender, CancelEventArgs e)
        {

        }

        private void cmsItemsViewMimeText_Click(object sender, EventArgs e)
        {
            ItemHelper.DisplaySelectedItemMIMEasText(_CurrentService, lvItems);
        }

        private void cmsItemsViewMimeHexDump_Click(object sender, EventArgs e)
        {
            ItemHelper.DisplaySelectedItemMIMEasHexDump(_CurrentService, lvItems);
        }

        private void cmsItemsProperties_Click(object sender, EventArgs e)
        {
            ItemHelper.DisplaySelectedItemProperties(_CurrentService, lvItems);
        }

        private void cmsItemsAttachments_Click(object sender, EventArgs e)
        {
            ItemHelper.DisplaySelectedItemAttachments(_CurrentService, ref lvItems);
        }

        private void cmsItemsEdit_Click(object sender, EventArgs e)
        {
            EditSelectedCalendarItem();
        }

        private void cmsItemsAdd_Click(object sender, EventArgs e)
        {
            ItemHelper.NewItemByFolderClass("IPF.Appointment", _CurrentService, _SelectedFolder);
        }

        private void cmsItemsAttendeeStatus_Click(object sender, EventArgs e)
        {
            if (lvItems.SelectedItems.Count > 0)
            {
                string sInfo = string.Empty;
                ItemTag oItemTag = (ItemTag)this.lvItems.SelectedItems[0].Tag;

                oItemTag = (ItemTag)lvItems.SelectedItems[0].Tag;
                _CurrentService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID
                Appointment oAppointment = Appointment.Bind(_CurrentService, oItemTag.Id);
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

                if (lvItems.SelectedItems[0].SubItems[4].Text == "False")
                {
                    CalendarForm oForm = new CalendarForm(_CurrentService, oItemTag.Id);
                    oForm.ShowDialog();
                    oForm = null;
 
                }
                else
                {
 
                    Appointment oAppointment = Appointment.BindToRecurringMaster(_CurrentService, oItemTag.Id);

                    CalendarForm oForm = new CalendarForm(_CurrentService, oAppointment.Id);
                    oForm.ShowDialog();
                    oForm = null;
                     
                }

                oItemTag = null;
            }
        }

        private void openItemToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (lvItems.SelectedItems.Count > 0)
            {
                ItemTag oItemTag = null;
                oItemTag = (ItemTag)lvItems.SelectedItems[0].Tag;

                List<ItemId> item = new List<ItemId>();
                item.Add(oItemTag.Id);

                ItemsContentForm.Show(
                    "Displaying recurrence item",
                    item,
                    _CurrentService,
                    this);
            }
        }
 
            
    }
}
