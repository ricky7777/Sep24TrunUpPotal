using System;
using System.ComponentModel;
using NUnit.Framework;
using OpenQA.Selenium;
using Sep24TurnUpPortal.Utilities;

namespace Sep24TurnUpPortal.Pages
{
	public class EmployeePage : BasePage
	{
        private readonly By NameTextBox = By.Id("Name");
        private readonly By UserNameTextBox = By.Id("Username");

        // can improve automation to detail.
        private readonly By ContactTextBox = By.Id("ContactDisplay");
        private readonly By PasswordTextBox = By.Id("Password");
        private readonly By RetypePasswordTextBox = By.Id("RetypePassword");
        private readonly By IsAdminCheckBox = By.Id("IsAdmin");
        private readonly By VehicleTextBox = By.Name("VehicleId_input");
        private readonly By GroupsTextBox = By.XPath("//*[@id=\"UserEditForm\"]/div/div[8]/div/div/div[1]");
        private readonly By GroupsList = By.XPath("//*[@id=\"groupList_listbox\"]/li[1]");
        private readonly By SaveButton = By.Id("SaveButton");

        private readonly By BackToEmployeeListLink = By.XPath("//*[@id=\"container\"]/div/a");

        private string Password = "asdf123455A?";

        private readonly By LastEmployeePageButton = By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span");
        private readonly By UserNameText = By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[2]");
        private readonly By EmployeeDeleteButton = By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[3]/a[2]");
        
        public EmployeePage(IWebDriver driver) : base(driver){}

        public void CreateEmployeeRecord()
		{
            //The name field should be Alphabets only
            Wait.WaitToBeClickable(_driver, NameTextBox);
            _driver.FindElement(NameTextBox).SendKeys("ricky");

            long unixTimestampMilliseconds = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            string UserNameByCreate = "Ricky" + unixTimestampMilliseconds;
            Wait.WaitToBeClickable(_driver, UserNameTextBox);
            _driver.FindElement(UserNameTextBox).SendKeys(UserNameByCreate);

            Wait.WaitToBeClickable(_driver, ContactTextBox);
            _driver.FindElement(ContactTextBox).SendKeys("Albany");

            Wait.WaitToBeClickable(_driver, PasswordTextBox);
            _driver.FindElement(PasswordTextBox).SendKeys(Password);

            Wait.WaitToBeClickable(_driver, RetypePasswordTextBox);
            _driver.FindElement(RetypePasswordTextBox).SendKeys(Password);

            Wait.WaitToBeClickable(_driver, IsAdminCheckBox);
            _driver.FindElement(IsAdminCheckBox).Click();

            Wait.WaitToBeClickable(_driver, VehicleTextBox);
            _driver.FindElement(VehicleTextBox).SendKeys("Bus");

            Wait.WaitToBeClickable(_driver, GroupsTextBox);
            _driver.FindElement(GroupsTextBox).Click();

            Wait.WaitToBeClickable(_driver, GroupsList);
            _driver.FindElement(GroupsList).Click();

            Wait.WaitToBeClickable(_driver, SaveButton);
            _driver.FindElement(SaveButton).Click();

            Wait.WaitToBeClickable(_driver, BackToEmployeeListLink);
            _driver.FindElement(BackToEmployeeListLink).Click(); 

            Wait.WaitToBeClickable(_driver, LastEmployeePageButton);
            _driver.FindElement(LastEmployeePageButton).Click();

            Wait.WaitToBeVisible(_driver, UserNameText);

            Assert.That(_driver.FindElement(UserNameText).Text == UserNameByCreate, "Created employee successfully");
        }

        public void EditEmployeeRecord()
        {
            long unixTimestampMilliseconds = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            string UserNameByCreate = "Ricky" + unixTimestampMilliseconds;
            Wait.WaitToBeClickable(_driver, UserNameTextBox);
            _driver.FindElement(UserNameTextBox).Clear();
            _driver.FindElement(UserNameTextBox).SendKeys(UserNameByCreate);

            Wait.WaitToBeClickable(_driver, SaveButton);
            _driver.FindElement(SaveButton).Click();

            Wait.WaitToBeClickable(_driver, BackToEmployeeListLink);
            _driver.FindElement(BackToEmployeeListLink).Click();

            Wait.WaitToBeClickable(_driver, LastEmployeePageButton);
            _driver.FindElement(LastEmployeePageButton).Click();

            Wait.WaitToBeVisible(_driver, UserNameText);

            Assert.That(_driver.FindElement(UserNameText).Text == UserNameByCreate, "Modify employee successfully");
        }

        public void DeleteEmployeeRecord()
        {
            Wait.WaitToBeClickable(_driver, EmployeeDeleteButton);
            _driver.FindElement(EmployeeDeleteButton).Click();

            IAlert confirmAlert = _driver.SwitchTo().Alert();
            string confirmText = confirmAlert.Text;
            confirmAlert.Accept();

        }
    }
}

