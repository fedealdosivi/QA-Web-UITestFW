using System;
using System.Configuration;
using OpenQA.Selenium;
using QA.Web.UITests.Utils.Browsers;
using QA.Web.UITests.Views.Home;

namespace QA.Web.UITests.Views.Common
{
    public class WebUser
    {
        public WebUser()
        {
           // browser = GetSelectedBrowser();
            Web = new WebInitializer().Start(Browser.CHROME);
            Web.Navigate().GoToUrl(ConfigurationManager.AppSettings["url"]);
            Web.Manage().Window.Maximize();
        }

        public IWebDriver Web { get; private set; }

        public HomePage VisitHomePage() => new HomePage(this);


        private String GetSelectedBrowser()
        {
            return ConfigurationManager.AppSettings["selectedBrowser"];
        }

    }
}
