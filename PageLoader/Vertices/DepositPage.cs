using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PageLoader.Models;

namespace PageLoader.Vertices
{
    class DepositPage : IPageVertex
    {
        private static IWebDriver _driver;

        public IWebDriver PageDriver { get { return _driver; } }

        public DepositPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }
        
    }
}
