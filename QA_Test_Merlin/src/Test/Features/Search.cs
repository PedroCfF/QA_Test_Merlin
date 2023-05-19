using QA_Test_Merlin.Behaviour;
using QA_Test_Merlin.Behaviour.Pages;
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
        }

        [Test]
        public void ValidSearchQuery_ValidTerm_ReturnsSearchResults()
        {
            _homePage.NavigateToHomePage();
            _homePage.PerformSearchAndClosePopUps("Campus 00s");

            // Verify that the search results page is displayed
            Assert.IsTrue(_searchResultPage.VerifySearchResultsDisplayed(), "Search results page is not displayed");

            // Verify that the search results contain the expected items related to the search term
            Assert.IsTrue(_searchResultPage.VerifySearchResultsContainItems("Campus 00s"), "Search results do not contain the expected items");
        }

        [Test]
        public void InvalidSearchQuery_InvalidTerm_DisplaysErrorMessage()
        {
            _homePage.NavigateToHomePage();
            _homePage.PerformSearchAndClosePopUps("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");

            // Verify that an appropriate error message or notification is displayed
            Assert.IsTrue(_searchResultPage.VerifyErrorMessageDisplayed(), "Error message is not displayed");

            // Verify that no search results are shown
            Assert.IsTrue(_searchResultPage.VerifyNoSearchResultsDisplayed(), "Search results are displayed");
        }

        [Test]
        public void EmptySearchQuery_EmptyTerm_HasNoEffect()
        {
            _homePage.NavigateToHomePage();
            _homePage.PerformSearchAndClosePopUps(" ");

            // Verify that an appropriate error message or notification is displayed
            Assert.IsTrue(_homePage.VerifyHomePageIsDisplayed(), "Empty search had unexpected effects");
        }

        [Test]
        public void SearchResultSorting_ValidTerm_SortsResultsByCriteria()
        {
            _homePage.NavigateToHomePage();
            _homePage.PerformSearchAndClosePopUps("Camiseta");

            // Perform a search result sorting by relevant criteria
            _searchResultPage.SortSearchResultsByCriteria(1);

            //Verify that the search results are sorted by the selected criteria
            Assert.IsTrue(_searchResultPage.VerifySearchResultsSortedByCriteria(), "Search results are not sorted by price");
        }

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
