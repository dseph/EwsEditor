using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.PropertyInformation.SmartViews
{
    /// <summary>
    /// Display a smart view of PidLidSideEffects based on
    /// http://msdn.microsoft.com/en-us/library/cc842271.aspx
    /// </summary>
    public class PidLidSideEffectsSmartView : ISmartView
    {
        public Microsoft.Exchange.WebServices.Data.ExtendedPropertyDefinition[] SupportedProperties
        {
            get 
            {
                return new ExtendedPropertyDefinition[] {KnownExtendedProperties.Instance().PidLidSideEffects};
            }
        }

        public string GetSmartView(object rawValue)
        {
            List<BitFlagDefinition> flags = new List<BitFlagDefinition>();
            flags.Add(new BitFlagDefinition(0x0001, "seOpenToDelete"));
            flags.Add(new BitFlagDefinition(0x0008, "seNoFrame"));
            flags.Add(new BitFlagDefinition(0x0010, "seCoerceToInbox"));
            flags.Add(new BitFlagDefinition(0x0020, "seOpenTocopy"));
            flags.Add(new BitFlagDefinition(0x0040, "seOpenToMove"));
            flags.Add(new BitFlagDefinition(0x0100, "seOpenForCtxMenu"));
            flags.Add(new BitFlagDefinition(0x0400, "seCannotUndoDelete"));
            flags.Add(new BitFlagDefinition(0x0800, "seCannotUndoCopy"));
            flags.Add(new BitFlagDefinition(0x1000, "seCannotUndoMove"));
            flags.Add(new BitFlagDefinition(0x2000, "seHasScript"));
            flags.Add(new BitFlagDefinition(0x4000, "seOpenToPermDelete"));

            return BitFlagsToStringHelper.ToString(Convert.ToInt32(rawValue), flags.ToArray());
        }
    }
}
