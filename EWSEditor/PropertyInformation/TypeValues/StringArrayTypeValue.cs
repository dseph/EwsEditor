using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EWSEditor.PropertyInformation.TypeValues
{
    public class StringArrayTypeValue : ITypeValue
    {
        public Type[] SupportedTypes
        {
            get
            {
                return new Type[] { typeof(string[]) };
            }
        }

        public string GetValue(object rawValue)
        {
            return GetValue(rawValue as string[], false);
        }

        public string GetValue(object ownerInstance, PropertyInfo propInfo)
        {
            string text = string.Empty;

            string[] strings = propInfo.GetValue(ownerInstance, null) as string[];

            return GetValue(strings, false);
        }

        internal static string GetValue(string[] strings, bool singleOut)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("Length: {0}", strings.Length));
            int i = 0;
            foreach(string s in strings)
            {
                sb.AppendLine(string.Format("[{0}] {1}", i.ToString(), s));
                i++;
            }

            return sb.ToString();
        }
    }
}