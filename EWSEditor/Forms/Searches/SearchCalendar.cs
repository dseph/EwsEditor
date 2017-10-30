using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using EWSEditor.Common;
using EWSEditor.Forms.Controls;
using EWSEditor.PropertyInformation;

using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.Forms
{
    public partial class SearchCalendar : Form
    {
    
        private ExchangeService _CurrentService = null;
        private FolderId _SelectedFolder = null;

        public SearchCalendar()
        {
            InitializeComponent();
        }

        public SearchCalendar(Form parent, ExchangeService oExchangeService, FolderId oFolderId) 
        {

            _CurrentService = oExchangeService;

            _SelectedFolder = oFolderId;

            InitializeComponent();
 
 
        }

        private void SearchCalendar_Load(object sender, EventArgs e)
        {
 
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // If no folder has been identified, warn the user
            if (this._SelectedFolder == null)
            {
                ErrorDialog.ShowWarning("No calendar folder selected.");
                this.DialogResult = DialogResult.None;
                return;
            }


            DateTime start = Convert.ToDateTime(txtStartTime.Text);
            DateTime end = Convert.ToDateTime(txtEndTime.Text);


            //// TODO: Add more search capablities
            // http://msdn.microsoft.com/en-us/library/dd633700(v=exchg.80).aspx

            SearchFilter.
                
                
                searchFilter = new SearchFilter.SearchFilterCollection();
            searchFilter.Add(new SearchFilter.IsGreaterThanOrEqualTo(AppointmentSchema.Start, start));
            searchFilter.Add(new SearchFilter.IsGreaterThanOrEqualTo(AppointmentSchema.Start, end));
            if (this.chkSearchSubject.Checked == true)
                searchFilter.Add(new SearchFilter.ContainsSubstring(ItemSchema.Subject, txtSubject.Text));
            if (this.chkSearchToAttendee.Checked == true)
                searchFilter.Add(new SearchFilter.ContainsSubstring(ItemSchema.DisplayTo, this.txtToAttendee.Text));
            if (this.chkSearchCCAttendee.Checked == true)
                searchFilter.Add(new SearchFilter.ContainsSubstring(ItemSchema.DisplayCc, this.txtCCAttendee.Text));
            if (this.chkSearchBody.Checked == true)
                searchFilter.Add(new SearchFilter.ContainsSubstring(ItemSchema.Body, this.txtBody.Text));

            ItemView view = new ItemView(20);
            view.PropertySet = new PropertySet(BasePropertySet.IdOnly, AppointmentSchema.Subject, AppointmentSchema.Start, AppointmentSchema.AppointmentType);
            _CurrentService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID. 
            FindItemsResults<Item> findResults = _CurrentService.FindItems(WellKnownFolderName.Calendar, searchFilter, view);

            foreach (Item item in findResults.Items)
            {
                Appointment appt = item as Appointment;
                if (appt.AppointmentType == AppointmentType.RecurringMaster)
                {
                    // Calendar item is a recurring master item for a recurring series.
                }
                if (appt.AppointmentType == AppointmentType.Occurrence)
                {
                    // Calendar item is an occurrence in a recurring series.
                }
                else if (appt.AppointmentType == AppointmentType.Exception)
                {
                    // Calendar item is an exception in a recurring series.
                }

            }
 

        }

        private void btnFolderId_Click(object sender, EventArgs e)
        {
            FolderIdDialog oForm = new FolderIdDialog(_CurrentService);
            oForm.ShowDialog();
            if (oForm.ChoseOK == true)
                lblFolderId.Text = PropertyInterpretation.GetPropertyValue(oForm.ChosenFolderId); 

            //if (FolderIdDialog.ShowDialog(ref this._SelectedFolder) == DialogResult.OK)
            //{
            //    lblFolderId.Text = PropertyInterpretation.GetPropertyValue(this._SelectedFolder);
            //}
        }
    }
}
