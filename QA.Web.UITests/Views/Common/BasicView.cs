using OpenQA.Selenium;

namespace QA.Web.UITests.Views.Common
{
    public abstract class BasicView
    {

        protected BasicView(WebUser webUser)
        {
            WebUser = webUser;
        }

        public WebUser WebUser { get; }

        public IWebDriver Web => WebUser.Web;

        
    }
}
