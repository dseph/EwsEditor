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

namespace EWSEditor.Forms
{
    public partial class ViewInBrowser : Form
    {
        public ViewInBrowser()
        {
            InitializeComponent();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
 
        }

        private void btnCreatePageAndView_Click(object sender, EventArgs e)
        {
            string sContent = textBox1.Text;
            //sContent = System.Web.HttpUtility.HtmlDecode(textBox1.Text);

            StringBuilder oSB = new StringBuilder();
            oSB.AppendLine("<HTML>");

            oSB.AppendLine("  <HEAD>");
            oSB.AppendLine("  </HEAD>");

            oSB.AppendLine("    <BODY>");
            oSB.Append("        ");
            oSB.AppendLine(textBox1.Text);
            oSB.AppendLine("    </BODY>");

            oSB.AppendLine("</HTML>");

            // oSB.AppendFormat("Email Address: %0   Folder: %1  UniqueId: %2\r\n", sEmailAddress, sFolder);

            string sFile = string.Empty;

            sContent = oSB.ToString();

            sFile = CreateTempFile(sContent, cmboFileExtension.Text.Trim());
           // webBrowser1.DocumentText = sContent;
            webBrowser1.Navigate(sFile);
             
        }

        private string CreateTempFile(string sContent)
        {
            string sFileNameExtension = string.Empty;
            return CreateTempFile(sContent, sFileNameExtension);
        }

        private string CreateTempFile(string sContent, string sFileNameExtension)
        {

             
            string sFoldePath = Path.GetTempPath();
            string sFileName = Path.GetRandomFileName();
            if (sFileNameExtension != string.Empty)
                sFileName += ("." +sFileNameExtension);
            string sFile = Path.Combine(sFoldePath, sFileName);

            StreamWriter oSW = new StreamWriter(sFile);
            oSW.Write(sContent);
            oSW.Close();
            oSW = null;

            //File.WriteAllText(sFile, sContent);

            return sFile;  
        }

        private void btnViewInExternalIE_Click(object sender, EventArgs e)
        {
            string sContent = textBox1.Text;
            //sContent = System.Web.HttpUtility.HtmlDecode(textBox1.Text);

            string sFile = string.Empty;

            sFile = CreateTempFile(sContent, cmboFileExtension.Text.Trim());

            //webBrowser1.DocumentText = sContent;

          
            webBrowser1.Navigate(sFile, true);
        }

        private void btnView_Click_1(object sender, EventArgs e)
        {

            string sContent = textBox1.Text;
            //sContent = System.Web.HttpUtility.HtmlDecode(textBox1.Text);

            string sFile = string.Empty;

            sFile = CreateTempFile(sContent, cmboFileExtension.Text.Trim());

            //webBrowser1.DocumentText = sContent;

            webBrowser1.Navigate(sFile);

            
        }

        private void ViewInBrowser_Load(object sender, EventArgs e)
        {

             
        }
    }
}
