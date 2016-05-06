using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge.Imaging;
using AForge.Imaging.Filters;
using Blackboard.ImageComparator;
using OpenQA.Selenium;

namespace Blackboard.KnowledgeSources
{
    /// <summary>
    /// Main responsibilities are to Evaluate its own applicability, to computes a result and to update Blackboard 
    /// Collaborator is the Blackboard object
    /// </summary>
    class ImageHandler
    {
        //Knowledge sources are separate, independent subsystems that solve specific aspects of the overall problem. Sometimes they are called "World Knowledge".
        //Together, knowledge sources model the overall problem domain
        //A solution can only be built by integrating the results of several knowledge sources
        //They do not communicate directly - they read and write to the blackboard. So, they have to understand the vocabulary of the blackboard
        //Each knowledge source is responsible for knowing the conditions under which it can contribute to a solution, so it often splits 
        //into condition-part and an action-part:
        //Condition-part (inspects) looks at the blackboard for current state and if there is anything can be done
        //Action-part (updates) takes the necessary action to the current blackboard contents

        /// <summary>
        /// Checks if some image is present in particular screenshot
        /// </summary>
        /// <param name="imageToSearchFor">The name of the image element from the project file structure</param>
        ///  <returns></returns>
        public bool IsScreenContainingImage(string imageToSearchFor, IWebDriver driver, IWebElement pageElement)
        {
            string screenShotName = "Screenshot_" + imageToSearchFor + DateTime.Now.Ticks + ".jpeg";
            string fullScreenshotPath = ResourceManager.PathToScreenshotFolder + screenShotName;
            string imageSystemFile = ResourceManager.GetImageSystemFile(imageToSearchFor, driver, pageElement);

            using (Bitmap searchImage = (Bitmap)Bitmap.FromFile(imageSystemFile))
            {
                ResourceManager.TakeScreenShotOfElement(driver, pageElement, ResourceManager.PathToScreenshotFolder, screenShotName, searchImage);

                using (Bitmap screenShot = (Bitmap)Bitmap.FromFile(fullScreenshotPath))
                {
                    if (IsSearchedImageFound(screenShot, searchImage))
                    {
                        return true;
                    }

                    return false;
                }
            }
        }

        private bool IsSearchedImageFound(Bitmap template, Bitmap image)
        {
            const Int32 epsilon = 10;
            // similarity is set to default as 95%, since performance is no issue at this point
            ExhaustiveTemplateMatching etm = new ExhaustiveTemplateMatching(0.95f);

            TemplateMatch[] tm = etm.ProcessImage(
                new ResizeNearestNeighbor(template.Width, template.Height).Apply(template),
                new ResizeNearestNeighbor(image.Width, image.Height).Apply(image)
                );

            if (tm.Length == 1) 
            {
                Rectangle tempRect = tm[0].Rectangle;

                if (Math.Abs(image.Width - tempRect.Width) < epsilon
                    &&
                    Math.Abs(image.Height - tempRect.Height) < epsilon)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
