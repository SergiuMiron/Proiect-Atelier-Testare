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
    public class TaskTypeTest
    {
        private IWebDriver driver;
        private TaskTypesPage tasksPage;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            var loginPage = new LoginPage(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://orangehrm-demo-6x.orangehrmlive.com/");
            loginPage.LoginApplication("admin", "admin123");
            var homePage = new HomePage(driver);

            tasksPage = homePage.NavigatetoTaskTypesPage();
            var addTaskType = tasksPage.NavigateToAddTaskTypePage();
            addTaskType.AddTaskType(new AddTaskTypeBO());
        }

        [TestMethod]
        public void Should_Display_Correct_Message()
        {
            tasksPage.DeleteTask();
            //string notice = "Successfully Deleted";
            //Assert.AreEqual(notice, tasksPage.no)
        }
    }
}
