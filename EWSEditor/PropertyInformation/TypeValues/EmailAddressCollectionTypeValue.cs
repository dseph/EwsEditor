using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.PropertyInformation.TypeValues
{
    public class EmailAddressCollectionTypeValue : ITypeValue
    {
        public Type[] SupportedTypes
        {
            get
            {
                return new Type[] {typeof(EmailAddressCollection)};
            }
        }

        public string GetValue(object rawValue)
        {
            return GetValue(rawValue as EmailAddressCollection, false);
        }

        public string GetValue(object ownerInstance, PropertyInfo propInfo)
        {
            string text = string.Empty;

            EmailAddressCollection emails =
                propInfo.GetValue(ownerInstance, null) as EmailAddressCollection;

            return GetValue(emails, false);
        }

        internal static string GetValue(EmailAddressCollection emails, bool singleLine)
        {
            if (emails == null) { return string.Empty; }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "Length: {0}", emails.Count));
            sb.AppendLine();

            int i = 0;
            foreach (EmailAddress email in emails)
            {
                sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "EmailAddress [{0}]", i));
                sb.AppendLine(EmailAddressTypeValue.GetValue(email, true));
                sb.AppendLine();
                sb.AppendLine();
                i++;
            }

            return sb.ToString();
        }
    }
}
