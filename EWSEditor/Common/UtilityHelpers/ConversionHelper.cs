using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EWSEditor.Common
{
    public class ConversionHelper
    {
        private ConversionHelper()
        {
        }

        public static string GetBase16(int num)
        {
            return Convert.ToString(num, 16);
        }

        public static int GetIntFromBase16String(string base16num)
        {
            if (base16num.Trim().StartsWith("0x"))
            {
                return Convert.ToInt32(base16num.Trim().Remove(0, 2), 16);
            }
            else
            {
                // Should we throw here or is it okay to deal with every string as long as it is a number?
                throw new ArgumentException("Base16 number must start with '0x'.");
            }
        }

        public static string GetStringFromBytes(byte[] bytes)
        {
            StringBuilder ret = new StringBuilder();
            foreach (byte b in bytes)
            {
                ret.Append(Convert.ToString(b, 16).PadLeft(2,'0'));
            }

            return ret.ToString();
        }


        public static Byte[] HexStringToByteArray(String HexString)
        {
            // http://gsexdev.blogspot.com/2011/03/using-prfolderpath-property-in-exchange.html#!/2011/03/using-prfolderpath-property-in-exchange.html

            Byte[] ByteArray = new Byte[HexString.Length / 2];
            for (int i = 0; i < HexString.Length; i += 2)
            {
                ByteArray[i / 2] = Convert.ToByte(HexString.Substring(i, 2), 16);
            }
            return ByteArray;
        }
    }
}
