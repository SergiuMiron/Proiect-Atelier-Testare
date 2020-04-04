using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1.PageObjects.Controllers
{
    public class MenuItemControl
    {
        public IWebDriver driver;

        public MenuItemControl(IWebDriver browser)
        {
            driver = browser;
        }
    }

    public class LoggedInMenuItemControl : MenuItemControl
    {
        private By userName = By.Id("account-name");
        private IWebElement LblUserName => driver.FindElement(userName);

        public LoggedInMenuItemControl(IWebDriver browser) : base(browser)
        {

        }

        public string UserNameText => LblUserName.Text;
    }
}
