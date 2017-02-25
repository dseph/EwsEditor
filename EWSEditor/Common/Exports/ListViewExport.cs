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
            List<ExtendedPropertyDefinition> oExtendedPropertyDefinitions,
             CsvExportOptions oCsvExportOptions
    )
        {
            bool bRet = false;

            string sHeader = string.Empty;
            string sLine = string.Empty;

            int iFolderPathColumn = 23;  // Folder Path
            int[] iByteArrCollumns = { 12, 13, 24};   // Byte array properties in listview
          

            PropertySet oExtendedPropSet = new PropertySet(BasePropertySet.IdOnly);

            if (oExtendedPropertyDefinitions != null)
            {
                foreach (ExtendedPropertyDefinition oEPD in oExtendedPropertyDefinitions)
                {
                    oExtendedPropSet.Add(oEPD);

                    //if (oEPD.Id == 32812)
                    //{
                    //    Console.Write("");
                         

                    //}
                }
            }

            StreamWriter w = File.AppendText(sFilePath);
            char[] TrimChars = { ',', ' ' };
            StringBuilder SbHeader = new StringBuilder();
            int iHeaderCount = 0;
            // Build header part for listview
            foreach (ColumnHeader oCH in oListView.Columns)
            {
                iHeaderCount++;
                // Exclusions
                if (oCsvExportOptions._CsvExportGridExclusions != Exports.CsvExportGridExclusions.ExportAll)
                {
                    if (oCsvExportOptions._CsvExportGridExclusions == Exports.CsvExportGridExclusions.ExcludeAllInGridExceptFilePath)
                    {
                        if (iFolderPathColumn == iHeaderCount)
                        {

                            SbHeader.Append(oCH.Text);
                            SbHeader.Append(",");
                        }
                    }
                }
                else
                {


                    SbHeader.Append(oCH.Text);
                    SbHeader.Append(",");
                }
 
            }
            sHeader = SbHeader.ToString();
            sHeader = sHeader.TrimEnd(TrimChars);
            // Add headers for custom properties.
            if (oAdditionalPropertyDefinitions != null)
            {
                sHeader += "," + AdditionalProperties.GetExtendedPropertyHeadersAsCsvContent(oAdditionalPropertyDefinitions);
                sHeader = sHeader.TrimEnd(TrimChars);
            }

            w.WriteLine(sHeader);


            ItemId oItemId = null;
            string sExtendedValue = string.Empty;

            int iCount = 0;

  

            string s = string.Empty;
            foreach (ListViewItem oListViewItem in oListView.SelectedItems)
            {

                iCount++; 

                StringBuilder SbLine = new StringBuilder();
                //oCalendarItemTag = (CalendarItemTag)oListViewItem.Tag;
                CalendarItemTag oCalendarItemTag = (CalendarItemTag)oListViewItem.Tag;  
                oItemId = oCalendarItemTag.Id;
                byte[] oFromBytes;

 
                if (oListViewItem.Selected == true)
                {
                    int iColumnCount = 0;
                    foreach (ListViewItem.ListViewSubItem o in oListViewItem.SubItems)
                    {
                        iColumnCount++;

                        s = (o.Text);
                       
                        if (oCsvExportOptions._CsvStringHandling != CsvStringHandling.None)
                            s = AdditionalProperties.DoStringHandling(s , oCsvExportOptions._CsvStringHandling );

 


                        //if (oCsvStringHandling != CsvStringHandling.None)
                        //{
                        //    if (oEPD.MapiType == MapiPropertyType.String)
                        //        sExtendedValue = DoStringHandling(sExtendedValue, oCsvStringHandling);
                        //}

                        //// String Handling
                        //if (oCsvStringHandling == CsvStringHandling.Base64encode)
                        //{
                        //    oFromBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(s);
                        //    s = Convert.ToBase64String(oFromBytes);  // reverse: Convert.FromBase64String(string data)
                        //}

                        //if (oCsvStringHandling == CsvStringHandling.SanitizeStrings)
                        //{
                        //    //if (s.Contains(','))
                        //    s = s.Replace(",", " "); // need to strip commas as this is a csv file.
                        //    s = s.Replace("\r", "");
                        //    s = s.Replace("\n", "");
                        //}

                        //s = s.Replace(",", " "); // need to strip commas as this is a csv file.
                        //s = s.Replace("\r", "");
                        //s = s.Replace("\n", "");

                        // Re-encode byte data?
                        bool bColumnIsByteArray = false;  
                        foreach (int iColumn in iByteArrCollumns)
                        {
                            if (iColumnCount == iColumn)
                                bColumnIsByteArray = true;
                        }

                        if (oCsvExportOptions.HexEncodeBinaryData == true && bColumnIsByteArray == true)
                        {
                            oFromBytes = System.Convert.FromBase64String(s); // Base64 to byte array.
                            s = StringHelper.HexStringFromByteArray(oFromBytes, false);
                        }
 
                        // Exclusions
                        if (oCsvExportOptions._CsvExportGridExclusions != Exports.CsvExportGridExclusions.ExportAll)
                        {
                            if (oCsvExportOptions._CsvExportGridExclusions == Exports.CsvExportGridExclusions.ExcludeAllInGridExceptFilePath)
                            {
                                if (iFolderPathColumn == iCount)
                                {
                                    SbLine.Append(s);
                                    SbLine.Append(",");
                                }
                            }
                        }
                        else
                        {

                            SbLine.Append(s);
                            SbLine.Append(",");
                        }
 

                       
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
                        oExtendedPropertyDefinitions,
                        oCsvExportOptions
                        );

                    // xxx
                    // String Handling
                        //if (oCsvStringHandling == CsvStringHandling.Base64encode)
                        //{
                        //    oFromBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(s);
                        //    s = Convert.ToBase64String(oFromBytes);  // reverse: Convert.FromBase64String(string data)
                        //}

                        //if (oCsvStringHandling == CsvStringHandling.SanitizeStrings)
                        //{
                        //    //if (s.Contains(','))
                        //    s = s.Replace(",", " "); // need to strip commas as this is a csv file.
                        //    s = s.Replace("\r", "");
                        //    s = s.Replace("\n", "");
                        //}

                        //SbLine.Append(s);
                        //SbLine.Append(",");
                    //   
                    sLine += "," + sExt;

                    //sLine = SbLine.ToString();
                    sLine = sLine.TrimEnd(TrimChars);

                }

                w.WriteLine(sLine);

                bRet = true;
            }

            w.Close();

            return bRet;
        }

        //public static bool SaveListViewToCsv(
        //    ExchangeService oExchangeService,
        //    ListView oListView, 
        //    string sFilePath,
        //    List<AdditionalPropertyDefinition> oAdditionalPropertyDefinitions,
        //    List<ExtendedPropertyDefinition> oExtendedPropertyDefinitions
        //    )
        //{
        //    bool bRet = false;

        //    string sHeader = string.Empty;
        //    string sLine = string.Empty;

 
        //    PropertySet oExtendedPropSet = new PropertySet(BasePropertySet.IdOnly);

        //    if (oExtendedPropertyDefinitions != null)
        //    {
        //        foreach (ExtendedPropertyDefinition oEPD in oExtendedPropertyDefinitions)
        //        {
        //            oExtendedPropSet.Add(oEPD);
        //        }
        //    }

        //    StreamWriter w = File.AppendText(sFilePath);
        //    char[] TrimChars = { ',', ' ' };
        //    StringBuilder SbHeader = new StringBuilder();
        //    foreach (ColumnHeader oCH in oListView.Columns)
        //    {
        //        SbHeader.Append(oCH.Text);
        //        SbHeader.Append(",");
        //    }
        //    sHeader = SbHeader.ToString();
        //    sHeader = sHeader.TrimEnd(TrimChars);

        //    if (oAdditionalPropertyDefinitions != null)
        //    {
        //        sHeader += "," + AdditionalProperties.GetExtendedPropertyHeadersAsCsvContent(oAdditionalPropertyDefinitions);
        //        sHeader = sHeader.TrimEnd(TrimChars);
        //    }

        //    w.WriteLine(sHeader);

             
        //    ItemId oItemId = null;
        //    string sExtendedValue = string.Empty;

        //    string s = string.Empty;
        //    foreach (ListViewItem oListViewItem in oListView.Items)
        //    {
        //        StringBuilder SbLine = new StringBuilder();
        //        //oCalendarItemTag = (CalendarItemTag)oListViewItem.Tag;
        //        oItemId = (ItemId)oListViewItem.Tag;

        //        if (oListViewItem.Selected == true)
        //        {
                      
        //            foreach (ListViewItem.ListViewSubItem o in oListViewItem.SubItems)
        //            {


        //                //s = (o.Text);
        //                //if (s.Contains(','))
        //                //    s = s.Replace(",", " "); // need to strip commas as this is a csv file.
        //                //SbLine.Append(s);
        //                //SbLine.Append(",");



        //            }
 
        //        }

        //        sLine = SbLine.ToString();
        //        sLine = sLine.TrimEnd(TrimChars);

        //        //  Add Additional Properties ----------------------------------------------


        //        StringBuilder oStringBuilder = new StringBuilder();

        //        if (oExtendedPropertyDefinitions != null)
        //        {
        //            string sExt = AdditionalProperties.GetExtendedPropertiesForItemAsCsvContent(
        //                oExchangeService,
        //                oItemId,
        //                oExtendedPropertyDefinitions,
        //                oCsvStringHandling
        //                );
        //            sLine = "," + sExt;

        //            sLine = SbLine.ToString();
        //            sLine = sLine.TrimEnd(TrimChars);

        //        }
  
        //        w.WriteLine(sLine);

        //        bRet = true;
        //    }

        //    w.Close();

        //    return bRet;
        //}
 
        
    }
}
