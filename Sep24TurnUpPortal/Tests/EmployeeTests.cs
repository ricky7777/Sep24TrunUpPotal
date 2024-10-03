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
        LoginPage loginPageObj = new LoginPage(driver);
        HomePage homePage = new HomePage(driver);
        EmployeePage employeePage = new EmployeePage(driver);

        [SetUp]
        public void SetUp()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            loginPageObj.LoginActions();
        }

        [Test, Order(1), Description("This test verified the creation of a new Emplyoee record")]
        public void TestCreateEmployeeRecord()
        {
            employeePage.CreateEmployeeRecord();
        }

        [Test, Order(2), Description("This test verified the edit of a new Emplyoee record")]
        public void TestEditEmployeeRecord()
        {

        }

        [Test, Order(3), Description("This test verified the delete of a new Emplyoee record")]
        public void TestDeleteEmployeeRecord()
        {

        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}

