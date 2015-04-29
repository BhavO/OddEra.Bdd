using OpenQA.Selenium;
using System;

namespace OddEra.Bdd.Framework
{
    public abstract class PageBase
    {
        protected IWebDriver driver;
        protected abstract string Title { get; }

        public IWebDriver Driver
        {
            get
            {
                if (this.driver == null)
                {
                    throw new InvalidOperationException("Browser session has not been set for this instance.");
                }
                return this.driver;
            }
            set
            {
                if (this.driver != null)
                {
                    throw new InvalidOperationException("Browser session already set for this instance.");
                }
                this.driver = value;
            }
        }

        public virtual void SetAsCurrentPageForUser(Persona user)
        {
            user.SetCurrentPage(this);
        }

        public virtual bool IsCurrentPage()
        {
            return Driver.Title.Equals(Title);
        }

        public virtual void EnterField(string fieldName, string fieldValue)
        {
            this.Driver.FindElement(By.Name(fieldName)).SendKeys(fieldValue);
        }

        public virtual string GetFieldValue(string fieldName)
        {
            return this.Driver.FindElement(By.Name(fieldName)).Text;
        }

        public virtual bool CanSeeFieldValue(string fieldName, string fieldResult)
        {
            string fieldValue = null;
            try
            {
                fieldValue = ((string)((IJavaScriptExecutor)this.Driver).ExecuteScript(string.Format("return document.getElementById('{0}').innerHTML", fieldName))).Trim(' ', '\n', '\r');

            }
            catch (Exception)
            {
                throw new ApplicationException(string.Format("{0} field missing from UI", fieldName));
            }

            return string.Equals(fieldValue, fieldResult, StringComparison.InvariantCultureIgnoreCase);
        }

        public abstract bool HasValidationError();

        public abstract bool HasValidationErrorMessage(string errorMessage);

        public abstract bool HasText(string message);

        public abstract void Login(string username, string password);

        protected virtual string GetFieldWithId(string fieldId)
        {
            return this.Driver.FindElement(By.Id(fieldId)).Text;
        }

        protected virtual void SetFieldWithId(string fieldId, string fieldValue)
        {
            this.Driver.FindElement(By.Id(fieldId)).Clear();
            this.Driver.FindElement(By.Id(fieldId)).SendKeys(fieldValue);
        }
    }
}
