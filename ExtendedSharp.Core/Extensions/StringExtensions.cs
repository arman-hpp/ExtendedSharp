using System;
using System.Text.RegularExpressions;

namespace ExtendedSharp.Core.Extensions
{
    public static class StringExtensions
    {
        public static string TrimAndReduce(this string str)
        {
            return ConvertWhitespacesToSingleSpaces(str).Trim();
        }

        public static string ConvertWhitespacesToSingleSpaces(this string value)
        {
            return Regex.Replace(value, @"\s+", " ");
        }

        public static string Reverse(this string input)
        {
            var chars = input.ToCharArray();
            Array.Reverse(chars);
            return new String(chars);
        }
    }
}
