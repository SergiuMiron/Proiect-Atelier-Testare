using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace UnitTestProject1.PageObjects.AddTrainingSession
{
    public class AddTrainingSessionPage
    {
        private IWebDriver driver;

        public AddTrainingSessionPage(IWebDriver browser)
        {
            driver = browser;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(sessionName));
        }

        private By sessionName = By.Id("addSession_name");
        private IWebElement TxtSessionName => driver.FindElement(sessionName);
        private IWebElement BtnCourse => driver.FindElement(By.ClassName("select-dropdown"));
        private By coursesList => By.ClassName("select-dropdown");
        //private IWebElement coursesList => driver.FindElement(By.CssSelector(".row > .row:nth-of-type(1) > .input-field.col.s6:nth-of-type(2) > .select-wrapper > input[type='text'].select-dropdown"));
        private IWebElement elementTest => driver.FindElement(By.XPath("//span['How to avoid phishing attacks']"));
        private IWebElement TxtStartDate => driver.FindElement(By.Id("addSession_scheduledDate"));
        private IWebElement btnToday => driver.FindElement(By.XPath("//button[@class='btn-flat picker__today']"));
        private IWebElement TxtEndDate => driver.FindElement(By.Id("addSession_dueDate"));
        private IWebElement TxtDeliveryLocation => driver.FindElement(By.Id("addSession_deliveryLocation"));
        private IWebElement DdlDeliveryMethod => driver.FindElement(By.XPath("//select[@name='addSession[deliveryMethod]']"));
        private IWebElement DdlStatus => driver.FindElement(By.XPath("//select[@name='addSession[status]']"));
        private IWebElement TxtDescription => driver.FindElement(By.Id("addSession_description"));
        private IWebElement BtnSave => driver.FindElement(By.Id("btnSave"));
        public void AddTrainingSession(AddTrainingSessionBO sessionTraining)
        {
            TxtSessionName.SendKeys(sessionTraining.TxtSessionName);
            BtnCourse.Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(coursesList));
            elementTest.Click();
            //driver.FindElement(coursesList).Click();
            //coursesList.Click();
            //var selectCourse = new SelectElement(coursesList);
            //selectCourse.SelectByText(sessionTraining.TxtCourseName);

            TxtStartDate.Click();
            btnToday.Click();
            //TxtEndDate.Click();
            //btnToday.Click();


            //TxtDeliveryLocation.SendKeys(sessionTraining.TxtDeliveryLocation);
            //var selectDeliveryMethod = new SelectElement(DdlDeliveryMethod);
            //selectDeliveryMethod.SelectByText(sessionTraining.TxtDeliveryMethod);
            //var selectStatus = new SelectElement(DdlStatus);
            //selectStatus.SelectByText(sessionTraining.TxtStatus);
            BtnSave.Click();
        }

        /*public TrainingSessionDetailsPage NavigateToSessionDetailsPage()
        {
            return new TrainingSessionDetailsPage(driver);
        }*/
    }
}
