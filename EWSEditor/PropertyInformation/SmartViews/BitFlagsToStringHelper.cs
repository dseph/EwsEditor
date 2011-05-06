using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EWSEditor.PropertyInformation.SmartViews
{
    internal struct BitFlagDefinition
    {
        internal readonly string FlagName;
        internal readonly int FlagValue;

        internal BitFlagDefinition(int value, string name)
        {
            FlagName = name;
            FlagValue = value;
        }
    }

    /// <summary>
    /// This simple helper function standardizes the way that bitmasks are displayed
    /// in EWSEditor.  The caller passes the value as well as an array of flag
    /// mappings to display strings and this function converts the value to output.
    /// </summary>
    internal class BitFlagsToStringHelper
    {
        internal static string ToString(int value, BitFlagDefinition[] flags)
        {
            StringBuilder output = new StringBuilder();

            foreach (BitFlagDefinition flag in flags)
            {
                if ((value & flag.FlagValue)> 0)
                {
                    if (output.Length > 0)
                    {
                        output.Append(string.Format(System.Globalization.CultureInfo.CurrentCulture, " | {0}", flag.FlagName));
                    }
                    else
                    {
                        output.Append(flag.FlagName);
                    }
                }
            }

            return string.Format(System.Globalization.CultureInfo.CurrentCulture, "Flags: {0}", output.ToString());
        }
    }
}
