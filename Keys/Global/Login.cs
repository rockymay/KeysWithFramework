using Keys.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keys.Global
{
    class Login
    {
        // Initializing the web elements 
        internal Login()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        // Finding the Email Field
        [FindsBy(How = How.Id, Using = "UserName")]
        private IWebElement Email { get; set; }

        // Finding the Password Field
        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement PassWord { get; set; }

        // Finding the Login Button
        [FindsBy(How = How.XPath, Using = "//*[@id='sign_in']/div[4]/div[2]/button")]
        private IWebElement loginButton { get; set; }

        public void LoginSuccessfull()
        {
            // Populating the data from Excel
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Login");
            // Navigating to Login page using value from Excel
            Driver.driver.Navigate().GoToUrl(ExcelLib.ReadData(2, "url"));
        
            // Sending the username 
            Email.SendKeys(ExcelLib.ReadData(2, "Email"));
            // Sending the password
            PassWord.SendKeys(ExcelLib.ReadData(2, "Password"));
            // Clicking on the login button
            loginButton.Click();
           
        }


    }
}
