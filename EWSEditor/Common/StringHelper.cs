using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EWSEditor.Common
{
    class StringHelper
    {
        //****************************************************************
        // DumpString() Will dump out the string in a Hex Dump.
        //****************************************************************
        public static string DumpString(string sString)
        {
            string sResults = string.Empty;
            char[] CharA = sString.ToCharArray();
            string sChar = " ";
 
            string sLeft = "";
            string sRight = "";
            int iLine = 0;
            sResults = "000000 00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F  0123456789ABCDEF\r\n";
            sResults += "------+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+-----------------\r\n";
            int iChar = 0;
            for (int iCount = 0; iCount < sString.Length; iCount++)
            {
                char x = CharA[iCount];

                iChar = x;
                 

                if (char.IsControl((char)iChar))
                    sChar = " ";
                else
                    sChar = CharA[iCount].ToString();

                

                sLeft += string.Format("{0000:X}", iChar).PadLeft(2, '0') + " ";
                sRight += sChar;
               
                if (iCount % 16 == 15)
                {
                    sResults += String.Format("{0:X}", iLine).PadLeft(6, '0') + " " + sLeft + " " + sRight + "\r\n";
                    sLeft = "";
                    sRight = "";
                    iLine++;
                }
            }
            if (sLeft.Length != 0)
            {
                sResults += String.Format("{0:X}", iLine).PadLeft(6, '0') + " ";
                sResults += sLeft.PadRight(48, ' ') + " " + sRight + "\r\n";
            }
            sResults = sResults.TrimEnd();
            sResults += "\r\n";
            return sResults;
        }

        public static string HexStringFromByteArray(byte[] baArrayToDump)
        {
            string sRet = string.Empty;

    
            StringBuilder oSB = new StringBuilder();

            string sHex = string.Empty;
            int iValue = 0;
            int iItem = 0;

            string sText = string.Empty;

 
            foreach (byte oByte in baArrayToDump)
            {
                iValue = oByte;
                iItem += 1;

                if (char.IsControl((char)iValue))
                {
                    sText += " ";

                }
                else
                {
                    sText += string.Format("{0}", (char)iValue).PadLeft(1, ' ');
                }

 
                oSB.Append(" ");
                sHex = string.Format("{00:X}", iValue).PadLeft(2, '0');
                oSB.Append(sHex);
                 
            }
            sRet = oSB.ToString();
            return sRet;

        }
    }
}
