//using Microsoft.Exchange.WebServices.Data;
//using Microsoft.IdentityModel.Clients.ActiveDirectory;
//using System.Diagnostics;
//using System.Threading.Tasks;
//using System;
//using System.IO;
//using System.Collections.Generic;
//using System.DirectoryServices.ActiveDirectory;
//using System.Linq;
//using System.Text;
//using EWSEditor.DataChecks.Calendar;
//using static EWSEditor.DataChecks.Calendar.CalendarCheckGlobals;
//using static EWSEditor.DataChecks.Calendar.CalendarCheckUtils;


//namespace EWSEditor.DataChecks.Calendar
//{

//    public class CalendarCheckUtils
//    {
//        // So I can get to the service object from wherever...
//        public static ExchangeService exService;

//        public static void ShowInfo()
//        {
//            Console.WriteLine("");
//            Console.WriteLine("===========");
//            Console.WriteLine("CalVerifier");
//            Console.WriteLine("===========");
//            Console.WriteLine("Checks Calendars for potential problem items and reports them.\r\n");
//        }
//        public static void ShowHelp()
//        {
//            Console.WriteLine("Usage:");
//            Console.WriteLine("CalVerifier [-L <filename>] [-M] [-V] [-?]");
//            Console.WriteLine("");
//            Console.WriteLine("-L   [List mode. Requires a file with SMTP addresses of mailboxes to check - one SMTP address per line.]");
//            Console.WriteLine("-M   [Move mode. Will move problem items out of the Calendar to a folder called CalVerifier in the Mailbox.]");
//            Console.WriteLine("-V   [Verbose. Will output tracing information.]");
//            Console.WriteLine("-?   [Shows this usage information.]");
//            Console.WriteLine("");
//            Console.WriteLine("Examples:");
//            Console.WriteLine("=========");
//            Console.WriteLine("Use no command line switches to run the utility against your mailbox (no impersonation):");
//            Console.WriteLine("     CalVerifier");
//            Console.WriteLine("");
//            Console.WriteLine("Run against a set of mailboxes using Impersonation (List.txt is a file with several SMTP addresses in it):");
//            Console.WriteLine("     CalVerifier -L C:\\Temp\\List.txt");
//            Console.WriteLine("");
//            Console.WriteLine("Run the utility against your mailbox and move error items:");
//            Console.WriteLine("     CalVerifier -M");
//            Console.WriteLine("");
//        }

//        public static void LogInfo()
//        {
//            LogLine("===========");
//            LogLine("CalVerifier");
//            LogLine("===========");
//            LogLine("Checks Calendars for potential problem items and reports them.\r\n");
//        }

//        public static void DisplayPrivacyInfo()
//        {
//            Console.WriteLine("\r\n");
//            Console.WriteLine("Privacy Note:");
//            Console.WriteLine("===============");
//            Console.WriteLine("The data files produced by CalVerifier can contain PII such as e-mail addresses.");
//            Console.WriteLine("Please remove these files from your system after analysis and/or supplying them to support for analysis.");
//            Console.WriteLine("For more information on Microsoft's privacy standards and practices, please go to https://www.microsoft.com/en-us/trustcenter/Privacy");
//        }

//        public static void LogLine(string strLine)
//        {
//            outLog.WriteLine(strLine);
//        }

//        public static void DisplayAndLog(string strLine)
//        {
//            Console.WriteLine(strLine);
//            outLog.WriteLine(strLine);
//        }

//        // create a hex blob text file for use with MrMAPI
//        public static void CreateHexFile(string strHex, string strFileName)
//        {
//            if (File.Exists(strFileName))
//            {
//                File.Delete(strFileName);
//            }
//            StreamWriter swFile = new StreamWriter(strFileName);
//            swFile.WriteLine(strHex);
//            swFile.Close();
//        }

//        // run the MrMAPI app to get item props
//        public static void RunMrMAPI(string strSwitches)
//        {
//            // Setup and launch MrMAPI
//            string strAppPath = GetMrMAPIPath();
//            if (File.Exists(strAppPath))
//            {
//                System.Diagnostics.Process mrMAPI = new System.Diagnostics.Process();
//                mrMAPI.StartInfo.FileName = (strAppPath);
//                mrMAPI.StartInfo.Arguments = (strSwitches);
//                mrMAPI.StartInfo.UseShellExecute = true;
//                mrMAPI.StartInfo.CreateNoWindow = true;
//                mrMAPI.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
//                mrMAPI.Start();
//                mrMAPI.WaitForExit();
//            }
//            return;
//        }

//        // Get the path to MrMAPI
//        public static string GetMrMAPIPath()
//        {
//            object oRegVal;
//            string strRegVal;
//            string strSize = IntPtr.Size.ToString();
//            string mapiBitness = "x86";

//            // Check for ClickToRun config first...
//            if (Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Office\ClickToRun", "Platform", null) != null)
//            {
//                oRegVal = Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Office\ClickToRun", "Platform", null);
//                strRegVal = oRegVal.ToString();
//                if (strRegVal.Contains("x64"))
//                {
//                    mapiBitness = "x64";
//                }
//            }
//            // check Office 15.0 location
//            else if (Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Office\15.0\Outlook", "Bitness", null) != null)
//            {
//                oRegVal = Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Office\15.0\Outlook", "Bitness", null);
//                strRegVal = oRegVal.ToString();
//                if (strRegVal.Contains("x64"))
//                {
//                    mapiBitness = "x64";
//                }
//            }
//            // check Office 16.0 location
//            else if (Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Office\16.0\Outlook", "Bitness", null) != null)
//            {
//                oRegVal = Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Office\16.0\Outlook", "Bitness", null);
//                strRegVal = oRegVal.ToString();
//                if (strRegVal.Contains("x64"))
//                {
//                    mapiBitness = "x64";
//                }
//            }
//            // I "think" Outlook 2013 would populate this with MSI builds - so another way to check if others above fail
//            else if (IntPtr.Size == 8 && Microsoft.Win32.Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows Messaging Subsystem\MSMapiApps", "outlook.exe", null) != null)
//            {
//                mapiBitness = "x64";
//            }

//            return System.IO.Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), mapiBitness, "MrMAPI.exe");
//        }

//        // Create the CalVerifier folder
//        public static void CreateErrFld()
//        {
//            Folder fld = new Folder(exService);
//            fld.DisplayName = "CalVerifier";

//            try
//            {
//                fld.Save(WellKnownFolderName.MsgFolderRoot);

//            }
//            catch (ServiceResponseException ex)
//            {
//                if (!(ex.ErrorCode.ToString().ToUpper() == "ERRORFOLDEREXISTS"))
//                {
//                    Console.ForegroundColor = ConsoleColor.Red;
//                    Console.WriteLine("");
//                    Console.WriteLine(ex.Message);
//                    Console.ResetColor();
//                    return;
//                }
//                else
//                {
//                    fld = FindFolder("CalVerifier");
//                }
//            }
//            fldCalVerifier = fld;
//        }

//        public static Folder FindFolder(string strFolder)
//        {
//            Folder fldSearch = null;
//            FindFoldersResults fFRes = null;
//            int iPageSize = 500;
//            int iOffset = 0;
//            bool bMore = true;

//            FolderView view = new FolderView(iPageSize, iOffset, OffsetBasePoint.Beginning);
//            view.PropertySet = new PropertySet(BasePropertySet.IdOnly);
//            view.PropertySet.Add(FolderSchema.DisplayName);
//            view.Traversal = FolderTraversal.Shallow;   // CalVerifier should be a direct child of MsgFolderRoot so Shallow should get it

//            // go get the results and find our folder
//            while (bMore)
//            {
//                fFRes = exService.FindFolders(WellKnownFolderName.MsgFolderRoot, view);
//                foreach (Folder fld in fFRes)
//                {
//                    if (fld.DisplayName == strFolder)
//                    {
//                        fldSearch = fld;
//                        break;
//                    }
//                }
//                // break out of the while loop if we got the folder
//                if (fldSearch != null)
//                {
//                    break;
//                }
//                else
//                {
//                    bMore = fFRes.MoreAvailable;
//                    if (bMore)
//                    {
//                        view.Offset += iPageSize;
//                    }
//                }
//            }

//            return fldSearch;
//        }

//        public static NameResolutionCollection DoResolveName(string strResolve)
//        {
//            NameResolutionCollection ncCol = null;
//            try
//            {
//                ncCol = exService.ResolveName(strResolve, ResolveNameSearchLocation.DirectoryOnly, true);
//            }
//            catch (ServiceRequestException ex)
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine("Error when attempting to resolve the name for " + strResolve + ":");
//                Console.WriteLine(ex.Message);
//                Console.ResetColor();
//                return null;
//            }

//            return ncCol;
//        }

//        // Check date/time values against boundary values.
//        // return TRUE if the time is no good.
//        public static bool TimeCheck(DateTime dtCheck)
//        {
//            int iComp = 0;
//            // less than 0 >> t1 earlier than t2
//            // zero >> t1 same as t2
//            //greater than 0 >> t1 is later than t2

//            iComp = DateTime.Compare(dtCheck, dtMin);
//            if (iComp < 0)
//            {
//                return true;
//            }

//            iComp = DateTime.Compare(dtCheck, dtNone);
//            if (iComp > 0)
//            {
//                return true;
//            }

//            if (dtCheck < DateTime.MinValue || dtCheck > DateTime.MaxValue)  // these are probably different from the Outlook boundary values
//            {
//                return true;
//            }

//            return false;
//        }
//    }
//}