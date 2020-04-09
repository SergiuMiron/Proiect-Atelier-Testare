using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject1.PageObjects.AddIDP;
using UnitTestProject1.PageObjects.Controllers;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace UnitTestProject1.PageObjects
{
    public class IDPPage
    {
        private IWebDriver driver;
        //private By addButton = By.XPath("//div[contains(@class, 'fixed-action-btn')]");
        private By addButton = By.Id("acac3985-2819-c64e-3384-b60af806b676");


        public IDPPage(IWebDriver browser)
        {
            driver = browser;
        }

        public AddIDPPage NavigateToAddIDPPage()
        {
            driver.SwitchTo().Frame(driver.FindElement(By.Id("noncoreIframe")));
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(addButton));
            driver.FindElement(addButton).Click();
            //driver.SwitchTo().DefaultContent();
            return new AddIDPPage(driver);
        }

    }
}
