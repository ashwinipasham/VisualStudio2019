using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace SeleniumFirstCSharp
{
    [TestFixture]
    class Program
    {
           /* //Create a Console app
            //Create reference to Webdriver
            //Add the Chrome Driver + selenium driver through Nugetpackages
            IWebDriver driver = new ChromeDriver();

            //Navigatre to page
            driver.Navigate().GoToUrl("http://demo.guru99.com/"); 

            //find WebElement
            IWebElement submitBtn = driver.FindElement(By.XPath("//input[@name='btnLogin']"));

            //Perform the ops - Click here 
            submitBtn.Click();

            //Close the driver 
            //driver.Close();          

        */

        IWebDriver driver = new FirefoxDriver();
        [SetUp]
        [Test]
        public void Initialize()
        {
            //Navigatre to page
            driver.Navigate().GoToUrl("http://demo.guru99.com/");
            Console.WriteLine("Opened URL"); 
        }

        [Test]
        public void ExecuteTest()
        {
         
            //find WebElement
            IWebElement submitBtn = driver.FindElement(By.XPath("//input[@name='btnLogin']"));

            //Perform the ops - Click here 
            submitBtn.Click();
            Console.WriteLine("Executed Tests");
        }

        [Test]
        public void SecondTest()
        {
            Console.WriteLine("This is a second test");
            IWebElement paymentLink = driver.FindElement(By.LinkText("Payment Gateway Project"));         
            paymentLink.Click();
            Console.WriteLine("This is a Paymnet Gateway clicked");
           
        }

        /*[TearDown]
        [Test]
        public void CleanUp()
        {

            //Close the driver 
           // driver.Close();
            Console.WriteLine("Closed Browser");
        }*/
    }
}
