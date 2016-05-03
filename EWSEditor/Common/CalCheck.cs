using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Exchange.WebServices.Data;

namespace SpecialUtility
{
    // Convert code from: https://calcheck.codeplex.com/

    class CalCheck
    {
        ExchangeService _ExchangeService = null;
        FolderId _FolderId = null;
        ItemId _ItemId = null;

        string _ResultsSummary = string.Empty;
        List<CalCheckResult> _Results = new List<CalCheckResult> { };

        /// <summary>
        ///  CheckFolder 
        ///  Check all calendar items in the mailbox
        /// </summary>
        /// <param name="oExchangeService"></param>
        public void CheckFolder(ExchangeService oExchangeService, ref string _ResultsSummary, ref List<CalCheckResult> oResults)
        {
            _Results = null;

        }
   
        /// <summary>
        /// CheckFolder
        /// Check the specific calendar folder
        /// </summary>
        /// <param name="oExchangeService"></param>
        /// <param name="oFolder"></param>
        public void CheckFolder(ExchangeService oExchangeService, FolderId oFolder, ref string _ResultsSummary, ref List<CalCheckResult> oResults)
        {
            _ExchangeService = oExchangeService;
            _FolderId = oFolder;

            _Results = null;

        }

        /// <summary>
        /// CheckItem
        /// Check the specified item.
        /// </summary>
        /// <param name="oExchangeService"></param>
        /// <param name="oItemId"></param>
        public void CheckItem(ExchangeService oExchangeService, ItemId oItemId, ref string _ResultsSummary, ref List<CalCheckResult> oResults)
        {
            _ExchangeService = oExchangeService;
            _ItemId = oItemId;

            _Results = null;

        }

        public class CalCheckResult
        {
            string FolderId = string.Empty;
            string FolderName = string.Empty;
            string ItemId = string.Empty;
            string Subject = string.Empty;
            string Location = string.Empty;
            string StartTime = string.Empty;
            string EndTime = string.Empty;
            string Recurring = string.Empty;
            string Organizer = string.Empty;
            string IsPastItem = string.Empty;
            string ErrorsAndWarnings = string.Empty;
            string OtherItemId = string.Empty;
            string OtherItemSubject = string.Empty;
            string OtherItemStart = string.Empty;
            string OtherItemEnd = string.Empty;
        }
     
    }
}
