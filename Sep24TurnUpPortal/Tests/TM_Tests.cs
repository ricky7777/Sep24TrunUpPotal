using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Sep24TurnUpPortal.Pages;
using Sep24TurnUpPortal.Utilities;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Sep24TurnUpPortal.Tests
{
	[TestFixture]
	public class TM_Tests : CommonDriver
    {
        LoginPage loginPageObj;
        HomePage homePageObj;
        TMPages tMPages;

        [SetUp]
		public void SetUpSteps()
		{
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            loginPageObj = new LoginPage(driver);
            loginPageObj.LoginActions();

            homePageObj = new HomePage(driver);
            tMPages = new TMPages(driver);
        }

		[Test]
		public void CreateTime_Test()
		{
            homePageObj.NavigationToTPMPage();
            homePageObj.NatigationToCreatePage();
            tMPages.CreateTimeRecord();
        }

        [Test]
        public void EditTime_Test()
		{
            homePageObj.NatigationToEditPage();
            tMPages.EditTimeRecord();
        }

        [Test]
        public void DeleteTime_Test()
		{
            homePageObj.NavigationToTPMPage();
            homePageObj.NatigationToLastPage();

            tMPages.DeletetimeRecord();
        }

		[TearDown]
		public void CloseTestRun()
		{
            driver.Quit();
        }
	}
}

