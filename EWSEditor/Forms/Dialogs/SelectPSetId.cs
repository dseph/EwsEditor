using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// List propertyset IDs and guids for user selection.
// TODO: Finish

namespace EWSEditor.Forms.Dialogs
{
    public partial class SelectPSetId : Form
    {
        public SelectPSetId()
        {
            InitializeComponent();
        }

        private void SelectPSetId_Load(object sender, EventArgs e)
        {

        }


        private void AddPSetIdsToList(ref ListView oListView)
        {

            //				Common				PS_PUBLIC_STRINGS	 		00020329-0000-0000-C000-000000000046 
            //				Common				PSETID_Common				00062008-0000-0000-C000-000000000046
            //				Contact				PSETID_Address				00062004-0000-0000-C000-000000000046
            //				Email				PS_INTERNET_HEADERS			00020386-0000-0000-C000-000000000046

            AddPSetIdsToList_AddLine(ref oListView, "00020329-0000-0000-C000-000000000046", "PS_PUBLIC_STRINGS", "Common");
            AddPSetIdsToList_AddLine(ref oListView, "00062008-0000-0000-C000-000000000046", "PSETID_Common	", "Common");
            AddPSetIdsToList_AddLine(ref oListView, "00062004-0000-0000-C000-000000000046", "PSETID_Address", "Contact");
            AddPSetIdsToList_AddLine(ref oListView, "00020386-0000-0000-C000-000000000046", "PS_INTERNET_HEADERS", "Email");


            //				Calendar			PSETID_Appointment			00062002-0000-0000-C000-000000000046
            //				Calendar			PSETID_Meeting				6ED8DA90-450B-101B-98DA-00AA003F1305
            //				Journal				PSETID_Log					0006200A-0000-0000-C000-000000000046
            //				Messaging			PSETID_Messaging			41F28F13-83F4-4114-A584-EEDB5A6B0BFF
            //

            AddPSetIdsToList_AddLine(ref oListView, "00062002-0000-0000-C000-000000000046", "PSETID_Appointment", "Calendar");
            AddPSetIdsToList_AddLine(ref oListView, "6ED8DA90-450B-101B-98DA-00AA003F1305", "PSETID_Meeting	", "Calendar");
            AddPSetIdsToList_AddLine(ref oListView, "0006200A-0000-0000-C000-000000000046", "PSETID_Log", "Journal");
            AddPSetIdsToList_AddLine(ref oListView, "41F28F13-83F4-4114-A584-EEDB5A6B0BFF", "PSETID_Messaging", "Messaging");


            //
            //				Sticky note			PSETID_Note					0006200E-0000-0000-C000-000000000046
            //				RSS feed			PSETID_PostRss				00062041-0000-0000-C000-000000000046
            //				Task				PSETID_Task					00062003-0000-0000-C000-000000000046
            //				Unified messaging	PSETID_UnifiedMessaging		4442858E-A9E3-4E80-B900-317A210CC15B 

            AddPSetIdsToList_AddLine(ref oListView, "0006200E-0000-0000-C000-000000000046", "PSETID_Note", "Sticky note");
            AddPSetIdsToList_AddLine(ref oListView, "00062041-0000-0000-C000-000000000046", "PSETID_PostRss	", "RSS feed");
            AddPSetIdsToList_AddLine(ref oListView, "00062003-0000-0000-C000-000000000046", "PSETID_Task", "Task");
            AddPSetIdsToList_AddLine(ref oListView, "4442858E-A9E3-4E80-B900-317A210CC15B", "PSETID_UnifiedMessaging", "Unified messaging");


            //				Common				PS_MAPI						00020328-0000-0000-C000-000000000046
            //				Sync				PSETID_AirSync				71035549-0739-4DCB-9163-00F0580DBBDF
            //				Sharing				PSETID_Sharing				00062040-0000-0000-C000-000000000046
            //				Extracted entities	PSETID_XmlExtractedEntities	23239608-685D-4732-9C55-4C95CB4E8E33 

            AddPSetIdsToList_AddLine(ref oListView, "00020328-0000-0000-C000-000000000046", "PS_MAPI", "Common");
            AddPSetIdsToList_AddLine(ref oListView, "71035549-0739-4DCB-9163-00F0580DBBDF", "PSETID_AirSync	", "Sync");
            AddPSetIdsToList_AddLine(ref oListView, "00062040-0000-0000-C000-000000000046", "PSETID_Sharing", "Sharing");
            AddPSetIdsToList_AddLine(ref oListView, "23239608-685D-4732-9C55-4C95CB4E8E33", "PSETID_XmlExtractedEntities", "Extracted entities");


            //
            //				Calendar Assistant?	PSETID_CalendarAssistant	11000E07-B51B-40D6-AF21-CAA85EDAB1D0

            AddPSetIdsToList_AddLine(ref oListView, "11000E07-B51B-40D6-AF21-CAA85EDAB1D0", "PSETID_CalendarAssistant", "Calendar Assistant");


        }
        private void AddPSetIdsToList_AddLine(ref ListView oListView, string sGuid, string sPropSetName, string sAreaName)
        {

            ListViewItem oListViewItem = null;
            oListViewItem = oListView.Items.Add(sGuid);
            oListViewItem.SubItems.Add(sPropSetName);
            oListViewItem.SubItems.Add(sAreaName);

        }
    }
}
