using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UnitTestProject1.PageObjects
{
    public class DisciplinaryCasesPage
    {
        private IWebDriver driver;

        private By addDiscipline = By.Id("addItemBtn");

        public DisciplinaryCasesPage(IWebDriver browser)
        {
            driver = browser;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

        }
        public AddDisciplinaryCasesPage NavigateToAddDisciplinaryCasesPage()
        {
            driver.SwitchTo().Frame(driver.FindElement(By.Id("noncoreIframe")));
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(addDiscipline));
            driver.FindElement(addDiscipline).Click();
            //driver.SwitchTo().DefaultContent();
            return new AddDisciplinaryCasesPage(driver);
        }



    }
}
