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
    class DepositPageEdges : ILoadableEdge
    {
        private static IWebDriver _driver;
        //we need the element map in order to interact with the component
        private DepositPage _depositPage;
        private IList<ILoadableEdge> _nodeNeighbours;
        private IList<ILoadableEdge> _rootNeighbours = new List<ILoadableEdge>();
        
        public IList<ILoadableEdge> RootNeighbours
        {
            get { return _rootNeighbours; }
        }
        public IList<ILoadableEdge> NodeNeighbours
        {
            get { return _nodeNeighbours; }
        }

        public DepositPageEdges(HomePage parent)
        {
            _driver = parent.PageDriver;
            _depositPage = new DepositPage(_driver);
            _rootNeighbours.Add(new HomePageEdges(parent));
        }

        public ILoadableComponent Load()
        {
            var parent = _rootNeighbours.First().Load();
            var homePage = ((HomePageEdges) parent).PageVertex;

            if (homePage.IsLoaded())
            {
                homePage.DepositButton.Click();
            }
           
            return this;
        }
    }
}
