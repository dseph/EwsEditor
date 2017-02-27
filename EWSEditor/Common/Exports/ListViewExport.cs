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

//using EWSEditor.Common.Exports;
 

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
                       
                        // clean or encode strings to prevent issus with usage in a CSV? ----------
                        if (oCsvExportOptions._CsvStringHandling != CsvStringHandling.None)
                            s = AdditionalProperties.DoStringHandling(s , oCsvExportOptions._CsvStringHandling );

                        // Re-encode byte data?   --------------------------------------------
                        //bool bColumnIsByteArray = false;  
                        //foreach (int iColumn in iByteArrCollumns) // re-encode known binary grid columns.
                        //{
                        //    if (iColumnCount == iColumn)
                        //        bColumnIsByteArray = true;
                        //}

                        // If its base64 encoded then convert it to hex encoded.
                        if (oCsvExportOptions.HexEncodeBinaryData == true)
                        {
                            //bColumnIsByteArray = StringHelper.IsBase64Encoded(s);
                            if (StringHelper.IsBase64Encoded(s) == true)
                            {
                                oFromBytes = System.Convert.FromBase64String(s); // Base64 to byte array.
                                s = StringHelper.HexStringFromByteArray(oFromBytes, false);
                            }
                        }

                        // Exclusions --------------------------------------------
                        if (oCsvExportOptions._CsvExportGridExclusions != Exports.CsvExportGridExclusions.ExportAll)
                        {
                            if (oCsvExportOptions._CsvExportGridExclusions == Exports.CsvExportGridExclusions.ExcludeAllInGridExceptFilePath)
                            {
                                if (iFolderPathColumn == iColumnCount)
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

        public static bool SaveItemListViewToCsv(
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

            int iFolderPathColumn = 14;  // Folder Path
 
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
                
                ItemTag oCalendarItemTag = (ItemTag)oListViewItem.Tag;
                oItemId = oCalendarItemTag.Id;
                byte[] oFromBytes;


                if (oListViewItem.Selected == true)
                {
                    int iColumnCount = 0;
                    foreach (ListViewItem.ListViewSubItem o in oListViewItem.SubItems)
                    {
                        iColumnCount++;

                        s = (o.Text);

                        // clean or encode strings to prevent issus with usage in a CSV? ----------
                        if (oCsvExportOptions._CsvStringHandling != CsvStringHandling.None)
                            s = AdditionalProperties.DoStringHandling(s, oCsvExportOptions._CsvStringHandling);

 

                        // If its base64 encoded then convert it to hex encoded.
                        if (oCsvExportOptions.HexEncodeBinaryData == true)
                        {
                            //bColumnIsByteArray = StringHelper.IsBase64Encoded(s);
                            if (StringHelper.IsBase64Encoded(s) == true)
                            {
                                oFromBytes = System.Convert.FromBase64String(s); // Base64 to byte array.
                                s = StringHelper.HexStringFromByteArray(oFromBytes, false);
                            }
                        }

                        // Exclusions --------------------------------------------
                        if (oCsvExportOptions._CsvExportGridExclusions != Exports.CsvExportGridExclusions.ExportAll)
                        {
                            if (oCsvExportOptions._CsvExportGridExclusions == Exports.CsvExportGridExclusions.ExcludeAllInGridExceptFilePath)
                            {
                                if (iFolderPathColumn == iColumnCount)
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

 
        //private   bool IsBase64Encoded(this string base64String)
        //{
        //    return false;
        //    //// /part of the code came from: oybek http://stackoverflow.com/users/794764/oybek
        //    ////string s = base64String.Trim();


        //    //if (base64String == null ||
        //    //    base64String.Length == 0 ||
        //    //    base64String.Length % 4 != 0 ||
        //    //    base64String.Contains(" ") ||
        //    //    base64String.Contains("\t") ||
        //    //    base64String.Contains("\r") ||
        //    //    base64String.Contains("\n"))
        //    //    return false;

        //    //// String length should be divisible by 4 with no remainder.

        //    //// https://en.wikipedia.org/wiki/Base64
        //    //// Base64 transfer encoding for MIME manates a '=' pad character. (RFC 2045)
        //    //// Standard 'base64' encoding for RFC 3548 or RFC 4648 - mandated '=' unless another doc says otherwise.
        //    //if (!base64String.EndsWith("="))
        //    //    return false;

        //    //try
        //    //{
        //    //    Convert.FromBase64String(base64String);
        //    //    return true;
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    // Handle the exception
        //    //}
        //    //return false;
        //}
 
   
    }
}
