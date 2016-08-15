using OpenQA.Selenium;

namespace AutoTests.Common
{
    public class LoginHelper : HelperBase
    {
        public void Login(string account, string passwd)
        {
            if (IsLoggedIn())
            { 
                if (IsLoggedIn(account))
                {
                    return;
                }

                Logout();
            }
            Type(By.XPath("//input[@name='username']"), account);
            Type(By.XPath("//input[@name='password']"), passwd);
            browser.FindElement(By.CssSelector("input[type='submit']")).Click();
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                browser.FindElement(By.LinkText("Logout")).Click();
            }
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }

        public bool IsLoggedIn(string account)
        {
            return IsLoggedIn() && browser.FindElement(By.Name("logout"))
                .FindElement(By.TagName("b")).Text
                   == "(" + account + ")";
        }

    }
}
