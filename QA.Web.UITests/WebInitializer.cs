using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using QA.Web.UITests.Utils.Browsers;

namespace QA.Web.UITests
{
    public class WebInitializer
    {
        public static IWebDriver Driver { get; private set; }
        public IWebDriver Start(Browser browser)
        {
            switch (browser)
            {
                case Browser.CHROME:
                    Driver = new ChromeDriver(ChromeDriverService.CreateDefaultService());
                    Driver.Manage().Window.Maximize();
                    Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
                    break;

                case Browser.IE:
                    Driver = new ChromeDriver("C:");
                    break;
                //     break;
                case Browser.FIREFOX:
                    Driver = new ChromeDriver("C:");
                    break;
                default:
                    throw new Exception("A driver must be specified in App.config");
            }
            return Driver;
        }

        private IWebDriver SetChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("disable-infobars");
            Driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), options, TimeSpan.FromSeconds(90));
            return SetDriverProperties(Driver);
        }

        private IWebDriver SetDriverProperties(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
