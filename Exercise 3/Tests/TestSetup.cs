﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using NUnit.Framework;
using AutoTests.Common;
using Exercise_3.Helpers;

namespace AutoTests.Tests
{
    [SetUpFixture]
    public class TestSetup
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            Browser browser = BrowserEnvironment.GetBrowser();
            browser.Manage().Window.Maximize();
            browser.Navigate().GoToUrl(Settings.BrowserUrl);
            var loginHelper = new LoginHelper();
            loginHelper.Login("admin", "admin");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
           ProxyHelper.ProxyTeardown(); 
        }
    }
}
