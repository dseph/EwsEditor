using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Collections;
using System.Diagnostics;

namespace MeetingAnalyzer
{
    public class RecurBlob  // This is the Reccurrence blob (dispidApptRecur)
    {
        public string HexBlob { get; set; }
        public string ParsedBlob { get; set; }
        public int ExceptionCount { get; set; }
        public int DelInstCount { get; set; }
        public int ModInstCount { get; set; }
        public int OccurCount { get; set; }
        public string RecurType { get; set; }
        public string RecurFreq { get; set; }
        public string RecurStartDate { get; set; }
        public string RecurStartTime { get; set; }
        public string RecurStartDateTime { get; set; }
        public string RecurEndDate { get; set; }
        public string RecurEndTime { get; set; }
        public string RecurEndDateTime { get; set; }

        enum recurFrequency
        {
            IDC_RCEV_BTN_DONTRECUR = 0x2002,
            IDC_RCEV_PAT_ORB_DAILY = 0x200A,
            IDC_RCEV_PAT_ORB_WEEKLY = 0x200B,
            IDC_RCEV_PAT_ORB_MONTHLY = 0x200C,
            IDC_RCEV_PAT_ORB_YEARLY = 0x200D,
            IDC_RCEV_PAT_ERB_END = 0x2021,
            IDC_RCEV_PAT_ERB_AFTERNOCCUR = 0x2022,
            IDC_RCEV_PAT_ERB_NOEND = 0x2023,
        }

        [Flags]
        enum exceptFlags
        {
            ARO_SUBJECT = 0x0001,
            ARO_MEETINGTYPE = 0x0002,
            ARO_REMINDERDELTA = 0x0004,
            ARO_REMINDER = 0x0008,
            ARO_LOCATION = 0x0010,
            ARO_BUSYSTATUS = 0x0020,
            ARO_ATTACHMENT = 0x0040,
            ARO_SUBTYPE = 0x0080,
            ARO_APPTCOLOR = 0x0100,
            ARO_EXCEPTIONAL_BODY = 0x0200,
        }

        public static string GetDateFromString(string strLine)
        {
            int iM = 0;
            string strDate = "";

            iM = strLine.IndexOf('M');
            strDate = strLine.Substring(iM + 2);

            return strDate;
        }

        public static string GetTimeFromString(string strLine)
        {
            int iEquals = 0;
            int iM = 0;
            int iLength = 0;
            string strTime = "";

            iEquals = strLine.LastIndexOf('=');
            iM = strLine.LastIndexOf('M') + 1;
            iLength = (iM - (iEquals + 2));

            strTime = strLine.Substring(iEquals + 2, iLength);

            return strTime;
        }

        public static int GetCountFromString(string strLine)
        {
            int iRet = 0;
            int iColon = 0;
            int iEquals = 0;
            string strTemp = "";

            // for deleted and modified instance counts...
            if (strLine.Contains("InstanceCount") || strLine.Contains("OccurrenceCount"))
            {
                iEquals = strLine.IndexOf('=');
                strTemp = strLine.Substring(iEquals + 2);
                iRet = Convert.ToInt32(strTemp);
            }

            // for Exception count...
            if (strLine.Contains("ExceptionCount"))
            {
                iColon = strLine.IndexOf(':');
                strTemp = strLine.Substring(iColon + 4);
                iRet = Convert.ToInt32(strTemp, 16);
            }

            return iRet;
        }
    }
}