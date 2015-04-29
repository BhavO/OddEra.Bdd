using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace OddEra.Bdd.AcceptanceTests.Helpers
{
    public static class RelativeDateFormatHelper
    {
        private const string TodayFormat = "<SYSDATE>";
        private const string RelativeFormat = @"<\s*SYSDATE\s*(?<operation>[+-])\s*(?<days>\d+)\s*DAYS\s*>";
        private static Regex relativeFormatRegex = new Regex(RelativeFormat);

        internal static string GetDate(string fromDate)
        {
            fromDate = fromDate.ToUpperInvariant();
            if (fromDate.Equals(TodayFormat))
            {
                return DateFormat(DateTime.UtcNow);
            }
            else
            {
                return DateFormat(GetRelativeDate(fromDate));
            }
        }

        private static DateTime GetRelativeDate(string dateTime)
        {
            var match = GetMatch(dateTime);
            if (match.Success)
            {
                if (match.Groups["operation"].ToString().Equals("+"))
                {
                    return DateTime.UtcNow.AddDays(Convert.ToInt32(match.Groups["days"].ToString()));
                }
                if (match.Groups["operation"].ToString().Equals("-"))
                {
                    return DateTime.UtcNow.AddDays(-Convert.ToInt32(match.Groups["days"].ToString()));
                }
            }

            return DateTime.UtcNow;
        }

        private static Match GetMatch(string dateTime)
        {
            return relativeFormatRegex.Match(dateTime);
        }

        private static string DateFormat(DateTime date)
        {
            return date.ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo(AppSettings.ThreadCulture));
        }

        internal static bool IsRelative(string dateTime)
        {
            dateTime = dateTime.ToUpperInvariant();
            return GetMatch(dateTime).Success || dateTime.Equals(TodayFormat);
        }
    }
}
