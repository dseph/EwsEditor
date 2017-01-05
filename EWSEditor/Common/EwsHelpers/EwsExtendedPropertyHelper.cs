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
        public static string GetExtendedPropByteArrAsString(Item oItem, ExtendedPropertyDefinition oExtendedPropertyDefinition)
        {
            byte[] bytearrVal;

            string sReturn = "";
            if (oItem.TryGetProperty(oExtendedPropertyDefinition, out bytearrVal))  // Example: CleanGlobalObjectId
                sReturn = Convert.ToBase64String(bytearrVal);  // reverse: Convert.FromBase64String(string data)
            else
                sReturn = "";
            return sReturn;
        }
    }
}