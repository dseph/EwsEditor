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
                string sError = string.Format("Error casting extended property.  GUID: {0} Property ID: 0x{1:X}\r\nError: {2}",
                            oExtendedPropertyDefinition.PropertySetId,
                            oExtendedPropertyDefinition.Id,
                            ex.Message);
                MessageBox.Show(sError, "Casting Error");
                throw ex;
            }
            return sReturn;
        }


        //public static string GetExtendedProp_DateTime_AsString(Item oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        //{
        //    DateTime oDateTime;

        //    string sReturn = "";

        //    try
        //    {  
        //    if (oItem.TryGetProperty(oExtendedPropertyDefinition, out oDateTime))
        //    {
        //        if (oDateTime == null)
        //            sReturn = "";

        //        else
        //            sReturn = oDateTime.ToString();
        //    }
        //    else
        //        sReturn = "";
        //    }
        //    catch (InvalidCastException ex)
        //    {
        //        string sError = string.Format("Error casting extended property.  GUID: {0} Property ID: {1}\r\nError: {2}",
        //                    oExtendedPropertyDefinition.PropertySetId,
        //                    oExtendedPropertyDefinition.Id,
        //                    ex.Message);
        //        MessageBox.Show(sError, "Casting Error");
        //        throw ex;
        //    }
        //    return sReturn;
        //}

        public static string GetExtendedProp_Byte_AsString(Item oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
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
                string sError = string.Format("Error casting extended property.  GUID: {0} Property ID: 0x{1:X}\r\nError: {2}",
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
                string sError = string.Format("Error casting extended property.  GUID: {0} Property ID: 0x{1:X}\r\nError: {2}",
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
            int ?lVal = 0;
            //long x = 0;
            string sReturn = "";
            try
            {

                if (oExtendedPropertyDefinition.Id == 33285)
                {
                    Console.WriteLine("");
 
                }
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
                // One EWS int prop gets retured as a string  - this is a workaround.
                if (oExtendedPropertyDefinition.Id == 33285 && 
                    (oExtendedPropertyDefinition.PropertySet == DefaultExtendedPropertySet.Appointment || 
                     oExtendedPropertyDefinition.PropertySetId == new Guid("00062002-0000-0000-c000-000000000046"))
                    )
                {
 
                    foreach (ExtendedProperty ep in oItem.ExtendedProperties)
                    {
                        if (ep.PropertyDefinition.Id == 33285 && 
                            (ep.PropertyDefinition.PropertySet == DefaultExtendedPropertySet.Appointment || 
                             ep.PropertyDefinition.PropertySetId == new Guid("00062002-0000-0000-c000-000000000046"))
                            )
                        {
                            try 
                            { 
                                string sVal = ep.Value.ToString();
                                return sVal;
                          
                            }
                            catch (Exception ex_swap)
                            {
                                string sError_Swap = string.Format("Error casting extended property.  GUID: {0} Property ID: 0x{1:X}\r\nError: {2}",
                                    ep.PropertyDefinition.PropertySetId,
                                    ep.PropertyDefinition.Id,
                                    ex_swap.Message);
                                MessageBox.Show(sError_Swap, "Casting Error");
                            }
                        }
                    }
 
                    string sError = string.Format("Error casting extended property.  GUID: {0} Property ID: 0x{1:X}\r\nError: {2}",
                                oExtendedPropertyDefinition.PropertySetId,
                                oExtendedPropertyDefinition.Id,
                                ex.Message);
                    MessageBox.Show(sError, "Casting Error");
                    throw ex;
  
                }
            }
            return sReturn;
        }



        public static string GetExtendedProp_Long_AsString(Item oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {
            long ?lVal = 0;

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
                string sError = string.Format("Error casting extended property.  GUID: {0} Property ID: 0x{1:X}\r\nError: {2}",
                            oExtendedPropertyDefinition.PropertySetId,
                            oExtendedPropertyDefinition.Id,
                            ex.Message);
                MessageBox.Show(sError, "Casting Error");
                throw ex;
            }
            return sReturn;
        }


        public static string GetExtendedProp_Float_AsString(Item oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {
            float ?fVal = 0;

            string sReturn = "";
            try
            {
                if (oItem.TryGetProperty(oExtendedPropertyDefinition, out fVal))
                {
                    if (fVal == null)
                        sReturn = "";
                    else
                        sReturn = fVal.ToString();
                }
                else
                    sReturn = "";
            }
            catch (InvalidCastException ex)
            {
                string sError = string.Format("Error casting extended property.  GUID: {0} Property ID: 0x{1:X}\r\nError: {2}",
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
            Int16 ?iVal = 0;

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
                string sError = string.Format("Error casting extended property.  GUID: {0} Property ID: 0x{1:X}\r\nError: {2}",
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
            bool ?bVal = false;

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
                string sError = string.Format("Error casting extended property.  GUID: {0} Property ID: 0x{1:X}\r\nError: {2}",
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
                string sError = string.Format("Error casting extended property.  GUID: {0} Property ID: 0x{1:X}\r\nError: {2}",
                            oExtendedPropertyDefinition.PropertySetId,
                            oExtendedPropertyDefinition.Id,
                            ex.Message);
                MessageBox.Show(sError, "Casting Error");
                throw ex;
            }
            return sReturn;
        }

        public static string GetExtendedProp_Byte_AsString(Folder oFolder, ExtendedPropertyDefinition oExtendedPropertyDefinition)
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
                string sError = string.Format("Error casting extended property.  GUID: {0} Property ID: 0x{1:X}\r\nError: {2}",
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
                string sError = string.Format("Error casting extended property.  GUID: {0} Property ID: 0x{1:X}\r\nError: {2}",
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
            int ?lVal = 0;

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
                string sError = string.Format("Error casting extended property.  GUID: {0} Property ID: 0x{1:X}\r\nError: {2}",
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
            long ?lVal = 0;

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
                string sError = string.Format("Error casting extended property.  GUID: {0} Property ID: 0x{1:X}\r\nError: {2}",
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
            Int16 ?iVal = 0;

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
                string sError = string.Format("Error casting extended property.  GUID: {0} Property ID: 0x{1:X}\r\nError: {2}",
                            oExtendedPropertyDefinition.PropertySetId,
                            oExtendedPropertyDefinition.Id,
                            ex.Message);
                MessageBox.Show(sError, "Casting Error");
                throw ex;
            }
            return sReturn;
        }

        public static string GetExtendedProp_Float_AsString(Folder oFolder, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {
            float ?fVal = 0;

            string sReturn = "";
            try
            {
                if (oFolder.TryGetProperty(oExtendedPropertyDefinition, out fVal))
                {
                    if (fVal == null)
                        sReturn = "";
                    else
                        sReturn = fVal.ToString();
                }
                else
                    sReturn = "";
            }
            catch (InvalidCastException ex)
            {
                string sError = string.Format("Error casting extended property.  GUID: {0} Property ID: 0x{1:X}\r\nError: {2}",
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
            bool ?bVal = false;

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
                string sError = string.Format("Error casting extended property.  GUID: {0} Property ID: 0x{1:X}\r\nError: {2}",
                            oExtendedPropertyDefinition.PropertySetId,
                            oExtendedPropertyDefinition.Id,
                            ex.Message);
                MessageBox.Show(sError, "Casting Error");
                throw ex;
            }
            return sReturn;
        }


        // ======================================================================
        // Item Array props

 
        public static string GetExtendedProp_DateTimeArr_AsString(Item oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {

            DateTime[][] oArrVal;     // *

            string sReturn = "";
            string sEntry = "";
            try
            {
                if (oItem.TryGetProperty(oExtendedPropertyDefinition, out oArrVal))
                {
                     
                        if (oArrVal == null)
                            sReturn = "";
                        else
                        {
                            string s = string.Empty;
                            sEntry = string.Empty;
                            foreach (DateTime[] oVal in oArrVal)    // *
                            {
                                byte[] oFromVal = System.Text.ASCIIEncoding.ASCII.GetBytes(sEntry);  // *
                                s = Convert.ToBase64String(oFromVal);
                                sEntry += s + ",";
                            }
                            sEntry = sEntry.Remove(sEntry.Length - 1, 1);  // get rid of last comma;

                            // Base64 encode final results.
                            byte[] oFromBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(sEntry);
                            sReturn = System.Convert.ToBase64String(oFromBytes);
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
         


        public static string GetExtendedProp_LongArr_AsString(Item oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {

            long[][] oArrVal;     // *

            string sReturn = "";
            string sEntry = "";
            try
            {
                if (oItem.TryGetProperty(oExtendedPropertyDefinition, out oArrVal))
                {
                     
                        if (oArrVal == null)
                            sReturn = "";
                        else
                        {
                            string s = string.Empty;
                            sEntry = string.Empty;
                            foreach (long[] oVal in oArrVal)    // *
                            {
                                byte[] oFromVal = System.Text.ASCIIEncoding.ASCII.GetBytes(sEntry);  // *
                                s = Convert.ToBase64String(oFromVal);
                                sEntry += s + ",";
                            }
                            sEntry = sEntry.Remove(sEntry.Length - 1, 1);  // get rid of last comma;

                            // Base64 encode final results.
                            byte[] oFromBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(sEntry);
                            sReturn = System.Convert.ToBase64String(oFromBytes);
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
         
 

        public static string GetExtendedProp_ByteArr_AsString(Item oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {
             
            byte[][] bytearrVal;

            string sReturn = "";
            string sEntry = "";
            try
            {
                if (oItem.TryGetProperty(oExtendedPropertyDefinition, out bytearrVal))  // Example: CleanGlobalObjectId
                {
                  
                        if (bytearrVal == null)
                            sReturn = "";
                        else
                        {
                            string s = string.Empty;
                            sEntry = string.Empty;
                            foreach (byte[] oByteArray in bytearrVal)
                            {
                                s = Convert.ToBase64String(oByteArray);
                                sEntry += s + ",";
                            }
                            sEntry = sEntry.Remove(sEntry.Length -1, 1);  // get rid of last comma;

                            // Base64 encode final results.
                            byte[] oFromBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(sEntry);
                            sReturn = System.Convert.ToBase64String(oFromBytes); 

                            //sReturn = Convert.ToBase64String(sEntry);  // reverse: Convert.FromBase64String(string data)
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

        public static string GetExtendedProp_StringArr_AsString(Item oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {

            string[][] oArrVal;     // *

            string sReturn = "";
            string sEntry = "";
            try
            {
                if (oItem.TryGetProperty(oExtendedPropertyDefinition, out oArrVal))   
                {
             
                        if (oArrVal == null)
                            sReturn = "";
                        else
                        {
                            string s = string.Empty;
                            sEntry = string.Empty;
                            foreach (string[] oVal in oArrVal)    // *
                            {
                                byte[] oFromVal = System.Text.ASCIIEncoding.ASCII.GetBytes(sEntry);  // *
                                s = Convert.ToBase64String(oFromVal);
                                sEntry += s + ",";
                            }
                            sEntry = sEntry.Remove(sEntry.Length - 1, 1);  // get rid of last comma;

                            // Base64 encode final results.
                            byte[] oFromBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(sEntry);
                            sReturn = System.Convert.ToBase64String(oFromBytes);
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
         


        public static string GetExtendedProp_IntArr_AsString(Item oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {

            int[][] oArrVal;     // *

            string sReturn = "";
            string sEntry = "";
            try
            {
                if (oItem.TryGetProperty(oExtendedPropertyDefinition, out oArrVal))
                {
                 
                        if (oArrVal == null)
                            sReturn = "";
                        else
                        {
                            string s = string.Empty;
                            sEntry = string.Empty;
                            foreach (int[] oVal in oArrVal)    // *
                            {
                                byte[] oFromVal = System.Text.ASCIIEncoding.ASCII.GetBytes(sEntry);
                                s = Convert.ToBase64String(oFromVal);
                                sEntry += s + ",";
                            }
                            sEntry = sEntry.Remove(sEntry.Length - 1, 1);  // get rid of last comma;

                            // Base64 encode final results.
                            byte[] oFromBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(sEntry);
                            sReturn = System.Convert.ToBase64String(oFromBytes);
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

        public static string GetExtendedProp_DoubleArr_AsString(Item oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {

            double[][] oArrVal;     // *

            string sReturn = "";
            string sEntry = "";
            try
            {
                if (oItem.TryGetProperty(oExtendedPropertyDefinition, out oArrVal))
                {
                     
                        if (oArrVal == null)
                            sReturn = "";
                        else
                        {
                            string s = string.Empty;
                            sEntry = string.Empty;
                            foreach (double[] oVal in oArrVal)    // *
                            {
                                byte[] oFromVal = System.Text.ASCIIEncoding.ASCII.GetBytes(sEntry);
                                s = Convert.ToBase64String(oFromVal);
                                sEntry += s + ",";
                            }
                            sEntry = sEntry.Remove(sEntry.Length - 1, 1);  // get rid of last comma;

                            // Base64 encode final results.
                            byte[] oFromBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(sEntry);
                            sReturn = System.Convert.ToBase64String(oFromBytes);
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


        public static string GetExtendedProp_ShortArr_AsString(Item oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {
    

            short[][] oArrVal;     // *

            string sReturn = "";
            string sEntry = "";
            try
            {
                if (oItem.TryGetProperty(oExtendedPropertyDefinition, out oArrVal))
                {
                     
                        if (oArrVal == null)
                            sReturn = "";
                        else
                        {
                            string s = string.Empty;
                            sEntry = string.Empty;
                            foreach (short[] oVal in oArrVal)    // *
                            {
                                byte[] oFromVal = System.Text.ASCIIEncoding.ASCII.GetBytes(sEntry);
                                s = Convert.ToBase64String(oFromVal);
                                sEntry += s + ",";
                            }
                            sEntry = sEntry.Remove(sEntry.Length - 1, 1);  // get rid of last comma;

                            // Base64 encode final results.
                            byte[] oFromBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(sEntry);
                            sReturn = System.Convert.ToBase64String(oFromBytes);
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


        public static string GetExtendedProp_FloatArr_AsString(Item oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {


            float[][] oArrVal;     // *

            string sReturn = "";
            string sEntry = "";
            try
            {
                if (oItem.TryGetProperty(oExtendedPropertyDefinition, out oArrVal))
                {
                    
                        if (oArrVal == null)
                            sReturn = "";
                        else
                        {
                            string s = string.Empty;
                            sEntry = string.Empty;
                            foreach (float[] oVal in oArrVal)    // *
                            {
                                byte[] oFromVal = System.Text.ASCIIEncoding.ASCII.GetBytes(sEntry);
                                s = Convert.ToBase64String(oFromVal);
                                sEntry += s + ",";
                            }
                            sEntry = sEntry.Remove(sEntry.Length - 1, 1);  // get rid of last comma;

                            // Base64 encode final results.
                            byte[] oFromBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(sEntry);
                            sReturn = System.Convert.ToBase64String(oFromBytes);
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

        // ======================================================================
        // Folder Array props


        public static string GetExtendedProp_DateTimeArr_AsString(Folder oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {

            DateTime[][] oArrVal;     // *

            string sReturn = "";
            string sEntry = "";
            try
            {
                if (oItem.TryGetProperty(oExtendedPropertyDefinition, out oArrVal))
                {
                    
                        if (oArrVal == null)
                            sReturn = "";
                        else
                        {
                            string s = string.Empty;
                            sEntry = string.Empty;
                            foreach (DateTime[] oVal in oArrVal)    // *
                            {
                                byte[] oFromVal = System.Text.ASCIIEncoding.ASCII.GetBytes(sEntry);  // *
                                s = Convert.ToBase64String(oFromVal);
                                sEntry += s + ",";
                            }
                            sEntry = sEntry.Remove(sEntry.Length - 1, 1);  // get rid of last comma;

                            // Base64 encode final results.
                            byte[] oFromBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(sEntry);
                            sReturn = System.Convert.ToBase64String(oFromBytes);
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



        public static string GetExtendedProp_LongArr_AsString(Folder oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {

            long[][] oArrVal;     // *

            string sReturn = "";
            string sEntry = "";
            try
            {
                if (oItem.TryGetProperty(oExtendedPropertyDefinition, out oArrVal))
                {
                     
                        if (oArrVal == null)
                            sReturn = "";
                        else
                        {
                            string s = string.Empty;
                            sEntry = string.Empty;
                            foreach (long[] oVal in oArrVal)    // *
                            {
                                byte[] oFromVal = System.Text.ASCIIEncoding.ASCII.GetBytes(sEntry);  // *
                                s = Convert.ToBase64String(oFromVal);
                                sEntry += s + ",";
                            }
                            sEntry = sEntry.Remove(sEntry.Length - 1, 1);  // get rid of last comma;

                            // Base64 encode final results.
                            byte[] oFromBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(sEntry);
                            sReturn = System.Convert.ToBase64String(oFromBytes);
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
         

        public static string GetExtendedProp_ByteArr_AsString(Folder oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {

            byte[][] bytearrVal;

            string sReturn = "";
            string sEntry = "";
            try
            {
                if (oItem.TryGetProperty(oExtendedPropertyDefinition, out bytearrVal))  // Example: CleanGlobalObjectId
                {
                     
                        if (bytearrVal == null)
                            sReturn = "";
                        else
                        {
                            string s = string.Empty;
                            sEntry = string.Empty;
                            foreach (byte[] oByteArray in bytearrVal)
                            {
                                s = Convert.ToBase64String(oByteArray);
                                sEntry += s + ",";
                            }
                            sEntry = sEntry.Remove(sEntry.Length - 1, 1);  // get rid of last comma;

                            // Base64 encode final results.
                            byte[] oFromBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(sEntry);
                            sReturn = System.Convert.ToBase64String(oFromBytes);

                            //sReturn = Convert.ToBase64String(sEntry);  // reverse: Convert.FromBase64String(string data)
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

        public static string GetExtendedProp_StringArr_AsString(Folder oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {

            string[][] oArrVal;     // *

            string sReturn = "";
            string sEntry = "";
            try
            {
                if (oItem.TryGetProperty(oExtendedPropertyDefinition, out oArrVal))
                {
                     
                        if (oArrVal == null)
                            sReturn = "";
                        else
                        {
                            string s = string.Empty;
                            sEntry = string.Empty;
                            foreach (string[] oVal in oArrVal)    // *
                            {
                                byte[] oFromVal = System.Text.ASCIIEncoding.ASCII.GetBytes(sEntry);  // *
                                s = Convert.ToBase64String(oFromVal);
                                sEntry += s + ",";
                            }
                            sEntry = sEntry.Remove(sEntry.Length - 1, 1);  // get rid of last comma;

                            // Base64 encode final results.
                            byte[] oFromBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(sEntry);
                            sReturn = System.Convert.ToBase64String(oFromBytes);
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

        public static string GetExtendedProp_BoolArr_AsString(Folder oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {

            bool[][] oArrVal;     // *

            string sReturn = "";
            string sEntry = "";
            try
            {
                if (oItem.TryGetProperty(oExtendedPropertyDefinition, out oArrVal))
                {
                     
                        if (oArrVal == null)
                            sReturn = "";
                        else
                        {
                            string s = string.Empty;
                            sEntry = string.Empty;
                            foreach (bool[] oVal in oArrVal)    // *
                            {
                                byte[] oFromVal = System.Text.ASCIIEncoding.ASCII.GetBytes(sEntry);
                                s = Convert.ToBase64String(oFromVal);
                                sEntry += s + ",";
                            }
                            sEntry = sEntry.Remove(sEntry.Length - 1, 1);  // get rid of last comma;

                            // Base64 encode final results.
                            byte[] oFromBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(sEntry);
                            sReturn = System.Convert.ToBase64String(oFromBytes);
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


        public static string GetExtendedProp_IntArr_AsString(Folder oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {

            int[][] oArrVal;     // *

            string sReturn = "";
            string sEntry = "";
            try
            {
                if (oItem.TryGetProperty(oExtendedPropertyDefinition, out oArrVal))
                {
                    
                        if (oArrVal == null)
                            sReturn = "";
                        else
                        {
                            string s = string.Empty;
                            sEntry = string.Empty;
                            foreach (int[] oVal in oArrVal)    // *
                            {
                                byte[] oFromVal = System.Text.ASCIIEncoding.ASCII.GetBytes(sEntry);
                                s = Convert.ToBase64String(oFromVal);
                                sEntry += s + ",";
                            }
                            sEntry = sEntry.Remove(sEntry.Length - 1, 1);  // get rid of last comma;

                            // Base64 encode final results.
                            byte[] oFromBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(sEntry);
                            sReturn = System.Convert.ToBase64String(oFromBytes);
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

        public static string GetExtendedProp_DoubleArr_AsString(Folder oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {

            double[][] oArrVal;     // *

            string sReturn = "";
            string sEntry = "";
            try
            {
                if (oItem.TryGetProperty(oExtendedPropertyDefinition, out oArrVal))
                {
                     
                        if (oArrVal == null)
                            sReturn = "";
                        else
                        {
                            string s = string.Empty;
                            sEntry = string.Empty;
                            foreach (double[] oVal in oArrVal)    // *
                            {
                                byte[] oFromVal = System.Text.ASCIIEncoding.ASCII.GetBytes(sEntry);
                                s = Convert.ToBase64String(oFromVal);
                                sEntry += s + ",";
                            }
                            sEntry = sEntry.Remove(sEntry.Length - 1, 1);  // get rid of last comma;

                            // Base64 encode final results.
                            byte[] oFromBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(sEntry);
                            sReturn = System.Convert.ToBase64String(oFromBytes);
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


        public static string GetExtendedProp_ShortArr_AsString(Folder oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {


            short[][] oArrVal;     // *

            string sReturn = "";
            string sEntry = "";
            try
            {
                if (oItem.TryGetProperty(oExtendedPropertyDefinition, out oArrVal))
                {
                     
                        if (oArrVal == null)
                            sReturn = "";
                        else
                        {
                            string s = string.Empty;
                            sEntry = string.Empty;
                            foreach (short[] oVal in oArrVal)    // *
                            {
                                byte[] oFromVal = System.Text.ASCIIEncoding.ASCII.GetBytes(sEntry);
                                s = Convert.ToBase64String(oFromVal);
                                sEntry += s + ",";
                            }
                            sEntry = sEntry.Remove(sEntry.Length - 1, 1);  // get rid of last comma;

                            // Base64 encode final results.
                            byte[] oFromBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(sEntry);
                            sReturn = System.Convert.ToBase64String(oFromBytes);
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


        public static string GetExtendedProp_FloatArr_AsString(Folder oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {


            float[][] oArrVal;     // *

            string sReturn = "";
            string sEntry = "";
            try
            {
                if (oItem.TryGetProperty(oExtendedPropertyDefinition, out oArrVal))
                {
                     
                        if (oArrVal == null)
                            sReturn = "";
                        else
                        {
                            string s = string.Empty;
                            sEntry = string.Empty;
                            foreach (float[] oVal in oArrVal)    // *
                            {
                                byte[] oFromVal = System.Text.ASCIIEncoding.ASCII.GetBytes(sEntry);
                                s = Convert.ToBase64String(oFromVal);
                                sEntry += s + ",";
                            }
                            sEntry = sEntry.Remove(sEntry.Length - 1, 1);  // get rid of last comma;

                            // Base64 encode final results.
                            byte[] oFromBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(sEntry);
                            sReturn = System.Convert.ToBase64String(oFromBytes);
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


        public static string TrySwapGuidForPropSetName( string sPropertySetName, int oPropertyId, string oPropertyType, 
                        string sUseLine,
                        int iLine)
 
        {
            string sGuid = null;

            switch (sPropertySetName.Trim().ToUpper())
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
                case "PSETID_UNIFIEDMESSAGING":
                        sGuid = "4442858E-A9E3-4E80-B900-317A210CC15B"; 
                        break;
                       

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
                        string s = string.Format("On Line {0} : Unknown Property set name or GUID a of the wrong length: \"{1}\".\r\n", iLine, sGuid);
                        s += string.Format("A property set GUID should have 36 characters; however this one has {0} characters. \r\n", sGuid.Length.ToString());
                        s += string.Format("See line {0}: \r\n{1}\r\n", iLine, sUseLine);
                        throw new Exception(s);
                    }
                    //string s = sGuid.Length.ToString();
                    break;
            }
            		 

            return sGuid;
        }


    }
}