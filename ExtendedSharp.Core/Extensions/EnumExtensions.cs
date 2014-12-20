using System;
using System.ComponentModel;
using System.Linq;

namespace ExtendedSharp.Core.Extensions
{
    public static class EnumExtensions
    {
        public static int GetValue(this Enum value)
        {
            return Convert.ToInt32(value);
        }

        public static string ToDescriptionString(this Enum value)
        {
            var attr =
                value.GetType()
                    .GetField(value.ToString())
                    .GetCustomAttributes(typeof (DescriptionAttribute), false)
                    .FirstOrDefault() as DescriptionAttribute;
            return (attr != null) ? attr.Description : value.ToString();
        }
    }
}
