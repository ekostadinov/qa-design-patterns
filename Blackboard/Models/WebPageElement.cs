using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Blackboard.Models
{
    class WebPageElement
    {
        public IWebElement WebElement { get; set; }
        public Bitmap Layout { get; set; }
    }
}
