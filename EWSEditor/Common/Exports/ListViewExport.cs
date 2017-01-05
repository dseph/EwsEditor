using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace EWSEditor.Common 
{
    public class ListViewExport
    {
        public static bool SaveListViewToCsv(ListView oListView, string sFilePath)
        {
            bool bRet = false;

            string sHeader = string.Empty;
            string sLine = string.Empty;

            StreamWriter w = File.AppendText(sFilePath);
            char[] TrimChars = { ',', ' ' };
            StringBuilder SbHeader = new StringBuilder();
            foreach (ColumnHeader oCH in oListView.Columns)
            {
                SbHeader.Append(oCH.Text);
                SbHeader.Append(",");
            }
            sHeader = SbHeader.ToString();
            sHeader = sHeader.TrimEnd(TrimChars);
            w.WriteLine(sHeader);
           

            string s = string.Empty;
            foreach (ListViewItem oListViewItem in oListView.Items)
            {
                if (oListViewItem.Selected == true)
                {
                    StringBuilder SbLine = new StringBuilder();
                    //SbLine.Append(oListViewItem.Text);
                    //SbLine.Append(",");

                    foreach (ListViewItem.ListViewSubItem o in oListViewItem.SubItems)
                    {
                        s = (o.Text);
                        if (s.Contains(','))
                            s = s.Replace(",", " "); // need to strip commas as this is a csv file.
                        SbLine.Append(s);
                        SbLine.Append(",");
                    }
                    sLine = SbLine.ToString();
                    sLine = sLine.TrimEnd(TrimChars);
                    w.WriteLine(sLine);

                    bRet = true;
                }
            }

            w.Close();

            return bRet;
        }
        
    }
}
