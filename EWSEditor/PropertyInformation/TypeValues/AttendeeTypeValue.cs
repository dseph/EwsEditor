using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.PropertyInformation.TypeValues
{
    public class AttendeeTypeValue : ITypeValue
    {
        public Type[] SupportedTypes
        {
            get 
            {
                return new Type[] { typeof(Attendee) }; 
            }
        }

        public string GetValue(object rawValue)
        {
            return GetValue(rawValue as Attendee, false);
        }

        public string GetValue(object ownerInstance, PropertyInfo propInfo)
        {
            string text = string.Empty;

            Attendee attendee = propInfo.GetValue(ownerInstance, null) as Attendee;

            return GetValue(attendee, false);
        }

        internal static string GetValue(Attendee attendee, bool singleLine)
        {
            if (attendee == null) { return string.Empty; }

            StringBuilder value = new StringBuilder();
            value.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "Address: {0}", attendee.Address));
            value.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "Id: {0}", ItemIdTypeValue.GetValue(attendee.Id, singleLine)));
            value.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "LastResponseTiem: {0}", attendee.LastResponseTime.ToString()));
            value.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "MailboxType: {0}", attendee.MailboxType.ToString()));
            value.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "Name: {0}", attendee.Name));
            value.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "ResponseType: {0}", attendee.ResponseType));
            value.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "RoutingType: {0}", attendee.RoutingType));

            if (singleLine)
            {
                return value.ToString().Replace("\n", "");
            }

            return value.ToString();
        }
    }
}
