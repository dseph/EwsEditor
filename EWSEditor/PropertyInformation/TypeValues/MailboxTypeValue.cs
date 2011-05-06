using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.PropertyInformation.TypeValues
{
    public class MailboxTypeValue : ITypeValue
    {
        public Type[] SupportedTypes
        {
            get
            {
                return new Type[] {typeof(Mailbox)};
            }
        }

        public string GetValue(object rawValue)
        {
            return GetValue(rawValue as Mailbox, false);
        }

        public string GetValue(object ownerInstance, PropertyInfo propInfo)
        {
            string text = string.Empty;

            Mailbox mbx = propInfo.GetValue(ownerInstance, null) as Mailbox;

            return GetValue(mbx, false);
        }

        internal static string GetValue(Mailbox mbx, bool singleLine)
        {
            if (singleLine)
            {
                return string.Format(System.Globalization.CultureInfo.CurrentCulture, "Address: {0} RoutingType: {1}", mbx.Address, mbx.RoutingType);
            }

            return string.Format(System.Globalization.CultureInfo.CurrentCulture, "Address: {0}\nRoutingType: {1}", mbx.Address, mbx.RoutingType);
        }
    }
}
