using OpenQA.Selenium;
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
            ExplicitWait(By.CssSelector("#lets-connect a"));
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
            ExplicitWait(By.CssSelector("#talk-to-us_new-projects #button_form_talk_to_us"));
            Locate.SendButton.Click();
            return this;
        }

        public TalkToUsPageChecker Verify()
        {
            return new TalkToUsPageChecker(WebUser, this);
        }

    }
}
