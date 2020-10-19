using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParallelSeleniumTest
{
    public enum BrowserType
    {
        Chrome,
        Firefox, 
        IE
    }

    public class Hooks :Base
    {

        private BrowserType _broswerType; 

        public Hooks(BrowserType browser)
        {
            _broswerType = browser; 
        }

        [SetUp]
        public void IntiliazeTest()
        {
            ChooseDriverInstance(_broswerType); 
        }

        private void ChooseDriverInstance(BrowserType browserType)
        {
            if (browserType == BrowserType.Chrome)
                driver = new ChromeDriver();
           else  if (browserType == BrowserType.Firefox)
                driver = new FirefoxDriver();
           /* else if (browserType == BrowserType.IE)
                driver = new InternetExplorerDriver();*/
        }


    }
}
