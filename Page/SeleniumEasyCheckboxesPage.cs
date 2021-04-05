using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Page
{
    public class SeleniumEasyCheckboxesPage : BasePage
    {
        private const string pageAddress = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
        private static IWebElement firstCheckBox => Driver.FindElement(By.Id("isAgeSelected"));
        private static IReadOnlyCollection<IWebElement> multipleCheckBoxList => Driver.FindElements(By.CssSelector(".cb1-element"));
        private static IWebElement text => Driver.FindElement(By.Id("txtAge"));
        private static IWebElement button => Driver.FindElement(By.Id("check1"));
        private static bool all_unchecked = true;


        public SeleniumEasyCheckboxesPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = pageAddress;
        }


        public void SelectAndClickFirstCheckBox()
        {
            if (!firstCheckBox.Selected)
                firstCheckBox.Click();
        }

        public void VerifyIfSuccessMessageVisible()
        {
            Assert.IsTrue("Success - Check box is checked".Equals(text.Text), "Result is NOK");
        }

        public void SelectBottomFour()
        {
            UnselectFirstCheck();
            foreach (IWebElement checkbox in multipleCheckBoxList)
            {
                if (!checkbox.Selected)
                    checkbox.Click();
            }
        }

        public void VerifyIfUncheckAllVisible()
        {
            Assert.IsTrue("Uncheck All".Equals(button.GetAttribute("value")));
        }

        public void ButtonClick()
        {
            button.Click();
        }

        public void VerifyIfUnchecksAll()
        {
            foreach (IWebElement checkbox in multipleCheckBoxList)
            {
                if (checkbox.Selected)
                    all_unchecked = false;
                Assert.IsTrue(all_unchecked, "Uncheck all did not produce expected results");
            }
        }

        private static void UnselectFirstCheck()
        {
            if (firstCheckBox.Selected)
                firstCheckBox.Click();
        }

    }
}
