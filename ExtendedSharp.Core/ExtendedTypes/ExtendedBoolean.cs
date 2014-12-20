using System;

namespace ExtendedSharp.Core.ExtendedTypes
{
    public static class ExBoolean
    {
        public static bool Not(this bool val)
        {
            return !val;
        }

        public static bool And(this bool valueA, bool valueB)
        {
            return valueA && valueB;
        }

        public static bool Or(this bool valueA, bool valueB)
        {
            return valueA && valueB;
        }

        public static int ToBinary(this bool b)
        {
            return b ? 1 : 0;
        }

        public static bool IfTrue(this bool b, Action action)
        {
            if (b)
            {
                action();
            }
            return b;
        }

        public static bool IfFalse(this bool b, Action action)
        {
            if (!b)
            {
                action();
            }
            return b;
        }
    }
}
