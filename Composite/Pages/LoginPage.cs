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
    class LoginPage : ILoadableComponent
    {
        private readonly IWebDriver _driver;
        private readonly string _url = "http://my-site.net/";

        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'loginUsername')]")]
        private readonly IWebElement _usernameInput = null;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'loginPassword')]")]
        private readonly IWebElement _passwordInput = null;

        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'form-elements')]//button[text()='Login']")]
        private readonly IWebElement _loginButtont = null;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        } 

        public ILoadableComponent Load()
        {
            _driver.Navigate().GoToUrl(_url);
            return this;
        }

        public void Login(string username, string pass)
        {
            if (_driver.Url.Equals(_url))
            {
                _usernameInput.SendKeys(username);
                _passwordInput.SendKeys(pass);
                _loginButtont.Click();
            }
        }
    }
}
