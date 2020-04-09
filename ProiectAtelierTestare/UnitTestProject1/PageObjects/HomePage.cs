using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject1.PageObjects.Controllers;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace UnitTestProject1.PageObjects
{
    public class HomePage
    {
        private IWebDriver driver;
        public LoggedInMenuItemControl menuItemControl => new LoggedInMenuItemControl(driver);

        public HomePage(IWebDriver browser)
        {
            driver = browser;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(userName));
        }

        private By userName = By.Id("account-name");
        private IWebElement btnUser => driver.FindElement(userName);

        private IWebElement BtnTraining => driver.FindElement(By.Id("menu_training_defaultTrainingModulePage"));
        private IWebElement BtnCourses => driver.FindElement(By.Id("menu_training_viewCourseList"));
        private IWebElement BtnOnBoarding => driver.FindElement(By.Id("menu_onboarding_defaultMenuView"));

        private By sessions = By.Id("menu_training_viewSessionList");
        private IWebElement BtnSessions => driver.FindElement(sessions);

        private By taskTypes = By.Id("menu_onboarding_viewTaskTypes");
        private IWebElement BtnTaskTypes => driver.FindElement(taskTypes);

        public CoursesPage NavigateToCoursesPage()
        {
            BtnTraining.Click();
            BtnCourses.Click();
            return new CoursesPage(driver);
        }

        public TrainingSessionsPage NavigateToTrainingSessionsPage()
        {
            BtnTraining.Click();
            BtnSessions.Click();
            return new TrainingSessionsPage(driver);
        }

        public TaskTypesPage NavigatetoTaskTypesPage()
        {
            BtnOnBoarding.Click();
            BtnTaskTypes.Click();
            return new TaskTypesPage(driver);
        }
    }
}
