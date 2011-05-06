using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.PropertyInformation.TypeValues
{
    public class EmailAddressTypeValue : ITypeValue
    {
        public Type[] SupportedTypes
        {
            get
            {
                return new Type[] {typeof(EmailAddress)};
            }
        }

        public string GetValue(object rawValue)
        {
            return GetValue(rawValue as EmailAddress, false);
        }

        public string GetValue(object ownerInstance, PropertyInfo propInfo)
        {
            string text = string.Empty;

            EmailAddress email = propInfo.GetValue(ownerInstance, null) as EmailAddress;

            return GetValue(email, false);
        }

        internal static string GetValue(EmailAddress email, bool singleLine)
        {
            StringBuilder text = new StringBuilder();

            text.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "Address: {0} ", email.Address));
            text.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "Id: {0} ", email.Id));
            text.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "MailboxType: {0} ", email.MailboxType));
            text.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "Name: {0} ", email.Name));
            text.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "RoutingType: {0} ", email.RoutingType));

            if (singleLine)
            {
                return text.ToString().Replace("\n", "");
            }

            return text.ToString();
        }
    }
}
