using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowSampleProject.Pages
{
   public class MyAccountPage : BasePage
    {
        IWebElement txtEmail => Driver.FindElement(By.Id("email_create"));
        IWebElement btnCreateAccount => Driver.FindElement(By.Id("SubmitCreate"));
        public MyAccountPage(IWebDriver _driver)
        {
            Driver = _driver;
        }

        public void EnterEmailId(string p0)
        {
            txtEmail.SendKeys(p0);
        }

        public CreateAccountPage ClickCreateAccountBtn()
        {
            btnCreateAccount.Click();
          return  new CreateAccountPage(Driver);
        }
    }
}
