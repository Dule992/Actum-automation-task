using OpenQA.Selenium;

namespace Functional.Tests.Pages
{
    public class LoginPage : BasePage
    {
        private readonly IWebDriver _webDriver;

        public LoginPage(IWebDriver webDriver) : base(webDriver)
        {
            _webDriver = webDriver;
        }

        #region Locators

        private By usernameField => By.Id("loginusername");
        private By passwordField => By.Id("loginpassword");
        private By loginButton => By.XPath("//button[@onclick='logIn()']");
        private By nameOfUserLabel => By.Id("nameofuser");

        #endregion

        #region WebElements

        private IWebElement UsernameField => _webDriver.FindElement(usernameField);
        private IWebElement PasswordField => _webDriver.FindElement(passwordField);
        private IWebElement LoginButton => _webDriver.FindElement(loginButton);
        private IWebElement NameOfUserLabel => _webDriver.FindElement(nameOfUserLabel);

        #endregion

        public void FillSignUpForm(string username, string password)
        {
            TypeText(UsernameField, usernameField, username);
            TypeText(PasswordField, passwordField, password);
            ClickOn(LoginButton, loginButton);
        }

        public string VerifyNameOfUser()
        {
            return GetText(NameOfUserLabel, nameOfUserLabel);
        }
    }
}
