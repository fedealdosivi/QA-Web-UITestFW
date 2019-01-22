using OpenQA.Selenium;

namespace QA.Web.UITests.Views.Common
{
    public class BasicViewChecker
    {
        protected BasicViewChecker(WebUser webUser)
        {
            WebUser = webUser;
        }

        public WebUser WebUser { get; }

        public IWebDriver Web => WebUser.Web;
    }
}
