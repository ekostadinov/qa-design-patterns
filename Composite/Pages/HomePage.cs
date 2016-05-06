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
    /// Composite object:
    /// - defines behaviour for components having children
    /// - stores child components
    /// - implements child related operations in the component interface
    /// </summary>
    internal class HomePage : ILoadableComponent
    {
        private readonly IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//a[text()='Deposit']")]
        public readonly IWebElement DepositButton = null;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        } 


        public ILoadableComponent Load()
        {
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.Load();
            loginPage.Login("PlayerInfoAT", "testauto");

            return this;
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
