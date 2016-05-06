using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Composite.Pages
{
    /// <summary>
    /// Leaf: 
    /// - represents leaf objects in the composition.A leaf has no children.
    /// - defines behaviour for primitive objects in the composition.
    /// </summary>
    class DepositPage : ILoadableComponent
    {
        private readonly IWebDriver _driver;

        public DepositPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        } 

        public ILoadableComponent Load()
        {
            HomePage homePage = new HomePage(_driver);
            homePage.Load();
            if (homePage.IsLoaded())
            {
                homePage.DepositButton.Click();
            }

            return this;
        }
    }
}
