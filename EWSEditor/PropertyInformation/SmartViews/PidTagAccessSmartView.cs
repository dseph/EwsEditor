using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.PropertyInformation.SmartViews
{
    /// <summary>
    /// Display a smart view of PidTagAccess based on
    /// http://msdn.microsoft.com/en-us/library/cc979218.aspx
    /// </summary>
    public class PidTagAccessSmartView : ISmartView
    {
        public ExtendedPropertyDefinition[] SupportedProperties
        {
            get
            {
                return new ExtendedPropertyDefinition[] {KnownExtendedProperties.Instance().PidTagAccess};
            }
        }

        public string GetSmartView(object rawValue)
        {
            List<BitFlagDefinition> flags = new List<BitFlagDefinition>();
            flags.Add(new BitFlagDefinition(0x1, "MAPI_ACCESS_MODIFY"));
            flags.Add(new BitFlagDefinition(0x2, "MAPI_ACCESS_READ"));
            flags.Add(new BitFlagDefinition(0x4, "MAPI_ACCESS_DELETE"));
            flags.Add(new BitFlagDefinition(0x8, "MAPI_ACCESS_CREATE_HIERARCHY"));
            flags.Add(new BitFlagDefinition(0x10, "MAPI_ACCESS_CREATE_CONTENTS"));
            flags.Add(new BitFlagDefinition(0x20, "MAPI_ACCESS_CREATE_ASSOCIATED"));

            return BitFlagsToStringHelper.ToString(Convert.ToInt32(rawValue), flags.ToArray());
        }
    }
}
