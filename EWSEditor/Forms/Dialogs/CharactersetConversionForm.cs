// CharactersetConversionform.cs

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EWSEditor.Forms.Dialogs
{
    public partial class CharactersetConversionForm : Form
    {
        public CharactersetConversionForm()
        {
            InitializeComponent();
        }

        private void CharactersetConversionForm_Load(object sender, EventArgs e)
        {
            // also see https://stackoverflow.com/questions/2855842/convert-utf-8-to-chinese-simplified-gb2312
            AddEncodingsToCombo(ref cmboFrom);
            AddEncodingsToCombo(ref cmboTo);
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            // https://docs.microsoft.com/en-us/dotnet/api/system.text.encodinginfo.name?view=netframework-4.8

            Encoding oFrom = Encoding.GetEncoding(cmboFrom.Text.Trim());
            Encoding oTo = Encoding.GetEncoding(cmboTo.Text.Trim());
             
            string sVal = ConvertEncoding(txtFrom.Text, oFrom, oTo);
            txtTo.Text = sVal;
        }

        //private Encoding GetEncodingSelection( string sValue)
        //{
        //    Encoding o = Encoding.ASCII;

        //    o = Encoding.GetEncoding(sValue);


        //    return o;
        //}

        private string ConvertEncoding(string sString, Encoding EncFrom, Encoding EncTo)
        {
            byte[] fromBytes = EncFrom.GetBytes(sString);

            byte[] toBytes = Encoding.Convert(EncFrom, EncTo, fromBytes);

            string toString = EncTo.GetString(toBytes);

            //System.Convert.FromBase64String(FromText);

            //using (StreamReader sr = new StreamReader(infile, Encoding.GetEncoding(936)))
            //{
            //    using (StreamWriter sw = new StreamWriter(outfile, false, Encoding.UTF8))
            //    {
            //        sw.Write(sr.ReadToEnd());
            //        sw.Close();
            //    }
            //    sr.Close();

                return toString;
        }

        private void cmboFrom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddEncodingsToCombo(ref ComboBox cmbo)
        {
            // https://stackoverflow.com/questions/7320847/get-encoding-list-in-net-1-1

            //string[] encs = new string[] {
            //    "IBM037", "IBM437", "IBM500", "ASMO-708", "DOS-720", "ibm737",
            //    "ibm775", "ibm850", "ibm852", "IBM855", "ibm857", "IBM00858",
            //    "IBM860", "ibm861", "DOS-862", "IBM863", "IBM864", "IBM865",
            //    "cp866", "ibm869", "IBM870", "windows-874", "cp875",
            //    "shift_jis", "gb2312", "ks_c_5601-1987", "big5", "IBM1026",
            //    "IBM01047", "IBM01140", "IBM01141", "IBM01142", "IBM01143",
            //    "IBM01144", "IBM01145", "IBM01146", "IBM01147", "IBM01148",
            //    "IBM01149", "utf-16", "utf-16BE", "windows-1250",
            //    "windows-1251", "Windows-1252", "windows-1253", "windows-1254",
            //    "windows-1255", "windows-1256", "windows-1257", "windows-1258",
            //    "Johab", "macintosh", "x-mac-japanese", "x-mac-chinesetrad",
            //    "x-mac-korean", "x-mac-arabic", "x-mac-hebrew", "x-mac-greek",
            //    "x-mac-cyrillic", "x-mac-chinesesimp", "x-mac-romanian",
            //    "x-mac-ukrainian", "x-mac-thai", "x-mac-ce", "x-mac-icelandic",
            //    "x-mac-turkish", "x-mac-croatian", "utf-32", "utf-32BE",
            //    "x-Chinese-CNS", "x-cp20001", "x-Chinese-Eten", "x-cp20003",
            //    "x-cp20004", "x-cp20005", "x-IA5", "x-IA5-German",
            //    "x-IA5-Swedish", "x-IA5-Norwegian", "us-ascii", "x-cp20261",
            //    "x-cp20269", "IBM273", "IBM277", "IBM278", "IBM280", "IBM284",
            //    "IBM285", "IBM290", "IBM297", "IBM420", "IBM423", "IBM424",
            //    "x-EBCDIC-KoreanExtended", "IBM-Thai", "koi8-r", "IBM871",
            //    "IBM880", "IBM905", "IBM00924", "EUC-JP", "x-cp20936",
            //    "x-cp20949", "cp1025", "koi8-u", "iso-8859-1", "iso-8859-2",
            //    "iso-8859-3", "iso-8859-4", "iso-8859-5", "iso-8859-6",
            //    "iso-8859-7", "iso-8859-8", "iso-8859-9", "iso-8859-13",
            //    "iso-8859-15", "x-Europa", "iso-8859-8-i", "iso-2022-jp",
            //    "csISO2022JP", "iso-2022-jp", "iso-2022-kr", "x-cp50227",
            //    "euc-jp", "EUC-CN", "euc-kr", "hz-gb-2312", "GB18030",
            //    "x-iscii-de", "x-iscii-be", "x-iscii-ta", "x-iscii-te",
            //    "x-iscii-as", "x-iscii-or", "x-iscii-ka", "x-iscii-ma",
            //    "x-iscii-gu", "x-iscii-pa", "utf-7", "utf-8"
            //};

            // https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=netframework-4.8

            string[] encs = new string[] {
                "EUC-CN",
                "euc-jp",
                "euc-kr",
                "gb2312",
                "GB18030",
                "hz-gb-2312",
                "iso-8859-1",
                "iso-8859-8-i",
                "iso-2022-jp",
                "csISO2022JP",
                "iso-2022-jp",
                "iso-2022-kr",
                "unicodeFFFE",
                "Windows-1252",
                "us-ascii",
                "utf-7", "utf-8", "utf-16", "utf-32", "utf-32BE",
                "x-cp20936",
                "x-cp20949",
                "x-cp50227",
                "x-iscii-de",
                "x-iscii-be",
                "x-iscii-ta",
                "x-iscii-te",
                "x-iscii-as",
                "x-iscii-or",
                "x-iscii-ka",
                "x-iscii-ma",
                "x-iscii-gu",
                "x-iscii-pa",
                "x-mac-chinesesimp",
                "x-mac-korean"

            };

 

            //foreach (EncodingInfo ei in Encoding.GetEncodings())
            //{
            //    Encoding e = ei.GetEncoding();

            //    Console.Write("{0,-15}", ei.CodePage);
            //    if (ei.CodePage == e.CodePage)
            //        Console.Write("    ");
            //    else
            //        Console.Write("*** ");

            //    Console.Write("{0,-25}", ei.Name);
            //    if (ei.CodePage == e.CodePage)
            //        Console.Write("    ");
            //    else
            //        Console.Write("*** ");

            //    Console.Write("{0,-25}", ei.DisplayName);
            //    if (ei.CodePage == e.CodePage)
            //        Console.Write("    ");
            //    else
            //        Console.Write("*** ");

            //    Console.WriteLine();
            //}


            cmbo.Items.Clear();

            //foreach (EncodingInfo ei in Encoding.GetEncodings())
            //{
            //    Encoding e = ei.GetEncoding();
            //    cmbo.Items.Add(ei.Name);
            //}

            foreach (var enc in encs)
            {
                cmbo.Items.Add(enc);
            }

        }
    }
}
