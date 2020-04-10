using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject1.PageObjects.AddEmployee;
using UnitTestProject1.PageObjects.Controllers;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace UnitTestProject1.PageObjects
{
    public class EmployeesPage
    {
        private IWebDriver driver;
        //private By addButton = By.XPath("//div[contains(@class, 'fixed-action-btn')]");
        private By addButton = By.Id("menu_pim_addEmployee");


        public EmployeesPage(IWebDriver browser)
        {
            driver = browser;
        }

        public AddEmployeePage NavigateToAddEmployeePage()
        {
            // driver.SwitchTo().Frame(driver.FindElement(By.Id("noncoreIframe")));
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(ExpectedConditions.ElementIsVisible(addButton));
            driver.FindElement(addButton).Click();
            //driver.SwitchTo().DefaultContent();
            return new AddEmployeePage(driver);
        }

    }
}
