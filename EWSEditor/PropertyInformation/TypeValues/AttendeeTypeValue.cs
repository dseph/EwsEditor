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
            value.AppendLine("Address: " + attendee.Address);
            value.AppendLine("Id: " + ItemIdTypeValue.GetValue(attendee.Id, singleLine));
            value.AppendLine("LastResponseTime: " + attendee.LastResponseTime.ToString());
            value.AppendLine("MailboxType: " + attendee.MailboxType.ToString());
            value.AppendLine("Name: {0}" + attendee.Name);
            value.AppendLine("ResponseType: " + attendee.ResponseType);
            value.AppendLine("RoutingType: {0}" + attendee.RoutingType);

            if (singleLine)
            {
                return value.ToString().Replace("\n", "");
            }

            return value.ToString();
        }
    }
}
