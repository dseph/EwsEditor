using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Exchange.WebServices.Data;
using EWSEditor.Forms;

namespace EWSEditor.Common.Exports
{
    public class AdditionalProperties
    {
        public static bool GetAdditionalPropertiesFromCsv(
            ref string sChosenFile,
            ref List<AdditionalPropertyDefinition> oAdditionalPropertyDefinitions,
            ref List<ExtendedPropertyDefinition> oExtendedPropertyDefinitions
            )
        {
            bool bRet = false;
            oExtendedPropertyDefinitions = new List<ExtendedPropertyDefinition>();
            oAdditionalPropertyDefinitions = new List<AdditionalPropertyDefinition>();

            ExtendedPropertyDefinition oExtendedPropertyDefinition = null;
            //AdditionalPropertyDefinition oAdditionalPropertyDefinition = null;

            MapiPropertyType oType = MapiPropertyType.String;

            // ----------------------

            // Get property definition list.
            // Before:
            //bRet = GetAdditionalPropertiesDefinitionsFromCsv(ref sChosenFile, ref oAdditionalPropertyDefinitions);

            // Use form...
            PropertySetDialogAddFromCSV oForm = new PropertySetDialogAddFromCSV(sChosenFile);
            oForm.ShowDialog();
            if (oForm.ClickedOK == true)
            {
 
                oAdditionalPropertyDefinitions = oForm.APD;
                sChosenFile = oForm.ChosenFile;
                bRet = true;
            }
            else
                bRet = false;

            // ------------------------------
            if (bRet == false)
                return false;

            int iCount = 0;

            // build list of ExtendedPropertyDefinition using list of AdditionalProperty
            try
            {
                foreach (AdditionalPropertyDefinition o in oAdditionalPropertyDefinitions)
                {

                    iCount++;
 
                    if (GetMapiPropertyTypeFromString(o.PropertyType, ref oType))
                    {
                        // Named Property?
                        if (o.PropertyIdIsString == true)
                        { 
                            
                            ////PropertyType = string.Empty;
                            ////ropertyIdIsString = false;
                            //oExtendedPropertyDefinition = new ExtendedPropertyDefinition(o.PropertySetIdString, o., oType);
                            //oExtendedPropertyDefinitions.Add(oExtendedPropertyDefinition);

                            if (o.PropertySetId == "")   // Have a propset guid?
                            {
                                // Need the propset guid for the custom property...

                                string sBad = string.Format("Line {0} has an invalide Property Set ID: \"{1}\".",
                                    iCount, o.PropertySetId);
                                MessageBox.Show(sBad, "Error in CSV.");

                                return false;
                            }
                            else
                            {
                                oExtendedPropertyDefinition = new ExtendedPropertyDefinition(new Guid(o.PropertySetId), o.PropertySetIdString, oType);
                                oExtendedPropertyDefinitions.Add(oExtendedPropertyDefinition);
                            }

                        }

                        if (o.PropertyIdIsString == false)
                        { 
                            if (o.PropertySetId == "")      // Have a propset guid?
                            { 
                                oExtendedPropertyDefinition = new ExtendedPropertyDefinition(o.PropertyId, oType);
                                oExtendedPropertyDefinitions.Add(oExtendedPropertyDefinition);
                            }
                            else
                            {
                                oExtendedPropertyDefinition = new ExtendedPropertyDefinition(new Guid(o.PropertySetId), o.PropertyId, oType);
                                oExtendedPropertyDefinitions.Add(oExtendedPropertyDefinition);
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error converting CSV data into properties. : \r\n\r\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                bRet = false;
            }

            return bRet;
        }



        public static bool GetMapiPropertyTypeFromString(string sProperty, ref MapiPropertyType oMapiPropertyType)
        {

            switch (sProperty.ToUpper())
            {
                case "INTEGER":
                    oMapiPropertyType = MapiPropertyType.Integer;
                    break;
                case "STRING":
                    oMapiPropertyType = MapiPropertyType.String;
                    break;
                case "BINARY":
                    oMapiPropertyType = MapiPropertyType.Binary;
                    break;
                case "LONG":
                    oMapiPropertyType = MapiPropertyType.Long;
                    break;
                case "SHORT":   
                    oMapiPropertyType = MapiPropertyType.Short;
                    break;
                case "FLOAT":
                    oMapiPropertyType = MapiPropertyType.Float;
                    break;
                case "BOOLEAN":
                    oMapiPropertyType = MapiPropertyType.Boolean;
                    break;
                case "SYSTEMTIME":
                    oMapiPropertyType = MapiPropertyType.SystemTime;
                    break;

                case "INTEGERARRAY":
                    oMapiPropertyType = MapiPropertyType.IntegerArray;
                    break;
                case "STRINGARRAY":
                    oMapiPropertyType = MapiPropertyType.StringArray;
                    break;
                case "BINARYARRAY":
                    oMapiPropertyType = MapiPropertyType.BinaryArray;
                    break;
                case "LONGARRAY":
                    oMapiPropertyType = MapiPropertyType.LongArray;
                    break;
                case "SHORTARRAY":
                    oMapiPropertyType = MapiPropertyType.ShortArray;
                    break;
                case "FLOATARRAY":
                    oMapiPropertyType = MapiPropertyType.FloatArray;
                    break;
                case "SYSTEMTIMEARRAY":
                    oMapiPropertyType = MapiPropertyType.SystemTimeArray;
                    break;

                default:
                    MessageBox.Show(string.Format("Non-supported data type in CSV: {0}.", sProperty), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
            }
            return true;
        }

        public static bool GetAdditionalPropertiesDefinitionsFromString(
        string sFileContents,
         ref List<AdditionalPropertyDefinition> oAdditionalPropertyDefinitions)
        {
            bool bRet = false;

            
            oAdditionalPropertyDefinitions = new List<AdditionalPropertyDefinition>();
            //bRet = GetCsvFile(sFile, ref sFileContents);

            List<string> listHeaders = new List<string>();

            sFileContents = sFileContents.Replace("\r\n", "\n");
            sFileContents = sFileContents.Replace("\r", "\n");
            sFileContents = sFileContents.Replace("\n", "\r\n");
            string[] sArrSplitLines = { "\r\n" };
            string[] sLines = sFileContents.Split(sArrSplitLines, StringSplitOptions.None);

            string[] sArrSplitFields = { "," };
            string[] sColumns;

            int iColumnCount = 0;

            int iPropertyId = 0;
            AdditionalPropertyDefinition oAdditionalPropertyDefinition = null;
            string sUseLine = string.Empty;
            bool bFoundFirstDataLine = false;
            string sPropertySetId = string.Empty;

            int iLine = 0;
            foreach (string sLine in sLines)
            {
                iLine++;
                sUseLine = sLine.Replace("\"", "");
                sUseLine = sUseLine.Trim();

                if (sUseLine.Length == 0 || (sUseLine.Trim().StartsWith("//") == true))  // skip blank lines and comment lines.
                    continue;

                if (bFoundFirstDataLine == false)
                {
                    // This should be the header line. If so then skip it.
                    bFoundFirstDataLine = true;
                }
                else
                {
                    // These should all be lines to process.
                    

                    oAdditionalPropertyDefinition = new AdditionalPropertyDefinition();

                    sColumns = sUseLine.Split(sArrSplitFields, StringSplitOptions.None);
                    iColumnCount = sColumns.Count<string>();
                    if (iColumnCount != 5)
                    {
                        string sInfo = (string.Format("Line {0} of the CSV file does not have the correct number of columns. See line with the following text:\r\n{1}", iLine, sUseLine));
                        MessageBox.Show(sInfo, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }

                    oAdditionalPropertyDefinition.DescPropertyName = sColumns[0].Trim();
                    oAdditionalPropertyDefinition.PropertyName = sColumns[1].Trim();
                    oAdditionalPropertyDefinition.PropertyType = sColumns[4].Trim();
                    //oAdditionalPropertyDefinition.PropertyId = iPropertyId;


                    oAdditionalPropertyDefinition.PropertyId = 0;
                    oAdditionalPropertyDefinition.PropertyIdIsString = false;
                    oAdditionalPropertyDefinition.PropertySetIdString = "";

                    bool bIsNumber = false;
                    string sVal = sColumns[3].Trim().ToUpper();  

                    if (StringHelper.IsInteger(sVal))
                        bIsNumber = true;
                    if (sVal.StartsWith("0X"))
                        bIsNumber = true;
                    //if (bIsNumber == false)
                    //    sVal = sColumns[3].Trim();

                    if (bIsNumber == false)
                    {
                        // This would be a named property - so, no id.
                        oAdditionalPropertyDefinition.PropertyIdIsString = true;
                        oAdditionalPropertyDefinition.PropertySetIdString = sColumns[3].Trim();
                    }

 
                    if (bIsNumber == true)
                    {
                        
                        try
                        {
                            if (sVal.StartsWith("0X"))  // Hex value?
                            {
                                sVal = sVal.Replace("0X", ""); // remove hex prefix
                                iPropertyId = Convert.ToInt32(sVal, 16);    // Convert from hex to int.
                            }
                            else
                            {
                                iPropertyId = Convert.ToInt32(sColumns[3].Trim());  // value is already an int.
                            }
                            oAdditionalPropertyDefinition.PropertyId = iPropertyId;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(string.Format("Line {0} of the CSV file has a non-numeric PropertyId. See {1} ", iLine, sColumns[1].Trim()), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                    }

                    if (sPropertySetId.StartsWith("http"))
                        System.Diagnostics.Debug.WriteLine("Test");

                    sPropertySetId = EwsExtendedPropertyHelper.TrySwapGuidForPropSetName(sColumns[2].Trim(),
                            oAdditionalPropertyDefinition.PropertyId, 
                            oAdditionalPropertyDefinition.PropertyType,
                            sUseLine,
                            iLine
                            );          
            
                    oAdditionalPropertyDefinition.PropertySetId = sPropertySetId;

                    oAdditionalPropertyDefinitions.Add(oAdditionalPropertyDefinition);
                   
                }
            }

            bRet = true;

            return bRet;
        }


        private static bool GetAdditionalPropertiesDefinitionsFromCsv(
            ref string sChosenFile,
            ref List<AdditionalPropertyDefinition> oAdditionalPropertyDefinitions)
        {
            bool bRet = false;
            string sFileContents = string.Empty;
            bRet = GetCsvFileContents(ref sChosenFile, ref sFileContents);

            if (bRet == false)
                return false;

 
            // return GetAdditionalPropertiesDefinitionsFromString(sFileContents, ref oAdditionalPropertyDefinitions);
            // Look at replacing whats below  with the line above.

            // The file is now loaded....


            oAdditionalPropertyDefinitions = new List<AdditionalPropertyDefinition>();
            //bRet = GetCsvFile(sFile, ref sFileContents);

            List<string> listHeaders = new List<string>();

            sFileContents = sFileContents.Replace("\r\n", "\n");
            sFileContents = sFileContents.Replace("\r", "\n");
            sFileContents = sFileContents.Replace("\n", "\r\n");
            string[] sArrSplitLines = { "\r\n" };
            string[] sLines = sFileContents.Split(sArrSplitLines, StringSplitOptions.None);

            string[] sArrSplitFields = { "," };
            string[] sColumns;

            int iColumnCount = 0;

            int iPropertyId = 0;
            AdditionalPropertyDefinition oAdditionalPropertyDefinition = null;
            string sUseLine = string.Empty;
            bool bFoundFirstDataLine = false;
            string sPropertySetId = string.Empty;

            //Console.WriteLine("============  GetAdditionalPropertiesDefinitionsFromCsv  ====" + DateTime.Now.ToString() + "  ==================");

            int iLine = 0;
            foreach (string sLine in sLines)
            {
                iLine++;
                sUseLine = sLine.Replace("\"", "");
                sUseLine = sUseLine.Trim();

                if (sUseLine.Length == 0 || (sUseLine.Trim().StartsWith("//") == true))  // skip blank lines and comment lines.
                    continue;

                if (bFoundFirstDataLine == false)
                {
                    // This should be the header line. If so then skip it.
                    bFoundFirstDataLine = true;
                }
                else
                {
                    // These should all be lines to process.

 
                    oAdditionalPropertyDefinition = new AdditionalPropertyDefinition();

                    sColumns = sUseLine.Split(sArrSplitFields, StringSplitOptions.None);
                    iColumnCount = sColumns.Count<string>();
                    if (iColumnCount != 5)
                    {
                       string sInfo = (string.Format("Line {0} of the CSV file does not have the correct number of columns. See line with the following text:\r\n{1}", iLine, sUseLine));
                        MessageBox.Show(sInfo, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                       
                    }

                    bool bIsNumber = false;

                    // Property ID can be different things
                    string sVal = sColumns[3].Trim().ToUpper();  
                    try
                    {// PropertyIdIsString
                        oAdditionalPropertyDefinition.PropertySetIdString = "";
                        oAdditionalPropertyDefinition.PropertyId = 0;
                        oAdditionalPropertyDefinition.PropertyIdIsString = false;

                        if (StringHelper.IsInteger(sVal))
                            bIsNumber = true;
                        if (sVal.StartsWith("0X"))
                            bIsNumber = true;

                        if (bIsNumber == false)
                        {
                            // This would be a named property - so, no id.
                            oAdditionalPropertyDefinition.PropertyIdIsString = true;
                            oAdditionalPropertyDefinition.PropertySetIdString = sVal;
                        }

                        if (bIsNumber == true)
                        {
                            oAdditionalPropertyDefinition.PropertyIdIsString  = false;
                            if (sVal.StartsWith("0X"))  // Hex value?
                            {

                                sVal = sVal.Replace("0X", ""); // remove hex prefix
                                iPropertyId = Convert.ToInt32(sVal, 16);    // Convert from hex to int.
                            }
                            else
                                iPropertyId = Convert.ToInt32(sColumns[3].Trim());  // value is already an int.

                            oAdditionalPropertyDefinition.PropertyId = iPropertyId;
                        }
                         
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(string.Format("Line {0} of the CSV file has a non-numeric PropertyId. See {1} ", iLine, sColumns[1].Trim()), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }

 
                    oAdditionalPropertyDefinition.DescPropertyName = sColumns[0].Trim();
                    oAdditionalPropertyDefinition.PropertyName = sColumns[1].Trim();

                   // oAdditionalPropertyDefinition.PropertyId = iPropertyId;   
                    oAdditionalPropertyDefinition.PropertyType = sColumns[4].Trim();

                    sPropertySetId = EwsExtendedPropertyHelper.TrySwapGuidForPropSetName(sColumns[2].Trim(),
                        oAdditionalPropertyDefinition.PropertyId,
                        oAdditionalPropertyDefinition.PropertyType, sUseLine, iLine
                        );

                    oAdditionalPropertyDefinition.PropertySetId = sPropertySetId;
 
                    //oAdditionalPropertyDefinition.PropertyDefinitionType = sColumns[3].Trim();
   
                    oAdditionalPropertyDefinitions.Add(oAdditionalPropertyDefinition);

                    // For debugging  - start
                    //string sDebug = string.Format("PropertyName: {0},  PropertyType: {1},  PropSetId: {2},  PropertyId: {3},  PropertyIdIsString {4}, PropertySetIdString {5}, Line: {6}\r\n", 
                    //    oAdditionalPropertyDefinition.PropertyName, 
                    //    oAdditionalPropertyDefinition.PropertyType, 
                    //    oAdditionalPropertyDefinition.PropertySetId,
                    //    oAdditionalPropertyDefinition.PropertyId.ToString(),
                    //    oAdditionalPropertyDefinition.PropertyIdIsString,
                    //    oAdditionalPropertyDefinition.PropertySetIdString,
                    //    iLine.ToString()
                    //    );
                    //Console.Write(sDebug);
                    //if (oAdditionalPropertyDefinition.PropertyId == 0 && oAdditionalPropertyDefinition.PropertyIdIsString == false)
                    //    Console.WriteLine("*****    (oAdditionalPropertyDefinition.PropertySetId == 0 && PropertyIdIsString == false)");
                    // For debugging  - end
                }
            }

            bRet = true;

            return bRet;
        }

      
 

        public static bool GetCsvFileContents(ref string sChosenFile, ref string sCsvFileContents)
        {
            bool bRet = false;
            string sFolderPath = GetPathToAdditionalPropertiesFolder();
            sCsvFileContents = string.Empty;

            System.Windows.Forms.OpenFileDialog oFD = new System.Windows.Forms.OpenFileDialog();

            string sFile = string.Empty;

            string sPath = (Path.GetDirectoryName(sChosenFile));

            if (UserIoHelper.PickLoadFromFile(sPath, "*.csv", ref sFile, "CSV files (*.csv)|*.csv"))
            {
                try
                {

                    sChosenFile = sFile;
                    sCsvFileContents = System.IO.File.ReadAllText(sFile);

                    bRet = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error loading file.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

            }

            return bRet;
        }

        public static string GetPathToAdditionalPropertiesFolder()
        {
            string sFolderPath = Application.StartupPath + "\\AdditionalProperties";

            return sFolderPath;
        }

        public static string GetExtendedPropertyHeadersAsCsvContent(
            List<AdditionalPropertyDefinition> oAdditionalPropertyDefinitions
            )
        {
            StringBuilder oStringBuilder = new StringBuilder();
            string sItemLine = string.Empty;
            char[] TrimChars = { ',', ' ' };

            foreach (AdditionalPropertyDefinition o in oAdditionalPropertyDefinitions)
            {
                oStringBuilder.Append(o.PropertyName);
                oStringBuilder.Append(",");

            }  // end foreach

            sItemLine += oStringBuilder.ToString();
            sItemLine = sItemLine.TrimEnd(TrimChars);

            return sItemLine;
        }

        public static PropertySet GetExtendedPropertPropertySet(List<ExtendedPropertyDefinition> oExtendedPropertyDefinitions)
        { 
            PropertySet oExtendedPropSet = new PropertySet(BasePropertySet.IdOnly);
            AddExtendedPropertPropertyDefinitionsToPropertySet(ref oExtendedPropSet, oExtendedPropertyDefinitions);

            return oExtendedPropSet;
        }

        public static void AddExtendedPropertPropertyDefinitionsToPropertySet(ref PropertySet oPropertySet, List<ExtendedPropertyDefinition> oExtendedPropertyDefinitions)
        {


            //ExtendedProperty abc = new ExtendedProperty();
            
              

            foreach (ExtendedPropertyDefinition oEPD in oExtendedPropertyDefinitions)
            {
                System.Diagnostics.Debug.WriteLine(oEPD.ToString());
                oPropertySet.Add(oEPD);
            }
        }



        public static string GetExtendedPropertiesForItemAsCsvContent(
            ExchangeService oExchangeService, 
            ItemId oItemId,
            List<ExtendedPropertyDefinition> oExtendedPropertyDefinitions,
            CsvExportOptions oCsvExportOptions
            )
        {
            //AddExtendedPropertPropertyDefinitionsToPropertySet(oExtendedPropertyDefinitions)

            PropertySet oExtendedPropSet = GetExtendedPropertPropertySet(oExtendedPropertyDefinitions);

            string sExtendedValue = string.Empty;
            StringBuilder oStringBuilder = new StringBuilder();
            int ix = 0;

            //// Debug
            //foreach ( ExtendedPropertyDefinition  x in oExtendedPropSet )
            //{
            //    ix++;
            //    if (x.Id == null)
            //        Console.WriteLine("MapiType: " + x.MapiType.ToString() + "  Type: " + x.Type.ToString() + "  PropertySetId" + x.PropertySetId.ToString() + " Count: " + ix.ToString());
            //    else
            //        Console.WriteLine("MapiType: " + x.MapiType.ToString() + "  Type: " + x.Type.ToString() + "  PropertySetId" + x.PropertySetId.ToString() + "  Id:" + x.Id.ToString() + " Count: " + ix.ToString());
            //    if (x.Id == null)
            //        Console.Write("");
            //    else
            //        if (x.Id == 0)
            //             Console.Write("");
            //}

            oExchangeService.ClientRequestId = Guid.NewGuid().ToString();  // Set a new GUID.
            Item oItem = Item.Bind(oExchangeService, oItemId, oExtendedPropSet);

            string sItemLine = string.Empty;
            char[] TrimChars = { ',', ' ' };
            byte[] oFromBytes;
            
            foreach (ExtendedPropertyDefinition oEPD in oExtendedPropertyDefinitions)
            {
                switch (oEPD.MapiType)
                { 
                    case MapiPropertyType.Integer:
                        sExtendedValue = EwsExtendedPropertyHelper.GetExtendedProp_Int_AsString(oItem, oEPD);
                        break;
                    case MapiPropertyType.String:
                        sExtendedValue = EwsExtendedPropertyHelper.GetExtendedProp_String_AsString(oItem, oEPD);
                        break;
                    case MapiPropertyType.Binary:
                        sExtendedValue = EwsExtendedPropertyHelper.GetExtendedProp_Byte_AsString(oItem, oEPD);
                        if (oCsvExportOptions.HexEncodeBinaryData == true)
                        {
                            //if (oEPD.Id == 0x0005 || 
                            //    oEPD.Id == 0x8223 ||
                            //    oEPD.Id == 0x000C ||
                            //    oEPD.Id == 0x000D ||
                            //    oEPD.Id == 0x000F ||
                            //    oEPD.Id == 0x0019
                            //    )
                            //{ 
                            //    int a = 0;
                            //    a = 1;
                            //}
                            //byte[] oFromBytes;
                            oFromBytes = System.Convert.FromBase64String(sExtendedValue); // Base64 to byte array.
                            sExtendedValue = StringHelper.HexStringFromByteArray(oFromBytes, false);
                        }
                        break;
                    case MapiPropertyType.Long:
                        sExtendedValue = EwsExtendedPropertyHelper.GetExtendedProp_Long_AsString(oItem, oEPD);
                        break;
                    case MapiPropertyType.Boolean:
                        sExtendedValue = EwsExtendedPropertyHelper.GetExtendedProp_Bool_AsString(oItem, oEPD);
                        break;
                    case MapiPropertyType.SystemTime:
                        sExtendedValue = EwsExtendedPropertyHelper.GetExtendedProp_DateTime_AsString(oItem, oEPD);
                        break;
                    case MapiPropertyType.Short:
                        sExtendedValue = EwsExtendedPropertyHelper.GetExtendedProp_Short_AsString(oItem, oEPD);
                        break;
                    case MapiPropertyType.Float:
                        sExtendedValue = EwsExtendedPropertyHelper.GetExtendedProp_Float_AsString(oItem, oEPD);
                        break;

                    case MapiPropertyType.IntegerArray:
                        sExtendedValue = EwsExtendedPropertyHelper.GetExtendedProp_IntArr_AsString(oItem, oEPD);
                        break;
                    case MapiPropertyType.StringArray:
                        sExtendedValue = EwsExtendedPropertyHelper.GetExtendedProp_StringArr_AsString(oItem, oEPD);
                        break;
                    case MapiPropertyType.BinaryArray:
                        sExtendedValue = EwsExtendedPropertyHelper.GetExtendedProp_ByteArr_AsString(oItem, oEPD);
 
                        break;
                    case MapiPropertyType.LongArray:
                        sExtendedValue = EwsExtendedPropertyHelper.GetExtendedProp_LongArr_AsString(oItem, oEPD);
                        break;
                    case MapiPropertyType.SystemTimeArray:
                        sExtendedValue = EwsExtendedPropertyHelper.GetExtendedProp_DateTimeArr_AsString(oItem, oEPD);
                        break;
                    case MapiPropertyType.ShortArray:
                        sExtendedValue = EwsExtendedPropertyHelper.GetExtendedProp_ShortArr_AsString(oItem, oEPD);
                        break;
                    case MapiPropertyType.FloatArray:
                        sExtendedValue = EwsExtendedPropertyHelper.GetExtendedProp_FloatArr_AsString(oItem, oEPD);
                        break;

                    default:
                        sExtendedValue = "";
                        break;

                }  // end switch

                if (sExtendedValue == null)
                {
                    sExtendedValue ="";
                }


                // String  Handling
                if (oCsvExportOptions._CsvStringHandling != CsvStringHandling.None)
                {
                    sExtendedValue = DoStringHandling(sExtendedValue, oCsvExportOptions._CsvStringHandling);
                }

                //// Hex encode binary (base64 encoded) data.
                //if (oCsvExportOptions.HexEncodeBinaryData == true)
                //{
                //    //bColumnIsByteArray = StringHelper.IsBase64Encoded(s);
                //    if (StringHelper.IsBase64Encoded(sExtendedValue) == true)
                //    {
                //        oFromBytes = System.Convert.FromBase64String(sExtendedValue); // Base64 to byte array.
                //        sExtendedValue = StringHelper.HexStringFromByteArray(oFromBytes, false);
                //    }
                //}

                 


                oStringBuilder.Append(sExtendedValue);
                oStringBuilder.Append(",");


                if (sExtendedValue.Trim().Length != 0)
                    System.Diagnostics.Debug.WriteLine("Warning - Should not have reached this line");

            }  // end foreach

            sItemLine = oStringBuilder.ToString();
            sItemLine = sItemLine.TrimEnd(TrimChars);
            return sItemLine;
        }

        public static string DoStringHandling(string sString, CsvStringHandling oCsvStringHandling)
        {
            if (oCsvStringHandling == CsvStringHandling.None)
                return sString;

            // -----------
            // String Handling
            if (oCsvStringHandling == CsvStringHandling.Base64encode)
            {
                byte[] oFromBytes;
                oFromBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(sString);
                sString = Convert.ToBase64String(oFromBytes);  // reverse: Convert.FromBase64String(string data)
            }

            if (oCsvStringHandling == CsvStringHandling.HexEncode)
            {
                byte[] oFromBytes;
                oFromBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(sString);
                sString = StringHelper.HexStringFromByteArray(oFromBytes, false);
            }

            if (oCsvStringHandling == CsvStringHandling.SanitizeStrings)
            {
                //if (s.Contains(','))
                sString = sString.Replace(",", " "); // need to strip commas as this is a csv file.
                sString = sString.Replace("\r", "");
                sString = sString.Replace("\n", "");
            }

            return sString;
        }
 
    }

    public class AdditionalPropertyDefinition
    {
        public string   DescPropertyName = string.Empty;
        public string   PropertyName = string.Empty;
        public string   PropertySetId = string.Empty;
        public string   PropertyDefinitionType = string.Empty;
        public int      PropertyId = 0;
        public string   PropertyType = string.Empty;
        public bool     PropertyIdIsString = false;
        public string   PropertySetIdString = string.Empty;

    }

    public enum CsvStringHandling
    {
        SanitizeStrings,
        Base64encode,
        HexEncode,
        None
    }

    public class CsvExportOptions
    {
        public CsvStringHandling _CsvStringHandling = CsvStringHandling.SanitizeStrings;
        public CsvExportGridExclusions _CsvExportGridExclusions = CsvExportGridExclusions.ExportAll;
        public bool HexEncodeBinaryData = false;
    }

    public enum CsvExportGridExclusions
    {
        ExportAll,
        ExcludeAllInGrid,
        ExcludeAllInGridExceptFilePath
    }


}

//"PropertyName",    "PropertySetId",                        "PropertyDefinitionType",  "Property",              "PropertyType" 
//"Diag_1",          "11000e07-b51b-40d6-af21-caa85edab1d0", "PropertyType",			  "1",                    "Boolean" 
//"Diag_3",          "11000e07-b51b-40d6-af21-caa85edab1d0", "PropertyType",			  "3",                    "Integer" 
//"Diag_4",          "11000e07-b51b-40d6-af21-caa85edab1d0", "PropertyType",			  "4",                    "Integer" 
//"Diag_5",          "11000e07-b51b-40d6-af21-caa85edab1d0", "PropertyType",			  "5",                    "String" 
//"Diag_7",          "11000e07-b51b-40d6-af21-caa85edab1d0", "PropertyType",			  "7",                    "Binary" 
//"Diag_8",          "11000e07-b51b-40d6-af21-caa85edab1d0", "PropertyType",			  "8",                    "SystemTime" 
//"Diag_9",          "11000e07-b51b-40d6-af21-caa85edab1d0", "PropertyType",			  "9",                    "SystemTime" 

//"Diag_10",          "11000e07-b51b-40d6-af21-caa85edab1d0", "PropertyType",			  "10",                    "String" 
//"Diag_11",          "11000e07-b51b-40d6-af21-caa85edab1d0", "PropertyType",			  "11",                    "String" 
//"Diag_12",          "11000e07-b51b-40d6-af21-caa85edab1d0", "PropertyType",			  "12",                    "String" 
//"Diag_13",          "11000e07-b51b-40d6-af21-caa85edab1d0", "PropertyType",			  "13",                    "String" 
//"Diag_14",          "11000e07-b51b-40d6-af21-caa85edab1d0", "PropertyType",			  "14",                    "String" 

//"Diag_16",          "11000e07-b51b-40d6-af21-caa85edab1d0", "PropertyType",			  "16",                    "String" 
//"Diag_17",          "11000e07-b51b-40d6-af21-caa85edab1d0", "PropertyType",			  "17",                    "String" 
//"Diag_18",          "11000e07-b51b-40d6-af21-caa85edab1d0", "PropertyType",			  "18",                    "String" 
//"Diag_19",          "11000e07-b51b-40d6-af21-caa85edab1d0", "PropertyType",			  "19",                    "String" 
//"Diag_20",          "11000e07-b51b-40d6-af21-caa85edab1d0", "PropertyType",			  "20",                    "String" 

//"Diag_21",          "11000e07-b51b-40d6-af21-caa85edab1d0", "PropertyType",			  "21",                    "String" 
//"Diag_22",          "11000e07-b51b-40d6-af21-caa85edab1d0", "PropertyType",			  "22",                    "String" 
//"Diag_23",          "11000e07-b51b-40d6-af21-caa85edab1d0", "PropertyType",			  "23",                    "String" 
//"Diag_24",          "11000e07-b51b-40d6-af21-caa85edab1d0", "PropertyType",			  "24",                    "String" 
//"Diag_25",          "11000e07-b51b-40d6-af21-caa85edab1d0", "PropertyType",			  "25",                    "Boolean" 

//"Diag_26",          "11000e07-b51b-40d6-af21-caa85edab1d0", "PropertyType",			  "26",                    "String" 
//"Diag_27",          "11000e07-b51b-40d6-af21-caa85edab1d0", "PropertyType",			  "27",                    "String" 
//"Diag_28",          "11000e07-b51b-40d6-af21-caa85edab1d0", "PropertyType",			  "28",                    "String" 
//"Diag_29",          "11000e07-b51b-40d6-af21-caa85edab1d0", "PropertyType",			  "29",                    "String" 
//"Diag_30",          "11000e07-b51b-40d6-af21-caa85edab1d0", "PropertyType",			  "30",                    "String" 

//"Diag_31",          "11000e07-b51b-40d6-af21-caa85edab1d0", "PropertyType",			  "31",                    "String" 
//"Diag_32",          "11000e07-b51b-40d6-af21-caa85edab1d0", "PropertyType",			  "32",                    "Binary" 
//"Diag_33",          "11000e07-b51b-40d6-af21-caa85edab1d0", "PropertyType",			  "33",                    "SystemTime" 
//"Diag_34",          "11000e07-b51b-40d6-af21-caa85edab1d0", "PropertyType",			  "34",                    "SystemTime" 

//"Diag_40",          "11000e07-b51b-40d6-af21-caa85edab1d0", "PropertyType",			  "40",                    "String" 
//"Diag_41",          "11000e07-b51b-40d6-af21-caa85edab1d0", "PropertyType",			  "41",                    "SystemTime" 
//"Diag_42",          "11000e07-b51b-40d6-af21-caa85edab1d0", "PropertyType",			  "42",                    "SystemTime" 

 
