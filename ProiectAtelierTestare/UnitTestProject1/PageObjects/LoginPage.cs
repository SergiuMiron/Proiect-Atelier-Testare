using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace UnitTestProject1.PageObjects
{
    class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver browser)
        {
            driver = browser;
        }

        private IWebElement TxtUsername()
        {
            return driver.FindElement(By.Id("txtUsername"));
        }

        private IWebElement TxtPassword()
        {
            return driver.FindElement(By.Id("txtPassword"));
        }

        private IWebElement BtnLogin()
        {
            return driver.FindElement(By.Id("btnLogin"));
        }

        private IWebElement BtnDropDownOptions()
        {
            return driver.FindElement(By.ClassName("dropdown-toggle"));
        }

        private IWebElement UserKevin()
        {
            return driver.FindElement(By.XPath("//*[@data-username='kevin']"));
        }

        public void LoginApplication(string username, string password)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            TxtUsername().Clear();
            TxtPassword().Clear();
            TxtUsername().SendKeys(username);
            TxtPassword().SendKeys(password);
            BtnLogin().Click();
        }

        public void DifferentLogin()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            BtnDropDownOptions().Click();
            UserKevin().Click();
        }
    }
}
