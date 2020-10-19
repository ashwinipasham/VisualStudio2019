using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProject1
{
    class FakerDataUsingSelenium
    {
        [Test]
        public void FakerDataGenerator()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Navigate().GoToUrl("http://demo.automationtesting.in/Register.html");

            //Generate random data using Faker Api
            String firstname = Faker.Name.First();
            String lastname = Faker.Name.Last();
            String email = Faker.Internet.Email(firstname);
            String phone = Faker.Phone.Number().Replace("-", "").Replace(".", "").Replace("x", "").Replace("(", "").Replace(")", "").Substring(0,10);
            //int phone = Faker.RandomNumber.Next(0, 10); 


            IWebElement firstName_TextBox = driver.FindElement(By.XPath("//input[@placeholder='First Name']"));
            IWebElement lastName_TextBox = driver.FindElement(By.XPath("//input[@placeholder='Last Name']"));
            IWebElement email_textBox = driver.FindElement(By.XPath("//*[@id='eid']/input"));
            IWebElement phone_textbox = driver.FindElement(By.XPath("//*[@id='basicBootstrapForm']/div[4]/div/input"));
            IWebElement gender_radioButtton = driver.FindElement(By.XPath("//label[1]//input[1]"));
            IWebElement country = driver.FindElement(By.XPath("//select[@id='countries'] "));
            SelectElement country_dropDown = new SelectElement(country); 
            IWebElement DOB_year_textbox = driver.FindElement(By.XPath("//select[@placeholder='Year']"));
            SelectElement dob_Dropdown = new SelectElement(DOB_year_textbox);
            IWebElement DOB_month_textbox = driver.FindElement(By.XPath("//select[@placeholder='Month']"));
            SelectElement dob_month_dropDown = new SelectElement(DOB_month_textbox); 
            IWebElement DOB_day_textbox = driver.FindElement(By.XPath("//select[@placeholder='Day']"));
            SelectElement dob_day_dropDown = new SelectElement(DOB_day_textbox); 

            IWebElement firstPwd = driver.FindElement(By.XPath("//*[@id='firstpassword']"));
            IWebElement secondPwd = driver.FindElement(By.XPath("//*[@id='secondpassword']"));

            IWebElement submit_Button = driver.FindElement(By.XPath("//button[@id='submitbtn']"));

            //feeding data to fields
            firstName_TextBox.SendKeys(firstname);
            lastName_TextBox.SendKeys(lastname);
            email_textBox.SendKeys(email);
            phone_textbox.SendKeys(phone);
            gender_radioButtton.Click();
            country_dropDown.SelectByValue("India");
            dob_Dropdown.SelectByIndex(7);
            dob_month_dropDown.SelectByText("March");
            dob_day_dropDown.SelectByValue("11");
            firstPwd.SendKeys("Selenium@123");
            secondPwd.SendKeys("Selenium@123"); 
            submit_Button.Click();


        }

    }
}
