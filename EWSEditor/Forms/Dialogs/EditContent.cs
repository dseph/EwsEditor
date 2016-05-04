using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EWSEditor.Common;

namespace EWSEditor.Forms.Dialogs
{
     
    public partial class EditContents : Form
    {

        public string NewBody = string.Empty;
        public bool UserChoseOK = false;

        public EditContents()
        {
            InitializeComponent();
        }

        public EditContents(string sBody)
        {
            InitializeComponent();
            txtBody.Text = sBody;
        
        }

        private void tabIERendering_Click(object sender, EventArgs e)
        {

        }

        private void EditContent_Load(object sender, EventArgs e)
        {

        }

     

        private void btnCancel_Click(object sender, EventArgs e)
        {

            UserChoseOK = false;
            this.Close();

           
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void wbContents_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
         
        private void btnOK_Click(object sender, EventArgs e)
        {
            NewBody = txtBody.Text;
            UserChoseOK = true;
            this.Close();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            wbContents.DocumentText = txtBody.Text;
        }

        private void btnLoadExample_Click(object sender, EventArgs e)
        {
            string sInitialDirectory = Application.StartupPath + "\\HtmlBodyExamples";

            string sSuggestedFilename = "*.*";
            string sSelectedfile = string.Empty;
            string sFilter = "HTM files (*.htm)|*.htm|HTML files (*.html)|*.html|TXT files (*.txt)|*.txt|All files (*.*)|*.*";

            if (UserIoHelper.PickLoadFromFile(sInitialDirectory, sSuggestedFilename, ref  sSelectedfile, sFilter))
            {
                try
                {

                    txtBody.Text = System.IO.File.ReadAllText(sSelectedfile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error reading file.");
                }

            }
        }

        private void btnSaveExample_Click(object sender, EventArgs e)
        {
            string sInitialDirectory = Application.StartupPath + "\\HtmlBodyExamples";

            string sSuggestedFilename = "*.*";
            string sSelectedfile = string.Empty;
            string sFilter = "HTM files (*.htm)|*.htm|HTML files (*.html)|*.html|TXT files (*.txt)|*.txt|All files (*.*)|*.*";
  

            if (UserIoHelper.PickSaveFileToFolder(sInitialDirectory, sSuggestedFilename, ref  sSelectedfile, sFilter))
            {
                try
                {
                    System.IO.File.WriteAllText(sSelectedfile, txtBody.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error writting file.");
                }

            }
        }
    }
}
