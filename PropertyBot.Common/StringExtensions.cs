using System;
using System.Globalization;

namespace PropertyBot.Common
{
    public static class StringExtensions
    {
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
            return int.Parse(s);
        }

        public static int ToIntSafe(this string s)
        {
            var germanCulture = new CultureInfo("de-DE");
            return int.TryParse(s?.Trim(), GetNumberStyles(), germanCulture , out var parsedResult) ? parsedResult : 0;
        }

        private static NumberStyles GetNumberStyles()
        {
            return NumberStyles.AllowCurrencySymbol | NumberStyles.Number;
        }

        public static double ToDoubleSafe(this string s)
        {

        }

        public static long ToLong(this string s)
        {
            return long.Parse(s);
        }
    }
}
