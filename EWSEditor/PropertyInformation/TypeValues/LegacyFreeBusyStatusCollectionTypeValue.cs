namespace EWSEditor.PropertyInformation.TypeValues
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    using Microsoft.Exchange.WebServices.Data;

    public class LegacyFreeBusyStatusCollectionTypeValue : ITypeValue
    {
        public Type[] SupportedTypes
        {
            get
            {
                return new Type[] { typeof(Collection<LegacyFreeBusyStatus>) };
            }
        }

        public string GetValue(object rawValue)
        {
            return GetValue(rawValue as Collection<LegacyFreeBusyStatus>);
        }

        public string GetValue(object ownerInstance, PropertyInfo propInfo)
        {
            string text = string.Empty;

            Collection<LegacyFreeBusyStatus> status = propInfo.GetValue(ownerInstance, null) as Collection<LegacyFreeBusyStatus>;

            return GetValue(status);
        }

        internal static string GetValue(Collection<LegacyFreeBusyStatus> status)
        {
            if (status == null)
            {
                return string.Empty;
            }

            StringBuilder mergedFBStatus = new StringBuilder();
            mergedFBStatus.AppendLine(String.Format("Count: {0} ", status.Count));

            if (status.Count > 0)
            {
                mergedFBStatus.AppendLine("Data: ");

                bool first = true;
                foreach (LegacyFreeBusyStatus legfb in status)
                {
                    if (!first)
                    {
                        mergedFBStatus.Append(" | ");
                    }

                    mergedFBStatus.Append(legfb.ToString());
                    first = false;
                }
            }

            return mergedFBStatus.ToString();
        }
    }
}
