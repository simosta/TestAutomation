/*Simona Ostachaviciute
2021 04 04*/
using OpenQA.Selenium;

namespace TestAutomation
{
    public class BasePage
    {
        protected static IWebDriver Driver;
        public BasePage(IWebDriver webdriver)
        {
            Driver = webdriver;
        }
    }
}
