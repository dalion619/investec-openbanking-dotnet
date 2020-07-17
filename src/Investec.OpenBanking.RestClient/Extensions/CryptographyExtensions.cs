using System;
using System.Security.Cryptography;
using System.Text;

namespace Investec.OpenBanking.RestClient.Extensions
{
    public static class CryptographyExtensions
    {
        private static Encoding _defaultEncoding => Encoding.UTF8;

        public static Guid ToMd5Guid(this string value) => new Guid(GetMd5Hash(value));

        public static byte[] GetMd5Hash(string input)
        {
            using (var md5 = MD5.Create())
            {
                var inputBytes = _defaultEncoding.GetBytes(input);
                return md5.ComputeHash(inputBytes);
            }
        }
    }
}