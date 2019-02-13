using QA.Web.UITests.Views.Common;

namespace QA.Web.UITests.Views.TalkToUs
{
    public class TalkToUsPage : BasicView
    {
        public TalkToUsPage(WebUser webUser) : base(webUser)
        {
            Locate = new TalkToUsPageLocator(webUser);
        }

        public TalkToUsPageLocator Locate { get; }

        public TalkToUsPage ClickOnLetsConnect()
        {
            ExplicitWait(Locate.LetsConnectLocator);
            Locate.LetsConnect.Click();
            return this;
        }

        public TalkToUsPage EnterName(string text = "QA Test")
        {
            ExplicitWait(Locate.NameFieldLocator);
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
            ExplicitWait(Locate.SendButtonLocator);
            Locate.SendButton.Click();
            return this;
        }

        public TalkToUsPageChecker Verify()
        {
            return new TalkToUsPageChecker(this);
        }

    }
}
