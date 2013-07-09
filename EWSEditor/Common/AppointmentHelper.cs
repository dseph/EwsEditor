using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Exchange.WebServices.Data;

namespace EWSEditor.Common
{
    public class AppointmentHelper
    {

        public static string GetAttendeeStatusAsInfoString(Appointment oAppointment)
        {

            // http://msdn.microsoft.com/en-us/library/dd633669(EXCHG.80).aspx
            string s = string.Empty;


            // Check responses from required attendees.
            s += "Required attendee:\r\n";
            for (int i = 0; i < oAppointment.RequiredAttendees.Count; i++)
            {
                s += "    " + oAppointment.RequiredAttendees[i].Address + ": " + oAppointment.RequiredAttendees[i].ResponseType.Value.ToString() + "\r\n";
            }

            // Check responses from optional attendees.
            s += "Optional attendee:\r\n";
            for (int i = 0; i < oAppointment.OptionalAttendees.Count; i++)
            {
                s += "    " + oAppointment.OptionalAttendees[i].Address + ": " + oAppointment.OptionalAttendees[i].ResponseType.Value.ToString() + "\r\n";
            }

            // Check responses from resources.
            s += "Resource attendee:\r\n";
            for (int i = 0; i < oAppointment.Resources.Count; i++)
            {
                s += "    " + oAppointment.Resources[i].Address + ": " + oAppointment.Resources[i].ResponseType.Value.ToString() + "\r\n";
            }

            return s;

        }
    }
}
