using OpenQA.Selenium;
using QA.Web.UITests.Views.Common;

namespace QA.Web.UITests.Views.Home
{
    public class HomePageLocator 
    {
        IWebDriver Web;
        public HomePageLocator(WebUser webUser) 
        {
            Web = webUser.Web;
        }

        public IWebElement AboutUs => Web.FindElement(By.CssSelector("#main-header .nav-menu-top li a[href*='talk-to-us']"));

        public IWebElement Services => Web.FindElement(By.CssSelector("#main-header .nav-menu-top li a[href*='services']"));

        public IWebElement OurWork => Web.FindElement(By.CssSelector("#main-header .nav-menu-top li a[href*='our-work']"));

        public IWebElement Blog => Web.FindElement(By.CssSelector("#main-header .nav-menu-top li a[href*='blog']"));

        public IWebElement Careers => Web.FindElement(By.CssSelector("#main-header .nav-menu-top li a[href*='careers']"));

        public IWebElement TalkToUs => Web.FindElement(By.CssSelector("#main-header .nav-menu-top li a[href*='talk-to-us']"));

    }
}
