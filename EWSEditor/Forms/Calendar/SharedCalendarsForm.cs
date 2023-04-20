using Microsoft.Exchange.WebServices.Data;
using System;
using System.Collections.Generic;
 
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EWSEditor.Calendar.SharedCalendar;
 

namespace EWSEditor.Forms.Calendar
{
    public partial class SharedCalendarsForm : Form
    {
        ExchangeService _Service = null;

        public SharedCalendarsForm()
        {
            InitializeComponent();
        }

        public SharedCalendarsForm(ExchangeService oService)
        {
            InitializeComponent();
            _Service = oService;
        }

        private void SharedCalendars_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EWSEditor.Calendar.SharedCalendar.SharedCalendars oSC = new EWSEditor.Calendar.SharedCalendar.SharedCalendars();
            System.Windows.Forms.ListViewItem oListItem =null;
 

            Dictionary<string, Folder> oDict = oSC.GetSharedCalendarFolders(_Service, txtMailboxSmtp.Text.Trim());

            foreach (KeyValuePair<string, Folder> entry in oDict)
            {
                Console.WriteLine(entry.Key + "[0] - [1] " + entry.Value.DisplayName, entry.Value.Id.UniqueId);
                oListItem = new System.Windows.Forms.ListViewItem(entry.Value.DisplayName, 0);
                oListItem.Tag = entry.Value;

                lvSharedCalendars.Items.AddRange(new ListViewItem[] { oListItem });
                oListItem = null;
 
            }

        }

        private void lvSharedCalendars_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvSharedCalendars_DoubleClick(object sender, EventArgs e)
        {
            if (lvSharedCalendars.SelectedItems.Count != 0)
            {
                string sFolderId = lvSharedCalendars.SelectedItems[0].Text;
 
                Folder oFolder = (Folder)lvSharedCalendars.SelectedItems[0].Tag;

                if (oFolder != null)
                {
 
                    FolderContentForm.Show(
                        "Shared Calendar Folder: " + oFolder.DisplayName,
                        oFolder,
                        ItemTraversal.Shallow,
                        _Service,
                        this);
                }





            }
        }
    }
}
