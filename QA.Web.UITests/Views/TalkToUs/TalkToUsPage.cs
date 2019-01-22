using QA.Web.UITests.Views.Common;
using SeleniumExtras.PageObjects;

namespace QA.Web.UITests.Views.TalkToUs
{
    public class TalkToUsPage : BasicView
    {
        public TalkToUsPage(WebUser webUser) : base(webUser)
        {
            Locate = new TalkToUsPageLocator(webUser);
            PageFactory.InitElements(Web, Locate);
        }

        public TalkToUsPageLocator Locate { get; }


        public TalkToUsPage ClickOnLetsConnect()
        {
            Locate.LetsConnect.Click();
            return this;
        }

        public TalkToUsPage EnterName(string text = "QA Test")
        {
            Locate.NameField.SendKeys(text);
            return this;
        }

        public TalkToUsPage EnterEmail(string email = "csenoseain@makingsense.com")
        {
            Locate.EmailField.SendKeys(email);
            return this;
        }

        public TalkToUsPage EnterMessage(string message = "Running test case on Making Sense Page")
        {
            Locate.MessageField.SendKeys(message);
            return this;
        }

        public TalkToUsPage ClickOnSend()
        {
            Locate.SendButton.Click();
            return this;
        }

        public TalkToUsPageChecker Verify()
        {
            return new TalkToUsPageChecker(WebUser, this);
        }

     

    }
}
