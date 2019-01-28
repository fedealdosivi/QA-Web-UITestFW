using QA.Web.UITests.Views.Common;
using QA.Web.UITests.Views.TalkToUs;

namespace QA.Web.UITests.Views.Home
{
    public class HomePage : BasicView
    {
        public HomePage(WebUser webUser) : base (webUser)
        {
            Locate = new HomePageLocator(webUser);
        }

        public HomePageLocator Locate { get; }

        public TalkToUsPage GotoTalkToUs()
        {
            Locate.TalkToUs.Click();
            return new TalkToUsPage(WebUser);
        }

        public HomePageChecker Verify()
        {
            return new HomePageChecker(this);
        }
    }
}
