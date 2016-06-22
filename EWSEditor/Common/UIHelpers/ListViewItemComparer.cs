using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Data;
using System.Diagnostics;
 

namespace EWSEditor.Common.UIHelpers
{
    public class ListViewItemComparer : IComparer
    {

        private int col;
        public ListViewItemComparer()
        {
            col = 0;
        }

        public ListViewItemComparer(int column)
        {
            col = column;
        }

        public int Compare(object x, object y)
        {
            int returnVal = -1;
            ListViewItem oX = (ListViewItem)x;
            ListViewItem oY = (ListViewItem)y;
            string sX = oX.SubItems[col].Text;
            string sY = oY.SubItems[col].Text;

            returnVal = String.Compare(sX, sY);
            return returnVal;
        }
    }

}
