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
    public class AddCoursesTest
    {
        private IWebDriver driver;
        private AddCoursePage addCoursePage;
        private HomePage homePage;
        private CoursesPage coursesPage;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            var loginPage = new LoginPage(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://orangehrm-demo-6x.orangehrmlive.com/auth/login");
            loginPage.LoginApplication("admin", "admin123");

            homePage = new HomePage(driver);

            coursesPage  = homePage.NavigateToCoursesPage();

        }

        [TestMethod]
        public void Should_Display_One_Row_In_Table_After_Creating_New_Course()
        {
            addCoursePage = coursesPage.NavigateToAddCoursePage();
            var title = "Test Title1";
            addCoursePage.AddCourse(new AddCourseBO {
                Title = title
            });
            coursesPage = homePage.NavigateToCoursesPage();
            coursesPage.SearchFilter(title);

            var tableRow = By.ClassName("dataRaw");
            Thread.Sleep(2000);
            var numberOfRows = driver.FindElements(tableRow);
            var test = numberOfRows.Count;
            Assert.AreEqual(numberOfRows.Count, 1);

        }

      
        //public void ZShould_Delete_Course()
        //{
        //    //driver.SwitchTo().DefaultContent();
        //    driver.SwitchTo().Frame(driver.FindElement(By.Id("noncoreIframe")));
        //    var title = "Test Title1";
        //    coursesPage.SearchFilter(title);

        //    Thread.Sleep(5000);
        //    new WebDriverWait(driver, TimeSpan.FromSeconds(5000)).Until(ExpectedConditions.ElementExists((By.Id("frmList_ohrmListComponent_Menu"))));
        //    driver.FindElement(By.Id("frmList_ohrmListComponent_Menu")).Click();
        //    driver.FindElement(By.Id("frmList_ohrmListComponent_chkSelectAll")).Click();
        //    driver.FindElement(By.Id("frmList_ohrmListComponent_Menu")).Click();
        //    driver.FindElement(By.Id("deleteBtn")).Click();
        //    driver.FindElement(By.Id("course-delete-button")).Click();
        //    Thread.Sleep(5000);
        //}

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }

    }
}
