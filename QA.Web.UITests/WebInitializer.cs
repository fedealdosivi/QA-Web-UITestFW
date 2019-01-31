using System;
using System.Configuration;
using Microsoft.Win32;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;

namespace QA.Web.UITests
{
    public class WebInitializer
    {
        public static IWebDriver Driver { get; private set; }

        public IWebDriver Start()
        {
            DriverOptions options = null;
            string browser = ConfigurationManager.AppSettings["browser"];
            switch (browser)
            {
                case "CHROME":
                    options = SetChromeOptions();
                    break;

                case "IE":
                    options = SetIEOptions();
                    break;
                
                case "FIREFOX":
                    options = SetFirefoxOptions();
                    break;

                default:
                    throw new Exception("A driver must be specified in App.config");
            }

            //Common capabilities  
             DesiredCapabilities capability = new DesiredCapabilities();
             capability.SetCapability("os", "Windows");
             capability.SetCapability("os_version", "10");
            /* capability.SetCapability("browser", "Firefox");
             capability.SetCapability("browser_version", "65.0 beta");*/
            /* capability.SetCapability("browser", "Chrome");
             capability.SetCapability("browser_version", "71.0");
             */
             capability.SetCapability("resolution", "1280x1024");
             capability.SetCapability("project", "QA_Web_UITests");
             capability.SetCapability("build", "Build 1.0");
             capability.SetCapability("name", "BasicTest");
             capability.SetCapability("browserstack.local", "false");
             capability.SetCapability("browserstack.selenium_version", "3.5.2");
             capability.SetCapability("browserstack.user", "sergiomarchetti1");
             capability.SetCapability("browserstack.key", "YmPqJpVnLiYJEeR4yxdR");


            string browserstackUrl = "http://hub-cloud.browserstack.com/wd/hub/";
            Driver = new RemoteWebDriver(new Uri(browserstackUrl), capability);
            Driver.Navigate().GoToUrl("http://makingsense.com");
            return Driver;
        }

        private DriverOptions SetChromeOptions()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("disable-infobars");
            chromeOptions.AddArgument("--disable-plugins");

          /*  chromeOptions.AcceptInsecureCertificates = true;
            chromeOptions.AddAdditionalCapability("browserstack.user", "sergiomarchetti1");
            chromeOptions.AddAdditionalCapability("browserstack.key", "YmPqJpVnLiYJEeR4yxdR");
            chromeOptions.AddAdditionalCapability("version", "70", true);
            chromeOptions.AddAdditionalCapability("platform", "Windows 10", true);*/

            //   options.AddAdditionalCapability("browserstack.key", "M4xekjhYuaFGxy4fEboz");
            // Driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), chromeOptions, TimeSpan.FromSeconds(90));
            return chromeOptions;//SetDriverProperties(Driver);
        }

        private RemoteWebDriver SetDriverProperties(RemoteWebDriver driver)
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            return driver;
        }

        private DriverOptions SetIEOptions()
        {
            EnableIEProtectedMode();
            InternetExplorerOptions options = new InternetExplorerOptions
            {
                IgnoreZoomLevel = true,
            };

            Driver = new InternetExplorerDriver(InternetExplorerDriverService.CreateDefaultService(), options, TimeSpan.FromSeconds(90));
            return options;// SetDriverProperties(Driver);
        }

        private DriverOptions SetFirefoxOptions()
        {
            FirefoxOptions firefoxProfile = new FirefoxOptions
            {
               BrowserExecutableLocation = GetFirefoxBinaryPath()
            };
            firefoxProfile.SetPreference("plugin.state.flash", 0);
            
            //new FirefoxDriver(FirefoxDriverService.CreateDefaultService(), firefoxProfile, TimeSpan.FromSeconds(60));
            return firefoxProfile;// SetDriverProperties(Driver);
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
