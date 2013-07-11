using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Windows.Forms;
using EWSEditor.Common;
using Microsoft.Exchange.WebServices.Data;
 

namespace EWSEditor.Forms 
{
    public partial class TimeZonesForm : Form
    {
        private ExchangeService _ExchangeService = null;

        public TimeZonesForm()
        {
            InitializeComponent();
        }

        public TimeZonesForm(ExchangeService oService)
        {
            _ExchangeService = oService;
            InitializeComponent();

        }

         

        private void btnListTimezones_Click(object sender, EventArgs e)
        {
 
            try
            {
                StringBuilder sb = new StringBuilder();
                ListView oListView = lvMachineTimeZones;

                oListView.Clear();
                oListView.View = View.Details;
                oListView.GridLines = true;
                oListView.FullRowSelect = true;
                oListView.Columns.Add("Id", 150, HorizontalAlignment.Left);
                oListView.Columns.Add("DisplayName", 150, HorizontalAlignment.Left);
                oListView.Columns.Add("BaseUtcOffset", 80, HorizontalAlignment.Left);
                oListView.Columns.Add("DaylightName", 150, HorizontalAlignment.Left);
                oListView.Columns.Add("StandardName", 150, HorizontalAlignment.Left);
                oListView.Columns.Add("SupportsDaylightSavingTime", 180, HorizontalAlignment.Left);

                ListViewItem oListItem = null;

                 foreach (TimeZoneInfo tzinfo in TimeZoneInfo.GetSystemTimeZones())
                {
                     oListItem = new ListViewItem(tzinfo.Id, 0);
                    oListItem.SubItems.Add(tzinfo.DisplayName);
                    oListItem.SubItems.Add(tzinfo.BaseUtcOffset.ToString());
                    oListItem.SubItems.Add(tzinfo.DaylightName);
                    oListItem.SubItems.Add(tzinfo.StandardName);
                    oListItem.SubItems.Add(tzinfo.SupportsDaylightSavingTime.ToString());
                    // TimeZoneInfo.AdjustmentRule[] o = tzinfo.GetAdjustmentRules();

                    oListView.Items.AddRange(new ListViewItem[] { oListItem });
                    oListItem = null;
                }
 
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnServerTimeZone_Click(object sender, EventArgs e)
        {
             txtServerTimezoneResults.Text =  GetValuesFromTimeZoneInfo(_ExchangeService.TimeZone);
        }

        private string GetValuesFromTimeZoneInfo(TimeZoneInfo oTimeZoneInfo)
        {
            string s = string.Empty;

            try
            {

                StringBuilder sb = new StringBuilder();


                sb.Append(string.Format("Timezone: \r\n"));
                sb.Append(string.Format("    ID:  {0} \r\n", oTimeZoneInfo.Id));
                sb.Append(string.Format("    DisplayName:  {0} \r\n", oTimeZoneInfo.DisplayName));
                sb.Append(string.Format("    StandardName:  {0} \r\n", oTimeZoneInfo.StandardName));
                sb.Append(string.Format("    DaylightName:  {0} \r\n", oTimeZoneInfo.DaylightName));
                sb.Append(string.Format("    SupportsDaylightSavingTime:  {0} \r\n", oTimeZoneInfo.SupportsDaylightSavingTime.ToString()));
                sb.Append(string.Format("    ToSerializedString:  {0} \r\n", oTimeZoneInfo.ToSerializedString()));
                sb.Append(string.Format("    ToString:  {0} \r\n", oTimeZoneInfo.ToString()));
                sb.Append(string.Format("    BaseUtcOffset:  {0} \r\n", oTimeZoneInfo.ToString()));

                s = sb.ToString();
                //txtServerTimezoneResults.Text = s;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            return s;
        }

        private string GetValuesFromTimezoneStringAndDateTime(string sTimeZone, DateTime oDateTime)
        {
            string s = string.Empty;

            try
            {
                StringBuilder sb = new StringBuilder();

                TimeZoneInfo oTimeZoneInfo = null;
                oTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(sTimeZone);

                sb.Append(string.Format("\r\n"));
                sb.Append(string.Format("Using Timezone string and Date + Time: \r\n"));
                sb.Append(string.Format("    GetUtcOffset:  {0} \r\n", oTimeZoneInfo.GetUtcOffset(oDateTime)));
                sb.Append(string.Format("    IsDaylightSavingTime:  {0} \r\n", oTimeZoneInfo.IsDaylightSavingTime(oDateTime)));
                sb.Append(string.Format("    IsAmbiguousTime:  {0} \r\n", oTimeZoneInfo.IsAmbiguousTime(oDateTime)));
                sb.Append(string.Format("    IsInvalidTime:  {0} \r\n", oTimeZoneInfo.IsInvalidTime(oDateTime)));


                s = sb.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            return s;
        }

        private void TimeZoneByIdString_Click(object sender, EventArgs e)
        {
            string s = string.Empty;
            StringBuilder sb = new StringBuilder();

            txtTimeZoneLookupResults.Text = string.Empty;

            string sTimeZone = cmboTimeZoneIds.Text.Trim();

            if (sTimeZone.Length != 0)
            {
                try
                {

                    //oTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(cmboTimeZoneIds.Text);
                    DateTime oDateTime = TimeHelper.GetDateFromDateTimePickers(dtStartDate, dtStartTime);

                    sb.Append("GetValuesFromTimezoneString: ");
                    sb.Append(GetValuesFromTimezoneString(cmboTimeZoneIds.Text.Trim()));
                    sb.Append("\r\n");
                    sb.Append("GetValuesFromTimezoneString using " + oDateTime.ToString() + ":");
                    sb.Append(GetValuesFromTimezoneStringAndDateTime(cmboTimeZoneIds.Text.Trim(), oDateTime));
                    sb.Append("\r\n");

                    s = sb.ToString();
                    txtTimeZoneLookupResults.Text = s;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
            else
            {
                MessageBox.Show("A Time Zone must be selectd first.", "Error");
            }

        }

        private void TimeZonesForm_Load(object sender, EventArgs e)
        {
            try
            {
                dtStartDate.Value = new DateTime(DateTime.Now.Ticks);
                dtStartTime.Value = new DateTime(dtStartDate.Value.Ticks);

                foreach (TimeZoneInfo tzinfo in TimeZoneInfo.GetSystemTimeZones())
                {
                    cmboTimeZoneIds.Items.Add(tzinfo.Id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void dtStartDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private string GetValuesFromTimezoneString(string sTimeZone)
        {
            string s = string.Empty;

            try
            {

                StringBuilder sb = new StringBuilder();

                TimeZoneInfo oTimeZoneInfo = null;
                oTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(sTimeZone);

                sb.Append(GetValuesFromTimeZoneInfo(oTimeZoneInfo));

                s = sb.ToString();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            return s;
        }

        private string GetComputerTimeValues()
        {
            string s = string.Empty;

            try
            {
                 

                StringBuilder sb = new StringBuilder();
                DaylightTime oDaylightTime = null;
                TimeZone oCurrentTimeZone = TimeZone.CurrentTimeZone;

                TimeZoneInfo x = TimeZoneInfo.Local;
                  
                
                sb.Append(string.Format("\r\n"));
 
                sb.Append(string.Format("On this computer: \r\n"));
                sb.Append(string.Format("    Now:            {0} \r\n", DateTime.Now.ToString()));
                sb.Append(string.Format("    LocalTime:      {0} \r\n", DateTime.Now.ToLocalTime()));

                sb.Append(string.Format("\r\n"));
                sb.Append(string.Format("  TimeZoneInfo: \r\n"));
                sb.Append(string.Format("    Id:             {0} \r\n", x.Id));
                sb.Append(string.Format("    StandardName:   {0} \r\n", x.StandardName));
                sb.Append(string.Format("    DaylightName:   {0} \r\n", x.DaylightName));
                sb.Append(string.Format("    DisplayName:    {0} \r\n", x.DisplayName));
                sb.Append(string.Format("    DisplayName:    {0} \r\n", x.BaseUtcOffset.ToString()));
                sb.Append(string.Format("    DisplayName:    {0} \r\n", x.SupportsDaylightSavingTime.ToString()));
 
                sb.Append(string.Format("\r\n"));
                sb.Append(string.Format("  TimeZone: \r\n" ));
                sb.Append(string.Format("    DaylightName:   {0} \r\n", oCurrentTimeZone.DaylightName));
                sb.Append(string.Format("    UniversalTime:  {0} \r\n", oCurrentTimeZone.StandardName));
 
                sb.Append(string.Format("\r\n"));
                sb.Append(string.Format("    Daylight Savings Time: \r\n"));
                oDaylightTime = oCurrentTimeZone.GetDaylightChanges(DateTime.Now.Year);
                sb.Append(string.Format("        Starts:     {0:yyyy-MM-dd HH:mm} \r\n", oDaylightTime.Start, oDaylightTime.End, oDaylightTime.Delta));
                sb.Append(string.Format("        Ends:       {0:yyyy-MM-dd HH:mm} \r\n", oDaylightTime.End));
                sb.Append(string.Format("        Delta:      {0} \r\n", oDaylightTime.Delta));

                s = sb.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            return s;
        }

        private void dtStartTime_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnClientCurrentTimeZone_Click(object sender, EventArgs e)
        {
            StringBuilder oSB = new StringBuilder();
            txtClientCurrentTimezone.Text = string.Empty;

            txtClientCurrentTimezone.Text = GetComputerTimeValues();
 
        }

        private void cmboTimeZoneIds_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
