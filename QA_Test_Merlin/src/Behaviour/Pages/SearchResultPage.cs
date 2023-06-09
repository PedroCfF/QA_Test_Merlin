﻿using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QA_Test_Merlin.Test;
using QA_Test_Merlin.Behaviour.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace QA_Test_Merlin.Behaviour.Pages
{
    public class SearchResultPage
    {
        private readonly IWebDriver _driver;
        private readonly ExtentTest _testReport;

        private By ResultsContainerLocator => By.Id("main-content");

        private By SearchResultsContainerLocator = By.CssSelector("[data-auto-id='product_container']");
        private By SearchResultItemDescriptionLocator => By.CssSelector("[data-auto-id='product-card-title']");
        private By ErrorMessageLocator => By.XPath($"//h4[contains(text(), '¡VAYA! NO HAY RESULTADOS')]");
        private By PaginationControlsLocator => By.ClassName("pagination-controls");

        private By SortingDropdownLocator = By.XPath("//div[@data-auto-id='dropdown-container']");

        private By SalePriceLocator = By.XPath("//div[@class= 'gl-price-item gl-price-item--sale notranslate']");

        private By PaginationContainerLocator = By.CssSelector("[data-auto-id='plp-pagination']");

        private By PaginationRightButtonLocator = By.CssSelector("[data-auto-id='pagination-right-button']");



        public SearchResultPage(IWebDriver driver, ExtentTest testReport)
        {
            _driver = driver;
            _testReport = testReport;
        }

        public bool VerifySearchResultsDisplayed()
        {
            try
            {
                TestingUtils.WaitForElement(_driver, ResultsContainerLocator);
                bool resultsDisplayed = TestingUtils.ElementIsDisplayed(_driver.FindElement(SearchResultsContainerLocator));

                if (resultsDisplayed)
                {
                    _testReport.Log(Status.Pass, "Search results are displayed");
                }
                else
                {
                    _testReport.Log(Status.Fail, "Search results are not displayed");
                }

                return resultsDisplayed;
            }
            catch (NoSuchElementException e)
            {
                _testReport.Log(Status.Fail, $"Failed to verify search results: {e.Message}");
                return false;
            }
        }

        public bool VerifySearchResultsContainItems(string searchTerm)
        {
            try
            {
                // Get the list of search result items
                IReadOnlyList<IWebElement> searchResultItems = _driver.FindElements(SearchResultItemDescriptionLocator);

                // Check if the search results contain the expected items related to the search term
                bool containsItems = searchResultItems.Any(item => item.Text.Contains(searchTerm));

                if (containsItems)
                {
                    _testReport.Log(Status.Pass, "Search results contain the expected items");
                }
                else
                {
                    _testReport.Log(Status.Fail, "Search results do not contain the expected items");
                }

                return containsItems;
            }
            catch (NoSuchElementException e)
            {
                _testReport.Log(Status.Fail, $"Failed to verify search results: {e.Message}");
                return false;
            }
        }

        public bool VerifyErrorMessageDisplayed()
        {
            try
            {
                TestingUtils.WaitForElement(_driver, ResultsContainerLocator);

                // Check if the error message is displayed
                bool isDisplayed = TestingUtils.ElementIsDisplayed(_driver.FindElement(ErrorMessageLocator));

                if (isDisplayed)
                {
                    _testReport.Log(Status.Pass, "Error message is displayed");
                }
                else
                {
                    _testReport.Log(Status.Fail, "Error message is not displayed");
                }

                return isDisplayed;
            }
            catch (NoSuchElementException e)
            {
                _testReport.Log(Status.Fail, $"Failed to verify error message: {e.Message}");
                return false;
            }
        }

        public bool VerifyNoSearchResultsDisplayed()
        {
            try
            {
                TestingUtils.WaitForElement(_driver, ResultsContainerLocator);

                // Check if no search results are shown
                bool noResultsDisplayed = !_driver.FindElements(SearchResultsContainerLocator).Any();

                if (noResultsDisplayed)
                {
                    _testReport.Log(Status.Pass, "No search results are displayed");
                }
                else
                {
                    _testReport.Log(Status.Fail, "Search results are displayed");
                }

                return noResultsDisplayed;
            }
            catch (NoSuchElementException e)
            {
                _testReport.Log(Status.Fail, $"Failed to verify search results: {e.Message}");
                return false;
            }
        }

        public void SortSearchResultsByCriteria(int sortCriteriaIndexPosition)
        {
            try
            {
                _driver.FindElement(SortingDropdownLocator).Click();
                _driver.FindElement(By.XPath($"(//div[@data-auto-id='item-wrapper']//button)[{sortCriteriaIndexPosition}]")).Click();
            }
            catch (NoSuchElementException e)
            {
                _testReport.Log(Status.Fail, $"Failed to sort search results: {e.Message}");
            }
        }

        public bool VerifySearchResultsSortedByCriteria()
        {
            try
            {
                TestingUtils.WaitForElement(_driver, SalePriceLocator);

                IReadOnlyList<IWebElement> searchResultItemPrices = _driver.FindElements(SalePriceLocator);

                List<double> processedPrices = new List<double>();

                foreach (IWebElement searchResultItemPrice in searchResultItemPrices)
                {
                    string priceText = searchResultItemPrice.Text.Replace("€", "").Trim();
                    double price = double.Parse(priceText);
                    processedPrices.Add(price);
                }

                bool isSorted = processedPrices.SequenceEqual(processedPrices.OrderBy(p => p));

                if (isSorted)
                {
                    _testReport.Log(Status.Pass, "Search results are sorted by the selected criteria");
                    return true;
                }
                else
                {
                    _testReport.Log(Status.Fail, "Search results are not sorted by the selected criteria");
                    return false;
                }
            }
            catch (NoSuchElementException e)
            {
                _testReport.Log(Status.Fail, $"Failed to verify search results sorting: {e.Message}");
                return false;
            }
        }

        public bool VerifyPaginationControlsAvailable()
        {
            try
            {
                TestingUtils.WaitForElement(_driver, ResultsContainerLocator);

                // Check if the pagination controls are available
                bool controlsAvailable = TestingUtils.ElementIsDisplayed(_driver.FindElement(PaginationContainerLocator));

                if (controlsAvailable)
                {
                    _testReport.Log(Status.Pass, "Pagination controls are available");
                }
                else
                {
                    _testReport.Log(Status.Fail, "Pagination controls are not available");
                }

                return controlsAvailable;
            }
            catch (NoSuchElementException e)
            {
                _testReport.Log(Status.Fail, $"Failed to verify pagination controls: {e.Message}");
                return false;
            }
        }

        public bool VerifyCorrectResultsDisplayed(int pageNumber)
        {
            try
            {
                TestingUtils.WaitForElement(_driver, PaginationRightButtonLocator);
                _driver.FindElement(PaginationRightButtonLocator).Click();

                TestingUtils.WaitForElement(_driver, ResultsContainerLocator);

                bool resultsDisplayed = TestingUtils.ElementIsDisplayed(_driver.FindElement(SearchResultsContainerLocator));

                if (resultsDisplayed)
                {
                    _testReport.Log(Status.Pass, "Search results are displayed");
                }
                else
                {
                    _testReport.Log(Status.Fail, "Search results are not displayed");
                }

                return resultsDisplayed;
            }
            catch (NoSuchElementException e)
            {
                _testReport.Log(Status.Fail, $"Failed to verify search results on page {pageNumber}: {e.Message}");
                return false;
            }
        }

        public bool VerifyUrl(int pageNumber)
        {
            try
            {
                string currentUrl = _driver.Url;
                string queryString = new Uri(currentUrl).Query;
                var queryDictionary = HttpUtility.ParseQueryString(queryString);

                int currentPageStart = Convert.ToInt32(queryDictionary["start"]);
                int expectedPageStart = 48*pageNumber;

                Boolean returnValue;

                if (currentPageStart == expectedPageStart)
                {
                    _testReport.Log(Status.Pass, $"Next page URL is correct. start={expectedPageStart}");
                    returnValue = true;
                }
                else
                {
                    _testReport.Log(Status.Fail, $"Next page URL is incorrect. Actual start={currentPageStart}");
                    returnValue = false;
                }

                return returnValue;

            }
            catch (Exception e)
            {
                _testReport.Log(Status.Fail, $"Failed to verify pagination increment: {e.Message}");
                return false;
            }
        }

    }
}
