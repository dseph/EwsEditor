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
    public partial class CalendarInstanceForm : Form
    {
        private bool _IsExistingAppointment = false;
        private ExchangeService _ExchangeService = null;
        private Appointment _Appointment = null;
        private FolderId _FolderId = null;
        private bool _isDirty = false;
        public bool _WasDeleted { get; set; }
        public bool _WasSaved { get; set; }
        public bool _WasSent { get; set; }

        public CalendarInstanceForm()
        {
            InitializeComponent();
        }

        public CalendarInstanceForm(ExchangeService oExchangeService, FolderId oFolderId)
        {
            InitializeComponent();
            _ExchangeService = oExchangeService;
            _IsExistingAppointment = false;
            _FolderId = oFolderId;
            _Appointment = new Appointment(oExchangeService);
            ClearForm();
        }

        public CalendarInstanceForm(ExchangeService oExchangeService, ItemId oItemId)
        {
            InitializeComponent();
            _ExchangeService = oExchangeService;


            _Appointment = LoadAppointmentForEdit(oExchangeService, oItemId);
            _FolderId = _Appointment.ParentFolderId;
            _IsExistingAppointment = true;
            SetFormFromAppointment(_Appointment);
            _isDirty = false;
        }

        public CalendarInstanceForm(ExchangeService oExchangeService, ref Appointment oAppointment)
        {

        }

        private void CalendarInstanceForm_Load(object sender, EventArgs e)
        {
            // http://msdn.microsoft.com/en-us/library/dd633685(EXCHG.80).aspx
            string s = string.Empty;
            foreach (TimeZoneInfo tzinfo in TimeZoneInfo.GetSystemTimeZones())
            {
                s = tzinfo.DisplayName + " | " + tzinfo.Id + " | " + tzinfo.BaseUtcOffset.ToString();
                this.cmboDurationStartTimezone.Items.Add(s);
                this.cmboDurationEndTimezone.Items.Add(s);
            }
            s = TimeZoneInfo.Local.DisplayName + " | " + TimeZoneInfo.Local.Id + " | " + TimeZoneInfo.Local.BaseUtcOffset.ToString();
            this.cmboDurationStartTimezone.Text = s;  
            this.cmboDurationEndTimezone.Text = s;  

            _WasDeleted = false;
            _WasSaved = false;
            _WasSent = false;
        }

        private Appointment LoadAppointmentForEdit(ExchangeService oExchangeService, ItemId oItemId)
        {
            PropertySet oPropertySet = null;
            if (_ExchangeService.ServerInfo.VersionString.CompareTo("Exchange2010") >= 0)
            {   // 2010 and above
                oPropertySet = new PropertySet(BasePropertySet.IdOnly,
                AppointmentSchema.Subject,
                AppointmentSchema.Location,
                AppointmentSchema.Start,
                AppointmentSchema.End,
                AppointmentSchema.IsRecurring,
                AppointmentSchema.AppointmentType,
                AppointmentSchema.ItemClass,
                AppointmentSchema.Organizer,
                AppointmentSchema.Body,
                AppointmentSchema.IsAllDayEvent,
                AppointmentSchema.IsRecurring,
                AppointmentSchema.IsMeeting,
                AppointmentSchema.RequiredAttendees,
                AppointmentSchema.OptionalAttendees,
                AppointmentSchema.Resources,

                AppointmentSchema.HasAttachments,
                AppointmentSchema.Importance,

                AppointmentSchema.Attachments,
                AppointmentSchema.ConferenceType,
                AppointmentSchema.ConversationId,
                AppointmentSchema.AppointmentType,
                AppointmentSchema.AppointmentState,
                AppointmentSchema.AppointmentSequenceNumber,
                AppointmentSchema.Categories,

                AppointmentSchema.DateTimeCreated,
                AppointmentSchema.DateTimeReceived,
                AppointmentSchema.DateTimeSent,
                AppointmentSchema.ICalUid,
                AppointmentSchema.ICalRecurrenceId,
                AppointmentSchema.ICalDateTimeStamp,
                AppointmentSchema.IsMeeting,
                AppointmentSchema.IsDraft,
                AppointmentSchema.IsAssociated,
                AppointmentSchema.IsCancelled,
                AppointmentSchema.IsFromMe,
                AppointmentSchema.IsOnlineMeeting,
                AppointmentSchema.IsReminderSet,
                AppointmentSchema.IsResend,
                AppointmentSchema.IsResponseRequested,
                AppointmentSchema.IsSubmitted,
                AppointmentSchema.IsUnmodified,
                AppointmentSchema.ItemClass,
                AppointmentSchema.LastModifiedName,
                AppointmentSchema.LastModifiedTime,
                AppointmentSchema.LastOccurrence,
                AppointmentSchema.LegacyFreeBusyStatus,
                AppointmentSchema.MeetingRequestWasSent,
                AppointmentSchema.MeetingWorkspaceUrl,
                AppointmentSchema.MimeContent,
                AppointmentSchema.ModifiedOccurrences,
                AppointmentSchema.NetShowUrl,
                AppointmentSchema.OriginalStart,
                AppointmentSchema.ParentFolderId,
                AppointmentSchema.Recurrence,
                AppointmentSchema.ReminderDueBy,
                AppointmentSchema.ReminderMinutesBeforeStart,
                AppointmentSchema.Resources,
                AppointmentSchema.Sensitivity,
                AppointmentSchema.Size,
                AppointmentSchema.StartTimeZone,
                AppointmentSchema.TimeZone,
                AppointmentSchema.EndTimeZone
                 
                );
            }
            else
            {  // 2007 and 2007 sp1
                oPropertySet = new PropertySet(BasePropertySet.IdOnly,
                AppointmentSchema.Subject,
                AppointmentSchema.Location,
                AppointmentSchema.Start,
                AppointmentSchema.End,
                AppointmentSchema.IsRecurring,
                AppointmentSchema.AppointmentType,
                AppointmentSchema.ItemClass,
                AppointmentSchema.Organizer,
                AppointmentSchema.Body,
                AppointmentSchema.IsAllDayEvent,
                AppointmentSchema.IsRecurring,
                AppointmentSchema.IsMeeting,
                AppointmentSchema.RequiredAttendees,
                AppointmentSchema.OptionalAttendees,
                AppointmentSchema.Resources,

                AppointmentSchema.HasAttachments,
                AppointmentSchema.Importance,

                AppointmentSchema.Attachments,
                AppointmentSchema.ConferenceType,

                AppointmentSchema.AppointmentType,
                AppointmentSchema.AppointmentState,
                AppointmentSchema.AppointmentSequenceNumber,
                AppointmentSchema.Categories,

                AppointmentSchema.DateTimeCreated,
                AppointmentSchema.DateTimeReceived,
                AppointmentSchema.DateTimeSent,
                AppointmentSchema.ICalUid,
                AppointmentSchema.ICalRecurrenceId,
                AppointmentSchema.ICalDateTimeStamp,
                AppointmentSchema.IsMeeting,
                AppointmentSchema.IsDraft,

                AppointmentSchema.IsCancelled,
                AppointmentSchema.IsFromMe,
                AppointmentSchema.IsOnlineMeeting,
                AppointmentSchema.IsReminderSet,
                AppointmentSchema.IsResend,
                AppointmentSchema.IsResponseRequested,
                AppointmentSchema.IsSubmitted,
                AppointmentSchema.IsUnmodified,
                AppointmentSchema.ItemClass,
                AppointmentSchema.LastModifiedName,
                AppointmentSchema.LastModifiedTime,
                AppointmentSchema.LastOccurrence,
                AppointmentSchema.LegacyFreeBusyStatus,
                AppointmentSchema.MeetingRequestWasSent,
                AppointmentSchema.MeetingWorkspaceUrl,
                AppointmentSchema.MimeContent,
                AppointmentSchema.ModifiedOccurrences,
                AppointmentSchema.NetShowUrl,
                AppointmentSchema.OriginalStart,
                AppointmentSchema.ParentFolderId,
                AppointmentSchema.Recurrence,
                AppointmentSchema.ReminderDueBy,
                AppointmentSchema.ReminderMinutesBeforeStart,
                AppointmentSchema.Resources,
                AppointmentSchema.Sensitivity,
                AppointmentSchema.Size,
                AppointmentSchema.StartTimeZone,
                AppointmentSchema.TimeZone,
                AppointmentSchema.EndTimeZone
                );
            }
           
// // TO: Test - Start
//            Guid oGuid = new Guid("{6ED8DA90-450B-101B-98DA-00AA003F1305}");
//            ExtendedPropertyDefinition oExtendedPropertyDefinition =
//                new ExtendedPropertyDefinition(oGuid, 0x03, MapiPropertyType.Binary);
//            oPropertySet.Add(oExtendedPropertyDefinition);
//// TO: Test - End

            Appointment oAppointment = Appointment.Bind(_ExchangeService, oItemId) as Appointment;
             oAppointment.Load(oPropertySet);
//// TO: Test - Start
//            object value = null;
//            oAppointment.TryGetProperty(oExtendedPropertyDefinition, out value);
//// TO: Test - End

            return oAppointment;
        }

        private void ClearForm()
        {

             

            txtAppointmentType.Text = string.Empty;
            txtOrganizer.Text = string.Empty;
            txtSubject.Text = string.Empty;
            txtLocation.Text = string.Empty;

            DateTime oDateTime = DateTime.Now;
            this.dtDurationStartDate.Value = oDateTime;
            this.dtDurationStartTime.Value = oDateTime;
            this.dtDurationEndDate.Value = oDateTime.AddMinutes(30);
            this.dtDurationEndTime.Value = oDateTime.AddMinutes(30);

            //TimeHelper.InitDateTimeRangeCmboPickers(
            //    (
            //    ref this.dtDurationStartDate.Value,
            //    ref this.dtDurationStartTime.Value,
            //    ref this.dtDurationEndDate.Value,
            //    ref this.dtDurationEndTime.Value

            //    );
            
            //http://msdn.microsoft.com/en-us/library/dd633707(EXCHG.80).aspx
            this.cmboDurationStartTimezone.Text = TimeHelper.GetTimezoneStringForCombobox(TimeZoneInfo.Local);
            this.cmboDurationStartTimezone.Text = TimeHelper.GetTimezoneStringForCombobox(TimeZoneInfo.Local);
            //this.cmboTimezone.Text = TimeHelper.GetTimezoneStringForCombobox(TimeZoneInfo.Local);
            txtBody.Text = string.Empty;

            chkIsAllDayEvent.Checked = false;
            chkIsRecurring.Checked = false;

            cmboLegacyFreeBusyStatus.Text = "OOF";
            cmboImportance.Text = "Normal";

            cmboCategories.Text = "";

        }

        private bool SetFormFromAppointment(Appointment oAppointment)
        {
            bool bRet = false;
            ClearForm();
            txtAppointmentType.Text = oAppointment.AppointmentType.ToString();
            txtOrganizer.Text = oAppointment.Organizer.Name;
            txtSubject.Text = oAppointment.Subject;
            txtLocation.Text = oAppointment.Location;

            foreach (string sCategory in oAppointment.Categories)
            {
                cmboCategories.Items.Add(sCategory);
            }
             

            this.dtDurationStartDate.Value = oAppointment.Start;
            this.dtDurationStartTime.Value = oAppointment.Start;
            this.dtDurationEndDate.Value = oAppointment.End;
            this.dtDurationEndTime.Value = oAppointment.End;

            //this.cmboDurationStartTimezone.Text = TimeHelper.GetTimezoneStringForCombobox(oAppointment.StartTimeZone);
            //this.cmboDurationEndTimezone.Text = TimeHelper.GetTimezoneStringForCombobox(oAppointment.EndTimeZone);

            if (oAppointment.StartTimeZone == null)  // could it ever be not null and be OK???
                oAppointment.StartTimeZone = TimeZoneInfo.Local;
            this.cmboDurationStartTimezone.Text = TimeHelper.GetTimezoneStringForCombobox(oAppointment.StartTimeZone);

            if (_ExchangeService.ServerInfo.VersionString.CompareTo("Exchange2010") >= 0)
            {   // 2010 and above
                if (oAppointment.EndTimeZone == null)  // could it ever be not null and be OK???
                    oAppointment.EndTimeZone = TimeZoneInfo.Local;
                this.cmboDurationEndTimezone.Text = TimeHelper.GetTimezoneStringForCombobox(oAppointment.EndTimeZone);
                this.cmboDurationEndTimezone.Visible = true;
                this.lblDurationEndTimezone.Visible = true;
            }
            else
            {
                this.cmboDurationEndTimezone.Visible = false;
                this.lblDurationEndTimezone.Visible = false;
            }

            

          
            //this.cmboImportance.Text =   oAppointment.Importance;

            txtBody.Text = oAppointment.Body.Text;
            chkIsAllDayEvent.Checked = oAppointment.IsAllDayEvent;
            chkIsRecurring.Checked = oAppointment.IsRecurring;

            cmboLegacyFreeBusyStatus.Text = "OOF";
            cmboImportance.Text = "Normal";
 
            if (oAppointment.IsMeeting)
            {
                foreach (Attendee oAttendee in oAppointment.RequiredAttendees)
                {
                    this.txtRequiredAttendees.Text += oAttendee.Address + "; ";
                }

                foreach (Attendee oAttendee in oAppointment.OptionalAttendees)
                {
                    this.txtOptionalAttendees.Text += oAttendee.Address + "; ";
                }
                foreach (Attendee oAttendee in oAppointment.Resources)
                {
                    this.txtResourceAttendees.Text += oAttendee.Address + "; ";
                }
            }

            if (oAppointment.IsRecurring == true)
            {


                //oAppointment.Recurrence.StartDate;
                //oAppointment.Recurrence.EndDate;
                //oAppointment.Recurrence.HasEnd;
                //oAppointment.Recurrence.NumberOfOccurrences;

            }

            txtICalUid.Text = _Appointment.ICalUid;
            if (_Appointment.ICalRecurrenceId.HasValue)
                txtICalRecurrenceId.Text = _Appointment.ICalRecurrenceId.Value.ToString();
            else
                txtICalRecurrenceId.Text = "";
            txtICalUid.Text = _Appointment.ICalUid;
            txtItemId.Text = _Appointment.Id.UniqueId;
            txtChangeKey.Text = _Appointment.Id.ChangeKey;
            //txtConversationId.Text = _Appointment.ConversationId.ToString();

            return bRet;
        }

        private void SetAppointmentFromForm( )
        {
            //oAppointment.AppointmentType = txtAppointmentType.Text;
            //oAppointment.Organizer.Name = txtOrganizer.Text;
            _Appointment.Subject = txtSubject.Text;
            _Appointment.Location = txtLocation.Text;
            //_Appointment.Importance = cmboImportance.Text;

            DateTime oStartTime = new DateTime(
                dtDurationStartDate.Value.Year,
                dtDurationStartDate.Value.Month,
                dtDurationStartDate.Value.Day,
                dtDurationStartTime.Value.Hour,
                dtDurationStartTime.Value.Minute,
                dtDurationStartTime.Value.Second);

            DateTime oEndTime = new DateTime(
                dtDurationEndDate.Value.Year,
                dtDurationEndDate.Value.Month,
                dtDurationEndDate.Value.Day,
                dtDurationEndDate.Value.Hour,
                dtDurationEndDate.Value.Minute,
                dtDurationEndDate.Value.Second);
            _Appointment.Start = oStartTime;
            _Appointment.End = oEndTime;

            _Appointment.StartTimeZone = TimeHelper.GetTzIdFromTimeZoneStringUsedByComboBoxes(this.cmboDurationStartTimezone.Text);
            //_Appointment.EndTimeZone = TimeHelper.GetTzIdFromTimeZoneStringUsedByComboBoxes(this.cmboDurationEndTimezone.Text);

            if (_ExchangeService.ServerInfo.VersionString.CompareTo("Exchange2010") >= 0)
            {
                _Appointment.EndTimeZone = TimeHelper.GetTzIdFromTimeZoneStringUsedByComboBoxes(this.cmboDurationEndTimezone.Text);
                //_Appointment.EndTimeZone = TimeHelper.GetTzIdFromTimeZoneStringUsedByComboBoxes(this.cmboDurationEndTimezone.Text);
            }
            //this.cmboDurationStartTimezone.Text = oAppointment.StartTimeZone.DisplayName;
            //this.cmboDurationEndTimezone.Text = oAppointment.EndTimeZone.DisplayName;
            //this.cmboImportance.Text =   oAppointment.Importance.;

            _Appointment.Body.Text = txtBody.Text;
            _Appointment.IsAllDayEvent = chkIsAllDayEvent.Checked;

            //_Appointment.LegacyFreeBusyStatus = AppointmentHelper.GetFreeBusyStatus(cmboLegacyFreeBusyStatus.Text);
            _Appointment.LegacyFreeBusyStatus = (LegacyFreeBusyStatus)Enum.Parse(typeof(LegacyFreeBusyStatus), cmboLegacyFreeBusyStatus.Text.Trim());
            //_Appointment.Importance = AppointmentHelper.GetImportance(cmboImportance.Text);
            _Appointment.Importance = (Importance)Enum.Parse(typeof(Importance), cmboImportance.Text.Trim());

            //_Appointment.IsRecurring = chkIsRecurring.Checked ; 
             
            RecipeintHelper.SetAppointmentRecipientsFromString(ref _Appointment, "Required", txtRequiredAttendees.Text.Trim());
            RecipeintHelper.SetAppointmentRecipientsFromString(ref _Appointment, "Optional", txtOptionalAttendees.Text.Trim());
            RecipeintHelper.SetAppointmentRecipientsFromString(ref _Appointment, "Resource", txtResourceAttendees.Text.Trim());



        }

        private void SetButtonState()
        {

            if (_IsExistingAppointment == true)
            {
                btnDelete.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
            }

            if (_isDirty == true)
            {
                btnSend.Enabled = true;
                btnSave.Enabled = true;
            }
            else
            {
                btnSend.Enabled = true;
                btnSave.Enabled = true;
            }

        }

       

        private void txtRequiredAttendees_TextChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void txtOptionalAttendees_TextChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void txtSubject_TextChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void txtBody_TextChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void txtLocation_TextChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void dtDurationStartDate_ValueChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void dtDurationEndDate_ValueChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void dtDurationStartTime_ValueChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void dtDurationEndTime_ValueChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveSend(false) == true)
                this.Close();
        }

        private bool SaveSend(bool bSend)
        {
            bool bRet = false;

            SetAppointmentFromForm();
 
            if (_isDirty)
            {
                if (bSend == false)
                {
                    try
                    {
                        _Appointment.Update(ConflictResolutionMode.AutoResolve);
                        bRet = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error Saving");
                    }
                }
                else
                {
                    try
                    {
                        SelectSendMeetingNotificationOptions oForm = new SelectSendMeetingNotificationOptions();
                        oForm.ShowDialog();
                        if (oForm.ChoseOK == true)
                        {
                            _Appointment.Update(ConflictResolutionMode.AutoResolve, oForm.SelectedSendInvitationsOrCancellationsMode);
                            bRet = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }
                }
            }
 
 
            return bRet;

        }


         
        private bool CheckForm()
        {
            //int iTest = 0;
            bool bNoErrors = true;
            //bool result = false;

            if (this.txtSubject.Text.Trim().Length == 0)
            {
                MessageBox.Show("txtSubject Needs to be set", "Entry Error");
                bNoErrors = false;
            }

            if (this.txtLocation.Text.Trim().Length == 0)
            {
                MessageBox.Show("txtLocation Needs to be set", "Entry Error");
                bNoErrors = false;
            }

            if (this.txtBody.Text.Trim().Length == 0)
            {
                MessageBox.Show("txtBody Needs to be set", "Entry Error");
                bNoErrors = false;
            }

             

            return bNoErrors;
        }

        private void txtResourceAttendees_TextChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void cmboImportance_SelectedIndexChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void cmboDurationEndTimezone_SelectedIndexChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void cmboDurationStartTimezone_SelectedIndexChanged(object sender, EventArgs e)
        {
            _isDirty = true;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (SaveSend(true) == true)
                this.Close();
        }

        private void btnAttendeeStatus_Click(object sender, EventArgs e)
        {
            string s = AppointmentHelper.GetAttendeeStatusAsInfoString(_Appointment);

            ShowTextDocument oForm = new ShowTextDocument();
            oForm.Text = "Attendee Status";
            oForm.txtEntry.Text = s;
            oForm.ShowDialog();
            oForm = null;
        }

        private void grpSchedule_Enter(object sender, EventArgs e)
        {

        }

        private void btnAttachments_Click(object sender, EventArgs e)
        {
            if (_isDirty == true)
            {
                DialogResult oDlg = MessageBox.Show("Save?", "Item needs to be saved before working with attachments.", MessageBoxButtons.OKCancel);
                if (oDlg == System.Windows.Forms.DialogResult.OK)
                {
                    Item oItem = (Item)_Appointment;
                    AddRemoveAttachments oAddRemoveAttachments = new AddRemoveAttachments(ref oItem, _IsExistingAppointment);
                    oAddRemoveAttachments.ShowDialog();
                    if (oAddRemoveAttachments.IsDirty == true)
                        _isDirty = true;
                }
            }
        }

    }
}
