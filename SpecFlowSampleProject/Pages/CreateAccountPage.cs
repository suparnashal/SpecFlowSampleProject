using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowSampleProject.Pages
{
   public class CreateAccountPage : BasePage
    {
        public CreateAccountPage(IWebDriver driver)
        {
            Driver = driver;
        }

        IWebElement lblPageheading => Driver.FindElement(By.XPath("//h1[@class='page-heading']"));

        public bool isPageHeadingDisplayed()
        {
            return lblPageheading.Displayed;
        }
    }
}
