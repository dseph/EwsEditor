using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.Common
{
    public class EwsExtendedPropertyHelper 
    {

        public static string GetExtendedProp_DateTime_AsString(Item oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {
            DateTime oDateTime;

            string sReturn = "";
            if (oItem.TryGetProperty(oExtendedPropertyDefinition, out oDateTime))
            {
                if (oDateTime == null)
                    sReturn = "";

                else
                    sReturn = oDateTime.ToString();
            }
            else
                sReturn = "";
            return sReturn;
        }

        public static string GetExtendedProp_ByteArr_AsString(Item oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {
            byte[] bytearrVal;

            string sReturn = "";
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
            return sReturn;
        }

        public static string GetExtendedProp_String_AsString(Item oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {
            string sString = string.Empty;

            string sReturn = "";
            if (oItem.TryGetProperty(oExtendedPropertyDefinition, out sString))
            {
                if (sString == null)
                    sReturn = "";
                else
                    sReturn = sString;
            }
            else
                sReturn = "";
            return sReturn;
        }

        public static string GetExtendedProp_Int_AsString(Item oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {
            int lVal = 0;

            string sReturn = "";
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
            return sReturn;
        }

        public static string GetExtendedProp_Long_AsString(Item oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {
            long lVal = 0;

            string sReturn = "";
            if (oItem.TryGetProperty(oExtendedPropertyDefinition, out lVal))
            {
                if (lVal == null)
                    sReturn = "";
                else
                    sReturn = lVal.ToString();
            }
            else
                sReturn = "";
            return sReturn;
        }

        public static string GetExtendedProp_Bool_AsString(Item oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {
            bool bVal = false;

            string sReturn = "";
            if (oItem.TryGetProperty(oExtendedPropertyDefinition, out bVal))
            {
                if (bVal == null)
                    sReturn = "";
                else
                    sReturn = bVal.ToString();
            }
            else
                sReturn = "";
            return sReturn;
        }


    }
}