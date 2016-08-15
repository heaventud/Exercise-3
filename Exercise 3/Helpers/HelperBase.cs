using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutoTests.Common
{
    public class HelperBase
    {
        protected Browser browser = BrowserEnvironment.GetBrowser();

        protected static Random rnd = new Random();

        
        protected void Type(By locator, string text)
        {
            if (text != null)
            {
                browser.FindElement(locator).Clear();
                browser.FindElement(locator).SendKeys(text);
            }
        }

        protected void SelectValue(By locator, string value)
        {
            var select = new SelectElement(browser.FindElement(locator));
            if (value != null)
            {
                select.SelectByValue(value);
            }
        }

        protected bool IsElementPresent(By by)
        {
            try
            {
                browser.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
