namespace EWSEditor.PropertyInformation.SmartViews
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Microsoft.Exchange.WebServices.Data;

    /// <summary>
    /// !!!  IMPORTANT  !!!
    /// New ISmartView classes must be added to this method so that
    /// they can be included in the search!
    /// </summary>
    internal class SmartViewFinder
    {
        private static Dictionary<ExtendedPropertyDefinition, ISmartView> smartViews = null;

        /// <summary>
        /// Returns an ISmartView object for the given property
        /// if one exists.
        /// </summary>
        /// <param name="propDef">Extended property to look for.</param>
        /// <returns>An ISmartView object that supports the given property.</returns>
        public static ISmartView GetSmartView(ExtendedPropertyDefinition propDef)
        {
            if (smartViews == null)
            {
                Initialize();
            }

            if (smartViews.ContainsKey(propDef))
            {
                return smartViews[propDef];
            }

            return null;
        }

        /// <summary>
        /// Load all the ISmartView classes defined into a Dictionary
        /// so that they can be retrieved by their SupportedProperty.
        /// </summary>
        private static void Initialize()
        {
            smartViews = new Dictionary<ExtendedPropertyDefinition, ISmartView>();

            AddSmartView(new PidLidNoteColorSmartView());
            AddSmartView(new PidLidSideEffectsSmartView());
            AddSmartView(new PidTagAccessSmartView());
            AddSmartView(new PidTagIconIndexSmartView());
            AddSmartView(new TzDefinitionSmartView());
            AddSmartView(new GlobalObjectIdSmartView());
            AddSmartView(new PidTagMessageFlagsSmartView());
            AddSmartView(new PidTagFlagStatusSmartView());
            AddSmartView(new PidTagFollowupIconSmartView());
        }

        private static void AddSmartView(ISmartView obj)
        {
            foreach (ExtendedPropertyDefinition propDef in obj.SupportedProperties)
            {
                smartViews.Add(propDef, obj);
            }
        }
    }
}
