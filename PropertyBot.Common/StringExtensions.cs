using System;

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

        public static long ToLong(this string s)
        {
            return long.Parse(s);
        }
    }
}
