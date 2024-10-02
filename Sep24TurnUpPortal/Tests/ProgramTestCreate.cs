using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Sep24TurnUpPortal.Pages;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

internal class ProgramTestCreate
{
    private static void Main3(string[] args)
    {
        new DriverManager().SetUpDriver(new ChromeConfig());
        //IWebDriver driver = new SafariDriver();
        IWebDriver driver = new ChromeDriver();
        LoginPage loginPageObj = new LoginPage(driver);
        loginPageObj.LoginActions();

        HomePage homePageObj = new HomePage(driver);
        homePageObj.NavigationToTPMPage();
        homePageObj.NatigationToCreatePage();

        TMPages tmpPageObj = new TMPages(driver);
        tmpPageObj.CreateTimeRecord();

        Thread.Sleep(3000);

    }


}