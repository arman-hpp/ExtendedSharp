using System.Text.RegularExpressions;

namespace ExtendedSharp.Core.ExtendedTypes
{
    public static class ExtendedString
    {
        public static string TrimAndReduce(this string str)
        {
            return ConvertWhitespacesToSingleSpaces(str).Trim();
        }

        public static string ConvertWhitespacesToSingleSpaces(this string value)
        {
            return Regex.Replace(value, @"\s+", " ");
        }
    }
}
