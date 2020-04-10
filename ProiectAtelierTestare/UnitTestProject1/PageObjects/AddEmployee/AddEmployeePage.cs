using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using UnitTestProject1;
namespace UnitTestProject1.PageObjects.AddEmployee
{
    public class AddEmployeePage
    {
        private IWebDriver driver;

        public AddEmployeePage(IWebDriver browser)
        {
            driver = browser;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(firstName));
        }

        private By firstName = By.Id("firstName");
        private IWebElement TxtFirstName => driver.FindElement(firstName);

        private IWebElement TxtLastName => driver.FindElement(By.Id("lastName"));

        private IWebElement Location => driver.FindElement(By.CssSelector("input[type='text'].select-dropdown"));

        private IList<IWebElement> LstGender => driver.FindElements(By.ClassName("radiobutton-container"));

        private IWebElement TxtBirthday => driver.FindElement(By.Id("emp_birthday"));

        private IList<IWebElement> LstBloodGroup => driver.FindElements(By.ClassName("select-wrapper initialized ng-dirty ng-valid-parse ng-not-empty ng-valid-tv4-302 ng-valid ng-valid-schema-form ng-empty-add ng-valid-remove ng-invalid-add ng-valid-tv4-302-remove ng-invalid-tv4-302-add ng-valid-schema-form-remove ng-invalid-schema-form-add"));

        private IWebElement TxtHobbies => driver.FindElement(By.Id("5"));

        // private IList<IWebElement> LstRegion => driver.FindElement(By.CssSelector(".dropdown-content.select-dropdown.active > li:nth-of-type(2) > span"));

        //private IList<IWebElement> LstFTE => driver.FindElement(By.Id(" select-options-a1fa9068-1556-28f1-06ff-25e466bf261c"));

        // private IList<IWebElement> LstDepartment => driver.FindElement(By.Id("select-options-bb75b201-685f-fb8c-8e6a-2e89d1254c19 "));

        private IWebElement BtnNExt => driver.FindElement(By.ClassName("btn waves-effect waves-light right"));

        public void AddEmployee(AddEmployeesBO employes)
        {
            Thread.Sleep(5000);
            TxtFirstName.SendKeys(employes.TxtFirstName);

            TxtLastName.SendKeys(employes.TxtLastName);


            Location.SendKeys(Keys.ArrowDown);
            Location.SendKeys(Keys.Enter);

            BtnNExt.Click();

            TxtHobbies.SendKeys(employes.TxtHobbies);

            TxtBirthday.SendKeys(employes.TxtBirthday);

            var selectLocation = new SelectElement(Location);
            selectLocation.SelectByText(employes.TxtLocation);

            BtnNExt.Click();

            /* var selectRegion = new SelectElement(LstRegion);
             selectRegion.SelectByText(employes.TxtRegion);

             var selectFTE = new SelectElement(LstFTE);
             selectFTE.SelectByText(employes.TxtFTE);

             var selectDepartment = new SelectElement(LstDepartment);
             selectDepartment.SelectByText(employes.TxtDeartment);
             */

            //  LstRegion[2].Click();

            // LstFTE[2].Click();

            // LstDepartment[2].Click();

            LstGender[2].Click();

            LstBloodGroup[2].Click();



        }
        /* 
         public EmployeesDetailsPage NavigateToEmployeesDetailsPage()
         {
             return new EmployeesDetailsPage(driver);
         }
         */
    }
}