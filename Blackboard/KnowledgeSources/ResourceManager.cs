using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Blackboard.ImageComparator
{
    /// <summary>
    /// This class is responsible for managing of image resources and project's folder structure
    /// </summary>
    internal class ResourceManager
    {
        // this is required since this functionality is at solution level, but
        // the relative paths are per project level
        public static readonly string ProjectName =
            // Assembly.GetCallingAssembly().GetName().Name; // change to, when this functionality is exposed as NuGet pack
            "GrosvenorAutomatedUiTests";

        public static readonly string PathToScreenshotFolder = "..\\..\\Screenshots\\";
        public static readonly string PathToImageFolder = "..\\..\\Images\\";

        internal static Bitmap LoadElementAsImageLayout(string elementName, string pathToDir)
        {
            var images = Directory.GetFiles(pathToDir, elementName + ".*");
            Bitmap image = (Bitmap) Image.FromFile(@images[0], true);
            return image;
        }

        //remove
        public static string GetImageSystemFile(string imageToSearchFor, IWebDriver driver, IWebElement pageElement)
        {
            // defensive programming is applied here in order to achieve insensitive execution 
            // even if different searched image's formats are used for storing
            var images = Directory.GetFiles(ResourceManager.PathToImageFolder, imageToSearchFor + ".*");
            string imageSystemFile = string.Empty;

            // there is no image for this page taken before current run
            if (images.Length == 0)
            {
                TakeScreenShotForImage(driver, pageElement, ResourceManager.PathToImageFolder, imageToSearchFor);
                images = Directory.GetFiles(ResourceManager.PathToImageFolder, imageToSearchFor + ".*");
                imageSystemFile = images[0];
            }
            else
            {
                imageSystemFile = images[0];
            }
            return imageSystemFile;
        }

        public static void TakeScreenShotForImage(IWebDriver webDriver, IWebElement pageElement, string rootpath,
            string screenShotName)
        {
            var crop = new Rectangle(pageElement.Location.X, pageElement.Location.Y,
                pageElement.Size.Width, pageElement.Size.Height);

            SaveScreenshotTaken(webDriver, rootpath, screenShotName, crop);
        }

        public static void TakeScreenShotOfElement(IWebDriver webDriver, IWebElement pageElement, string rootpath,
            string screenShotName, Bitmap searchImage)
        {
            int templatePixelsOffset = 0;
            var crop = new Rectangle(pageElement.Location.X, pageElement.Location.Y,
                pageElement.Size.Width + templatePixelsOffset, pageElement.Size.Height + templatePixelsOffset);

            SelfResizeScreenshotCrop(pageElement, searchImage, ref templatePixelsOffset, ref crop);

            SaveScreenshotTaken(webDriver, rootpath, screenShotName, crop);
        }

        private static void SaveScreenshotTaken(IWebDriver webDriver, string rootpath, string screenShotName,
            Rectangle crop)
        {
            Byte[] screenshotArray = ((ITakesScreenshot)webDriver).GetScreenshot().AsByteArray;

            Bitmap screenshot = null;
            using (MemoryStream screenshotStream = new MemoryStream(screenshotArray))
            {
                screenshot = new Bitmap(screenshotStream);

                // since the CI server can't process such big images it's required to 
                // sequentially resize the initial screenshot relatively to the web element
                screenshot = CropImage(screenshot, crop);

                if (!Directory.Exists(rootpath))
                {
                    Directory.CreateDirectory(rootpath);
                }

                string formatForSaving = "{0}\\{1}";
                if (!screenShotName.Contains(".jpeg"))
                {
                    formatForSaving += ".jpeg";
                }
                screenshot.Save(String.Format(formatForSaving, rootpath, screenShotName),
                    System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        private static Bitmap CropImage(Bitmap originalImage, Rectangle sourceRectangle,
            Rectangle? destinationRectangle = null)
        {
            if (destinationRectangle == null)
            {
                destinationRectangle = new Rectangle(Point.Empty, sourceRectangle.Size);
            }

            var croppedImage = new Bitmap(destinationRectangle.Value.Width,
                destinationRectangle.Value.Height);
            using (var graphics = Graphics.FromImage(croppedImage))
            {
                graphics.DrawImage(originalImage, destinationRectangle.Value,
                    sourceRectangle, GraphicsUnit.Pixel);
            }
            return croppedImage;
        }

        private static void SelfResizeScreenshotCrop(IWebElement pageElement, Bitmap searchImage,
            ref int templatePixelsOffset, ref Rectangle crop)
        {
            bool isTemplateSmaller = crop.Width < searchImage.Size.Width
                                     || crop.Height < searchImage.Size.Height;

            while (isTemplateSmaller)
            {
                // pixels offset is required since the screenshot's template should be bigger than the searched image
                templatePixelsOffset += 5;
                crop = new Rectangle(pageElement.Location.X, pageElement.Location.Y,
                    pageElement.Size.Width + templatePixelsOffset, pageElement.Size.Height + templatePixelsOffset);

                isTemplateSmaller = crop.Width < searchImage.Size.Width
                                    || crop.Height < searchImage.Size.Height;
            }
        }

    }
}

