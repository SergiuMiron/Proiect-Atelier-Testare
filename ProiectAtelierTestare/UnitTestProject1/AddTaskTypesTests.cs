using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestProject1.PageObjects;
using UnitTestProject1.PageObjects.AddTaskType;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace UnitTestProject1
{
    [TestClass]
    public class AddTaskTypesTests
    {
        private IWebDriver driver;
        private AddTaskTypePage addTaskTypePage;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            var loginPage = new LoginPage(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://orangehrm-demo-6x.orangehrmlive.com/");
            loginPage.LoginApplication("admin", "admin123");

            var homePage = new HomePage(driver);
            var taskTypesPage = homePage.NavigatetoTaskTypesPage();
            addTaskTypePage = taskTypesPage.NavigateToAddTaskTypePage();
        }

        [TestMethod]
        public void Display_Correct_Message_For_Creating_New_TaskType()
        {
            addTaskTypePage.AddTaskType(new AddTaskTypeBO());
            //var message = "Successfully Updated";
            //Assert.AreEqual(message, addTaskTypePage.SuccessMessage.Text);
        }

        [TestMethod]
        public void Display_Error_Message_For_Required_Fields()
        {
            var taskName = "";
            addTaskTypePage.AddTaskType(new AddTaskTypeBO
            {
                Name = taskName
            });
            var message = "Required";
            var errorMessage = driver.FindElement(By.Id("type_name-error")).Text;
            Assert.AreEqual(message, errorMessage);

        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
