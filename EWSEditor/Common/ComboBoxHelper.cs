using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using EWSEditor.Common;

namespace EWSEditor.Common 
{
    public class ComboBoxHelper
    {

        static public void AddEnumsToComboBox(ref ComboBox oComboBox, Type oType, bool SetFirstAsDefault)
        {

            AddEnumsToComboBox(ref oComboBox, oType);

            if (SetFirstAsDefault == true)
            {
                oComboBox.Text = oComboBox.Items[0].ToString();
            }

        }

        static public void AddEnumsToComboBox(ref ComboBox oComboBox, Type oType)
        {
            oComboBox.Items.Clear();

            Array arrItems = System.Enum.GetValues(oType);

            foreach (int iItem in arrItems)
            {

                string sItem = Enum.GetName(oType, iItem);
                oComboBox.Items.Add(sItem);
            }
        }
    }
}
