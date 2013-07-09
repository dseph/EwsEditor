using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Exchange.WebServices.Data;
//using EWSEditor;
using System.Windows.Forms;

namespace EWSEditor.Common
{
    public class RecipeintHelper
    {

        public static bool SetAppointmentRecipientsFromString(ref Appointment oAppointment, string sRecipeintLine, string sAddressString)
        {
            bool bRet = false;
            Attendee oAttendee = null;
            char[] arrAddressDelimiter = { ';' };
            string[] sAddresses = sAddressString.Split(arrAddressDelimiter);
            string sSmtpAddress = string.Empty;
            string sRecipientName = string.Empty;
            string sWork = string.Empty;
            char[] carrEndAddress = { '>', ')' };
            char[] carrStartAddress = { '<', ')' };
            char[] junk = { '<', '>', '(', ' ', ';' };
            int iEndAddress = 0;
            int iStartAddress = 0;
            string sCurrentAddress = string.Empty;
            try
            {
                foreach (string sAddress in sAddresses)
                {

                    sCurrentAddress = sAddress;

                    iStartAddress = sAddress.IndexOfAny(carrStartAddress);
                    iEndAddress = sAddress.IndexOfAny(carrEndAddress);

                    sSmtpAddress = string.Empty;
                    sRecipientName = string.Empty;
                    if (sAddress.Contains('>') || sAddress.Contains(')'))
                    {
                        sWork = sAddress.Substring(iStartAddress, iEndAddress - iStartAddress);
                        sSmtpAddress = sWork.Trim(junk);

                        sWork = sWork.Substring(0, iStartAddress);
                        sRecipientName = sWork.Trim(junk);
                    }
                    else
                    {
                        sWork = sAddress.Trim(junk);
                        if (sWork.Length != 0)
                            sSmtpAddress = sAddress.Trim(junk);

                    }

                    if (sRecipientName.Length != 0)
                    {
                        if (sSmtpAddress.Length != 0)
                        {
                            switch (sRecipeintLine)
                            {
                                case "Required":
                                    oAttendee = oAppointment.RequiredAttendees.Add(sRecipientName, sSmtpAddress);
                                    break;
                                case "Optional":
                                    oAttendee = oAppointment.OptionalAttendees.Add(sRecipientName, sSmtpAddress);
                                    break;
                                case "Resource":
                                    oAttendee = oAppointment.Resources.Add(sRecipientName, sSmtpAddress);
                                    break;
                            }
                        }
                    }
                    else
                    {
                        if (sSmtpAddress.Length != 0)
                        {
                            switch (sRecipeintLine)
                            {
                                case "Required":
                                    oAttendee = oAppointment.RequiredAttendees.Add(sSmtpAddress);
                                    break;
                                case "Optional":
                                    oAttendee = oAppointment.OptionalAttendees.Add(sSmtpAddress);
                                    break;
                                case "Resource":
                                    oAttendee = oAppointment.Resources.Add(sSmtpAddress);
                                    break;
                            }
                        }
                    }


                    oAttendee = null;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\r\n\r\nAddress: " + sCurrentAddress, "Error Parsing Address");
            }

            oAttendee = null;

            bRet = true;

            return bRet;

        }

    }
}
