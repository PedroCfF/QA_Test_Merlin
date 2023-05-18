using AventStack.ExtentReports;
using OpenQA.Selenium;
using QA_Test_Merlin.Behaviour.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Test_Merlin.Behaviour
{
    public class BehaviourManager
    {
        public SearchResultPage SearchResultPage { get; }
        public HomePage HomePage { get; }

        public BehaviourManager(IWebDriver driver, ExtentTest testReport)
        {
            SearchResultPage = new SearchResultPage(driver, testReport);
            HomePage = new HomePage(driver, testReport);
        }
    }
}
