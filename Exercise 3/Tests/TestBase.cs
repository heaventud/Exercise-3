using System;
using AutoTests.Common;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace AutoTests.Tests
{
    public class TestBase : LoginHelper
    {
        //protected Browser browser;

        [OneTimeSetUp]
        public void SetUp()
        {
            browser = BrowserEnvironment.GetBrowser();
        }

        protected static Random rnd = new Random();
    }
}
