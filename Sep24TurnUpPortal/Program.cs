using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Safari;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

internal class Program
{
    private static void Main(string[] args)
    {
        new DriverManager().SetUpDriver(new ChromeConfig());
        //IWebDriver driver = new SafariDriver();
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl("http://horse.industryconnect.io");
        //driver.Manage().Window.Maximize();

        IWebElement userInput = driver.FindElement(By.Id("UserName"));
        userInput.SendKeys("hari");

        IWebElement passwordInput = driver.FindElement(By.Id("Password"));
        passwordInput.SendKeys("123123");

        IWebElement loginBtton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
        loginBtton.Click();

        Thread.Sleep(1000);
        IWebElement helloHari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));

        if (helloHari.Text == "Hello hari!")
        {
            Console.WriteLine("User has logged in successfully. Test passed!");
        }
        else
        {
            Console.WriteLine("User has not logged in. Test failed!");
        }
        Thread.Sleep(10000);

    }


}