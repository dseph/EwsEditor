using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.PropertyInformation.TypeValues
{
    public class PhysicalAddressEntryTypeValue : ITypeValue
    {
        public Type[] SupportedTypes
        {
            get
            {
                return new Type[] { typeof(PhysicalAddressEntry) };
            }
        }

        public string GetValue(object rawValue)
        {
            return GetValue(rawValue as PhysicalAddressEntry, false);
        }

        public string GetValue(object ownerInstance, PropertyInfo propInfo)
        {
            PhysicalAddressEntry entry = propInfo.GetValue(ownerInstance, null) as PhysicalAddressEntry;

            return GetValue(entry, false);
        }

        /// <summary>
        /// Return the text to describe each entry in the PhysicalAddessDictionary
        /// </summary>
        /// <param name="service">PhysicalAddressDictionary to get the value from.</param>
        /// <returns>Text to describe the object's value.</returns>
        internal static string GetValue(PhysicalAddressEntry entry, bool singleLine)
        {
            if (entry == null) { return string.Empty; }

            StringBuilder value = new StringBuilder();

            value.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "Street: {0}", entry.Street));
            value.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "City: {0}", entry.City));
            value.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "State: {0}", entry.State));
            value.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "PostalCode: {0}", entry.PostalCode));
            value.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "CountryOrRegion: {0}", entry.CountryOrRegion));

            if (singleLine)
            {
                return value.ToString().Replace("\n", "");
            }

            return value.ToString();
        }
    }
}
