using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using PageFactoryCore;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace PageObjectModel
{
    class Hulu_homePageObjects
    {
        //Classical way of Intialize these objects using PageFactory (POM)
        //Type ctor - to construct a constructor
        /*public Hulu_homePageObjects(IWebDriver driver)
        {
           // PageFactory.InitElements(driver, this); 
          // SeleniumExtras.PageFactory.
        }

        //Find Search your trail button
        [FindsBy(How = How.ClassName, Using = "button--cta button--white Masthead__input-cta")]
        public IWebElement startYourTrail{ get; set; } 

        //Navigate toLogin App withinthe page
        [FindsBy(How = How.ClassName, Using = "navigation__login-button navigation__action-button navigation__cta")]
        public IWebElement logInPage{ get; set; }
        

        //Navigate to more deatils page
        [FindsBy(How = How.ClassName, Using = "dplusbanner__details")]
         public IWebElement moreDetailsPage { get; set; }*/

        private readonly RemoteWebDriver _driver; 

        public Hulu_homePageObjects(RemoteWebDriver driver)
        {
            _driver = driver; 
        }

        public IWebElement startYourTrail => _driver.FindElementByXPath("//button[@class='button--cta button--white Masthead__input-cta']");



        public IWebElement loginPage => _driver.FindElementByXPath("//a[@class='login__button']");

        public void Click()
        {
            startYourTrail.Click();
            Console.WriteLine("Page Clicked"); 
           // loginPage.Click(); 
        }

       
       
    }
}
