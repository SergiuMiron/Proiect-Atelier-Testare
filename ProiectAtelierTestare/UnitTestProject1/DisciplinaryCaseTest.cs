using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnitTestProject1.PageObjects;
using UnitTestProject1.PageObjects.AddCourse;

namespace UnitTestProject1
{
    [TestClass]
    public class DisciplinaryCasesTest
    {
        private IWebDriver driver;
        private DisciplinaryCasesPage disciplinaryCasesPage;
        private AddDisciplinaryCasesPage addDisciplinaryCasesPage;
        private HomePage homePage;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            var loginPage = new LoginPage(driver);
            driver.Navigate().GoToUrl("https://orangehrm-demo-6x.orangehrmlive.com/auth/login");
            loginPage.LoginApplication("admin", "admin123");

            homePage = new HomePage(driver);
            disciplinaryCasesPage = homePage.NavigateToDisciplinaryCasesPage();
        }

        [TestMethod]
        public void Delete_all_disciplinary_cases()
        {
            disciplinaryCasesPage.deleteAllrows();

            // var number ="0";
            //var noOfResults = driver.FindElement(By.Id("frmList_ohrmListComponenttotal")).Text;
           // Assert.AreEqual(number,noOfResults);

        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
