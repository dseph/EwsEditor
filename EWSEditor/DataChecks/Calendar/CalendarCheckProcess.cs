//using Microsoft.Exchange.WebServices.Data;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using EWSEditor.DataChecks.Calendar;
//using static EWSEditor.DataChecks.Calendar.CalendarCheckGlobals;
//using static EWSEditor.DataChecks.Calendar.CalendarCheckUtils;
//using static EWSEditor.DataChecks.Calendar.CalendarCheckPropSet;
//using static EWSEditor.DataChecks.Calendar.CalendarCheckProcess;

//namespace EWSEditor.DataChecks.Calendar
//{
//    public class CalendarCheckProcess
//    {
 
//        // properties that are used for the tests
//        public static string strSubject = "";                 //PR_SUBJECT
//        public static string strOrganizerName = "";           //PR_SENT_REPRESENTING_NAME_W
//        public static string strOrganizerAddr = "";           //PR_SENT_REPRESENTING_EMAIL_ADDRESS_W 
//        public static string strOrganizerAddrType = "";       //PR_SENT_REPRESENTING_ADDRTYPE_W
//        public static string strSenderName = "";              //PR_SENDER_NAME_W
//        public static string strSenderAddr = "";              //PR_SENDER_EMAIL_ADDRESS_W
//        public static string strMsgClass = "";                //PR_MESSAGE_CLASS
//        public static string strLastModified = "";            //PR_LAST_MODIFICATION_TIME
//        public static string strLastModifiedBy = "";          //PR_LAST_MODIFIER_NAME_W
//        public static string strEntryID = "";                 //PR_ENTRYID
//        public static string strMsgSize = "";                 //PR_MESSAGE_SIZE 
//        public static string strDeliveryTime = "";            //PR_MESSAGE_DELIVERY_TIME
//        public static string strHasAttach = "";               //PR_HASATTACH
//        public static string strMsgStatus = "";               //PR_MSG_STATUS
//        public static string strCreateTime = "";              //PR_CREATION_TIME
//        public static string strRecurring = "";               //dispidRecurring
//        public static string strRecurType = "";               //dispidRecurType
//        public static string strStartWhole = "";              //dispidApptStartWhole
//        public static string strEndWhole = "";                //dispidApptEndWhole
//        public static string strApptStateFlags = "";          //dispidApptStateFlags
//        public static string strLocation = "";                //dispidLocation
//        public static string strTZDesc = "";                  //dispidTimeZoneDesc
//        public static string strAllDay = "";                  //dispidApptSubType
//        public static string strRecurBlob = "";               //dispidApptRecur
//        public static string strIsRecurring = "";             //PidLidIsRecurring
//        public static string strGlobalObjID = "";             //PidLidGlobalObjectId
//        public static string strCleanGlobalObjID = "";        //PidLidCleanGlobalObjectId
//        public static string strAuxFlags = "";                //dispidApptAuxFlags
//        public static string strIsException = "";             //PidLidIsException
//        public static string strTZStruct = "";                //dispidTimeZoneStruct
//        public static string strTZDefStart = "";              //dispidApptTZDefStartDisplay
//        public static string strTZDefEnd = "";                //dispidApptTZDefEndDisplay
//        public static string strTZDefRecur = "";              //dispidApptTZDefRecur
//        public static string strPropDefStream = "";           //dispidPropDefStream
//                                                                // data from the Recurrence Blob
//        public static string strRecurBlobType = "";
//        public static string strRecurNumOccurs = "";
//        public static string strRecurStartDate = "";
//        public static string strRecurStartTime = "";
//        public static string strRecurEndDate = "";
//        public static string strRecurEndTime = "";
//        public static string strRecurExceptCount = "";
//        public static string strRecurDelInstCount = "";
//        public static string strRecurModInstCount = "";


//        // Test this Calendar Item's properties.
//        public static void ProcessItem(Appointment appt)
//        {
//            // populate the values for the properties
//            try
//            {
//                if (appt.Size > 0)
//                {
//                    if (bVerbose)
//                    {
//                        outLog.WriteLine("Calling to Get Readable Properties from the following item.");
//                    }
//                    GetPropsReadable(appt);
//                }
//                else
//                {
//                    DisplayAndLog("Appointment item not valid - continuing...");
//                    return;
//                }
//            }
//            catch
//            {
//                DisplayAndLog("Getting props failed or item is NULL - continuing...");
//                return;
//            }

//            string strLogItem = "Problem item: " + strSubject + " | " + strLocation + "| " + strStartWhole + " | " + strEndWhole;

//            if (bVerbose)
//            {
//                string strItemsChecked = (iCheckedItems + 1).ToString();
//                outLog.WriteLine("Checking item " + strItemsChecked + ": " + strSubject + " | " + strStartWhole + "|" + strEndWhole);
//            }

//            foreach (string strVal in appt.Categories)
//            {
//                if (strVal.ToUpper() == "HOLIDAY")
//                {
//                    return; // we will skip testing holiday items since they are imported and should be okay
//                }
//            }

//            List<string> strErrors = new List<string>();
//            bool bErr = false;
//            bool bWarn = false;
//            bool bOrgTest = true;
//            DateTime dtStart = DateTime.MinValue;
//            DateTime dtEnd = DateTime.MinValue;
//            int iDel = 0;
//            int iMod = 0;
//            int iExcept = 0;
//            string strRecurStart = "";
//            string strRecurEnd = "";
//            DateTime dtRecurStart = DateTime.MinValue;
//            DateTime dtRecurEnd = DateTime.MinValue;

//            // parse the recurrence blob and get useful stuff out of it
//            if (!string.IsNullOrEmpty(strRecurBlob))
//            {
//                GetRecurData(strRecurBlob);
//                if (!(string.IsNullOrEmpty(strRecurDelInstCount) && !(string.IsNullOrEmpty(strRecurModInstCount))))
//                {
//                    iDel = int.Parse(strRecurDelInstCount);
//                    iMod = int.Parse(strRecurModInstCount);
//                    iExcept = iDel - iMod;
//                    strRecurExceptCount = iExcept.ToString();
//                }
//                if (!(string.IsNullOrEmpty(strRecurStartDate) && !(string.IsNullOrEmpty(strRecurStartTime))))
//                {
//                    strRecurStart = strRecurStartDate + " " + strRecurStartTime;
//                    dtRecurStart = DateTime.Parse(strRecurStart);
//                }
//                if (!(string.IsNullOrEmpty(strRecurEndDate) && !(string.IsNullOrEmpty(strRecurEndTime))))
//                {
//                    strRecurEnd = strRecurEndDate + " " + strRecurEndTime;
//                    dtRecurEnd = DateTime.Parse(strRecurEnd);
//                }
//            }

//            string strOrganizerSMTP = "";
//            string strMbxSMTP = strSMTPAddr;
//            // get the SMTP address of the Organizer by doing Resolve Name on the X500 address.
//            if (!(string.IsNullOrEmpty(strOrganizerAddr)))
//            {
//                NameResolutionCollection ncCol = null;
//                try
//                {
//                    ncCol = CalendarCheckUtils.exService.ResolveName(strOrganizerAddr);
//                }
//                catch (ServiceRequestException ex)
//                {
//                    strErrors.Add("   Error when attempting to resolve the name for " + strOrganizerAddr + ":");
//                    strErrors.Add("   " + ex.Message);
//                    iWarn++;
//                }

//                if (ncCol.Count > 0 && !string.IsNullOrEmpty(ncCol[0].Mailbox.Address))
//                {
//                    strOrganizerSMTP = ncCol[0].Mailbox.Address;
//                }
//                else
//                {
//                    bOrgTest = false;
//                    strOrganizerSMTP = strOrganizerAddr;
//                }
//            }
//            else
//            {
//                strOrganizerAddr = "";
//            }


//            // now really actually start testing props

//            if (string.IsNullOrEmpty(strSubject))
//            {
//                bWarn = true;
//                strErrors.Add("   WARNING: Subject is empty/missing.");
//                iWarn++;
//                strSubject = "";
//            }
//            else // need to remove commas for logging purposes
//            {
//                if (strSubject.Contains(","))
//                {
//                    strSubject = strSubject.Replace(',', '_');
//                }
//            }

//            if (string.IsNullOrEmpty(strEndWhole))
//            {
//                bErr = true;
//                strErrors.Add("   ERROR: Missing required End Time property.");
//                iErrors++;
//            }
//            else // not empty/missing, but might still have problems
//            {
//                dtEnd = DateTime.Parse(strEndWhole);

//                if (TimeCheck(dtEnd))
//                {
//                    bErr = true;
//                    strErrors.Add("   ERROR: End Time is not set correctly.");
//                    iErrors++;
//                }
//            }

//            if (string.IsNullOrEmpty(strStartWhole))
//            {
//                bErr = true;
//                strErrors.Add("   ERROR: Missing required Start Time property.");
//                iErrors++;
//            }
//            else // not empty/missing, but might still have problems
//            {
//                dtStart = DateTime.Parse(strStartWhole);

//                if (dtEnd < dtStart)
//                {
//                    bErr = true;
//                    strErrors.Add("   ERROR: Start Time is greater than the End Time.");
//                    iErrors++;
//                }

//                if (TimeCheck(dtStart))
//                {
//                    bErr = true;
//                    strErrors.Add("   ERROR: Start Time is set to an invalid value.");
//                    iErrors++;
//                }
//            }

//            if (string.IsNullOrEmpty(strOrganizerAddr))
//            {
//                if (int.Parse(strApptStateFlags) > 0) // if no Organizer Address AND this is a meeting then that's bad.
//                {
//                    bErr = true;
//                    strErrors.Add("   ERROR: Missing required Organizer Address property.");
//                    iErrors++;
//                }
//                strOrganizerAddr = "";
//            }

//            if (string.IsNullOrEmpty(strRecurring))
//            {
//                bErr = true;
//                strErrors.Add("   ERROR: Missing required Recurring property.");
//                iErrors++;
//                strRecurring = "MISSING";
//            }

//            if (string.IsNullOrEmpty(strLocation))
//            {
//                strLocation = "";
//            }
//            else
//            {
//                if (strLocation.Contains(","))
//                {
//                    strLocation = strLocation.Replace(',', '_');
//                }
//            }

//            // check for duplicate calendar items
//            string strDupLine = strSubject + "," + strLocation + "," + strOrganizerAddr + "," + strRecurring + "," + strStartWhole + "," + strEndWhole;
//            if (strDupCheck.Count > 0)
//            {
//                bool bAdd = true;
//                foreach (string str in strDupCheck)
//                {
//                    string strSubj = str.Split(',')[0];
//                    string strStart = str.Split(',')[4];
//                    string strEnd = str.Split(',')[5];
//                    if (str == strDupLine)
//                    {
//                        bErr = true;
//                        strErrors.Add("   ERROR: Duplicate Items.");
//                        strErrors.Add("          This Item: " + strSubject + " | " + strStartWhole + " | " + strEndWhole);
//                        strErrors.Add("          Other Item: " + strSubj + " | " + strStart + " | " + strEnd);
//                        iErrors++;
//                        bAdd = false;
//                    }
//                }
//                if (bAdd)
//                {
//                    strDupCheck.Add(strDupLine);
//                }
//            }
//            else
//            {
//                strDupCheck.Add(strDupLine);
//            }

//            if (string.IsNullOrEmpty(strDeliveryTime))
//            {
//                if (int.Parse(strApptStateFlags) > 0) // single Appt might not need Delivery time.
//                {
//                    bErr = true;
//                    strErrors.Add("   ERROR: Missing required Delivery Time property.");
//                    iErrors++;
//                }
//            }

//            // Do some tests if the item is a recurring item
//            if (strRecurring.ToUpper() == "TRUE")
//            {
//                if (iMod > iDel)
//                {
//                    bErr = true;
//                    strErrors.Add("   ERROR: Recurrence Data is corrupt.");
//                    iErrors++;
//                }

//                if (TimeCheck(dtRecurStart))
//                {
//                    bErr = true;
//                    strErrors.Add("   ERROR: Recurrence Start Time is set to an invalid value.");
//                    iErrors++;
//                }

//                if (TimeCheck(dtRecurEnd))
//                {
//                    bErr = true;
//                    strErrors.Add("   ERROR: Recurrence End Time is set to an invalid value.");
//                    iErrors++;
//                }

//                iRecurItems++;
//                if (iRecurItems == 1299)
//                {
//                    bErr = true;
//                    strErrors.Add("   ERROR: Reached limit of 1300 Recurring Appointments. Delete some older recurring appointments to correct this.");
//                    iErrors++;
//                }
//                if (iRecurItems == 1250)
//                {
//                    bWarn = true;
//                    strErrors.Add("   WARNING: Approaching limit of 1300 Recurring Appointments. Delete some older recurring appointments to correct this.");
//                    iWarn++;
//                }
//            }

//            if (dtStart < dtOld)
//            {
//                if (!(strAllDay.ToUpper() == "TRUE"))
//                {
//                    bErr = true;
//                    strErrors.Add("   ERROR: Start time set previous to 1990.");
//                    iErrors++;
//                }
//                else
//                {
//                    bWarn = true;
//                    strErrors.Add("   WARNING: All day event set with event date before 1990.");
//                    iWarn++;
//                }
//            }

//            if (dtStart > dtFuture)
//            {
//                if (!(strAllDay.ToUpper() == "TRUE"))
//                {
//                    bErr = true;
//                    strErrors.Add("   ERROR: Start time set after the year 2100.");
//                    iErrors++;
//                }
//                else
//                {
//                    bWarn = true;
//                    strErrors.Add("   WARNING: All day event set with event date after 2100.");
//                    iWarn++;
//                }
//            }

//            if (string.IsNullOrEmpty(strSenderName))
//            {
//                if (int.Parse(strApptStateFlags) > 0) // if no Sender Name AND this is a meeting then that's bad.
//                {
//                    bErr = true;
//                    strErrors.Add("   ERROR: Missing required Sender Name property.");
//                    iErrors++;
//                }
//            }

//            if (string.IsNullOrEmpty(strSenderAddr))
//            {
//                if (int.Parse(strApptStateFlags) > 0) // if no Sender Address AND this is a meeting then that's bad.
//                {
//                    bErr = true;
//                    strErrors.Add("   ERROR: Missing required Sender Address property.");
//                    iErrors++;
//                }
//            }

//            if (string.IsNullOrEmpty(strMsgClass))
//            {
//                bErr = true;
//                strErrors.Add("   ERROR: Missing required Message Class property.");
//                iErrors++;
//            }
//            else
//            {
//                bool bFound = false;
//                foreach (string strClass in calMsgClasses)
//                {
//                    if (strClass == strMsgClass)
//                    {
//                        bFound = true;
//                        break; // if one of the known classes then all is good.
//                    }
//                }

//                if (!bFound)
//                {
//                    if (!(strMsgClass.Contains("IPM.Appointment")))
//                    {
//                        bErr = true;
//                        strErrors.Add("   ERROR: Unknown or incorrect Message Class " + strMsgClass + " is set on this item.");
//                        iErrors++;
//                    }
//                    else
//                    {
//                        bWarn = true;
//                        strErrors.Add("   WARNING: Unknown Message Class " + strMsgClass + " is set on this item.");
//                        iWarn++;
//                    }
//                }
//            }

//            if (iExcept >= 25)
//            {
//                bWarn = true;
//                strErrors.Add("   WARNING: Meeting has " + strRecurExceptCount + " exceptions which may indicate a problematic long-running recurring meeting.");
//                iWarn++;
//            }

//            if (!(string.IsNullOrEmpty(strMsgSize)))
//            {
//                int iSize = int.Parse(strMsgSize);
//                string strNum = "";


//                if (iSize >= 52428800)
//                {
//                    strNum = "50M";
//                }
//                else if (iSize >= 26214400)
//                {
//                    strNum = "25M";
//                }
//                else if (iSize >= 10485760)
//                {
//                    strNum = "10M";
//                }

//                if (iSize >= 10485760) // if >= 10M then one of the above is true...
//                {
//                    bWarn = true;
//                    iWarn++;
//                    if (strHasAttach.ToUpper() == "TRUE" && strRecurring.ToUpper() == "TRUE")
//                    {
//                        strErrors.Add("   WARNING: Message size exceeds " + strNum + " which may indicate a problematic long-running recurring meeting.");
//                    }
//                    else if (strHasAttach.ToUpper() == "TRUE")
//                    {
//                        strErrors.Add("   WARNING: Message size exceeds " + strNum + " but is not set as recurring. Might have large and/or many attachments.");
//                    }
//                    else
//                    {
//                        strErrors.Add("   WARNING: Message size exceeds " + strNum + " but has no attachments. Might have some large problem properties.");
//                    }
//                }

//            }

//            if (string.IsNullOrEmpty(strApptStateFlags)) //
//            {
//                bErr = true;
//                strErrors.Add("   ERROR: Missing required Appointment State property.");
//                iErrors++;
//            }
//            else
//            {
//                // check for meeting hijack items
//                switch (strApptStateFlags)
//                {
//                    case "0": // Non-meeting appointment
//                        {
//                            //single appointment I made in my Calendar
//                            break;
//                        }
//                    case "1": // Meeting and I am the Organizer
//                        {
//                            if (!string.IsNullOrEmpty(strOrganizerAddr) && !string.IsNullOrEmpty(strOrganizerSMTP))
//                            {
//                                if (!(strOrganizerSMTP.ToUpper() == strMbxSMTP)) // this user's email should match with the Organizer. If not then error.
//                                {
//                                    if (bOrgTest)
//                                    {
//                                        bErr = true;
//                                        strErrors.Add("   ERROR: Organizer properties are in conflict.");
//                                        strErrors.Add("          Organizer Address: " + strOrganizerAddr);
//                                        strErrors.Add("          Appt State: " + strDisplayName + " is the Organizer");
//                                        iErrors++;
//                                    }
//                                    else
//                                    {
//                                        bWarn = true;
//                                        strErrors.Add("   WARNING: Organizer properties might be in conflict.");
//                                        strErrors.Add("            Organizer Address: " + strOrganizerAddr);
//                                        strErrors.Add("            Appt State: " + strDisplayName + " is the Organizer");
//                                        strErrors.Add("            If the address above is one of the proxyAddresses for " + strDisplayName + " then all is good.");
//                                        iWarn++;
//                                    }
//                                }
//                            }
//                            break;
//                        }
//                    case "2": // Received item - shouldn't be in this state
//                        {
//                            bErr = true;
//                            strErrors.Add("   ERROR: Appointment State is an incorrect value.");
//                            iErrors++;
//                            break;
//                        }
//                    case "3": // Meeting item that I received - I am an Attendee
//                        {
//                            if (!string.IsNullOrEmpty(strOrganizerAddr) && !string.IsNullOrEmpty(strOrganizerSMTP))
//                            {
//                                if (strOrganizerSMTP.ToUpper() == strMbxSMTP) // this user's email should NOT match with the Organizer. If it does then error.
//                                {
//                                    if (bOrgTest)
//                                    {
//                                        bErr = true;
//                                        strErrors.Add("   ERROR: Organizer properties are in conflict.");
//                                        strErrors.Add("          Organizer Address: " + strOrganizerAddr);
//                                        strErrors.Add("          Appt State: " + strDisplayName + " is an Attendee");
//                                        iErrors++;
//                                    }
//                                    else
//                                    {
//                                        bWarn = true;
//                                        strErrors.Add("   WARNING: Organizer properties might be in conflict.");
//                                        strErrors.Add("            Organizer Address: " + strOrganizerAddr);
//                                        strErrors.Add("            Appt State: " + strDisplayName + " is an Attendee");
//                                        strErrors.Add("            If the address above is NOT a proxyAddress for " + strDisplayName + " then all is good.");
//                                        iWarn++;
//                                    }
//                                }
//                            }
//                            break;
//                        }
//                    default: // nothing else matters yet - can add later if needed
//                        {
//                            break;
//                        }
//                }
//            }

//            if (string.IsNullOrEmpty(strTZDefStart))
//            {
//                if (strRecurring.ToUpper() == "TRUE")
//                {
//                    bErr = true;
//                    strErrors.Add("   ERROR: Missing required Timezone property.");
//                    iErrors++;
//                }
//            }

//            // GlobalObjectID check
//            if (int.Parse(strApptStateFlags) > 0) /// Global Obj IDs count when it's an actual Meeting, not single Appt.
//            {
//                bool bAdd = true;

//                if (string.IsNullOrEmpty(strGlobalObjID))
//                {
//                    bErr = true;
//                    strErrors.Add("   ERROR: No GlobalObjectID property detected on this meeting item.");
//                    iErrors++;
//                }

//                if (string.IsNullOrEmpty(strCleanGlobalObjID))
//                {
//                    bErr = true;
//                    strErrors.Add("   ERROR: No CleanGlobalObjectID property detected on this meeting item.");
//                    iErrors++;
//                }

//                if (!(string.IsNullOrEmpty(strGlobalObjID)) || (!(string.IsNullOrEmpty(strCleanGlobalObjID)))) // if both are empty then don't bother testing
//                {
//                    string strGOIDs = strGlobalObjID + "," + strCleanGlobalObjID + "," + strSubject + "," + strStartWhole + "," + strEndWhole;

//                    if (strGOIDCheck.Count > 0)
//                    {
//                        foreach (string str in strGOIDCheck)
//                        {
//                            string strGOID = str.Split(',')[0];
//                            string strCleanGOID = str.Split(',')[1];
//                            string strSubj = str.Split(',')[2];
//                            string strStart = str.Split(',')[3];
//                            string strEnd = str.Split(',')[4];

//                            if (strGOID == strGlobalObjID && strCleanGOID == strCleanGlobalObjID)
//                            {
//                                bErr = true;
//                                strErrors.Add("   ERROR: Duplicate GlobalObjectID properties detected on two items.");
//                                strErrors.Add("          This item: " + strSubject + " | " + strStartWhole + " | " + strEndWhole);
//                                strErrors.Add("          Other item: " + strSubj + " | " + strStart + " | " + strEnd);
//                                iErrors++;
//                                bAdd = false;
//                            }
//                            else if (strGOID == strGlobalObjID)
//                            {
//                                if (!(string.IsNullOrEmpty(strGlobalObjID)))
//                                {
//                                    bErr = true;
//                                    strErrors.Add("   ERROR: Duplicate GlobalObjectID prop detected on two items.");
//                                    strErrors.Add("          This item: " + strSubject + " | " + strStartWhole + " | " + strEndWhole);
//                                    strErrors.Add("          Other item: " + strSubj + " | " + strStart + " | " + strEnd);
//                                    iErrors++;
//                                }
//                                bAdd = false;
//                            }
//                            else if (strCleanGOID == strCleanGlobalObjID)
//                            {
//                                if (!(string.IsNullOrEmpty(strCleanGlobalObjID)))
//                                {
//                                    bErr = true;
//                                    strErrors.Add("   ERROR: Duplicate CleanGlobalObjectID prop detected on two items.");
//                                    strErrors.Add("          This item: " + strSubject + " | " + strStartWhole + " | " + strEndWhole);
//                                    strErrors.Add("          Other item: " + strSubj + " | " + strStart + " | " + strEnd);
//                                    iErrors++;
//                                }
//                                bAdd = false;
//                            }
//                        }
//                        if (bAdd)
//                        {
//                            strGOIDCheck.Add(strGOIDs);
//                        }
//                    }
//                    else
//                    {
//                        strGOIDCheck.Add(strGOIDs);
//                    }
//                }
//            }

//            // 
//            // Now do the reporting and moving of items as needed
//            //

//            if (bErr || bWarn)
//            {
//                outLog.WriteLine(strLogItem);
//                // AND log out each line in the List of errors
//                foreach (string strLine in strErrors)
//                {
//                    outLog.WriteLine(strLine);
//                }
//                outLog.WriteLine("");
//            }

//            // Move items to CalVerifier folder if error is flagged and in "move" mode
//            if (bMoveItems && bErr)
//            {
//                appt.Move(fldCalVerifier.Id);
//            }

//            ResetProps(); // reset the properties for each item.
//        }


//        private static void ResetProps()
//        {
//            strSubject = "";                 //PR_SUBJECT
//            strOrganizerName = "";           //PR_SENT_REPRESENTING_NAME_W
//            strOrganizerAddr = "";           //PR_SENT_REPRESENTING_EMAIL_ADDRESS_W 
//            strOrganizerAddrType = "";       //PR_SENT_REPRESENTING_ADDRTYPE_W
//            strSenderName = "";              //PR_SENDER_NAME_W
//            strSenderAddr = "";              //PR_SENDER_EMAIL_ADDRESS_W
//            strMsgClass = "";                //PR_MESSAGE_CLASS
//            strLastModified = "";            //PR_LAST_MODIFICATION_TIME
//            strLastModifiedBy = "";          //PR_LAST_MODIFIER_NAME_W
//            strEntryID = "";                 //PR_ENTRYID
//            strMsgSize = "";                 //PR_MESSAGE_SIZE 
//            strDeliveryTime = "";            //PR_MESSAGE_DELIVERY_TIME
//            strHasAttach = "";               //PR_HASATTACH
//            strMsgStatus = "";               //PR_MSG_STATUS
//            strCreateTime = "";              //PR_CREATION_TIME
//            strRecurring = "";               //dispidRecurring
//            strRecurType = "";               //dispidRecurType
//            strStartWhole = "";              //dispidApptStartWhole
//            strEndWhole = "";                //dispidApptEndWhole
//            strApptStateFlags = "";          //dispidApptStateFlags
//            strLocation = "";                //dispidLocation
//            strTZDesc = "";                  //dispidTimeZoneDesc
//            strAllDay = "";                  //dispidApptSubType
//            strRecurBlob = "";               //dispidApptRecur
//            strIsRecurring = "";             //PidLidIsRecurring
//            strGlobalObjID = "";             //PidLidGlobalObjectId
//            strCleanGlobalObjID = "";        //PidLidCleanGlobalObjectId
//            strAuxFlags = "";                //dispidApptAuxFlags
//            strIsException = "";             //PidLidIsException
//            strTZStruct = "";                //dispidTimeZoneStruct
//            strTZDefStart = "";              //dispidApptTZDefStartDisplay
//            strTZDefEnd = "";                //dispidApptTZDefEndDisplay
//            strTZDefRecur = "";              //dispidApptTZDefRecur
//            strPropDefStream = "";           //dispidPropDefStream
//            strRecurBlobType = "";
//            strRecurNumOccurs = "";
//            strRecurStartDate = "";
//            strRecurStartTime = "";
//            strRecurEndDate = "";
//            strRecurEndTime = "";
//            strRecurExceptCount = "";
//            strRecurDelInstCount = "";
//            strRecurModInstCount = "";
//        }

//        private static void GetRecurData(string strRecurBlob)
//        {
//            string strInFile = strAppPath + "RBHex.txt";
//            string strOutFile = strAppPath + "RBRead.txt";

//            CreateHexFile(strRecurBlob, strInFile);
//            RunMrMAPI(string.Format("-p 2 -i \"{0}\" -o \"{1}\"", strInFile, strOutFile));

//            StreamReader srIn = new StreamReader(strOutFile);
//            string strLine = "";
//            while ((strLine = srIn.ReadLine()) != null)
//            {
//                if (strLine.StartsWith("EndType:"))
//                {
//                    if (strLine.Contains("IDC_RCEV_PAT_ERB_NOEND"))
//                    {
//                        strRecurBlobType = "NoEndDate";
//                    }
//                    if (strLine.Contains("IDC_RCEV_PAT_ERB_END"))
//                    {
//                        strRecurBlobType = "EndSpecificDate";
//                    }
//                    if (strLine.Contains("IDC_RCEV_PAT_ERB_AFTERNOCCUR"))
//                    {
//                        strRecurBlobType = "EndNumberOccur";
//                    }
//                }
//                if (strLine.StartsWith("OccurrenceCount:"))
//                {
//                    strRecurNumOccurs = strLine.Substring(strLine.LastIndexOf('=') + 2);
//                }
//                if (strLine.StartsWith("DeletedInstanceCount:"))
//                {
//                    strRecurDelInstCount = strLine.Substring(strLine.LastIndexOf('=') + 2);
//                }
//                if (strLine.StartsWith("ModifiedInstanceCount:"))
//                {
//                    strRecurModInstCount = strLine.Substring(strLine.LastIndexOf('=') + 2);
//                }
//                if (strLine.StartsWith("StartDate:"))
//                {
//                    strRecurStartDate = strLine.Substring(strLine.LastIndexOf('M') + 2);
//                }
//                if (strLine.StartsWith("EndDate:"))
//                {
//                    strRecurEndDate = strLine.Substring(strLine.LastIndexOf('M') + 2);
//                }
//                if (strLine.StartsWith("StartTimeOffset:"))
//                {
//                    strRecurStartTime = GetTimeFromString(strLine);
//                }
//                if (strLine.StartsWith("EndTimeOffset:"))
//                {
//                    strRecurEndTime = GetTimeFromString(strLine);
//                }
//            }
//            srIn.Close();

//            if (File.Exists(strOutFile))
//            {
//                File.Delete(strOutFile);
//            }
//            if (File.Exists(strInFile))
//            {
//                File.Delete(strInFile);
//            }
//        }

//        private static string GetTimeFromString(string str)
//        {
//            int iEquals = 0;
//            int iM = 0;
//            int iLength = 0;
//            string strTime = "";

//            iEquals = str.LastIndexOf('=');
//            iM = str.LastIndexOf('M');
//            iLength = (iM - (iEquals + 1));

//            strTime = str.Substring(iEquals + 2, iLength);

//            return strTime;
//        }

//        // Populate the property values for each of the props the app checks on.
//        // Some tests require multiple props, so best to go ahead and just get them all first.
//        public static void GetPropsReadable(Appointment appt)
//        {
//            string strHexTag = "";
//            string strPropName = "";
//            string strSetID = "";
//            string strGUID = "";
//            string strValue = "";
//            string strType = "";

//            foreach (ExtendedProperty extProp in appt.ExtendedProperties)
//            {
//                // Get the Tag
//                if (extProp.PropertyDefinition.Tag.HasValue)
//                {
//                    strHexTag = extProp.PropertyDefinition.Tag.Value.ToString("X4");
//                }
//                else if (extProp.PropertyDefinition.Id.HasValue)
//                {
//                    strHexTag = extProp.PropertyDefinition.Id.Value.ToString("X4");
//                }

//                // Get the SetID for named props
//                if (extProp.PropertyDefinition.PropertySetId.HasValue)
//                {
//                    strGUID = extProp.PropertyDefinition.PropertySetId.Value.ToString("B");
//                    strSetID = CalendarCheckPropSet.GetSetIDFromGUID(strGUID);
//                }

//                // Get the Property Type
//                strType = extProp.PropertyDefinition.MapiType.ToString();

//                // Get the Prop Name
//                strPropName = CalendarCheckPropSet.GetPropNameFromTag(strHexTag, strSetID);

//                // if it's binary then convert it to a string-ized binary - will be converted using MrMapi
//                if (strType == "Binary")
//                {
//                    byte[] binData = extProp.Value as byte[];
//                    strValue = GetStringFromBytes(binData);
//                }
//                else
//                {
//                    if (extProp.Value != null)
//                    {
//                        strValue = extProp.Value.ToString();
//                    }
//                }

//                switch (strPropName)
//                {
//                    case "PR_SUBJECT_W":
//                        {
//                            strSubject = strValue;
//                            break;
//                        }
//                    case "PR_SENT_REPRESENTING_NAME_W":
//                        {
//                            strOrganizerName = strValue;
//                            break;
//                        }
//                    case "PR_SENT_REPRESENTING_EMAIL_ADDRESS_W":
//                        {
//                            strOrganizerAddr = strValue;
//                            break;
//                        }
//                    case "PR_SENT_REPRESENTING_ADDRTYPE_W":
//                        {
//                            strOrganizerAddrType = strValue;
//                            break;
//                        }
//                    case "PR_SENDER_NAME_W":
//                        {
//                            strSenderName = strValue;
//                            break;
//                        }
//                    case "PR_SENDER_EMAIL_ADDRESS_W":
//                        {
//                            strSenderAddr = strValue;
//                            break;
//                        }
//                    case "PR_MESSAGE_CLASS":
//                        {
//                            strMsgClass = strValue;
//                            break;
//                        }
//                    case "PR_LAST_MODIFICATION_TIME":
//                        {
//                            strLastModified = strValue;
//                            break;
//                        }
//                    case "PR_LAST_MODIFIER_NAME_W":
//                        {
//                            strLastModifiedBy = strValue;
//                            break;
//                        }
//                    case "PR_ENTRYID":
//                        {
//                            strEntryID = strValue;
//                            break;
//                        }
//                    case "PR_MESSAGE_SIZE":
//                        {
//                            strMsgSize = strValue;
//                            break;
//                        }
//                    case "PR_MESSAGE_DELIVERY_TIME":
//                        {
//                            strDeliveryTime = strValue;
//                            break;
//                        }
//                    case "PR_HASATTACH":
//                        {
//                            strHasAttach = strValue;
//                            break;
//                        }
//                    case "PR_MSG_STATUS":
//                        {
//                            strMsgStatus = strValue;
//                            break;
//                        }
//                    case "PR_CREATION_TIME":
//                        {
//                            strCreateTime = strValue;
//                            break;
//                        }
//                    case "dispidRecurring":
//                        {
//                            strRecurring = strValue;
//                            break;
//                        }
//                    case "dispidRecurType":
//                        {
//                            strRecurType = strValue;
//                            break;
//                        }
//                    case "dispidApptStartWhole":
//                        {
//                            strStartWhole = strValue;
//                            break;
//                        }
//                    case "dispidApptEndWhole":
//                        {
//                            strEndWhole = strValue;
//                            break;
//                        }
//                    case "dispidApptStateFlags":
//                        {
//                            strApptStateFlags = strValue;
//                            break;
//                        }
//                    case "dispidLocation":
//                        {
//                            strLocation = strValue;
//                            break;
//                        }
//                    case "dispidTimeZoneDesc":
//                        {
//                            strTZDesc = strValue;
//                            break;
//                        }
//                    case "dispidApptSubType":
//                        {
//                            strAllDay = strValue;
//                            break;
//                        }
//                    case "dispidApptRecur":
//                        {
//                            strRecurBlob = strValue;
//                            break;
//                        }
//                    case "PidLidIsRecurring":
//                        {
//                            strIsRecurring = strValue;
//                            break;
//                        }
//                    case "PidLidGlobalObjectId":
//                        {
//                            strGlobalObjID = strValue;
//                            break;
//                        }
//                    case "PidLidCleanGlobalObjectId":
//                        {
//                            strCleanGlobalObjID = strValue;
//                            break;
//                        }
//                    case "dispidApptAuxFlags":
//                        {
//                            strAuxFlags = strValue;
//                            break;
//                        }
//                    case "PidLidIsException":
//                        {
//                            strIsException = strValue;
//                            break;
//                        }
//                    case "dispidTimeZoneStruct":
//                        {
//                            strTZStruct = strValue;
//                            break;
//                        }
//                    case "dispidApptTZDefStartDisplay":
//                        {
//                            strTZDefStart = strValue;
//                            break;
//                        }
//                    case "dispidApptTZDefEndDisplay":
//                        {
//                            strTZDefEnd = strValue;
//                            break;
//                        }
//                    case "dispidApptTZDefRecur":
//                        {
//                            strTZDefRecur = strValue;
//                            break;
//                        }
//                    case "dispidPropDefStream":
//                        {
//                            strPropDefStream = strValue;
//                            break;
//                        }
//                    default:
//                        {
//                            break;
//                        }
//                }
//            }
//            return;
//        }

//        // EWS does not return a string-ized hex blob, and need it for MrMapi conversion
//        public static string GetStringFromBytes(byte[] bytes)
//        {
//            StringBuilder ret = new StringBuilder();
//            foreach (byte b in bytes)
//            {
//                ret.Append(Convert.ToString(b, 16).PadLeft(2, '0'));
//            }

//            return ret.ToString().ToUpper();
//        }
//    }
//}
 
