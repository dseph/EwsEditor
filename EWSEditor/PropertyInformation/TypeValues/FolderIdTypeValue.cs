using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.PropertyInformation.TypeValues
{
    public class FolderIdTypeValue : ITypeValue
    {
        public Type[] SupportedTypes
        {
            get
            {
                return new Type[] {typeof(FolderId)};
            }
        }

        public string GetValue(object rawValue)
        {
            return GetValue(rawValue as FolderId, false);
        }

        public string GetValue(object ownerInstance, PropertyInfo propInfo)
        {
            FolderId folderId = propInfo.GetValue(ownerInstance, null) as FolderId;

            return GetValue(folderId, false);
        }

        internal static string GetValue(FolderId folderId, bool singleLine)
        {
            string text = string.Empty;

            if (folderId.FolderName.HasValue)
            {
                text = string.Format(System.Globalization.CultureInfo.CurrentCulture, "FolderName: {0}", folderId.FolderName.ToString());
            }
            else
            {
                text = string.Format(System.Globalization.CultureInfo.CurrentCulture, "UniqueId: {0}", folderId.UniqueId);
            }

            if (folderId.ChangeKey != null)
            {
                text = string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0}\nChangeKey: {1}", text, folderId.ChangeKey);
            }

            if (folderId.Mailbox != null)
            {
                text = string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0}\nMailbox {0}: {1}",
                    text,
                    folderId.Mailbox.GetType().FullName,
                    MailboxTypeValue.GetValue(folderId.Mailbox, true));
            }

            if (singleLine)
            {
                return text.Replace("\n", ",");
            }

            return text;
        }
    }
}
