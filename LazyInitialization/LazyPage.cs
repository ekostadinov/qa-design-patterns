using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace LazyInitialization
{
    class LazyPage
    {
        private IWebDriver _driver;

        public IWebDriver Driver
        {
            get { return _driver; }
        }

        public LazyPage()
        {
            Console.WriteLine("Lazy page constructor!");
            _driver = new FirefoxDriver();
        }
    }
}
