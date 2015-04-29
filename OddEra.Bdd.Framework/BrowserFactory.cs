using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using System;
using System.Configuration;

namespace OddEra.Bdd.Framework
{
    public static class DriverFactory
    {
        private static readonly string baseUrl = ConfigurationManager.AppSettings["BaseUrl"] ?? "http://localhost/SomeApp";
        private static readonly string testBrowser = ConfigurationManager.AppSettings["TestBrowser"] ?? "InternetExplorer";
        private static readonly string fireFoxBinary = ConfigurationManager.AppSettings["FireFoxBinary"] ?? @"C:\Program Files (x86)\Mozilla";
        private static readonly int driverWaitTimeout = !string.IsNullOrEmpty(ConfigurationManager.AppSettings["Driver.WaitTimeoutSecs"]) ? Convert.ToInt32(ConfigurationManager.AppSettings["Driver.WaitTimeoutSecs"]) : 2;

        public static IWebDriver GetDriver()
        {
            switch (GetBrowserType())
            {
                case BrowserType.FireFox:
                    var fireFoxDriver = new FirefoxDriver(new FirefoxBinary(fireFoxBinary), new FirefoxProfile());
                    fireFoxDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(driverWaitTimeout));
                    fireFoxDriver.Manage().Window.Maximize();
                    return fireFoxDriver;
                case BrowserType.InternetExplorer:
                    InternetExplorerOptions internetExplorerOptions = new InternetExplorerOptions();
                    internetExplorerOptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    internetExplorerOptions.EnableNativeEvents = true;
                    InternetExplorerOptions internetExplorerOptions2 = internetExplorerOptions;
                    return new InternetExplorerDriver();
                case BrowserType.Chrome:
                    return new ChromeDriver();
                case BrowserType.PhantomJS:
                    return new PhantomJSDriver();
                default:
                    throw new InvalidOperationException("Browser type not supported");
            }
        }

        private static BrowserType GetBrowserType()
        {
            return (BrowserType)Enum.Parse(typeof(BrowserType), testBrowser, true);
        }
    }
}
