using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UnitTestProject1.PageObjects.AddDisciplinaryCases;

namespace UnitTestProject1.PageObjects
{
    public class AddDisciplinaryCasesPage
    {
        private IWebDriver driver;

        public AddDisciplinaryCasesPage(IWebDriver browser)
        {
            driver = browser;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(addEmpName));
        }
        private By addEmpName = By.Id("addCase_employeeName_empName");
        private IWebElement Employee => driver.FindElement(addEmpName);
        private IWebElement Case => driver.FindElement(By.Id("addCase_caseName"));
        private IWebElement Description => driver.FindElement(By.Id("addCase_description"));
        private IWebElement CancelBtn => driver.FindElement(By.Id("btnBack"));
        private IWebElement SaveBtn => driver.FindElement(By.Id("btnSave"));



        public void AddDisciplinaryCases(AddDisciplnaryCasesBO discipline)
        {
            Employee.SendKeys(discipline.Employee);
            driver.FindElements(By.ClassName("ac_results"))[0].Click();

            Case.SendKeys(discipline.Case);
            Description.SendKeys(discipline.Description);
            SaveBtn.Click();

        }


    }
}
