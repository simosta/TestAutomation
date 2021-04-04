using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomation.Page;

namespace TestAutomation.Test
{
    public class SeleniumEasyCheckboxesTest
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]
        public static void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
            
        }
        
        [OneTimeTearDown]
        public static void TearDown()
        {
            _driver.Quit();
        }
        
        [Test]
        public static void TestSoloCheckbox()
        {
            SeleniumEasyCheckboxesPage page = new SeleniumEasyCheckboxesPage(_driver);
            //page.SelectAndClickFirstCheckBox();
            page.TestResultFirstCheckboxClicked();
        }

        [Test]
        public static void TestFourBottomCheckboxesSelected()
        {
            SeleniumEasyCheckboxesPage page = new SeleniumEasyCheckboxesPage(_driver);
            page.TestIfUncheckAllvisible();
        }
        [Test]
        public static void TestIfUncheckAllWorks()
        {
            SeleniumEasyCheckboxesPage page = new SeleniumEasyCheckboxesPage(_driver);
            page.TestIfUnchecksAll();
        }
    }
}
