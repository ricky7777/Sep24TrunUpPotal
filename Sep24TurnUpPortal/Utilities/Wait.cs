using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace Sep24TurnUpPortal.Utilities
{
	public class Wait
	{
        public const string LocatorType_XPATH = "XPath";
        // Generic function to wait for an element to be clickable
        public static void WaitToBeClickable(IWebDriver driver, By locatorValue, int timeoutInSeconds = 5)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locatorValue));
            Thread.Sleep(1000);
        }

        public static void WaitToBeVisible(IWebDriver driver, By locatorValue, int timeoutInSeconds = 5)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locatorValue));
            Thread.Sleep(1000);
        }

        public static void WaitToExist(IWebDriver driver, By locatorValue, int timeoutInSeconds = 5)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locatorValue));
            Thread.Sleep(1000);
        }
    }
}

