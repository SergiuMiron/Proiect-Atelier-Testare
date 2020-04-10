using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnitTestProject1.PageObjects.AddEvent;
using UnitTestProject1.PageObjects.Controllers;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace UnitTestProject1.PageObjects
{
    public class EventsPage
    {
        private IWebDriver driver;
        //private By addButton = By.XPath("//div[contains(@class, 'fixed-action-btn')]");
        private By addButton = By.Id("addItemBtn");



        public EventsPage(IWebDriver browser)
        {
            driver = browser;
            // var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            // wait.Until(ExpectedConditions.ElementIsVisible(addButton));
        }

        public AddEventPage NavigateToAddEventsPage()
        {
            driver.SwitchTo().Frame(driver.FindElement(By.Id("noncoreIframe")));
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(addButton));
            driver.FindElement(addButton).Click();
            //driver.SwitchTo().DefaultContent();
            return new AddEventPage(driver);

        }

    }

}
