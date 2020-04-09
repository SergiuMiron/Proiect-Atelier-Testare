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
using UnitTestProject1.PageObjects.AddEvent;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace UnitTestProject1
{
    [TestClass]
    public class AddEventsTest
    {
        private IWebDriver driver;
        private AddEventPage addEventPage;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            var loginPage = new LoginPage(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://orangehrm-demo-6x.orangehrmlive.com/auth/login");
            loginPage.LoginApplication("admin", "admin123");

            var homePage = new HomePage(driver);

            var eventsPage = homePage.NavigateToEventsPage();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            addEventPage = eventsPage.NavigateToAddEventsPage();

        }

        [TestMethod]
        public void Should_Display_Success_Toaster_For_Creating_New_Event()
        {
            addEventPage.AddEvent(new AddEventBO());
            //var successMessage = "Successfully Updatedd";
            //var successToaster = By.ClassName("toast-success");
            //Assert.AreEqual(successMessage, driver.FindElement(successToaster).Text);

        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }

    }
}
