using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnitTestProject1.PageObjects.AddCourse;
using UnitTestProject1.PageObjects.Controllers;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace UnitTestProject1.PageObjects
{
    public class CoursesPage
    {
        private IWebDriver driver;
        //private By addButton = By.XPath("//div[contains(@class, 'fixed-action-btn')]");
        private By addButton = By.Id("addItemBtn");


        public CoursesPage(IWebDriver browser)
        {
            driver = browser;
        }

        public AddCoursePage NavigateToAddCoursePage()
        {
            driver.SwitchTo().Frame(driver.FindElement(By.Id("noncoreIframe")));
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(addButton));
            driver.FindElement(addButton).Click();
            //driver.SwitchTo().DefaultContent();
            return new AddCoursePage(driver);
        }

        public void SearchFilter(string titleName)
        {
            var searchModal = By.Id("searchModal");
            driver.FindElement(searchModal).Click();
            driver.FindElement(By.Id("searchCourse_title")).SendKeys(titleName);
            var searchButton = By.Id("searchBtn");
            driver.FindElement(searchButton).Click();
        }

    }
}
