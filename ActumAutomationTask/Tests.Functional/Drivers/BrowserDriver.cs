using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Tests.Functional.Drivers
{
    public class BrowserDriver : IDisposable
    {
        private readonly Lazy<IWebDriver> _webDriver;
        private bool _disposed;

        public BrowserDriver()
        {
            _webDriver = new Lazy<IWebDriver>(CreateWebDriver);
        }

        public IWebDriver Current => _webDriver.Value;

        private IWebDriver CreateWebDriver()
        {
            var service = ChromeDriverService.CreateDefaultService();

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");

            var chromeDriver = new ChromeDriver(service, chromeOptions);

            chromeDriver.Manage().Window.Maximize();

            return chromeDriver;
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            if (_webDriver.IsValueCreated)
            {
                Current.Quit();
            }

            _disposed = true;
        }
    }
}
