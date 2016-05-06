using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Composite.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Composite
{
    /// <summary>
    /// Composite design patten allows you to have a tree structure and ask each node in the tree structure to perform a task. 
    /// Compose objects into tree structure to represent part-whole hierarchies.Composite lets client treat individual objects and compositions of objects uniformly.
    /// It treats each node in two ways - Composite or leaf. Composite means it can have other objects below it. Leaf means it has no objects below it.
    /// </summary>
    class MainProgram
    {
        // Client (test) manipulates objects in the composition through the component interface (ILoadableComponent)
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();

            // Leaf object
            ILoadableComponent depositPage = new DepositPage(driver);
            depositPage.Load();

            //driver.Quit();
        }
    }
}
