using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace EWSEditor.Common 
{ 
    public class UserIoHelper
    {
        public static bool PickSaveFileToFolder(string SuggestedName, ref string SelectedFile)
        {

            bool bRet = false;
            SaveFileDialog fsd = new SaveFileDialog();

            SelectedFile = SuggestedName;

            fsd.FileName = SuggestedName;
            fsd.Filter = "All files (*.*)|*.*";
            fsd.FilterIndex = 1;
            fsd.RestoreDirectory = false;
            fsd.Title = "Save File To Folder";

            if (fsd.ShowDialog() == DialogResult.OK)
            {
                bRet = true;
                SelectedFile = fsd.FileName.Trim();
            }
            fsd = null;
            return bRet;
        }

        public static bool PickSaveFileToFolder(string InitialDirectory, string SuggestedName, ref string SelectedFile)
        {
            bool bRet = false;
            bRet = PickSaveFileToFolder(InitialDirectory, SuggestedName, ref SelectedFile, "All files (*.*)|*.*");
            return bRet;
        }

        public static bool PickSaveFileToFolder(string InitialDirectory, string SuggestedName, ref string SelectedFile, string FileFilter)
        {

            bool bRet = false;
            SaveFileDialog fsd = new SaveFileDialog();

            SelectedFile = SuggestedName;
            fsd.InitialDirectory = InitialDirectory;
            fsd.FileName = SuggestedName;
            fsd.Filter = "All files (*.*)|*.*";
            fsd.FilterIndex = 1;
            fsd.RestoreDirectory = false;
            fsd.Title = "Save File To Folder";

            if (fsd.ShowDialog() == DialogResult.OK)
            {
                bRet = true;
                SelectedFile = fsd.FileName.Trim();
            }
            fsd = null;
            return bRet;
        }

        public static bool PickLoadFromFile(string InitialDirectory, string SuggestedName, ref string SelectedFile)
        {

            bool bRet = false;
            bRet = PickLoadFromFile(InitialDirectory, SuggestedName, ref SelectedFile, "All files (*.*)|*.*");

            return bRet;
        }

        public static bool PickLoadFromFile(string InitialDirectory, string SuggestedName, ref string SelectedFile, string FileFilter)
        {

            bool bRet = false;
            OpenFileDialog fsd = new OpenFileDialog();

            SelectedFile = SuggestedName;
            fsd.InitialDirectory = InitialDirectory;
            fsd.FileName = SuggestedName;
            fsd.Filter = FileFilter;
            fsd.FilterIndex = 1;
            fsd.RestoreDirectory = false;
            fsd.Title = "Select File";

            if (fsd.ShowDialog() == DialogResult.OK)
            {
                bRet = true;
                SelectedFile = fsd.FileName.Trim();
            }
            fsd = null;
            return bRet;
        }

    }
}
