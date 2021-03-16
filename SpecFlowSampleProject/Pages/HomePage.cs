using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowSampleProject.Pages
{
   public class HomePage :BasePage
    {
        
        IWebElement lnkSignIn => Driver.FindElement(By.XPath("//a[@class='login']"));
        public HomePage(IWebDriver driver) //Driver is always set in the constructor
        {
            Driver = driver;
        }

        public MyAccountPage ClickSignInLink()
        {
            lnkSignIn.Click();
            return new MyAccountPage(Driver);
        }

    }
}
