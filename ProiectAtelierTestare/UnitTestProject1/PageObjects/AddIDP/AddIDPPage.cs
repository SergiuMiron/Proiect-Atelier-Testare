using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace UnitTestProject1.PageObjects.AddIDP
{
    public class AddIDPPage
    {
        private IWebDriver driver;

        public AddIDPPage(IWebDriver browser)
        {
            driver = browser;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(employee));
        }

        private By employee = By.Id("owner_value");
        private IWebElement Employee => driver.FindElement(employee);

        private IWebElement Coach => driver.FindElement(By.Id("coach"));

        private IWebElement Description => driver.FindElement(By.Id("mceu_285"));

        private IWebElement SaveButton => driver.FindElement(By.CssSelector("[ng-click=buttonClick($event,form)]"));

        public IWebElement SuccessMessage => driver.FindElement(By.ClassName("toast-message"));

        public void AddIDP(AddIDPBO course)
        {
            
            Employee.SendKeys(course.Employee);
            driver.FindElements(By.ClassName("angucomplete-title"))[0].Click();

            Coach.SendKeys(course.Coach);
            driver.FindElements(By.ClassName("angucomplete-row angucomplete-selected-row"))[0].Click();
      
            Description.SendKeys(course.Description);

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

            Thread.Sleep(5000);
        }
    }
}
