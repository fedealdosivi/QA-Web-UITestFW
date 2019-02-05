using System.Collections.Generic;
using NUnit.Framework;

namespace QA.Web.UITests.TestsData
{
    public class InputData
    {
        public static IEnumerable<TestCaseData> FormData()
        {
            yield return new TestCaseData("Celeste", "csenoseain@makingsense.com", "Hello!!!");
            yield return new TestCaseData("Betiana", "bcastro@makingsense.com" , "Running test");
        }
    }
}
