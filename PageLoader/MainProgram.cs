using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using PageLoader.Edges;
using PageLoader.Vertices;

namespace PageLoader
{ 
    /// <summary>
    /// Encapsilates navigation logic over site's pages via graph:
    ///  - Bidirected: which each edge is given an independent orientation (or direction, or arrow) at each end
    ///  - Cyclic: contains at least one cycle (there exists a path starting at vertex A that eventually ends back at vertex A)
    /// </summary>
    class MainProgram
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();

            DepositPageEdges edges = new DepositPageEdges(new HomePage(driver));
            edges.Load();

            //driver.Quit();
        }
    }
}
