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
            addCoursePage = coursesPage.NavigateToAddCoursePage();
            var title = "Test";
            addCoursePage.AddCourse(new AddCourseBO
            {
                Title = title
            });
            coursesPage = homePage.NavigateToCoursesPage();
            coursesPage.SearchFilter(title);
            //driver.FindElement(By.Id("frmList_ohrmListComponent_Menu")).Click();
            //driver.FindElement(By.Id("frmList_ohrmListComponent_chkSelectAll")).Click();
            //driver.FindElement(By.Id("frmList_ohrmListComponent_Menu")).Click();
            //driver.FindElement(By.Id("deleteBtn")).Click();
            //driver.FindElement(By.Id("course-delete-button")).Click();
            Thread.Sleep(5000);
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
