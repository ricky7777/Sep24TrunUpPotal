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

        // Navigate to the time and material page
        IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
        createNewButton.Click();

        // Click on Create New Button
        IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
        typeCodeDropdown.Click();

        // Select time for dropdown
        IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
        timeOption.Click();

        // Type code into textbox
        IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
        String codeText = "TA Program test117";
        codeTextbox.SendKeys(codeText);

        // Type description into description textbox
        IWebElement descriptiontbox = driver.FindElement(By.Id("Description"));
        descriptiontbox.SendKeys("This is a description");

        // Type price into price textbox
        IWebElement priceTagOverlap = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
        priceTagOverlap.Click();
        IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
        priceTextbox.SendKeys("12");

        // Click on Save button
        IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
        saveButton.Click();
        Thread.Sleep(3000);
    
        // Check if Time record has been created successfully
        IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
        goToLastPageButton.Click();

        IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
        if(newCode.Text == codeText)
        {
            Console.WriteLine("Time record created successfuly");
        }
        else {
            Console.WriteLine("New time has not been created!");
        }
        Thread.Sleep(5000);

    }


}