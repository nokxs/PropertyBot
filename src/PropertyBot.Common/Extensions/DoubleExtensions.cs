﻿using System.Globalization;

namespace PropertyBot.Common.Extensions
{
    public static class DoubleExtensions
    {
        public static string Format(this double d)
        {
            var cultureInfo = new CultureInfo("de-DE");
            return d.ToString("#,#.##", cultureInfo);
        }
    }
}
