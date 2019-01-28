using OpenQA.Selenium;
using QA.Web.UITests.Views.Common;

namespace QA.Web.UITests.Views.TalkToUs
{
    public class TalkToUsPageLocator 
    {
        IWebDriver Web;

        public TalkToUsPageLocator(WebUser webUser)
        {
            Web = webUser.Web;
        }

        public IWebElement LetsConnect => Web.FindElement(By.CssSelector("#lets-connect a"));

        public IWebElement NameField => Web.FindElement(By.CssSelector("#talk-to-us_new-projects input#input1"));

        public IWebElement EmailField => Web.FindElement(By.CssSelector("#talk-to-us_new-projects input#input2"));

        public IWebElement MessageField => Web.FindElement(By.CssSelector("#talk-to-us_new-projects textarea#input3"));

        public IWebElement SendButton => Web.FindElement(By.CssSelector("#talk-to-us_new-projects #button_form_talk_to_us"));

        public IWebElement ConfirmationText => Web.FindElement(By.CssSelector("div.modal--content--success h2"));

        public IWebElement ErrorNameField => Web.FindElement(By.CssSelector("#talk-to-us_new-projects label[data-text='Name:']"));

        public IWebElement ErrorEmailField => Web.FindElement(By.CssSelector("#talk-to-us_new-projects label[data-text='Email:']"));

        public IWebElement ErrorMessageField => Web.FindElement(By.CssSelector("#talk-to-us_new-projects label[data-text='Message:']"));

    }
}
