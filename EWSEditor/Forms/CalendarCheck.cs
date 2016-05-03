using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpecialUtility;

namespace EWSEditor.Forms
{
    public partial class CalendarCheck : Form
    {
        public CalendarCheck()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            bool bRet = false;
            string sResultsSummary = "";
            CalCheck oCalCheck = new CalCheck();

            // Collection of a custom class for  results?

            //bRet = oCalCheck.CheckFolder(ExchangeService oExchangeService, ref sResultsSummary, ref List<CalCheckResult> oResults);
            //bRet = oCalCheck.CheckFolder(ExchangeService oExchangeService, FolderId oFolderId, ref sResultsSummary,  ref List<CalCheckResult> oResults);
            //bRet = oCalCheck.CheckItem(ExchangeService oExchangeService, ItemId oItemId, ref sResultsSummary, ref List<CalCheckResult> oResults);
 
        }

        private void CalendarCheck_Load(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {

        }
    }
}
