using System;

namespace ExtendedSharp.Core.Extensions
{
    public static class IntExtensions
    {
        /// <summary>
        /// Returns a boolean indicating whether this Integer is an Odd number.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool IsOdd(this int i)
        {
            return (i % 2) != 0;
        }

        /// <summary>
        /// Returns a boolean indicating whether this Integer is an Even number.
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool IsEven(this int i)
        {
            return (i % 2) == 0;
        }

        /// <summary>
        /// Iterates from the Int through the specified stopAt and calls the specified Action for each passing in the iterator.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="stopAt"></param>
        /// <param name="action"></param>
        public static void UpTo(this int i, int stopAt, Action<int> action)
        {
            for (var a = i; a <= stopAt; a++)
            {
                action(a);
            }
        }

        /// <summary>
        /// Returns a boolean value indicating that the integer is "between" the low and high values specified. Ex: 1 is between 0 and 2, but 0 or 2 are not.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        public static bool Between(this int i, int low, int high)
        {
            return i > low && i < high;
        }

    }
}
