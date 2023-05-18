﻿using QA_Test_Merlin.Behaviour;
using QA_Test_Merlin.Behaviour.Pages;
using QA_Test_Merlin.Models;
using QA_Test_Merlin.Test.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Test_Merlin.Test.Features
{
    public class Search : BaseTest
    {
        private HomePage _homePage;
        private SearchResultPage _searchResultPage;

        [SetUp]
        public void TestSetup()
        {
            _homePage = _behaviourManager.HomePage;
            _searchResultPage = _behaviourManager.SearchResultPage;

            // Perform the necessary setup steps for the test scenario, e.g., login to the website
            // ...
        }

        [Test]
        public void ValidSearchQuery_ValidTerm_ReturnsSearchResults()
        {
            _homePage.NavigateToHomePage();
            _homePage.PerformSearch("CAMISETA");

            // Verify that the search results page is displayed
            Assert.IsTrue(_searchResultPage.VerifySearchResultsDisplayed(), "Search results page is not displayed");

            // Verify that the search results contain the expected items related to the search term
            Assert.IsTrue(_searchResultPage.VerifySearchResultsContainItems("CAMISETA"), "Search results do not contain the expected items");
        }

        //[Test]
        //public void InvalidSearchQuery_InvalidTerm_DisplaysErrorMessage()
        //{
        //    // Navigate to the search feature of the website
        //    _homePage.NavigateToSearch();

        //    // Enter an invalid search term and press the "Search" button
        //    _homePage.EnterSearchTerm("invalid term");
        //    _homePage.ClickSearchButton();

        //    // Verify that an appropriate error message or notification is displayed
        //    Assert.IsTrue(_searchResultPage.VerifyErrorMessageDisplayed("Invalid search term"), "Error message is not displayed");

        //    // Verify that no search results are shown
        //    Assert.IsTrue(_searchResultPage.VerifyNoSearchResultsDisplayed(), "Search results are displayed");
        //}

        //[Test]
        //public void EmptySearchQuery_EmptyTerm_DisplaysErrorMessage()
        //{
        //    // Navigate to the search feature of the website
        //    _homePage.NavigateToSearch();

        //    // Leave the search field empty and press the "Search" button
        //    _homePage.ClearSearchTerm();
        //    _homePage.ClickSearchButton();

        //    // Verify that an appropriate error message or notification is displayed
        //    Assert.IsTrue(_searchResultPage.VerifyErrorMessageDisplayed("Please enter a search term"), "Error message is not displayed");

        //    // Verify that no search results are shown
        //    Assert.IsTrue(_searchResultPage.VerifyNoSearchResultsDisplayed(), "Search results are displayed");
        //}

        //[Test]
        //public void SearchResultSorting_ValidTerm_SortsResultsByCriteria()
        //{
        //    // Navigate to the search feature of the website
        //    _homePage.NavigateToSearch();

        //    // Enter a valid search term and press the "Search" button
        //    _homePage.EnterSearchTerm("valid term");
        //    _homePage.ClickSearchButton();

        //    // Perform a search result sorting by relevant criteria
        //    _searchResultPage.SortSearchResultsByCriteria("price");

        //    // Verify that the search results are sorted by the selected criteria
        //    Assert.IsTrue(_searchResultPage.VerifySearchResultsSortedByCriteria("price"), "Search results are not sorted by price");
        //}

        //[Test]
        //public void Pagination_MultiplePages_ReturnsCorrectResults()
        //{
        //    // Navigate to the search feature of the website
        //    _homePage.NavigateToSearch();

        //    // Enter a search term that returns multiple pages of results
        //    _homePage.EnterSearchTerm("multiple pages");
        //    _homePage.ClickSearchButton();
        //    // Verify that the pagination controls are available
        //    Assert.IsTrue(_searchResultPage.VerifyPaginationControlsAvailable(), "Pagination controls are not available");

        //    // Perform navigation through the pages and ensure the correct results are displayed
        //    for (int pageNumber = 1; pageNumber <= 3; pageNumber++)
        //    {
        //        // Navigate to the specified page
        //        _searchResultPage.NavigateToPage(pageNumber);

        //        // Verify that the correct results are displayed for the given page number
        //        Assert.IsTrue(_searchResultPage.VerifyCorrectResultsDisplayed(pageNumber), $"Correct results are not displayed for page {pageNumber}");
        //    }
        //}
    }
}
