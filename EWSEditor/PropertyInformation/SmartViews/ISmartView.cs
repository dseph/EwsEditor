using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.PropertyInformation.SmartViews
{
    interface ISmartView
    {
        ExtendedPropertyDefinition[] SupportedProperties { get; }
        string GetSmartView(object rawValue);
    }
}
