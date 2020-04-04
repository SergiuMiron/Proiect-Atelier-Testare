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

    public class LoggedInMenuItemControl: MenuItemControl
    {
        private By user = By.CssSelector("#menu_admin_viewAdminModule .left-menu-title");
        private IWebElement LblUser => driver.FindElement(user);

        public LoggedInMenuItemControl(IWebDriver browser) : base(browser)
        {
        }

        public string AdminUser => LblUser.Text;
    }
}
