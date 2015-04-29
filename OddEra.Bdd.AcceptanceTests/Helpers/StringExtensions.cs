using System.Globalization;

namespace OddEra.Bdd.AcceptanceTests.Helpers
{
    public static class StringExtensions
    {
        public static bool IsDefault(this string str)
        {
            return str.ToUpperInvariant().Equals("<DEFAULT>");
        }

        public static string ToAbsolute(this string str)
        {
            return RelativeDateFormatHelper.GetDate(str);
        }

        public static string With(this string format, params object[] args)
        {
            return string.Format(CultureInfo.InvariantCulture, format, args);
        }
    }
}
