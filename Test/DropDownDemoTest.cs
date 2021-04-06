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
    class DropDownDemoTest
    {
        private static DropDownDemoPage _page;
        
        [OneTimeSetUp]
        public static void Setup()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            _page = new DropDownDemoPage(driver);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            //_page.CloseBrowser();
        }

        /*[TestCase("Friday", TestName = "TestIfFridayIsCorrect")]
        public static void TestSimpleDropDown(string dayOfWeek)
        {
            _page.SelectFromDropDownByValue(dayOfWeek);
            _page.VerifySelectedValue(dayOfWeek);
        }*/

        [TestCase("Ohio", "Florida", "California", TestName = "First selected Ohio")]
        [TestCase("California", "Florida", TestName = "First selected California")]
        
        /*public static void TestMultipleDropDownFirstSelelcted(string states)
        {
            List<string> state = states.Split(',').ToList();
            _page.SelectFromMultipleDropDown(state);
            _page.ClickFirstSelectedButton();
            _page.VerifyFirstSelected(state[0]);
        }*/
        public static void TestMultipleDropDownFirstSelelcted(params string[] states)
        {
            _page.SelectFromMultipleDropDown(states);
            _page.ClickFirstSelectedButton();
            _page.VerifyFirstSelected(states[0]);
        }
    }
}
