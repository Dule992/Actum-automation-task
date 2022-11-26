using OpenQA.Selenium;
using Tests.Functional.Utilities;

namespace Tests.Functional.Pages
{
    public class CartPage : BasePage
    {
        private readonly IWebDriver _webDriver;

        public CartPage(IWebDriver webDriver) : base(webDriver)
        {
            _webDriver = webDriver;
        }

        #region Locators

        private By itemInCart => By.XPath("//tr[@class='success'][1]//td[2]");
        private By placeOrderButton => By.XPath("//button[@class='btn btn-success']");
        private By nameField => By.Id("name");
        private By countryField => By.Id("country");
        private By cityField => By.Id("city");
        private By creditCardField => By.Id("card");
        private By monthField => By.Id("month");
        private By yearField => By.Id("year");
        private By purchaseButton => By.XPath("//button[@onclick='purchaseOrder()']");
        private By receiptMessage => By.XPath("//h2[text()='Thank you for your purchase!']");
        private By okButton => By.XPath("//button[@class='confirm btn btn-lg btn-primary']");

        #endregion

        #region WebElements

        private IWebElement ItemInCart => _webDriver.FindElement(itemInCart);
        private IWebElement PlaceOrderButton => _webDriver.FindElement(placeOrderButton);
        private IWebElement NameField => _webDriver.FindElement(nameField);
        private IWebElement CountryField => _webDriver.FindElement(countryField);
        private IWebElement CityField => _webDriver.FindElement(cityField);
        private IWebElement CreditCardField => _webDriver.FindElement(creditCardField);
        private IWebElement MonthField => _webDriver.FindElement(monthField);
        private IWebElement YearField => _webDriver.FindElement(yearField);
        private IWebElement PurchaseButton => _webDriver.FindElement(purchaseButton);
        private IWebElement ReceiptMessage => _webDriver.FindElement(receiptMessage);
        private IWebElement OkButton => _webDriver.FindElement(okButton);

        #endregion

        #region Methods

        public void ClickOnPlaceOrderButon()
        {
            ClickOn(PlaceOrderButton, placeOrderButton);
        }

        public void ClickOnPurchaseButon()
        {
            ClickOn(PurchaseButton, purchaseButton);
        }

        public void ClickOnOkButon()
        {
            ClickOn(OkButton, okButton);
        }

        public string GetItemTextFromTheCart()
        {
            return GetText(ItemInCart, itemInCart);
        }

        public void FillPlaceOrderForm()
        {
            var userDetails = Helpers.CreateUserDetails();

            TypeText(NameField, nameField, userDetails.Name);
            TypeText(CountryField, countryField, userDetails.Country);
            TypeText(CityField, cityField, userDetails.City);
            TypeText(CreditCardField, creditCardField, userDetails.CreditCard);
            TypeText(MonthField, monthField, userDetails.Month);
            TypeText(YearField, yearField, userDetails.Year);
        }

        public string GetReceiptMessage()
        {
            return GetText(ReceiptMessage, receiptMessage);
        }

        #endregion
    }
}
