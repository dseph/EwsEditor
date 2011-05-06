using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.PropertyInformation.TypeValues
{
    public class MimeContentTypeValue : ITypeValue
    {
        public Type[] SupportedTypes
        {
            get
            {
                return new Type[] { typeof(MimeContent) };
            }
        }

        public string GetValue(object rawValue)
        {
            return GetValue(rawValue as MimeContent, false);
        }

        public string GetValue(object ownerInstance, PropertyInfo propInfo)
        {
            string text = string.Empty;

            MimeContent content = propInfo.GetValue(ownerInstance, null) as MimeContent;

            return GetValue(content, false);
        }

        internal static string GetValue(MimeContent content, bool singleLine)
        {
            string text = string.Empty;

            text = string.Format(System.Globalization.CultureInfo.CurrentCulture, "CharacterSet: {0}\nContent:\n\n{1}", 
                content.CharacterSet, 
                System.Text.Encoding.Default.GetString(content.Content));

            if (singleLine)
            {
                return text.Replace("\n", "");
            }

            return text;
        }
    }
}
