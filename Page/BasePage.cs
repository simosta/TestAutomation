/*Simona Ostachaviciute
2021 04 04*/
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestAutomation
{
    public class BasePage
    {
        protected static IWebDriver Driver;
        public BasePage(IWebDriver webdriver)
        {
            Driver = webdriver;
        }

        public void CloseBrowser()
        {
            Driver.Quit();
        }
        public WebDriverWait GetWait(int seconds = 5)
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds));
        }

    }
}
