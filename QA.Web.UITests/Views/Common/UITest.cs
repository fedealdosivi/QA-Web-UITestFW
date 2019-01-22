using NUnit.Framework;

namespace QA.Web.UITests.Views.Common
{
    public class UITest
    {
        public WebUser Web { get; private set; }

        [SetUp]
        public void StartBrowser()
        {
            Web = new WebUser();
        }

        [TearDown]
        public void TearDown()
        {
            if (Web != null)
                Web.Web.Quit();
        }
    }
}
