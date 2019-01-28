using System;
using System.Configuration;
using OpenQA.Selenium;
using QA.Web.UITests.Views.Home;

namespace QA.Web.UITests.Views.Common
{
    public class WebUser
    {
        public WebUser()
        {
            Web = new WebInitializer().Start();
            Web.Navigate().GoToUrl(ConfigurationManager.AppSettings["url"]);
        }

        public IWebDriver Web { get; private set; }

        public HomePage VisitHomePage() => new HomePage(this);


        public String GetSelectedBrowser()
        {
            return ConfigurationManager.AppSettings["selectedBrowser"];
        }

    }
}
