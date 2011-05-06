using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.PropertyInformation.TypeValues
{
    /// <summary>
    /// This interpreter handles all the Recurrence pattern types
    /// </summary>
    public class RecurrenceTypeValue : ITypeValue
    {
        public Type[] SupportedTypes
        {
            get
            {
                return new Type[] {
                    typeof(Recurrence),
                    typeof(Recurrence.DailyPattern),
                    typeof(Recurrence.DailyRegenerationPattern),
                    typeof(Recurrence.MonthlyPattern),
                    typeof(Recurrence.MonthlyRegenerationPattern),
                    typeof(Recurrence.RelativeMonthlyPattern),
                    typeof(Recurrence.RelativeYearlyPattern),
                    typeof(Recurrence.WeeklyPattern),
                    typeof(Recurrence.WeeklyRegenerationPattern),
                    typeof(Recurrence.YearlyPattern),
                    typeof(Recurrence.YearlyRegenerationPattern)
                };
            }
        }

        public string GetValue(object rawValue)
        {
            return GetValue(rawValue as Recurrence, false);
        }

        public string GetValue(object ownerInstance, PropertyInfo propInfo)
        {
            string text = string.Empty;

            Recurrence recur = propInfo.GetValue(ownerInstance, null) as Recurrence;

            return GetValue(recur, false);
        }

        internal static string GetValue(Recurrence recur, bool singleLine)
        {
            // TODO: Implement switching for the specialized recurrence pattern types
            string text = string.Format(System.Globalization.CultureInfo.CurrentCulture, "StartDate: {0}\nEndDate: {1}\nHasEnd: {2}\nNumberOfOcccurences: {3}",
                        recur.StartDate,
                        recur.EndDate,
                        recur.HasEnd.ToString(),
                        recur.NumberOfOccurrences.ToString());

            if (singleLine)
            {
                return text.Replace("\n", "");
            }

            return text;
        }
    }
}
