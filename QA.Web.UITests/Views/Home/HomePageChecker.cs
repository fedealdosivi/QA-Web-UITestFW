using NUnit.Framework;

namespace QA.Web.UITests.Views.Home
{
    public class HomePageChecker 
    {
        public HomePageChecker(HomePage view) 
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
