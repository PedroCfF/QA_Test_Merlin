﻿using AventStack.ExtentReports;
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

        private string url = "https://www.adidas.es/";

        // Locators for elements on the home page
        private By mainContainer => By.Id("main-content");

        private By SearchInputLocator = By.CssSelector("[data-auto-id='searchinput-desktop']");

        private By CookiesPanelLocator = By.Id("gl-modal__main-content-cookie-consent-modal");

        private By AcceptCookiesButtonLocator = By.Id("glass-gdpr-default-consent-accept-button");

        private By NewsletterSubscriptionPopUpLocator = By.CssSelector("[data-auto-id='landing-screen']");

        private By NewsletterSubscriptionPopUpCloseButtonLocator = By.CssSelector("button[name='account-portal-close']");

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

        public bool VerifyHomePageIsDisplayed()
        {
            try
            {
                //TestingUtils.WaitForElement(_driver, mainContainer);
                TestingUtils.Wait(3000);

                // Check if the home page is displayed
                bool isHomePageDisplayed = TestingUtils.ElementIsDisplayed(_driver.FindElement(mainContainer));

                Console.WriteLine("here");

                if (isHomePageDisplayed)
                {
                    _testReport.Log(Status.Pass, "Home page is still displayed");
                }
                else
                {
                    _testReport.Log(Status.Fail, "Home page is not displayed");
                }

                return isHomePageDisplayed;
            }
            catch (NoSuchElementException e)
            {
                _testReport.Log(Status.Fail, $"Failed to locate home page element: {e.Message}");
                return false;
            }
        }

        public void PerformSearchAndClosePopUps(string searchTerm)
        {
            ClosePopUp(CookiesPanelLocator, AcceptCookiesButtonLocator);

            _driver.FindElement(SearchInputLocator).Click();
            TestingUtils.WaitForElement(_driver, SearchInputLocator);
            _driver.FindElement(SearchInputLocator).SendKeys(searchTerm);
            _driver.FindElement(SearchInputLocator).SendKeys(Keys.Enter);

            ClosePopUp(NewsletterSubscriptionPopUpLocator, NewsletterSubscriptionPopUpCloseButtonLocator);
        }

        private void ClosePopUp(By panelLocator, By closeButtonPopUpLocator)
        {
            try
            {
                // Check if the pop-up or panel is displayed before attempting to interact with it
                if (TestingUtils.ElementExists(_driver, panelLocator))
                {
                    TestingUtils.WaitForElement(_driver, panelLocator);
                    // Click the close button of the pop-up
                    _driver.FindElement(closeButtonPopUpLocator).Click();
                }
            }
            catch (NoSuchElementException)
            {
                _testReport.Log(Status.Info, "Pop-up or panel was not displayed");
            }
        }
    }
}
