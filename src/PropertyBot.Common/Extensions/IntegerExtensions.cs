namespace PropertyBot.Common.Extensions
{
    public static class IntegerExtensions
    {
        public static string ToSetString(this int i)
        {
            return i == 0 ? string.Empty : i.ToString();
        }
    }
}
