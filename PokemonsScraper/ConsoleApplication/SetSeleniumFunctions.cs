using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ConsoleApplication
{
    class SetSeleniumFunctions
    {
        public static void EnterText(IWebDriver driver, string element, string value, string elementType, bool click)
        {
            if (elementType == "Id")
            {
                driver.FindElement(By.Id(element)).SendKeys(value);
                if (click)
                {
                    driver.FindElement(By.Id(element)).SendKeys(Keys.Enter);
                }
            }
            if (elementType == "Name")
            {
                driver.FindElement(By.Name(element)).SendKeys(value);
                if (click)
                {
                    driver.FindElement(By.Name(element)).SendKeys(Keys.Enter);
                }
            }


        }
        public static void SelectDropDown(IWebDriver driver, string element, string value, string elementType)
        {
            if (elementType == "Id")
            {
                new SelectElement(driver.FindElement(By.Id(element))).SelectByText(value);
            }
            if (elementType == "Name")
            {
                new SelectElement(driver.FindElement(By.Name(element))).SelectByText(value);
            }


        }

        public static void Click(IWebDriver driver, string element, string elementType)
        {

            if (elementType == "Id")
            {
                driver.FindElement(By.Id(element)).Click();
            }
            if (elementType == "Name")
            {
                driver.FindElement(By.Name(element)).Click();
            }
            if (elementType == "XPath")
            {
                driver.FindElement(By.XPath(element)).Click();
            }
        }
    }
}
