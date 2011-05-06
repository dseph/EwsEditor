using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Exchange.WebServices.Data;

using EWSEditor.Common;
using EWSEditor.PropertyInformation;
using EWSEditor.Resources;

namespace EWSEditor.Forms
{
    public partial class FindAppointmentsDialog : DialogForm
    {
        private FolderId CurrentCalendar = null;
        private List<Appointment> AppointmentsFound = null;

        private FindAppointmentsDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Display the dialog and return the appropriate DialogResults.
        /// If the user doesn't click OK to close the dialog, return null.
        /// </summary>
        /// <param name="service">ServiceBinding used to make requests.</param>
        /// <param name="appointments">Output parameter</param>
        /// <returns>DialogResult</returns>
        public static DialogResult ShowDialog(ExchangeService service, ref List<ItemId> appointments)
        {
            FindAppointmentsDialog dialog = new FindAppointmentsDialog();
            dialog.CurrentService = service;

            dialog.txtStartTime.Text = DateTime.Now.ToString();
            dialog.txtEndTime.Text = DateTime.Now.ToString();

            DialogResult res = ((Form)dialog).ShowDialog();

            if (res == DialogResult.OK)
            {
                AppointmentsContentForm.Show(
                    string.Format(
                        "CalendarView from {0} to {1} in {2}.", 
                        dialog.txtStartTime.Text, 
                        dialog.txtEndTime.Text,
                        dialog.CurrentCalendar),
                    dialog.AppointmentsFound, 
                    dialog.CurrentService, 
                    dialog.ParentForm);
            }

            return res;
        }

        /// <summary>
        /// Perform the CalendarView search and set the return Appointment
        /// collection to be returned.
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // If no folder has been identified, warn the user
                if (this.CurrentCalendar == null)
                {
                    ErrorDialog.ShowWarning("No calendar folder selected.");
                    this.DialogResult = DialogResult.None;
                    return;
                }

                DateTime start = Convert.ToDateTime(txtStartTime.Text);
                DateTime end = Convert.ToDateTime(txtEndTime.Text);

                CalendarView view = new CalendarView(start, end, ConfigHelper.CalendarViewSize);
                view.PropertySet = new PropertySet(BasePropertySet.FirstClassProperties);

                FindItemsResults<Appointment> appts = this.CurrentService.FindAppointments(
                    this.CurrentCalendar, 
                    view);

                this.AppointmentsFound = new List<Appointment>();
                this.AppointmentsFound.AddRange(appts.Items);

                // Warn the user if more results are available that we are not displaying
                if (appts.MoreAvailable)
                {
                    ErrorDialog.ShowWarning(string.Format(DisplayStrings.WARN_CALENDARVIEW_LIMT, ConfigHelper.CalendarViewSize));
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Display the FolderIdDialog to get a FolderId for the
        /// calendar folder.
        /// </summary>
        private void btnFolderId_Click(object sender, EventArgs e)
        {
            ErrorDialog.ShowInfo("Create a FolderId for the Calendar you wish to search.");
            if (FolderIdDialog.ShowDialog(ref this.CurrentCalendar) == DialogResult.OK)
            {
                lblFolderId.Text = PropertyInterpretation.GetPropertyValue(this.CurrentCalendar);
            }
        }
    }
}
