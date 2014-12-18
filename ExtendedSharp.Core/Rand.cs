using System;

namespace ExtendedSharp.Core
{
    public static class Rand
    {
        public static double NextF(double minValue, double maxValue)
        {
            var random = new Random(Guid.NewGuid().GetHashCode());
            return random.NextDouble() * (maxValue - minValue) + minValue;
        }

        public static int Next(int minValue, int maxValue)
        {
            var random = new Random(Guid.NewGuid().GetHashCode());
            return random.Next(minValue, maxValue + 1);
        }
    }
}
