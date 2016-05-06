using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageLoader.Models;
using PageLoader.Vertices;

namespace PageLoader.Edges
{
    class LoginPageEdges : ILoadableEdge
    {
        // this node is our site root
        //no need of _rootNeighbours;
        private IList<ILoadableEdge> _nodeNeighbours;
        private IWebDriver _driver;
        private LoginPage _loginPage;

        public LoginPage PageVertex { get { return _loginPage; } }
        public IList<ILoadableEdge> RootNeighbours
        {
            get { throw new InvalidOperationException("This page vertex is the root!"); }
        }
        public IList<ILoadableEdge> NodeNeighbours
        {
            get { return _nodeNeighbours; }
        }

        public LoginPageEdges(LoginPage loginPage)
        {
            _loginPage = loginPage;
            _driver = loginPage.PageDriver;
        }
        
        public ILoadableComponent Load()
        {
            _driver.Navigate().GoToUrl(_loginPage.Url);
            return this;
        }

        //this logic should be placed in separate class (SRP)
        public void Login(string username, string pass)
        {
            if (_driver.Url.Equals(_loginPage.Url))
            {
                _loginPage.UsernameInput.SendKeys(username);
                _loginPage.PasswordInput.SendKeys(pass);
                _loginPage.LoginButton.Click();
            }
        }
    }
}
