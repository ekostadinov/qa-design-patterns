using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackboard.ImageComparator;
using Blackboard.KnowledgeSources;
using Blackboard.Models;
using OpenQA.Selenium;

namespace Blackboard
{
    /// <summary>
    /// Responsibility is to manage central data. http://www.openloop.com/softwareEngineering/patterns/architecturePattern/arch_Blackboard.htm
    /// The Blackboard architectural pattern is useful for problems for which no deterministic solution strategies are known
    /// In this pattern, several specialized subsystems assemble their knowledge to build a possibly partial or approximate solution
    /// The idea is to use a collection of independent programs that work cooperatively on a common data structure.
    /// </summary>
    class WebPage
    {
        private IList<WebPageElement> _elements = new List<WebPageElement>();

        public IList<WebPageElement> Blackboard
        {
            get { return _elements; }
        }

        public IWebElement FindElementOnPage(string elementName, IWebDriver driver)
        {
            // knowledge sourses are ResourceManager, ImageHandler and DomHandler
            // load element as image
            var elementAsImage = ResourceManager.LoadElementAsImageLayout(elementName, ResourceManager.PathToImageFolder);
            // find all webelements
            DomHandler dom =  new DomHandler(driver);
            var relevantElements = dom.GetAllRelevantElements(elementName);
            // iterate over relevant ones
            // take screenshot
            // compare with expected layout
            // if match return WebElement
            ImageHandler imageHandler = new ImageHandler();
            IWebElement foundElelement = dom.FindExpectedElement(imageHandler, elementAsImage, relevantElements, elementName);

            return foundElelement;
        }
    }
}
