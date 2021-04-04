using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TestAutomation.Page;


namespace TestAutomation.Test
{
    
    public class CheckYourBrowserTest
    {
        [TestCase("chrome", "Chrome")]
        [TestCase("firefox", "Firefox")]
        public static void TestBrowser(string browser, string result)
        {
            IWebDriver webdriver = CheckYourBrowserPage.SelectBrowser(browser);
            CheckYourBrowserPage page = new CheckYourBrowserPage(webdriver);
            page.GoToPage(webdriver);
            page.TestResult(result, webdriver);
        }
    }
}
