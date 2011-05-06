namespace EWSEditor.PropertyInformation.SmartViews
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    using Microsoft.Exchange.WebServices.Data;

    /// <summary>
    /// Display a smart view of PidTagIconIndex based on
    /// http://msdn.microsoft.com/en-us/library/cc815472.aspx
    /// </summary>
    public class PidTagIconIndexSmartView : ISmartView
    {
        public Microsoft.Exchange.WebServices.Data.ExtendedPropertyDefinition[] SupportedProperties
        {
            get
            {
                return new ExtendedPropertyDefinition[] { KnownExtendedProperties.Instance().PidTagIconIndex };
            }
        }

        public string GetSmartView(object rawValue)
        {
            string smartView = string.Empty;

            // TODO: This is really an error condition, should we report it as such?
            if (!(rawValue is int))
            {
                return string.Empty;
            }

            uint? index = 0xFFFFFFFF;

            // HACK:
            if (Convert.ToInt32(rawValue) != -1)
            {
                index = Convert.ToUInt32(rawValue);
            }

            switch (index)
            {
                case 0xFFFFFFFF:
                    smartView = "New mail";
                    break;
                case 0x00000001:
                    smartView = "Post";
                    break;
                case 0x00000003:
                    smartView = "Other";
                    break;
                case 0x00000100:
                    smartView = "Read mail";
                    break;
                case 0x00000101:
                    smartView = "Unread mail";
                    break;
                case 0x00000102:
                    smartView = "Submitted mail";
                    break;
                case 0x00000103:
                    smartView = "Submitted mail";
                    break;
                case 0x00000104:
                    smartView = "Receipt mail";
                    break;
                case 0x00000105:
                    smartView = "Replied mail";
                    break;
                case 0x00000106:
                    smartView = "Forwarded mail";
                    break;
                case 0x00000107:
                    smartView = "Remote mail";
                    break;
                case 0x00000108:
                    smartView = "Delivery mail";
                    break;
                case 0x00000109:
                    smartView = "Read mail";
                    break;
                case 0x0000010A:
                    smartView = "Nondelivery mail";
                    break;
                case 0x0000010B:
                    smartView = "Nonread mail";
                    break;
                case 0x0000010C:
                    smartView = "Recall_S mail";
                    break;
                case 0x0000010D:
                    smartView = "Recall_F mail";
                    break;
                case 0x0000011B:
                    smartView = "Out of office mail";
                    break;
                case 0x0000011C:
                    smartView = "Recall mail";
                    break;
                case 0x00000130:
                    smartView = "Tracked mail";
                    break;
                case 0x00000200:
                    smartView = "Contact";
                    break;
                case 0x00000202:
                    smartView = "Distribution List";
                    break;
                case 0x00000300:
                    smartView = "Sticky note blue";
                    break;
                case 0x00000301:
                    smartView = "Sticky note green";
                    break;
                case 0x00000302:
                    smartView = "Sticky note pink";
                    break;
                case 0x00000303:
                    smartView = "Sticky note yellow";
                    break;
                case 0x00000304:
                    smartView = "Sticky note white";
                    break;
                case 0x00000400:
                    smartView = "Single instance appointment";
                    break;
                case 0x00000401:
                    smartView = "Recurring appointment";
                    break;
                case 0x00000402:
                    smartView = "Single instance meeting";
                    break;
                case 0x00000403:
                    smartView = "Recurring meeting";
                    break;
                case 0x00000404:
                    smartView = "Meeting request";
                    break;
                case 0x00000405:
                    smartView = "Accept";
                    break;
                case 0x00000406:
                    smartView = "Decline";
                    break;
                case 0x00000407:
                    smartView = "Tentativly";
                    break;
                case 0x00000408:
                    smartView = "Cancellation";
                    break;
                case 0x00000409:
                    smartView = "Informational update";
                    break;
                case 0x00000500:
                    smartView = "Task/task";
                    break;
                case 0x00000501:
                    smartView = "Unassigned recurring task";
                    break;
                case 0x00000502:
                    smartView = "Assignee's task";
                    break;
                case 0x00000503:
                    smartView = "Assigner's task";
                    break;
                case 0x00000504:
                    smartView = "Task request";
                    break;
                case 0x00000505:
                    smartView = "Task acceptance";
                    break;
                case 0x00000506:
                    smartView = "Task rejection";
                    break;
                case 0x00000601:
                    smartView = "Journal conversation";
                    break;
                case 0x00000602:
                    smartView = "Journal e-mail message";
                    break;
                case 0x00000603:
                    smartView = "Journal meeting request";
                    break;
                case 0x00000604:
                    smartView = "Journal meeting response";
                    break;
                case 0x00000606:
                    smartView = "Journal task request";
                    break;
                case 0x00000607:
                    smartView = "Journal task response";
                    break;
                case 0x00000608:
                    smartView = "Journal note";
                    break;
                case 0x00000609:
                    smartView = "Journal fax";
                    break;
                case 0x0000060A:
                    smartView = "Journal phone call";
                    break;
                case 0x0000060C:
                    smartView = "Journal letter";
                    break;
                case 0x0000060D:
                    smartView = "Journal Microsoft Office Word";
                    break;
                case 0x0000060E:
                    smartView = "Journal Microsoft Office Excel";
                    break;
                case 0x0000060F:
                    smartView = "Journal Microsoft Office PowerPoint";
                    break;
                case 0x00000610:
                    smartView = "Journal Microsoft Office Access";
                    break;
                case 0x00000612:
                    smartView = "Journal document";
                    break;
                case 0x00000613:
                    smartView = "Journal meeting";
                    break;
                case 0x00000614:
                    smartView = "Journal meeting cancellation";
                    break;
                case 0x00000615:
                    smartView = "Journal remote session";
                    break;
            }

            return smartView;
        }
    }
}
