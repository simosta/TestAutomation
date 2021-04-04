using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Page
{
    public class SeleniumEasyCheckboxesPage : BasePage
    {
        private static IWebElement firstCheckBox => Driver.FindElement(By.Id("isAgeSelected"));
        private static IReadOnlyCollection<IWebElement> multipleCheckBoxList => Driver.FindElements(By.CssSelector(".cb1-element"));
        private static IWebElement text => Driver.FindElement(By.Id("txtAge"));
        private static IWebElement button => Driver.FindElement(By.Id("check1"));
        
        private static bool all_unchecked = true;


        public SeleniumEasyCheckboxesPage(IWebDriver webdriver) : base(webdriver) { }

        private void SelectAndClickFirstCheckBox()
        {
            if (!firstCheckBox.Selected)
                firstCheckBox.Click();
        }

        public void TestResultFirstCheckboxClicked()
        {
            SelectAndClickFirstCheckBox();
            Assert.IsTrue("Success - Check box is checked".Equals(text.Text), "Result is NOK");
        }
        

        public void TestIfUncheckAllvisible()
        {
            UnselectFirstCheck();
            SelectBottomFour();
            Assert.IsTrue("Uncheck All".Equals(button.GetAttribute("value")));
        }

        public void TestIfUnchecksAll()
        {
            UnselectFirstCheck();
            SelectBottomFour();
            ButtonClick();
            foreach (IWebElement checkbox in multipleCheckBoxList)
            {
                if (checkbox.Selected)
                    all_unchecked = false;
                Assert.IsTrue(all_unchecked, "Uncheck all did not produce expected results");
            }
        }
        private static void ButtonClick()
        {
            button.Click();
        }
        private static void UnselectFirstCheck()
        {
            if (firstCheckBox.Selected)
                firstCheckBox.Click();
        }
        private static void SelectBottomFour()
        {

            foreach (IWebElement checkbox in multipleCheckBoxList)
            {
                if (!checkbox.Selected)
                    checkbox.Click();
            }
        }

    }
}
