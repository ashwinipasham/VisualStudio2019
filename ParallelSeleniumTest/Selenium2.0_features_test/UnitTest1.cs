using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace Selenium2._0_features_test
{
    [Parallelizable]
    public class Tests
    {
        IWebDriver driver = new FirefoxDriver();


        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("http://uitestpractice.com/Students/Actions");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void DblClick_Test()
        {
            IWebElement dClick = driver.FindElement(By.Name("dblClick"));
            //Use Actions class
            Actions dblaction = new Actions(driver);
            dblaction.DoubleClick(dClick).Perform();
            Console.WriteLine("Element has been dbl clicked!");
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            Console.WriteLine("Alert has been accepted!");
            Assert.Pass("Test Passed");

        }

        [Test]
        public void DragDrop_Test()
        {
            IWebElement drag = driver.FindElement(By.XPath("//div[@id='draggable']"));
            IWebElement drop = driver.FindElement(By.Id("droppable"));
            Actions dragAction = new Actions(driver);
            dragAction.DragAndDrop(drag, drop).Perform();
            Console.WriteLine("Element has been dropped!");
        }


        [Test]
        public void Iframe_Test()
        {
            driver.Navigate().GoToUrl("http://uitestpractice.com/Students/Switchto");
            //Switch to child Frames - call the child frame by Id or name. 
            driver.SwitchTo().Frame("iframe_a");
            IWebElement iframe_TextBox = driver.FindElement(By.Id("name"));
            iframe_TextBox.SendKeys("AnkoPro_Tests");
            String getText = iframe_TextBox.GetAttribute("value");
            Console.WriteLine("Added text to Iframe");
            Console.WriteLine("Caught the input Text: " + getText);

            //for email and password we can use the clear method.
            /*iframe_TextBox.Clear();
            Console.WriteLine("Input Text Cleared");*/

            //Switch back to Parent frame to click on the link
            driver.SwitchTo().ParentFrame();
            IWebElement linkText = driver.FindElement(By.LinkText("uitestpractice.com"));
            linkText.Click();
            Console.WriteLine("Website opens in Iframe");

        }

        [Test]
        public void AjaxCall_Test()
        {
            driver.Navigate().GoToUrl("http://uitestpractice.com/Students/Contact");
            IWebElement AjaxCall = driver.FindElement(By.XPath("//a[contains(text(),'This is a Ajax link')]"));
            AjaxCall.Click();
            Console.WriteLine("Clicked AJAX link!!");
            // Assert.AreEqual()
            driver.Navigate().Back();

        }

        [Test]
        public void multipleWindows_Test()
        {
            driver.Navigate().GoToUrl("http://uitestpractice.com/Students/Switchto");
            Console.WriteLine("Before Click");
            Console.WriteLine("No. of windows open by Selenium: " + driver.WindowHandles);
            foreach (var item in driver.WindowHandles)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Current Window Handle " + driver.CurrentWindowHandle);
            driver.FindElement(By.PartialLinkText("Opens in a new")).Click();
            Console.WriteLine("After Click");
            Console.WriteLine("No. of windows open by Selenium: " + driver.WindowHandles);
            foreach (var item in driver.WindowHandles)
            {
                Console.WriteLine(item);
            }

            //We have switch to the new window to fidn the elements for that we use Window class. 
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            Console.WriteLine("Current Window Handle " + driver.CurrentWindowHandle);

            //Scrolling the current window to find the container 
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            System.Threading.Thread.Sleep(5000);
            js.ExecuteScript("window.scrollBy(0,1600);");
            Console.WriteLine("Srcolled the new Window");
            IWebElement selectCntrl = driver.FindElement(By.XPath("//div[@class='container orange']"));
            Console.WriteLine("found the orange container");

            //Added Explicit Wait time to find the element
            /*WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15)); 
            IWebElement select_10 = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//li[contains(text(),'10')]")));
            select_10.Click(); */

            IWebElement select_3 = driver.FindElement(By.XPath("//li[contains(text(),'3')]"));
            select_3.Click();
            String number = select_3.GetAttribute("value");
            Console.WriteLine("Selected " + number + " number from Selectable control in new Window");


        }

        [Test]
        public void ClickAndHoldRelease()
        {
            IWebElement element = driver.FindElement(By.XPath("//li[@name='one']"));
            Actions action = new Actions(driver);
            action.MoveToElement(element).ClickAndHold()
                .MoveToElement(driver.FindElement(By.XPath("//li[@name='seven']")))
                .Release()
                .Build()
                .Perform();
            Console.WriteLine("ClickHold and Release test Passed!");                
        }

        [Test]
        public void DialogControl()
        {
            driver.Navigate().GoToUrl("http://uitestpractice.com/");
            IWebElement create_user = driver.FindElement(By.Id("create-user"));
            create_user.Click();
            IWebElement email = driver.FindElement(By.Id("email"));
            email.Clear(); 
            email.SendKeys("johndoe@hotmail.com");
            String getEmail = email.GetAttribute("value");
            Console.WriteLine(getEmail); 
            IWebElement account = driver.FindElement(By.XPath("//span[contains(text(),'Create an account')]"));
            account.Click();

            Console.WriteLine("Create a new user!");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            //}

        }
    }
}