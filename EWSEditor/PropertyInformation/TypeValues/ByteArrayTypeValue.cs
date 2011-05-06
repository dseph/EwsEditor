using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EWSEditor.PropertyInformation.TypeValues
{
    public class ByteArrayTypeValue : ITypeValue
    {
        public Type[] SupportedTypes
        {
            get
            {
                return new Type[] { typeof(Byte[]) };
            }
        }

        public string GetValue(object rawValue)
        {
            return GetValue(rawValue as Byte[], false);
        }

        public string GetValue(object ownerInstance, PropertyInfo propInfo)
        {
            string text = string.Empty;

            Byte[] bytes = propInfo.GetValue(ownerInstance, null) as Byte[];

            return GetValue(bytes, false);
        }

        internal static string GetValue(Byte[] bytes, bool singleOut)
        {
            return Convert.ToBase64String(bytes);
        }
    }
}
