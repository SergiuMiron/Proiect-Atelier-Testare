using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UnitTestProject1.PageObjects;
using UnitTestProject1.PageObjects.AddTrainingSession;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace UnitTestProject1
{
    [TestClass]
    public class AddTrainingSessionsTests
    {
        private IWebDriver driver;
        private AddTrainingSessionPage addTrainingSessionPage;
        private HomePage homepage;
        private TrainingSessionsPage trainingSessionsPage;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            var loginPage = new LoginPage(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://orangehrm-demo-6x.orangehrmlive.com/");
            loginPage.LoginApplication("admin", "admin123");

            homepage = new HomePage(driver);
            trainingSessionsPage = homepage.NavigateToTrainingSessionsPage();
            //var trainingSessionsPage = homePage.NavigateToTrainingSessionsPage();
            //addTrainingSessionPage = trainingSessionsPage.NavigateToAddTrainingSessionPage();
        }

        [TestMethod]
        public void Display_Correct_Message_For_Creating_New_TrainingSession()
        {
            //addTrainingSessionPage.AddTrainingSession(new AddTrainingSessionBO());
            /*var trainingSessionDetails = addTrainingSessionPage.NavigateToSessionDetailsPage();
            var message = "Successfully Updated";
            Assert.AreEqual(message, trainingSessionDetails.LblSuccess.Text);*/
            addTrainingSessionPage = trainingSessionsPage.NavigateToAddTrainingSessionPage();
            var sessionName = "test";
            addTrainingSessionPage.AddTrainingSession(new AddTrainingSessionBO
            {
                TxtSessionName = sessionName
            });
            /*trainingSessionsPage = homepage.NavigateToTrainingSessionsPage();
            trainingSessionsPage.SearchFilter(sessionName);

            var tableRow = By.ClassName("dataRaw");
            var numberOfRows = driver.FindElements(tableRow);
            var test = numberOfRows.Count;
            Assert.AreEqual(numberOfRows.Count, 1);*/
        }

        [TestMethod]
        public void Display_Error_Message_For_Required_Fields()
        {
            addTrainingSessionPage = trainingSessionsPage.NavigateToAddTrainingSessionPage();
            var sessionName = "";
            addTrainingSessionPage.AddTrainingSession(new AddTrainingSessionBO
            {
                TxtSessionName = sessionName
            });
            var message = "Required";
            var errorMessage = driver.FindElement(By.Id("addSession_name-error")).Text;
            Assert.AreEqual(message, errorMessage);
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
