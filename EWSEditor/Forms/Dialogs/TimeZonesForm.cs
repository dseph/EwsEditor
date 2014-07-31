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
        //private ExchangeService _ExchangeService = null;

        public TimeZonesForm()
        {
            InitializeComponent();
        }

        //public TimeZonesForm(ExchangeService oService)
        //{
        //    _ExchangeService = oService;
        //    InitializeComponent();

        //}

         

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
            ServerTimeZone();
 
        }

        private void ServerTimeZone()
        {
            //DateTime oDateTime = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified);

            //StringBuilder oSB = new StringBuilder();
            //oSB.AppendLine("Server TimeZoneInfo:");
            //oSB.AppendLine(TimeHelper.GetValuesFromTimeZoneInfo(_ExchangeService.TimeZone));
            //oSB.AppendLine("");


            //txtServerTimezoneResults.Text = oSB.ToString();

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

                    //sb.Append("GetValuesFromTimezoneString: ");
                    //sb.Append(GetValuesFromTimezoneString(cmboTimeZoneIds.Text.Trim()));
                    //sb.Append("\r\n");
                    sb.Append("Timezone Information:" );
                    sb.Append(TimeHelper.GetValuesFromTimezoneStringAndDateTime(cmboTimeZoneIds.Text.Trim(), oDateTime));
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
                    cmboFromTimeZone.Items.Add(tzinfo.Id);
                    cmboToTimeZone.Items.Add(tzinfo.Id);
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

                //StringBuilder sb = new StringBuilder();

                TimeZoneInfo oTimeZoneInfo = null;
                oTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(sTimeZone);

                s = TimeHelper.GetValuesFromTimeZoneInfo(oTimeZoneInfo);

                //s = sb.ToString();
                
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
                //DaylightTime oDaylightTime = null;
                TimeZone oCurrentTimeZone = TimeZone.CurrentTimeZone;

                TimeZoneInfo x = TimeZoneInfo.Local;
                  
                
                sb.Append(string.Format("\r\n"));
 
                sb.Append(string.Format("On this computer: \r\n"));
                sb.Append(string.Format("    Now:            {0} \r\n", DateTime.Now.ToString()));
                sb.Append(string.Format("    LocalTime:      {0} \r\n", DateTime.Now.ToLocalTime()));

                //sb.Append(string.Format("\r\n"));
                //sb.Append(string.Format("Local TimeZoneInfo: \r\n"));
                //sb.Append(string.Format("    Id:             {0} \r\n", x.Id));
                //sb.Append(string.Format("    StandardName:   {0} \r\n", x.StandardName));
                //sb.Append(string.Format("    DaylightName:   {0} \r\n", x.DaylightName));
                //sb.Append(string.Format("    DisplayName:    {0} \r\n", x.DisplayName));
                //sb.Append(string.Format("    DisplayName:    {0} \r\n", x.BaseUtcOffset.ToString()));
                //sb.Append(string.Format("    DisplayName:    {0} \r\n", x.SupportsDaylightSavingTime.ToString()));
 
                //sb.Append(string.Format("\r\n"));
                //sb.Append(string.Format("  TimeZone: \r\n" ));
                //sb.Append(string.Format("    DaylightName:   {0} \r\n", oCurrentTimeZone.DaylightName));
                //sb.Append(string.Format("    UniversalTime:  {0} \r\n", oCurrentTimeZone.StandardName));
 
                //sb.Append(string.Format("\r\n"));
                //sb.Append(string.Format("    Daylight Savings Time: \r\n"));
                //oDaylightTime = oCurrentTimeZone.GetDaylightChanges(DateTime.Now.Year);
                //sb.Append(string.Format("        Starts:     {0:yyyy-MM-dd HH:mm} \r\n", oDaylightTime.Start, oDaylightTime.End, oDaylightTime.Delta));
                //sb.Append(string.Format("        Ends:       {0:yyyy-MM-dd HH:mm} \r\n", oDaylightTime.End));
                //sb.Append(string.Format("        Delta:      {0} \r\n", oDaylightTime.Delta));

                sb.AppendLine("Local TimeZoneInfo:");
                sb.Append(TimeHelper.GetValuesFromTimeZoneInfo(x));

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

            // GetValuesFromTimezoneString
 
        }

        private void cmboTimeZoneIds_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnConvertTimezone_Click(object sender, EventArgs e)
        {
            string s = string.Empty;
            StringBuilder sbFrom = new StringBuilder();
            StringBuilder sbTo = new StringBuilder();
            this.txtConversionResults.Text = "";

            
            this.txtFromTimeZone.Text = string.Empty;
            this.txtToTimeZone.Text = string.Empty;
           
            string sFromTimeZone = this.cmboFromTimeZone.Text.Trim();
            string sToTimeZone = this.cmboToTimeZone.Text.Trim();

 
            DateTime oDateTime = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Unspecified); 

            if (rdoConvertByDateTime.Checked == true)
            {
                oDateTime = TimeHelper.GetDateFromDateTimePickers(dtConvertStartDate, dtConvertStartTime);
            }
            if (this.rdoConvertByTicks.Checked == true)
            {
                long lTicks = 0;   // its a Int64

                string sString = this.txtTicks.Text.Trim();
                if (Int64.TryParse(sString, out lTicks))
                {
                    //iTicks = Convert.ToInt64(sString);
                    oDateTime = new DateTime(lTicks);
                }
                else
                {
                    MessageBox.Show("The Ticks value is not an int64.");
                    return;
                }
            }
            if (rdoConvertByNow.Checked == true)
            {
                DateTimeKind oDateTimeKind = DateTimeKind.Unspecified;
                switch (this.cmboConversionKind.Text)
                {
                    case "Unspecified":
                        oDateTimeKind = DateTimeKind.Unspecified;
                        break;
                    case "Utc":
                        oDateTimeKind = DateTimeKind.Utc;
                        break;
                    case "Local":
                        oDateTimeKind = DateTimeKind.Local;
                        break;
                }

                oDateTime = DateTime.SpecifyKind(DateTime.Now, oDateTimeKind); 
            }

            txtConversionDateInfo.Text = TimeHelper.GetDateTimeInfo(oDateTime);
 
            if (sFromTimeZone.Length != 0)
            {
                try
                {

                    //oTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(cmboTimeZoneIds.Text);


                    //sbFrom.Append("GetValuesFromTimezoneString: ");
                    //sbFrom.Append(GetValuesFromTimezoneString(cmboFromTimeZone.Text.Trim()));
                    //sbFrom.Append("\r\n");
                    sbFrom.Append("Timezone Information:");
                    sbFrom.Append(TimeHelper.GetValuesFromTimezoneStringAndDateTime(cmboFromTimeZone.Text.Trim(), oDateTime));
                    sbFrom.Append("\r\n");

                    s = sbFrom.ToString();
                    txtFromTimeZone.Text = s;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error finding From TimeZone");
                    return;
                }
            }
            else
            {
                MessageBox.Show("A From Time Zone must be selectd first.", "Error");
                return;
            }

            
        if (sToTimeZone.Length != 0)
            {
                try
                {

                    sbTo.Append("Timezone Information:");
                    sbTo.Append(TimeHelper.GetValuesFromTimezoneStringAndDateTime(this.cmboToTimeZone.Text.Trim(), oDateTime));
                    sbTo.Append("\r\n");

                    s = sbTo.ToString();
                    txtToTimeZone.Text = s;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error finding To TimeZone");
                    return;
                }
            }
            else
            {
                MessageBox.Show("A To Time Zone must be selectd first.", "Error");
                return;
            }

            TimeZoneInfo oFromTimeZoneInfo = null;
            oFromTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(sFromTimeZone);

            TimeZoneInfo oToTimeZoneInfo = null;
            oToTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(sToTimeZone);

            // Some times are not valid for certain timezones.  This can happen when time (often an hour) is skipped for DST changes.  Timezone conversion routines will throw
            // an error rather than adjusting the time forward to what the time would be after a DST/trasition time change.
            lblConversionError.Text = "";
            if (oFromTimeZoneInfo.IsInvalidTime(oDateTime))
            {
                lblConversionError.Text += oDateTime.ToString() + " is invalid for " + oFromTimeZoneInfo.StandardName + ".  ";
            }
            if (oToTimeZoneInfo.IsInvalidTime(oDateTime))
            {
                lblConversionError.Text += oDateTime.ToString() + " is invalid for " + oToTimeZoneInfo.StandardName;
            }
 
            try
            {

                DateTime oResultDateTime = System.TimeZoneInfo.ConvertTime(oDateTime, oFromTimeZoneInfo, oToTimeZoneInfo);

                StringBuilder oSbRestults = new StringBuilder();
                oSbRestults.AppendLine("New DateTime: " + oResultDateTime.ToString());
                oSbRestults.Append(TimeHelper.GetDateTimeInfo(oResultDateTime));
                oSbRestults.AppendLine(" ");
 
                this.txtConversionResults.Text = oSbRestults.ToString();
            }
            catch (System.ArgumentException exSae)
            {
 
                this.txtConversionResults.Text =
                    "\r\n*********************\r\nError (ArgumentException): \r\n\r\n" + 
                    exSae.ToString() +
                    "\r\n*********************\r\n\r\n"; 

            }
            catch (TimeZoneConversionException exTz)
            {
                this.txtConversionResults.Text =
                    "\r\n*********************\r\nError (TimeZoneConversionException): \r\n\r\n" +
                    exTz.ToString() +
                    "\r\n*********************\r\n\r\n"; 

            }
            catch (Exception ex)
            {
                this.txtConversionResults.Text =
                    "\r\n*********************\r\nError (Exception): \r\n\r\n" +
                    ex.ToString() +
                    "\r\n*********************\r\n\r\n"; 
            }

 
 
            
        }
 

        private void ToTimeZone_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void rdoNow_CheckedChanged(object sender, EventArgs e)
        {
            SetConversionEnablement();
        }

        private void SetConversionEnablement()
        {
            if (this.rdoConvertByDateTime.Checked == true)
            {
                dtConvertStartTime.Enabled = true;
                dtConvertStartDate.Enabled = true;

                txtTicks.Enabled = false;
            }

            if (this.rdoConvertByTicks.Checked == true)
            {
                dtConvertStartTime.Enabled = false;
                dtConvertStartDate.Enabled = false;

                txtTicks.Enabled = true;
            }

            if (this.rdoConvertByNow.Checked == true)
            {
                dtConvertStartTime.Enabled = false;
                dtConvertStartDate.Enabled = false;

                txtTicks.Enabled = false;

            }

        }

        private void tabConvertTime_Click(object sender, EventArgs e)
        {
            SetConversionEnablement();
        }

        private void rdoConvertByDateTime_CheckedChanged(object sender, EventArgs e)
        {
            SetConversionEnablement();
        }

        private void rdoConvertByTicks_CheckedChanged(object sender, EventArgs e)
        {
            SetConversionEnablement();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lvMachineTimeZones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvMachineTimeZones.SelectedItems.Count > 0)
            {
                TimeZoneInfo oTimeZoneInfo = null;
                string sTimezone = lvMachineTimeZones.SelectedItems[0].Text;
                oTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(sTimezone);

                this.txtMachineTimeZones.Text = TimeHelper.GetValuesFromTimeZoneInfo(oTimeZoneInfo);
            }
        }

        private void txtMachineTimeZones_TextChanged(object sender, EventArgs e)
        {
 
        }

        private void txtTicks_TextChanged(object sender, EventArgs e)
        {
            try
            {
                long lTicks = 0;   // its a Int64
                DateTime oDateTime = new DateTime();  // test current
                this.txtTicksTime.Text = "";
                string sString = this.txtTicks.Text.Trim();
                if (Int64.TryParse(sString, out lTicks))
                {
                    //iTicks = Convert.ToInt64(sString);
                    oDateTime = new DateTime(lTicks);
                    this.txtTicksTime.Text = oDateTime.ToString();
                }
 
            }
            catch (Exception ex)
            {

            }
           
        }

         

 

    }
}
