using System;
using System.Collections.Generic;
//using System.Management.Automation;
//using System.Management.Automation.Remoting;
//using System.Management.Automation.Runspaces;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Xml;
using System.Collections;
using System.Diagnostics;

namespace MeetingAnalyzer
{
    public class Utils
    {
        public static string m_AppPath = "";
        public static string m_FilePath = "";
        public static string m_CSVPath = "";
        public static string m_MBX = "";
        public static string m_Subject = "";

        // List of property names to get from Exchange for each item in the get-calendardiagnosticobjects call
        public static string[] rgstrPropsToGet = new string[] {
                    "AppointmentAuxiliaryFlags",
                    "AppointmentRecurrenceBlob",
                    "AppointmentRecurring",
                    "AppointmentState",
                    "CalendarItemType",
                    "CalendarLogTriggerAction",
                    "CalendarProcessed",
                    "CleanGlobalObjectId",
                    "ClientInfoString",
                    "ClientIntent",
                    "DisplayAttendeesCc",
                    "DisplayAttendeesTo",
                    "EndTime",
                    "EndWallClock",
                    "FreeBusyStatus",
                    "From",
                    "HijackedMeeting",
                    "IsAllDayEvent",
                    "IsCancelled",
                    "IsException",
                    "IsMeeting",
                    "IsOrganizerProperty",
                    "IsProcessed",
                    "IsRecurring",
                    "IsSeriesCancelled",
                    "IsSoftDeleted",
                    "ItemClass",
                    "LastModifiedTime",
                    "Location",
                    "MapiEndTime",
                    "MapiStartTime",
                    "MeetingRequestType",
                    "OriginalLastModifiedTime",
                    "ReceivedBy",
                    "ReceivedRepresenting",
                    "RecurrencePattern",
                    "ResponsibleUserName",
                    "SenderEmailAddress",
                    "SentRepresentingDisplayName",
                    "SentRepresentingEmailAddress",
                    "StartTime",
                    "StartWallClock",
                    "SubjectProperty",
                    "TimeZone",
                    "ViewEndTime",
                    "ViewStartTime"
                };

        // DispidApptAuxFlags can be set as below...
        [Flags]
        enum AuxFlags
        {
            auxApptFlagCopied = 0x0001,
            auxApptFlagForceMtgResponse = 0x0002,
            auxApptFlagForwarded = 0x0004,
            auxApptFlagRepairUpdateMessage = 0x0020,
        }
        // Public documentation allows me to use the above flags for now (as of 12/10/2015)
        /*
         * auxApptFlagCopied (1 bit): This flag indicates that the Calendar object was copied from another Calendar folder
           auxApptFlagForceMtgResponse (1 bit): This flag on a Meeting Request object indicates that the client or server can require that a Meeting Response object be sent to the organizer when a response is chosen.
           auxApptFlagForwarded (1 bit): This flag on a Meeting Request object indicates that it was forwarded by the organizer or another recipient (2), rather than sent directly from the organizer.
           auxApptFlagRepairUpdateMessage (1 bit): This flag is set when the meeting request is a Repair Update Message sent from a server-side calendar repair system
         * */

        //
        // Create Log File
        //
        public static void CreateFile(string strUser, string strSubject)
        {
            if (!(string.IsNullOrEmpty(strUser)))
            {
                strUser = string.Concat(strUser.Split(Path.GetInvalidFileNameChars(), StringSplitOptions.RemoveEmptyEntries));
            }
            if (!(string.IsNullOrEmpty(strSubject)))
            {
                if (strSubject.Length > 25)
                {
                    strSubject = strSubject.Substring(0, 25);
                }
                strSubject = string.Concat(strSubject.Split(Path.GetInvalidFileNameChars(), StringSplitOptions.RemoveEmptyEntries));
                strSubject = strSubject.Replace(' ', '_');
                strSubject = strSubject.Replace('.', '_');
            }
            m_AppPath = AppDomain.CurrentDomain.BaseDirectory;
            m_FilePath = m_AppPath + strUser + "_" + strSubject + ".log";
            //File.Create(m_FilePath);
            //File.SetAttributes(m_FilePath, FileAttributes.Normal);
        }

        //
        // Create a CSV file to dump props for all items to
        //
        public static void CreateCSVFile(string strUser, string strSubject)
        {
            /*string strHeader = "AppointmentAuxiliaryFlags,AppointmentRecurrenceBlob,AppointmentRecurring,AppointmentState,CalendarItemType,CalendarLogTriggerAction,CalendarProcessed," +
                                "CleanGlobalObjectId,ClientInfoString,ClientIntent,DisplayAttendeesCc,DisplayAttendeesTo,EndTime,EndWallClock,FreeBusyStatus,From," +
                                "HijackedMeeting,IsAllDayEvent,IsCancelled,IsException,IsMeeting,IsOrganizerProperty,IsProcessed,IsRecurring,IsSeriesCancelled,IsSoftDeleted," +
                                "ItemClass,LastModifiedTime,Location,MapiEndTime,MapiStartTime,MeetingRequestType,OriginalLastModifiedTime,ReceivedBy,ReceivedRepresenting," +
                                "RecurrencePattern,ResponsibleUserName,SenderEmailAddress,SentRepresentingDisplayName,SentRepresentingEmailAddress,StartTime,StartWallClock," +
                                "SubjectProperty,TimeZone,ViewEndTime,ViewStartTime,ItemFolderName";*/
            string strHeader = "SubjectProperty,ItemClass,CalendarLogTriggerAction,ClientInfoString,ResponsibleUserName,FreeBusyStatus,AppointmentState,OriginalLastModifiedTime," +
                                "AppointmentAuxiliaryFlags,AppointmentRecurrenceBlob,AppointmentRecurring,CalendarItemType,CalendarProcessed,CleanGlobalObjectId,ClientIntent," +
                                "DisplayAttendeesCc,DisplayAttendeesTo,EndTime,EndWallClock,From,HijackedMeeting,IsAllDayEvent,IsCancelled,IsException,IsMeeting,IsOrganizerProperty," +
                                "IsProcessed,IsRecurring,IsSeriesCancelled,IsSoftDeleted,LastModifiedTime,Location,MapiEndTime,MapiStartTime,MeetingRequestType,ParentDisplay,ReceivedBy," +
                                "ReceivedRepresenting,RecurrencePattern,SenderEmailAddress,SentRepresentingDisplayName,SentRepresentingEmailAddress,StartTime,StartWallClock," +
                                "TimeZone,ViewEndTime,ViewStartTime";

            if (!(string.IsNullOrEmpty(strUser)))
            {
                strUser = string.Concat(strUser.Split(Path.GetInvalidFileNameChars(), StringSplitOptions.RemoveEmptyEntries));
            }
            if (!(string.IsNullOrEmpty(strSubject)))
            {
                if (strSubject.Length > 25)
                {
                    strSubject = strSubject.Substring(0, 25);
                }
                strSubject = string.Concat(strSubject.Split(Path.GetInvalidFileNameChars(), StringSplitOptions.RemoveEmptyEntries));
                strSubject = strSubject.Replace(' ', '_');
                strSubject = strSubject.Replace('.', '_');
            }
            m_AppPath = AppDomain.CurrentDomain.BaseDirectory;
            m_CSVPath = m_AppPath + strUser + "_" + strSubject + ".csv";

            File.AppendAllText(m_CSVPath, strHeader + Environment.NewLine);
        }

        //
        // Send all the message data out to a CSV - NOT to command window any more 
        //
        public static void WriteMsgData(DataSet ds)
        {
            Console.WriteLine("Writing data to files...");

            StringCollection strColCSV = new StringCollection();
            string[] strCSVProps = new string[] {
                "SubjectProperty", "ItemClass", "CalendarLogTriggerAction", "ClientInfoString", "ResponsibleUserName", "FreeBusyStatus", "AppointmentState", "OriginalLastModifiedTime",
                "AppointmentAuxiliaryFlags", "AppointmentRecurrenceBlob", "AppointmentRecurring", "CalendarItemType", "CalendarProcessed", "CleanGlobalObjectId", "ClientIntent",
                "DisplayAttendeesCc", "DisplayAttendeesTo", "EndTime", "EndWallClock", "From", "HijackedMeeting", "IsAllDayEvent", "IsCancelled", "IsException", "IsMeeting",
                "IsOrganizerProperty", "IsProcessed", "IsRecurring", "IsSeriesCancelled", "IsSoftDeleted", "LastModifiedTime", "Location", "MapiEndTime", "MapiStartTime",
                "MeetingRequestType", "ParentDisplay", "ReceivedBy", "ReceivedRepresenting", "RecurrencePattern", "SenderEmailAddress", "SentRepresentingDisplayName",
                "SentRepresentingEmailAddress", "StartTime", "StartWallClock", "TimeZone", "ViewEndTime", "ViewStartTime"
            };
            strColCSV.AddRange(strCSVProps);

            foreach (DataTable dt in ds.Tables)
            {
                //Console.WriteLine("====================================================");

                foreach (string strP in strCSVProps)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        string strProp = dr["PropName"].ToString();

                        if (strP == strProp)
                        {
                            string strVal = dr["PropVal"].ToString();
                            string strCSV = "";

                            // make easier-to-read output (converting a number / hex to understandable text)

                            if (strProp == "AppointmentState")
                            {
                                if (!(string.IsNullOrEmpty(strVal)))
                                {
                                    HandleASF(ref strVal);
                                }
                            }

                            if (strProp == "FreeBusyStatus")
                            {
                                if (!(string.IsNullOrEmpty(strVal)))
                                {
                                    HandleBusyStatus(ref strVal);
                                }
                            }

                            if (strProp == "AppointmentAuxiliaryFlags")
                            {
                                if (!(string.IsNullOrEmpty(strVal)))
                                {
                                    HandleAuxFlags(ref strVal);
                                }
                            }

                            strVal = strVal.Replace(',', ';');
                            //string strOut = FormatOutputString(strProp, strVal);
                            //Console.WriteLine(strOut);
                            if (strProp != "ViewStartTime")
                            {
                                strCSV = strVal + ",";
                            }
                            else
                            {
                                strCSV = strVal;
                            }
                            File.AppendAllText(m_CSVPath, strCSV);
                        }
                    }
                }
                File.AppendAllText(m_CSVPath, Environment.NewLine);

                //Console.WriteLine("====================================================");
                //Console.WriteLine("");
            }

        }

        //
        // Formatting for writing message data
        //
        public static string FormatOutputString(string strPropName, string strPropVal)
        {
            int iFormat = 30; // seems the longest name is 26 chars, so 30 is a nice round number
            int iNameDiff = 0;
            string strSpaces = "";
            string strOut = "";

            iNameDiff = iFormat - strPropName.Length;
            for (int i = 0; i < iNameDiff; i++)
            {
                strSpaces = strSpaces + " ";
            }

            strOut = strPropName + strSpaces + ":" + " " + strPropVal;
            return strOut;
        }

        //
        // Write to text file and to console
        //
        public static void Write(string strLine)
        {
            Console.WriteLine(strLine);
            File.AppendAllText(m_FilePath, strLine + Environment.NewLine);
        }

        //
        // Write to text file only
        //
        public static void FileWrite(string strLine)
        {
            File.AppendAllText(m_FilePath, strLine + Environment.NewLine);
        }

        //
        // Get the path to the version of MrMapi needed
        //
        public static string GetMrMapiPath()
        {
            object oRegVal;
            string strRegVal;
            string strSize = IntPtr.Size.ToString();
            string mapiBitness = "x86";

            // Check for ClickToRun config first...
            if (Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Office\ClickToRun", "Platform", null) != null)
            {
                oRegVal = Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Office\ClickToRun", "Platform", null);
                strRegVal = oRegVal.ToString();
                if (strRegVal.Contains("x64"))
                {
                    mapiBitness = "x64";
                }
            }
            // check Office 15.0 location
            else if (Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Office\15.0\Outlook", "Bitness", null) != null)
            {
                oRegVal = Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Office\15.0\Outlook", "Bitness", null);
                strRegVal = oRegVal.ToString();
                if (strRegVal.Contains("x64"))
                {
                    mapiBitness = "x64";
                }
            }
            // check Office 16.0 location
            else if (Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Office\16.0\Outlook", "Bitness", null) != null)
            {
                oRegVal = Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Office\16.0\Outlook", "Bitness", null);
                strRegVal = oRegVal.ToString();
                if (strRegVal.Contains("x64"))
                {
                    mapiBitness = "x64";
                }
            }
            // I "think" Outlook 2010 / 2013 64-bit would populate this with MSI builds - so another way to check if others above fail
            else if (IntPtr.Size == 8 && Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows Messaging Subsystem\MSMapiApps", "outlook.exe", null) != null)
            {
                mapiBitness = "x64";
            }

            // Console.WriteLine("MAPI Bitness is: " + mapiBitness);
            return System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), mapiBitness, "MrMAPI.exe");
        }

        //
        // run MrMapi to get item props requiring conversion/parsing like the appointment recurrence property
        //
        public static void RunMrMAPI(string strSwitches)
        {
            // Setup and launch MrMAPI
            string strAppPath = GetMrMapiPath();
            if (File.Exists(strAppPath))
            {
                Process mrMAPI = new Process();
                mrMAPI.StartInfo.FileName = (strAppPath);
                mrMAPI.StartInfo.Arguments = (strSwitches);
                mrMAPI.StartInfo.UseShellExecute = true;
                mrMAPI.StartInfo.CreateNoWindow = true;
                mrMAPI.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                mrMAPI.Start();
                mrMAPI.WaitForExit();
            }
            return;
        }

        //
        // Handle the Aux Flags prop
        //
        public static void HandleAuxFlags(ref string strAuxFlags)
        {
            string strTemp = strAuxFlags;
            if (!(string.IsNullOrEmpty(strTemp) || strTemp != "NotFound" || strTemp != "0"))
            {
                long HexVal = Convert.ToInt64(strAuxFlags, 16);
                int iVal = int.Parse(strAuxFlags);
                string strHexVal = iVal.ToString("X");
                AuxFlags af = (AuxFlags)Enum.Parse(typeof(AuxFlags), strAuxFlags, false);

                strAuxFlags = "flags: " + strTemp + "(dec) = " + strHexVal + "(hex): " + af.ToString();
            }
            else
            {
                strAuxFlags = "flags: 0";
            }
        }

        //
        // Handle the Busy Status prop
        //
        public static void HandleBusyStatus(ref string strBusyStatus)
        {
            switch (strBusyStatus)
            {
                case "0":
                    {
                        strBusyStatus = "0 (Free)";
                        break;
                    }
                case "1":
                    {
                        strBusyStatus = "1 (Tentative)";
                        break;
                    }
                case "2":
                    {
                        strBusyStatus = "2 (Busy)";
                        break;
                    }
                case "3":
                    {
                        strBusyStatus = "3 (Out Of Office)";
                        break;
                    }
                default:
                    {
                        strBusyStatus = strBusyStatus + " (Unknown or Invalid Setting)";
                        break;
                    }
            }
        }

        //
        // Handle the Appointment State Flags prop
        //
        public static void HandleASF(ref string strASF)
        {
            switch (strASF)
            {
                case "0":
                    {
                        strASF = "0 (None - Appointment)";
                        break;
                    }
                case "1":
                    {
                        strASF = "1 (Meeting - Organizer)";
                        break;
                    }
                case "2":
                    {
                        strASF = "2 (Received)";
                        break;
                    }
                case "3":
                    {
                        strASF = "3 (Meeting/Received - Attendee)";
                        break;
                    }
                case "4":
                    {
                        strASF = "4 (Canceled)";
                        break;
                    }
                case "5":
                    {
                        strASF = "5 (Meeting/Canceled)";
                        break;
                    }
                case "6":
                    {
                        strASF = "6 (Received/Canceled)";
                        break;
                    }
                case "7":
                    {
                        strASF = "7 (Meeting/Received/Canceled - Canceled Meeting)";
                        break;
                    }
                case "8":
                    {
                        strASF = "8 (Forward)";
                        break;
                    }
                case "9":
                    {
                        strASF = "9 (Forward/Meeting)";
                        break;
                    }
                case "10":
                    {
                        strASF = "10 (Forward/Received)";
                        break;
                    }
                case "11":
                    {
                        strASF = "11 (Fwd/Rcvd/Meeting)";
                        break;
                    }
                default:
                    {
                        strASF = strASF + " (Unknown or Invalid Setting)";
                        break;
                    }
            }
        }


        //
        // Set stuff back to initial state for a new meeting if the user wants to check another meeting
        //
        public static void Reset()
        {
            try
            {
                MsgData.msgDataSet.Clear();
                Timeline.m_strMbx = "";
                Timeline.m_bAccepted = false;
                Timeline.m_bExtMsgClass = false;
                Timeline.m_bFirstItem = true;
                Timeline.m_bHeader = false;
                Timeline.m_bInitPropsSaved = false;
                Timeline.m_FromSMTP = "";
                Timeline.m_FromX500 = "";
                Timeline.m_iMsgNum = 1;
                Timeline.m_Role = "";
                Timeline.m_iNumMsgs = 0;
                Timeline.m_bOLProcessedLast = false;
                Timeline.m_bOLProcessedItem = false;
                Timeline.m_bOrganizer = false;
                Timeline.m_strApptRecurring = "";
                Timeline.m_strApptStateFlags = "";
                Timeline.m_strBusyStatus = "";
                Timeline.m_strCc = "";
                Timeline.m_strEndWhole = "";
                Timeline.m_strIsRecurring = "";
                Timeline.m_strLocation = "";
                Timeline.m_strMbx = "";
                Timeline.m_strOrganizerAddr = "";
                Timeline.m_strOrganizerName = "";
                Timeline.m_strSender = "";
                Timeline.m_strStartWhole = "";
                Timeline.m_strTo = "";
                Timeline.m_strViewEnd = "";
            }
            catch
            {
                // if here then probably never really started anyway - so just go...
            }
        }
    }//utils class
}// namespace