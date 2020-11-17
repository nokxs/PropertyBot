using System;
using System.Globalization;

namespace PropertyBot.Common.Extensions
{
    public static class StringExtensions
    {
        private static readonly CultureInfo GermanCulture = new CultureInfo("de-DE");

        public static string GetAsMandatoryEnvironmentVariable(this string variable)
        {
            return Environment.GetEnvironmentVariable(variable) ?? throw new ArgumentException($"The mandatory environment variable {variable} is not set.");
        }

        public static string GetAsOptionalEnvironmentVariable(this string variable, string defaultValue)
        {
            return Environment.GetEnvironmentVariable(variable) ?? defaultValue;
        }

        public static int ToInt(this string s)
        {
            return int.Parse(s.Trim(), GetNumberStyles(), GermanCulture);
        }

        public static int ToIntSafe(this string s)
        {
            return int.TryParse(s?.Trim(), GetNumberStyles(), GermanCulture , out var parsedResult) ? parsedResult : 0;
        }

        public static long ToLong(this string s)
        {
            return long.Parse(s.Trim(), GetNumberStyles(), GermanCulture);
        }

        public static double ToDoubleSafe(this string s)
        {
            return double.TryParse(s?.Trim(), GetNumberStyles(), GermanCulture, out var parsedResult) ? parsedResult : 0;
        }

        public static string RemoveRNT(this string s)
        {
            return s?
                   .Replace("\r", string.Empty)
                   .Replace("\n", string.Empty)
                   .Replace("\t", string.Empty)
                   .Trim()
                    ?? string.Empty;
        }

        public static string RemoveContent(this string s, params string[] contents)
        {
            var returnString = s;

            foreach (var content in contents)
            {
                returnString = returnString.Replace(content, string.Empty);
            }

            return returnString;
        }

        private static NumberStyles GetNumberStyles()
        {
            return NumberStyles.AllowCurrencySymbol | NumberStyles.Number;
        }
    }
}
