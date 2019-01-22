using OpenQA.Selenium;
using QA.Web.UITests.Views.Common;
using SeleniumExtras.PageObjects;

namespace QA.Web.UITests.Views.Home
{
    public class HomePageLocator : BasicViewLocator
    {
        public HomePageLocator(WebUser webUser) : base(webUser) {}

        [FindsBy(How = How.CssSelector, Using = "#main-header .nav-menu-top li a[href*='talk-to-us']")]
        public IWebElement AboutUs { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#main-header .nav-menu-top li a[href*='services']")]
        public IWebElement Services { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#main-header .nav-menu-top li a[href*='our-work']")]
        public IWebElement OurWork { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#main-header .nav-menu-top li a[href*='blog']")]
        public IWebElement Blog { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#main-header .nav-menu-top li a[href*='careers']")]
        public IWebElement Careers { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#main-header .nav-menu-top li a[href*='talk-to-us']")]
        public IWebElement TalkToUs { get; set; }
    }
}
