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
using System.IO;
using EWSEditor.Common;
 

namespace EWSEditor.Forms
{
    public partial class FileContentHelper : Form
    {
        public string sInitialDirectory = Application.StartupPath + "\\Testing";
        public FileContentHelper()
        {
            InitializeComponent();
        }

        private void Base64Contenthelper_Load(object sender, EventArgs e)
        {
            txtLoadFile.Text = sInitialDirectory;
            txtSaveFile.Text = sInitialDirectory;
            
        }

        private void lblFromFile_Click(object sender, EventArgs e)
        {

        }

        private void btnFromFileGo_Click(object sender, EventArgs e)
        {
         
        }

        private void btnToFileGo_Click(object sender, EventArgs e)
        {
 
            //string sSuggestedFilename = "*.xml";
            //string sSelectedfile = string.Empty;
            //string sFilter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";

            //if (UserIoHelper.PickSaveFileToFolder(sInitialDirectory, sSuggestedFilename, ref  sSelectedfile, sFilter))
            //{
            //    try
            //    {
            //        System.IO.File.WriteAllText(sSelectedfile, txtRequest.Text);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "Error writting file.");
            //    }

            //}
        }

        private void btnLoadFileG_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
 
           try
           { 
 
                switch (cmboLoadType.Text.Trim())
                {
                    case "BASE64":
                       txtLoad.Text = System.Convert.ToBase64String(System.IO.File.ReadAllBytes(txtLoadFile.Text.Trim()));
                        break;
                    case "Hex Bytes":
                        string sResults = StringHelper.HexStringFromByteArray(System.IO.File.ReadAllBytes(txtLoadFile.Text.Trim()), true);
                        txtLoad.Text = sResults.Trim();   
                        break;
                    case "Hex Dump":
                        txtLoad.Text = StringHelper.HexDumpFromByteArray(System.IO.File.ReadAllBytes(txtLoadFile.Text.Trim()));
                        break;
                    default:
                        break;
                }
 
       
                        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }

        private void btnSaveFileGo_Click(object sender, EventArgs e)
        {
 
            //System.IO.FileStream saveFile;
             
            string sErrors = string.Empty; ;
            string base64String = txtSave.Text.Trim();

            try
            {

                switch (cmboSaveType.Text.Trim())
                {
                    case "BASE64":
                        System.IO.File.WriteAllBytes(txtSaveFile.Text.Trim(), System.Convert.FromBase64String(txtSave.Text.Trim()));
                        break;
                    case "Hex Bytes":
                        byte[] binaryData = null;
                        string sCleanedString = string.Empty;
                        bool bRet = false;
                        bRet = StringHelper.CleanHexString(txtSave.Text.Trim(), ref sCleanedString, ref sErrors);
                        if (bRet == true)
                        {  
                            bRet = StringHelper.RoughHexStringToByteArray(sCleanedString, ref binaryData, ref sErrors);
                            if (bRet == false)
                                MessageBox.Show(sErrors, "Error converting to byte array.");
                            }
                        else
                        { 
                            MessageBox.Show(sErrors, "Error cleaning content.");
                        }
                        if (bRet == true)
                        {
                            System.IO.File.WriteAllBytes(txtSaveFile.Text.Trim(), binaryData);
                        }
                        else
                        {
                            MessageBox.Show(sErrors, "Error");
                        }
                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }

        private void btnLoadFileSelect_Click(object sender, EventArgs e)
        {
             
 
            string sContent = string.Empty;

            string sSuggestedFilename = "*.*";
            string sSelectedfile = string.Empty;
            string sFilter = "Jpg files (*.jpg)|*.jpg|XML files (*.xml)|*.xml|All files (*.*)|*.*";

            if (UserIoHelper.PickLoadFromFile(txtLoadFile.Text.Trim(), sSuggestedFilename, ref  sSelectedfile, sFilter))
            {

                txtLoadFile.Text = sSelectedfile;
 

            }
        }

        private void btnSaveFileSelect_Click(object sender, EventArgs e)
        {
  
            string sContent = string.Empty;

            string sSuggestedFilename = "*.*";
            string sSelectedfile = string.Empty;
            string sFilter = "Jpg files (*.jpg)|*.jpg|XML files (*.xml)|*.xml|All files (*.*)|*.*";

            if (UserIoHelper.PickSaveFileToFolder(txtSaveFile.Text.Trim(), sSuggestedFilename, ref  sSelectedfile, sFilter))
            {
                txtSaveFile.Text = sSelectedfile;
            }

           
        }
    }
}
