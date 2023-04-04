//using Microsoft.Exchange.WebServices.Data;
//using System;
//using System.Collections.Generic;
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
//    internal class CheckCalendarData
//    {

//        public static bool ProcessCalendar(ExchangeService service) 
//        {
//            return ProcessCalendar(service, WellKnownFolderName.Calendar);
//        }


//        // Go connect to the Calendar folder and get the calendar items
//        public static bool ProcessCalendar(ExchangeService service, FolderId oCalendarFolderId)
//        {
//            Folder fldCal = null;
//            int iOffset = 0;
//            int iPageSize = 500;
//            bool bMore = true;
//            //List<Item> cAppts = new List<Item>();
//            FindItemsResults<Item> findResults = null;

//            try
//            {
//                // Here's where it connects to the Calendar
//                fldCal = Folder.Bind(service, oCalendarFolderId, new PropertySet());

//            }
//            catch (ServiceResponseException ex)
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine("");
//                Console.WriteLine("Could not connect to this user's mailbox or calendar.");
//                Console.WriteLine(ex.Message);
//                Console.ResetColor();
//                return false;
//            }

//            // if we're in then we get here
//            // creating a view with props to request / collect
//            ItemView cView = new ItemView(iPageSize, iOffset, OffsetBasePoint.Beginning);
//            List<ExtendedPropertyDefinition> propSet = new List<ExtendedPropertyDefinition>();
//            DoProps(ref propSet);

//            cView.PropertySet = new PropertySet(BasePropertySet.FirstClassProperties);
//            cView.OrderBy.Add(ItemSchema.LastModifiedTime, SortDirection.Descending);
//            foreach (PropertyDefinitionBase pdbProp in propSet)
//            {
//                cView.PropertySet.Add(pdbProp);
//            }

//            // now go get the items. 1000 Max so must loop to get all items
//            while (bMore)
//            {
//                findResults = fldCal.FindItems(cView);

//                int i = 0;
//                int n = 0;
//                foreach (Appointment appt in findResults.Items)
//                {
//                    //cAppts.Add(item);
//                    i++;
//                    if (i % 5 == 0)
//                    {
//                        // do a progress marker that spins | / - \
//                        Console.SetCursorPosition(0, Console.CursorTop);
//                        Console.Write("");
//                        Console.Write(cSpin[n % 4]);
//                        n++;
//                    }

//                    try
//                    {
//                        if (appt.Size > 0)
//                        {
//                            if (bVerbose)
//                            {
//                                outLog.WriteLine("Calling to Process Item");
//                            }
//                            ProcessItem(appt);
//                        }
//                        else
//                        {
//                            DisplayAndLog("Encountered an invalid Appointment. Continuing...");
//                        }
//                    }
//                    catch
//                    {
//                        DisplayAndLog("Appointment item processing failed or item is NULL. Continuing...");
//                    }

//                    iCheckedItems++;
//                    if (i % 500 == 0)
//                    {
//                        // Give progress update every 500 items
//                        Console.SetCursorPosition(0, Console.CursorTop);
//                        Console.Write("");
//                        Console.WriteLine("Completed " + iCheckedItems.ToString() + " items and continuing...");
//                    }
//                }

//                bMore = findResults.MoreAvailable;
//                if (bMore)
//                {
//                    cView.Offset += iPageSize;
//                }

//                // clear out progress marker now that we are done
//                Console.SetCursorPosition(0, Console.CursorTop);
//                Console.Write(" ");
//            }

//            return true;
//        }
//    }
//}
