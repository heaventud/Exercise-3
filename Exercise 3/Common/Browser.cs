using System;
using System.Collections.ObjectModel;
using System.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using AutomatedTester.BrowserMob;
using Exercise_3.Helpers;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace AutoTests.Common
{
    public class Browser : ThreadLocal<IWebDriver>
    {
        private IWebDriver _driver;
        private ThreadLocal<IWebDriver> browser = new ThreadLocal<IWebDriver>(); 

        public Browser()
        {
        }
        
        public Browser(IWebDriver driver)
        {
            this._driver = driver;
            this.Value = _driver;
        }

        ~Browser()
        {
            try
            {
                _driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            } 
        }

        public IWebDriver Driver
        {
            get { return _driver; }
        }

        public IWebElement FindElement(By by)
        {
            return _driver.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return _driver.FindElements(by);
        }

        public IOptions Manage()
        {
            return _driver.Manage();
        }

        public ITargetLocator SwitchTo()
        {
            return _driver.SwitchTo();
        }

        public INavigation Navigate()
        {
            return _driver.Navigate();
        }

        public void Quit()
        {
            _driver.Quit();
        }

        public string Url
        {
            get { return _driver.Url; }
        }
    }
    
    public class BrowserEnvironment
    {
        public static Browser browser = new Browser();

        //public static Proxy seleniumProxy = new Proxy { HttpProxy = ProxyHelper.GetProxy().SeleniumProxy };

        public static Browser GetBrowser()
        {
            if (!browser.IsValueCreated)
            {
               Settings.WebBrowser = ConfigurationManager.AppSettings["BrowserType"];

                switch (Settings.WebBrowser)
                {
                    case "firefox":
                        browser = new Browser(new FirefoxDriver());;
                        break;
                    case "iexplore":
                        browser = new Browser(new InternetExplorerDriver(ConfigurationManager.AppSettings["IExplorerDriverPath"]));
                        break;
                    case "chrome":
                        var opts = new ChromeOptions();
                        opts.Proxy = new Proxy { HttpProxy = ProxyHelper.GetProxy().SeleniumProxy };
                        browser = new Browser(new ChromeDriver(ConfigurationManager.AppSettings["ChromeDriverPath"], opts));
                        break;
                    default:
                        throw new WebDriverException("There are no browsers");
                }
            }
            return browser;
        }
    }
}
