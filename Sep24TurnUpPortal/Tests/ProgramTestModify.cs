using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Sep24TurnUpPortal.Pages;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

internal class ProgramTestModify
{
    private static void Main3(string[] args)
    {
        new DriverManager().SetUpDriver(new ChromeConfig());
        IWebDriver driver = new ChromeDriver();
        LoginPage loginPageObj = new LoginPage(driver);
        loginPageObj.LoginActions();

        HomePage homePageObj = new HomePage(driver);
        homePageObj.NatigationToEditPage();

        TMPages tMPages = new TMPages(driver);
        tMPages.EditTimeRecord();

        Thread.Sleep(5000);

    }


}