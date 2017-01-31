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


        public static string TrySwapGuidForPropSetName(string sPropertySetName)
        {
            string sGuid = null;

            switch (sPropertySetName)
            {
                case "PS_PUBLIC_STRINGS": sGuid = "00020329-0000-0000-C000-000000000046"; break;
                case "PSETID_Common": sGuid = "00062008-0000-0000-C000-000000000046"; break;
                case "PS_INTERNET_HEADERS": sGuid = "00020386-0000-0000-C000-000000000046"; break;
                case "PSETID_Appointment": sGuid = "00062002-0000-0000-C000-000000000046"; break;
                case "PSETID_Meeting": sGuid = "6ED8DA90-450B-101B-98DA-00AA003F1305"; break;
                case "PSETID_Log": sGuid = "0006200A-0000-0000-C000-000000000046"; break;
                case "PSETID_Messaging": sGuid = "41F28F13-83F4-4114-A584-EEDB5A6B0BFF"; break;
                case "PSETID_Note": sGuid = "0006200E-0000-0000-C000-000000000046"; break;
                case "PSETID_PostRss": sGuid = "00062041-0000-0000-C000-000000000046"; break;
                case "PSETID_Task": sGuid = "00062003-0000-0000-C000-000000000046"; break;
                case "PSETID_UnifiedMessaging": sGuid = "4442858E-A9E3-4E80-B900-317A210CC15B"; break;
                case "PS_MAPI": sGuid = "00020328-0000-0000-C000-000000000046"; break;
                case "PSETID_AirSync": sGuid = "71035549-0739-4DCB-9163-00F0580DBBDF"; break;
                case "PSETID_Sharing": sGuid = "00062040-0000-0000-C000-000000000046"; break;
                case "PSETID_XmlExtractedEntities": sGuid = "23239608-685D-4732-9C55-4C95CB4E8E33"; break;
                case "PSETID_CalendarAssistant": sGuid = "11000E07-B51B-40D6-AF21-CAA85EDAB1D0"; break;
                default: 
                    sGuid = sPropertySetName;
                    if (sGuid.Length != 36 && sGuid.Length != 0)
                    {
                        string s = string.Format("Unknown Property set name or GUID a of the wrong length: \"{0}\".  ",  sGuid);
                        s += string.Format("A property set GUID should have 36 characters; however this one has {0} characters.  ",  sGuid.Length.ToString());
                        throw new Exception(s);
                    }
                    //string s = sGuid.Length.ToString();
                    break;
            }
            		 

            return sGuid;
        }


    }
}