using OpenQA.Selenium;

namespace Tests.Functional.Pages
{
    public class ProductPage : BasePage
    {
        private readonly IWebDriver _webDriver;

        public ProductPage(IWebDriver webDriver) : base(webDriver)
        {
            _webDriver = webDriver;
        }

        #region Locators

        private By cartMenuButton => By.Id("cartur");
        private By addToCartButton => By.XPath("//a[@class='btn btn-success btn-lg']");

        #endregion

        #region WebElements

        private IWebElement CartMenuButton => _webDriver.FindElement(cartMenuButton);
        private IWebElement AddToCartButton => _webDriver.FindElement(addToCartButton);

        #endregion

        #region Methods
        public void ClickOnCartButon()
        {
            ClickOn(CartMenuButton, cartMenuButton);
        }
        public void ClickOnAddToCartButon()
        {
            ClickOn(AddToCartButton, addToCartButton);
        }
        
        #endregion
    }
}
