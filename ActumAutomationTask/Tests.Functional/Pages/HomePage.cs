using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Tests.Functional.Pages
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
        private By itemPicture(string itemInList) => By.XPath($"//div[@class='col-lg-4 col-md-6 mb-4'][{itemInList}]");
        private By listOfItems => By.XPath("//div[@class='card-block']//h4[@class='card-title']");
        
        #endregion

        #region WebElements

        private IWebElement HomeSignUpButton => _webDriver.FindElement(homeSingUpButton);
        private IWebElement LoginButton => _webDriver.FindElement(loginButton);
        private IWebElement UsernameField => _webDriver.FindElement(usernameField);
        private IWebElement PasswordField => _webDriver.FindElement(passwordField);
        private IWebElement FormSignUpButton => _webDriver.FindElement(formSignUpButton);
        private IWebElement ItemPicture(string itemInList) => _webDriver.FindElement(itemPicture(itemInList));
        private IList<IWebElement> ListOfItems => _webDriver.FindElements(listOfItems);

        #endregion

        #region Methods
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
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        public void PickItem(string iteminList)
        {
            WaitElement();
            ClickOn(ItemPicture(iteminList), itemPicture(iteminList));
        }

        public List<string> GetListOfItems()
        {
            var list = new List<string>();

            foreach (var item in ListOfItems)
            {
                list.Add(item.Text);
            }

            return list;
        }

        #endregion
    }
}
