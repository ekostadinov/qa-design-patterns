using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Blackboard.Models
{
    /// <summary>
    /// This (SimpleFactory) class is used to create instances of Selenium's web drivers
    /// </summary>
    internal class WebDriverFactory
    {
        private int pageLoadTimeoutSeconds = 5;

        /// <summary>
        /// Creates IWebDriver instance required by the test specification 
        /// </summary>
        /// <param name="browserType">name of the browser, currently only Firefox. The parameter is case insensitive.</param>
        /// <returns>IWebDriver</returns>
        public IWebDriver CreateWebDriver(string browserType)
        {
            IWebDriver driver = null;
            switch (browserType.ToLower())
            {
                case "firefox":
                    Console.WriteLine("Creating firefox driver.");
                    driver = new FirefoxDriver();
                    driver.Manage().Window.Maximize();
                    driver.Manage().Timeouts().SetPageLoadTimeout(new TimeSpan(0, 0, 0, pageLoadTimeoutSeconds));
                    return driver;
                default:
                    throw new Exception("Error: provided browser name was not found in the list of supported browsers!");
            }
        }
    }
}

