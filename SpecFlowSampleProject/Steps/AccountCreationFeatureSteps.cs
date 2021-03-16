using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowSampleProject.Framework;
using SpecFlowSampleProject.Pages;
using System;
using TechTalk.SpecFlow;

/// <summary>
/// This class demonstrates using BeforeScenario and AfterScenario hooks in class implementing the steps
/// Useful for initializations specific to a given scenario/scenarios
/// </summary>
namespace SpecFlowSampleProject.Steps
{
    [Binding]
    public class AccountCreationFeatureSteps
    {

        BasePage currentPage;
        IWebDriver Driver;

        public AccountCreationFeatureSteps()
        {
            Driver = BrowserFactory.GetBrowser();              
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Driver.Navigate().GoToUrl("http://automationpractice.com/index.php");

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

        [AfterScenario]
        public void AfterScenario()
        {
            Driver.Quit();
        }
    }
}
