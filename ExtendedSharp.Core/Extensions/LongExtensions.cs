using System;

namespace ExtendedSharp.Core.Extensions
{
    public static class LongExtensions
    {
        /// <summary>
        /// Converts a Unix Time Stamp (long / Int64 representing the number of seconds since Jan 1, 1970) to a DateTime
        /// </summary>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public static DateTime ConvertFromUnixTimestamp(this long timestamp)
        {
            var dt = new DateTime(1970, 1, 1);
            return dt.AddSeconds(timestamp);
        }
    }
}
