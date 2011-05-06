namespace EWSEditor.PropertyInformation.SmartViews
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Microsoft.Exchange.WebServices.Data;

    /// <summary>
    /// Display a smart view of PidTagFlagStatus based on
    /// http://msdn.microsoft.com/en-us/library/cc842307.aspx
    /// </summary>
    internal class PidTagFlagStatusSmartView : ISmartView
    {
        #region ISmartView Members

        public Microsoft.Exchange.WebServices.Data.ExtendedPropertyDefinition[] SupportedProperties
        {
            get 
            {
                return new ExtendedPropertyDefinition[] { KnownExtendedProperties.Instance().PidTagFlagStatus };
            }
        }

        public string GetSmartView(object rawValue)
        {
            int? status = rawValue as int?;

            if (!status.HasValue)
            {
                return "Unflagged";
            }

            switch (status)
            {
                case 0x1:
                    return "followupComplete";
                case 0x2:
                    return "followupFlagged";
                default:
                    // TODO: This is really an error condition, should we report it as such?
                    return string.Empty;
            }
        }

        #endregion
    }
}
