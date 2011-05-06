namespace EWSEditor.PropertyInformation.TypeValues
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    using Microsoft.Exchange.WebServices.Data;

    public class WorkingHoursTypeValue : ITypeValue
    {
        public Type[] SupportedTypes
        {
            get
            {
                return new Type[] { typeof(WorkingHours) };
            }
        }

        public string GetValue(object rawValue)
        {
            return GetValue(rawValue as WorkingHours, false);
        }

        public string GetValue(object ownerInstance, PropertyInfo propInfo)
        {
            string text = string.Empty;

            WorkingHours mbx = propInfo.GetValue(ownerInstance, null) as WorkingHours;

            return GetValue(mbx, false);
        }

        internal static string GetValue(WorkingHours hours, bool singleLine)
        {
            return string.Format(
                    System.Globalization.CultureInfo.CurrentCulture,
                    "DaysOfTheWeek: {0} \r\nStartTime: {1} \r\nEndTime: {2} \r\nTimeZone: {3}",
                    ToString(hours.DaysOfTheWeek),
                    hours.StartTime.ToString(),
                    hours.EndTime.ToString(),
                    hours.TimeZone.DisplayName);
        }

        internal static string ToString(System.Collections.ObjectModel.Collection<DayOfTheWeek> days)
        {
            if (days.Count > 0)
            {
                StringBuilder output = new StringBuilder();
                output.AppendFormat("Count: {0} Days: ", days.Count);
                bool first = true;
                foreach (DayOfTheWeek day in days)
                {
                    if (!first)
                    {
                        output.Append(" | ");
                    }

                    output.Append(day.ToString());
                    first = false;
                }

                return output.ToString();
            }

            return string.Empty;
        }
    }
}
