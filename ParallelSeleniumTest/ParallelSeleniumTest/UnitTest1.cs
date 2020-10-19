using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace ParallelSeleniumTest
{
    [Parallelizable]
    public class FirefoxTest : Hooks
    {
        public FirefoxTest() : base(BrowserType.Firefox)
        {
        }

        [Test]
        public void FirefoxTesting()
        {
            driver.Navigate().GoToUrl("http://www.google.com");
            driver.FindElement(By.Name("q")).SendKeys("Selenium");
            //System.Threading.Thread.Sleep(10);
            driver.FindElement(By.Name("btnK")).Click();
            Assert.That(driver.PageSource.Contains("Selenium"), Is.EqualTo(true),
                "The text selenium does not exist");
        }

    }

    public class ChromeTest : Hooks
    {
        public ChromeTest() : base(BrowserType.Chrome)
        {
        }

        [Test]
        public void ChromeTesting()
        {
            driver.Navigate().GoToUrl("https://oldnavy.gap.com/");
            driver.FindElement(By.Name("searchText")).SendKeys("women zipup hoodie");
            //driver.FindElement(By.XPath("//span[@class='css-u0zwhm']//*[local-name()='svg']")).Click();
            Assert.That(driver.PageSource.Contains("Women"), Is.EqualTo(true),
                "women zipup hoodie");
        }


    }

    public class FirefoxSecondTest : Hooks
    {
       
        public FirefoxSecondTest() : base(BrowserType.Firefox)
        {
        }

        [Test]
        public void SecondTest()
        {
            //add implicit wait 
           // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);
            driver.Navigate().GoToUrl("https://oldnavy.gap.com/");
            // - //div[@class="css-q5fqw0"] - Style: display : flex
            /*IAlert alert = driver.SwitchTo().Alert();
            alert.Dismiss(); */ //use these alerts in Java classes 


           //add explicit wait 
           WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));


            //Handles modal window
            /*string getModalWindowText = driver.FindElement(By.XPath("//div[@class='css - q5fqw0']")).Text;
            Console.WriteLine(getModalWindowText);*/

            IWebElement modalWindowClose = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//button[@class='css-1qosac6']")));
            modalWindowClose.Click(); 
        

            driver.FindElement(By.Name("searchText")).SendKeys("women zipup hoodie");
            driver.FindElement(By.XPath("//span[@class='css-u0zwhm']//*[local-name()='svg']")).Click();
            Assert.That(driver.PageSource.Contains("Women"), Is.EqualTo(true),
                "women zipup hoodie");
        }
    }
}