namespace EWSEditor.PropertyInformation.TypeValues
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    using Microsoft.Exchange.WebServices.Data;

    /// <summary>
    /// !!!  IMPORTANT  !!!
    /// New ITypeInterpreter classes must be added to this method so that
    /// they can be included in the search!
    /// </summary>
    internal class TypeValueFinder
    {
        private static Dictionary<Type, ITypeValue> propertyInterpreters = null;

        /// <summary>
        /// Returns an ITypeInterpreter object for the given type
        /// if one exists.
        /// </summary>
        /// <param name="propType">Type to look for.</param>
        /// <returns>An ITypeInterpreter object that supports the given type.</returns>
        internal static ITypeValue GetTypeInterpreter(Type propType)
        {
            if (propertyInterpreters == null)
            {
                Initialize();
            }

            if (propertyInterpreters.ContainsKey(propType))
            {
                return propertyInterpreters[propType];
            }

            return null;
        }

        /// <summary>
        /// Load all the ITypeInterpreter classes defined into a Dictionary
        /// so that they can be retrieved by their SupportedType.
        /// </summary>
        private static void Initialize()
        {
            propertyInterpreters = new Dictionary<Type, ITypeValue>();

            AddTypeValue(new ByteArrayTypeValue());
            AddTypeValue(new EmailAddressCollectionTypeValue());
            AddTypeValue(new EmailAddressTypeValue());
            AddTypeValue(new ExchangeServiceTypeValue());
            AddTypeValue(new FolderIdTypeValue());
            AddTypeValue(new InternetMessageHeaderTypeValue());
            AddTypeValue(new InternetMessageHeaderCollectionTypeValue());
            AddTypeValue(new ItemIdTypeValue());
            AddTypeValue(new MailboxTypeValue());
            AddTypeValue(new MessageBodyTypeValue());
            AddTypeValue(new OccurrenceInfoTypeValue());
            AddTypeValue(new RecurrenceTypeValue());
            AddTypeValue(new PhysicalAddressEntryTypeValue());
            AddTypeValue(new PhysicalAddressDictionaryTypeValue());
            AddTypeValue(new MimeContentTypeValue());
            AddTypeValue(new StringArrayTypeValue());
            AddTypeValue(new ByteArrayArrayTypeValue());
            AddTypeValue(new FolderPermissionCollectionTypeValue());
            AddTypeValue(new FolderPermissionTypeValue());
            AddTypeValue(new AttendeeTypeValue());
            AddTypeValue(new AttendeeCollectionTypeValue());
            AddTypeValue(new WorkingHoursTypeValue());
            AddTypeValue(new LegacyFreeBusyStatusCollectionTypeValue());
        }

        private static void AddTypeValue(ITypeValue obj)
        {
            foreach (Type supportedType in obj.SupportedTypes)
            {
                propertyInterpreters.Add(supportedType, obj);
            }
        }
    }
}
