using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.PropertyInformation.TypeValues
{
    public class PhysicalAddressDictionaryTypeValue : ITypeValue
    {
        public Type[] SupportedTypes
        {
            get
            {
                return new Type[] { typeof(PhysicalAddressDictionary) };
            }
        }

        public string GetValue(object rawValue)
        {
            return GetValue(rawValue as PhysicalAddressDictionary, false);
        }

        public string GetValue(object ownerInstance, PropertyInfo propInfo)
        {
            PhysicalAddressDictionary dictionary = propInfo.GetValue(ownerInstance, null) as PhysicalAddressDictionary;

            return GetValue(dictionary, false);
        }

        /// <summary>
        /// Return the text to describe each entry in the PhysicalAddessDictionary
        /// </summary>
        /// <param name="service">PhysicalAddressDictionary to get the value from.</param>
        /// <returns>Text to describe the object's value.</returns>
        internal static string GetValue(PhysicalAddressDictionary dictionary, bool singleLine)
        {
            if (dictionary == null) { return string.Empty; }

            StringBuilder text = new StringBuilder();

            foreach(object value in System.Enum.GetValues(typeof(PhysicalAddressKey)))
            {
                if (dictionary.Contains((PhysicalAddressKey)value))
                {
                    text.AppendLine(value.ToString());
                    text.AppendLine();
                    text.AppendLine(PhysicalAddressEntryTypeValue.GetValue(dictionary[(PhysicalAddressKey)value], singleLine));
                }
            }

            if (singleLine)
            {
                return text.ToString().Replace("\n", "");
            }

            return text.ToString();
        }
    }
}
