using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Exchange.WebServices.Data;

using EWSEditor.Common;

namespace EWSEditor.PropertyInformation.SmartViews
{
    public struct TZDEFINITION
    {
        public byte MajorVersion;
        public byte MinorVersion;
        public UInt32 HeaderLength;
        public UInt32 Reserved;
        public UInt32 KeyNameLength;
        public string Keyname;
        public UInt32 RulesCount;
        public TZRULE[] TZRules;
        public byte[] Junk;
    }

    public struct TZRULE
    {
        public byte MajorVersion;
        public byte MinorVersion;
        public UInt32 Reserved;
        public UInt32 TZRuleFlags;
        public byte[] X;
        public UInt32 Year;
        public Int32 Bias;
        public Int32 StandardBias;
        public Int32 DaylightBias;
        public SYSTEMTIME StandardDate;
        public SYSTEMTIME DaylightDate;
    }

    /// <summary>
    /// Display a smart view of PidLidNoteColor based on
    /// http://msdn.microsoft.com/en-us/library/cc815603.aspx
    /// </summary>
    public class TzDefinitionSmartView : ISmartView
    {
        private const int TZ_MAX_RULES = 50;

        public ExtendedPropertyDefinition[] SupportedProperties
        {
            get
            {
                return new ExtendedPropertyDefinition[] {
                    KnownExtendedProperties.Instance().PidLidAppointmentTimeZoneDefinitionStartDisplay,
                    KnownExtendedProperties.Instance().PidLidAppointmentTimeZoneDefinitionEndDisplay,
                    KnownExtendedProperties.Instance().PidLidAppointmentTimeZoneDefinitionRecur
                };
            }
        }

        public string GetSmartView(object rawValue)
        {

            TZDEFINITION def = GetTZDefinition(rawValue as byte[]);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Time Zone Definition:");
            sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "MajorVersion = {0}", def.MajorVersion));
            sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "MinorVersion = {0}", def.MinorVersion));
            sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "HeaderLength = {0}", def.HeaderLength));
            sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "Reserved = {0}", def.Reserved));
            sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "KeyName = {0}", def.Keyname));
            sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "KeyNameLength = {0}", def.KeyNameLength));
            sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "RulesCount = {0}", def.RulesCount));
            sb.AppendLine();

            for (int i = 0;i < def.RulesCount;i++)
            {
                sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "TZRule[{0}].MajorVersion = {1}",
                    ConversionHelper.GetBase16(i),
                    def.TZRules[i].MajorVersion));

                sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "TZRule[{0}].MinorVersion = {1}",
                    ConversionHelper.GetBase16(i),
                    def.TZRules[i].MinorVersion));

                sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "TZRule[{0}].Reserved = {1}",
                    ConversionHelper.GetBase16(i),
                    def.TZRules[i].Reserved));

                sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "TZRule[{0}].TZRuleFlags = {1}",
                    ConversionHelper.GetBase16(i),
                    def.TZRules[i].TZRuleFlags));

                sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "TZRule[{0}].Year = {1}",
                    ConversionHelper.GetBase16(i),
                    def.TZRules[i].Year));

                sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "TZRule[{0}].X = c:{1} b:{2}",
                    ConversionHelper.GetBase16(i),
                    def.TZRules[i].X.Length,
                    ConversionHelper.GetStringFromBytes(def.TZRules[i].X)));

                sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "TZRule[{0}].Bias = {1}",
                    ConversionHelper.GetBase16(i),
                    def.TZRules[i].Bias));

                sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "TZRule[{0}].StandardBias = {1}",
                    ConversionHelper.GetBase16(i),
                    def.TZRules[i].StandardBias));

                sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "TZRule[{0}].DaylightBias = {1}",
                    ConversionHelper.GetBase16(i),
                    def.TZRules[i].DaylightBias));
                sb.AppendLine();

                sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "TZRule[{0}].StandardDate.Year = {1}",
                    ConversionHelper.GetBase16(i),
                    def.TZRules[i].StandardDate.Year));

                sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "TZRule[{0}].StandardDate.Month = {1}",
                    ConversionHelper.GetBase16(i),
                    def.TZRules[i].StandardDate.Month));

                sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "TZRule[{0}].StandardDate.DayOfWeek = {1}",
                    ConversionHelper.GetBase16(i),
                    def.TZRules[i].StandardDate.DayOfWeek));

                sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "TZRule[{0}].StandardDate.Day = {1}",
                    ConversionHelper.GetBase16(i),
                    def.TZRules[i].StandardDate.Day));

                sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "TZRule[{0}].StandardDate.Hour = {1}",
                    ConversionHelper.GetBase16(i),
                    def.TZRules[i].StandardDate.Hour));

                sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "TZRule[{0}].StandardDate.Minute = {1}",
                    ConversionHelper.GetBase16(i),
                    def.TZRules[i].StandardDate.Minute));

                sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "TZRule[{0}].StandardDate.Second = {1}",
                    ConversionHelper.GetBase16(i),
                    def.TZRules[i].StandardDate.Second));

                sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "TZRule[{0}].StandardDate.Milliseconds = {1}",
                    ConversionHelper.GetBase16(i),
                    def.TZRules[i].StandardDate.Milliseconds));
                sb.AppendLine();

                sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "TZRule[{0}].DaylightDate.Year = {1}",
                    ConversionHelper.GetBase16(i),
                    def.TZRules[i].DaylightDate.Year));

                sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "TZRule[{0}].DaylightDate.Month = {1}",
                    ConversionHelper.GetBase16(i),
                    def.TZRules[i].DaylightDate.Month));

                sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "TZRule[{0}].DaylightDate.DayOfWeek = {1}",
                    ConversionHelper.GetBase16(i),
                    def.TZRules[i].DaylightDate.DayOfWeek));

                sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "TZRule[{0}].DaylightDate.Day = {1}",
                    ConversionHelper.GetBase16(i),
                    def.TZRules[i].DaylightDate.Day));

                sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "TZRule[{0}].DaylightDate.Hour = {1}",
                    ConversionHelper.GetBase16(i),
                    def.TZRules[i].DaylightDate.Hour));

                sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "TZRule[{0}].DaylightDate.Minute = {1}",
                    ConversionHelper.GetBase16(i),
                    def.TZRules[i].DaylightDate.Minute));

                sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "TZRule[{0}].DaylightDate.Second = {1}",
                    ConversionHelper.GetBase16(i),
                    def.TZRules[i].DaylightDate.Second));

                sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "TZRule[{0}].DaylightDate.Milliseconds = {1}",
                    ConversionHelper.GetBase16(i),
                    def.TZRules[i].DaylightDate.Milliseconds));
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public static TZDEFINITION GetTZDefinition(byte[] rawValue)
        {
            System.IO.MemoryStream stream = new System.IO.MemoryStream(rawValue);
            System.IO.BinaryReader reader = new System.IO.BinaryReader(stream);

            TZDEFINITION def = new TZDEFINITION();
            def.MajorVersion = reader.ReadByte();
            def.MinorVersion = reader.ReadByte();
            def.HeaderLength = reader.ReadUInt16();
            def.Reserved = reader.ReadUInt16();
            def.KeyNameLength = reader.ReadUInt16();

            byte[] keyNameBytes = reader.ReadBytes((int)def.KeyNameLength * 2);
            UnicodeEncoding encoding = new UnicodeEncoding();
            def.Keyname = encoding.GetString(keyNameBytes);
            def.RulesCount = reader.ReadUInt16();

            if (def.RulesCount > 0 && def.RulesCount < TZ_MAX_RULES)
            {
                def.TZRules = new TZRULE[def.RulesCount];
            }

            if (def.TZRules != null)
            {
                for (int i = 0; i < def.RulesCount; i++)
                {
                    def.TZRules[i].MajorVersion = reader.ReadByte();
                    def.TZRules[i].MinorVersion = reader.ReadByte();
                    def.TZRules[i].Reserved = reader.ReadUInt16();
                    def.TZRules[i].TZRuleFlags = reader.ReadUInt16();
                    def.TZRules[i].Year = reader.ReadUInt16();
                    def.TZRules[i].X = reader.ReadBytes(14);
                    def.TZRules[i].Bias = reader.ReadInt32();
                    def.TZRules[i].StandardBias = reader.ReadInt32();
                    def.TZRules[i].DaylightBias = reader.ReadInt32();
                    def.TZRules[i].StandardDate = ReaderHelper.ReadSystemTime(reader);
                    def.TZRules[i].DaylightDate = ReaderHelper.ReadSystemTime(reader);
                }
            }

            // Junk data is all that is left
            List<byte> junk = new List<byte>();
            while (reader.PeekChar() > 0)
            {
                junk.Add(reader.ReadByte());
            }
            def.Junk = junk.ToArray();

            return def;
        }
    }
}
