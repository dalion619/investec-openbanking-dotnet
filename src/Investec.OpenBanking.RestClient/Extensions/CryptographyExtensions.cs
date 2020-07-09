using System;
using System.Text;

namespace Investec.OpenBanking.RestClient.Extensions
{
    public static class CryptographyExtensions
    {
        private static Encoding _defaultEncoding => Encoding.UTF8;

        public static Guid ToMd5Guid(this string value)
        {
            return new Guid(GetMd5Hash(value));
        }

        public static byte[] GetMd5Hash(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = _defaultEncoding.GetBytes(input);
                return md5.ComputeHash(inputBytes);
            }
        }
    }
}