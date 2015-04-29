using System.Collections.Generic;

namespace OddEra.Bdd.AcceptanceTests.Helpers
{
    public static class DateFormatToRegexMapping
    {
        private static IDictionary<string, string> mapping = new Dictionary<string, string>();

        static DateFormatToRegexMapping()
        {
            mapping.Add("DD/MM/YYYY HH:MM:SS", "[0-9]{1,2}[/][0-9]{1,2}[/][0-9]{1,4} [0-9]{1,2}:[0-9]{1,2}:[0-9]{1,2}");
            mapping.Add("DD/MM/YYYY", "[0-9]{1,2}[/][0-9]{1,2}[/][0-9]{1,4}");
            mapping.Add("HH:MM:SS", "[0-9]{1,2}:[0-9]{1,2}:[0-9]{1,2}");
        }

        public static string GetRegexForDateFormat(string dateFormat)
        {
            return mapping[dateFormat.ToUpperInvariant()];
        }
    }
}
