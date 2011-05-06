using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.PropertyInformation.TypeValues
{
    public class OccurrenceInfoTypeValue : ITypeValue
    {
        public Type[] SupportedTypes
        {
            get
            {
                return new Type[] {typeof(OccurrenceInfo)};
            }
        }

        public string GetValue(object rawValue)
        {
            return GetValue(rawValue as OccurrenceInfo, false);
        }

        public string GetValue(object ownerInstance, PropertyInfo propInfo)
        {
            string text = string.Empty;

            OccurrenceInfo occur = propInfo.GetValue(ownerInstance, null) as OccurrenceInfo;

            return GetValue(occur, false);
        }

        internal static string GetValue(OccurrenceInfo occur, bool singleLine)
        {
            string text = string.Format(System.Globalization.CultureInfo.CurrentCulture, "Original Start: {0}\nStart: {1}\nEnd: {2}\nItemId: {3}",
                        occur.OriginalStart,
                        occur.Start,
                        occur.End,
                        ItemIdTypeValue.GetValue(occur.ItemId, true));

            if (singleLine)
            {
                return text.Replace("\n", "");
            }

            return text;
        }
    }
}
