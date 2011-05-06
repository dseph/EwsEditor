using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.PropertyInformation.TypeValues
{
    public class ItemIdTypeValue : ITypeValue
    {
        public Type[] SupportedTypes
        {
            get
            {
                return new Type[] {typeof(ItemId)};
            }
        }

        public string GetValue(object rawValue)
        {
            return GetValue(rawValue as ItemId, false);
        }

        public string GetValue(object ownerInstance, PropertyInfo propInfo)
        {
            string text = string.Empty;

            ItemId itemId = propInfo.GetValue(ownerInstance, null) as ItemId;

            return GetValue(itemId, false);
        }

        internal static string GetValue(ItemId itemId, bool singleLine)
        {
            if (itemId == null) { return string.Empty; }

            StringBuilder value = new StringBuilder();
            value.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "UniqueId: {0}", itemId.UniqueId));
            value.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "ChangeKey:: {0}", itemId.ChangeKey));

            if (singleLine)
            {
                return value.ToString().Replace("\n", "");
            }

            return value.ToString();
        }
    }
}
