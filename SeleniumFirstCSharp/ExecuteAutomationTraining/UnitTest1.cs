using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace ExecuteAutomationTraining
{
    [TestFixture]
    public class Tests
    {
        //create reference for our browser
        //IWebDriver PropertiesCollection.driver = new ChromeDriver(); 

        [SetUp]
        public void Setup()
        {
             PropertiesCollection.driver = new ChromeDriver();
            //Navigate to the URL page 
            PropertiesCollection.driver.Navigate().GoToUrl("https://demosite.executeautomation.com/index.html"); 
            
        }

        [Test]
        public void Test1()
        {


            ExcelDataReader util = new ExcelDataReader(); 
            util.ExceltoDataTable(@"C:\Users\Raju\Documents\Data.xlsx");


            //Title dropdown
            SeleniumSetMethods.SelectDropdown("TitleId", "Ms.", PropertyType.Id);

            //Name field
            SeleniumSetMethods.EnterText("FirstName", "Karthik", PropertyType.Id);

            //Get tte text to console
            Console.WriteLine("The value from my Title: " + SeleniumGetMethods.GetTextfromDDL("TitleId", PropertyType.Id));

            Console.WriteLine("The value from FirstName: " + SeleniumGetMethods.GetText("FirstName", PropertyType.Id));

            //Save button 
            SeleniumSetMethods.Click("Save", PropertyType.Name);
            Console.WriteLine("Clicked 'Save' button Successfully!"); 


            Assert.Pass();
        }

        
        [TearDown]
        public void TearDown()
        {
            //Exit the PropertiesCollection.driver
            PropertiesCollection.driver.Close(); 

        }
    }
}