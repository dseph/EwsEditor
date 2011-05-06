using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.PropertyInformation.TypeValues
{
    public class FolderPermissionTypeValue : ITypeValue
    {
        public Type[] SupportedTypes
        {
            get
            {
                return new Type[] { typeof(FolderPermission) };
            }
        }

        public string GetValue(object rawValue)
        {
            return GetValue(rawValue as FolderPermission, false);
        }

        public string GetValue(object ownerInstance, PropertyInfo propInfo)
        {
            FolderPermission perm = propInfo.GetValue(ownerInstance, null) as FolderPermission;

            return GetValue(perm, false);
        }

        internal static string GetValue(FolderPermission perm, bool singleLine)
        {
            StringBuilder sb = new StringBuilder();

            if (perm.UserId.StandardUser.HasValue)
            {
                sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "UserId: {0}", perm.UserId.StandardUser.Value.ToString()));
            }
            else
            {
                sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "UserId: {0}, {1}, {2}", perm.UserId.DisplayName, perm.UserId.PrimarySmtpAddress, perm.UserId.SID));
            }

            sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "Display Permission Level: {0}", perm.DisplayPermissionLevel.ToString()));
            sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "Permission Level: {0}", perm.PermissionLevel.ToString()));
            sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "CanCreateItems: {0}", perm.CanCreateItems.ToString()));
            sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "CanCreateSubFolders: {0}", perm.CanCreateSubFolders.ToString()));
            sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "DeleteItems: {0}", perm.DeleteItems.ToString()));
            sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "EditItems: {0}", perm.EditItems.ToString()));
            sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "IsFolderContact: {0}", perm.IsFolderContact.ToString()));
            sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "IsFolderOwner: {0}", perm.IsFolderOwner.ToString()));
            sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "IsFolderVisible: {0}", perm.IsFolderVisible.ToString()));
            sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "ReadItems: {0}", perm.ReadItems.ToString()));

            if (singleLine)
            {
                return sb.ToString().Replace("\n", " ");
            }

            return sb.ToString();
        }
    }
}
