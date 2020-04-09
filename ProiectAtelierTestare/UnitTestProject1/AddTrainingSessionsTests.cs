using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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


        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            var loginPage = new LoginPage(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://orangehrm-demo-6x.orangehrmlive.com/");
            loginPage.LoginApplication("admin", "admin123");

            var homePage = new HomePage(driver);
            var trainingSessionsPage = homePage.NavigateToTrainingSessionsPage();
            addTrainingSessionPage = trainingSessionsPage.NavigateToAddTrainingSessionPage();
        }

        [TestMethod]
        public void Display_Correct_Message_For_Creating_New_TrainingSession()
        {
            addTrainingSessionPage.AddTrainingSession(new AddTrainingSessionBO());
            /*var trainingSessionDetails = addTrainingSessionPage.NavigateToSessionDetailsPage();
            var message = "Successfully Updated";
            Assert.AreEqual(message, trainingSessionDetails.LblSuccess.Text);*/
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
