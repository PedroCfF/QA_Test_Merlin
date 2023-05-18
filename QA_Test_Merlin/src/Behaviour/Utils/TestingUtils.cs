using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace QA_Test_Merlin.Behaviour.Utils
{
    public static class TestingUtils
    {
        public static void WaitForUrl(IWebDriver driver, string expectedUrl)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5000));
            wait.Until(ExpectedConditions.UrlToBe(expectedUrl));
        }

        public static void WaitForElement(IWebDriver driver, By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5000));
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static void Wait(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }

        public static void MaximizeWindow(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
        }

        public static bool ElementIsDisplayed(IWebElement element)
        {
            try
            {
                return element.Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
