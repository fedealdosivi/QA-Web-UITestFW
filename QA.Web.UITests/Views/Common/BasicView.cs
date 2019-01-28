using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace QA.Web.UITests.Views.Common
{
    public class BasicView
    {
        protected BasicView(WebUser webUser)
        {
            WebUser = webUser;
        }

        public WebUser WebUser { get; set; }

        public IWebDriver Web => WebUser.Web;

        public void ExplicitWait(By locator)
        {
            var wait = new WebDriverWait(Web, new TimeSpan(0, 0, 30));
            var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }
        
    }
}
