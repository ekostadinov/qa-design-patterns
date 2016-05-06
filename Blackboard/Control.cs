using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackboard.Models;
using OpenQA.Selenium;

namespace Blackboard
{
    /// <summary>
    /// Main responsibility is to Monitor the Blackboard and to schedule knowledge source activations.
    /// Collaborators are Blackboard and Knowledge Sources
    /// </summary>
    class Control
    {
        //A central control component evaluates the current state of processing and coordinates the specialized programs.
        //This data-directed control regime is referred to as opportunistic problem solving. It allows experimenting different algorithms possible and
        //allows experimentally-derived heuristics to control processing.
        //During the problem-solving process, the system works with partial solutions that are combined, changed or rejected.
        //Each of these solutions represents a partial problem and a certain stage of its solution.
        //The set of all possible solutions is called solution space and is organized into levels of abstraction:
        //Lowest level is the internal representation of the input and
        //Highest level is the potential solutions

        private IWebDriver _driver;
        private WebPage _blackboard;

        public Control()
        {
            _driver = new WebDriverFactory().CreateWebDriver("firefox");
            _blackboard = new WebPage();
        }

        public void WhenIClickOnElement(string loginButton)
        {
            IWebElement userClickableForm = _blackboard.FindElementOnPage(loginButton, _driver);
            userClickableForm.Click();
        }

        public void WhenITypeTextToToElement(string inputElement, string text)
        {
            IWebElement userInputForm = _blackboard.FindElementOnPage(inputElement, _driver);
            userInputForm.SendKeys(text);
        }

        public void GivenWhenINavigateToHomePage(string siteUrl)
        {
            _driver.Navigate().GoToUrl(siteUrl);
        }

    }
}
