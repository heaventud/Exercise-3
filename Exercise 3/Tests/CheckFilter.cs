using System;
using Exercise_3.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutoTests.Tests
{
    [TestFixture]
    public class SearchBoxTests : TestHelper
    {
        private string movieName;

        [SetUp]
        public void SetupTest()
        {
            CancelFilter();
            var movies = GetMovieNames();
            var index = rnd.Next(movies.Count);
            movieName = movies[index];

        }

        [Test]
        public void SearchBoxTest()
        {
            WebDriverWait wait = new WebDriverWait(browser.Driver, TimeSpan.FromSeconds(5));
            var loc = By.XPath("//div[@id='results']/a/div");

            var results_area = browser.FindElement(loc);
            SetFilter(movieName);
            wait.Until(ExpectedConditions.StalenessOf(results_area));
            wait.Until(ExpectedConditions.ElementIsVisible(loc));
            var movies = GetMovieNames();
            for (var i = 0; i < movies.Count; i++)
            {
                Assert.IsTrue(movies[i] == movieName);
            }

            foreach (var code in ProxyHelper.GetAllResponseCodes())
            {
                Assert.IsTrue(code < 400 | code > 500);
            }
        }
    }

    [TestFixture]
    public class SearchBoxNegativeTests : TestHelper
    {
        private readonly string fakeName = "abracadabra";

        [SetUp]
        public void SetupTest()
        {
            SetFilter(fakeName);
        }
        
        [Test]
        public void SearchBoxNegativeTest()
        {
            var movies = GetMovieNames();
            Assert.IsFalse(movies.Contains(fakeName));

            foreach (var code in ProxyHelper.GetAllResponseCodes())
            {
                Assert.IsTrue(code < 400 | code > 500);
            }
        }
    }
}
