using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.PropertyInformation.TypeValues
{
    public class InternetMessageHeaderCollectionTypeValue : ITypeValue
    {
        public Type[] SupportedTypes
        {
            get
            {
                return new Type[] { typeof(InternetMessageHeaderCollection) };
            }
        }

        public string GetValue(object rawValue)
        {
            return GetValue(rawValue as InternetMessageHeaderCollection, false);
        }

        public string GetValue(object ownerInstance, PropertyInfo propInfo)
        {
            string text = string.Empty;

            InternetMessageHeaderCollection headers =
                propInfo.GetValue(ownerInstance, null) as InternetMessageHeaderCollection;

            return GetValue(headers, false);
        }

        internal static string GetValue(InternetMessageHeaderCollection headers, bool singleLine)
        {
            StringBuilder text = new StringBuilder();

            text.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "Count: {0}", headers.Count));
            foreach (InternetMessageHeader header in headers)
            {
                //text.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "Header {0}: {1}",
                //    header.GetType().ToString(),
                //    InternetMessageHeaderTypeValue.GetValue(header, true)));
                text.AppendLine();
                text.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "Name: {0}", header.Name));
                text.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "Value: {0}", header.Value));
            }

            if (singleLine)
            {
                return text.ToString().Replace("\n", "");
            }

            return text.ToString();
        }
    }
}
