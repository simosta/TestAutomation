using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;


namespace TestAutomation.Page
{
    public class CheckYourBrowserPage : BasePage
    {
        public static IWebElement text => Driver.FindElement(By.CssSelector(".simple-major"));
        public CheckYourBrowserPage(IWebDriver webdriver) : base(webdriver) { } //konstruktorius

        public static void TestResult(string result, IWebDriver webdriver)
        {
            WaitForElementToBeDisplayed(text);
            Assert.IsTrue(text.Text.Contains(result), "Browser name is not displayed correctly");
            ClosePage(webdriver);
        }

        public static IWebDriver SelectBrowser(string browser)
        {
            if ("chrome".Equals(browser))
                Driver = new ChromeDriver();
            else if ("firefox".Equals(browser))
                Driver = new FirefoxDriver();
            else
                throw new Exception("Browser is not supported");
            return Driver;
        }
        public static void GoToPage(IWebDriver webdriver)
        {
            webdriver.Url = "https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent";
            webdriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            webdriver.Manage().Window.Maximize();
        }
        private static void ClosePage(IWebDriver webdriver)
        {
            webdriver.Quit();
        }
        private static void WaitForElementToBeDisplayed(IWebElement webElement)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(webdriver => webElement.Displayed);
        }
    }
}
