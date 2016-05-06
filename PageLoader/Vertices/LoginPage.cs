using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using PageLoader.Models;

namespace PageLoader.Vertices
{
    class LoginPage : IPageVertex
    {
        private static IWebDriver _driver;
        
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'loginUsername')]")]
        private readonly IWebElement _usernameInput = null;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'loginPassword')]")]
        private readonly IWebElement _passwordInput = null;

        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'form-elements')]//button[text()='Login']")]
        private readonly IWebElement _loginButton = null;

        public readonly string Url = "http://my-site.net/";
        public IWebDriver PageDriver { get { return _driver; } }
        public IWebElement UsernameInput { get { return _usernameInput; } }
        public IWebElement PasswordInput { get { return _passwordInput; } }
        public IWebElement LoginButton { get { return _loginButton; } }

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }
    }
}
