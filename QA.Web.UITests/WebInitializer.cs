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
            var browser = GetBrowser();

            string server = ConfigurationManager.AppSettings["server_configuration"];

            switch (browser)
            {
                case "CHROME":
                    Driver = SetChromeOptions(server);
                    break;

                case "IE":
                    Driver = SetIEOptions(server);
                    break;
                
                case "FIREFOX":
                    Driver = SetFirefoxOptions(server);
                    break;

                default:
                    throw new Exception("A Browser must be specified in App.config");
            }

          return SetDriverProperties(Driver);
        }

        private IWebDriver SetDriverProperties(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            return driver;
        }

        private IWebDriver SetChromeOptions(string server)
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

            return CreateDriver(chromeOptions);
        }

        private IWebDriver CreateDriver(DriverOptions options)
        {
            string server = ConfigurationManager.AppSettings["server_configuration"];
            var browser = GetBrowser();
            var url = "";

            if (server == "LOCAL")
            {
                url = string.Format("http://" + ConfigurationManager.AppSettings["local_server"] + "/wd/hub");
                switch (browser)
                {
                    case "CHROME":
                        Driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), (ChromeOptions) options, TimeSpan.FromSeconds(90));
                        break;

                    case "IE":
                        Driver = new InternetExplorerDriver(InternetExplorerDriverService.CreateDefaultService(), (InternetExplorerOptions) options, TimeSpan.FromSeconds(90));
                        break;

                    case "FIREFOX":
                        Driver = new FirefoxDriver(FirefoxDriverService.CreateDefaultService(), (FirefoxOptions) options, TimeSpan.FromSeconds(90));
                        break;

                    default:
                        throw new Exception("A Browser must be specified in App.config");
                }
            }

            else
            {
                //Create Remote WebDriver
                string bsUsername = Environment.GetEnvironmentVariable("BROWSERSTACK_USERNAME");
                string bsAccessKey = Environment.GetEnvironmentVariable("BROWSERSTACK_ACCESS_KEY");
                var browserstackUsername = (string.IsNullOrEmpty(bsUsername)) ? ConfigurationManager.AppSettings["browserstack_user"] : bsUsername;
                var browserstackAccessKey = (string.IsNullOrEmpty(bsAccessKey)) ? ConfigurationManager.AppSettings["browserstack_key"] : bsAccessKey;
              
                    url = string.Format(
                                        "https://{0}:{1}@hub-cloud.browserstack.com/wd/hub",
                                           browserstackUsername,
                                           browserstackAccessKey);
                Driver = new RemoteWebDriver(new Uri(url), options.ToCapabilities());
            
            }
            return Driver;
        }

        private IWebDriver SetIEOptions(string server)
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

            return CreateDriver(options);
        }

        private IWebDriver SetFirefoxOptions(string server)
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
       
            return CreateDriver(firefoxProfile);
        }

        private string GetBrowser()
        {
            var browser = Environment.GetEnvironmentVariable("BROWSER");

            if (string.IsNullOrEmpty(browser))
            {
                browser = ConfigurationManager.AppSettings["browser"];
            }
            return browser;

        }

        private string GetFirefoxBinaryPath()
        {
            var path = "C:\\Program Files\\Mozilla Firefox\\firefox.exe"; 
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