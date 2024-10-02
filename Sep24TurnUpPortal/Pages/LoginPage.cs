﻿using System;
using OpenQA.Selenium;
using Sep24TurnUpPortal.Utilities;

namespace Sep24TurnUpPortal.Pages
{
	public class LoginPage: BasePage
    {
        private const string LoginUrl = "http://horse.industryconnect.io";
        private const string Username = "hari";
        private const string Password = "123123";
        private readonly By UserNameField = By.Id("UserName");
        private readonly By PasswordField = By.Id("Password");
        private readonly By LoginButton = By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]");
        private readonly By HelloHariText = By.XPath("//*[@id=\"logoutForm\"]/ul/li/a");

        public LoginPage(IWebDriver driver) : base(driver) {
        }

        // Functions that allow users to login the TurnUp portal
        public void LoginActions()
        {
            _driver.Navigate().GoToUrl(LoginUrl);
            //driver.Manage().Window.Maximize();

            IWebElement userInput = _driver.FindElement(UserNameField);
            userInput.SendKeys(Username);

            IWebElement passwordInput = _driver.FindElement(PasswordField);
            passwordInput.SendKeys(Password);

            Wait.WaitToBeClickable(_driver, LoginButton);
            _driver.FindElement(LoginButton).Click();

            IWebElement helloHari = _driver.FindElement(HelloHariText);

            if (helloHari.Text == "Hello hari!")
            {
                Console.WriteLine("User has logged in successfully. Test passed!");
            }
            else
            {
                Console.WriteLine("User has not logged in. Test failed!");
            }

        }

    }
}