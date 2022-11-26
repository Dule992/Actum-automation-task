using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace Tests.Functional.Drivers
{
    public class BrowserDriver : IDisposable
    {
        private readonly Lazy<IWebDriver> _webDriver;
        private readonly ScenarioContext _scenarioContext;

        private bool _disposed;

        public BrowserDriver(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _webDriver = new Lazy<IWebDriver>(CreateWebDriver);
        }

        public IWebDriver Current => _webDriver.Value;

        [BeforeScenario]
        private IWebDriver CreateWebDriver()
        {
            var service = ChromeDriverService.CreateDefaultService();

            var chromeOptions = new ChromeOptions();

            if (_scenarioContext.ScenarioInfo.Tags.Contains("headlessMode"))
            {
                chromeOptions.AddArguments("headless");
            }

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
