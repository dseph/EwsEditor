using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Windows.Forms.AxHost;
using EWSEditor.DataChecks.Calendar;

namespace EWSEditor.DataChecks.Calendar
{
    public partial class CalendarCheck : Form
    {
        public CalendarCheck()
        {
            InitializeComponent();
        }

        private void CalendarCheck_Load(object sender, EventArgs e)
        {

        }

        private void btnStartCheck_Click(object sender, EventArgs e)
        {

        }

        private void btnStopChecking_Click(object sender, EventArgs e)
        {

        }

        private void LoadSmtpList()
        {

        }

        private void PrecessList()
        {
            //NameResolutionCollection ncCol = null;

            //if (bListMode) // List mode
            //{
                //rgstrMBX = File.ReadAllLines(strListFile);
                //foreach (string strSMTP in rgstrMBX)
                //{
                //    CreateLogFile();
                //    LogInfo();
                //    strDupCheck = new List<string>();
                //    strGOIDCheck = new List<string>();
                //    ncCol = DoResolveName(strSMTP);
                //    if (ncCol == null || ncCol.Count == 0)
                //    {
                //        // Didn't get a NameResCollection, so error out.
                //        Console.WriteLine("");
                //        Console.WriteLine("Check the SMTP addresses in the list file - there was a problem resolving against the directory.");
                //        Console.WriteLine("SMTP Address: " + strSMTP);
                //        Console.WriteLine("Exiting the program.");
                //        return;  // look at just skipping to the next one here...
                //    }

                //    if (ncCol[0].Contact != null)
                //    {
                //        strDisplayName = ncCol[0].Contact.DisplayName;
                //        DisplayAndLog("Processing Calendar for " + strDisplayName);
                //    }
                //    else
                //    {
                //        DisplayAndLog("Processing Calendar for " + strSMTP);
                //    }

                //    exService.ImpersonatedUserId = new ImpersonatedUserId(ConnectingIdType.SmtpAddress, strSMTP);
                //    // TODO - Set X-AnchorMailbox

                //    // Should only do this if the switch was set.
                //    if (bMoveItems)
                //    {
                //        CreateErrFld();
                //        string strFldID = fldCalVerifier.Id.ToString();
                //    }
                //    strSMTPAddr = strSMTP.ToUpper();

                //    //-----------------//
                //    // Main processing //
                //    bRet = ProcessCalendar(exService);
 
                //    DisplayAndLog("\r\n");
                //    DisplayAndLog("===============================================================");
                //    DisplayAndLog("Checked " + iCheckedItems.ToString() + " items.");
                //    DisplayAndLog("Found " + iErrors.ToString() + " errors and " + iWarn.ToString() + " warnings.");
                //    DisplayAndLog("===============================================================\r\n");
                //    outLog.Close();

                //    dtNow = DateTime.Now;
                //    strDate = dtNow.ToShortDateString();
                //    strDate = strDate.Replace('/', '-');
                //    strFileName = strAppPath + strDate + "_" + strSMTPAddr + "_CalVerifier.log";

                //    if (File.Exists(strFileName))
                //    {
                //        File.Delete(strFileName);
                //    }
                //    File.Move(strLogFile, strFileName);
                //    ResetGlobals();
                //}
                //Console.WriteLine("");
                //Console.WriteLine("Please check " + strAppPath + " for the CalVerifier logs.");
            //}
        }
    }
}
