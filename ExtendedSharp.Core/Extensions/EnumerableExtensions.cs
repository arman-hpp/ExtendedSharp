using System.Collections.Generic;

namespace ExtendedSharp.Core.Extensions
{
    public static class EnumerableExtensions
    {
        public static string ToDelimString(this IEnumerable<string> arr, string delim = ",")
        {
            var ans = "";
            var Enum = arr.GetEnumerator();
            Enum.MoveNext();
            while (Enum.Current != null)
            {
                ans += Enum.Current;
                if (Enum.MoveNext())
                    ans += delim;
                else
                    break;
            }
            return ans;
        }
    }
}