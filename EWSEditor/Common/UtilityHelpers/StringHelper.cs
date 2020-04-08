using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace EWSEditor.Common
{
    public class StringHelper
    {
        public static  bool IsInteger(string s)
        {
            int xVal = 0;
            return  int.TryParse(s, out xVal);
     
        }
        public static bool IsDouble(string s)
        {
            double xVal = 0;
            return  double.TryParse(s, out xVal);
        }
        public static bool IsShort(string s)
        {
            short xVal = 0;
            return short.TryParse(s, out xVal);
        }


        public static bool IsNumeric(object Expression)
        {
            //http://stackoverflow.com/questions/894263/how-do-i-identify-if-a-string-is-a-number

            double retNum;
            bool isNum = double.TryParse(Convert.ToString(Expression), out retNum); //i now = 10
            //bool isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }

        public static bool IsBase64Encoded(string base64String)
        {
            // /part of the code came from: oybek http://stackoverflow.com/users/794764/oybek
            //string s = base64String.Trim();
            //base64String = base64String.Trim();

            if (base64String == null ||
                base64String.Length == 0 ||
                base64String.Length % 4 != 0 ||
                base64String.Contains(" ") ||
                base64String.Contains("\t") ||
                base64String.Contains("\r") ||
                base64String.Contains("\n"))
                return false;

            // String length should be divisible by 4 with no remainder.

            // https://en.wikipedia.org/wiki/Base64
            // Base64 transfer encoding for MIME manates a '=' pad character. (RFC 2045)
            // Standard 'base64' encoding for RFC 3548 or RFC 4648 - mandated '=' unless another doc says otherwise.
            // In testing of various base64 encoded strings I see that some will not end with an equal sign.
            //if (!base64String.EndsWith("="))
            //    return false;

            try
            {
                Convert.FromBase64String(base64String);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Error: IsBase64Encoded: " + ex.ToString());
                // Handle the exception
            }
            return false;
        }

        //*************************************************************************************
        //GetStringStats() Provides information on the characters which are in a string.
        //*************************************************************************************
        public static string GetStringStats(string sString)
        {
            string sResults = string.Empty;
            char[] CharArr = sString.ToCharArray();

            //int iCharCode = 0;
            int iTotalLines = 0;
            int iTotalCharacters = 0;
            int iCurrentLine = 0;
            int iCurrentLineLength = 0;
            int iLongestLine = 0;
            int iLongestLineChars = 0;
            int iStandardEnglish = 0;
            int iNull = 0;
            int iTab = 0;
            int iCr = 0;
            int iLF = 0;
            int iLowerCaseAlpha = 0;
            int iUpperCaseAlpha = 0;
            int iNumeric = 0;
            int iAbove255 = 0;
            int iAbove127 = 0;
            int iControlCharacters = 0;
            char xChar = ' ';
            long ixChar = 0;
            iTotalCharacters = sString.Length;
            for (int iCount = 0; iCount < sString.Length; iCount++)
            {
                xChar = CharArr[iCount];
                iCurrentLineLength++;
                if (xChar == '\n' || xChar == '\r')
                {
                    if (xChar == '\n')
                    {
                        iCurrentLine++;
                        iTotalLines++;
                    }
                    iCurrentLineLength = 0;
                }
                if (iCurrentLineLength > iLongestLineChars)
                {
                    iLongestLineChars = iCurrentLineLength;
                    iLongestLine = iCurrentLine;
                }
                ixChar = (int)xChar;
                if (xChar >= 'a' && xChar <= 'z') iLowerCaseAlpha++;
                if (xChar >= 'A' && xChar <= 'Z') iUpperCaseAlpha++;
                if (xChar >= '0' && xChar <= '9') iNumeric++;
                if (ixChar > 255) iAbove255++;
                if (ixChar > 127) iAbove127++;
                //if (ixChar <= 31) iControlCharacters++;
                 
                // Control Characters except CR(13) LF (10) and TAB (9)
                if ((ixChar >= 0 && ixChar <= 31) && (ixChar != 10 && ixChar != 13 && ixChar != 9)) iControlCharacters++;
                if (ixChar > 31 & ixChar < 127 || xChar == '\r' || xChar == '\n' || xChar == '\t')
                {
                    iStandardEnglish++;
                }
                if (xChar == '\0') iNull++;
                if (xChar == '\t') iTab++;
                if (xChar == '\r') iCr++;
                if (xChar == '\n') iLF++;
            }
            iLongestLine++;
            sResults += " Total Lines: " + iTotalLines.ToString() + " ";
            sResults += "Total Characters: " + iTotalCharacters.ToString() + " ";
            sResults += "Longest Line is " + iLongestLine.ToString() + " having " + iLongestLineChars.ToString() + " characters\r\n";
            sResults += "\r\n";
            sResults += " Characters:\r\n";
            sResults += string.Format(" {0} In Normal English Range - letters, numbers, symbols and Cr/Lf/Tab (31-126 dec range+ 13/10/9 dec) \r\n", iStandardEnglish.ToString().PadLeft(6, ' '));
            sResults += string.Format(" {0} Tab(09 hex)\r\n", iTab.ToString().PadLeft(6, ' '));
            sResults += string.Format(" {0} Cr (0D hex)\r\n", iCr.ToString().PadLeft(6, ' '));
            sResults += string.Format(" {0} Lf (0A hex)\r\n", iLF.ToString().PadLeft(6, ' '));
            sResults += string.Format(" {0} Control Characters (Range 0-31 dec/0-1F Hex  except for CR, LF and TAB)\r\n", iControlCharacters.ToString().PadLeft(6, ' '));
            sResults += string.Format(" {0} Above 127 dec range\r\n", iAbove255.ToString().PadLeft(6, ' '));
            sResults += string.Format(" {0} Above 255 dec range\r\n", iAbove127.ToString().PadLeft(6, ' '));
            sResults += string.Format(" {0} Null (00 hex)\r\n", iNull.ToString().PadLeft(6, ' '));

            sResults += string.Format(" {0} Lower Case\r\n", iLowerCaseAlpha.ToString().PadLeft(6, ' '));
            sResults += string.Format(" {0} Upper Case\r\n", iUpperCaseAlpha.ToString().PadLeft(6, ' '));
            sResults += string.Format(" {0} Numeric\r\n", iNumeric.ToString().PadLeft(6, ' '));
            sResults += "\r\n";

            return sResults;
        }

        //****************************************************************
        // DeNullString - convert a null string to ""
        //****************************************************************
        public static string DeNullString(string s)
        {
            if (s == null)
                return "";
            else
                return s;
        }

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
            sWork = sFrom.Trim() ;
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



        public static string RemoveControlCodes(string sBody)
        {
            string sReturn = string.Empty;

            StringBuilder oSanitized = new StringBuilder();
            bool bGoodCharacter = true;
            int iVal = 0;

            foreach (char c in sBody)
            {
                bGoodCharacter = true;
                iVal = (int)c;

                //// Extended ascii check
                //if (iVal > 127 & iVal < 256)
                //{
                //    bGoodCharacter = false;
                //}

                //// Non-ASCII and non-Extended ASCII check
                //if (iVal > 255)
                //{
                //    bGoodCharacter = false;
                //}

                // Control character check:
                // Control Characters except CR(13) LF (10) and TAB (9)
                if ((iVal >= 0 && iVal <= 31) && (iVal != 10 && iVal != 13 && iVal != 9))
                {
                    bGoodCharacter = false;
                }

                if (bGoodCharacter == true)
                    oSanitized.Append(c);
            }

            sReturn = oSanitized.ToString();

            return sReturn;
        }


        public static string RemoveNonAsciiAndControlCharacters(string sBody)
        {
            string sReturn = string.Empty;

            StringBuilder oSanitized = new StringBuilder();
            bool bGoodCharacter = true;
            int iVal = 0;

            foreach (char c in sBody)
            {
                bGoodCharacter = true;
                iVal = (int)c;

                // Extended ascii check
                if (iVal > 127 & iVal < 256)
                {
                    bGoodCharacter = false;
                }

                // Non-ASCII and non-Extended ASCII check
                if (iVal > 255)
                {
                    bGoodCharacter = false;
                }

                // Control character check:
                // Control Characters except CR(13) LF (10) and TAB (9)
                if ((iVal >= 0 && iVal <= 31) && (iVal != 10 && iVal != 13 && iVal != 9))
                {
                    bGoodCharacter = false;
                }

                if (bGoodCharacter == true)
                    oSanitized.Append(c);
            }

            sReturn = oSanitized.ToString();

            return sReturn;
        }


        public static string RemoveNonExtendedAsciiAndControlCharacters(string sBody)
        {
            string sReturn = string.Empty;

            StringBuilder oSanitized = new StringBuilder();
            bool bGoodCharacter = true;
            int iVal = 0;

            foreach (char c in sBody)
            {
                bGoodCharacter = true;
                iVal = (int)c;

                //// Extended ascii check
                //if (iVal > 127 & iVal < 256)
                //{
                //    bGoodCharacter = false;
                //}

                // Non-ASCII and non-Extended ASCII check
                if (iVal > 255)
                {
                    bGoodCharacter = false;
                }

                // Control character check:
                // Control Characters except CR(13) LF (10) and TAB (9)
                if ((iVal >= 0 && iVal <= 31) && (iVal != 10 && iVal != 13 && iVal != 9))
                {
                    bGoodCharacter = false;
                }

                if (bGoodCharacter == true)
                    oSanitized.Append(c);
            }

            sReturn = oSanitized.ToString();

            return sReturn;
        }


        public static string CheckResponseForOddCharacters(string sBody)
        {
            StringBuilder oSB = new StringBuilder();

            bool bResponseHasUnicode = false;
            bool bResponseHasExtendedAsciiCharacters = false;
            bool bResponseHasControlCharacters = false;
            bool bResponseHasOddCharacters = false;
            string sReponseCheck = string.Empty;


            int iVal = 0;
            string sComment = string.Empty;
            StringBuilder oCharCheck = new StringBuilder();

            oCharCheck.AppendFormat("\r\nDumping characters...\r\n");
            oCharCheck.AppendFormat("Value   Char  Comment\r\n");
            StringBuilder oSanitized = new StringBuilder();
            foreach (char c in sBody)
            {
                sComment = string.Empty;
                iVal = (int)c;
                if (iVal > 127 & iVal < 256)
                {
                    sComment = "Over 127 ********** ********** **********";
                    bResponseHasOddCharacters = true;
                    bResponseHasExtendedAsciiCharacters = true;
                }
                if (iVal > 255)
                {
                    sComment = "Over 255 ********** ********** **********";
                    bResponseHasOddCharacters = true;
                    bResponseHasUnicode = true;
                }
                // Control character check:
                // Control Characters except CR(13) LF (10) and TAB (9)
                if ((iVal >= 0 && iVal <= 31) && (iVal != 10 && iVal != 13 && iVal != 9))
                {
                    sComment = "Control Character ********** ********** **********";
                    bResponseHasControlCharacters = true;
                    bResponseHasOddCharacters = true;
                }

                if (bResponseHasOddCharacters == false)
                    oSanitized.Append(c);

                oCharCheck.AppendFormat("[{0}] - {1}  {2} \r\n", (int)c, c, sComment);
            }


            if (bResponseHasOddCharacters == true)
            {
                oSB.AppendLine("***");
                if (bResponseHasControlCharacters == true)
                    oSB.AppendLine("***  Control Characters found.  ********** ********** **********");
                if (bResponseHasUnicode == true)
                    oSB.AppendLine("***  Unicode characters found.  ********** ********** **********");
                if (bResponseHasExtendedAsciiCharacters == true)
                    oSB.AppendLine("***  Extended ASCII characters found.  ********** ********** **********");
                oSB.AppendLine("***");
                oSB.Append(oCharCheck.ToString());  // Character by character check

                oSB.Append("\r\nThe following is a version of the source text without extended ascii/unicode/control characters:\r\n");
                oSB.Append(oSanitized.ToString());

                //MessageBox.Show("The are non-basic ASCII characters found.");
            }
            else
            {
                oSB.AppendLine("No non-ASCII or control characters found.");
                oSB.AppendLine("");
            }

            oSB.Append(oSanitized.ToString());

            return oSB.ToString();
        }

        public static string UnicodeStringToHexString(string str)
        {

            // from:  https://stackoverflow.com/questions/16999604/convert-string-to-hex-string-in-c-sharp

            var sb = new StringBuilder();

            var bytes = Encoding.Unicode.GetBytes(str);
            foreach (var t in bytes)
            {
                sb.Append(t.ToString("X2"));
            }

            return sb.ToString(); // returns: "48656C6C6F20776F726C64" for "Hello world"
        }

        public static string  HexStringToUnicodeString(string hexString)
        {
            // from:  https://stackoverflow.com/questions/16999604/convert-string-to-hex-string-in-c-sharp
            var bytes = new byte[hexString.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return Encoding.Unicode.GetString(bytes); // returns: "Hello world" for "48656C6C6F20776F726C64"
        }



        // Note: Helping calls:
        //
        //string sItem = Enum.GetName(typeof(DayOfTheWeek), DayOfTheWeek.Monday); // String for name
        //string = Enum.GetName(typeof(DayOfTheWeek), 3));  // Third Instnace name of enumeration
        //oDayOfTheWeek = (DayOfTheWeek)Enum.Parse(typeof(DayOfTheWeek), "Monday"); // Convert from string to enumerated value



    }
}
