using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UnitTestProject1.PageObjects.AddTrainingSession;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace UnitTestProject1.PageObjects
{
    public class TrainingSessionsPage
    {
        private IWebDriver driver;
        private By newTrainingSession = By.Id("addItemBtn");
        private By chkList = By.Id("checkbox_ohrmList_chkSelectRecord_15");
        private By dotsActions = By.Id("frmList_ohrmListComponent_Menu");
        private By deleteTrainingSession = By.Id("deleteSession");
        private By popDeleteAction = By.Id("modal-delete-session");
        private By confirmDelete = By.Id("session-delete-button");
        private By notice = By.ClassName("toast-message");
        private IWebElement LblNotice => driver.FindElement(notice);
        public string NoticeText => LblNotice.Text;
        public TrainingSessionsPage(IWebDriver browser)
        {
            driver = browser;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        public AddTrainingSessionPage NavigateToAddTrainingSessionPage()
        {
            driver.SwitchTo().Frame(driver.FindElement(By.Id("noncoreIframe")));
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(newTrainingSession));
            driver.FindElement(newTrainingSession).Click();
            return new AddTrainingSessionPage(driver);
        }

        public void DeleteTrainingSession()
        {
            driver.SwitchTo().Frame(driver.FindElement(By.Id("noncoreIframe")));
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(dotsActions));
            driver.FindElement(chkList).Click();
            driver.FindElement(dotsActions).Click();
            driver.FindElement(deleteTrainingSession).Click();
            driver.FindElement(confirmDelete).Click();
        }

        public void SearchFilter(string titleName)
        {
            var searchModal = By.Id("searchModal");
            driver.FindElement(searchModal).Click();
            driver.FindElement(By.Id("searchSession_name")).SendKeys(titleName);
            var searchButton = By.Id("searchBtn");
            driver.FindElement(searchButton).Click();
        }
    }
}
