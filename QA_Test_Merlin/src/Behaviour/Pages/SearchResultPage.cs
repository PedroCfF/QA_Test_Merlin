using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QA_Test_Merlin.Test;
using QA_Test_Merlin.Behaviour.Utils;
using QA_Test_Merlin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public bool VerifyErrorMessageDisplayed(string errorMessage)
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

        //public void SortSearchResultsByCriteria(string sortCriteria)
        //{
        //    try
        //    {
        //        // Implement the behavior to sort the search results by relevant criteria
        //        // Locate the sorting option element and click it based on the provided sort criteria

        //        // Example: Click the sorting option based on sortCriteria
        //        By sortingOptionLocator = By.XPath($"//select[@id='sortingOption']/option[text()='{sortCriteria}']");
        //        IWebElement sortingOption = _driver.FindElement(sortingOptionLocator);
        //        sortingOption.Click();

        //        // Perform additional actions if necessary
        //    }
        //    catch (NoSuchElementException e)
        //    {
        //        _testReport.Log(Status.Fail, $"Failed to sort search results: {e.Message}");
        //    }
        //}

        //public bool VerifySearchResultsSortedByCriteria(string sortCriteria)
        //{
        //    try
        //    {
        //        // Implement the verification logic to check if the search results are rearranged according to the selected sorting option

        //        // Example: Check if the search results are sorted based on sortCriteria
        //        // Get the list of search result items
        //        IReadOnlyList<IWebElement> searchResultItems = _driver.FindElements(SearchResultItemLocator);

        //        // Implement the verification logic based on the provided sortCriteria

        //        _testReport.Log(Status.Pass, "Search results are sorted by the selected criteria");
        //        return true;
        //    }
        //    catch (NoSuchElementException e)
        //    {
        //        _testReport.Log(Status.Fail, $"Failed to verify search results sorting: {e.Message}");
        //        return false;
        //    }
        //}

        //public bool VerifyPaginationControlsAvailable()
        //{
        //    try
        //    {
        //        // Check if the pagination controls are available
        //        bool controlsAvailable = TestingUtils.IsElementVisible(_driver.FindElement(PaginationControlsLocator));

        //        if (controlsAvailable)
        //        {
        //            _testReport.Log(Status.Pass, "Pagination controls are available");
        //        }
        //        else
        //        {
        //            _testReport.Log(Status.Fail, "Pagination controls are not available");
        //        }

        //        return controlsAvailable;
        //    }
        //    catch (NoSuchElementException e)
        //    {
        //        _testReport.Log(Status.Fail, $"Failed to verify pagination controls: {e.Message}");
        //        return false;
        //    }
        //}

        //public void NavigateToPage(int pageNumber)
        //{
        //    try
        //    {
        //        // Implement the behavior to navigate to a specific page of the search results
        //        // Locate the pagination control element corresponding to the provided page number and click it

        //        // Example: Click the pagination control for the specified pageNumber
        //        By paginationControlLocator = By.XPath($"//div[@class='pagination-controls']//a[text()='{pageNumber}']");
        //        IWebElement paginationControl = _driver.FindElement(paginationControlLocator);
        //        paginationControl.Click();

        //        // Perform additional actions if necessary
        //    }
        //    catch (NoSuchElementException e)
        //    {
        //        _testReport.Log(Status.Fail, $"Failed to navigate to page {pageNumber}: {e.Message}");
        //    }
        //}

        //public bool VerifyCorrectResultsDisplayed(int pageNumber)
        //{
        //    try
        //    {
        //        // Implement the verification logic to check if the correct results are displayed for the given page number

        //        // Example: Check if the correct results are displayed for the specified pageNumber

        //        _testReport.Log(Status.Pass, $"Correct results are displayed for page {pageNumber}");
        //        return true;
        //    }
        //    catch (NoSuchElementException e)
        //    {
        //        _testReport.Log(Status.Fail, $"Failed to verify search results on page {pageNumber}: {e.Message}");
        //        return false;
        //    }
        //}
    }
}
