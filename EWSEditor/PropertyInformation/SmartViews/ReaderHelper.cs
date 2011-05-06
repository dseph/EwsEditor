using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EWSEditor.PropertyInformation.SmartViews
{
    public struct SYSTEMTIME
    {
        public UInt32 Year;
        public UInt32 Month;
        public UInt32 DayOfWeek;
        public UInt32 Day;
        public UInt32 Hour;
        public UInt32 Minute;
        public UInt32 Second;
        public UInt32 Milliseconds;
    }

    public class ReaderHelper
    {
        public static SYSTEMTIME ReadSystemTime(System.IO.BinaryReader reader)
        {
            SYSTEMTIME time = new SYSTEMTIME();

            time.Year = reader.ReadUInt16();
            time.Month = reader.ReadUInt16();
            time.DayOfWeek = reader.ReadUInt16();
            time.Day = reader.ReadUInt16();
            time.Hour = reader.ReadUInt16();
            time.Minute = reader.ReadUInt16();
            time.Second = reader.ReadUInt16();
            time.Milliseconds = reader.ReadUInt16();

            return time;
        }
    }
}