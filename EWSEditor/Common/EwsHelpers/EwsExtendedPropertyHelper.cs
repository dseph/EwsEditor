using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using Microsoft.Exchange.WebServices.Data;
using System.Windows.Forms;

namespace EWSEditor.Common
{
    public class EwsExtendedPropertyHelper 
    {

        public static string GetExtendedProp_DateTime_AsString(Item oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {
            DateTime oDateTime;

            string sReturn = "";

            try
            {  
            if (oItem.TryGetProperty(oExtendedPropertyDefinition, out oDateTime))
            {
                if (oDateTime == null)
                    sReturn = "";

                else
                    sReturn = oDateTime.ToString();
            }
            else
                sReturn = "";
            }
            catch (InvalidCastException ex)
            {
                string sError = string.Format("Error casting extended property.  GUID: {0} Property ID: {1}\r\nError: {2}",
                            oExtendedPropertyDefinition.PropertySetId,
                            oExtendedPropertyDefinition.Id,
                            ex.Message);
                MessageBox.Show(sError, "Casting Error");
                throw ex;
            }
            return sReturn;
        }

        public static string GetExtendedProp_ByteArr_AsString(Item oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {
            byte[] bytearrVal;

            string sReturn = "";
            try
            {  
                if (oItem.TryGetProperty(oExtendedPropertyDefinition, out bytearrVal))  // Example: CleanGlobalObjectId
                {
                    {
                        if (bytearrVal == null)
                            sReturn = "";
                        else
                            sReturn = Convert.ToBase64String(bytearrVal);  // reverse: Convert.FromBase64String(string data)
                    }
                }
                else
                    sReturn = "";

            }
            catch (InvalidCastException ex)
            {
                string sError = string.Format("Error casting extended property.  GUID: {0} Property ID: {1}\r\nError: {2}",
                            oExtendedPropertyDefinition.PropertySetId,
                            oExtendedPropertyDefinition.Id,
                            ex.Message);
                MessageBox.Show(sError, "Casting Error");
                throw ex;
            }
            return sReturn;
        }

        public static string GetExtendedProp_String_AsString(Item oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {
            string sString = string.Empty;

            string sReturn = "";

            try
            {  
            if (oItem.TryGetProperty(oExtendedPropertyDefinition, out sString))
            {
                if (sString == null)
                    sReturn = "";
                else
                    sReturn = sString;
            }
            else
                sReturn = "";
            }
            catch (InvalidCastException ex)
            {
                string sError = string.Format("Error casting extended property.  GUID: {0} Property ID: {1}\r\nError: {2}",
                            oExtendedPropertyDefinition.PropertySetId,
                            oExtendedPropertyDefinition.Id,
                            ex.Message);
                MessageBox.Show(sError, "Casting Error");
                throw ex;
            }
            return sReturn;
        }

        public static string GetExtendedProp_Int_AsString(Item oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {
            int lVal = 0;
            //long x = 0;
            string sReturn = "";
            try
            {
                //if (oItem.TryGetProperty(oExtendedPropertyDefinition, out x))
                if (oItem.TryGetProperty(oExtendedPropertyDefinition, out lVal))
                {
                    if (lVal == null)
                        sReturn = "";
                    else
                        sReturn = lVal.ToString();
                }
                else
                    sReturn = "";

                if (sReturn == null)
                {
                    sReturn = "";
                }
            }
            catch (InvalidCastException ex)
            {
                string sError = string.Format("Error casting extended property.  GUID: {0} Property ID: {1}\r\nError: {2}",
                            oExtendedPropertyDefinition.PropertySetId, 
                            oExtendedPropertyDefinition.Id, 
                            ex.Message);
                MessageBox.Show(sError, "Casting Error");
                throw ex;
            }
            return sReturn;
        }

        public static string GetExtendedProp_Long_AsString(Item oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {
            long lVal = 0;

            string sReturn = "";
            try
            {  
                if (oItem.TryGetProperty(oExtendedPropertyDefinition, out lVal))
                {
                    if (lVal == null)
                        sReturn = "";
                    else
                        sReturn = lVal.ToString();
                }
                else
                    sReturn = "";
            }
            catch (InvalidCastException ex)
            {
                string sError = string.Format("Error casting extended property.  GUID: {0} Property ID: {1}\r\nError: {2}",
                            oExtendedPropertyDefinition.PropertySetId,
                            oExtendedPropertyDefinition.Id,
                            ex.Message);
                MessageBox.Show(sError, "Casting Error");
                throw ex;
            }
            return sReturn;
        }

        public static string GetExtendedProp_Short_AsString(Item oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {
            Int16 iVal = 0;

            string sReturn = "";
            try
            {
                if (oItem.TryGetProperty(oExtendedPropertyDefinition, out iVal))
                {
                    if (iVal == null)
                        sReturn = "";
                    else
                        sReturn = iVal.ToString();
                }
                else
                    sReturn = "";
            }
            catch (InvalidCastException ex)
            {
                string sError = string.Format("Error casting extended property.  GUID: {0} Property ID: {1}\r\nError: {2}",
                            oExtendedPropertyDefinition.PropertySetId,
                            oExtendedPropertyDefinition.Id,
                            ex.Message);
                MessageBox.Show(sError, "Casting Error");
                throw ex;
            }
            return sReturn;
        }


        public static string GetExtendedProp_Bool_AsString(Item oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {
            bool bVal = false;

            string sReturn = "";
            try
            {  
                if (oItem.TryGetProperty(oExtendedPropertyDefinition, out bVal))
                {
                    if (bVal == null)
                        sReturn = "";
                    else
                        sReturn = bVal.ToString();
                }
                else
                    sReturn = "";
            }
            catch (InvalidCastException ex)
            {
                string sError = string.Format("Error casting extended property.  GUID: {0} Property ID: {1}\r\nError: {2}",
                            oExtendedPropertyDefinition.PropertySetId,
                            oExtendedPropertyDefinition.Id,
                            ex.Message);
                MessageBox.Show(sError, "Casting Error");
                throw ex;
            }
            return sReturn;
        }

        // Folders

        public static string GetExtendedProp_DateTime_AsString(Folder oFolder, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {
            DateTime oDateTime;

            string sReturn = "";

            try
            {
                if (oFolder.TryGetProperty(oExtendedPropertyDefinition, out oDateTime))
                {
                    if (oDateTime == null)
                        sReturn = "";

                    else
                        sReturn = oDateTime.ToString();
                }
                else
                    sReturn = "";
            }
            catch (InvalidCastException ex)
            {
                string sError = string.Format("Error casting extended property.  GUID: {0} Property ID: {1}\r\nError: {2}",
                            oExtendedPropertyDefinition.PropertySetId,
                            oExtendedPropertyDefinition.Id,
                            ex.Message);
                MessageBox.Show(sError, "Casting Error");
                throw ex;
            }
            return sReturn;
        }

        public static string GetExtendedProp_ByteArr_AsString(Folder oFolder, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {
            byte[] bytearrVal;

            string sReturn = "";

            try
            {  
                if (oFolder.TryGetProperty(oExtendedPropertyDefinition, out bytearrVal))  // Example: CleanGlobalObjectId
                {
                    {
                        if (bytearrVal == null)
                            sReturn = "";
                        else
                            sReturn = Convert.ToBase64String(bytearrVal);  // reverse: Convert.FromBase64String(string data)
                    }
                }
                else
                    sReturn = "";
            }
            catch (InvalidCastException ex)
            {
                string sError = string.Format("Error casting extended property.  GUID: {0} Property ID: {1}\r\nError: {2}",
                            oExtendedPropertyDefinition.PropertySetId,
                            oExtendedPropertyDefinition.Id,
                            ex.Message);
                MessageBox.Show(sError, "Casting Error");
                throw ex;
            }
            return sReturn;
        }

        public static string GetExtendedProp_String_AsString(Folder oFolder, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {
            string sString = string.Empty;

            string sReturn = "";

            try
            {  
                if (oFolder.TryGetProperty(oExtendedPropertyDefinition, out sString))
                {
                    if (sString == null)
                        sReturn = "";
                    else
                        sReturn = sString;
                }
                else
                    sReturn = "";
            }
            catch (InvalidCastException ex)
            {
                string sError = string.Format("Error casting extended property.  GUID: {0} Property ID: {1}\r\nError: {2}",
                            oExtendedPropertyDefinition.PropertySetId,
                            oExtendedPropertyDefinition.Id,
                            ex.Message);
                MessageBox.Show(sError, "Casting Error");
                throw ex;
            }
            return sReturn;
        }

        public static string GetExtendedProp_Int_AsString(Folder oFolder, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {
            int lVal = 0;

            string sReturn = "";

            try
            {  
                if (oFolder.TryGetProperty(oExtendedPropertyDefinition, out lVal))
                {
                    if (lVal == null)
                        sReturn = "";
                    else
                        sReturn = lVal.ToString();
                }
                else
                    sReturn = "";

                if (sReturn == null)
                {
                    sReturn = "";
                }
            }
            catch (InvalidCastException ex)
            {
                string sError = string.Format("Error casting extended property.  GUID: {0} Property ID: {1}\r\nError: {2}",
                            oExtendedPropertyDefinition.PropertySetId,
                            oExtendedPropertyDefinition.Id,
                            ex.Message);
                MessageBox.Show(sError, "Casting Error");
                throw ex;
            }
            return sReturn;
        }

        public static string GetExtendedProp_Long_AsString(Folder oFolder, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {
            long lVal = 0;

            string sReturn = "";

            try
            {  
                if (oFolder.TryGetProperty(oExtendedPropertyDefinition, out lVal))
                {
                    if (lVal == null)
                        sReturn = "";
                    else
                        sReturn = lVal.ToString();
                }
                else
                    sReturn = "";
            }
            catch (InvalidCastException ex)
            {
                string sError = string.Format("Error casting extended property.  GUID: {0} Property ID: {1}\r\nError: {2}",
                            oExtendedPropertyDefinition.PropertySetId,
                            oExtendedPropertyDefinition.Id,
                            ex.Message);
                MessageBox.Show(sError, "Casting Error");
                throw ex;
            }
            return sReturn;
        }

        public static string GetExtendedProp_Short_AsString(Folder oFolder, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {
            Int16 iVal = 0;

            string sReturn = "";
            try
            {
                if (oFolder.TryGetProperty(oExtendedPropertyDefinition, out iVal))
                {
                    if (iVal == null)
                        sReturn = "";
                    else
                        sReturn = iVal.ToString();
                }
                else
                    sReturn = "";
            }
            catch (InvalidCastException ex)
            {
                string sError = string.Format("Error casting extended property.  GUID: {0} Property ID: {1}\r\nError: {2}",
                            oExtendedPropertyDefinition.PropertySetId,
                            oExtendedPropertyDefinition.Id,
                            ex.Message);
                MessageBox.Show(sError, "Casting Error");
                throw ex;
            }
            return sReturn;
        }

        public static string GetExtendedProp_Bool_AsString(Folder oFolder, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {
            bool bVal = false;

            string sReturn = "";

            try
            {  
            if (oFolder.TryGetProperty(oExtendedPropertyDefinition, out bVal))
            {
                if (bVal == null)
                    sReturn = "";
                else
                    sReturn = bVal.ToString();
            }
            else
                sReturn = "";
            }
            catch (InvalidCastException ex)
            {
                string sError = string.Format("Error casting extended property.  GUID: {0} Property ID: {1}\r\nError: {2}",
                            oExtendedPropertyDefinition.PropertySetId,
                            oExtendedPropertyDefinition.Id,
                            ex.Message);
                MessageBox.Show(sError, "Casting Error");
                throw ex;
            }
            return sReturn;
        }


        //        case MapiPropertyType.IntegerArray:
        //    sExtendedValue = EwsExtendedPropertyHelper.GetExtendedProp_IntArray_AsString(oItem, oEPD);
        //    break;
        //case MapiPropertyType.StringArray:
        //    sExtendedValue = EwsExtendedPropertyHelper.GetExtendedProp_StringArray_AsString(oItem, oEPD);
        //    break;
        //case MapiPropertyType.BinaryArray:
        //    sExtendedValue = EwsExtendedPropertyHelper.GetExtendedProp_ByteArrArray_AsString(oItem, oEPD);
        //    break;
        //case MapiPropertyType.LongArray:
        //    sExtendedValue = EwsExtendedPropertyHelper.GetExtendedProp_LongArray_AsString(oItem, oEPD);
        //    break;
        //case MapiPropertyType.SystemTimeArray:
        //    sExtendedValue = EwsExtendedPropertyHelper.GetExtendedProp_DateTimeArray_AsString(oItem, oEPD);
        //    break;
        //case MapiPropertyType.ShortArray:
        //    sExtendedValue = EwsExtendedPropertyHelper.GetExtendedProp_ShortArray_AsString(oItem, oEPD);
        //    break;


        public static string TrySwapGuidForPropSetName( string sPropertySetName, int oPropertyId, string oPropertyType )
 
        {
            string sGuid = null;

            switch (sPropertySetName.ToUpper())
            {
                case "PS_PUBLIC_STRINGS":           sGuid = "00020329-0000-0000-C000-000000000046"; break;
                case "PSETID_COMMON":               sGuid = "00062008-0000-0000-C000-000000000046"; break;
                case "PSETID_ADDRESS":              sGuid = "00062004-0000-0000-C000-000000000046"; break;
                case "PS_INTERNET_HEADERS":         sGuid = "00020386-0000-0000-C000-000000000046"; break;

                case "PSETID_APPOINTMENT":          sGuid = "00062002-0000-0000-C000-000000000046"; break;
                case "PSETID_MEETING":              sGuid = "6ED8DA90-450B-101B-98DA-00AA003F1305"; break;
                case "PSETID_LOG":                  sGuid = "0006200A-0000-0000-C000-000000000046"; break;
                case "PSETID_MESSAGING":            sGuid = "41F28F13-83F4-4114-A584-EEDB5A6B0BFF"; break;

                case "PSETID_NOTE":                 sGuid = "0006200E-0000-0000-C000-000000000046"; break;
                case "PSETID_POSTRSS":              sGuid = "00062041-0000-0000-C000-000000000046"; break;
                case "PSETID_TASK":                 sGuid = "00062003-0000-0000-C000-000000000046"; break;
                case "PSETID_UnifiedMessaging":     sGuid = "4442858E-A9E3-4E80-B900-317A210CC15B"; break;

                case "PS_MAPI":                     sGuid = "00020328-0000-0000-C000-000000000046"; break;
                case "PSETID_AIRSYNC":              sGuid = "71035549-0739-4DCB-9163-00F0580DBBDF"; break;
                case "PSETID_SHARING":              sGuid = "00062040-0000-0000-C000-000000000046"; break;
                case "SHARING": 
                    sGuid = "00062040-0000-0000-C000-000000000046"; 
                    break;
                case "PSETID_XMLEXTRACTEDENTITIES": sGuid = "23239608-685D-4732-9C55-4C95CB4E8E33"; break;

                case "PSETID_CALENDARASSISTANT":    sGuid = "11000E07-B51B-40D6-AF21-CAA85EDAB1D0"; break;
                default: 
                    sGuid = sPropertySetName;
                    if (sGuid.Length != 36 && sGuid.Length != 0)
                    {
                        string s = string.Format("On {0} - {1}: Unknown Property set name or GUID a of the wrong length: \"{0}\".  ",  sGuid);
                        s += string.Format("A property set GUID should have 36 characters; however this one has {0} characters. ", sGuid.Length.ToString());
                        s += string.Format("See Property: {0} - {1}  \\", oPropertyId, oPropertyType.ToString());
                        throw new Exception(s);
                    }
                    //string s = sGuid.Length.ToString();
                    break;
            }
            		 

            return sGuid;
        }


    }
}