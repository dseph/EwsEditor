using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Exchange.WebServices.Data;

using EWSEditor.Common;

namespace EWSEditor.PropertyInformation.SmartViews
{
    public struct GlobalObjectIdStruct
    {
        public byte[] Id;
        public Int32 Year;
        public byte Month;
        public byte Day;
        public Int64 CreationTime;
        public Int64 X;
        public Int32 Size;
        public byte[] lpData;
        public byte[] Junk;
    }

    /// <summary>
    /// Display a smart view of properties based on GlobalObjectId such as:
    /// 
    /// PidLidGlobalObjectId
    /// http://msdn.microsoft.com/en-us/library/cc815676.aspx
    /// 
    /// PidLidCleanGlobalObjectId
    /// http://msdn.microsoft.com/en-us/library/cc839502.aspx
    /// </summary>
    public class GlobalObjectIdSmartView : ISmartView
    {
        public ExtendedPropertyDefinition[] SupportedProperties
        {
            get
            {
                return new ExtendedPropertyDefinition[] {
                    KnownExtendedProperties.Instance().PidLidGlobalObjectId,
                    KnownExtendedProperties.Instance().PidLidCleanGlobalObjectId
                };
            }
        }

        public string GetSmartView(object rawValue)
        {
            GlobalObjectIdStruct goidStruct = GetGlobalObjectIdStruct(rawValue as byte[]);

            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine("GlobalObjectId:");
            sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "Byte Array ID = c: {0} b: {1}", 
                goidStruct.Id.Length, 
                ConversionHelper.GetStringFromBytes(goidStruct.Id)));

            sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "Year = 0x{0}, {1}",
                ConversionHelper.GetBase16(goidStruct.Year),
                goidStruct.Year));

            sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "Month = 0x{0}, {1}",
                ConversionHelper.GetBase16(goidStruct.Month),
                goidStruct.Month));

            sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "Day = 0x{0}, {1}",
                ConversionHelper.GetBase16(goidStruct.Day),
                goidStruct.Day));

            sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "CreationTime = {0}, {1}", 
                goidStruct.CreationTime,
                System.DateTime.FromFileTimeUtc(goidStruct.CreationTime)));

            sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "X = {0}", 
                goidStruct.X));

            sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "Size = 0x{0}, {1}",
                ConversionHelper.GetBase16(goidStruct.Size),
                goidStruct.Size));

            sb.AppendLine(string.Format(System.Globalization.CultureInfo.CurrentCulture, "Data = c:{0} b: {1}",
                goidStruct.lpData.Length,
                ConversionHelper.GetStringFromBytes(goidStruct.lpData)));

            sb.AppendLine();

            return sb.ToString();
        }

        public static GlobalObjectIdStruct GetGlobalObjectIdStruct(byte[] rawValue)
        {
            System.IO.MemoryStream stream = new System.IO.MemoryStream(rawValue);
            System.IO.BinaryReader reader = new System.IO.BinaryReader(stream);

            GlobalObjectIdStruct goid = new GlobalObjectIdStruct();

            goid.Id = reader.ReadBytes(16);
            byte b1 = reader.ReadByte();
            byte b2 = reader.ReadByte();
            goid.Year = ((b1 << 8) | b2);
            goid.Month = reader.ReadByte();
            goid.Day = reader.ReadByte();
            goid.CreationTime = reader.ReadInt64();
            goid.X = reader.ReadInt64();
            goid.Size = reader.ReadInt32();
            goid.lpData = reader.ReadBytes((int)goid.Size);

            // Junk data is all that is left
            List<byte> junk = new List<byte>();
            while (reader.PeekChar() > 0)
            {
                junk.Add(reader.ReadByte());
            }
            goid.Junk = junk.ToArray();

            return goid;
        }
    }
}
