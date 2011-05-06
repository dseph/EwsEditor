using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.PropertyInformation.TypeValues
{
    public class FolderPermissionCollectionTypeValue : ITypeValue
    {
        public Type[] SupportedTypes
        {
            get
            {
                return new Type[] { typeof(FolderPermissionCollection) };
            }
        }

        public string GetValue(object rawValue)
        {
            return GetValue(rawValue as FolderPermissionCollection, false);
        }

        public string GetValue(object ownerInstance, PropertyInfo propInfo)
        {
            FolderPermissionCollection perms = propInfo.GetValue(ownerInstance, null) as FolderPermissionCollection;

            return GetValue(perms, false);
        }

        internal static string GetValue(FolderPermissionCollection perms, bool singleLine)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < perms.Count; i++)
            {
                sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "[{0}] {1}", i, FolderPermissionTypeValue.GetValue(perms[i], true)));
            }

            if (singleLine)
            {
                return sb.ToString().Replace("\n", "");
            }

            return sb.ToString();
        }
    }
}
