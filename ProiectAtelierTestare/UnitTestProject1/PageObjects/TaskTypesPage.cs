using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UnitTestProject1.PageObjects.AddTaskType;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace UnitTestProject1.PageObjects
{
    public class TaskTypesPage
    {
        private IWebDriver driver;
        private By newTaskType = By.Id("addItemBtn");
        private By chkList = By.Id("checkbox_ohrmList_chkSelectRecord_13");
        private By dotsActions = By.Id("frmList_ohrmListComponent_Menu");
        private By delete = By.Id("deleteTaskTypes");
        private By popDeleteAction = By.Id("modal-delete-session");
        private By confirmDelete = By.Id("task-delete-button");
        private By notice = By.ClassName("toast-message");

        public TaskTypesPage (IWebDriver browser)
        {
            driver = browser;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        public AddTaskTypePage NavigateToAddTaskTypePage()
        {
            driver.SwitchTo().Frame(driver.FindElement(By.Id("noncoreIframe")));
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(newTaskType));
            driver.FindElement(newTaskType).Click();
            return new AddTaskTypePage(driver);
        }

        public void DeleteTask()
        {
            driver.SwitchTo().Frame(driver.FindElement(By.Id("noncoreIframe")));
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(dotsActions));
            driver.FindElement(chkList).Click();
            driver.FindElement(dotsActions).Click();
            driver.FindElement(delete).Click();
            driver.FindElement(confirmDelete).Click();
        }
    }
}
