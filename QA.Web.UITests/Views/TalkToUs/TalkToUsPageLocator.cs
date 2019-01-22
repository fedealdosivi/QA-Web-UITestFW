using OpenQA.Selenium;
using QA.Web.UITests.Views.Common;
using SeleniumExtras.PageObjects;

namespace QA.Web.UITests.Views.TalkToUs
{
    public class TalkToUsPageLocator : BasicViewLocator
    {
        public TalkToUsPageLocator(WebUser webUser) : base(webUser) { }

        [FindsBy(How = How.CssSelector, Using = "#lets-connect a")]
        public IWebElement LetsConnect { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#talk-to-us_new-projects input#input1")]
        public IWebElement NameField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#talk-to-us_new-projects input#input2")]
        public IWebElement EmailField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#talk-to-us_new-projects textarea#input3")]
        public IWebElement MessageField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#talk-to-us_new-projects #button_form_talk_to_us")]
        public IWebElement SendButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.modal--content--success h2")]
        public IWebElement ConfirmationText { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#talk-to-us_new-projects label[data-text='Name:']")]
        public IWebElement ErrorNameField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#talk-to-us_new-projects label[data-text='Email:']")]
        public IWebElement ErrorEmailField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#talk-to-us_new-projects label[data-text='Message:']")]
        public IWebElement ErrorMessageField { get; set; }
    }
}
