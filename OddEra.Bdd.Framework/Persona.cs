using System;
using System.Configuration;
using OpenQA.Selenium;

namespace OddEra.Bdd.Framework
{
    public abstract class Persona
    {
        protected IWebDriver driver;

        protected PageBase currentPage;

        protected Persona()
        {
            driver = DriverFactory.GetDriver();
        }

        public virtual T OnPage<T>() where T : PageBase, new()
        {
            PageBase basePage = currentPage;

            if (basePage == null)
                throw new InvalidOperationException("User not on a page");

            if (!(basePage is T))
            {
                currentPage = new T { Driver = driver };
                currentPage.SetAsCurrentPageForUser(this);
            }

            if (!(currentPage is T))
            {
                throw new InvalidOperationException("Type specified is not current page");
            }

            return (T)currentPage;
        }

        public void SetCurrentPage(PageBase page)
        {
            this.currentPage = page;
            this.currentPage.Driver = driver;
        }

        public virtual void CloseBrowser()
        {
            driver.Close();
        }
    }
}
