using System;
using System.Collections.Generic;
using System.Windows.Forms;
using EWSEditor.Forms.Controls;
using EWSEditor.Logging;
using EWSEditor.PropertyInformation;
using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.Forms
{
    public partial class AvailabilityForm : CountedForm
    {
        private const string InitialAttendAvailGroupHeader = "Attendees and Availability";
        private const string NoSelectedAttendeeLabelText = "Select an attendee to display availability";
        private const string SelectedAttendeeLabelText = "Showing availability for {0}";
        private const string AvailViewGroupName = "AvailViewGroup";
        private const string CalEventsViewGroupName = "CalEventsViewGroup";

        private EnumComboBox<AvailabilityData> availDataCombo = new EnumComboBox<AvailabilityData>();
        private EnumComboBox<SuggestionQuality> minSuggestQualCombo = new EnumComboBox<SuggestionQuality>();
        private EnumComboBox<FreeBusyViewType> requestFBViewCombo = new EnumComboBox<FreeBusyViewType>();

        private AvailabilityForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Show AvailabilityForm which is used to excercise GetUserAvailability
        /// and display the output.
        /// </summary>
        /// <param name="service">ExchangeService used to make EWS calls</param>
        public static void Show(ExchangeService service)
        {
            if (service == null)
            {
                throw new InvalidOperationException("This forms requires an ExchangeService to make EWS calls, 'service' cannot be null.");
            }

            AvailabilityForm thisForm = new AvailabilityForm();
            thisForm.CurrentService = service;
            thisForm.Show();
        }

        private void AvailabilityDialog_Load(object sender, EventArgs e)
        {
            // Initialize ComboBoxes
            this.availDataCombo.TransformComboBox(this.TempAvailDataCombo);
            this.availDataCombo.SelectedItem = AvailabilityData.FreeBusy;

            this.minSuggestQualCombo.TransformComboBox(this.TempMinSuggestQualCombo);
            this.minSuggestQualCombo.SelectedItem = SuggestionQuality.Fair;

            this.requestFBViewCombo.TransformComboBox(this.TempRequestFBViewCombo);
            this.requestFBViewCombo.SelectedItem = FreeBusyViewType.Detailed;

            // Get the current time rounded to the next hour
            DateTime nowJustHours = DateTime.Now;
            nowJustHours = nowJustHours.AddMinutes((60 - nowJustHours.Minute));
            nowJustHours = nowJustHours.AddSeconds(-1 * nowJustHours.Second);

            // Use that time to seed the DateTime pickers
            this.StartWindowDate.Value = nowJustHours;
            this.EndWindowDate.Value = nowJustHours.AddDays(1);
            this.CurrentMeetingDate.Value = nowJustHours;
            this.StartDetailDate.Value = nowJustHours;
            this.EndDetailDate.Value = nowJustHours.AddDays(1);

            // Load availability option defaults
            this.MergeFBIntervalText.Text = "30";
            this.MeetingDurationText.Text = "60";
            this.MaxSuggestPerDayText.Text = "10";
            this.MaxNonWorkSuggestText.Text = "0";
            this.GoodSuggestThresholdText.Text = "25";

            // Initialize ListView grouping header
            //this.AttendeeAvailabilityGroup.Text = InitialAttendAvailGroupHeader;

            this.ClearAvailabilityResults();
        }

        private void CurrentMeetingTimeCheck_CheckedChanged(object sender, EventArgs e)
        {
            this.CurrentMeetingDate.Enabled = this.CurrentMeetingCheck.Checked;
            this.CurrentMeetingLabel.Enabled = this.CurrentMeetingCheck.Checked;
        }

        private void AttendeeList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (this.AttendeeList.SelectedItems.Count == 1)
            {
                AttendeeDataContainer? attendee = this.AttendeeList.SelectedItems[0].Tag as AttendeeDataContainer?;

                if (attendee.HasValue && attendee.Value.Info != null && !String.IsNullOrEmpty(attendee.Value.Info.SmtpAddress))
                {
                    this.DisplayAttendeeResults(attendee.Value);
                }
            }
        }

        private void GetAvailabilityButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // Get AttendeeInfo from AttendeeList
                List<AttendeeInfo> attendees = null;
                if (!this.TryGetAttendeesFromList(out attendees))
                {
                    ErrorDialog.ShowWarning("There must be at least one attendee listed to retrieve availability for.");
                    return;
                }

                // Get TimeWindow from input
                TimeWindow window = new TimeWindow(
                    this.StartWindowDate.Value.ToUniversalTime(),
                    this.EndWindowDate.Value.ToUniversalTime());

                // Get RequestedData from input
                AvailabilityData requestedData = AvailabilityData.FreeBusy;
                if (this.availDataCombo.SelectedItem.HasValue)
                {
                    requestedData = this.availDataCombo.SelectedItem.Value;
                }

                // Collect AvailabilityOptions from form input
                AvailabilityOptions options = new AvailabilityOptions();
                if (this.CurrentMeetingCheck.Checked)
                {
                    options.CurrentMeetingTime = this.CurrentMeetingDate.Value;
                }
                else
                {
                    options.CurrentMeetingTime = null;
                }

                options.MeetingDuration = Convert.ToInt32(this.MeetingDurationText.Text);
                options.DetailedSuggestionsWindow = new TimeWindow(
                    this.StartDetailDate.Value,
                    this.EndDetailDate.Value);
                options.GlobalObjectId = this.GlobalObjectIdText.Text;
                options.GoodSuggestionThreshold = Convert.ToInt32(this.GoodSuggestThresholdText.Text);
                options.MaximumNonWorkHoursSuggestionsPerDay = Convert.ToInt32(this.MaxNonWorkSuggestText.Text);
                options.MaximumSuggestionsPerDay = Convert.ToInt32(this.MaxSuggestPerDayText.Text);
                options.MergedFreeBusyInterval = Convert.ToInt32(this.MergeFBIntervalText.Text);

                if (this.minSuggestQualCombo.SelectedItem.HasValue)
                {
                    options.MinimumSuggestionQuality = this.minSuggestQualCombo.SelectedItem.Value;
                }

                if (this.requestFBViewCombo.SelectedItem.HasValue)
                {
                    options.RequestedFreeBusyView = this.requestFBViewCombo.SelectedItem.Value;
                }

                // Remember which attendee was selected in the AttendeeList
                int selectedIndex = -1;
                if (this.AttendeeList.SelectedItems != null &&
                    this.AttendeeList.SelectedItems.Count == 1)
                {
                    selectedIndex = this.AttendeeList.SelectedItems[0].Index;
                    this.AttendeeList.Items[selectedIndex].Selected = false;
                }

                // Make the EWS request
                GetUserAvailabilityResults results = this.CurrentService.GetUserAvailability(
                                                            attendees,
                                                            window,
                                                            requestedData,
                                                            options);

                // Enable result lists
                this.AttendeeAvailabilityList.Enabled = true;
                this.CalEventsList.Enabled = true;
                this.SuggestionsList.Enabled = true;
                
                // Attach AttendeeAvailability to the associated attendee in the ListView.
                // It can be assumed that the order of the AttendeesAvailability and Suggestions 
                // results arrays correspond to the order of the attendees.
                for (int i = 0; i < attendees.Count; i++)
                {
                    AttendeeAvailability availResult = null;
                    if (results.AttendeesAvailability != null &&
                        results.AttendeesAvailability[i] != null)
                    {
                        availResult = results.AttendeesAvailability[i];
                    }

                    this.AddResultsToAttendee(attendees[i], availResult);
                }

                if (results.Suggestions != null)
                {
                    // Display the Suggestion in the ListView
                    foreach (Suggestion suggest in results.Suggestions)
                    {
                        foreach (TimeSuggestion time in suggest.TimeSuggestions)
                        {
                            ListViewItem timeItem = this.SuggestionsList.Items.Add(suggest.Date.ToShortDateString());
                            timeItem.SubItems.Add(suggest.Quality.ToString());
                            timeItem.SubItems.Add(time.MeetingTime.ToShortTimeString());
                            timeItem.SubItems.Add(time.Quality.ToString());
                            timeItem.SubItems.Add(time.Conflicts.Count.ToString());
                            timeItem.SubItems.Add(time.IsWorkTime.ToString());
                        }
                    }
                }

                // Reset the selected Attendee and display the results or show a message
                // to inform the user how to display results.
                if (selectedIndex > -1)
                {
                    this.AttendeeList.Items[selectedIndex].Selected = true;
                }
                else
                {
                    //this.AttendeeAvailabilityGroup.Text = "Select an attendee in the list to display availability results.";
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddAttendeeButton_Click(object sender, EventArgs e)
        {
            AttendeeInfo info = null;
            if (AttendeeInfoDialog.ShowDialog(this.CurrentService, out info) == DialogResult.OK)
            {
                this.AddAttendeeToList(info);
            }
        }

        private void RemoveAttendeeButton_Click(object sender, EventArgs e)
        {
            if (this.AttendeeList.SelectedItems.Count == 1)
            {
                this.AttendeeList.SelectedItems[0].Remove();
                this.ClearAvailabilityResults();
            }
        }

        private bool TryGetAttendeesFromList(out List<AttendeeInfo> attendees)
        {
            // Initialize the output parameter to null
            attendees = null;

            try
            {
                if (this.AttendeeList.Items.Count == 0)
                {
                    DebugLog.WriteVerbose("false: No attendees in the AttendeeList");
                    return false;
                }

                // Return a list of AttendeeInfo based on the rows in the ListView
                foreach (ListViewItem item in this.AttendeeList.Items)
                {
                    AttendeeDataContainer? attendee = item.Tag as AttendeeDataContainer?;
                    if (attendee.HasValue)
                    {
                        // Initialize the output list if needed
                        if (attendees == null)
                        {
                            attendees = new List<AttendeeInfo>();
                        }

                        attendees.Add(attendee.Value.Info);
                    }
                }

                if (attendees == null ||
                    attendees.Count == 0)
                {
                    DebugLog.WriteVerbose("false: No attendees a AttendeeDataContainer found in the AttendeeList");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                DebugLog.WriteVerbose("Returning false due to exception", ex);
                return false;
            }
        }

        private void AddResultsToAttendee(AttendeeInfo attendee, AttendeeAvailability availability)
        {
            // Find the given attendee in the AttendeeList and add the
            // passed AttendeeAvailability and Suggestion so they can be
            // displayed when the attendee is selected.
            foreach (ListViewItem item in this.AttendeeList.Items)
            {
                AttendeeDataContainer? attendeeData = item.Tag as AttendeeDataContainer?;
                if (attendeeData.HasValue)
                {
                    // Match the attendees by SMTP address
                    AttendeeDataContainer data = attendeeData.Value;
                    if (String.Equals(attendee.SmtpAddress, data.Info.SmtpAddress, StringComparison.CurrentCultureIgnoreCase))
                    {
                        // If we found the attendee then set the values and break out
                        data.Availability = availability;
                        item.Tag = data;
                        return;
                    }
                }
            }

            DebugLog.WriteVerbose(string.Format("Leave: Attendee, {0}, not found in AttendeeList", attendee.SmtpAddress));
        }

        private void AddAttendeeToList(AttendeeInfo attendee)
        {
            if (attendee == null)
            {
                DebugLog.WriteVerbose("Leave: attendee is null");
                return;
            }

            if (String.IsNullOrEmpty(attendee.SmtpAddress))
            {
                DebugLog.WriteVerbose("Leave: Attendee's SMTP address is null or empty");
                return;
            }

            // Reset the availability results for all attendees and require
            // a new availability request since we have new attendee list
            this.ClearAvailabilityResults();

            // Load the visual elements of the row with attendee data
            ListViewItem row = this.AttendeeList.Items.Add(attendee.SmtpAddress);
            row.SubItems.Add(attendee.AttendeeType.ToString());
            row.SubItems.Add(attendee.ExcludeConflicts.ToString());
            
            // Store the original object in the tag for use later
            row.Tag = new AttendeeDataContainer(attendee);
        }

        private void DisplayAttendeeResults(AttendeeDataContainer attendeeData)
        {
            // Clear existing availability information
            this.AttendeeAvailabilityList.Items.Clear();
            this.CalEventsList.Items.Clear();

            // Display the given AttendeeAvailability in the ListView
            AttendeeAvailability availability = attendeeData.Availability;
            if (availability != null && availability.Result == ServiceResult.Success)
            {
                // Change the label text to indicate the selected attendee
                //this.AttendeeAvailabilityGroup.Text = string.Format(SelectedAttendeeLabelText, attendeeData.Info.SmtpAddress);

                ListViewItem availRow = this.AttendeeAvailabilityList.Items.Add(PropertyInterpretation.GetPropertyValue(availability.ViewType));
                availRow.SubItems.Add(PropertyInterpretation.GetPropertyValue(availability.WorkingHours));

                if (availability.MergedFreeBusyStatus.Count > 0)
                {
                    availRow.SubItems.Add(PropertyInterpretation.GetPropertyValue(availability.MergedFreeBusyStatus));
                }

                foreach (CalendarEvent calEvent in availability.CalendarEvents)
                {
                    ListViewItem calRow = this.CalEventsList.Items.Add(PropertyInterpretation.GetPropertyValue(calEvent.FreeBusyStatus));
                    calRow.SubItems.Add(PropertyInterpretation.GetPropertyValue(calEvent.StartTime));
                    calRow.SubItems.Add(PropertyInterpretation.GetPropertyValue(calEvent.EndTime));

                    if (calEvent.Details != null)
                    {
                        calRow.SubItems.Add(calEvent.Details.Subject);
                        calRow.SubItems.Add(calEvent.Details.Location);
                        calRow.SubItems.Add(calEvent.Details.IsException.ToString());
                        calRow.SubItems.Add(calEvent.Details.IsMeeting.ToString());
                        calRow.SubItems.Add(calEvent.Details.IsPrivate.ToString());
                        calRow.SubItems.Add(calEvent.Details.IsRecurring.ToString());
                        calRow.SubItems.Add(calEvent.Details.IsReminderSet.ToString());
                        calRow.SubItems.Add(calEvent.Details.StoreId);
                    }
                }
            }
            else if (availability != null && availability.Result == ServiceResult.Error)
            {
                ErrorDialog.ShowServiceResponseMsgBox(
                    availability,
                    String.Format("Availability request returned an error for attendee, {0}.", attendeeData.Info.SmtpAddress), 
                    string.Empty, 
                    MessageBoxIcon.Warning);
            }
            else if (availability != null)
            {
                throw new NotImplementedException(
                    string.Format(
                        "Unexpected ServiceResult, {0}, for AttendeeAvailability", 
                        availability.Result.ToString()));
            }
        }

        private void ClearAvailabilityResults()
        {
            // Clear results from all attendees in the AttendeeList
            foreach (ListViewItem item in this.AttendeeList.Items)
            {
                AttendeeDataContainer? attendeeData = item.Tag as AttendeeDataContainer?;
                if (attendeeData.HasValue)
                {
                    AttendeeDataContainer data = attendeeData.Value;
                    data.Availability = null;
                    item.Tag = data;
                }
            }

            // Clear all result lists
            this.AttendeeAvailabilityList.Items.Clear();
            this.CalEventsList.Items.Clear();
            this.SuggestionsList.Items.Clear();

            this.AttendeeAvailabilityList.Enabled = false;
            this.CalEventsList.Enabled = false;
            this.SuggestionsList.Enabled = false;

            // Indicate that there are availability results yet
            //this.AttendeeAvailabilityGroup.Text = String.Concat("Click the '", this.GetAvailabilityButton.Text, "' button to get availablity results.");
        }

        private struct AttendeeDataContainer
        {
            internal AttendeeInfo Info;
            internal AttendeeAvailability Availability;

            internal AttendeeDataContainer(AttendeeInfo info)
            {
                this.Info = info;
                this.Availability = null;
            }
        }

        private void AvailabilityDataGroup_Enter(object sender, EventArgs e)
        {

        }
    }
}
