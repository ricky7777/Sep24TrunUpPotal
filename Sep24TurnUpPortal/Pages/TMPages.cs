using System;
using NUnit.Framework;
using OpenQA.Selenium;
using Sep24TurnUpPortal.Utilities;

namespace Sep24TurnUpPortal.Pages
{
	public class TMPages : BasePage
    {
        private readonly By AdministrationTab = By.XPath("/html/body/div[3]/div/div/ul/li[5]/a");
        private readonly By TimeAndMaterialOption = By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a");
        private readonly By CreateNewButton = By.XPath("//*[@id=\"container\"]/p/a");
        private readonly By TypeCodeDropdown = By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span");
        private readonly By TimeOption = By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]");
        private readonly By CodeTextbox = By.Id("Code");
        private readonly By DescriptionTextbox = By.Id("Description");
        private readonly By PriceTagOverlap = By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]");
        private readonly By PriceTextbox = By.Id("Price");
        private readonly By SaveButton = By.Id("SaveButton");
        private readonly By GoToLastPageButton = By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span");
        private readonly By NewCode = By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]");
        private readonly By DescriptionTextBox = By.Id("Description");
        private readonly By LastDescriptionText = By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]");
        private readonly By LastDeleteButton = By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]");


        public TMPages(IWebDriver driver) : base(driver){}

        public void CreateTimeRecord()
		{
            string codeText = "TA Program test 917";

            // Wait for Administration Tab and click
            Wait.WaitToBeClickable(_driver, AdministrationTab);
            _driver.FindElement(AdministrationTab).Click();

            // Wait for Time and Material Option and click
            Wait.WaitToBeClickable(_driver, TimeAndMaterialOption);
            _driver.FindElement(TimeAndMaterialOption).Click();

            // Wait for Create New Button and click
            Wait.WaitToBeClickable(_driver, CreateNewButton);
            _driver.FindElement(CreateNewButton).Click();

            // Wait for Type Code Dropdown and click
            Wait.WaitToBeClickable(_driver, TypeCodeDropdown);
            _driver.FindElement(TypeCodeDropdown).Click();

            // Wait for Time Option and select it
            Wait.WaitToBeClickable(_driver, TimeOption);
            _driver.FindElement(TimeOption).Click();

            // Type code into textbox
            Wait.WaitToBeVisible(_driver, CodeTextbox);
            _driver.FindElement(CodeTextbox).SendKeys(codeText);

            // Type description into description textbox
            Wait.WaitToBeVisible(_driver, DescriptionTextbox);
            _driver.FindElement(DescriptionTextbox).SendKeys("This is a description");

            // Click on price tag and enter price
            Wait.WaitToBeClickable(_driver, PriceTagOverlap);
            _driver.FindElement(PriceTagOverlap).Click();
            _driver.FindElement(PriceTextbox).SendKeys("12");

            // Click on Save button
            Wait.WaitToBeClickable(_driver, SaveButton);
            _driver.FindElement(SaveButton).Click();

            // Wait for the last page button and click
            Wait.WaitToBeClickable(_driver, GoToLastPageButton);
            _driver.FindElement(GoToLastPageButton).Click();

            // Verify if the new record is created successfully
            Wait.WaitToBeVisible(_driver, NewCode);
            IWebElement newCodeElement = _driver.FindElement(NewCode);
            Assert.That(newCodeElement.Text == codeText, "Time record created successfully");
        }
	

    public void EditTimeRecord()
    {
            // Modify description textbox
            IWebElement descriptionTextBox = _driver.FindElement(DescriptionTextBox);
            String modifyText = "Modify";

            descriptionTextBox.Clear();
            descriptionTextBox.SendKeys(modifyText);

            // Save Button
            _driver.FindElement(SaveButton).Click();

            HomePage homePageObj = new HomePage(_driver);
            homePageObj.NatigationToLastPage();
            Thread.Sleep(4000);
            // Verify description text
            IWebElement lastDescriptionText = _driver.FindElement(LastDescriptionText);
            Assert.That(lastDescriptionText.Text == "Modify", "Description modify successfuly");
        }

    public void DeletetimeRecord()
    {
            // Click Last raw delete button
            _driver.FindElement(LastDeleteButton).Click();

            IAlert confirmAlert = _driver.SwitchTo().Alert();
            string confirmText = confirmAlert.Text;
            confirmAlert.Accept();
    }
   }

}