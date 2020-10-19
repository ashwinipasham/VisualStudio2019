using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Chrome;
using System;

namespace AppiumClientDemo
{
    public class Tests
    {


        private AppiumDriver<AndroidElement> appdriver;

        [SetUp]
        public void Setup()
        {

            var appPath = "com.android.calculator2";

            //platformName, deviceName, application - file path 
            var driverOption = new AppiumOptions();
            driverOption.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            driverOption.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Android 28");
            driverOption.AddAdditionalCapability(MobileCapabilityType.App, appPath);

            driverOption.AddAdditionalCapability("chromedriverExecutable", @"C:\driver\Chromedriver\");

            appdriver = new AndroidDriver<AndroidElement>(new Uri("http://localhost:4723/wd/hub"), driverOption);


        }

        [Test]
        public void TestCal()
        {
            ChromeWebElement two = appdriver.FindElementById(digit_2);
            two.Click();

            ChromeWebElement plus = appdriver.FindElementById(op_add);
            plus.Click();

            ChromeWebElement eight -appdriver.FindElementById(digit_8);
            eight.Click();

            ChromeWebElement eq = appdriver.FindElementById(eq);
            eq.Click();

            //locate the edit box of the calculator by using By.tagName()
            ChromeWebElement results = appdriver.FindElementById(result));
            //Check the calculated value on the edit box
            assert results.getText().equals("10"):"Actual value is : " + results.getText() + " did not match with expected value: 6";


            Assert.Pass();
        }

        [TearDown]
        public void TearDown()
        {
            appdriver.Quit(); 
        }


    }
}