using System;
using System.Collections.Generic;
//using System.Management.Automation;
//using System.Management.Automation.Remoting;
//using System.Management.Automation.Runspaces;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Xml;
using System.Collections;
using System.Diagnostics;

namespace MeetingAnalyzer
{
    public class Timeline  // This is everything dealing with the timeline output to screen
    {
        public static RecurBlob m_rbPrevious = new RecurBlob();
        public static RecurBlob m_rbCurrent = new RecurBlob();
        public static string m_strMbx = "";
        public static bool m_bHeader = false;
        public static bool m_FirstAppt = true;
        public static int m_iMsgNum = 1;
        public static bool m_bExtMsgClass = false;
        public static bool m_bInitPropsSaved = false;
        public static string m_FromX500 = "";
        public static string m_FromSMTP = "";
        public static string m_Role = "";
        public static bool m_bAccepted = false;
        public static bool m_bFirstItem = true;
        public static int m_iNumMsgs = 0;
        public static bool m_bOLProcessedLast = false;
        public static bool m_bOLProcessedItem = false;
        public static bool m_bOrganizer = false;
        public static bool m_DelCheck = false;

        //Initial Appt Prop value members
        public static string m_strApptRecurring = "";
        public static string m_strIsRecurring = "";
        public static string m_strStartWhole = "";
        public static string m_strEndWhole = "";
        public static string m_strBusyStatus = "";
        public static string m_strApptStateFlags = "";
        public static string m_strLocation = "";
        public static string m_strOrganizerAddr = "";
        public static string m_strOrganizerName = "";
        public static string m_strSender = "";
        public static string m_strTo = "";
        public static string m_strCc = "";
        public static string m_strViewEnd = "";

        // When adding members here make sure to Reset them in Utils.Reset();


        // message classes we know of that are valid for meeting/calendar items
        private static string[] rgstrMsgClasses = new string[] {
                    "IPM.Appointment",
                    "IPM.Schedule.Meeting.Request",
                    "IPM.Schedule.Meeting.Canceled",
                    "IPM.Schedule.Meeting.Resp.Pos",
                    "IPM.Schedule.Meeting.Resp.Neg",
                    "IPM.Schedule.Meeting.Resp.Tent",
                    "IPM.Schedule.Meeting.Notification.Forward",
                    "IPM.Schedule.Inquiry",                                     // Calendar Repair Agent
                    "IPM.OLE.CLASS.{00061055-0000-0000-C000-000000000046}"};    // string for a meeting exception - which shows up "sometimes"};


        // the tool will dump out the recurrence data on the item that is currently in the Calendar folder - need to check "most" calendar folder names...
        private static string[] rgstrCalNames = new string[] {
            "calendar",
            "calendario",
            "kalender",
            "calendrier"
        };

        //
        // Parse out the X500 and SMTP addresses
        // format of the string is - [OneOff "user1", EX:/O=FIRST ORGANIZATION/OU=EXCHANGE ADMINISTRATIVE GROUP(FYDIBOHF23SPDLT)/CN=RECIPIENTS/CN=28651A02D4BF4C209284B00D0A0D44B6-USER1, SMTP:user1@domain.com]
        //
        public static void ParseOneOffProp(string strOneOff, ref string strX500, ref string strSMTP)
        {
            string strTemp = strOneOff;
            strTemp = strTemp.TrimStart('[');
            strTemp = strTemp.TrimEnd(']');

            string[] rgstrAddrs = strTemp.Split(',');

            foreach (string strAddr in rgstrAddrs)
            {
                if (strAddr.Contains("EX:"))
                {
                    int iPos = strAddr.IndexOf(':');
                    strX500 = strAddr.Substring(iPos + 1);
                }
                if (strAddr.Contains("SMTP:"))
                {
                    int iPos = strAddr.IndexOf(':');
                    strSMTP = strAddr.Substring(iPos + 1);
                }
            }
        }

        // 
        // Get this mailbox's Role (organizer, delegate, attendee) from props
        //
        public static void MeetingRole(TLMsg msg)
        {
            // if we have a "From" SMTP address, we can see if this is the organizer's mailbox, delegate, etc.
            if (m_FromSMTP != "(none)")
            {
                if (m_strMbx.ToLower() == m_FromSMTP.ToLower())
                {
                    if (m_FromX500.ToLower() == msg.OrganizerAddr.ToLower())
                    {
                        m_Role = "Organizer";
                    }
                    else if (m_FromX500.ToLower() == msg.SenderAddress.ToLower())
                    {
                        m_Role = "Delegate";
                    }
                    else
                    {
                        m_Role = "Attendee";
                    }
                }
                else
                {
                    m_Role = "Attendee";
                }
            }
            else if (m_bOrganizer == true)
            {
                if (m_FromX500.ToLower() == msg.OrganizerAddr.ToLower())
                {
                    m_Role = "Organizer";
                }
                else if (m_FromX500.ToLower() == msg.SenderAddress.ToLower())
                {
                    m_Role = "Delegate";
                }
            }
            else
            {
                if (msg.ResponsibleUser.ToLower() == msg.SenderAddress.ToLower())
                {
                    if (msg.SenderAddress.ToLower() != msg.OrganizerAddr.ToLower())
                    {
                        m_Role = "Delegate";
                    }
                }
                else
                {
                    m_Role = "Attendee";
                }
            }
        }


        //
        // Write out some basic "summary of this meeting" props to screen
        //
        public static void WriteHeaderInfo(TLMsg msg)
        {
            if (m_bHeader == false)
            {
                ParseOneOffProp(msg.From, ref m_FromX500, ref m_FromSMTP);
                MeetingRole(msg);

                Utils.Write("================");
                Utils.Write("Meeting Summary");
                Utils.Write("================");
                Utils.Write("Current Mailbox:  " + m_strMbx);
                Utils.Write("Meeting Role:     " + m_Role);
                Utils.Write("Subject:          " + msg.Subject);
                Utils.Write("Location:         " + msg.Location);
                Utils.Write("Organizer:        " + msg.OrganizerAddr);
                Utils.Write("Sender:           " + msg.SenderAddress);
                Utils.Write("To:               " + msg.AttendeeTo);

                if (!(string.IsNullOrEmpty(msg.ViewStartTime)))
                {
                    Utils.Write("Starting:         " + msg.ViewStartTime);
                }
                else if (!(string.IsNullOrEmpty(m_rbCurrent.RecurStartDateTime)))
                {
                    Utils.Write("Starting:         " + m_rbCurrent.RecurStartDateTime);
                }
                else if (!(string.IsNullOrEmpty(msg.StartWallClock)))
                {
                    Utils.Write("Starting:         " + msg.StartWallClock);
                }
                else
                {
                    Utils.Write("Starting:         " + msg.ApptStartWhole);
                }

                if (!(string.IsNullOrEmpty(msg.ViewEndTime)))
                {
                    Utils.Write("Ending:           " + msg.ViewEndTime);
                }
                else if (!(string.IsNullOrEmpty(m_rbCurrent.RecurEndDateTime)))
                {
                    Utils.Write("Ending:           " + m_rbCurrent.RecurEndDateTime);
                }
                else if (!(string.IsNullOrEmpty(msg.EndWallClock)))
                {
                    Utils.Write("Ending:           " + msg.EndWallClock);
                }
                else
                {
                    Utils.Write("Ending:           " + msg.ApptEndWhole);
                }

                if (!(string.IsNullOrEmpty(msg.RecurPattern)))
                {
                    Utils.Write("Occurring:        " + msg.RecurPattern);
                }

                if (!(string.IsNullOrEmpty(m_rbCurrent.RecurFreq)))
                {
                    string strInfo = m_rbCurrent.RecurFreq;
                    string strCount = "";
                    if (!(string.IsNullOrEmpty(m_rbCurrent.RecurType)))
                    {
                        strInfo += ", " + m_rbCurrent.RecurType;
                        if (m_rbCurrent.RecurType == "No End Date")
                        {
                            strCount = "No End Date";
                        }
                        else
                        {
                            strCount = m_rbCurrent.OccurCount.ToString();
                        }
                    }
                    Utils.Write("Recurrence Info:  " + strInfo);
                    Utils.Write("Recurrence Count: " + strCount);

                }

                Utils.Write("\r\nReported times might or might not be in GMT depending on the property.");
                Utils.Write("Some calculation of these times might need to be done for the time zone adjusted time.");
                Utils.Write("======================================================================================\r\n");
            }
        }

        //
        // check IPM.Appointment items for some props and throw errors as needed
        //
        public static void CheckApptProps(TLMsg msg)
        {
            // if an error is written - do it with different color to attract attention
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;

            // Check that the PidLidRecurring prop is there
            if (string.IsNullOrEmpty(msg.IsRecurring))
            {
                Utils.Write("ERROR: The Recurring property is not set on this item.");
            }
            // Check that the dispidApptRecurring prop is there
            if (string.IsNullOrEmpty(msg.ApptRecurring))
            {
                Utils.Write("ERROR: The Appointment Recurring property is not set on this item.");
            }
            // Check Start time
            if (msg.ApptStartWhole.Contains("01/01/1601") || string.IsNullOrEmpty(msg.ApptStartWhole))
            {
                Utils.Write("ERROR: The Start Date and Time property is not set on this item.");
            }
            // Check End time
            if (msg.ApptEndWhole.Contains("01/01/1601") || string.IsNullOrEmpty(msg.ApptEndWhole))
            {
                Utils.Write("ERROR: The End Date and Time property is not set on this item.");
            }
            // Check Organizer address
            if (string.IsNullOrEmpty(msg.OrganizerAddr))
            {
                Utils.Write("ERROR: Missing Organizer address on this item.");
            }
            // Check Sender address
            if (string.IsNullOrEmpty(msg.SenderAddress))
            {
                Utils.Write("ERROR: Missing Sender address on this item.");
            }
            // Check "IsOrganizer" with ApptStateFlags
            if (!(string.IsNullOrEmpty(msg.IsOrganizer)) && !(string.IsNullOrEmpty(msg.ApptStateFlags)))
            {
                if (msg.IsOrganizer.ToLower() == "false")
                {
                    if (msg.ApptStateFlags == "1")
                    {
                        Utils.Write("ERROR: This user should be an attendee, but properties indicate this user is the Organizer.");
                    }
                }
            }
            // Check the new "IsHijacked" property
            if (!(string.IsNullOrEmpty(msg.IsHijacked)))
            {
                if (msg.IsHijacked.ToLower() == "true")
                {
                    Utils.Write("ERROR: Meeting is set as Hijacked.");
                }
            }
            // Check to see if this is a copied item in the calendar
            if (!(string.IsNullOrEmpty(msg.ApptAuxFlags)))
            {
                string strAuxFlags = msg.ApptAuxFlags;
                Utils.HandleAuxFlags(ref strAuxFlags);

                if (strAuxFlags.Contains("auxApptFlagCopied"))
                {
                    Utils.Write("This Calendar item was copied.");
                }
            }
            // set color back before exiting here
            Console.ResetColor();
        }// CheckApptProps

        //
        // Save the appointment props from the first IPM.Appointment item - used for checking things later 
        //
        public static void SaveInitApptProps(TLMsg msg)
        {

            m_strApptStateFlags = msg.ApptStateFlags;
            m_strApptRecurring = msg.ApptRecurring;
            m_strBusyStatus = msg.BusyStatus;
            m_strEndWhole = msg.ApptEndWhole;
            m_strIsRecurring = msg.IsRecurring;
            m_strLocation = msg.Location;
            m_strOrganizerAddr = msg.OrganizerAddr;
            m_strOrganizerName = msg.OrganizerName;
            m_strSender = msg.SenderAddress;
            m_strStartWhole = msg.ApptStartWhole;
            m_strCc = msg.AttendeeCC;
            m_strTo = msg.AttendeeTo;
            m_strViewEnd = msg.ViewEndTime;
        }

        //
        // Compare the current IPM.Appointment props against the previous and report differences as needed
        //
        public static void CompareApptProps(TLMsg msg)
        {
            if (m_strApptRecurring.ToLower() != msg.ApptRecurring.ToLower())
            {
                if (msg.ApptRecurring.ToLower() == "true")
                {
                    Utils.Write("The item changed from a single-instance meeting to a recurring meeting.");
                }
                else if (msg.ApptRecurring.ToLower() == "false")
                {
                    Utils.Write("The item changed from a recurring meeting to a single-instance meeting.");
                }
                m_strApptRecurring = msg.ApptRecurring;
            }

            if (m_strStartWhole.ToLower() != msg.ApptStartWhole.ToLower())
            {
                Utils.Write("The start time changed from " + m_strStartWhole + " to " + msg.ApptStartWhole);
                m_strStartWhole = msg.ApptStartWhole;
            }

            if (m_strEndWhole.ToLower() != msg.ApptEndWhole.ToLower())
            {
                Utils.Write("The end time changed from " + m_strEndWhole + " to " + msg.ApptEndWhole);
                m_strEndWhole = msg.ApptEndWhole;
            }

            if (m_strViewEnd.ToLower() != msg.ViewEndTime.ToLower())
            {
                Utils.Write("The series final instance end time changed from " + m_strViewEnd + " to " + msg.ViewEndTime);
                m_strViewEnd = msg.ViewEndTime;
            }

            if (m_strOrganizerAddr.ToLower() != msg.OrganizerAddr.ToLower())
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Red;
                Utils.Write("The organizer address changed. This should not happen and is potentially an error.");
                Utils.Write("    Was: " + m_strOrganizerAddr);
                Utils.Write("    Now: " + msg.OrganizerAddr);
                Console.ResetColor();
                m_strOrganizerAddr = msg.OrganizerAddr;
            }

            if (m_strTo.Length != msg.AttendeeTo.Length) // check length - Apple devices switch order of same recips on items
            {
                if (m_strTo.ToLower() != msg.AttendeeTo.ToLower())
                {
                    Utils.Write("The attendee list (To: line) changed.");
                    Utils.Write("    Was: " + m_strTo);
                    Utils.Write("    Now: " + msg.AttendeeTo);
                    m_strTo = msg.AttendeeTo;
                }
            }

            if (m_strCc.Length != msg.AttendeeCC.Length) // check length - Apple devices switch order of same recips on items
            {
                if (m_strCc.ToLower() != msg.AttendeeCC.ToLower())
                {
                    Utils.Write("The attendee list (Cc: line) changed.");
                    Utils.Write("    Was: " + m_strCc);
                    Utils.Write("    Now: " + msg.AttendeeCC);
                    m_strCc = msg.AttendeeCC;
                }
            }

            if (m_strBusyStatus != msg.BusyStatus)
            {
                string strBusyLast = m_strBusyStatus;
                string strBusyNow = msg.BusyStatus;
                Utils.HandleBusyStatus(ref strBusyLast);
                Utils.HandleBusyStatus(ref strBusyNow);

                Utils.Write("The Free Busy Status changed from " + strBusyLast + " to " + strBusyNow);

                if (msg.BusyStatus == "0")
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (m_strBusyStatus == "2")
                    {
                        Utils.Write("This previously accepted item has been declined or deleted from this user's Calendar.");
                    }
                    if (m_strBusyStatus == "1")
                    {
                        Utils.Write("The tentative item has been declined or deleted from this user's Calendar.");
                    }
                    Console.ResetColor();
                }

                m_strBusyStatus = msg.BusyStatus;
            }

            if (m_strApptStateFlags != msg.ApptStateFlags)
            {
                string strASFLast = m_strApptStateFlags;
                string strASFNow = msg.ApptStateFlags;
                Utils.HandleASF(ref strASFLast);
                Utils.HandleASF(ref strASFNow);

                Utils.Write("The Appointment State changed from " + strASFLast + " to " + strASFNow);
                m_strApptStateFlags = msg.ApptStateFlags;

                if (msg.ApptStateFlags == "1")
                {
                    if (m_strApptStateFlags == "3")
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Utils.Write("ERROR: This user was set as an attendee, and is now set as the Organizer.");
                        Console.ResetColor();
                    }
                }
            }

            if (m_strLocation.ToLower() != msg.Location.ToLower())
            {
                Utils.Write("The location of the meeting changed.");
                Utils.Write("    Was: " + m_strLocation);
                Utils.Write("    Now: " + msg.Location);
                m_strLocation = msg.Location;
            }
        }

        //
        // Main analysis function to write out timeline
        //
        public static void AnalyzeForTimeline(TLMsg msg)
        {
            string strMsgNum = m_iMsgNum.ToString();
            bool bIsDelegate = false;

            if (msg.SenderAddress != msg.OrganizerAddr)
                bIsDelegate = true;


            // write out the time of this item on screen
            if (!(string.IsNullOrEmpty(msg.OrigLastModTime)))
            {
                Utils.Write(strMsgNum + " - " + msg.OrigLastModTime);
                m_iMsgNum++;
            }
            else if (!(string.IsNullOrEmpty(msg.LastModTime)))
            {
                Utils.Write(strMsgNum + " - " + msg.LastModTime);
                m_iMsgNum++;
            }

            // write out the message class
            if (!(string.IsNullOrEmpty(msg.ItemMsgClass)))
            {
                if (!(rgstrMsgClasses.Contains(msg.ItemMsgClass)))
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Utils.Write(msg.ItemMsgClass + " item.");
                    if (m_bExtMsgClass == false)
                    {
                        Utils.Write("This is a third party customized and/or proprietary Message Class.");
                        Utils.Write("The timeline analysis might show incorrect or incomplete results due to this.");
                        m_bExtMsgClass = true;
                    }
                    Console.ResetColor();
                }
                else
                {
                    Utils.Write(msg.ItemMsgClass + " item.");
                }
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Red;
                Utils.Write("ERROR: No Message Class is set on this item.");
                Console.ResetColor();
            }

            // write out the responsible user - the user who made this change
            if (!(string.IsNullOrEmpty(msg.ResponsibleUser)))
            {
                Utils.Write("User that performed the action/change on this instance of the item:\r\n   " + msg.ResponsibleUser);
            }

            // do some things with IPM.Appointment items
            if (msg.ItemMsgClass.Contains("IPM.Appointment"))
            {
                // check for some props and throw errors as needed
                CheckApptProps(msg);

                // Save off initial props and check later in order to update the timeline
                if (m_bInitPropsSaved == false)
                {
                    SaveInitApptProps(msg);
                    m_bInitPropsSaved = true;
                }
                else
                {
                    CompareApptProps(msg);
                }
            }

            // Now analyze the current message and write out info to the screen

            if (msg.ItemMsgClass.Contains("IPM.Appointment"))
            {
                if (msg.TriggerAction == "Create")
                {
                    if (msg.BusyStatus == "0")
                    {
                        if (msg.ApptStateFlags == "7" && msg.IsException == "False")
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Red;
                            WriteStdOutput(msg, "The item has been cancelled and freed from the Calendar by ");
                            Console.ResetColor();
                        }
                    }
                    else if (msg.BusyStatus == "1")
                    {
                        WriteStdOutput(msg, "A tentative item was created on the Calendar by ");
                    }
                    else if (msg.BusyStatus == "2")
                    {
                        if (m_Role == "Organizer")
                        {
                            if (msg.ApptStateFlags == "1" || msg.ApptStateFlags == "0")
                            {
                                m_bFirstItem = false;
                                m_bAccepted = true;
                                if (bIsDelegate)
                                {
                                    WriteStdOutput(msg, "Organizer's Calendar. Delegate created the item in the Calendar using ");
                                }
                                else
                                {
                                    WriteStdOutput(msg, "Organizer's Calendar. The item was created in the Calendar by ");
                                }
                            }
                        }
                        else
                        {
                            if (msg.ClientInfoString.Contains("Hub Transport"))
                            {
                                OutputApptUpdate(msg, "the Calendar Assistant.");
                            }
                            else if (msg.ClientInfoString.Contains("MSExchangeRPC"))
                            {
                                OutputApptUpdate(msg, "Outlook.");
                            }
                            else if (msg.ClientInfoString.Contains("Client=OWA"))
                            {
                                OutputApptUpdate(msg, "OWA (Outlook Web App).");
                            }
                            else if (msg.ClientInfoString.Contains("CalendarRepairAssistant"))
                            {
                                OutputApptUpdate(msg, "the Calendar Repair Assistant.");
                            }
                            else if (msg.ClientInfoString.Contains("MacOutlook"))
                            {
                                OutputApptUpdate(msg, "Mac Outlook.");
                            }
                            else if (msg.ClientInfoString.Contains("MSExchangeMailboxAssistants"))
                            {
                                OutputApptUpdate(msg, "the Mailbox Assistant.");
                            }
                            else
                            {
                                OutputApptUpdate(msg, "the following client:");
                            }
                        }
                    }
                } // Appointment > Create

                if (msg.TriggerAction == "Update")
                {
                    if (msg.BusyStatus == "0")
                    {
                        if (msg.ApptStateFlags == "7" && msg.IsException == "False")
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Red;
                            WriteStdOutput(msg, "The item has been cancelled and freed from the Calendar by ");
                            Console.ResetColor();
                        }
                    }
                    if (msg.BusyStatus == "1")
                    {
                        WriteStdOutput(msg, "The tentative item was updated in the Calendar by ");
                    }
                    if (msg.BusyStatus == "2")
                    {
                        if (msg.ClientInfoString.Contains("Hub Transport"))
                        {
                            OutputApptUpdate(msg, "the Calendar Assistant.");
                        }
                        else if (msg.ClientInfoString.Contains("MSExchangeRPC"))
                        {
                            OutputApptUpdate(msg, "Outlook.");
                        }
                        else if (msg.ClientInfoString.Contains("Client=OWA"))
                        {
                            OutputApptUpdate(msg, "OWA (Outlook Web App).");
                        }
                        else if (msg.ClientInfoString.Contains("CalendarRepairAssistant"))
                        {
                            OutputApptUpdate(msg, "the Calendar Repair Assistant.");
                        }
                        else if (msg.ClientInfoString.Contains("MacOutlook"))
                        {
                            OutputApptUpdate(msg, "Mac Outlook.");
                        }
                        else if (msg.ClientInfoString.Contains("MSExchangeMailboxAssistants"))
                        {
                            OutputApptUpdate(msg, "the Mailbox Assistant.");
                        }
                        else
                        {
                            OutputApptUpdate(msg, "the following client:");
                        }
                    }
                } // Appointment > Update

                if (msg.TriggerAction == "MoveToDeletedItems")
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Red;
                    WriteStdOutput(msg, "The item was deleted from the Calendar by ");
                    Console.ResetColor();
                    ResetAfterDelete();
                }

                if (msg.TriggerAction == "SoftDelete")
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Red;
                    WriteStdOutput(msg, "The item was deleted from the Calendar by ");
                    Console.ResetColor();
                    ResetAfterDelete();

                } // Appointment > SoftDelete

                if (msg.TriggerAction == "HardDelete")
                {
                    bool bReset = true;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Red;
                    if (msg.ClientInfoString.Contains("MSExchangeRPC"))
                    {
                        Console.ResetColor();
                        if (m_bOLProcessedLast == true && m_bOLProcessedItem == false) // initial processing in Outlook does a hard delete of a "ghost" appointment
                        {
                            Utils.Write("Outlook processed the Calendar item.");
                            m_bOLProcessedLast = false;
                            m_bOLProcessedItem = true;
                            bReset = false;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Utils.Write("The item was deleted from the Calendar by Outlook.");
                            Utils.Write("This could be expected due to initial processing of the item when the meeting request first arrived.");
                            bReset = false;
                        }
                    }
                    else if (msg.ClientInfoString.Contains("Management"))
                    {
                        if (msg.ClientInfoString.Contains("E-Discovery"))
                        {
                            Utils.Write("The item was deleted from the Calendar by Exchange Management via the Search-Mailbox powershell cmdlet.");
                        }
                        else
                        {
                            Utils.Write("The item was deleted from the Calendar by Exchange Management.");
                        }
                    }
                    else
                    {
                        WriteStdOutput(msg, "The item was deleted from the Calendar by ");
                    }
                    Console.ResetColor();
                    if (bReset == true)
                    {
                        ResetAfterDelete();
                    }
                } // Appointment > HardDelete

                // Do stuff with the recurrence blob if this is a recurring appointment
                if (msg.ApptRecurring.ToLower() == "true")
                {
                    // Do the whole copy current to previous and make a new current thing
                    CopyRecurBlob(m_rbCurrent, m_rbPrevious);
                    ClearRecurBlob(m_rbCurrent);
                    CreateCurrentRecurObject(msg);

                    // if any changes to the recurrence blob then do stuff - otherwise no need to do anything
                    if (m_rbPrevious.HexBlob != m_rbCurrent.HexBlob)
                    {
                        CompareRBs(m_rbPrevious, m_rbCurrent);
                    }
                    // Write "current" Recurrence blob out to the log
                    if (rgstrCalNames.Contains(msg.ParentFolder.ToLower()))
                    {
                        StringReader srRbCurr = new StringReader(m_rbCurrent.ParsedBlob);
                        string strCurr = "";

                        Utils.FileWrite("\r\n================================================");
                        Utils.FileWrite("Reccurrence Data From This IPM.Appointment Item");
                        Utils.FileWrite("This is the item currently in the Calendar.");
                        Utils.FileWrite("================================================");
                        Utils.FileWrite("");
                        while ((strCurr = srRbCurr.ReadLine()) != null)
                        {
                            Utils.FileWrite(strCurr);
                        }
                        Utils.FileWrite("");
                    }
                }
            }

            if (msg.ItemMsgClass.Contains("IPM.Schedule.Meeting.Request"))
            {
                if (msg.TriggerAction == "Create")
                {
                    if (msg.IsException == "True")
                    {
                        if (m_Role == "Organizer")
                        {
                            if (bIsDelegate)
                            {
                                Utils.Write("The Organizer's Delegate created a Meeting Exception Request.");
                            }
                            else
                            {
                                Utils.Write("Organizer's Calendar. Organizer created a Meeting Exception Request.");
                            }
                        }
                        else if (m_Role == "Delegate")
                        {
                            Utils.Write("The Organizer's Delegate created a Meeting Exception Request.");
                        }
                        else
                        {
                            if (bIsDelegate)
                            {
                                Utils.Write("Received a Meeting Exception Request from the Organizer's Delegate.");
                            }
                            else
                            {
                                Utils.Write("Received a Meeting Exception Request from the Organizer.");
                            }
                        }
                        Utils.Write("   Start Time of Exception: " + msg.ApptStartWhole);
                        Utils.Write("   End Time of Exception  : " + msg.ApptEndWhole);
                    }
                    else
                    {
                        if (m_Role == "Organizer")
                        {
                            if (bIsDelegate)
                            {
                                Utils.Write("The Organizer's Delegate created a Meeting Request.");
                            }
                            else
                            {
                                Utils.Write("Organizer's Calendar. Organizer created a Meeting Request.");
                            }
                        }
                        else if (m_Role == "Delegate")
                        {
                            Utils.Write("The Organizer's Delegate created a Meeting Request.");
                        }
                        else
                        {
                            if (bIsDelegate)
                            {
                                Utils.Write("Received a Meeting Request from the Organizer's Delegate.");
                            }
                            else
                            {
                                Utils.Write("Received a Meeting Request from the Organizer.");
                            }
                        }
                    }
                }

                if (msg.TriggerAction == "Update")
                {
                    if (msg.ParentFolder == "Sent Items")
                    {
                        Utils.Write("The Meeting Request was sent and placed in the Sent Items folder.");
                    }
                    if (msg.IsProcessed.ToLower() == "true")
                    {
                        Utils.Write("Outlook auto-processing completed on the Meeting Request.");
                        m_bOLProcessedLast = true;
                    }
                }

                if (msg.TriggerAction == "MoveToDeletedItems")
                {
                    Utils.Write("The Meeting Request was moved to deleted items - usually as a result of Accepting/Declining the request.");
                }

                if (msg.TriggerAction == "Move")
                {
                    if (m_Role == "Organizer")
                    {
                        Utils.Write("Organizer's Calendar. Organizer sent the Meeting Request.");
                    }
                    if (m_Role == "Delegate")
                    {
                        Utils.Write("Organizer's Delegate sent the Meeting Request.");
                    }
                }
            }

            if (msg.ItemMsgClass.Contains("IPM.Schedule.Meeting.Canceled"))
            {
                if (msg.TriggerAction == "Create")
                {
                    if (msg.IsException == "True")
                    {
                        if (m_Role == "Organizer")
                        {
                            if (bIsDelegate)
                            {
                                Utils.Write("The Organizer's Delegate created a Cancelation Exception to the series.");
                            }
                            else
                            {
                                Utils.Write("Organizer's Calendar. Organizer created a Cancelation Exception to the series.");
                            }
                        }
                        else if (m_Role == "Delegate")
                        {
                            Utils.Write("The Organizer's Delegate created a Cancelation Exception to the series.");
                        }
                        else
                        {
                            if (bIsDelegate)
                            {
                                Utils.Write("Received a Cancelation Exception from the Organizer's Delegate.");
                            }
                            else
                            {
                                Utils.Write("Received a Cancelation Exception from the Organizer.");
                            }
                        }
                        Utils.Write("   Start Time for Cancelation Exception: " + msg.ApptStartWhole);
                        Utils.Write("   End Time for Cancelation Exception  : " + msg.ApptEndWhole);
                    }
                    else
                    {
                        if (m_Role == "Organizer")
                        {
                            if (bIsDelegate)
                            {
                                Utils.Write("Organizer's Delegate created the Meeting Cancelation for the entire series.");
                            }
                            else
                            {
                                Utils.Write("Organizer's Calendar. Organizer created the Meeting Cancelation for the entire series.");
                            }
                        }
                        else if (m_Role == "Delegate")
                        {
                            Utils.Write("Organizer's Delegate created the Meeting Cancelation for the entire series.");
                        }
                        else
                        {
                            if (bIsDelegate)
                            {
                                Utils.Write("Received a Meeting Cancelation for the entire meeting series from the Organizer's Delegate.");
                            }
                            else
                            {
                                Utils.Write("Received a Meeting Cancelation for the entire meeting series from the Organizer.");
                            }
                        }
                    }
                }

                if (msg.TriggerAction == "Move")
                {
                    if (m_Role == "Organizer")
                    {
                        if (bIsDelegate)
                        {
                            Utils.Write("Organizer's Delegate sent the Cancelation.");
                        }
                        else
                        {
                            Utils.Write("Organizer's Calendar. Organizer sent the Cancelation.");
                        }
                    }
                    if (m_Role == "Delegate")
                    {
                        Utils.Write("Organizer's Delegate sent the Cancelation.");
                    }
                }
                if (msg.TriggerAction == "MoveToDeletedItems")
                {
                    Utils.Write("The Meeting Cancelation item was moved to Deleted Items - usually as a result of interacting with the Cancelation item in the Inbox.");
                    if (msg.IsException.ToLower() == "true")
                    {
                        Utils.Write("   Start Time for Cancelation Exception: " + msg.ApptStartWhole);
                        Utils.Write("   End Time for Cancelation Exception  : " + msg.ApptEndWhole);
                    }
                }
                if (msg.TriggerAction == "Update")
                {
                    if (msg.IsProcessed.ToLower() == "true")
                    {
                        Utils.Write("The Meeting Cancelation was processed by Outlook.");
                    }
                    else
                    {
                        Utils.Write("The Meeting Cancelation was updated.");
                    }
                    if (msg.IsException.ToLower() == "true")
                    {
                        Utils.Write("   Start Time for Cancelation Exception: " + msg.ApptStartWhole);
                        Utils.Write("   End Time for Cancelation Exception  : " + msg.ApptEndWhole);
                    }
                }
            }

            if (msg.ItemMsgClass.Contains("IPM.Schedule.Meeting.Resp.Pos"))
            {
                RequestResponse(msg, "Accept");
            }

            if (msg.ItemMsgClass.Contains("IPM.Schedule.Meeting.Resp.Neg"))
            {
                RequestResponse(msg, "Decline");
            }

            if (msg.ItemMsgClass.Contains("IPM.Schedule.Meeting.Resp.Tent"))
            {
                RequestResponse(msg, "Tentative");
            }

            if (msg.ItemMsgClass.Contains("IPM.Schedule.Meeting.Notification.Forward"))
            {
                if (msg.TriggerAction == "Create")
                {
                    if (m_strApptRecurring.ToLower() == "true")
                    {
                        if (msg.ApptRecurring.ToLower() == "true")
                        {
                            Utils.Write("The meeting was forwarded.");
                        }
                        else
                        {
                            Utils.Write("An instance of the Meeting Series was forwarded:");
                            Utils.Write("   Start       : " + msg.ApptStartWhole);
                            Utils.Write("   End         :   " + msg.ApptEndWhole);
                        }
                    }
                    else
                    {
                        Utils.Write("The meeting was forwarded.");
                    }

                    Utils.Write("   Forwarded by: " + msg.OrganizerName);
                }
            }

            // separator before the next item
            Utils.Write("------------\r\n");
        }

        //
        // Create and write out the Meeting info and Timeline
        //
        public static void CreateTimeline(DataSet ds)
        {
            if (ds.Tables.Count > 0)
            {
                // See if the meeting item designates this user as the organizer
                foreach (DataTable dt in ds.Tables)
                {
                    string strClass = MsgData.GetProp(dt, "ItemClass");
                    string strASF = MsgData.GetProp(dt, "AppointmentState");

                    if (!(string.IsNullOrEmpty(strClass)))
                    {
                        if (strClass.Contains("IPM.Appointment"))
                        {
                            if (!(string.IsNullOrEmpty(strASF)))
                            {
                                if (strASF == "1")
                                {
                                    m_bOrganizer = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                // if not set as organizer for Meeting type, try testing for Single Appointment (if so then still technically the Organizer)
                if (m_bOrganizer == false)
                {
                    foreach (DataTable dt in ds.Tables)
                    {
                        string strClass = MsgData.GetProp(dt, "ItemClass");
                        string strASF = MsgData.GetProp(dt, "AppointmentState");

                        if (!(string.IsNullOrEmpty(strClass)))
                        {
                            if (strClass.Contains("IPM.Appointment"))
                            {
                                if (!(string.IsNullOrEmpty(strASF)))
                                {
                                    if (strASF == "0")
                                    {
                                        m_bOrganizer = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

                foreach (DataTable dt in ds.Tables)
                {
                    string strClass = MsgData.GetProp(dt, "ItemClass");
                    string strApptRecur = MsgData.GetProp(dt, "AppointmentRecurring");

                    if (!(string.IsNullOrEmpty(strClass)))
                    {
                        if (strClass.Contains("IPM.Appointment"))
                        {
                            if (m_bHeader == false)
                            {
                                // this should be the first IPM.Appt item, so if recurring then make the first recur blob object 
                                if (strApptRecur.ToLower() == "true")
                                {
                                    CreateCurrentRecurObject(new TLMsg(dt));
                                }
                                WriteHeaderInfo(new TLMsg(dt));
                                m_bHeader = true;
                            }
                            break;
                        }
                    }
                }
                // Inform this is probably a delegate, and try to get header info from the first non-exception Meeting Request - which is not ideal and might not populate anyway.
                if (m_bHeader == false)
                {
                    Utils.Write("\r\n===========================================================================");
                    Utils.Write("No IPM.Appointment item (Calendar folder item) was found in this data set.");
                    Utils.Write("This can be expected for Delegate mailboxes.");
                    Utils.Write("===========================================================================\r\n");

                    m_DelCheck = true;

                    foreach (DataTable dt in ds.Tables)
                    {
                        string strClass = MsgData.GetProp(dt, "ItemClass");

                        if (!(string.IsNullOrEmpty(strClass)))
                        {
                            if (strClass.Contains("IPM.Schedule.Meeting.Request"))
                            {
                                string strType = MsgData.GetProp(dt, "IsException");
                                if (!string.IsNullOrEmpty(strType))
                                {
                                    if (strType.ToLower() == "false")
                                    {
                                        WriteHeaderInfo(new TLMsg(dt));
                                        m_bHeader = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

                // We're about to do the actual timeline, so put up a header for it
                Utils.Write("=======================");
                Utils.Write("Timeline For This Item");
                Utils.Write("=======================\r\n");

                // Now look at each message (table) and do analysis and write that to the screen
                foreach (DataTable dt in ds.Tables)
                {
                    AnalyzeForTimeline(new TLMsg(dt));
                }
            }
        }


        //
        // Create Current RecurBlob Object
        //
        public static void CreateCurrentRecurObject(TLMsg msg)
        {
            if (!(string.IsNullOrEmpty(msg.ApptRecurBlob)))
            {
                m_rbCurrent.HexBlob = msg.ApptRecurBlob;
                string strParsedRB = msg.GetProp("AppointmentRecurrenceBlob", "SmartVal");
                m_rbCurrent.ParsedBlob = strParsedRB;

                if (!(string.IsNullOrEmpty(strParsedRB)))
                {
                    StringReader srRB = new StringReader(strParsedRB);
                    string strLine = "";
                    while ((strLine = srRB.ReadLine()) != null)
                    {
                        if (strLine.Contains("EndType:"))
                        {
                            if (strLine.Contains("IDC_RCEV_PAT_ERB_NOEND"))
                            {
                                m_rbCurrent.RecurType = "No End Date";
                            }
                            if (strLine.Contains("IDC_RCEV_PAT_ERB_END"))
                            {
                                m_rbCurrent.RecurType = "Ends On Specific Date";
                            }
                            if (strLine.Contains("IDC_RCEV_PAT_ERB_AFTERNOCCUR"))
                            {
                                m_rbCurrent.RecurType = "Ends After Specific Number Of Occurrences";
                            }
                        }
                        if (strLine.Contains("RecurFrequency:"))
                        {
                            if (strLine.Contains("IDC_RCEV_PAT_ORB_DAILY"))
                            {
                                m_rbCurrent.RecurFreq = "Daily";
                            }
                            if (strLine.Contains("IDC_RCEV_PAT_ORB_WEEKLY"))
                            {
                                m_rbCurrent.RecurFreq = "Weekly";
                            }
                            if (strLine.Contains("IDC_RCEV_PAT_ORB_MONTHLY"))
                            {
                                m_rbCurrent.RecurFreq = "Monthly";
                            }
                            if (strLine.Contains("IDC_RCEV_PAT_ORB_YEARLY"))
                            {
                                m_rbCurrent.RecurFreq = "Yearly";
                            }
                        }
                        if (strLine.Contains("OccurrenceCount:"))
                        {
                            m_rbCurrent.OccurCount = RecurBlob.GetCountFromString(strLine);
                        }
                        if (strLine.Contains("DeletedInstanceCount:"))
                        {
                            m_rbCurrent.DelInstCount = RecurBlob.GetCountFromString(strLine);
                        }
                        if (strLine.Contains("ModifiedInstanceCount:"))
                        {
                            m_rbCurrent.ModInstCount = RecurBlob.GetCountFromString(strLine);
                        }
                        if (strLine.Contains("ExceptionCount:"))
                        {
                            m_rbCurrent.ExceptionCount = RecurBlob.GetCountFromString(strLine);
                        }
                        if (strLine.StartsWith("StartDate:"))
                        {
                            m_rbCurrent.RecurStartDate = RecurBlob.GetDateFromString(strLine);
                        }
                        if (strLine.StartsWith("EndDate:"))
                        {
                            m_rbCurrent.RecurEndDate = RecurBlob.GetDateFromString(strLine);
                        }
                        if (strLine.StartsWith("StartTimeOffset:"))
                        {
                            m_rbCurrent.RecurStartTime = RecurBlob.GetTimeFromString(strLine);
                        }
                        if (strLine.StartsWith("EndTimeOffset:"))
                        {
                            m_rbCurrent.RecurEndTime = RecurBlob.GetTimeFromString(strLine);
                        }
                        m_rbCurrent.RecurStartDateTime = m_rbCurrent.RecurStartDate + " " + m_rbCurrent.RecurStartTime;
                        m_rbCurrent.RecurEndDateTime = m_rbCurrent.RecurEndDate + " " + m_rbCurrent.RecurEndTime;
                    } // while
                }
            }
        }

        public static void CopyRecurBlob(RecurBlob rb1, RecurBlob rb2)
        {
            rb2.HexBlob = rb1.HexBlob;
            rb2.ParsedBlob = rb1.ParsedBlob;
            rb2.ExceptionCount = rb1.ExceptionCount;
            rb2.DelInstCount = rb1.DelInstCount;
            rb2.ModInstCount = rb1.ModInstCount;
            rb2.OccurCount = rb1.OccurCount;
            rb2.RecurType = rb1.RecurType;
            rb2.RecurFreq = rb1.RecurFreq;
            rb2.RecurStartDate = rb1.RecurStartDate;
            rb2.RecurStartTime = rb1.RecurStartTime;
            rb2.RecurStartDateTime = rb1.RecurStartDateTime;
            rb2.RecurEndDate = rb1.RecurEndDate;
            rb2.RecurEndTime = rb1.RecurEndTime;
            rb2.RecurEndDateTime = rb1.RecurEndDateTime;
        }

        //
        // Reset a recur blob object
        //
        public static void ClearRecurBlob(RecurBlob rb)
        {
            rb.HexBlob = "";
            rb.ParsedBlob = "";
            rb.ExceptionCount = 0;
            rb.DelInstCount = 0;
            rb.ModInstCount = 0;
            rb.OccurCount = 0;
            rb.RecurType = "";
            rb.RecurFreq = "";
            rb.RecurStartDate = "";
            rb.RecurStartTime = "";
            rb.RecurStartDateTime = "";
            rb.RecurEndDate = "";
            rb.RecurEndTime = "";
            rb.RecurEndDateTime = "";
        }

        public static void CompareRBs(RecurBlob rbPrev, RecurBlob rbCurr)
        {
            string[] rgDel = new string[10 + (rbCurr.DelInstCount * 2)];
            string[] rgMod = new string[10 + (rbCurr.ModInstCount * 2)];
            string[] rgExInfo = new string[1000];
            string[] rgOutExInfo = new string[1000];
            string[] rgOutDel = new string[10 + (rbCurr.DelInstCount * 2)];
            string[] rgOutMod = new string[10 + (rbCurr.ModInstCount * 2)];
            string strTemp1 = "";
            string strTemp2 = "";
            int iPos1 = 0;
            int iPos2 = 0;
            int cDel = 0;
            int cOutDel = 0;
            int cOutMod = 0;
            int cMod = 0;
            int cExInfo = 0;
            int cOutExInfo = 0;
            bool bValidDelete = false;
            string strDeletedMod = "";
            StringReader srRbPrev = new StringReader(rbPrev.ParsedBlob);
            string strPrev = "";
            StringReader srRbCurr = new StringReader(rbCurr.ParsedBlob);
            string strCurr = "";


            // if recurrence type / frequency changed then the exceptions are all removed...
            if (rbPrev.RecurType != rbCurr.RecurType || rbPrev.OccurCount != rbCurr.OccurCount)
            {
                Utils.Write("The Recurrence Type changed or the number of occurrences in the series changed, so all Exceptions in the series have been removed.");
                Utils.Write("   Old Recurrence Type:  " + rbPrev.RecurType);
                if (rbPrev.RecurType == "No End Date")
                {
                    Utils.Write("   Old Recurrence Count: No End Date");
                }
                else
                {
                    Utils.Write("   Old Recurrence Count: " + rbPrev.OccurCount.ToString());
                }
                Utils.Write("   New Recurrence Type:  " + rbCurr.RecurType);
                if (rbCurr.RecurType == "No End Date")
                {
                    Utils.Write("   New Recurrence Count: No End Date");
                }
                else
                {
                    Utils.Write("   New Recurrence Count: " + rbCurr.OccurCount.ToString());
                }
            }
            else if (rbPrev.RecurType == rbCurr.RecurType || rbPrev.OccurCount == rbCurr.OccurCount) // there might be differences in exception data...
            {
                if (!(rbPrev.HexBlob.Length > rbCurr.HexBlob.Length))
                {
                    // Populate the Previous interation's data for Mods/Deletes/ExceptionInfo to some variables
                    while ((strPrev = srRbPrev.ReadLine()) != null)
                    {
                        if (strPrev.Contains("DeletedInstanceDates"))
                        {
                            iPos1 = strPrev.IndexOf(':');
                            strTemp1 = strPrev.Substring(iPos1 + 2);
                            rgDel.SetValue(strTemp1, cDel);
                            cDel++;
                        }
                        if (strPrev.Contains("ModifiedInstanceDates"))
                        {
                            iPos1 = strPrev.IndexOf(':');
                            strTemp1 = strPrev.Substring(iPos1 + 2);
                            rgMod.SetValue(strTemp1, cMod);
                            cMod++;
                        }
                        if (strPrev.Contains("ExceptionInfo"))
                        {
                            rgExInfo.SetValue(strPrev, cExInfo);
                            cExInfo++;
                        }
                        strTemp1 = "";
                        iPos1 = 0;
                    }
                    // Check to see if an instance deletion occurred using modified instances
                    if (rbPrev.ModInstCount != 0 && !(rbPrev.ModInstCount > rbCurr.ModInstCount))
                    {
                        string[] rgstrCurr = new string[100];
                        int iCount = 0;
                        bool bDelMod = false;

                        foreach (string strException in rgExInfo)
                        {
                            if (!(string.IsNullOrEmpty(strException)))
                            {
                                if (strException.Contains("asfCancelled"))
                                {
                                    bValidDelete = true;
                                    break;
                                }
                            }
                        }
                        if (rbCurr.ModInstCount == 0)
                        {
                            // There was only 1 exception before - so that is the one...
                            if (!(string.IsNullOrEmpty(rgMod[0].ToString())))
                            {
                                strDeletedMod = rgMod[0].ToString();
                            }
                        }
                        else
                        {
                            // go find the exception to output if it's there
                            while ((strCurr = srRbPrev.ReadLine()) != null)
                            {
                                if (strCurr.Contains("ModifiedInstanceDates"))
                                {
                                    rgstrCurr.SetValue(strCurr, iCount);
                                    iCount++;
                                }

                                foreach (string strMod in rgMod)
                                {
                                    if (!(string.IsNullOrEmpty(strMod)))
                                    {
                                        bDelMod = false;
                                        foreach (string strCheck in rgstrCurr)
                                        {
                                            if (!(string.IsNullOrEmpty(strCheck)))
                                            {
                                                if (strCheck.Contains(strMod))
                                                {
                                                    bDelMod = true;
                                                }
                                            }
                                        }
                                        if (bDelMod == false)
                                        {
                                            strDeletedMod = strMod;
                                        }
                                    }
                                }
                            }
                        }
                        if (strDeletedMod != "")
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Red;
                            if (bValidDelete == true)
                            {
                                Utils.Write("One or more occurrences of this meeting was canceled and removed: ");
                            }
                            else
                            {
                                Utils.Write("One or more occurrences of this meeting was deleted: ");
                            }
                            Utils.Write(strDeletedMod);
                            Console.ResetColor();
                        }
                    } // if ModInstCount check

                    // Now check for new exceptions to add
                    while ((strCurr = srRbCurr.ReadLine()) != null)
                    {
                        if (strCurr.Contains("DeletedInstanceDates"))
                        {
                            iPos2 = strCurr.IndexOf(':');
                            strTemp2 = strCurr.Substring(iPos2 + 2);
                            if (!(rgDel.Contains(strTemp2)))
                            {
                                strTemp2 = RecurBlob.GetDateFromString(strTemp2);
                                rgOutDel.SetValue("Deleted Instance: " + strTemp2, cOutDel);
                                cOutDel++;
                            }
                            strTemp2 = "";
                        }
                        if (strCurr.Contains("ModifiedInstanceDates"))
                        {
                            iPos2 = strCurr.IndexOf(':');
                            strTemp2 = strCurr.Substring(iPos2 + 2);
                            if (!(rgMod.Contains(strTemp2)))
                            {
                                strTemp2 = RecurBlob.GetDateFromString(strTemp2);
                                rgOutMod.SetValue("Modified Instance: " + strTemp2, cOutMod);
                                cOutMod++;
                            }
                            strTemp2 = "";
                        }
                        if (strCurr.Contains("ExceptionInfo"))
                        {
                            if (rbPrev.ExceptionCount == 0)
                            {
                                rgOutExInfo.SetValue(strCurr, cOutExInfo);
                                cOutExInfo++;
                            }
                            else
                            {
                                bool bNew = true;

                                foreach (string strCheck in rgExInfo)
                                {
                                    if (!(string.IsNullOrEmpty(strCheck)))
                                    {
                                        if (strCheck == strCurr)
                                        {
                                            bNew = false;
                                        }
                                    }
                                }
                                if (bNew == true)
                                {
                                    rgOutExInfo.SetValue(strCurr, cOutExInfo);
                                    cOutExInfo++;
                                    bNew = false;
                                }
                            }
                        }
                    }
                    // write the new stuff out to the Timeline
                    if (cOutDel > 0 || cOutMod > 0 || cOutExInfo > 0)
                    {
                        bool bDels = false;
                        Utils.Write("   Updated Exception Info:");
                        if (cOutDel > 0)
                        {
                            if (cOutMod == 0 || cOutDel > cOutMod)
                            {
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Utils.Write("    One or more occurrences of this meeting was deleted.");
                                bDels = true;
                                foreach (string strOut in rgOutDel)
                                {
                                    if (!(string.IsNullOrEmpty(strOut)))
                                    {
                                        Utils.Write("    " + strOut);
                                    }
                                }
                                Console.ResetColor();
                            }
                            else
                            {
                                foreach (string strOut in rgOutDel)
                                {
                                    if (!(string.IsNullOrEmpty(strOut)))
                                    {
                                        Utils.Write("    " + strOut);
                                    }
                                }
                            }

                        }
                        if (cOutMod > 0)
                        {
                            if (bDels == true)
                            {
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Utils.Write("    Deleted instances not matching up with a modified date below were deleted.");
                            }
                            foreach (string strOut in rgOutMod)
                            {
                                if (!(string.IsNullOrEmpty(strOut)))
                                {
                                    Utils.Write("    " + strOut);
                                }
                            }
                            Console.ResetColor();
                        }
                        if (cOutExInfo > 0)
                        {
                            Utils.Write("\r\n    Exception info below describes changes to modified instances.");
                            Utils.Write("    =============================================================");
                            foreach (string strOut in rgOutExInfo)
                            {
                                if (!(string.IsNullOrEmpty(strOut)))
                                {
                                    Utils.Write("    " + strOut);
                                }
                            }
                        }
                    }
                }
            }
        }

        //
        // Write standard output for various client types
        //
        public static void WriteStdOutput(TLMsg msg, string strLine)
        {
            if (msg.ClientInfoString.Contains("MSExchangeRPC"))
            {
                Utils.Write(strLine + "Outlook.");
            }
            else if (msg.ClientInfoString.Contains("Hub Transport"))
            {
                Utils.Write(strLine + "the Calendar Assistant.");
            }
            else if (msg.ClientInfoString.Contains("CalendarRepairAssistant"))
            {
                Utils.Write(strLine + "the Calendar Repair Assistant.");
            }
            else if (msg.ClientInfoString.Contains("MSExchangeMailboxAssistants"))
            {
                Utils.Write(strLine + "the Mailbox Assistant.");
            }
            else if (msg.ClientInfoString.Contains("MacOutlook"))
            {
                Utils.Write(strLine + "a Mac Outlook client.");
            }
            else if (msg.ClientInfoString.Contains("Client=OWA"))
            {
                Utils.Write(strLine + "OWA (Outlook Web App).");
            }
            else if (msg.ClientInfoString.Contains("Apple"))
            {
                Utils.Write(strLine + "an Apple Device.");
                Utils.Write("Client Info String: " + msg.ClientInfoString);
            }
            else if (msg.ClientInfoString.Contains("Android"))
            {
                Utils.Write(strLine + "an Android Device.");
                Utils.Write("Client Info String: " + msg.ClientInfoString);
            }
            else if (msg.ClientInfoString.Contains("DeviceType=WP"))
            {
                Utils.Write(strLine + "a Windows Phone.");
                Utils.Write("Client Info String: " + msg.ClientInfoString);
            }
            else if (msg.ClientInfoString.Contains("Moto"))
            {
                Utils.Write(strLine + "a Motorola Device.");
                Utils.Write("Client Info String: " + msg.ClientInfoString);
            }
            else
            {
                Utils.Write(strLine + "the following client:");
                Utils.Write("Client Info String: " + msg.ClientInfoString);
            }
        }

        //
        // Handle IPM.Appointment Update action output when busy is set to 2
        //
        public static void OutputApptUpdate(TLMsg msg, string strClient)
        {
            if (m_bAccepted == false)
            {
                if (m_bFirstItem == true)
                {
                    Utils.Write("The item was accepted in the Calendar by " + strClient);
                    if (strClient.Contains("following client:"))
                    {
                        Utils.Write("Client Info String: " + msg.ClientInfoString);
                    }
                    m_bFirstItem = false;
                }
                else
                {
                    Utils.Write("The item was updated in the Calendar by " + strClient);
                    if (strClient.Contains("following client:"))
                    {
                        Utils.Write("Client Info String: " + msg.ClientInfoString);
                    }
                }
                m_bAccepted = true;
            }
            else
            {
                Utils.Write("The item was updated in the Calendar by " + strClient);
                if (strClient.Contains("following client:"))
                {
                    Utils.Write("Client Info String: " + msg.ClientInfoString);
                }
            }
        }

        public static void RequestResponse(TLMsg msg, string strType)
        {
            string strRcvdX500 = "";
            string strRcvdSMTP = "";
            string strRcvRepX500 = "";
            string strRcvRepSMTP = "";
            bool bDelegate = false;
            bool bReceived = false;

            if (!(string.IsNullOrEmpty(msg.RcvdRepresenting)))
            {
                ParseOneOffProp(msg.RcvdRepresenting, ref strRcvRepX500, ref strRcvRepSMTP);
            }
            if (!(string.IsNullOrEmpty(msg.RcvdBy)))
            {
                ParseOneOffProp(msg.RcvdBy, ref strRcvdX500, ref strRcvdSMTP);
                bReceived = true;
            }

            if (strRcvdX500.ToLower() != strRcvRepX500.ToLower())
            {
                bDelegate = true;
            }

            if (m_bOrganizer)
            {
                if (msg.OrganizerAddr.ToLower() == m_FromX500.ToLower())
                {
                    if (msg.IsException.ToLower() == "true")
                    {
                        if (msg.TriggerAction == "Create")
                        {
                            Utils.Write(strType + " response was sent for an instance of the meeting series.");
                        }
                        if (msg.TriggerAction == "Update")
                        {
                            Utils.Write(strType + " response was updated for an instance of the meeting series.");
                        }
                        Utils.Write("   Start: " + msg.ApptStartWhole);
                        Utils.Write("   End  : " + msg.ApptEndWhole);
                    }
                    else
                    {
                        if (msg.TriggerAction == "Create")
                        {
                            Utils.Write(strType + " response was sent.");
                        }
                        if (msg.TriggerAction == "Update")
                        {
                            if (msg.IsProcessed.ToLower() == "true")
                            {
                                Utils.Write(strType + " response was processed by Outlook.");
                            }
                            else
                            {
                                Utils.Write(strType + " response was updated.");
                            }
                        }
                        if (msg.TriggerAction == "Move")
                        {
                            Utils.Write(strType + " response was moved to Sent Items.");
                        }
                    }
                }
                else
                {
                    if (msg.IsException.ToLower() == "true")
                    {
                        if (msg.TriggerAction == "Create")
                        {
                            Utils.Write(strType + " response was received for an instance of the meeting series.");
                        }
                        if (msg.TriggerAction == "Update")
                        {
                            if (msg.IsProcessed.ToLower() == "true")
                            {
                                Utils.Write(strType + " response was processed by Outlook for an exception to the series.");
                            }
                            else
                            {
                                Utils.Write(strType + " response was updated for an instance of the meeting series.");
                            }
                        }
                        Utils.Write("   From : " + msg.OrganizerAddr);
                        Utils.Write("   Start: " + msg.ApptStartWhole);
                        Utils.Write("   End  : " + msg.ApptEndWhole);
                    }
                    else
                    {
                        if (msg.TriggerAction == "Create")
                        {
                            Utils.Write(strType + " response was received from: " + msg.OrganizerAddr);
                        }
                        if (msg.TriggerAction == "Update")
                        {
                            Utils.Write(strType + " response was updated.");
                        }
                    }
                }
            }
            else
            {
                if (msg.OrganizerAddr.ToLower() != m_FromX500.ToLower())
                {
                    if (msg.IsException.ToLower() == "true")
                    {
                        if (msg.TriggerAction == "Create")
                        {
                            if (bReceived && bDelegate)
                            {
                                Utils.Write(strType + " response was received by the delegate for an instance of the meeting series.");
                            }
                            else if (bReceived)
                            {
                                Utils.Write(strType + " response was received for an instance of the meeting series.");
                            }
                            else
                            {
                                Utils.Write(strType + " response was sent for an instance of the meeting series.");
                            }
                        }
                        if (msg.TriggerAction == "Update")
                        {
                            Utils.Write(strType + " response was updated for an instance of the meeting series.");
                        }
                        if (msg.TriggerAction == "Move")
                        {
                            Utils.Write(strType + " response was moved to Sent Items for an instance of the meeting series.");
                        }
                        Utils.Write("   From : " + msg.OrganizerAddr);
                        Utils.Write("   Start: " + msg.ApptStartWhole);
                        Utils.Write("   End  : " + msg.ApptEndWhole);
                    }
                    else
                    {
                        if (msg.TriggerAction == "Create")
                        {
                            if (bReceived && bDelegate)
                            {
                                Utils.Write(strType + " response was received by the delegate.");
                            }
                            else if (bReceived)
                            {
                                Utils.Write(strType + " response was received.");
                            }
                            else
                            {
                                Utils.Write(strType + " response was sent.");
                            }
                        }
                        if (msg.TriggerAction == "Update")
                        {
                            Utils.Write(strType + " response was updated.");
                        }
                        if (msg.TriggerAction == "Move")
                        {
                            Utils.Write(strType + " response was moved to Sent Items.");
                        }
                    }
                }
                else
                {
                    if (msg.IsException.ToLower() == "true")
                    {
                        if (msg.TriggerAction == "Create")
                        {
                            if (bReceived && bDelegate)
                            {
                                Utils.Write(strType + " response was received by the delegate for an instance of the meeting series.");
                            }
                            else if (bReceived)
                            {
                                Utils.Write(strType + " response was received for an instance of the meeting series.");
                            }
                            else
                            {
                                Utils.Write(strType + " response was sent for an instance of the meeting series.");
                            }
                        }
                        if (msg.TriggerAction == "Update")
                        {
                            if (msg.IsProcessed.ToLower() == "true")
                            {
                                Utils.Write(strType + " response was processed by Outlook for an instance of the meeting series.");
                            }
                            else
                            {
                                Utils.Write(strType + " response was updated for an instance of the meeting series.");
                            }
                        }
                        Utils.Write("   From : " + msg.OrganizerAddr);
                        Utils.Write("   Start: " + msg.ApptStartWhole);
                        Utils.Write("   End  : " + msg.ApptEndWhole);
                    }
                    else
                    {
                        if (msg.TriggerAction == "Create")
                        {
                            if (bReceived && bDelegate)
                            {
                                Utils.Write(strType + " response was received by the delegate.");
                            }
                            else if (bReceived)
                            {
                                Utils.Write(strType + " response was received.");
                            }
                            else
                            {
                                Utils.Write(strType + " response was received from: " + msg.OrganizerAddr);
                            }
                        }
                        if (msg.TriggerAction == "Update")
                        {
                            Utils.Write(strType + " response was updated.");
                        }
                    }
                }
            }
        }

        //
        // Reset some things if there was a delete of the Calendar item during the set of items
        //
        public static void ResetAfterDelete()
        {
            m_bAccepted = false;
            m_bFirstItem = true;
            m_bExtMsgClass = false;

        }

    }// public class Timeline
}// namespace