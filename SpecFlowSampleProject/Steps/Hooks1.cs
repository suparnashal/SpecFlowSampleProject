using OpenQA.Selenium;
using SpecFlowSampleProject.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowSampleProject.Steps
{
    [Binding]
    public sealed class HooksInitialize 
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private readonly ScenarioContext scenarioContext;
        IWebDriver Driver;

        public HooksInitialize(ScenarioContext _scenarioContext)
        {
            Driver = BrowserFactory.GetBrowser();
            scenarioContext = _scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            scenarioContext["Driver"] = Driver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Driver.Quit();
        }
    }
}
