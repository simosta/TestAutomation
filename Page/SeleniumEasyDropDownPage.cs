/*Užduotis:
Puslapiui https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html 2 testus naudojant Page Object Patterna:
1) Pažymime 2 valstijas, spaudžiame "First Selected" mygtuką - patikrinam, ar rezultatas teisingas, rodo pirmą pažymėtą valstiją.
2) Pažymime 2 valstijas, spaudžiame "Get All Selected" mygtuką - patikrinam, ar rezultatas teisingas, rodo visas užžymėtas valstijas.
3) Pažymime 3 valstijas, spaudžiame "First Selected" mygtuką - patikrinam, ar rezultatas teisingas, rodo pirmą pažymėtą valstiją.
4) Pažymime 4 valstijas, spaudžiame "Get All Selected" mygtuką - patikrinam, ar rezultatas teisingas, rodo visas užžymėtas valstijas.*/
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
    public class SeleniumEasyDropDownPage : BasePage
    {
        private const string _pageAdress = "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";
        private const string _defaultTextForFirstSelected = "First selected option is : ";
        private const string _defaultTextForAllSelected = "Options selected are : ";
        private SelectElement _multiDropDown => new SelectElement(Driver.FindElement(By.Id("multi-select")));
        private IWebElement _firstSelectedButton => Driver.FindElement(By.Id("printMe"));
        private IWebElement _allSelectedButton => Driver.FindElement(By.Id("printAll"));
        private IWebElement _visibleTextMultipleSelected => Driver.FindElement(By.CssSelector(".getall-selected"));

        public SeleniumEasyDropDownPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = _pageAdress;
        }
        public void SelectFromMultipleDropDown(string[] statelist)
        {
            ClearOutSelections();
            Actions action = new Actions(Driver);
            action.KeyDown(Keys.Control);
            foreach (string state in statelist)
            {
                foreach (IWebElement option in _multiDropDown.Options)
                {
                    if (state.Equals(option.GetAttribute("value")) && !option.Selected)
                    {
                        option.Click();
                    }
                }
            }
            action.KeyUp(Keys.Control);
            action.Build().Perform();
        }
        public void ClickFirstSelectedButton()
        {
            _firstSelectedButton.Click();
        }
        public void VerifyFirstSelected(string firstState)
        {
            Assert.AreEqual((_defaultTextForFirstSelected + firstState), _visibleTextMultipleSelected.Text, $"{_visibleTextMultipleSelected.Text} Result is NOK");
        }
        public void ClickAllSelectedButton()
        {
            _allSelectedButton.Click();
        }
        public void VerifyAllSelected(string[] states)
        {
            string statesconcat = "";
            for (int i = 0; i < states.Length-1; i++)
            {
                statesconcat = statesconcat + states[i] + ",";
            }
            statesconcat = statesconcat + states[states.Length - 1];
            
            Assert.AreEqual((_defaultTextForAllSelected + statesconcat), _visibleTextMultipleSelected.Text, $"{_visibleTextMultipleSelected.Text} Result is NOK");
        }

        private void ClearOutSelections()
        {
            foreach (IWebElement option in _multiDropDown.Options)
            {
                if (option.Selected)
                {
                    option.Click();
                }
            }
        }
        
    }


}
