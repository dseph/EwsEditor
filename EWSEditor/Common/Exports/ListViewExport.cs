using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

using EWSEditor.Common.Exports;
using EWSEditor.Common;
using EWSEditor.Common.Extensions;
using EWSEditor.Resources;
using Microsoft.Exchange.WebServices.Data;

using EWSEditor.Common.Exports;
 

namespace EWSEditor.Common 
{
    public class ListViewExport
    {
        public static bool SaveCalendarListViewToCsv(
            ExchangeService oExchangeService,
            ListView oListView,
            string sFilePath,
            List<AdditionalPropertyDefinition> oAdditionalPropertyDefinitions,
            List<ExtendedPropertyDefinition> oExtendedPropertyDefinitions
    )
        {
            bool bRet = false;

            string sHeader = string.Empty;
            string sLine = string.Empty;


            PropertySet oExtendedPropSet = new PropertySet(BasePropertySet.IdOnly);

            if (oExtendedPropertyDefinitions != null)
            {
                foreach (ExtendedPropertyDefinition oEPD in oExtendedPropertyDefinitions)
                {
                    oExtendedPropSet.Add(oEPD);
                }
            }

            StreamWriter w = File.AppendText(sFilePath);
            char[] TrimChars = { ',', ' ' };
            StringBuilder SbHeader = new StringBuilder();
            foreach (ColumnHeader oCH in oListView.Columns)
            {
                SbHeader.Append(oCH.Text);
                SbHeader.Append(",");
            }
            sHeader = SbHeader.ToString();
            sHeader = sHeader.TrimEnd(TrimChars);

            if (oAdditionalPropertyDefinitions != null)
            {
                sHeader += "," + AdditionalProperties.GetExtendedPropertyHeadersAsCsvContent(oAdditionalPropertyDefinitions);
                sHeader = sHeader.TrimEnd(TrimChars);
            }

            w.WriteLine(sHeader);


            ItemId oItemId = null;
            string sExtendedValue = string.Empty;

            string s = string.Empty;
            foreach (ListViewItem oListViewItem in oListView.Items)
            {
                StringBuilder SbLine = new StringBuilder();
                //oCalendarItemTag = (CalendarItemTag)oListViewItem.Tag;
                CalendarItemTag oCalendarItemTag = (CalendarItemTag)oListViewItem.Tag;  
                oItemId = oCalendarItemTag.Id;

                if (oListViewItem.Selected == true)
                {

                    foreach (ListViewItem.ListViewSubItem o in oListViewItem.SubItems)
                    {
                        s = (o.Text);
                        if (s.Contains(','))
                            s = s.Replace(",", " "); // need to strip commas as this is a csv file.
                        SbLine.Append(s);
                        SbLine.Append(",");
                    }

                }

                sLine = SbLine.ToString();
                sLine = sLine.TrimEnd(TrimChars);

                //  Add Additional Properties ----------------------------------------------


               // StringBuilder oStringBuilder = new StringBuilder();

                if (oExtendedPropertyDefinitions != null)
                {
                    string sExt = AdditionalProperties.GetExtendedPropertiesForItemAsCsvContent(
                        oExchangeService,
                        oItemId,
                        oExtendedPropertyDefinitions
                        );
                    sLine = "," + sExt;

                    //sLine = SbLine.ToString();
                    sLine = sLine.TrimEnd(TrimChars);

                }

                w.WriteLine(sLine);

                bRet = true;
            }

            w.Close();

            return bRet;
        }

        public static bool SaveListViewToCsv(
            ExchangeService oExchangeService,
            ListView oListView, 
            string sFilePath,
            List<AdditionalPropertyDefinition> oAdditionalPropertyDefinitions,
            List<ExtendedPropertyDefinition> oExtendedPropertyDefinitions
            )
        {
            bool bRet = false;

            string sHeader = string.Empty;
            string sLine = string.Empty;

 
            PropertySet oExtendedPropSet = new PropertySet(BasePropertySet.IdOnly);

            if (oExtendedPropertyDefinitions != null)
            {
                foreach (ExtendedPropertyDefinition oEPD in oExtendedPropertyDefinitions)
                {
                    oExtendedPropSet.Add(oEPD);
                }
            }

            StreamWriter w = File.AppendText(sFilePath);
            char[] TrimChars = { ',', ' ' };
            StringBuilder SbHeader = new StringBuilder();
            foreach (ColumnHeader oCH in oListView.Columns)
            {
                SbHeader.Append(oCH.Text);
                SbHeader.Append(",");
            }
            sHeader = SbHeader.ToString();
            sHeader = sHeader.TrimEnd(TrimChars);

            if (oAdditionalPropertyDefinitions != null)
            {
                sHeader += "," + AdditionalProperties.GetExtendedPropertyHeadersAsCsvContent(oAdditionalPropertyDefinitions);
                sHeader = sHeader.TrimEnd(TrimChars);
            }

            w.WriteLine(sHeader);

             
            ItemId oItemId = null;
            string sExtendedValue = string.Empty;

            string s = string.Empty;
            foreach (ListViewItem oListViewItem in oListView.Items)
            {
                StringBuilder SbLine = new StringBuilder();
                //oCalendarItemTag = (CalendarItemTag)oListViewItem.Tag;
                oItemId = (ItemId)oListViewItem.Tag;

                if (oListViewItem.Selected == true)
                {
                      
                    foreach (ListViewItem.ListViewSubItem o in oListViewItem.SubItems)
                    {
                        s = (o.Text);
                        if (s.Contains(','))
                            s = s.Replace(",", " "); // need to strip commas as this is a csv file.
                        SbLine.Append(s);
                        SbLine.Append(",");
                    }
 
                }

                sLine = SbLine.ToString();
                sLine = sLine.TrimEnd(TrimChars);

                //  Add Additional Properties ----------------------------------------------


                StringBuilder oStringBuilder = new StringBuilder();

                if (oExtendedPropertyDefinitions != null)
                {
                    string sExt = AdditionalProperties.GetExtendedPropertiesForItemAsCsvContent(
                        oExchangeService,
                        oItemId,
                        oExtendedPropertyDefinitions
                        );
                    sLine = "," + sExt;

                    sLine = SbLine.ToString();
                    sLine = sLine.TrimEnd(TrimChars);

                }
  
                w.WriteLine(sLine);

                bRet = true;
            }

            w.Close();

            return bRet;
        }
 
        
    }
}
