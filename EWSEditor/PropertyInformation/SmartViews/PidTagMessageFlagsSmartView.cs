namespace EWSEditor.PropertyInformation.SmartViews
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Microsoft.Exchange.WebServices.Data;

    /// <summary>
    /// Display a SmartView of PidTagMessageFlags based on
    /// http://msdn.microsoft.com/en-us/library/cc839733.aspx
    /// </summary>
    internal class PidTagMessageFlagsSmartView : ISmartView
    {
        #region ISmartView Members

        public Microsoft.Exchange.WebServices.Data.ExtendedPropertyDefinition[] SupportedProperties
        {
            get 
            {
                return new ExtendedPropertyDefinition[] { KnownExtendedProperties.Instance().PidTagMessageFlags };
            }
        }

        public string GetSmartView(object rawValue)
        {
            int? flagValue = rawValue as int?;

            // TODO: This is really an error condition, should we report it as such?
            if (!flagValue.HasValue)
            {
                return string.Empty;
            }

            List<BitFlagDefinition> flags = new List<BitFlagDefinition>();
            flags.Add(new BitFlagDefinition(0x0001, "mfRead"));
            flags.Add(new BitFlagDefinition(0x0002, "mfUnmodified"));
            flags.Add(new BitFlagDefinition(0x0004, "mfSubmitted"));
            flags.Add(new BitFlagDefinition(0x0008, "mfUnsent"));
            flags.Add(new BitFlagDefinition(0x0010, "mfHasAttach"));
            flags.Add(new BitFlagDefinition(0x0020, "mfFromMe"));
            flags.Add(new BitFlagDefinition(0x0040, "mfFAI"));
            flags.Add(new BitFlagDefinition(0x0080, "mfResend"));
            flags.Add(new BitFlagDefinition(0x0100, "mfNotifyRead"));
            flags.Add(new BitFlagDefinition(0x0200, "mfNotifyUnread"));
            flags.Add(new BitFlagDefinition(0x2000, "mfInternet"));
            flags.Add(new BitFlagDefinition(0x8000, "mfUntrusted"));

            return BitFlagsToStringHelper.ToString(flagValue.Value, flags.ToArray());
        }

        #endregion
    }
}
