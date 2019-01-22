using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace QA.Web.UITests.Views.Common
{
    public class BasicViewLocator
    {
        protected BasicViewLocator(WebUser webUser)
        {
            WebUser = webUser;
        }

        public WebUser WebUser { get; }

        public IWebDriver Web => WebUser.Web;
    }
}
