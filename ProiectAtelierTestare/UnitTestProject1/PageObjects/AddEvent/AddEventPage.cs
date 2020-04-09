using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace UnitTestProject1.PageObjects.AddEvent
{
    public class AddEventPage
    {
        private IWebDriver driver;

        public AddEventPage(IWebDriver browser)
        {
            driver = browser;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(addEvent_name));
        }

        private By addEvent_name = By.Id("OhrmJob_name");
        private IWebElement Name => driver.FindElement(addEvent_name);

        private IWebElement Location => driver.FindElement(By.Id("addCourse_coordinator_empName"));

        private IWebElement Date => driver.FindElement(By.Id("jobDueDate_root"));

        private IWebElement Participant => driver.FindElement(By.Id("OhrmJob_newHires"));

        private IWebElement  Owner => driver.FindElement(By.Id("OhrmJob_owners"));

        private IWebElement SaveButton => driver.FindElement(By.Id("createButton"));

        public IWebElement SuccessMessage => driver.FindElement(By.ClassName("toast-message"));

        public void AddEvent(AddEventBO events)
        {
            Name.SendKeys(events.Name);
            
            Date.SendKeys(events.Date);
            driver.FindElements(By.ClassName("btn-flat picker__today"))[0].Click();

            Participant.SendKeys(events.Participant);
            driver.FindElements(By.ClassName("ac_even ac_over"))[0].Click();

            Owner.SendKeys(events.Owner);
            driver.FindElements(By.ClassName("ac_even ac_over"))[0].Click();

            Location.SendKeys(events.Location);
            driver.FindElements(By.XPath("iframe#noncoreIframe //span[contains(text(), 'Australian Regional HQ')]"))[0].Click();


            SaveButton.Click();

            //var selectSubunit = new SelectElement(Subunit);
            //selectSubunit.SelectByText("Architecture Team");

            //driver.FindElements(By.ClassName("select-dropdown"))[0].Click();
            //var dropdownOption = By.XPath("//span[text()='Architecture Team']");
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            //wait.Until(ExpectedConditions.ElementIsVisible(dropdownOption));
            //driver.FindElement(dropdownOption).SendKeys("Architecture Team");

            //driver.FindElement(dropdownOption).Click();

            //var dropdownOption = By.CssSelector("li:nth-child(2)");
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            //wait.Until(ExpectedConditions.ElementIsVisible(dropdownOption));
            //driver.FindElement(dropdownOption).Click();

            //var dropdownOptions = By.ClassName("dropdown-content");
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            //wait.Until(ExpectedConditions.ElementIsVisible(dropdownOptions));
            //driver.FindElements(dropdownOptions)[3].Click();

            Thread.Sleep(12000);
        }
    }
}
