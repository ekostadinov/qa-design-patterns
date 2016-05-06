using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageLoader.Models;
using PageLoader.Vertices;

namespace PageLoader.Edges
{
    class HomePageEdges : ILoadableEdge
    {
        private static IWebDriver _driver;
        private IList<ILoadableEdge> _rootNeighbours = new List<ILoadableEdge>();
        private IList<ILoadableEdge> _nodeNeighbours;
        private HomePage _homePage;

        public HomePage PageVertex { get { return _homePage; }  }
        public IList<ILoadableEdge> RootNeighbours
        {
            get { return _rootNeighbours; }
        }
        public IList<ILoadableEdge> NodeNeighbours
        {
            get { return _nodeNeighbours; }
        }

        public HomePageEdges(HomePage homePage)
        {
            _homePage = homePage;
            _driver = homePage.PageDriver;
            _rootNeighbours.Add(new LoginPageEdges(new LoginPage(_driver)));
        }

        public ILoadableComponent Load()
        {
            var parent = _rootNeighbours.First().Load();
            ((LoginPageEdges)parent).Login("PlayerInfoAT", "testauto");

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
