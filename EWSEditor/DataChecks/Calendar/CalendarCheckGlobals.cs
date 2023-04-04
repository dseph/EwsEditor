//using Microsoft.Exchange.WebServices.Data;
//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using EWSEditor.DataChecks.Calendar;
//using static EWSEditor.DataChecks.Calendar.CalendarCheckGlobals;
//using static EWSEditor.DataChecks.Calendar.CalendarCheckUtils;
 
//namespace EWSEditor.DataChecks.Calendar
//{
//    internal class CalendarCheckGlobals
//    {
//        public static string strClientID = ConfigurationManager.AppSettings["ClientID"];
//        public static string strRedirURI = "https://CalVerifier";
//        public static string strAuthCommon = "https://login.microsoftonline.com/common";
//        public static string strSrvURI = "https://outlook.office365.com";                            // O365 URI         
//        public static string strResource = "00000002-0000-0ff1-ce00-000000000000";                   // O365 Exchange Resource
//        public static bool bListMode = false;
//        public static bool bMoveItems = false;
//        public static bool bVerbose = false;
//        public static string strListFile = "";
//        public static string[] rgstrMBX;
//        public static string strAppPath = AppDomain.CurrentDomain.BaseDirectory;
//        public static int iErrors = 0;
//        public static int iWarn = 0;
//        public static DateTime dtMin = DateTime.Parse("01/01/1601 00:00");
//        public static DateTime dtMax = DateTime.Parse("12/31/4500 11:59");
//        public static DateTime dtNone = DateTime.Parse("01/01/4501 00:00");
//        public static DateTime dtOld = DateTime.Parse("01/01/1990 00:00");
//        public static DateTime dtFuture = DateTime.Parse("12/31/2099 11:59");
//        public static List<string> rgstrProxyAddresses = null;
//        public static string strDisplayName = "";
//        public static string strSMTPAddr = "";
//        public static string strLogFile;
//        public static StreamWriter outLog;
//        public static List<string> strDupCheck = null;
//        public static List<string> strGOIDCheck = null;
//        public static int iRecurItems = 0;
//        public static Folder fldCalVerifier = null;
//        public static int iCheckedItems = 0;
//        public static char[] cSpin = new char[] { '/', '-', '\\', '|' };

//        public static void CreateLogFile()
//        {
//            strLogFile = strAppPath + "CalVerifier.log";
//            outLog = new StreamWriter(strLogFile);
//        }

//        public static void ResetGlobals()
//        {
//            iErrors = 0;
//            iWarn = 0;
//            rgstrProxyAddresses = null;
//            strDisplayName = "";
//            strSMTPAddr = "";
//            strDupCheck = null;
//            strGOIDCheck = null;
//            iRecurItems = 0;
//            iCheckedItems = 0;
//            fldCalVerifier = null;
//        }

//        public static string[] calMsgClasses = new string[]
//        {
//            "IPM.Appointment",
//            "IPM.Appointment.Live Meeting Request",
//            "IPM.Appointment.Location",
//            "IPM.Appointment.MeetingPlace",
//            "IPM.Appointment.MP"
//        };
//    }
//}
