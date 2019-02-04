using System;
using System.Collections.Specialized;
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

            //Create Remote WebDriver
            string browserstackUsername = ConfigurationManager.AppSettings["browserstack_user"];
            string browserstackAccessKey = ConfigurationManager.AppSettings["browserstack_key"];
            string server = ConfigurationManager.AppSettings["server_configuration"];
            
            var browserstackUrl = "";

            switch (server)
            {
                case "BROWSERSTACK":
                      browserstackUrl = string.Format(
                                        "https://{0}:{1}@hub-cloud.browserstack.com/wd/hub",
                                           browserstackUsername,
                                           browserstackAccessKey);
                      break;
                case "LOCAL":
                     browserstackUrl = string.Format("http://" + ConfigurationManager.AppSettings["local_server"] + "/wd/hub");
                     break;
                default: 
                    throw new Exception("A server Configuration driver must be specified in App.config");
            }
          
            Driver = new RemoteWebDriver(new Uri(browserstackUrl), options.ToCapabilities());
            
            return SetDriverProperties(Driver);
        }

        private IWebDriver SetDriverProperties(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            return driver;
        }

        private DriverOptions SetChromeOptions()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("disable-infobars");
            chromeOptions.AddArgument("--disable-plugins");
            chromeOptions.AcceptInsecureCertificates = true;
 
            NameValueCollection caps = ConfigurationManager.GetSection("capabilities/" + "chrome") as NameValueCollection;
            
            foreach (string key in caps.AllKeys)
            {
                chromeOptions.AddAdditionalCapability(key, caps[key], true);
            }
         
            return chromeOptions;
        }

        private DriverOptions SetIEOptions()
        {
            EnableIEProtectedMode();
            InternetExplorerOptions options = new InternetExplorerOptions
            {
                IgnoreZoomLevel = true,
            };

            NameValueCollection caps = ConfigurationManager.GetSection("capabilities/" + "ie") as NameValueCollection;

            foreach (string key in caps.AllKeys)
            {
                options.AddAdditionalCapability(key, caps[key], true);
            }

            return options;
        }

        private DriverOptions SetFirefoxOptions()
        {
            var firefoxProfile = new FirefoxOptions
            {
               BrowserExecutableLocation = GetFirefoxBinaryPath()
            };

            firefoxProfile.SetPreference("plugin.state.flash", 0);
 
            NameValueCollection caps = ConfigurationManager.GetSection("capabilities/" + "firefox") as NameValueCollection;
            
            foreach (string key in caps.AllKeys)
            {
                firefoxProfile.AddAdditionalCapability(key, caps[key], true);
            }

            return firefoxProfile;
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