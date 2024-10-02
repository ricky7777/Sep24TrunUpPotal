using System;
using OpenQA.Selenium;

namespace Sep24TurnUpPortal.Pages
{
	public abstract class BasePage
	{
		protected readonly IWebDriver _driver;
        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

    }
}

