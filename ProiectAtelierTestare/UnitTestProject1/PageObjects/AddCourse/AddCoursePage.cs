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

        private IWebElement Subunit => driver.FindElement(By.Id("addCourse_subunit"));

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

            Cost.SendKeys(course.Cost);
            Company.SendKeys(course.Company);
            Duration.SendKeys(course.Duration);
            Description.SendKeys(course.Description);

            SaveButton.Click();

            //var selectSubunit = new SelectElement(Subunit);
            //selectSubunit.SelectByText("Architecture Team");

            //driver.FindElements(By.ClassName("select-dropdown"))[0].Click();
            //var dropdownOption = By.XPath("//span[text()='Architecture Team']");
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            //wait.Until(ExpectedConditions.ElementIsVisible(dropdownOption));
            //driver.FindElement(dropdownOption).SendKeys("Architecture Team");
            
            //driver.FindElement(dropdownOption).Click();

            //var dropdownOption = By.CssSelector("li:nth-child(2)");
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            //wait.Until(ExpectedConditions.ElementIsVisible(dropdownOption));
            //driver.FindElement(dropdownOption).Click();

            //var dropdownOptions = By.ClassName("dropdown-content");
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            //wait.Until(ExpectedConditions.ElementIsVisible(dropdownOptions));
            //driver.FindElements(dropdownOptions)[3].Click();

            Thread.Sleep(5000);
        }
    }
}
