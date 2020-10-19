using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Security.Cryptography.X509Certificates;

namespace PageObjectModel
{
    public class Tests { 

        RemoteWebDriver driver = new ChromeDriver(); 
    
        [SetUp]
        public void Setup()
        {
            
            driver.Navigate().GoToUrl("https://www.hulu.com/welcome");
        }

        [Test]
        public void Test1()
        {
            Console.WriteLine("Hello PageObjectModel World! - used to organize all the objects using Page factory");

            /* //Object for the page
             Hulu_homePageObjects page = new Hulu_homePageObjects(driver);

             //Search for trial button and click on it
             page.startYourTrail().Click(); 

             //Search for more details page and click 
             page.moreDetailsPage.Click();
             Assert.Pass();*/

            Hulu_homePageObjects page = new Hulu_homePageObjects(driver);

            page.Click(); 

            


        }
    }
}