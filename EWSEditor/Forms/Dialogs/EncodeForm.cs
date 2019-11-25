using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.Xml;
using EWSEditor.Common;
using System.Text.RegularExpressions;
using System.IO;

namespace EWSEditor.Forms
{
    public partial class EncodeForm : Form
    {
        public EncodeForm()
        {
            InitializeComponent();
        }

         

        private const string UrlEncode = "Url Encode";
        private const string UrlDecode = "Url Decode";
        private const string UrlEncodeUnicode = "Url Encode Unicode";
        private const string UrlDecodeUnicode = "Url Decode Unicode";

        private const string HtmlEncode = "Html Encode";
        private const string HtmlDecode = "Html Decode";
        private const string Base64Encode = "Base 64 Encode";
        private const string Base64Decode = "Base 64 Decode";
 
        private const string XmlEncode = "Xml Encode";
        private const string XmlDecode = "Xml Decode";
        private const string XmlBeautify = "Beautify XML";

        //private const string Utf8Encode = "Utf8 Encode";
        //private const string Utf8Decode = "Utf8 Decode";

        //private const string QuotedPrintableDecode = "Quoted Printable Decode";

        private const string XmlBase64ToHex = "Base 64 to Hex";
        private const string XmlBase64ToHexSpaceDelimited = "Base 64 to Hex - Space delimited";
        private const string XmlHexToBase64 = "Hex to Base 64";

        private const string XmlHexToText = "Hex to text string";
        private const string XmlHexToCleanHexText = "Clean Hex text so that its only has hex characters";
        private const string XmlTextToHex = "Text to Hex string";
        private const string XmlTextToHexSpaceDelimited = "Text to space delimited Hex string";
        private const string XmlHexDumpText = "Text to Hex Dump";
        private const string XmlBase64ToHexDump = "Decode Base 64 content and Hex dump";

        private const string XmlConvertVerifyXmlChars = "XmlConvert - VerifyXmlChars";

        private const string UnicodeStringToHexString = "Unicode String to Hex String";
        private const string HexStringToUnicodeString = "Hex String to Unicode String";

        private const string StringStatistics = "Information about text"; 
        private const string CheckForNonASCIICharacters = "Check for non-ASCII characters and control codes (Except CR, LF and TAB)";
        private const string sRemoveControlCodes = "Remove control codes (Except CR, LF and TAB)";
        private const string sRemoveNonAsciiAndControlCharacters = "Remove non-ASCII and control codes (Except CR, LF and TAB)";
        private const string sRemoveNonExtendedAsciiAndControlCharacters = "Remove non-Extended ASCII and control codes (Except CR, LF and TAB)";
 
 
        private void EncodeForm_Load(object sender, EventArgs e)
        { 
        cmboFrom.Items.Clear();
 
        cmboFrom.Items.Add(UrlEncode);
        cmboFrom.Items.Add(UrlDecode);
        cmboFrom.Items.Add(UrlEncodeUnicode);
 
        cmboFrom.Items.Add(HtmlEncode);
        cmboFrom.Items.Add(HtmlDecode);
        cmboFrom.Items.Add(Base64Encode);
        cmboFrom.Items.Add(Base64Decode);
 
        cmboFrom.Items.Add(XmlEncode);
        cmboFrom.Items.Add(XmlDecode);
        cmboFrom.Items.Add(XmlBeautify);

             

        //cmboFrom.Items.Add(Utf8Encode);
        //cmboFrom.Items.Add(Utf8Decode);
        //cmboFrom.Items.Add(QuotedPrintableDecode);
        

        cmboFrom.Items.Add(XmlBase64ToHex);
        cmboFrom.Items.Add(XmlBase64ToHexSpaceDelimited);
        cmboFrom.Items.Add(XmlHexToBase64);

        cmboFrom.Items.Add(XmlHexToText);
        cmboFrom.Items.Add(XmlHexToCleanHexText);
        cmboFrom.Items.Add(XmlTextToHex);
        cmboFrom.Items.Add(XmlTextToHexSpaceDelimited);
        cmboFrom.Items.Add(XmlHexDumpText);
        cmboFrom.Items.Add(XmlBase64ToHexDump);

        cmboFrom.Items.Add(UnicodeStringToHexString);
        cmboFrom.Items.Add(HexStringToUnicodeString);

        cmboFrom.Items.Add(StringStatistics);
        cmboFrom.Items.Add(CheckForNonASCIICharacters);
        cmboFrom.Items.Add(sRemoveControlCodes);
        cmboFrom.Items.Add(sRemoveNonAsciiAndControlCharacters);
        cmboFrom.Items.Add(sRemoveNonExtendedAsciiAndControlCharacters);

        //cmboFrom.Items.Add(XmlConvertVerifyXmlChars);


        cmboFrom.SelectedIndex = 0;
 
 
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            txtTo.Text = ConvertString(txtFrom.Text, cmboFrom.Text);
            //webBrowser1.DocumentText = ConvertString(txtFrom.Text, cmboFrom.Text);
        }

        private string ConvertString(string sFrom, string TypeOfConversion)
        {
            string FromText = txtFrom.Text;
            string ToText = string.Empty;
            byte[] oFromBytes = null;
            //byte[] oToBytes = null;
            
            //byte[] ToBytes;
            System.Text.Encoding oUtf8Encoding = System.Text.Encoding.UTF8;
            System.Text.Encoding oAsciiEncoding = System.Text.Encoding.ASCII;

            string sError = string.Empty;

            switch (TypeOfConversion)
            {
                case UrlEncode:
                    ToText = System.Web.HttpUtility.UrlEncode(FromText);
                    break;
                case UrlDecode:
                    ToText = System.Web.HttpUtility.UrlDecode(FromText);
                    break;
                case UrlEncodeUnicode:
                     
                    ToText = System.Web.HttpUtility.UrlEncode(FromText);
                    //ToText = System.Web.HttpUtility.UrlEncodeUnicode(FromText);
                    break;
                

                case HtmlEncode:
                    try
                    {
                        ToText = System.Web.HttpUtility.HtmlEncode(FromText); 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error");
                    }
                    break;
                case HtmlDecode:
                 
                    try
                    {
                        ToText = System.Web.HttpUtility.HtmlDecode(FromText);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error");
                    }
                    break;

                case Base64Encode:
                    try
                    {
                        oFromBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(FromText);
                        ToText = System.Convert.ToBase64String(oFromBytes);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error");
                    }
                    break;

                case Base64Decode:
                    try
                    {
                        oFromBytes = System.Convert.FromBase64String(FromText);
                        ToText = System.Text.ASCIIEncoding.ASCII.GetString(oFromBytes);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error");
                    }
                    break;

                //case Utf8Encode:
                //    try
                //    {
                //        oFromBytes = System.Text.Encoding.Default.GetBytes(FromText);
                //        ToText = System.Text.Encoding.UTF8.GetString(oFromBytes);

                //        ToText += "\r\n";
                //        Console.WriteLine("Encoded bytes:");
                //        foreach (Byte b in oFromBytes)
                //        {
                //            ToText += string.Format("[{0}]", b);

                //        }

    
                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show(ex.ToString(), "Error");
                //    }
                //    break;
                //case Utf8Decode:
                //    try
                //    {
                //        oFromBytes = oUtf8Encoding.GetBytes(FromText);
                //        ToText = oUtf8Encoding.GetString(oFromBytes);

                //        //oFromBytes = oUtf8Encoding.GetBytes(FromText);
                //        //oToBytes = Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding("iso-8859-1"), oFromBytes);
                //        //ToText = System.Text.Encoding.UTF8.GetString(oToBytes);

  
                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show(ex.ToString(), "Error");
                //    }
                //    break;

                case XmlEncode:
                    try
                    {
                        
                        
                        XmlDocument oXmlDocument = new XmlDocument();
                        XmlElement oXmlElement = oXmlDocument.CreateElement("SomeElement");
                        oXmlElement.InnerText = FromText;
                        ToText = oXmlElement.InnerXml;
                        oXmlElement = null;
                        oXmlDocument = null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error");
                    }
                    break;

 
                
                //case XmlEscape:
                //    try
                //    {
                //        ToText = System.Security.SecurityElement.Escape(FromText);
 
                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show(ex.ToString(), "Error");
                //    }
                //    break;

                //case QuotedPrintableDecode:
                //    // http://stackoverflow.com/questions/2226554/c-class-for-decoding-quoted-printable-encoding
                //    try
                //    {
                //        //string sWork = FromText;
                //        //var occurences = new Regex(@"=[0-9A-Z]{2}", RegexOptions.Multiline);
                //        //var matches = occurences.Matches(sWork);
                //        //foreach (Match match in matches)
                //        //{
                //        //    char hexChar= (char) Convert.ToInt32(match.Groups[0].Value.Substring(1), 16);
                //        //    sWork = sWork.Replace(match.Groups[0].Value, hexChar.ToString());
                //        //}
                //        //ToText =  sWork.Replace("=\r\n", "");
 
                //        ToText = DecodeQuotedPrintables(FromText, "iso-8859-1");
                 
                //    }
                //    catch (Exception ex)
                //    {
                //        MessageBox.Show(ex.ToString(), "Error");
                //    }
                //    break;


                case XmlDecode:
                    try
                    {
                        //ToText = XmlConvert.DecodeName(FromText);

                        XmlDocument oXmlDocument = new XmlDocument();
                        XmlElement oXmlElement = oXmlDocument.CreateElement("SomeElement");
                        oXmlElement.InnerXml = FromText;
                        ToText = oXmlElement.InnerText;
                        oXmlElement = null;
                        oXmlDocument = null;

 
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error");
                    }
                    break;

                case XmlBeautify:
                    try
                    {
 
                        ToText = "";

                        XmlDocument oXmlDocument = new XmlDocument();
                        oXmlDocument.InnerXml = FromText;
 
                        try
                        {
                            StringBuilder sb = new StringBuilder();
                            XmlWriterSettings settings = new XmlWriterSettings
                            {
                                Indent = true,
                                IndentChars = "  ",
                                NewLineChars = "\r\n",
                                NewLineHandling = NewLineHandling.Replace,
                                CheckCharacters = false
                            };
                            using (XmlWriter writer = XmlWriter.Create(sb, settings))
                            {
                                oXmlDocument.Save(writer);
                                ToText = sb.ToString();
                                oXmlDocument = null;
                                settings = null;
                            }
                        }
                        catch (System.Xml.XmlException XmlEx)
                        {
                            MessageBox.Show(XmlEx.ToString(), "Error");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Error");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error");
                    }
                    break;

                case XmlBase64ToHex:
                    try
                    {
                        oFromBytes = System.Convert.FromBase64String(FromText);  // Convert to Bytes first.

                        ToText = StringHelper.HexStringFromByteArray(oFromBytes, false);  // Now convert it to a hex string.
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error");
                    }
                    break;

                case XmlBase64ToHexSpaceDelimited:
                    try
                    {
                        oFromBytes = System.Convert.FromBase64String(FromText);  // Convert to Bytes first.

                        ToText = StringHelper.HexStringFromByteArray(oFromBytes, true);  // Now convert it to a hex string.
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error");
                    }
                    break;

                case XmlTextToHex:
 
                    try
                    {
                        System.Text.ASCIIEncoding oEncoding = new System.Text.ASCIIEncoding();
                        oFromBytes = oEncoding.GetBytes(sFrom);
                        ToText = StringHelper.HexStringFromByteArray(oFromBytes, false);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error");
                    }
                    break;
                case XmlTextToHexSpaceDelimited:
                    try
                    {
                        System.Text.ASCIIEncoding oEncoding = new System.Text.ASCIIEncoding();
                        oFromBytes = oEncoding.GetBytes(sFrom);
                        ToText = StringHelper.HexStringFromByteArray(oFromBytes, true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error");
                    }
                    break;

                case XmlHexToCleanHexText:

                    try
                    {
                        if (StringHelper.CleanHexString(FromText, ref ToText, ref sError) == false)
                        {   
                            ToText = sError;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error");
                    }
                    break;

                case XmlHexToText:

                    try
                    {
                        if (StringHelper.RoughHexStringToByteArray(FromText, ref oFromBytes, ref sError) == true)
                        {
                            ToText = System.Text.Encoding.ASCII.GetString(oFromBytes);
              
                        }
                        else
                        {
                            ToText = sError;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error");
                    }
                    break;

                case XmlHexToBase64:
                    
                    try
                    {
                        if (StringHelper.RoughHexStringToByteArray(FromText, ref oFromBytes, ref sError) == true)
                        {  
                            //oFromBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(FromText);  // First Turn hex string into an byte array.
                            ToText = System.Convert.ToBase64String(oFromBytes);  // Now convert to a Base64 string.
                        }
                        else
                        {
                            ToText = sError;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error");
                    }
                    break;
 

                case XmlHexDumpText:
                    try
                    {

                        ToText = StringHelper.DumpString(FromText);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error");
                    }
                    break;

                case XmlBase64ToHexDump:
                    try
                    {
                        oFromBytes = System.Convert.FromBase64String(FromText);  // Convert to Bytes first.
                        ToText = StringHelper.HexDumpFromByteArray(oFromBytes);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error");
                    }
                    break;

                case XmlConvertVerifyXmlChars:

                    try
                    {

                        ToText = XmlConvert.VerifyXmlChars(FromText);
                        if (ToText != null)
                            MessageBox.Show("Xml characters verfied.");
                    }
                    catch (XmlException XmlExx)
                    {
                        MessageBox.Show(XmlExx.ToString(), "Error");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error");
                    }
                    break;

                case UnicodeStringToHexString:

                    try
                    {
                        ToText = StringHelper.UnicodeStringToHexString(FromText);

                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.ToString(), "Error");
                    }
                    break;

                case HexStringToUnicodeString:

                    try
                    {
                        ToText = StringHelper.HexStringToUnicodeString(FromText);

                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.ToString(), "Error");
                    }
                    break;

                case StringStatistics:

                    try
                    {
                        ToText = StringHelper.GetStringStats(FromText);

                    }
                    catch (XmlException XmlExx)
                    {
                        MessageBox.Show(XmlExx.ToString(), "Error");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error");
                    }
                    break;


                case CheckForNonASCIICharacters:
                    try
                    {

                        ToText = StringHelper.CheckResponseForOddCharacters(FromText);

                    }
                    catch (Exception exCheckForInvalidCharacters)
                    {
                        MessageBox.Show(exCheckForInvalidCharacters.ToString(), "Error");
                    }
                    break;

                case sRemoveControlCodes:
                    try
                    {
                        ToText = StringHelper.RemoveControlCodes(FromText);
                    }
                    catch (Exception exRemoveControlCodes)
                    {
                        MessageBox.Show(exRemoveControlCodes.ToString(), "Error");
                    }
                    break;

   
                case sRemoveNonAsciiAndControlCharacters:
                    try
                    {
                        ToText = StringHelper.RemoveNonAsciiAndControlCharacters(FromText);
                    }
                    catch (Exception exRemoveNonAsciiAndControlCharacters)
                    {
                        MessageBox.Show(exRemoveNonAsciiAndControlCharacters.ToString(), "Error");
                    }
                    break;

                case sRemoveNonExtendedAsciiAndControlCharacters:
                    try
                    {
                        ToText = StringHelper.RemoveNonExtendedAsciiAndControlCharacters(FromText);
                    }
                    catch (Exception exRemoveNonExtendedAsciiAndControlCharacters)
                    {
                        MessageBox.Show(exRemoveNonExtendedAsciiAndControlCharacters.ToString(), "Error");
                    }
                    break;

                //case Utf8DecodeToAscii:
                //    oUtf8Encoding = System.Text.Encoding.UTF8;
                //    oFromBytes = oUtf8Encoding.GetBytes(FromText);
                //    ToBytes = Encoding.Convert(Encoding.UTF8, Encoding.UTF8, oFromBytes);
                //    ToText =  System.Text.Encoding.ASCII.GetString(ToBytes);
                //    break;

                //case Utf32DecodeToAscii:
                //    oUtf8Encoding = System.Text.Encoding.UTF8;
                //    oFromBytes = oUtf8Encoding.GetBytes(FromText);
                //    ToBytes = Encoding.Convert(Encoding.UTF32, Encoding.UTF32, oFromBytes);
                //    ToText = System.Text.Encoding.ASCII.GetString(ToBytes);
                //    break;
 

              
 
            }

            return  ToText;
             

        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            string sDataPath = null;
            sDataPath = txtFileName.Text.ToString();

            openFileDialog1.InitialDirectory = sDataPath;
            openFileDialog1.Filter = "eml files (*.eml)|*.eml |txt files (*.txt)|*.txt|All files (*.*)|*.*";

            openFileDialog1.FilterIndex = 3;

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
              
                txtFileName.Text = openFileDialog1.FileName;

            }
        }

        private void cmdLoad_Click(object sender, EventArgs e)
        {
            bool bLoad = true;
            string sFile = txtFileName.Text.Trim();
            if (sFile == string.Empty)
            {
                MessageBox.Show("File path needs to be set first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (!File.Exists(sFile))
                {
                    MessageBox.Show("The file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    txtFrom.Text = UserIoHelper.GetFileAsString(sFile);
                }
            }
        }

        //// DecodeQuotedPrintables
        //// from: http://stackoverflow.com/questions/2226554/c-class-for-decoding-quoted-printable-encoding
        //private string DecodeQuotedPrintables(string input, string charSet)
        //{
        //    // http://stackoverflow.com/questions/2226554/c-class-for-decoding-quoted-printable-encoding

        //    if (string.IsNullOrEmpty(charSet))
        //    {
        //        var charSetOccurences = new Regex(@"=\?.*\?Q\?", RegexOptions.IgnoreCase);
        //        var charSetMatches = charSetOccurences.Matches(input);
        //        foreach (Match match in charSetMatches)
        //        {
        //            charSet = match.Groups[0].Value.Replace("=?", "").Replace("?Q?", "");
        //            input = input.Replace(match.Groups[0].Value, "").Replace("?=", "");
        //        }
        //    }

        //    Encoding enc = new ASCIIEncoding();
        //    if (!string.IsNullOrEmpty(charSet))
        //    {
        //        try
        //        {
        //            enc = Encoding.GetEncoding(charSet);
        //        }
        //        catch
        //        {
        //            enc = new ASCIIEncoding();
        //        }
        //    }

        //    //decode iso-8859-[0-9]
        //    var occurences = new Regex(@"=[0-9A-Z]{2}", RegexOptions.Multiline);
        //    var matches = occurences.Matches(input);
        //    foreach (Match match in matches)
        //    {
        //        try
        //        {
        //            byte[] b = new byte[] { byte.Parse(match.Groups[0].Value.Substring(1), System.Globalization.NumberStyles.AllowHexSpecifier) };
        //            char[] hexChar = enc.GetChars(b);
        //            input = input.Replace(match.Groups[0].Value, hexChar[0].ToString());
        //        }
        //        catch
        //        { ;}
        //    }

        //    //decode base64String (utf-8?B?)
        //    occurences = new Regex(@"\?utf-8\?B\?.*\?", RegexOptions.IgnoreCase);
        //    matches = occurences.Matches(input);
        //    foreach (Match match in matches)
        //    {
        //        byte[] b = Convert.FromBase64String(match.Groups[0].Value.Replace("?utf-8?B?", "").Replace("?UTF-8?B?", "").Replace("?", ""));
        //        string temp = Encoding.UTF8.GetString(b);
        //        input = input.Replace(match.Groups[0].Value, temp);
        //    }

        //    input = input.Replace("=\r\n", "");

        //    return input;
        //}

        //string RemoveControlCodes(string sBody)
        //{
        //    string sReturn = string.Empty;

        //    StringBuilder oSanitized = new StringBuilder();
        //    bool bGoodCharacter = true;
        //    int iVal = 0;

        //    foreach (char c in sBody)
        //    {
        //        bGoodCharacter = true;
        //        iVal = (int)c;

        //        //// Extended ascii check
        //        //if (iVal > 127 & iVal < 256)
        //        //{
        //        //    bGoodCharacter = false;
        //        //}

        //        //// Non-ASCII and non-Extended ASCII check
        //        //if (iVal > 255)
        //        //{
        //        //    bGoodCharacter = false;
        //        //}

        //        // Control character check
        //        if ((iVal > 0 && iVal < 7) || (iVal > 13 && iVal < 32))
        //        {
        //            bGoodCharacter = false;
        //        }

        //        if (bGoodCharacter == true)
        //            oSanitized.Append(c);
        //    }

        //    sReturn = oSanitized.ToString();

        //    return sReturn;
        //}


        //string RemoveNonAsciiAndControlCharacters(string sBody)
        //{
        //    string sReturn = string.Empty;

        //    StringBuilder oSanitized = new StringBuilder();
        //    bool bGoodCharacter = true;
        //    int iVal = 0;

        //    foreach (char c in sBody)
        //    {
        //        bGoodCharacter = true;
        //        iVal = (int)c;

        //        // Extended ascii check
        //        if (iVal > 127 & iVal < 256)
        //        {
        //            bGoodCharacter = false;
        //        }

        //        // Non-ASCII and non-Extended ASCII check
        //        if (iVal > 255)
        //        {
        //            bGoodCharacter = false;
        //        }

        //        // Control character check
        //        if ((iVal > 0 && iVal < 7) || (iVal > 13 && iVal < 32))
        //        {
        //            bGoodCharacter = false;
        //        }

        //        if (bGoodCharacter == true)
        //            oSanitized.Append(c);
        //    }

        //    sReturn = oSanitized.ToString();

        //    return sReturn;
        //}


        //string RemoveNonExtendedAsciiAndControlCharacters(string sBody)
        //{
        //    string sReturn = string.Empty;

        //    StringBuilder oSanitized = new StringBuilder();
        //    bool bGoodCharacter = true;
        //    int iVal = 0;

        //    foreach (char c in sBody)
        //    {
        //        bGoodCharacter = true;
        //        iVal = (int)c;

        //        //// Extended ascii check
        //        //if (iVal > 127 & iVal < 256)
        //        //{
        //        //    bGoodCharacter = false;
        //        //}

        //        // Non-ASCII and non-Extended ASCII check
        //        if (iVal > 255)
        //        {
        //            bGoodCharacter = false;
        //        }

        //        // Control character check
        //        if ((iVal > 0 && iVal < 7) || (iVal > 13 && iVal < 32))
        //        {
        //            bGoodCharacter = false;
        //        }

        //        if (bGoodCharacter == true)
        //            oSanitized.Append(c);
        //    }

        //    sReturn = oSanitized.ToString();

        //    return sReturn;
        //}


        //string CheckResponseForOddCharacters(string sBody)
        //{
        //    StringBuilder oSB = new StringBuilder();

        //    bool bResponseHasUnicode = false;
        //    bool bResponseHasExtendedAsciiCharacters = false;
        //    bool bResponseHasControlCharacters = false;
        //    bool bResponseHasOddCharacters = false;
        //    string sReponseCheck = string.Empty;


        //    int iVal = 0;
        //    string sComment = string.Empty;
        //    StringBuilder oCharCheck = new StringBuilder();

        //    oCharCheck.AppendFormat("\r\nDumping characters...\r\n");
        //    oCharCheck.AppendFormat("Value   Char  Comment\r\n");
        //    StringBuilder oSanitized = new StringBuilder();
        //    foreach (char c in sBody)
        //    {
        //        sComment = string.Empty;
        //        iVal = (int)c;
        //        if (iVal > 127 & iVal < 256)
        //        {
        //            sComment = "Over 127";
        //            bResponseHasOddCharacters = true;
        //            bResponseHasExtendedAsciiCharacters = true;
        //        }
        //        if (iVal > 255)
        //        {
        //            sComment = "Over 255";
        //            bResponseHasOddCharacters = true;
        //            bResponseHasUnicode = true;
        //        }
        //        if ((iVal > 0 && iVal < 7) || (iVal > 13 && iVal < 32))
        //        {
        //            sComment = "Control Character";
        //            bResponseHasControlCharacters = true;
        //            bResponseHasOddCharacters = true;
        //        }

        //        if (bResponseHasOddCharacters == false)
        //            oSanitized.Append(c);

        //        oCharCheck.AppendFormat("[{0}] - {1}  {2} \r\n", (int)c, c, sComment);
        //    }


        //    if (bResponseHasOddCharacters == true)
        //    {
        //        oSB.AppendLine("***");
        //        if (bResponseHasControlCharacters == true)
        //            oSB.AppendLine("***  Control Characters found. ***");
        //        if (bResponseHasUnicode == true)
        //            oSB.AppendLine("***  Unicode characters found. ***");
        //        if (bResponseHasExtendedAsciiCharacters == true)
        //            oSB.AppendLine("***  Extended ASCII characters found. ***");
        //        oSB.AppendLine("***");
        //        oSB.Append(oCharCheck.ToString());  // Character by character check

        //        oSB.Append("\r\nThe following is a version of the source text without extended ascii/unicode/control characters:\r\n");
        //        oSB.Append(oSanitized.ToString());

        //        //MessageBox.Show("The are non-basic ASCII characters found.");
        //    }
        //    else
        //    {
        //        oSB.AppendLine("No non-ASCII or control characters found.");
        //        oSB.AppendLine("");
        //    }

        //    oSB.Append(oSanitized.ToString());

        //    return oSB.ToString();
        //}
    }
}
