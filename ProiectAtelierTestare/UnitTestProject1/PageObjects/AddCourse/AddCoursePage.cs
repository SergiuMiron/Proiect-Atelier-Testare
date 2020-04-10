using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace UnitTestProject1.PageObjects.AddCourse
{
    public class AddCoursePage
    {
        private IWebDriver driver;

        public AddCoursePage(IWebDriver browser)
        {
            driver = browser;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(addCourse_title));
        }

        private By addCourse_title = By.Id("addCourse_title");
        private IWebElement Title => driver.FindElement(addCourse_title);

        private IWebElement Coordinator => driver.FindElement(By.Id("addCourse_coordinator_empName"));

        private IWebElement Subunit => driver.FindElements(By.ClassName("select-dropdown"))[0];

        private IWebElement Version => driver.FindElements(By.ClassName("select-dropdown"))[2];

        private IWebElement Subversion => driver.FindElements(By.ClassName("select-dropdown"))[4];

        private IWebElement Currency => driver.FindElements(By.ClassName("select-dropdown"))[6];

        private IWebElement Cost => driver.FindElement(By.Id("addCourse_cost"));

        private IWebElement Company => driver.FindElement(By.Id("addCourse_company"));

        private IWebElement Duration => driver.FindElement(By.Id("addCourse_duration"));

        private IWebElement Description => driver.FindElement(By.Id("addCourse_description"));

        private IWebElement SaveButton => driver.FindElement(By.Id("btnSaveCourse"));

        public IWebElement SuccessMessage => driver.FindElement(By.ClassName("toast-message"));

        public void AddCourse(AddCourseBO course)
        {
            Title.SendKeys(course.Title);
            Coordinator.SendKeys(course.Coordinator);
            driver.FindElements(By.ClassName("ac_results"))[0].Click();

            Subunit.Click();
            Subunit.SendKeys(Keys.ArrowDown);
            Subunit.SendKeys(Keys.Enter);

            Version.Click();
            Version.SendKeys(Keys.ArrowDown);
            Version.SendKeys(Keys.Enter);

            Subversion.Click();
            Subversion.SendKeys(Keys.ArrowDown);
            Subversion.SendKeys(Keys.Enter);

            Currency.Click();
            Currency.SendKeys(Keys.ArrowDown);
            Currency.SendKeys(Keys.Enter);


            Cost.SendKeys(course.Cost);
            Company.SendKeys(course.Company);
            Duration.SendKeys(course.Duration);
            Description.SendKeys(course.Description);

            SaveButton.Click();
        }
    }
}
