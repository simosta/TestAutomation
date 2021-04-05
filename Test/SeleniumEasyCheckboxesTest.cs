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
        private static SeleniumEasyCheckboxesPage _page;

        [OneTimeSetUp]
        public static void Setup()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            _page = new SeleniumEasyCheckboxesPage(driver);
        }
        
        [OneTimeTearDown]
        public static void TearDown()
        {
            _page.CloseBrowser();
        }
        //[Order(1)] jei norėčiau iš eilės leisti testus, nes dabar leidžia pgl abc
        [Test]
        public static void TestSoloCheckbox()
        {
            _page.SelectAndClickFirstCheckBox();
            _page.VerifyIfSuccessMessageVisible();
        }

        [Test]
        public static void TestFourBottomCheckboxesSelected()
        {
            _page.SelectBottomFour();
            _page.VerifyIfUncheckAllVisible();
        }

        [Test]
        public static void TestIfUncheckAllWorks()
        {
            _page.SelectBottomFour();
            _page.ButtonClick();
            _page.VerifyIfUnchecksAll();
        }
    }
}
