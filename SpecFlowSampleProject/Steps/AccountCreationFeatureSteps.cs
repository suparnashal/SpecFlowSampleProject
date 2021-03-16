using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowSampleProject.Framework;
using SpecFlowSampleProject.Pages;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowSampleProject.Steps
{
    [Binding]
    public class AccountCreationFeatureSteps
    {

        BasePage currentPage;
        IWebDriver Driver;

        public AccountCreationFeatureSteps(ScenarioContext _scenarioContext)
        {
            Driver = (IWebDriver)_scenarioContext["Driver"];
        }

        [Given(@"we are on homepage")]
        public void GivenWeAreOnHomepage()
        {
            // IWebDriver driver = BrowserFactory.GetBrowser();
            //currentPage = new HomePage(driver).OpenUrlAndLogin();

            currentPage = new HomePage(Driver);
        }
        
        [Given(@"we click Sign in")]
        public void GivenWeClickSignIn()
        {
            currentPage = ((HomePage)currentPage).ClickSignInLink();
        }


        [When(@"we enter email ""(.*)""\tand click Create Account button")]
        public void WhenWeEnterEmailAndClickCreateAccountButton(string p0)
        {
            ((MyAccountPage)currentPage).EnterEmailId(p0);
            currentPage = ((MyAccountPage)currentPage).ClickCreateAccountBtn();

        }           
        
        [Then(@"Create an account page opens")]
        public void ThenCreateAnAccountPageOpens()
        {
            Assert.That(((CreateAccountPage)currentPage).isPageHeadingDisplayed);            
        }
    }
}
