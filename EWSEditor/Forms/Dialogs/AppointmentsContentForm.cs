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

    using EWSEditor.Common;
    using EWSEditor.PropertyInformation;

    using Microsoft.Exchange.WebServices.Data;

    public partial class AppointmentsContentForm : BaseContentForm
    {
        private const string ColNameStartTime = "colStartTime";
        private const string ColNameEndTime = "colEndTime";
        private const string ColNameSubject = "colSubject";
        private const string ColNameOrganizer = "colOrganizer";
        private const string ColNameReqAttendees = "colReqAttendees";
        private const string ColNameOptAttendees = "colOptAttendees";
        private const string ColNameResources = "colResources";
        private const string ColNameItemId = "colItemId";

        protected const string ColPidLidClientIntent = "colPidLidClientIntent";
        protected const string ColClientInfoString = "colClientInfoString";
        protected const string ColPidLidCleanGlobalObjectId = "colPidLidCleanGlobalObjectId";

        private List<Appointment> currentAppointments = null;

        private AppointmentsContentForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load the form with the appointments in the collection.
        /// </summary>
        /// <param name="caption">Text to append to the form title.</param>
        /// <param name="appointments">Appointments to display.</param>
        /// <param name="service">Current ExchangeService to use.</param>
        /// <param name="parentForm">Parent form that called this method.</param>
        public static void Show(
            string caption,
            List<Appointment> appointments,
            ExchangeService service,
            Form parentForm)
        {
            AppointmentsContentForm form = new AppointmentsContentForm();

            form.CurrentService = service;
            form.currentAppointments = appointments;
            form.PropertyDetailsGrid.CurrentService = service;
            form.Text = caption;
            form.CallingForm = parentForm;
            form.Show();
        }

        protected override void SetupForm()
        {
            this.ContentIdColumnName = ColNameItemId;
            this.DefaultDetailPropertySet = new PropertySet(BasePropertySet.FirstClassProperties);

            // Setup the this.ContentsGrid with columns for displaying item collections
            int col = 0;
            col = this.ContentsGrid.Columns.Add(ColNameStartTime, "Start Time");
            this.ContentsGrid.Columns[col].Width = 150;

            col = this.ContentsGrid.Columns.Add(ColNameEndTime, "End Time");
            this.ContentsGrid.Columns[col].Width = 150;

            col = this.ContentsGrid.Columns.Add(ColNameSubject, "Subject");
            this.ContentsGrid.Columns[col].Width = 150;

            col = this.ContentsGrid.Columns.Add(ColNameOrganizer, "Organizer");
            this.ContentsGrid.Columns[col].Width = 150;

            col = this.ContentsGrid.Columns.Add(ColNameReqAttendees, "RequiredAttendees");
            this.ContentsGrid.Columns[col].Width = 150;

            col = this.ContentsGrid.Columns.Add(ColNameOptAttendees, "OptionalAttendees");
            this.ContentsGrid.Columns[col].Width = 150;

            col = this.ContentsGrid.Columns.Add(ColNameResources, "Resources");
            this.ContentsGrid.Columns[col].Width = 150;

            col = this.ContentsGrid.Columns.Add(ColNameItemId, "Item Id");
            this.ContentsGrid.Columns[col].Visible = false;

            //col = this.ContentsGrid.Columns.Add(ColPidLidClientIntent, "PidLidClientIntent");
            //this.ContentsGrid.Columns[col].Visible = false;

            //col = this.ContentsGrid.Columns.Add(ColClientInfoString, "ClientInfoString");
            //this.ContentsGrid.Columns[col].Visible = false;

            //col = this.ContentsGrid.Columns.Add(ColPidLidCleanGlobalObjectId, "PidLidCleanGlobalObjectId");
            //this.ContentsGrid.Columns[col].Visible = false;
 
         

            base.SetupForm();
        }

        protected override void LoadContents()
        {
            // Add each Appointment to the ContentsGrid with no data binding
            foreach (Appointment appt in this.currentAppointments)
            {
                int row = this.ContentsGrid.Rows.Add();
                this.ContentsGrid.Rows[row].Cells[ColNameStartTime].Value = appt.Start.ToString();
                this.ContentsGrid.Rows[row].Cells[ColNameEndTime].Value = appt.End.ToString();
                this.ContentsGrid.Rows[row].Cells[ColNameSubject].Value = appt.Subject;

                this.ContentsGrid.Rows[row].Cells[ColNameOrganizer].Value =
                    PropertyInterpretation.GetPropertyValue(appt.Organizer);

                this.ContentsGrid.Rows[row].Cells[ColNameReqAttendees].Value =
                    PropertyInterpretation.GetPropertyValue(appt.RequiredAttendees);

                this.ContentsGrid.Rows[row].Cells[ColNameOptAttendees].Value =
                    PropertyInterpretation.GetPropertyValue(appt.OptionalAttendees);

                this.ContentsGrid.Rows[row].Cells[ColNameResources].Value =
                    PropertyInterpretation.GetPropertyValue(appt.Resources);

                //this.ContentsGrid.Rows[row].Cells[ColNameItemId].Value = appt.Id.UniqueId;

                //this.ContentsGrid.Rows[row].Cells[ColPidLidClientIntent].Value = PropertyInterpretation.GetPropertyValue(appt.Resources);

                //this.ContentsGrid.Rows[row].Cells[ColClientInfoString].Value = PropertyInterpretation.GetPropertyValue(appt.Resources);

                //this.ContentsGrid.Rows[row].Cells[ColPidLidCleanGlobalObjectId].Value = PropertyInterpretation.GetPropertyValue(appt.Resources);

 
            }

            base.LoadContents();
        }

        protected override void LoadSelectionDetails()
        {
            // If we can't get a content id string bail out
            if (GetSelectedContentId().Length == 0)
            {
                return;
            }

            ItemId apptId = new ItemId(GetSelectedContentId());
            
            // If no ItemId was created bail out
            if (apptId == null)
            {
                return;
            }

            Appointment appt = EWSEditor.Forms.FormsUtil.PerformRetryableItemBind(
                        this.CurrentService,
                        apptId,
                        this.CurrentDetailPropertySet) as Appointment;
            
            // If no appointment was retrieved bail out
            if (appt == null)
            {
                return;
            }

            this.PropertyDetailsGrid.LoadObject(appt);

            base.LoadSelectionDetails();
        }
    }
}
