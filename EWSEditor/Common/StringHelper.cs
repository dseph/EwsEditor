using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

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


 

        public static string HexStringFromByteArray(byte[] baArrayToDump, bool bSpaceDelimit)
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

                // Clean junk charaters...
                if (char.IsControl((char)iValue))
                {
                    sText += " ";

                }
                else
                {
                    sText += string.Format("{0}", (char)iValue).PadLeft(1, ' ');
                }


                if (bSpaceDelimit)
                    oSB.Append(" ");

                sHex = string.Format("{00:X}", iValue).PadLeft(2, '0');
                oSB.Append(sHex);
                 
            }
            sRet = oSB.ToString();
            return sRet;

        }

    public static bool HexDumpFromFile(string sFile, ref string sDump)
        {
            bool bRet = false;

            int iItemsPerLine = 16;

            StringBuilder oSB = new StringBuilder();
            BinaryReader b = null;
            string sHex = string.Empty;
            int iValue = 0;
            int iItem = 0;
            int iReadSize = sizeof(byte);
            string sText = string.Empty;

            string sHeader1 = "       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F  0123456789ABCDEF\r\n";
            string sHeader2 = "------+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+-----------------\r\n";


            string path = sFile.Trim();
            if (File.Exists(path))
            {

                try
                {
                    oSB.Append(sHeader1);
                    oSB.Append(sHeader2);

                    b = new BinaryReader(File.Open(path, FileMode.Open));


                    int pos = 0;

                    int length = (int)b.BaseStream.Length;
                    while (pos < length)
                    {
                        //iValue = b.ReadInt32();
                        //iValue = b.ReadChar();
                        iValue = b.ReadByte();
                        iItem += 1;

                        if (char.IsControl((char)iValue))
                        {
                            sText += " ";

                        }
                        else
                        {
                            sText += string.Format("{0}", (char)iValue).PadLeft(1, ' ');
                        }

                        // Start of Line - Add position
                        if (iItem == 1)
                        {
                            oSB.Append(string.Format("{0000:X}", pos).PadLeft(4, '0'));
                            oSB.Append("  ");
                        }

                        if (iItem <= iItemsPerLine)
                        {
                            oSB.Append(" ");
                            sHex = string.Format("{00:X}", iValue).PadLeft(2, '0');
                            oSB.Append(sHex);

                            // Text Representation of hex bits.
                            if (iItem == iItemsPerLine)
                            {

                                oSB.Append("  " + sText); // Add text representation of hex.
                                sText = string.Empty;
                                sHex = string.Format("\r\n");
                                oSB.Append(sHex);

                                sHex = string.Empty;
                                iItem = 0;
                            }
                        }

                        if (iItem > 0 && iItem != iItemsPerLine)
                        {
                            int iPadLength = (3 * (16 - iItem)) + 2;
                            string sPadding = String.Format("{0:X}", "").PadLeft(iPadLength, ' ');
                            oSB.Append(sPadding);
                            oSB.Append(sText); // Add text representation of hex.
                            oSB.Append("\r\n");
                            pos++;
                        }


                        pos += iReadSize;  // Point to next.
                    }

                    b.Close();
                    b = null;
                    sDump = oSB.ToString();
                    bRet = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Error Reading File");
                    bRet = false;
                }



            }

            return bRet;

        }

        public static string HexDumpFromByteArray(byte[] baArrayToDump)
        {
            string sRet = string.Empty;

            int iItemsPerLine = 16;

            StringBuilder oSB = new StringBuilder();

            string sHex = string.Empty;
            int iValue = 0;
            int iItem = 0;

            string sText = string.Empty;

            string sHeader1 = "       00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F  0123456789ABCDEF\r\n";
            string sHeader2 = "------+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+--+-----------------\r\n";


            oSB.Append(sHeader1);
            oSB.Append(sHeader2);
            int pos = 0;
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

                // Start of Line - Add position
                if (iItem == 1)
                {
                    oSB.Append(string.Format("{0000:X}", pos).PadLeft(4, '0'));
                    oSB.Append("  ");
                }

                if (iItem <= iItemsPerLine)
                {
                    oSB.Append(" ");
                    sHex = string.Format("{00:X}", iValue).PadLeft(2, '0');
                    oSB.Append(sHex);

                    // Text Representation of hex bits.
                    if (iItem == iItemsPerLine)
                    {

                        oSB.Append("  " + sText); // Add text representation of hex.
                        sText = string.Empty;
                        sHex = string.Format("\r\n");
                        oSB.Append(sHex);

                        sHex = string.Empty;
                        iItem = 0;
                    }

                }
            }

            if (iItem > 0 && iItem != iItemsPerLine)
            {
                int iPadLength = (3 * (16 - iItem)) + 2;
                string sPadding = String.Format("{0:X}", "").PadLeft(iPadLength, ' ');
                oSB.Append(sPadding);
                oSB.Append(sText); // Add text representation of hex.
                oSB.Append("\r\n");  
                pos++;
            }
            sRet = oSB.ToString();
            return sRet;

        }

        public static string HexDumpFromRoughHexString(string sHex, ref byte[] ByteData, ref string sError)
        {
            bool bRet = false;
            string sResult = string.Empty;

            bRet = RoughHexStringToByteArray(sHex, ref ByteData, ref sError);
            if (bRet == true)
                sResult = HexDumpFromByteArray(ByteData);

            return sResult;
        }

        public static bool CleanHexString(string sFrom, ref string sCleanString, ref string sErrors)
        {
            string sWork = string.Empty;
            sWork = sFrom;
            string sHexStingErrors = string.Empty;
            bool bContinue = true;
            string sReturn = string.Empty;
            bool bRet = false;

            // weed out junk
            var sb = new StringBuilder(sWork.Length);
            foreach (char i in sWork)
                if (i != '\n' && i != '\r' && i != '\t' && i != '\r' && i != '[' && i != ']' && i != ';')
                    sb.Append(i);
            sWork = sb.ToString();
            sWork = sWork.Replace("    ", " ");
            sWork = sWork.Replace("    ", " ");
            sWork = sWork.Replace("   ", " ");
            sWork = sWork.Replace("  ", " ");
            sWork = sWork.Replace(" ", ",");

            sb = new StringBuilder();
            string[] sItems = sWork.Split(',').Select(sValue => sValue.Trim()).ToArray();

            string sHex = string.Empty;
            int iCount = 1;
            int iTest = 0;
            bool bTest = false;
            bool bError = false;

            foreach (string sNum in sItems)
            {
                sHex = sNum.Trim();

                if (bContinue == true)
                {
                    if (sHex == "")  // this would be encountered if the hex values did not fill a full line.
                    {
                        bContinue = false;
                    }
                }

                if (bContinue == true)
                {
                    if (sHex.Length > 2)
                    {
                        sHexStingErrors += string.Format("Hex digit'{0}' in position '{1} is more than 2 characters and has been replaced with 'XX'", sHex, sb.Length);
                        sHex = "XX";
                        bContinue = false;
                        bError = true;
                    }
                }

                if (bContinue == true)
                {
                    if (sHex.Length < 2)
                    {
                        sHexStingErrors += string.Format("Hex digit'{0}' in position '{1} is less than 2 characters and has been replaced with 'XX'", sHex, sb.Length);
                        sHex = "XX";
                        bContinue = false;
                        bError = true;
                    }
                }

                if (bContinue == true)
                {
                    bTest = Int32.TryParse(sHex, System.Globalization.NumberStyles.HexNumber, null, out iTest);
                    if (bTest == false)
                    {
                        sHexStingErrors += string.Format("Hex digit'{0}' in position '{1} is not hex 'XX'", sHex, sb.Length);
                        sHex = "XX";
                        bContinue = false;
                        bError = true;
                    }
                }

                sb.Append(sHex);
                iCount++;

                if (bContinue == false)
                    break;
            }

            // With a clean string of hex values the rest of of the conversions can be done.
            sCleanString = sb.ToString();
            sErrors = sHexStingErrors;

            if (bError == false)
                bRet = true;
            else
                bRet = false; ;

            return bRet;

        }

        public static  bool RoughHexStringToByteArray(string sHex, ref byte[] ByteData, ref string sError)
        {
            StringBuilder sb = null;
            bool bContinue = true;
            string sConversionErrors = string.Empty;
            string sToDump = string.Empty;
            string sEASDecoded = string.Empty;
            bool bRet = false;
            byte[] oBytes = null;

            // Convert to two byte hex values with space delimiter.
            string sHexStrings = sHex;
            sb = new StringBuilder();
            int iCount = 0;
            foreach (char a in sHexStrings)
            {
                if ((a >= 'a' && a <= 'f') ||
                    (a >= 'A' && a <= 'F') ||
                    (a >= '0' && a <= '9'))
                {
                    sb.Append(a);
                    iCount += 1;
                    if (iCount == 2)
                    {
                        sb.Append(' ');
                        iCount = 0;
                    }

                }
                else
                {
               
                    sConversionErrors += string.Format("Byte '{0}' at position {1} is not a hex digit.\r\n", a, iCount);
                    iCount += 1;
                    bContinue = false;
                }

            }


            if (bContinue == true)
            {

                sHexStrings = sb.ToString().TrimEnd();
                 

                string[] hexValuesSplit = sHexStrings.Split(' ');
                oBytes = new byte[hexValuesSplit.Length];
                int iCountBytes = 0;
                foreach (String hex in hexValuesSplit)
                {
                    if (hex.Length != 2)
                    {
                        sConversionErrors += string.Format("Byte pair '{0}' does not have two byte values.\r\n", hex);
                        bContinue = false;
                        break;
                    }
                    else
                        oBytes[iCountBytes] = Convert.ToByte(hex, 16);

                    iCountBytes++;
                }

                bRet = bContinue;

                 HexDumpFromByteArray(oBytes);

               
            }

            ByteData = oBytes;

            sError = sConversionErrors;
            return bRet;
        }
 


        // Note: Helping calls:
        //
        //string sItem = Enum.GetName(typeof(DayOfTheWeek), DayOfTheWeek.Monday); // String for name
        //string = Enum.GetName(typeof(DayOfTheWeek), 3));  // Third Instnace name of enumeration
        //oDayOfTheWeek = (DayOfTheWeek)Enum.Parse(typeof(DayOfTheWeek), "Monday"); // Convert from string to enumerated value


 
    }
}
