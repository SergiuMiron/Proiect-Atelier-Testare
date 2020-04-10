using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnitTestProject1.PageObjects;
using UnitTestProject1.PageObjects.AddCourse;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace UnitTestProject1
{
    [TestClass]
    public class CoursesTest
    {
        private IWebDriver driver;
        private CoursesPage coursesPage;
        private AddCoursePage addCoursePage;
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
            coursesPage = homePage.NavigateToCoursesPage();
        }

        [TestMethod]
        public void Should_Delete_Course()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            var title = "Test1 To Be Deleted";

            // Add an entity. We are going to delete it in this test
            addCoursePage = coursesPage.NavigateToAddCoursePage();
            addCoursePage.AddCourse(new AddCourseBO
            {
                Title = title
            });

            // Delete the entity that we've just added
            coursesPage.DeleteCourse(title);

            // Check if the entity was deleted
            coursesPage.SearchFilter(title);
            var tableRow = By.ClassName("dataRaw");
            Thread.Sleep(2000);
            var numberOfRows = driver.FindElements(tableRow);
            var test = numberOfRows.Count;
            Assert.AreEqual(numberOfRows.Count, 0);

            Thread.Sleep(5000);
        }


        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
