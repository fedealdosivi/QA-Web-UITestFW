using NUnit.Framework;
using QA.Web.UITests.TestsData;
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
       
        [Test, TestCaseSource(typeof(InputData), "FormData")]
        public void TalkToUsWithInputDataTest(string name, string email, string message)
        {
            Web
                .VisitHomePage()
                .GotoTalkToUs()
                .ClickOnLetsConnect()
                .EnterName(name)
                .EnterEmail(email)
                .EnterMessage(message)
                .ClickOnSend()
                .Verify().EmailConfirmation();
        }
    }
}
