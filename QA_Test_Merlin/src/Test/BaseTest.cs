using AventStack.ExtentReports;
using OpenQA.Selenium;
using QA_Test_Merlin.Test;
using QA_Test_Merlin.Behaviour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QA_Test_Merlin.Behaviour.Utils;

namespace QA_Test_Merlin.Test
{
    public class BaseTest
    {
        protected IWebDriver Driver;
        private ExtentTest TestReport;
        public BehaviourManager _behaviourManager;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            ReportsManager.SetupReport();
        }

        [SetUp]
        public void Setup()
        {
            Driver = WebDriverManager.CreateWebDriver();
            TestReport = ReportsManager.CreateTestReport();
            _behaviourManager = new BehaviourManager(Driver,TestReport);
            TestingUtils.MaximizeWindow(Driver);
        }

        [TearDown]
        public void Cleanup()
        {
            ReportsManager.AddResultsToReport();   
            Driver.Quit();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            ReportsManager.TearDownReport();
        }
    }
}
