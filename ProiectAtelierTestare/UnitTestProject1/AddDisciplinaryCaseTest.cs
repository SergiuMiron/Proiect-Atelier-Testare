using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using UnitTestProject1.PageObjects;
using UnitTestProject1.PageObjects.AddDisciplinaryCases;

namespace UnitTestProject1
{
    [TestClass]
    public class AddDisciplinaryCasesTest
    {
        private IWebDriver driver;
        public AddDisciplinaryCasesPage addDisciplinaryCasesPage;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            var loginPage = new LoginPage(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://orangehrm-demo-6x.orangehrmlive.com/auth/login");
            loginPage.LoginApplication("admin", "admin123");

            var homePage = new HomePage(driver);

            var disciplinarycasesPage = homePage.NavigateToDisciplinaryCasesPage();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            addDisciplinaryCasesPage = disciplinarycasesPage.NavigateToAddDisciplinaryCasesPage();

        }
        [TestMethod]
        public void Should_Display_Success_Message_For_Creating_New_DisciplinaryCase()
        {
            addDisciplinaryCasesPage.AddDisciplinaryCases(new AddDisciplnaryCasesBO());
            //var employyeName = "Kevin Mathews";
            //var employee = driver.FindElement(By.Id("addCase_employeeName_empName")).Text;

            //Assert.AreEqual(employyeName, employee);

        }

        [TestMethod]
        public void Should_Display_Error_Message_For_Required_Fields()
        {
            var addDisciplinarycaseBO = new AddDisciplnaryCasesBO
            {
                Employee = " ",
                Case = " "
            };
            addDisciplinaryCasesPage.AddDisciplinaryCases(addDisciplinarycaseBO);
            var message = "Required";
            var errmessage = driver.FindElement(By.Id("addCase_caseName-error")).Text;
            Assert.AreEqual(message, errmessage);


        }




        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }

    }
}

