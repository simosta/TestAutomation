using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Page
{
    public class DropDownDemoPage : BasePage
    {
        private const string _pageAdress = "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";
        private const string _defaultTextForDaySelected = "Day selected :- ";
        private const string _defaultTextForFirstSelected = "First selected option is : ";
        private const string _defaultTextForAllSelected = "Options selected are : ";
        private SelectElement _firstDropDown => new SelectElement(Driver.FindElement(By.Id("select-demo")));
        private SelectElement _multiDropDown => new SelectElement(Driver.FindElement(By.Id("multi-select")));
        private IWebElement _visibleTextForDaySelected => Driver.FindElement(By.CssSelector(".selected-value"));

        private IWebElement _firstSelectedButton => Driver.FindElement(By.Id("printMe"));
        private IWebElement _allSelectedButton => Driver.FindElement(By.Id("printAll"));
        private IWebElement _visibleTextMultipleSelected => Driver.FindElement(By.CssSelector(".getall-selected"));
       
        public DropDownDemoPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = _pageAdress;
        }

        public void SelectFromDropDownByValue(string value)
        {
            _firstDropDown.SelectByText(value);
        }

        public void VerifySelectedValue(string value)
        {
            Assert.IsTrue((_defaultTextForDaySelected + value).Equals(_visibleTextForDaySelected.Text), "Result is NOK");
        }

        public void SelectFromMultipleDropDown(string[] statelist)
        {
            Actions action = new Actions(Driver);
            action.KeyDown(Keys.Control);
            foreach (string state in statelist)
            {
                foreach (IWebElement option in _multiDropDown.Options)
                {
                    if (state.Equals(option.GetAttribute("value")))
                    {
                        option.Click();
                    }
                }
            }
            action.KeyUp(Keys.Control);
            action.Build().Perform();
        }
        /*public void SelectFromMultipleDropDown(List<string> statelist)
        {
            Actions action = new Actions(Driver);
            action.KeyDown(Keys.Control);
            foreach (string state in statelist)
            {
                foreach (IWebElement option in _multiDropDown.Options)
                {
                    if (state.Equals(option.GetAttribute("value")))
                    {
                        option.Click();
                    }
                }
            }
            action.KeyUp(Keys.Control);
            action.Build().Perform();
        }*/


        public void ClickFirstSelectedButton()
        {
            _firstSelectedButton.Click();
        }
        public void ClickAllSelectedButton()
        {
            _allSelectedButton.Click();
        }

        public void VerifyFirstSelected(string firstState)
        {
            Assert.AreEqual((_defaultTextForFirstSelected + firstState), _visibleTextMultipleSelected.Text, $"{_visibleTextMultipleSelected.Text} Result is NOK");
        }

      /*  public void VerifyAllSelected()
        {
            Assert.AreEqual((_defaultTextForAllSelected + firstState), _visibleTextMultipleSelected.Text, $"{_visibleTextMultipleSelected.Text} Result is NOK");
        }*/


    }
}
