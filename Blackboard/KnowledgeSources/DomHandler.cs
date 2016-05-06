using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackboard.ImageComparator;
using OpenQA.Selenium;

namespace Blackboard.KnowledgeSources
{
    /// <summary>
    /// Main responsibilities are to Evaluate its own applicability, to computes a result and to update Blackboard 
    /// Collaborator is the Blackboard object
    /// </summary>
    class DomHandler
    {
        private IWebDriver _driver;
        public DomHandler(IWebDriver driver)
        {
            _driver = driver;
        }

        internal List<IWebElement> GetAllRelevantElements(string elementName)
        {
            string xpath = ".//";
            if (elementName.ToLower().Contains("input"))
            {
                xpath += "input";
            }
            else if (elementName.ToLower().Contains("button"))
            {
                xpath += "button";
            }

            ReadOnlyCollection<IWebElement> relevantElements = _driver.FindElements(By.XPath(xpath));

            return relevantElements.ToList();
        }

        internal IWebElement FindExpectedElement(ImageHandler imageHandler, Bitmap elementExpectedAsImage, List<IWebElement> relevantElements, string elementName)
        {
            IWebElement foundElement = null;
            int sizeMatchMargin = 5;

            foreach (var element in relevantElements)
            {

                bool isCloseWidth = (element.Size.Width - sizeMatchMargin) <= elementExpectedAsImage.Width;
                bool isCloseHeight = (element.Size.Height - sizeMatchMargin) <= elementExpectedAsImage.Height;
                bool isVisible = element.Size.Width > 0 && element.Size.Height > 0;

                // some elements are not displayed and we can skip checks
                if (isCloseHeight && isCloseWidth && isVisible)
                {
                    //compare element layout with expected
                    if (imageHandler.IsScreenContainingImage(elementName, _driver, element))
                    {
                        return element;
                    }
                }
            }

                throw new ElementNotVisibleException("WebElement layout is not found on the page!");
        }
    }
}
