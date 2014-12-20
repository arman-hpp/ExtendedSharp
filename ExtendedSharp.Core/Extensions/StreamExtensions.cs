using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedSharp.Core.Extensions
{
    public static class StreamExtensions
    {
        /// <summary>
        /// Returns an MD5 Hash from the Stream.
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static string ToMd5Hash(this Stream stream)
        {
            using (var md5 = MD5.Create())
            {
                var hashBytes = md5.ComputeHash(stream);
                var sb = new StringBuilder();
                hashBytes.Each(b => sb.Append(b.ToString("X2")));
                return sb.ToString();
            }
        }

        /// <summary>
        /// Returns a read-only Encrypted stream from the original stream using the specified Algorithm.
        /// </summary>
        /// <typeparam name="TAlgorithm">The SymmetricAlgorithm to use for Encryption</typeparam>
        /// <param name="stream">Required. The stream to Encrypt</param>
        /// <param name="key">Required. The Encryption Key</param>
        /// <param name="iv">Optional. The Initialization Vector for the symmetric algorithm</param>
        /// <returns>Returns a read-only cryptographic stream from the original stream.</returns>
        public static Stream Encrypt<TAlgorithm>(this Stream stream, byte[] key, byte[] iv = null)
            where TAlgorithm : SymmetricAlgorithm
        {
            var alg = Activator.CreateInstance<TAlgorithm>();
            alg.Key = key;
            alg.IV = iv ?? key;
            ICryptoTransform encryptor = alg.CreateEncryptor();
            return new CryptoStream(stream, encryptor, CryptoStreamMode.Read);
        }

        /// <summary>
        /// Returns a read-only Decrypted stream from the original stream using the specified Algorithm.
        /// </summary>
        /// <typeparam name="TAlgorithm"></typeparam>
        /// <param name="stream"></param>
        /// <param name="key"></param>
        /// /// <param name="iv">Optional. The Initialization Vector for the symmetric algorithm</param>
        /// <returns></returns>
        public static Stream Decrypt<TAlgorithm>(this Stream stream, byte[] key, byte[] iv = null)
            where TAlgorithm : SymmetricAlgorithm
        {
            var alg = Activator.CreateInstance<TAlgorithm>();
            alg.Key = key;
            alg.IV = iv ?? key;
            var encryptor = alg.CreateDecryptor();
            return new CryptoStream(stream, encryptor, CryptoStreamMode.Read);
        }

        /// <summary>
        /// Returns a Byte Array containing the contents of the Stream.
        /// </summary>
        /// <param name="stream">Required. The Stream to convert to a Byte Array.</param>
        /// <returns>Returns a Byte Array containing the contents of the Stream.</returns>
        public static byte[] ToByteArray(this Stream stream)
        {
            var buffer = new byte[1000];
            var readLength = 1;
            using (var ms = new MemoryStream())
            {
                while (readLength > 0)
                {
                    readLength = stream.Read(buffer, 0, buffer.Length);
                    if (readLength > 0)
                        ms.Write(buffer, 0, readLength);
                }
                return ms.ToArray();
            }
        }
    }
}
