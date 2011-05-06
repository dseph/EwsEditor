using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.PropertyInformation.TypeValues
{
    public class InternetMessageHeaderTypeValue : ITypeValue
    {
        public Type[] SupportedTypes
        {
            get
            {
                return new Type[] {typeof(InternetMessageHeader)};
            }
        }

        public string GetValue(object rawValue)
        {
            return GetValue(rawValue as InternetMessageHeader, false);
        }

        public string GetValue(object ownerInstance, PropertyInfo propInfo)
        {
            string text = string.Empty;

            InternetMessageHeader header =
                propInfo.GetValue(ownerInstance, null) as InternetMessageHeader;

            return GetValue(header, false);
        }

        internal static string GetValue(InternetMessageHeader header, bool singleLine)
        {
            if (singleLine)
            {
                return string.Format(System.Globalization.CultureInfo.CurrentCulture, "Name: {0} Value: {1}", header.Name, header.Value);
            }

            return string.Format(System.Globalization.CultureInfo.CurrentCulture, "Name: {0}\nValue: {1}", header.Name, header.Value);
        }
    }
}
