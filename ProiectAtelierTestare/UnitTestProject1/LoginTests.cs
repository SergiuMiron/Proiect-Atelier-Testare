using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UnitTestProject1.PageObjects;

namespace UnitTestProject1
{
    [TestClass]
    public class LoginTests
    {
        private IWebDriver driver;
        private LoginPage loginPage;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            loginPage = new LoginPage(driver);
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://orangehrm-demo-6x.orangehrmlive.com/auth/login");
        }

        [TestMethod]
        public void AdminLogin_CorrectUser_CorrectPassword()
        {
            loginPage.LoginApplication("admin", "admin123");

            var expectedResult = "Jacqueline White";
            var homePage = new HomePage(driver);

            Assert.AreEqual(expectedResult, homePage.menuItemControl.UserNameText);
        }

        [TestMethod]
        public void AdminLogin_CorrectUser_IncorrectPassword()
        {
            loginPage.LoginApplication("admin", "admin");

            var expectedResult = "Invalid Credentials";
            var actualResults = driver.FindElement(By.ClassName("toast-message")).Text;

            Assert.AreEqual(expectedResult, actualResults);
        }

        [TestMethod]
        public void SupervisorLogin_CorrectUser_CorrectPassword()
        {
            loginPage.DifferentLogin();

            var expectedResult = "Kevin Mathews";
            var homePage = new HomePage(driver);

            Assert.AreEqual(expectedResult, homePage.menuItemControl.UserNameText);
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
