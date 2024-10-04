using System;
using OpenQA.Selenium;
using Sep24TurnUpPortal.Utilities;

namespace Sep24TurnUpPortal.Pages
{
    public class HomePage : BasePage
    {

        private readonly By AdministrationTab = By.XPath("/html/body/div[3]/div/div/ul/li[5]/a");
        private readonly By TimeAndMaterialOption = By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a");
        private readonly By LastPageButton = By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span");
        private readonly By LastRawEdit = By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]");
        private readonly By CreateNewButton = By.XPath("//*[@id=\"container\"]/p/a");

        private readonly By EmployeeButton = By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[2]");
        private readonly By EmployeeCreateButton = By.ClassName("btn-primary");
        private readonly By LastEmployeePageButton = By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]");
        private readonly By LastEmployeeRawEdit = By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[3]/a[1]");

        public HomePage(IWebDriver driver) : base(driver) { }

        public void NavigationToTPMPage()
        {
            Wait.WaitToBeClickable(_driver, AdministrationTab);
            _driver.FindElement(AdministrationTab).Click();

            Wait.WaitToBeClickable(_driver, TimeAndMaterialOption);
            _driver.FindElement(TimeAndMaterialOption).Click();

        }

        public void NatigationToEditPage()
        {
            // Navigate to Administration Tab
            Wait.WaitToBeClickable(_driver, AdministrationTab);
            _driver.FindElement(AdministrationTab).Click();

            // Navigate to Time and Material Option
            Wait.WaitToBeClickable(_driver, TimeAndMaterialOption);
            _driver.FindElement(TimeAndMaterialOption).Click();

            // Find and click the last page button
            NatigationToLastPage();

            // Find and click the edit button in the last row
            Wait.WaitToBeClickable(_driver, LastRawEdit);
            _driver.FindElement(LastRawEdit).Click();
        }

        public void NatigationToLastPage()
        {
            Wait.WaitToBeClickable(_driver, LastPageButton);
            _driver.FindElement(LastPageButton).Click();
        }

        public void NatigationToCreatePage()
        {
            Wait.WaitToBeClickable(_driver, CreateNewButton);
            _driver.FindElement(CreateNewButton).Click();
        }

        public void NatigationToEmployeePage()
        {
            Wait.WaitToBeClickable(_driver, AdministrationTab);
            _driver.FindElement(AdministrationTab).Click();

            Wait.WaitToBeClickable(_driver, EmployeeButton);
            _driver.FindElement(EmployeeButton).Click();
        }

        public void NatigationToEmployeeCreatePage()
        {
            Wait.WaitToBeClickable(_driver, EmployeeCreateButton);
            _driver.FindElement(EmployeeCreateButton).Click();
        }

        public void NatigationToLastEmployeePage()
        {
            Wait.WaitToBeClickable(_driver, LastEmployeePageButton);
            _driver.FindElement(LastEmployeePageButton).Click();
        }

        public void NatigationToEmployeeEditPage()
        {
            Wait.WaitToBeClickable(_driver, LastEmployeeRawEdit);
            _driver.FindElement(LastEmployeeRawEdit).Click();
        }
    }
}