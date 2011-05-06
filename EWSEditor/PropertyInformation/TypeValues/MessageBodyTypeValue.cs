using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.PropertyInformation.TypeValues
{
    public class MessageBodyTypeValue : ITypeValue
    {
        public Type[] SupportedTypes
        {
            get
            {
                return new Type[] {typeof(MessageBody)};
            }
        }

        public string GetValue(object rawValue)
        {
            return GetValue(rawValue as MessageBody, false);
        }

        public string GetValue(object ownerInstance, PropertyInfo propInfo)
        {
            string text = string.Empty;

            MessageBody body = propInfo.GetValue(ownerInstance, null) as MessageBody;

            return GetValue(body, false);
        }

        internal static string GetValue(MessageBody body, bool singleLine)
        {
            string text = string.Empty;

            text = string.Format(System.Globalization.CultureInfo.CurrentCulture, "Type: {0}\nText: {1}", body.BodyType.ToString(), body.Text);

            if (singleLine)
            {
                return text.Replace("\n", "");
            }

            return text;
        }
    }
}
