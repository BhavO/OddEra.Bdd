using System.Configuration;

namespace OddEra.Bdd.AcceptanceTests
{
    public static class AppSettings
    {
        public static string ThreadCulture
        {
            get { return ConfigurationManager.AppSettings["ThreadCulture"] ?? "en-GB"; }
        }
    }
}
