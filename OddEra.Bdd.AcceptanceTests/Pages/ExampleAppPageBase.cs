using OddEra.Bdd.Framework;
using OpenQA.Selenium;
using System.Configuration;

namespace OddEra.Bdd.AcceptanceTests.Pages
{
    public abstract class ExampleAppPageBase : PageBase
    {
        private string ExampleAppHomePageLoginUrlTemaplte = ConfigurationManager.AppSettings["ExampleAppHomePageLoginUrlTemaplte"];
        private const string FieldValidationErrorCss = ".field-validation-error";
        
        public override void Login(string username, string password)
        {
            driver.Navigate().GoToUrl(string.Format(ExampleAppHomePageLoginUrlTemaplte, username, password));
        }

        public override bool HasValidationError()
        {
            return this.Driver.FindElements(By.CssSelector(FieldValidationErrorCss)).Count > 0;
        }

        public override bool HasValidationErrorMessage(string errorMessage)
        {
            return this.HasValidationError() && this.HasText(errorMessage);
        }

        public override bool HasText(string message)
        {
            return this.Driver.FindElements(By.XPath("//*[contains(text(),'" + message + "')]")).Count > 0;
        }
    }
}
