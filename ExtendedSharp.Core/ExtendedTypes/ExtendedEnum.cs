using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedSharp.Core.ExtendedTypes
{
    public static class ExtendedEnum
    {
        public static int GetValue(this Enum value)
        {
            return Convert.ToInt32(value);
        }
    }
}
