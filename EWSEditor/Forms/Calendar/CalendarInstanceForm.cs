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
using EWSEditor.Forms.Dialogs;

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
            this.chkSetDurationStartTimezone.Checked = false;
            this.chkSetDurationEndTimezone.Checked = false;

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
 //               AppointmentSchema.ConversationId,
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
  //              AppointmentSchema.IsAssociated,
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
            _ExchangeService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID. 
            Appointment oAppointment = Appointment.Bind(_ExchangeService, oItemId) as Appointment;
            oAppointment.Service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID. 
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

            ComboBoxHelper.AddEnumsToComboBox(ref cmboLegacyFreeBusyStatus, typeof(LegacyFreeBusyStatus));
            cmboLegacyFreeBusyStatus.Text = "OOF";
             

            ComboBoxHelper.AddEnumsToComboBox(ref cmboImportance, typeof(Importance));
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
            {
                chkSetDurationStartTimezone.Checked = false;
                oAppointment.StartTimeZone = TimeZoneInfo.Local;
            }
            else
            {
                chkSetDurationStartTimezone.Checked = true;
            }

            this.cmboDurationStartTimezone.Text = TimeHelper.GetTimezoneStringForCombobox(oAppointment.StartTimeZone);

            if (_ExchangeService.ServerInfo.VersionString.CompareTo("Exchange2010") >= 0)
            {   // 2010 and above
                if (oAppointment.EndTimeZone == null)  // could it ever be not null and be OK???
                {
                    chkSetDurationEndTimezone.Checked = false;
                    oAppointment.EndTimeZone = TimeZoneInfo.Local;

                }
                else
                {
                    chkSetDurationEndTimezone.Checked = true;
                }

                this.cmboDurationEndTimezone.Text = TimeHelper.GetTimezoneStringForCombobox(oAppointment.EndTimeZone);
                this.chkSetDurationEndTimezone.Visible = true;
                this.cmboDurationEndTimezone.Visible = true;
                this.lblDurationEndTimezone.Visible = true;
            }
            else
            {
                this.chkSetDurationEndTimezone.Visible = false;
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
                txtICalRecurrenceId.Text = _Appointment.ICalRecurrenceId.Value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.ffZ");
            else
                txtICalRecurrenceId.Text = "";
            txtICalUid.Text = _Appointment.ICalUid;
            txtItemId.Text = _Appointment.Id.UniqueId;
            txtChangeKey.Text = _Appointment.Id.ChangeKey;
            //txtConversationId.Text = _Appointment.ConversationId.ToString();

            SetButtonState();

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
                10,
                dtDurationStartTime.Value.Minute,
                dtDurationStartTime.Value.Second);

            

            //dtDurationEndDate.Value.Hour = 10;

            DateTime oEndTime = new DateTime(
                dtDurationEndDate.Value.Year,
                dtDurationEndDate.Value.Month,
                dtDurationEndDate.Value.Day,
                10,
                dtDurationEndDate.Value.Minute,
                dtDurationEndDate.Value.Second);
            _Appointment.Start = oStartTime;
            _Appointment.End = oEndTime;

            if (this.chkSetDurationStartTimezone.Checked == true)
            {
                _Appointment.StartTimeZone = TimeHelper.GetTzIdFromTimeZoneStringUsedByComboBoxes(this.cmboDurationStartTimezone.Text);
            }

            if (this.chkSetDurationEndTimezone.Checked == true)
            {
                if (_ExchangeService.ServerInfo.VersionString.CompareTo("Exchange2010") >= 0)
                {
                    _Appointment.EndTimeZone = TimeHelper.GetTzIdFromTimeZoneStringUsedByComboBoxes(this.cmboDurationEndTimezone.Text);
                }
            }
            
            _Appointment.Body.Text = txtBody.Text;
            _Appointment.IsAllDayEvent = chkIsAllDayEvent.Checked;
             
 
            _Appointment.LegacyFreeBusyStatus = (LegacyFreeBusyStatus)Enum.Parse(typeof(LegacyFreeBusyStatus), cmboLegacyFreeBusyStatus.Text.Trim());
      
            _Appointment.Importance = (Importance)Enum.Parse(typeof(Importance), cmboImportance.Text.Trim());

      
             
            RecipeintHelper.SetAppointmentRecipientsFromString(ref _Appointment, "Required", txtRequiredAttendees.Text.Trim());
            RecipeintHelper.SetAppointmentRecipientsFromString(ref _Appointment, "Optional", txtOptionalAttendees.Text.Trim());
            RecipeintHelper.SetAppointmentRecipientsFromString(ref _Appointment, "Resource", txtResourceAttendees.Text.Trim());



        }

        private void SetButtonState()
        {

            if (_IsExistingAppointment == true)
            {
                btnDelete.Enabled = _IsExistingAppointment;
                btnForward.Visible = _IsExistingAppointment;
                txtForwardTo.Visible = _IsExistingAppointment;
                lblForwardTo.Visible = _IsExistingAppointment;

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
                        _Appointment.Service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID. 
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
                            _Appointment.Service.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID. 
                            _Appointment.Update(ConflictResolutionMode.AlwaysOverwrite, oForm.SelectedSendInvitationsOrCancellationsMode);
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
                //DialogResult oDlg = MessageBox.Show("Save?", "Item needs to be saved before working with attachments.", MessageBoxButtons.OKCancel);
                //if (oDlg == System.Windows.Forms.DialogResult.OK)
                //{
                    Item oItem = (Item)_Appointment;
                    AddRemoveAttachments oAddRemoveAttachments = new AddRemoveAttachments(ref oItem, _IsExistingAppointment);
                    oAddRemoveAttachments.ShowDialog();
                    if (oAddRemoveAttachments.IsDirty == true)
                        _isDirty = true;
                //}
            }
        }

        private void chkSetDurationStartTimezone_CheckedChanged(object sender, EventArgs e)
        {
            cmboDurationStartTimezone.Enabled = chkSetDurationStartTimezone.Checked;
        }

        private void chkSetDurationEndTimezone_CheckedChanged(object sender, EventArgs e)
        {
            cmboDurationEndTimezone.Enabled = chkSetDurationEndTimezone.Checked;
        }

        private void btnEditInLargerWindow_Click(object sender, EventArgs e)
        {
            EditContents oDialog = new EditContents(txtBody.Text);

            oDialog.ShowDialog();
            if (oDialog.UserChoseOK == true)
                txtBody.Text = oDialog.NewBody;
            oDialog = null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Item oItem = (Item)_Appointment;

            oItem.Delete(DeleteMode.MoveToDeletedItems); 
            _WasDeleted = true;
            this.Close();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            //https://learn.microsoft.com/en-us/previous-versions/office/developer/exchange-server-2010/dd633652(v=exchg.80)

 

            // Specify the recipient e-mail addresses and forward the meeting request message to the recipients with customized message body text. 
            EmailAddress[] fwdAddresses = new EmailAddress[1];
            fwdAddresses[0] = new EmailAddress(txtForwardTo.Text.Trim());

            _Appointment.Forward("Forwarded message.", fwdAddresses);

            this.Close();
        }
    }
}
