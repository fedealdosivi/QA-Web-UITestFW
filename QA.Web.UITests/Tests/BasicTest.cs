using NUnit.Framework;
using QA.Web.UITests.Views.Common;

namespace QA.Web.UITests.Tests
{
    public class BasicTest : UITest
    {
        [Test]
        public void TalkToUsTest()
        {
            Web
                .VisitHomePage()
                .GotoTalkToUs()
                .ClickOnLetsConnect()
                .EnterName()
                .EnterEmail()
                .EnterMessage()
                .ClickOnSend()
                .Verify().EmailConfirmation();
        }

        [Test]
        public void RequiredFieldsInTalkToUsTest()
        {
            Web
                .VisitHomePage()
                .GotoTalkToUs()
                .ClickOnLetsConnect()
                .ClickOnSend()
                .Verify().RequiredFields();
        }

        [Test]
        public void NavigationBarIsPresentTest()
        {
            Web
                .VisitHomePage()
                .Verify().ElementsArePresentinMenu();
        }

        [Test, Sequential]
        public void TalkToUsWithInputDataTest([ValuesAttribute("InputData")] string names,
            [ValuesAttribute("InputData")] string emails,
            [ValuesAttribute("InputData")] string messages)
        {
            Web
                .VisitHomePage()
                .GotoTalkToUs()
                .ClickOnLetsConnect()
                .EnterName(names)
                .EnterEmail(emails)
                .EnterMessage(messages)
                .ClickOnSend()
                .Verify().EmailConfirmation();
        }
    }
}
