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

    public class ListViewItemComparer_Dates : IComparer
    {
        // https://social.msdn.microsoft.com/Forums/vstudio/en-US/499ce6d4-b20c-4675-89f6-08801d404fd0/sort-listview-items-by-date?forum=csharpgeneral
        private int col;
        private SortOrder order;
        public ListViewItemComparer_Dates()
        {
            col = 0;
            order = SortOrder.Ascending;
        }
        public ListViewItemComparer_Dates(int column, SortOrder order)
        {
            col = column;
            this.order = order;
        }
        public int Compare(object x, object y)
        {
            int returnVal;
            // Determine whether the type being compared is a date type.   
            try
            {
                // Parse the two objects passed as a parameter as a DateTime.   
                System.DateTime firstDate =
                        DateTime.Parse(((ListViewItem)x).SubItems[col].Text);
                System.DateTime secondDate =
                        DateTime.Parse(((ListViewItem)y).SubItems[col].Text);
                // Compare the two dates.   
                returnVal = DateTime.Compare(firstDate, secondDate);
            }
            // If neither compared object has a valid date format, compare   
            // as a string.   
            catch
            {
                // Compare the two items as a string.   
                returnVal = String.Compare(((ListViewItem)x).SubItems[col].Text,
                            ((ListViewItem)y).SubItems[col].Text);
            }
            // Determine whether the sort order is descending.   
            if (order == SortOrder.Descending)
                // Invert the value returned by String.Compare.   
                returnVal *= -1;
            return returnVal;
        }
    }  


}
