using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Sep24TurnUpPortal.Pages;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

internal class ProgramTestDelete
{
    private static void Main(string[] args)
    {
        new DriverManager().SetUpDriver(new ChromeConfig());
        IWebDriver driver = new ChromeDriver();
        LoginPage loginPageObj = new LoginPage(driver);
        loginPageObj.LoginActions();

        HomePage homePageObj = new HomePage(driver);
        homePageObj.NavigationToTPMPage();
        homePageObj.NatigationToLastPage();

        TMPages tMPages = new TMPages(driver);
        tMPages.DeletetimeRecord();

        Thread.Sleep(5000);

    }


}