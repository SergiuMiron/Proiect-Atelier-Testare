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
        //trd
        private IWebDriver driver;
        private LoginPage loginPage;

        [TestInitialize]
        public void SetUp()
        {
            //test
            driver = new ChromeDriver();
            loginPage = new LoginPage(driver);
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://orangehrm-demo-6x.orangehrmlive.com/auth/login");
        }

        [TestMethod]
        public void LoginAsAdmin()
        {
            loginPage.LoginApplication();

            var expectedResult = "Admin";
            //actual result
            var homePage = new HomePage(driver);

            Assert.AreEqual(expectedResult, homePage.menuItemControl.AdminUser);
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
