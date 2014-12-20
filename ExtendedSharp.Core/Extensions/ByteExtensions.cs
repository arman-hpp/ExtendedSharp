using System;

namespace ExtendedSharp.Core.Extensions
{
    public static class ByteExtensions
    {
        /// <summary>
        /// Converts an array of 8-bit unsigned integers to its equivalent string representation that is encoded with base-64 digits.
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ToBase64String(this byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }
    }
}
