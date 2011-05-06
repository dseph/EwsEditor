using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.PropertyInformation
{
    public struct KnownExtendedPropertyInfo
    {
        public string CanonicalNames;
        public string AlternateNames;
        public string Areas;
        public string References;

        public KnownExtendedPropertyInfo(
            string canonicalNames, 
            string alternateNames, 
            string areas, 
            string references)
        {
            CanonicalNames = canonicalNames;
            AlternateNames = alternateNames;
            Areas = areas;
            References = references;
        }

        public override string ToString()
        {
            return CanonicalNames;
        }
    }

    public partial class KnownExtendedProperties
    {
        #region Singleton Members
        // Single instance
        private static KnownExtendedProperties ThisInstance = null;

        // Private constructor
        private KnownExtendedProperties() { }

        public static KnownExtendedProperties Instance()
        {
            if (ThisInstance == null)
            {
                ThisInstance = new KnownExtendedProperties();
            }

            return ThisInstance;
        }
        #endregion

        // Create and initialize the property list
        private Dictionary<ExtendedPropertyDefinition, KnownExtendedPropertyInfo> PropertyDictionary = new Dictionary<ExtendedPropertyDefinition,KnownExtendedPropertyInfo>();

        public ExtendedPropertyDefinition[] GetAllPropertyDefinitions()
        {
            // Initialize list on first use.
            if (this.PropertyDictionary.Count == 0) { InitializeList(); };

            ExtendedPropertyDefinition[] properties = new ExtendedPropertyDefinition[this.PropertyDictionary.Count];
            this.PropertyDictionary.Keys.CopyTo(properties, 0);

            return properties;
        }

        public KnownExtendedPropertyInfo[] GetAllKnownPropertyInfos()
        {
            // Initialize list on first use.
            if (this.PropertyDictionary.Count == 0) { InitializeList(); };

            KnownExtendedPropertyInfo[] infos = new KnownExtendedPropertyInfo[this.PropertyDictionary.Count];
            this.PropertyDictionary.Values.CopyTo(infos, 0);

            return infos;
        }

        /// <summary>
        /// Given KnownExtendedPropertyInfo look up the corresponding property definition
        /// </summary>
        /// <param name="info">Info to lookup</param>
        /// <returns>Property Definition</returns>
        public ExtendedPropertyDefinition GetExtendedPropertyDefinition(KnownExtendedPropertyInfo info)
        {
            // Initialize list on first use.
            if (this.PropertyDictionary.Count == 0) { InitializeList(); };

            if (this.PropertyDictionary.ContainsValue(info))
            {
                foreach (KeyValuePair<ExtendedPropertyDefinition, KnownExtendedPropertyInfo> item in this.PropertyDictionary)
                {
                    if (item.Value.CanonicalNames == info.CanonicalNames)
                    {
                        return item.Key;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Look up a known ExtendedPropertyDefinition by the canonical name or by
        /// matching one of the alternate names.
        /// </summary>
        /// <param name="name">Name to look up</param>
        /// <returns>Property definition if found, NULL if no matches</returns>
        public ExtendedPropertyDefinition GetExtendedPropertyDefinition(string findName)
        {
            // Initialize list on first use.
            if (this.PropertyDictionary.Count == 0) { InitializeList(); };

            // If there is no input bail out
            if (findName.Length == 0) { return null; }

            foreach (KeyValuePair<ExtendedPropertyDefinition, KnownExtendedPropertyInfo> item in this.PropertyDictionary)
            {
                if (item.Value.CanonicalNames.IndexOf(findName, StringComparison.CurrentCultureIgnoreCase) > -1 ||
                    item.Value.AlternateNames.IndexOf(findName, StringComparison.CurrentCultureIgnoreCase) > -1)
                {
                    List<string> names = new List<string>();

                    names.AddRange(item.Value.CanonicalNames.Split(new char[] { ',' }));
                    names.AddRange(item.Value.AlternateNames.Split(new char[] { ',' }));

                    foreach (string name in names)
                    {
                        if (name.Trim().ToUpper().Equals(findName.ToUpper()))
                        {
                            return item.Key;
                        }
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Lookup the ExtendedPropertyDefinition's name.
        /// </summary>
        /// <param name="exProp">Property to lookup.</param>
        /// <PropertyDictionaryurns>Canonical name of the property if found.</PropertyDictionaryurns>
        public KnownExtendedPropertyInfo? GetKnownExtendedPropertyInfo(ExtendedPropertyDefinition exProp)
        {
            // Initialize list on first use.
            if (this.PropertyDictionary.Count == 0) { InitializeList(); };

            if (PropertyDictionary.ContainsKey(exProp))
            {
                return PropertyDictionary[exProp];
            }

            return null;
        }
    }
}