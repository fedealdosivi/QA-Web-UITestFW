using System.Threading;
using NUnit.Framework;
using QA.Web.UITests.Views.Common;

namespace QA.Web.UITests.Views.TalkToUs
{
    public class TalkToUsPageChecker : BasicViewChecker
    {
        public TalkToUsPageChecker(WebUser webUser, TalkToUsPage view) : base(webUser)
        {
            View = view;
        }

        public TalkToUsPage View { get; }

        public TalkToUsPage EmailConfirmation()
        {
            Thread.Sleep(5000);
            Assert.IsTrue(View.Locate.ConfirmationText.Text.Equals("Thanks for getting in touch with us!"));
            return View;
        }

        public TalkToUsPage RequiredFields()
        {
            Assert.IsTrue(View.Locate.ErrorNameField.Text.Equals("Please, fill in this field"));
            Assert.IsTrue(View.Locate.ErrorEmailField.Text.Equals("This is not a valid email address :("));
            Assert.IsTrue(View.Locate.ErrorMessageField.Text.Equals("Please, fill in this field"));
            return View;
        }
    }
}
