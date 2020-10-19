using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParallelSeleniumTest
{
    class CaptureScreenshot
    {

        public RemoteWebDriver Driver { get; set;  }

        //public BasePage CurrentPage { get; set;  }

        // To capture screenshot and send reports we are using the Extent.Reports.core nuget package 
        /*public MediaEntityBuilder CaptureScreenshotAndReturnModel(string Name)
        {
            var screenhot = ((ITakesScreenshot)Driver).GetScreenshot().AsBase64EncodedString;

            //return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenhot, Name).Build(); 
        }*/

    }
}
