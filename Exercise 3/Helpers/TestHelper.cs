using System;
using System.Collections.Generic;
using System.Linq;
using AutoTests.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Exercise_3.Helpers
{
    public class TestHelper : HelperBase
    {
        protected List<string> GetMovieNames()
        {
            WebDriverWait wait = new WebDriverWait(browser.Driver, TimeSpan.FromMilliseconds(1000));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='movie_box']/div[@class='title']")));
            List<string> movies = new List<string>();
            try
            {
                movies = browser.FindElements(By.XPath("//div[@class='movie_box']/div[@class='title']"))
                    .ToList().Select(x => x.Text).ToList();
            }
            catch (StaleElementReferenceException)
            {
                movies = browser.FindElements(By.XPath("//div[@class='movie_box']/div[@class='title']"))
                    .ToList().Select(x => x.Text).ToList();
            }
            if (movies.Count == 0)
            {
                return new List<string>();
            }
            return movies;
        }

        protected void SetFilter(string name)
        {
            var locator = By.XPath("//div[@class='searchbox']/input[1]");
            Type(locator, name);
            browser.FindElement(locator).SendKeys(Keys.Enter);
        }

        protected void CancelFilter()
        {
            var filter = browser.FindElement(By.XPath("//div[@class='searchbox']/input[1]"));
            filter.Clear();
            filter.SendKeys(Keys.Enter);
        }
    }
}
