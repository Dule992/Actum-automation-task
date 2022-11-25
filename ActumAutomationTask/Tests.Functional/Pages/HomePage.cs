using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Functional.Tests.Pages
{
    public class HomePage : BasePage
    {
        private readonly IWebDriver _webDriver;
        private IAlert _alert;

        public HomePage(IWebDriver webDriver) : base(webDriver)
        {
            _webDriver = webDriver;
        }

        #region Locators

        private By homeSingUpButton => By.Id("signin2");
        private By loginButton => By.Id("login2");
        private By usernameField => By.Id("sign-username");
        private By passwordField => By.Id("sign-password");
        private By formSignUpButton => By.XPath("//button[@onclick='register()']");

        #endregion

        #region WebElements

        private IWebElement HomeSignUpButton => _webDriver.FindElement(homeSingUpButton);
        private IWebElement LoginButton => _webDriver.FindElement(loginButton);
        private IWebElement UsernameField => _webDriver.FindElement(usernameField);
        private IWebElement PasswordField => _webDriver.FindElement(passwordField);
        private IWebElement FormSignUpButton => _webDriver.FindElement(formSignUpButton);

        #endregion

        public void ClickOnSingUpButon()
        {
            ClickOn(HomeSignUpButton, homeSingUpButton);
        }

        public void ClickOnLoginButon()
        {
            ClickOn(LoginButton, loginButton);
        }

        public void FillSignUpForm(string username, string password)       
        {
            TypeText(UsernameField, usernameField, username);
            TypeText(PasswordField, passwordField, password);
            ClickOn(FormSignUpButton, formSignUpButton);
        }

        public string GetAlertMessage()
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(20));
            wait.Until(driver => IsAlertShown(driver));

            string message = _alert.Text;
            _alert.Accept();
            return message;
        }

        bool IsAlertShown(IWebDriver driver)
        {
            try
            {
                _alert = driver.SwitchTo().Alert();
            }
            catch (NoAlertPresentException e)
            {
                return false;
            }
            return true;
        }
    }
}
