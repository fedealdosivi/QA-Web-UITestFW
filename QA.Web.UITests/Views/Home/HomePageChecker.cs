using NUnit.Framework;
using QA.Web.UITests.Views.Common;

namespace QA.Web.UITests.Views.Home
{
    public class HomePageChecker : BasicViewChecker
    {
        public HomePageChecker(WebUser webUser, HomePage view) : base(webUser)
        {
            View = view;
        }

        public HomePage View { get; }

        public HomePage ElementsArePresentinMenu()
        {
            Assert.IsTrue(View.Locate.AboutUs.Displayed);
            Assert.IsTrue(View.Locate.Services.Displayed);
            Assert.IsTrue(View.Locate.OurWork.Displayed);
            Assert.IsTrue(View.Locate.Blog.Displayed);
            Assert.IsTrue(View.Locate.Careers.Displayed);
            Assert.IsTrue(View.Locate.TalkToUs.Displayed);
            return View;
        }
    }
}
