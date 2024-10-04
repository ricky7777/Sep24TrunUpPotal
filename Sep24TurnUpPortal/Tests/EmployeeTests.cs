using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using Sep24TurnUpPortal.Pages;
using Sep24TurnUpPortal.Utilities;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Sep24TurnUpPortal.Tests
{
    [Parallelizable]
    [TestFixture]
    public class EmployeeTests : CommonDriver
    {
        LoginPage loginPageObj;
        HomePage homePage;
        EmployeePage employeePage;

        [SetUp]
        public void SetUp()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            loginPageObj = new LoginPage(driver);
            loginPageObj.LoginActions();

            homePage = new HomePage(driver);
            employeePage = new EmployeePage(driver);
        }

        [Test, Order(1), Description("This test verified the creation of a new Emplyoee record")]
        public void TestCreateEmployeeRecord()
        {
            homePage.NatigationToEmployeePage();
            homePage.NatigationToEmployeeCreatePage();
            employeePage.CreateEmployeeRecord();
        }

        [Test, Order(2), Description("This test verified the edit of a new Emplyoee record")]
        public void TestEditEmployeeRecord()
        {
            homePage.NatigationToEmployeePage();
            homePage.NatigationToLastEmployeePage();
            homePage.NatigationToEmployeeEditPage();
            employeePage.EditEmployeeRecord();
        }

        [Test, Order(3), Description("This test verified the delete of a new Emplyoee record")]
        public void TestDeleteEmployeeRecord()
        {
            homePage.NatigationToEmployeePage();
            homePage.NatigationToLastEmployeePage();
            employeePage.DeleteEmployeeRecord();
        }

        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(3000);
            driver.Quit();
        }
    }
}

