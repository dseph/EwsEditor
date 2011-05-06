using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.PropertyInformation.TypeValues
{
    public class AttendeeCollectionTypeValue:ITypeValue
    {

        public Type[] SupportedTypes
        {
            get
            {
                return new Type[] { typeof(AttendeeCollection) };
            }
        }

        public string GetValue(object rawValue)
        {
            return GetValue(rawValue as AttendeeCollection, false);
        }

        public string GetValue(object ownerInstance, PropertyInfo propInfo)
        {
            string text = string.Empty;

            AttendeeCollection attendees = propInfo.GetValue(ownerInstance, null) as AttendeeCollection;

            return GetValue(attendees, false);
        }

        internal static string GetValue(AttendeeCollection attendees, bool singleOut)
        {
            if (attendees == null) { return string.Empty; }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "Length: {0}", attendees.Count));
            sb.AppendLine();

            int i = 0;
            foreach (Attendee attendee in attendees)
            {
                sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "Attendee [{0}]", i));
                sb.AppendLine(AttendeeTypeValue.GetValue(attendee, true));
                sb.AppendLine();
                sb.AppendLine();
                i++;
            }

            return sb.ToString();
        }
    }
}
