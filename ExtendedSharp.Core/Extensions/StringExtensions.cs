using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

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

        /// <summary>
        /// Retuns a String that is a concatenation of the source String repeated the specified number of times.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="repeatCount">The number of times to repeat the String in the returned concatenation.</param>
        /// <returns></returns>
        public static string Repeat(this string s, int repeatCount)
        {
            if (repeatCount < 0)
            {
                throw new ArgumentOutOfRangeException("repeatCount", "repeatCount must be greater than zero.");
            }

            if (s.IsNull() || s.IsEmpty())
            {
                return s;
            }

            var sb = new StringBuilder();
            repeatCount.Times(i => sb.Append(s));
            return sb.ToString();
        }

        /// <summary>
        /// Returns an MD5 Hash from the specified string
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToMd5Hash(this string s)
        {
            using (var md5 = MD5.Create())
            {
                var bytes = s.ToByteArray();
                var hashBytes = md5.ComputeHash(bytes);
                var sb = new StringBuilder();
                hashBytes.Each(b => sb.Append(b.ToString("X2")));
                return sb.ToString();
            }
        }

        /// <summary>
        /// Returns a string containing a specified number of characters from the left side of a string.
        /// </summary>
        /// <param name="s">Required. String expression from which the leftmost characters are returned</param>
        /// <param name="length">Required. Integer expression. Numeric expression indicating how many characters to return. If 0, a zero-length string ("") is returned. If greater than or equal to the number of characters in str, the entire string is returned.</param>
        /// <returns>Returns a string containing a specified number of characters from the left side of a string.</returns>
        public static string Left(this string s, int length)
        {
            if (s.IsNullOrEmpty() || length > s.Length || length < 0)
                return s;

            return s.Substring(0, length);
        }

        /// <summary>
        /// Returns a string containing a specified number of characters from the right side of a string.
        /// </summary>
        /// <param name="s">Required. String expression from which the rightmost characters are returned.</param>
        /// <param name="length">Required. Integer. Numeric expression indicating how many characters to return. If 0, a zero-length string ("") is returned. If greater than or equal to the number of characters in str, the entire string is returned.</param>
        /// <returns>Returns a string containing a specified number of characters from the right side of a string.</returns>
        public static string Right(this string s, int length)
        {
            if (s.IsNullOrEmpty() || length > s.Length || length < 0)
                return s;

            return s.Substring(s.Length - length);
        }

        /// <summary>
        /// Returns the String HtmlEncoded.
        /// </summary>
        /// <param name="str">Required. The String to HtmlEncode.</param>
        /// <returns>Returns the String HtmlEncoded.</returns>
        public static string EncodeHtml(this string str)
        {
            return HttpUtility.HtmlEncode(str);
        }

        /// <summary>
        /// Returns the String HtmlDecoded.
        /// </summary>
        /// <param name="str">Required. The String to HtmlDecode.</param>
        /// <returns>Returns the String HtmlDecoded.</returns>
        public static string DecodeHtml(this string str)
        {
            return HttpUtility.HtmlDecode(str);
        }

        /// <summary>
        /// Returns the String UrlEncoded.
        /// </summary>
        /// <param name="str">Required. The String to UrlEncode.</param>
        /// <returns>Returns the String UrlEncoded.</returns>
        public static string EncodeUrl(this string str)
        {
            return HttpUtility.UrlEncode(str);
        }

        /// <summary>
        /// Returns the String UrlDecoded.
        /// </summary>
        /// <param name="str">Required. The String to UrlDecode.</param>
        /// <returns>Returns the String UrlDecoded.</returns>
        public static string DecodeUrl(this string str)
        {
            return HttpUtility.UrlDecode(str);
        }

        /// <summary>
        /// Returns the String Base64 Encoded.
        /// </summary>
        /// <param name="str">Required. The String to Base64 Encode.</param>
        /// <returns>Returns the String Base64 Encoded.</returns>
        public static string EncodeBase64(this string str)
        {
            return Convert.ToBase64String(str.ToByteArray<ASCIIEncoding>());
        }

        /// <summary>
        /// Returns the String Base64 Decoded.
        /// </summary>
        /// <param name="str">Required. The String to Base64 Decode.</param>
        /// <returns>Returns the String Base64 Decoded.</returns>
        public static string DecodeBase64(this string str)
        {
            return Encoding.ASCII.GetString(Convert.FromBase64String(str));
        }

        /// <summary>
        /// Returns a Byte Array of the String using the specified Encoding.
        /// </summary>
        /// <typeparam name="TEncoding">The character encoding to use to encode the String to a Byte Array.</typeparam>
        /// <param name="str">Required. The String to Convert to a Byte Array.</param>
        /// <returns>Returns a Byte Array of the String.</returns>
        public static byte[] ToByteArray<TEncoding>(this string str) where TEncoding : Encoding
        {
            Encoding enc = Activator.CreateInstance<TEncoding>();
            return enc.GetBytes(str);
        }

        /// <summary>
        /// Returns a Byte Array of the String using ASCIIEncoding.
        /// </summary>
        /// <param name="str">Required. The String to Convert to a Byte Array.</param>
        /// <returns>Returns a Byte Array of the String.</returns>
        public static byte[] ToByteArray(this string str)
        {
            return str.ToByteArray<ASCIIEncoding>();
        }

        /// <summary>
        /// Returns a Stream representation of the String using ASCIIEncoding.
        /// </summary>
        /// <param name="str">Required. The String to convert to a Stream.</param>
        /// <returns>Returns a Stream representation of the String.</returns>
        public static Stream ToStream(this string str)
        {
            return str.ToStream<ASCIIEncoding>();
        }

        /// <summary>
        /// Returns a Stream representation of the String using the specified Encoding.
        /// </summary>
        /// <typeparam name="TEncoding">The String Encoding Type to use.</typeparam>
        /// <param name="str">Required. The String to convert to a Stream.</param>
        /// <returns>Returns a Stream representation of the String.</returns>
        public static Stream ToStream<TEncoding>(this string str) where TEncoding : Encoding
        {
            return new MemoryStream(str.ToByteArray<TEncoding>());
        }

        /// <summary>
        /// Encrypts the String using the given Encryption Algorithm and key. Return value is also Base64 encoded.
        /// </summary>
        /// <typeparam name="TAlgorithm">The SymmetricAlgorithm type to use for Encryption.</typeparam>
        /// <param name="str">Required. The String to Encrypt.</param>
        /// <param name="key">The Encryption Key to use.</param>
        /// <param name="iv">Optional. The Initialization Vector for the symmetric algorithm</param>
        /// <returns>Returns the String Encrypted using the given Encryption Algorithm and key.</returns>
        public static string Encrypt<TAlgorithm>(this string str, string key, string iv = null)
            where TAlgorithm : SymmetricAlgorithm
        {
            using (var s = str.ToStream())
            {
                var encryptedStream = s.Encrypt<TAlgorithm>(key.ToByteArray(), iv != null ? iv.ToByteArray() : null);
                var bytes = encryptedStream.ToByteArray();
                return bytes.ToBase64String();
            }
        }

        /// <summary>
        /// Decrypts the Base64 encoded String using the given Encryption Algorithm and key.
        /// </summary>
        /// <typeparam name="TAlgorithm">The SymmetricAlgorithm type to use for Encryption.</typeparam>
        /// <param name="str">Required. The String to Dencrypt.</param>
        /// <param name="key">The Decryption Key.</param>
        /// <param name="iv">Optional. The Initialization Vector for the symmetric algorithm</param>
        /// <returns></returns>
        public static string Decrypt<TAlgorithm>(this string str, string key, string iv = null)
            where TAlgorithm : SymmetricAlgorithm
        {
            using (var s = new MemoryStream(Convert.FromBase64String(str)))
            {
                Stream decryptedStream = s.Decrypt<TAlgorithm>(key.ToByteArray(), iv != null ? iv.ToByteArray() : null);
                byte[] bytes = decryptedStream.ToByteArray();
                var enc = new ASCIIEncoding();
                return enc.GetString(bytes);
            }
        }

        /// <summary>
        /// Returns a boolean indicating whether the String is NULL, a System.String.Empty string or consists only of white-space characters.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        /// <summary>
        /// Returns a boolean indicating whether the String is NULL or a System.String.Empty string.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// Returns a boolean indicating whether the String is a System.String.Empty string.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsEmpty(this string str)
        {
            return str == string.Empty;
        }

        /// <summary>
        /// Returns a boolean indicating whether the String is a null string.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNull(this string str)
        {
            return str == string.Empty;
        }

        /// <summary>
        /// Strips out all instances of the specified string from the source string
        /// </summary>
        /// <param name="source">The source string</param>
        /// <param name="removeStrings"></param>
        /// <returns>The stripped string</returns>
        public static string RemoveAll(this string source, params string[] removeStrings)
        {
            var v = source;
            foreach (var s in removeStrings)
            {
                v = v.Replace(s, string.Empty);
            }
            return v;
        }


    }
}
