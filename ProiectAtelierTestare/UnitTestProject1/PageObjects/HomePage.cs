﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject1.PageObjects.Controllers;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using System.Threading;

namespace UnitTestProject1.PageObjects
{
    public class HomePage
        ////test
    {
        private IWebDriver driver;
        public LoggedInMenuItemControl menuItemControl => new LoggedInMenuItemControl(driver);

        public HomePage(IWebDriver browser)
        {
            driver = browser;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(userName));
        }
        private IWebElement PIM => driver.FindElement(By.Id("menu_pim_viewPimModule"));
        private IWebElement BtnEmployee => driver.FindElement(By.Id("menu_pim_viewEmployeeList"));

        private IWebElement BtnOnBording => driver.FindElement(By.Id("menu_onboarding_defaultMenuView"));
        private IWebElement BtnEvents => driver.FindElement(By.Id("menu_onboarding_viewJobs"));


        private IWebElement BtnSD => driver.FindElement(By.Id("menu_succession & development_Succession&Development"));
        private IWebElement BtnIDP => driver.FindElement(By.Id("menu_succession & development_individualDevelopmentPlans"));

        private IWebElement BtnAdmin => driver.FindElement(By.Id("menu_admin_viewAdminModule"));
        private IWebElement BtnJob => driver.FindElement(By.Id("menu_admin_Job"));
        private IWebElement BtnPay => driver.FindElement(By.Id("menu_admin_viewPayGrades"));

        private By userName = By.Id("account-name");
        private IWebElement btnUser => driver.FindElement(userName);

        private IWebElement BtnTraining => driver.FindElement(By.Id("menu_training_defaultTrainingModulePage"));
        private IWebElement BtnCourses => driver.FindElement(By.Id("menu_training_viewCourseList"));
        private IWebElement BtnOnBoarding => driver.FindElement(By.Id("menu_onboarding_defaultMenuView"));

        private By sessions = By.Id("menu_training_viewSessionList");
        private IWebElement BtnSessions => driver.FindElement(sessions);

        private By taskTypes = By.Id("menu_onboarding_viewTaskTypes");
        private IWebElement BtnTaskTypes => driver.FindElement(taskTypes);

       
        private IWebElement BtnDiscipline => driver.FindElement(By.Id("menu_discipline_defaultDisciplinaryView"));
        private IWebElement BtnDisciplinaryCases => driver.FindElement(By.Id("menu_discipline_viewDisciplinaryCases"));
       
        
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

        public DisciplinaryCasesPage NavigateToDisciplinaryCasesPage()
        {
            BtnDiscipline.Click();
            BtnDisciplinaryCases.Click();
            return new DisciplinaryCasesPage(driver);
        }
       
        public PaysPage NavigateToPaysPage()
        {
            BtnAdmin.Click();
            BtnJob.Click();
            Thread.Sleep(2000);
            BtnPay.Click();
            return new PaysPage(driver);

        }
        public EmployeesPage NavigateToAddEmployeePage()
        {
            PIM.Click();
            BtnEmployee.Click();

            return new EmployeesPage(driver);
        }
    }

}
