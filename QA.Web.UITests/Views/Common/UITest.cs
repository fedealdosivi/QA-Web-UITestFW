using System;
using System.ComponentModel;
using System.Diagnostics;
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
            {
                Web.Web.Close();
                Web.Web.Quit();
                Web.Web.Dispose();
                KillCurrentDriver();
            }
        }

        public void KillCurrentDriver()
        {
            switch (Web.GetSelectedBrowser())
            {
                case "CHROME":
                    KillDriver("chromedriver");
                    break;
                case "IE":
                    KillDriver("IEDriverServer");
                    break;
                case "FIREFOX":
                    KillDriver("geckodriver");
                    break;
            }
        }

        private void KillDriver(string processName)
        {
            Process[] driverProcesses = Process.GetProcessesByName(processName);

            if (driverProcesses != null)
            {
                foreach (var driverProcess in driverProcesses)
                {
                    try
                    {
                        driverProcess.Kill();
                        driverProcess.WaitForExit();
                    }
                    catch (Win32Exception)
                    {
                        if (driverProcess.HasExited)
                        {
                            break;
                        }
                        else
                        {
                            throw new Exception("Unable to kill WebDriver process");
                        }
                    }
                }
            }
        }
    }
}
