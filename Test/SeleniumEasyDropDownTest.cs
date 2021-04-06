/*Užduotis:
Puslapiui https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html 2 testus naudojant Page Object Patterna:
1) Pažymime 2 valstijas, spaudžiame "First Selected" mygtuką - patikrinam, ar rezultatas teisingas, rodo pirmą pažymėtą valstiją.
2) Pažymime 2 valstijas, spaudžiame "Get All Selected" mygtuką - patikrinam, ar rezultatas teisingas, rodo visas užžymėtas valstijas.
3) Pažymime 3 valstijas, spaudžiame "First Selected" mygtuką - patikrinam, ar rezultatas teisingas, rodo pirmą pažymėtą valstiją.
4) Pažymime 4 valstijas, spaudžiame "Get All Selected" mygtuką - patikrinam, ar rezultatas teisingas, rodo visas užžymėtas valstijas.*/

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
    
    public class SeleniumEasyDropDownTest
    {
        private static SeleniumEasyDropDownPage _page;

        [OneTimeSetUp]
        public static void Setup()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            _page = new SeleniumEasyDropDownPage(driver);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _page.CloseBrowser();
        }
        //valid options  California,Florida,New Jersey,New York,Ohio,Texas,Pennsylvania,Washington

        [TestCase("Pennsylvania", "Texas", TestName = "Last selected is Texas")]//1 dalis
        [TestCase("Pennsylvania", "Washington", "California", TestName = "Last selected is California")]//2 dalis

        public static void TestIfFirstSelectedIsCorrect(params string[] states)//iš tikro tai paskutinę visada rodo
        {
            _page.SelectFromMultipleDropDown(states);
            _page.ClickFirstSelectedButton();
            _page.VerifyFirstSelected(states[0]);
        }
        
        
        [TestCase("Pennsylvania", "Texas", "Florida", TestName = "Pennsylvania,Texas,Florida")]
        [TestCase("Pennsylvania", "Texas", "Florida", "California", TestName = "Pennsylvania,Texas,Florida,California")]
        public static void TestIfGetAllSelectedIsCorrect(params string[] states)//ir čia paskutinę
        {
            _page.SelectFromMultipleDropDown(states);
            _page.ClickAllSelectedButton();
            _page.VerifyAllSelected(states);
        }
    }
}
