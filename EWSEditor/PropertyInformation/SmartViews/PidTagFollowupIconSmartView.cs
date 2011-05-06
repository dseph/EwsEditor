namespace EWSEditor.PropertyInformation.SmartViews
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Microsoft.Exchange.WebServices.Data;

    /// <summary>
    /// Display a smart view of PidTagFollowupIcon based on
    /// http://msdn.microsoft.com/en-us/library/cc815482.aspx
    /// </summary>
    internal class PidTagFollowupIconSmartView : ISmartView
    {
        #region ISmartView Members

        public ExtendedPropertyDefinition[] SupportedProperties
        {
            get 
            {
                return new ExtendedPropertyDefinition[] { KnownExtendedProperties.Instance().PidTagFollowupIcon };
            }
        }

        public string GetSmartView(object rawValue)
        {
            int? icon = rawValue as int?;

            // TODO: This is really an error condition, should we report it as such?
            if (!icon.HasValue)
            {
                return string.Empty;
            }

            switch (icon.Value)
            {
                case 0x1:
                    return "followupIcon1 (Purple flag)";
                case 0x2:
                    return "followupIcon2 (Orange flag)";
                case 0x3:
                    return "followupIcon3 (Green flag)";
                case 0x4:
                    return "followupIcon4 (Yellow flag)";
                case 0x5:
                    return "followupIcon5 (Blue flag)";
                case 0x6:
                    return "followupIcon6 (Red flag)";
                default:
                    // TODO: This is really an error condition, should we report it as such?
                    return string.Empty;
            }
        }

        #endregion
    }
}
