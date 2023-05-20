# QA-Test-Merlin

This project is a test automation framework developed using NUnit, Selenium, and Extent Report. It focuses on testing the search functionality of the adidas website https://www.adidas.es/

## Overview

The project aims to automate the testing of the search feature in a web application. It includes various test scenarios to validate the behavior and correctness of the search functionality. The tests are written in C# using the NUnit framework and utilize Selenium WebDriver for interacting with the web application.
The framework follows the Page Object Model (POM) design pattern, which enhances the maintainability and readability of the tests. It separates the test logic from the page-specific elements and actions, allowing for easy modification and reusability.

## Test Scenarios

The project includes several test scenarios to validate the search functionality:

- **ValidSearchQuery_ValidTerm_ReturnsSearchResults**: Verifies that search results are displayed for a valid search term.
- **InvalidSearchQuery_InvalidTerm_DisplaysErrorMessage**: Verifies that an appropriate error message is displayed for an invalid search term.
- **EmptySearchQuery_EmptyTerm_HasNoEffect**: Verifies that performing an empty search has no effect on the application.
- **SearchResultSorting_ValidTerm_SortsResultsByCriteria**: Verifies that the search results are correctly sorted based on the selected sorting criteria.
- **Pagination_MultiplePages_ReturnsCorrectResults**: Verifies that the pagination functionality works correctly and displays the expected results for multiple pages.

## Reporting

The project utilizes Extent Report for test reporting. After running the tests, a test report in HTML format will be generated and saved in the `TestResults` folder. The report provides detailed information about test execution, including test status, steps, and any failures encountered.

## Usage

To use this test automation framework, follow these steps:

1. Clone the project repository to your local machine.
2. Open the solution with Visual Studio Code.
3. Ensure that you have the necessary dependencies installed:
   - coverlet.collector (3.1.2)
   - DotNetSeleniumExtras.WaitHelpers (3.11.0)
   - ExtentReports (4.1.0)
   - Microsoft.NET.Test.SDK (17.1.0)
   - NUnit (3.13.3)
   - NUnit.Analyzers (3.3.0)
   - NUnit3TestAdapter (4.2.1)
   - Selenium.WebDriver (4.9.1)
   - Selenium.WebDriver.ChromeDriver (113.0.5672.6300)
4. Build the project to restore dependencies and compile the code.
5. Run the tests using the test runner in Visual Studio Code or the command line.
   - Run all tests
     ```shell
     dotnet test
     ```
   - Run single test
     ```shell
     dotnet test --filter FullyQualifiedName~ValidSearchQuery_ValidTerm_ReturnsSearchResults
     ```

6. The test execution results will be saved in the `TestResults` folder as an HTML report. You can open it with your favourite browser to properly see whe results in a well designed webpage.

## License

This project is licensed under the MIT License.
