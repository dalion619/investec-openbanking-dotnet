using System;
using System.Linq;

namespace Investec.OpenBanking.RestClient.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        ///     Converts a string to sentence case.
        /// </summary>
        /// <param name="input">The string to convert.</param>
        /// <returns>A string</returns>
        public static string SentenceCase(this string input)
        {
            if (input.Length < 1)
            {
                return input;
            }

            var sentence = input.ToLower();
            var parts = sentence.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            for (var i = 0; i < parts.Length; i++)
            {
                parts[i] = parts[i][0].ToString().ToUpper() +
                           parts[i].Substring(1);
            }

            return string.Join(" ", parts);
        }

        /// <summary>
        ///     Removes non digits.
        /// </summary>
        /// <param name="str">String to sanitize.</param>
        public static string RemoveNonDigits(this string str) =>
            $"{new string(Array.FindAll(str.ToArray(), c => char.IsDigit(c)))}";
    }
}