using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using PageLoader.Models;

namespace PageLoader.Vertices
{
    class HomePage : IPageVertex
    {
        private static IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//a[text()='Deposit']")]
        public readonly IWebElement DepositButton = null;

        public IWebDriver PageDriver { get { return _driver; } }

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public bool IsLoaded()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60000));
            wait.Until(d =>
            {
                try
                {
                    var element = d.FindElement(By.XPath("//a[text()='Deposit']"));
                    return true;
                }
                catch (Exception e)
                {
                    return false;
                }
            });

            return true;
        }
    }
}
