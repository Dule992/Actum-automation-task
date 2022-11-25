using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Tests.Functional.Pages
{
    public class BasePage
    {
        private readonly IWebDriver _webDriver;

        public BasePage(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void GoToPage(string url)
        {
            _webDriver.Navigate().GoToUrl(url);
        }

        public void ClickOn(IWebElement webElement, By locator)
        {
            bool isClickable = false;

            while (isClickable == false)
            {
                isClickable = ElementIsClickable(locator);
            }

            webElement.Click();
        }

        public void TypeText(IWebElement webElement, By locator, string text)
        {
            bool isClickable = false;

            while (isClickable == false)
            {
                isClickable = ElementIsClickable(locator);
            }

            webElement.SendKeys(text);
        }

        public string GetText(IWebElement webElement, By locator)
        {
            bool isVisible = false;

            while (isVisible == false)
            {
                isVisible = ElementIsVisible(locator);
            }

            return webElement.Text;
        }

        public void WaitElement()
        {
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public bool ElementIsClickable(By locator)
        {
            var isEnabled = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(5)).Until(element => element.FindElement(locator)).Enabled;
            return isEnabled;
        }

        public bool ElementIsVisible(By locator)
        {
            var isDisplayed = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(5)).Until(element => element.FindElement(locator)).Displayed;
            return isDisplayed;
        }
    }
}
