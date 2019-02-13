using NUnit.Framework;

namespace QA.Web.UITests.Views.TalkToUs
{
    public class TalkToUsPageChecker 
    {
        public TalkToUsPageChecker(TalkToUsPage view) 
        {
            View = view;
        }

        public TalkToUsPage View { get; }

        public TalkToUsPage EmailConfirmation()
        {
            View.ExplicitWait(View.Locate.ConfirmationTextLocator);
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
