using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Exchange.WebServices.Data;

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



            // Get property definition list.
            bRet = GetAdditionalPropertiesDefinitionsFromCsv(ref sChosenFile, ref oAdditionalPropertyDefinitions);
            if (bRet == false)
                return false;

            // build list of ExtendedPropertyDefinition using list of AdditionalProperty
            try
            {
                foreach (AdditionalPropertyDefinition o in oAdditionalPropertyDefinitions)
                {
                    if (GetMapiPropertyTypeFromString(o.PropertyType, ref oType))
                    {
                        oExtendedPropertyDefinition = new ExtendedPropertyDefinition(new Guid(o.PropertySetId), o.PropertyId, oType);
                        oExtendedPropertyDefinitions.Add(oExtendedPropertyDefinition);
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

            switch (sProperty)
            {
                case "Integer":
                    oMapiPropertyType = MapiPropertyType.Integer;
                    break;
                case "String":
                    oMapiPropertyType = MapiPropertyType.String;
                    break;
                case "Binary":
                    oMapiPropertyType = MapiPropertyType.Binary;
                    break;
                case "Long":
                    oMapiPropertyType = MapiPropertyType.Long;
                    break;
                case "Boolean":
                    oMapiPropertyType = MapiPropertyType.Boolean;
                    break;
                case "SystemTime":
                    oMapiPropertyType = MapiPropertyType.SystemTime;
                    break;
                default:
                    MessageBox.Show(string.Format("Non-supported data type in CSV: {0}.", sProperty), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
            }
            return true;
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

            AdditionalPropertyDefinition oAdditionalPropertyDefinition = null;
            string sUseLine = string.Empty;
            int iLine = 0;
            foreach (string sLine in sLines)
            {
                iLine++;
                sUseLine = sLine.Replace("\"", "");
                

                // skip first line (header) and skip blank lines
                if (sUseLine.Trim().Length != 0 && iLine != 1)
                {
                    oAdditionalPropertyDefinition = new AdditionalPropertyDefinition();

                    sColumns = sUseLine.Split(sArrSplitFields, StringSplitOptions.None);
                    iColumnCount = sColumns.Count<string>();
                    if (iColumnCount != 5)
                    {
                        MessageBox.Show(string.Format("Line {0} of the CSV file does not have the correct number of columns.", iLine), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }

                    
                    oAdditionalPropertyDefinition.PropertyName = sColumns[0].Trim();
                    oAdditionalPropertyDefinition.PropertySetId = sColumns[1].Trim();
                    oAdditionalPropertyDefinition.PropertyDefinitionType = sColumns[2].Trim();
                    oAdditionalPropertyDefinition.PropertyId = sColumns[3].Trim();
                    oAdditionalPropertyDefinition.PropertyType = sColumns[4].Trim();

                    oAdditionalPropertyDefinitions.Add(oAdditionalPropertyDefinition);
                }
            }

            return bRet;
        }


        public static bool GetCsvFileContents(ref string sChosenFile, ref string sCsvFileContents)
        {
            bool bRet = false;
            string sFolderPath = GetPathToAdditionalPropertiesFolder();
            sCsvFileContents = string.Empty;

            System.Windows.Forms.OpenFileDialog oFD = new System.Windows.Forms.OpenFileDialog();

            string sFile = string.Empty;


            if (UserIoHelper.PickLoadFromFile(Application.UserAppDataPath, "*.csv", ref sFile, "CSV files (*.csv)|*.csv"))
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
                oPropertySet.Add(oEPD);
            }
        }



        public static string GetExtendedPropertiesForItemAsCsvContent(
            ExchangeService oExchangeService, 
            ItemId oItemId,
            List<ExtendedPropertyDefinition> oExtendedPropertyDefinitions 
            )
        {
            //AddExtendedPropertPropertyDefinitionsToPropertySet(oExtendedPropertyDefinitions)

            PropertySet oExtendedPropSet = GetExtendedPropertPropertySet(oExtendedPropertyDefinitions);

            string sExtendedValue = string.Empty;
            StringBuilder oStringBuilder = new StringBuilder();
            Item oItem = Item.Bind(oExchangeService, oItemId, oExtendedPropSet);
            string sItemLine = string.Empty;
            char[] TrimChars = { ',', ' ' };
            
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
                        sExtendedValue = EwsExtendedPropertyHelper.GetExtendedProp_ByteArr_AsString(oItem, oEPD);
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
                    default:
                        sExtendedValue = "";
                        break;

                }  // end switch

                if (sExtendedValue.Contains(','))
                    sExtendedValue = sExtendedValue.Replace(",", " "); // need to strip commas as this is a csv file.

                oStringBuilder.Append(sExtendedValue);
                oStringBuilder.Append(",");

                if (sExtendedValue.Trim().Length != 0)
                    System.Diagnostics.Debug.WriteLine("XXX");

            }  // end foreach

            sItemLine += oStringBuilder.ToString();
            sItemLine = sItemLine.TrimEnd(TrimChars);
            return sItemLine;
        }
 
    }

    public class AdditionalPropertyDefinition
    {
        public string PropertyName = string.Empty;
        public string PropertySetId = string.Empty;
        public string PropertyDefinitionType = string.Empty;
        public string PropertyId = string.Empty;
        public string PropertyType = string.Empty;

 
    }

    //public class AdditionalPropertyData : AdditionalPropertyDefinition 
    //{
    //    //public string PropertyName = string.Empty;
    //    //public string PropertySetId = string.Empty;
    //    //public string PropertyDefinitionType = string.Empty;
    //    //public string Property = string.Empty;
    //    //public string PropertyType = string.Empty;
    //    public string PropertyData = string.Empty;
    //}


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

 
