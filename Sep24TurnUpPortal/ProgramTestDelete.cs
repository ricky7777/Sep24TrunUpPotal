using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

internal class ProgramTestDelete
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
        Thread.Sleep(2000);

        IWebElement helloHari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));

        if (helloHari.Text == "Hello hari!")
        {
            Console.WriteLine("User has logged in successfully. Test passed!");
        }
        else
        {
            Console.WriteLine("User has not logged in. Test failed!");
        }
    

        // Create a time and material record
        IWebElement administrationTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
        administrationTab.Click();

        IWebElement timeAndMaterialOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
        timeAndMaterialOption.Click();

        // Find Final button
        IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        goToLastPageButton.Click();
        Thread.Sleep(2000);


        // Click Last raw delete button
        IWebElement lastDeleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
        lastDeleteButton.Click();

        Thread.Sleep(2000);
        IAlert confirmAlert = driver.SwitchTo().Alert();
        string confirmText = confirmAlert.Text;
        confirmAlert.Accept();

        Thread.Sleep(5000);

    }


}