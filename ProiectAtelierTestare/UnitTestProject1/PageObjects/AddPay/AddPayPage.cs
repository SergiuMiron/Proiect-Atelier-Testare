using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
namespace UnitTestProject1.PageObjects.AddPay
{
    public class AddPayPage
    {
        private IWebDriver driver;

        public AddPayPage(IWebDriver browser)
        {
            driver = browser;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(Name));
        }

        private By Name = By.Id("name");
        private IWebElement Name_Grade => driver.FindElement(Name);

        private IWebElement SaveButton => driver.FindElement(By.ClassName("modal-action waves-effect waves-green btn primary-btn"));

        public IWebElement SuccessMessage => driver.FindElement(By.ClassName("toast-message"));

        public void AddPay(AddPayBO course)
        {

            Name_Grade.SendKeys(course.Name);

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
