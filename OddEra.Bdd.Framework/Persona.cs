using System;
using System.Configuration;
using OpenQA.Selenium;

namespace OddEra.Bdd.Framework
{
    public abstract class Persona
    {
        private IWebDriver driver;

        protected PageBase currentPage;

        protected IWebDriver Driver
        {
            get
            {
                return driver ?? (driver = DriverFactory.GetDriver());
            }
        }

        public virtual T OnPage<T>() where T : PageBase, new()
        {
            PageBase basePage = currentPage;

            if (basePage == null)
                throw new InvalidOperationException("User not on a page");

            if (!(basePage is T))
            {
                currentPage = new T();
                currentPage.SetAsCurrentPageForUser(this);
            }

            if (!(currentPage is T))
            {
                throw new InvalidOperationException("Type specified is not current page");
            }

            currentPage.Driver = Driver;

            return (T)currentPage;
        }

        public void SetCurrentPage(PageBase page)
        {
            this.currentPage = page;
            this.currentPage.Driver = Driver;
        }

        public virtual void CloseBrowser()
        {
            if (Driver != null)
            {
                Driver.Quit();
                driver = null;
            }
        }
    }
}
