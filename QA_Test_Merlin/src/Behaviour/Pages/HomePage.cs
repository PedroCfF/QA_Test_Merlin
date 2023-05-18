using AventStack.ExtentReports;
using OpenQA.Selenium;
using QA_Test_Merlin.Test;
using QA_Test_Merlin.Behaviour.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace QA_Test_Merlin.Behaviour.Pages
{
    public class HomePage
    {
        private readonly IWebDriver _driver;
        private readonly ExtentTest _testReport;

        // Locators for elements on the home page
        private By mainContainer => By.Id("theme-app");

        private By searchLinkLocator = By.CssSelector($"a[href='https://www.zara.com/es/es/search']");
        private By SearchInputLocator => By.Id("search-products-form-combo-input");

        private By CookiesPanel = By.Id("onetrust-group-container");

        private By CookiesButton = By.Id("onetrust-accept-btn-handler");

        private string url = "https://www.zara.com/es/";

        public HomePage(IWebDriver driver, ExtentTest testReport)
        {
            _driver = driver;
            _testReport = testReport;
        }

        public void NavigateToHomePage()
        {
            _driver.Navigate().GoToUrl(url);
            TestingUtils.WaitForElement(_driver, mainContainer);
        }

        public void PerformSearch(string searchTerm)
        {
            if (TestingUtils.ElementIsDisplayed(_driver.FindElement(CookiesPanel))) _driver.FindElement(CookiesButton).Click();
            _driver.FindElement(searchLinkLocator).Click();
            TestingUtils.WaitForElement(_driver, SearchInputLocator);
            _driver.FindElement(SearchInputLocator).SendKeys(searchTerm);
            _driver.FindElement(SearchInputLocator).SendKeys(Keys.Enter);
        }
    }
}
