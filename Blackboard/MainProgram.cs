using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackboard.ImageComparator;
using OpenQA.Selenium;

namespace Blackboard
{
    /// <summary>
    /// Building a software system for WebElements' image recognition. Input is screenshot recorded as image and output is accessible WebElement.
    /// Blackboard is used to describe the situation where a group of human experts sit in front of a real blackboard and work together to solve a problem.
    /// So, partial solutions are "posted" to the blackboard for further processing.
    /// 
    ///             Blackboard ---------- operates on ---> Knowledge Source 
    ///             ^                                           |
    ///             |                                           |
    ///             |                                        activates
    ///             |                                           |
    ///             ---------monitor and schedule----------- Control
    ///
    /// </summary>
    class MainProgram
    {
        private static WebPage _blackboard = new WebPage();

        static void Main(string[] args)
        {
            //Blackboard is the central data store for solution space and control data (we called that vocabulary)
            //Blackboard provides interface that enables all knowledge sources to read from and write to it
            //We use the term hypothesis or blackboard entry for solutions that are constructed during the problem solving process
            //Hypotheses has level of abstraction (how far we are from the input), estimated degree of truth, and/or time interval covered as attributes
            string siteUrl = "http://my-site.net/";
            string username = "carduser";
            string password = "testauto";
            string usernameInput = "usernameInput"; //image name in ./images
            string passwordInput = "passwordInput";
            string loginButton = "loginButton";
            Control testCase = new Control();

            testCase.GivenWhenINavigateToHomePage(siteUrl);
            // consider declarative BDD
            // WhenILoginWithUserDetails(username, password);
            testCase.WhenITypeTextToToElement(usernameInput, username);
            testCase.WhenITypeTextToToElement(passwordInput, password); 
            testCase.WhenIClickOnElement(loginButton);
        }
       
    }
}
