using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject1.PageObjects.Controllers;

namespace UnitTestProject1.PageObjects
{
    public class HomePage
    {
        private IWebDriver driver;
        public LoggedInMenuItemControl menuItemControl => new LoggedInMenuItemControl(driver);

        public HomePage(IWebDriver browser)
        {
            driver = browser;
        }
    }
}
