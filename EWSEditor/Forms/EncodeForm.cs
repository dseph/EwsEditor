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

        private const string XmlConvertVerifyXmlChars = "XmlConvert - VerifyXmlChars";
 

 
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
            byte[] oFromBytes;
            //byte[] ToBytes;
            System.Text.Encoding oUtf8Encoding = System.Text.Encoding.UTF8;
            System.Text.Encoding oAsciiEncoding = System.Text.Encoding.ASCII;

            switch (TypeOfConversion)
            {
                case UrlEncode:
                    ToText = System.Web.HttpUtility.UrlEncode(FromText);
                    break;
                case UrlDecode:
                    ToText = System.Web.HttpUtility.UrlDecode(FromText);
                    break;
                case UrlEncodeUnicode:
                     
                    ToText = System.Web.HttpUtility.UrlEncodeUnicode(FromText);
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
                //        ToBytes = Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding("iso-8859-1"), oFromBytes);
                //        ToText = System.Text.Encoding.UTF8.GetString(ToBytes);
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
    }
}
