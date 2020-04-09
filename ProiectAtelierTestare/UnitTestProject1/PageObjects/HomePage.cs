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

        private IWebElement BtnOnBording => driver.FindElement(By.Id("menu_onboarding_defaultMenuView"));
        private IWebElement BtnEvents => driver.FindElement(By.Id("menu_onboarding_viewJobs"));


        private IWebElement BtnSD => driver.FindElement(By.Id("menu_succession & development_Succession&Development"));
        private IWebElement BtnIDP => driver.FindElement(By.Id("menu_succession & development_individualDevelopmentPlans"));

        public CoursesPage NavigateToCoursesPage()
        {
            BtnTraining.Click();
            BtnCourses.Click();
            return new CoursesPage(driver);
    
        }
        public EventsPage NavigateToEventsPage()
        {
            BtnOnBording.Click();
            BtnEvents.Click();
            return new EventsPage(driver);

        }
        public IDPPage NavigateToIDPPage()
        {
            BtnSD.Click();
            BtnIDP.Click();
            return new IDPPage(driver);

        }
    }
}
