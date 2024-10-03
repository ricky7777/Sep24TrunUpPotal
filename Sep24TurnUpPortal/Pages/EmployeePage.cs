using System;
using OpenQA.Selenium;

namespace Sep24TurnUpPortal.Pages
{
	public class EmployeePage : BasePage
	{
        public EmployeePage(IWebDriver driver) : base(driver)
        {

        }

        public void CreateEmployeeRecord()
		{
			Console.WriteLine("Employee Record Created");
		}

        public void UpdateEmployeeRecord()
        {
            Console.WriteLine("Employee Record Created");
        }

        public void DeleteEmployeeRecord()
        {
            Console.WriteLine("Employee Record Created");
        }
    }
}

