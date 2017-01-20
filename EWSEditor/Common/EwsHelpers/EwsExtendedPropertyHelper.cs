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
        //public static string GetExtendedPropByteArrAsString(Item oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        //{
        //    byte[] bytearrVal;

        //    string sReturn = "";
        //    if (oItem.TryGetProperty(oExtendedPropertyDefinition, out bytearrVal))  // Example: CleanGlobalObjectId
        //        sReturn = Convert.ToBase64String(bytearrVal);  // reverse: Convert.FromBase64String(string data)
        //    else
        //        sReturn = "";
        //    return sReturn;
        //}


        //public static string GetExtendedProp_DateTime_AsString(Item oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        //{
        //    DateTime oDateTime;

        //    string sReturn = "";
        //    if (oItem.TryGetProperty(oExtendedPropertyDefinition, out oDateTime))
        //        sReturn = oDateTime.ToString();
        //    else
        //        sReturn = "";
        //    return sReturn;
        //}

        //public static string GetExtendedProp_ByteArr_AsString(Item oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        //{
        //    byte[] bytearrVal;

        //    string sReturn = "";
        //    if (oItem.TryGetProperty(oExtendedPropertyDefinition, out bytearrVal))  // Example: CleanGlobalObjectId
        //        sReturn = Convert.ToBase64String(bytearrVal);  // reverse: Convert.FromBase64String(string data)
        //    else
        //        sReturn = "";
        //    return sReturn;
        //}

        //public static string GetExtendedProp_String_AsString(Item oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        //{
        //    string sString = string.Empty;

        //    string sReturn = "";
        //    if (oItem.TryGetProperty(oExtendedPropertyDefinition, out sString))
        //        sReturn = sString;
        //    else
        //        sReturn = "";
        //    return sReturn;
        //}

        //public static string GetExtendedProp_Int_AsString(Item oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        //{
        //    int lVal = 0;

        //    string sReturn = "";
        //    if (oItem.TryGetProperty(oExtendedPropertyDefinition, out lVal))
        //        sReturn = lVal.ToString();
        //    else
        //        sReturn = "";
        //    return sReturn;
        //}

        //public static string GetExtendedProp_Bool_AsString(Item oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        //{
        //    bool bVal = false;

        //    string sReturn = "";
        //    if (oItem.TryGetProperty(oExtendedPropertyDefinition, out bVal))
        //        sReturn = bVal.ToString();
        //    else
        //        sReturn = "";
        //    return sReturn;
        //}

    }
}