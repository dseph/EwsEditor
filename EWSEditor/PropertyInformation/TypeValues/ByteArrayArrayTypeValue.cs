using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EWSEditor.PropertyInformation.TypeValues
{
    public class ByteArrayArrayTypeValue : ITypeValue
    {
        public Type[] SupportedTypes
        {
            get
            {
                return new Type[] { typeof(Byte[][]) };
            }
        }

        public string GetValue(object rawValue)
        {
            return GetValue(rawValue as Byte[][], false);
        }

        public string GetValue(object ownerInstance, PropertyInfo propInfo)
        {
            string text = string.Empty;

            Byte[][] bytes = propInfo.GetValue(ownerInstance, null) as Byte[][];

            return GetValue(bytes, false);
        }

        internal static string GetValue(Byte[][] bytesbytes, bool singleOut)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "Length: {0}", bytesbytes.Length));
            int i = 0;
            foreach (Byte[] bytes in bytesbytes)
            {
                sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "[{0}] {1}", i, ByteArrayTypeValue.GetValue(bytes, true)));
                i++;
            }

            return sb.ToString();
        }
    }
}
