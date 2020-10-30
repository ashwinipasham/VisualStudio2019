using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using System;
using System.Threading;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace MenuControl_Selenium
{
    public class Tests 
    {
        IWebDriver driver;

        ExtentReports extent1 = null;
        ExtentTest test = null;
        ExtentTest test2;

        ExtentReports extent2;
        ExtentTest test3;


        [SetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://uitestpractice.com/"); 
        }

        [OneTimeSetUp]
        public void ExtentStart()
        {
            //extent1 = new ExtentReports();
            extent2 = new ExtentReports();
            //var htmlReporter = new ExtentHtmlReporter(@"C:\Users\Raju\Documents\Selenium\REports\MenuControl_Project.html");
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\Raju\source\repos\VisualStudio2019\MenuControl_Selenium\MenuControl_Selenium\ExtentReports\FirstReport.html");
            extent2.AttachReporter(htmlReporter); 
           // extent1.AttachReporter(htmlReporter); 
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            //Flush method is used to log all the test results
            extent2.Flush();
        }

        [Test]
        public void menuControl_Test()
        {
            test = extent1.CreateTest("Test1").Info("Test Started"); 
            //Scrolling the page to find the container 
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            System.Threading.Thread.Sleep(6000);
            js.ExecuteScript("window.scrollBy(273, 3250)");
            Console.WriteLine("Sroll down to find Menu Control");

            driver.FindElement(By.XPath("//div[@class='container SkyBlue']"));
            IWebElement menu = driver.FindElement(By.XPath("//ul[@id='menu']"));
            IWebElement menuItem = driver.FindElement(By.XPath("//li[@id='ui-id-15']"));
            IWebElement subMenu = driver.FindElement(By.XPath("//li[@id='ui-id-18']"));

            test.Log(Status.Info, "Chrome Browser launched and started testing"); 

            Actions action = new Actions(driver);

            action.ClickAndHold(menu)
                .MoveToElement(menuItem)
                .Release()
                .Build()
                .Perform();

            test.Log(Status.Info, "Menu has been clicked");
            test.Log(Status.Pass, "Test1 Passed");
            Console.WriteLine("Menu Control has been Clicked"); 
           
        }

        [Test]
        public void find_hiddenfeilds() 
        {
            test = extent1.CreateTest("Test1").Info("find Hidden elements Test Started"); 
            driver.Navigate().GoToUrl("http://uitestpractice.com/Students/Index");

            test.Log(Status.Info, "Browser launched and Clicked Edit btn"); 
            IWebElement EditBtn = driver.FindElement(By.XPath("//tbody/tr[2]/td[4]/button[1]"));
            EditBtn.Click();

            //Getting a screenshot from the websbrowser using Itakescreenshot interface

            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(@"C:\Users\Raju\Documents\Selenium\Edit Details.png");

            test.Log(Status.Info, "Screenshot captured"); 
            Console.WriteLine("Screenshot Captured");

            String s= ((IJavaScriptExecutor)driver).ExecuteScript("return document.getElementById('Id').value").ToString();
            Console.WriteLine(s);
            test.Log(Status.Info, "value recieved");
            test.Log(Status.Pass, "Test2 Passed");

            //// Second test has been started 

            try
            {
                test2 = extent1.CreateTest("Test2").Info("find Hidden elements Test Started");
                driver.Navigate().GoToUrl("http://uitestpractice.com/Students/Index");

                test2.Log(Status.Info, "Browser launched and Clicked Edit btn");
                IWebElement EditBtn1 = driver.FindElement(By.XPath("//tbody/tr[2]/td[4]/button[0]"));
                test2.Log(Status.Error, "Exception occured");
                EditBtn.Click();

                test2.Log(Status.Info, "Browser launched and Clicked Edit btn");

                String s1 = ((IJavaScriptExecutor)driver).ExecuteScript("return document.getElementById('Id').value").ToString();
                Console.WriteLine(s);
                test2.Log(Status.Info, "value recieved");
                test2.Log(Status.Pass, "Test2 Passed");

            }

            catch(Exception e)
            {
                Console.WriteLine(e);
                test2.Log(Status.Error, e); 
            }
        }

        [Test]
        public void HighlightElement()
        {
            driver.Navigate().GoToUrl("http://uitestpractice.com/Students/Index");

            // Highlight the searchData elements
            IWebElement searchData = driver.FindElement(By.Name("Search_Data"));

            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px dotted green'", searchData);

            Thread.Sleep(4000);
        }

        [Test]
        public void FileUpload()
        {
            driver.Navigate().GoToUrl("http://uitestpractice.com/Students/Widgets");

            driver.FindElement(By.Id("image_file")).SendKeys(@"C:\Users\Raju\Documents\Selenium\Nag_family.jpg");

            IWebElement uploadBtn = driver.FindElement(By.XPath("//input[contains(@value, 'Upload')]"));
            uploadBtn.Click();

            Console.WriteLine("File Uploaded successfully"); 


        }

        [Test]
        public void XpathAxes_Method()
        {
            Console.WriteLine("Adding the Extent Report logs for reference"); 
            test3 = extent2.CreateTest("Testing Xpath Axes features + Extent reports + Highlight").Info("Launching Actively open website "); 
            driver.Navigate().GoToUrl("https://read.activelylearn.com/#teacher/catalog?subject=science");

            test3.Log(Status.Info, "Searching for topics menu in Catalog with parameter Science");
            Thread.Sleep(3000);
            IWebElement Topics_Catalog = driver.FindElement(By.XPath("//div[@id='catalogNav']/child::button[2]"));
            Topics_Catalog.Click();

            test3.Log(Status.Info, "Catalog Menu is clicked");
            Console.WriteLine("Topics catalog is clicked");

            IWebElement menuItem = driver.FindElement(By.XPath("//div[contains(text(), 'Chemistry')]"));

            //IWebElement menuItem_Arrow = driver.FindElement(By.XPath("//div[contains(text(), 'Chemistry')]/following-sibling::span[1]"));
            test3.Log(Status.Info, "Inside the menu item, Chemistry topic is found");

            test3.Log(Status.Info, "Highight the Chemistry topic");
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].style.border='3px dotted red'", menuItem);
            Thread.Sleep(4000);

            test3.Log(Status.Info, "Thread Sleep for 4 secs");
            test3.Log(Status.Info, "Mouse hover on the Chemistry menu item to see the sub menu");
            Actions action1 = new Actions(driver);
            action1.MoveToElement(menuItem)
                .ClickAndHold(menuItem)
                .Build()
                .Perform();


            test3.Log(Status.Info, "Once the submenu is dispalyed, close the browser.");
            Console.WriteLine("Chemistry Topic has been selected");
            test3.Log(Status.Pass, "Test 3 Passed!");



        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit(); 
        }

        
    }

}