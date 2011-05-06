using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.PropertyInformation.SmartViews
{
    /// <summary>
    /// Display a smart view of PidLidNoteColor based on
    /// http://msdn.microsoft.com/en-us/library/cc815603.aspx
    /// </summary>
    public class PidLidNoteColorSmartView : ISmartView
    {
        public ExtendedPropertyDefinition[] SupportedProperties
        {
            get
            {
                return new ExtendedPropertyDefinition[] {KnownExtendedProperties.Instance().PidLidNoteColor};
            }
        }

        public string GetSmartView(object rawValue)
        {
            string smartView = string.Empty;

            switch (rawValue as string)
            {
                case "0":
                    smartView = "Blue";
                    break;
                case "1":
                    smartView = "Green";
                    break;
                case "2":
                    smartView = "Pink";
                    break;
                case "3":
                    smartView = "Yellow";
                    break;
                case "4":
                    smartView = "White";
                    break;
            }

            return smartView;
        }
    }
}
