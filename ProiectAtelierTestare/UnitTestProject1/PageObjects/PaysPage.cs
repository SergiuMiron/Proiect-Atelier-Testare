using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnitTestProject1.PageObjects.AddPay;
using UnitTestProject1.PageObjects.Controllers;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace UnitTestProject1.PageObjects
{
    public class PaysPage
    {
        private IWebDriver driver;
        //private By addButton = By.XPath("//div[contains(@class, 'fixed-action-btn')]");
        private By addButton = By.CssSelector("[data-tooltip='Add Pay Grade']");


        public PaysPage(IWebDriver browser)
        {
            driver = browser;
            Thread.Sleep(3000);
            // var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
            //wait.Until(ExpectedConditions.ElementIsVisible(addButton));
        }

        public AddPayPage NavigateToAddPaysPage()
        {
            driver.SwitchTo().Frame(driver.FindElement(By.Id("noncoreIframe")));
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(addButton));
            driver.FindElement(addButton).Click();
            //driver.SwitchTo().DefaultContent();
            return new AddPayPage(driver);
        }
    }
}
