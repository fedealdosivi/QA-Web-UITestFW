using System;
using System.Configuration;
using Microsoft.Win32;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace QA.Web.UITests
{
    public class WebInitializer
    {
        public static RemoteWebDriver Driver { get; private set; }

        public RemoteWebDriver Start()
        {
            string browser = ConfigurationManager.AppSettings["browser"];
            switch (browser)
            {
                case "CHROME":
                    Driver = SetChromeDriver();
                    break;

                case "IE":
                    Driver = SetIEDriver();
                    break;
                
                case "FIREFOX":
                    Driver = SetFirefoxDriver();
                    break;

                default:
                    throw new Exception("A driver must be specified in App.config");
            }
            return Driver;
        }

        private RemoteWebDriver SetChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("disable-infobars");
            Driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromSeconds(90));
            return SetDriverProperties(Driver);
        }

        private RemoteWebDriver SetDriverProperties(RemoteWebDriver driver)
        {
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            return Driver;
        }

        private RemoteWebDriver SetIEDriver()
        {
            EnableIEProtectedMode();
            InternetExplorerOptions options = new InternetExplorerOptions
            {
                IgnoreZoomLevel = true,
            };

            Driver = new InternetExplorerDriver(InternetExplorerDriverService.CreateDefaultService(), options, TimeSpan.FromSeconds(90));
            return SetDriverProperties(Driver);
        }

        private RemoteWebDriver SetFirefoxDriver()
        {
            FirefoxOptions options = new FirefoxOptions
            {
               BrowserExecutableLocation = GetFirefoxBinaryPath()
            };
            Driver = new FirefoxDriver(FirefoxDriverService.CreateDefaultService(), options, TimeSpan.FromSeconds(60));
            return SetDriverProperties(Driver);
        }

        private string GetFirefoxBinaryPath()
        {
            var path = "C:\\Program Files (x86)\\Mozilla Firefox\\firefox.exe"; 
            return path;
        }

        private void EnableIEProtectedMode()
        {
            for (int i = 0; i < 5; i++)
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings\Zones\" + i.ToString(), true);
                if (key != null)
                {
                    key.SetValue("2500", "0", RegistryValueKind.DWord);
                    key.Close();
                }
            }
        }
    }
}
