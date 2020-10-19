using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProject1
{
    class TestDataGeneartorForSelenium
    {

        [Test]
        public void RandomTestDataInSelenium()
        {
            //Browser intialization and navigating to the URL.
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Navigate().GoToUrl("http://demo.automationtesting.in/Register.html");

            //Creating random data
            Random r = new Random();

            String firstname = $"firstname{r.Next()}";
            String lastname = $"lastname{r.Next()}";


            //Finding WebElements
            IWebElement firstName_TextBox = driver.FindElement(By.XPath("//input[@placeholder='First Name']"));
            IWebElement lastName_TextBox = driver.FindElement(By.XPath("//input[@placeholder='Last Name']"));
            IWebElement submit_Button = driver.FindElement(By.XPath("//button[@id='submitbtn']")); 

            //feeding the data to the feilds.
            firstName_TextBox.SendKeys(firstname);
            lastName_TextBox.SendKeys(lastname);
            submit_Button.Click(); 




           /* IWebElement address_TextBox = driver.FindElement(By.XPath("//input[@placeholder='First Name']"));
            IWebElement email_TextBox = driver.FindElement(By.XPath("//input[@placeholder='First Name']"));
            IWebElement phone_TextBox = driver.FindElement(By.XPath("//input[@placeholder='First Name']"));
*/






        }


    }
}
