//using Microsoft.Exchange.WebServices.Data;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using EWSEditor.DataChecks.Calendar;
//using static EWSEditor.DataChecks.Calendar.CalendarCheckGlobals;
//using static EWSEditor.DataChecks.Calendar.CalendarCheckUtils;
//using static EWSEditor.DataChecks.Calendar.CalendarCheckPropSet;
//using static EWSEditor.DataChecks.Calendar.CalendarCheckProcess;
 

//namespace EWSEditor.DataChecks.Calendar
//{
//    public class CalendarCheckPropSet
//    {
//        public static bool DoProps(ref List<ExtendedPropertyDefinition> epdProps)
//        {
//            bool bSuccess = true;

//            epdProps = new List<ExtendedPropertyDefinition>();
//            ExtendedPropertyDefinition extProp = null;
//            int iTag = 0;
//            MapiPropertyType mpType = MapiPropertyType.Null;
//            int Bound0 = rgProps.GetUpperBound(0);

//            for (int i = 0; i < Bound0; i++)
//            {
//                mpType = GetPropType(rgProps[i, 1]);

//                if (rgProps[i, 0] == "") // for string values that have no pTag
//                {
//                    string strGUID = GetGUIDFromSetID(rgProps[i, 2]);
//                    string strProp = rgProps[i, 3];
//                    extProp = new ExtendedPropertyDefinition(new Guid(strGUID), strProp, mpType);
//                }
//                else // all others that have pTags
//                {
//                    iTag = Convert.ToInt32(rgProps[i, 0], 16);

//                    if (rgProps[i, 2] == "") // If Not a Named Prop
//                    {
//                        extProp = new ExtendedPropertyDefinition(iTag, mpType);
//                    }
//                    else // else it is a named prop
//                    {
//                        string strGUID = GetGUIDFromSetID(rgProps[i, 2]);
//                        extProp = new ExtendedPropertyDefinition(new Guid(strGUID), iTag, mpType);
//                    }
//                }
//                epdProps.Add(extProp);
//            }
//            return bSuccess;
//        }

//        private static string[,] rgProps = new string[,]
//        {
//            {"001A", "String", "", "PR_MESSAGE_CLASS"},
//            {"0037", "String", "", "PR_SUBJECT_W"},
//            {"0042", "String", "", "PR_SENT_REPRESENTING_NAME_W"},
//            {"0065", "String", "", "PR_SENT_REPRESENTING_EMAIL_ADDRESS_W"},
//            {"0064", "String", "", "PR_SENT_REPRESENTING_ADDRTYPE_W"},
//            {"0C1A", "String", "", "PR_SENDER_NAME_W"},
//            {"0C1F", "String", "", "PR_SENDER_EMAIL_ADDRESS_W"},
//            {"3008", "SystemTime", "", "PR_LAST_MODIFICATION_TIME"},
//            {"3FF8", "String", "", "PR_LAST_MODIFIER_NAME_W"},
//            {"0FFF", "Binary", "", "PR_ENTRYID"},
//            {"0E08", "Integer", "", "PR_MESSAGE_SIZE"},
//            {"0E06", "SystemTime", "", "PR_MESSAGE_DELIVERY_TIME"},
//            {"0E1B", "Boolean", "", "PR_HASATTACH"},
//            {"0E17", "Integer", "", "PR_MSG_STATUS"},
//            {"3007", "SystemTime", "", "PR_CREATION_TIME"},
//            {"0003", "Binary", "PSETID_Meeting", "PidLidGlobalObjectId"},
//            {"0005", "Boolean", "PSETID_Meeting", "PidLidIsRecurring"},
//            {"0023", "Binary", "PSETID_Meeting", "PidLidCleanGlobalObjectId"},
//            {"000A", "Boolean", "PSETID_Meeting", "PidLidIsException"},
//            {"8223", "Boolean", "PSETID_Appointment", "dispidRecurring"},
//            {"8231", "Integer", "PSETID_Appointment", "dispidRecurType"},
//            {"820D", "SystemTime", "PSETID_Appointment", "dispidApptStartWhole"},
//            {"820E", "SystemTime", "PSETID_Appointment", "dispidApptEndWhole"},
//            {"8217", "Integer", "PSETID_Appointment", "dispidApptStateFlags"},
//            {"8208", "String", "PSETID_Appointment", "dispidLocation"},
//            {"8234", "String", "PSETID_Appointment", "dispidTimeZoneDesc"},
//            {"8215", "Boolean", "PSETID_Appointment", "dispidApptSubType"},
//            {"8216", "Binary", "PSETID_Appointment", "dispidApptRecur"},
//            {"8207", "Integer", "PSETID_Appointment", "dispidApptAuxFlags"},
//            {"8233", "Binary", "PSETID_Appointment", "dispidTimeZoneStruct"},
//            {"825E", "Binary", "PSETID_Appointment", "dispidApptTZDefStartDisplay"},
//            {"825F", "Binary", "PSETID_Appointment", "dispidApptTZDefEndDisplay"},
//            {"8260", "Binary", "PSETID_Appointment", "dispidApptTZDefRecur"},
//            {"8540", "Binary", "PSETID_Common", "dispidPropDefStream"}
//        };

//        public static string[,] RgProps { get => rgProps; set => rgProps = value; }


//        private static string[,] rgGUIDS = new string[,]
//        {
//            {"{11000E07-B51B-40D6-AF21-CAA85EDAB1D0}", "PSETID_CalendarAssistant" },
//            {"{6ED8DA90-450B-101B-98DA-00AA003F1305}", "PSETID_Meeting" },
//            {"{00062002-0000-0000-C000-000000000046}", "PSETID_Appointment" },
//            {"{00020329-0000-0000-C000-000000000046}", "PS_PUBLIC_STRINGS" },
//            {"{00062008-0000-0000-C000-000000000046}", "PSETID_Common" }
//        };

//        public static string GetPropNameFromTag(string strTag, string strSetID)
//        {
//            string strOut = "";
//            int Bound0 = rgProps.GetUpperBound(0);

//            for (int i = 0; i <= Bound0; i++)
//            {
//                if (strTag == rgProps[i, 0])
//                {
//                    if (strSetID == rgProps[i, 2])
//                    {
//                        strOut = rgProps[i, 3];
//                        break;
//                    }
//                }
//            }
//            return strOut;
//        }

//        public static string GetSetIDFromGUID(string strGUID)
//        {
//            string strOut = "";
//            int Bound0 = rgGUIDS.GetUpperBound(0);

//            for (int i = 0; i <= Bound0; i++)
//            {
//                if (strGUID.ToUpper() == rgGUIDS[i, 0])
//                {
//                    strOut = rgGUIDS[i, 1];
//                    break;
//                }
//            }
//            return strOut;
//        }

//        public static string GetGUIDFromSetID(string strSetID)
//        {
//            string strOut = "";
//            int Bound0 = rgGUIDS.GetUpperBound(0);

//            for (int i = 0; i <= Bound0; i++)
//            {
//                if (strSetID == rgGUIDS[i, 1])
//                {
//                    strOut = rgGUIDS[i, 0];
//                    break;
//                }
//            }
//            return strOut;
//        }

//        public static MapiPropertyType GetPropType(string strProp)
//        {
//            MapiPropertyType mpType = MapiPropertyType.Null;

//            switch (strProp.ToUpper())
//            {
//                case "INTEGER":
//                    mpType = MapiPropertyType.Integer;
//                    break;
//                case "STRING":
//                    mpType = MapiPropertyType.String;
//                    break;
//                case "BINARY":
//                    mpType = MapiPropertyType.Binary;
//                    break;
//                case "LONG":
//                    mpType = MapiPropertyType.Long;
//                    break;
//                case "BOOLEAN":
//                    mpType = MapiPropertyType.Boolean;
//                    break;
//                case "SYSTEMTIME":
//                    mpType = MapiPropertyType.SystemTime;
//                    break;
//                case "STRINGARRAY":
//                    mpType = MapiPropertyType.StringArray;
//                    break;

//                default:
//                    return MapiPropertyType.Null;
//            }
//            return mpType;
//        }
//    }
//}

