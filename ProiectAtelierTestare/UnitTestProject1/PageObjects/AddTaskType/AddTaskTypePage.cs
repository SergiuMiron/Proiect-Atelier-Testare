using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace UnitTestProject1.PageObjects.AddTaskType
{
    public class AddTaskTypePage
    {
        private IWebDriver driver;

        public AddTaskTypePage(IWebDriver browser)
        {
            driver = browser;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(addTypeName));
        }

        private By addTypeName = By.Id("type_name");
        private IWebElement Name => driver.FindElement(addTypeName);
        private IWebElement NotifiedBeforeNr => driver.FindElement(By.Id("type_notified_before"));
        private IWebElement Owner => driver.FindElement(By.Id("type_owner_empName"));
        private IWebElement EmailAddress => driver.FindElement(By.Id("type_also_notify"));
        private IWebElement Description => driver.FindElement(By.Id("type_description"));
        private IWebElement SaveTaskButton => driver.FindElement(By.Id("saveTaskType"));
        public IWebElement SuccessMessage => driver.FindElement(By.ClassName("toast-message"));

        public void AddTaskType (AddTaskTypeBO task)
        {
            Name.SendKeys(task.Name);
            NotifiedBeforeNr.SendKeys(task.NotifiedBeforeNr);
            //Owner.SendKeys(task.Owner);
            EmailAddress.SendKeys(task.EmailAddress);
            Description.SendKeys(task.Description);
            SaveTaskButton.Click();
        }


    }
}
