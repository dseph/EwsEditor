using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EWSEditor.Forms.Searches
{
    public partial class SearchAccrossMailboxes : Form
    {
        public SearchAccrossMailboxes()
        {
            InitializeComponent();
        }

        private void SearchAccrossMailboxes_Load(object sender, EventArgs e)
        {

            ////"DescPropertyName",							"ProbablePropertyName",					"PropertySetId",			"PropertyId",		"PropertyType"
            ////"PidLidAddressBookProviderArrayType",		"PidLidAddressBookProviderArrayType,	"PSETID_Address",			"0x00008029",		Integer                    
            ////PidLidAddressBookProviderEmailList",		"PidLidAddressBookProviderEmailList,	"PSETID_Address",			"0x00008028",		IntegerArray                    
            ////"PidLidAddressCountryCode",				"PidLidAddressCountryCode,				"PSETID_Address",			"0x000080DD",		String                    
            //            "PidLidAgingDontAgeMe",						"PidLidAgingDontAgeMe,					"PSETID_Common",			"0x0000850E",		Boolean                    
            //"PidLidAllAttendeesList",					"PidLidAllAttendeesList,				"PSETID_Meeting",			"0x0000001D",		String                    
            //"PidLidAllAttendeesString",					"PidLidAllAttendeesString,				"PSETID_Appointment",		"0x00008238",		String                    
            //"PidLidAllowExternalCheck",					"PidLidAllowExternalCheck,				"PSETID_Appointment",		"0x00008246",		Boolean                    
            ////"PidLidAnniversaryEventEntryId",			"PidLidAnniversaryEventEntryId,			"PSETID_Address",			"0x0000804E",		Binary                    
            //"PidLidAppointmentAuxiliaryFlags",			"PidLidAppointmentAuxiliaryFlags,		"PSETID_Appointment",		"0x00008207",		Integer      

        }

        private void SelectPSetId()
        {
            string sSelectedPSet = string.Empty;
            //SelectPSetId oForm = new SelectPSetId();
            //oForm.Show();
            //if (oForm.ChoseOk == true)
            //{
            //    sSelectedPSet = oForm.sSelectedPS;
            //}
        }

    }
}
