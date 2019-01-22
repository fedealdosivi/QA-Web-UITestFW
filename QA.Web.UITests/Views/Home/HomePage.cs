using QA.Web.UITests.Views.Common;
using QA.Web.UITests.Views.TalkToUs;
using SeleniumExtras.PageObjects;

namespace QA.Web.UITests.Views.Home
{
    public class HomePage : BasicView
    {
        public HomePage(WebUser webUser) : base (webUser)
        {
            Locate = new HomePageLocator(webUser);
            PageFactory.InitElements(Web, Locate);
        }

        public HomePageLocator Locate { get; }

        public TalkToUsPage GotoTalkToUs()
        {
            Locate.TalkToUs.Click();
            return new TalkToUsPage(WebUser);
        }

        public HomePageChecker Verify()
        {
            return new HomePageChecker(WebUser, this);
        }
    }
}
