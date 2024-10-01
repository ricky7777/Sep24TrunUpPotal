using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

internal class ProgramTestModify
{
    private static void Main3(string[] args)
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

        // Create a Time record

        // Create a time and material record
        IWebElement administrationTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
        administrationTab.Click();

        IWebElement timeAndMaterialOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
        timeAndMaterialOption.Click();

        // Find final button
        IWebElement lastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        lastPageButton.Click();
        Thread.Sleep(1000);

        // Find final raw click edit
        IWebElement lastRawEdit = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
        lastRawEdit.Click();


        // Modify description textbox
        IWebElement descriptionTextBox = driver.FindElement(By.Id("Description"));        
        String modifyText = "Modify";

        descriptionTextBox.Clear();
        descriptionTextBox.SendKeys(modifyText);

        // Save Button
        IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
        saveButton.Click();
        Thread.Sleep(2000);

        // Verify description text
        IWebElement lastDescriptionText = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
        if (lastDescriptionText.Text == modifyText)
        {
            Console.WriteLine("Description modify successfuly");
        }
        else
        {
            Console.WriteLine("Description modify failed");
        }
        

        Thread.Sleep(5000);

    }


}