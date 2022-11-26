using OpenQA.Selenium;
namespace Tests.Functional.Pages
{
    public class CategoriesPage : BasePage
    {
        private readonly IWebDriver _webDriver;

        public CategoriesPage(IWebDriver webDriver) : base(webDriver)
        {
            _webDriver = webDriver;
        }

        #region Locators

        private By categoriesFilter(string filterType) => By.XPath($"//a[contains(text(),'{filterType}')]");
        private By nextPageButton => By.Id("next2");

        #endregion

        #region WebElements

        private IWebElement CategoriesFilter(string filterType) => _webDriver.FindElement(categoriesFilter(filterType));
        private IWebElement NextPageButton => _webDriver.FindElement(nextPageButton);

        #endregion

        #region Methods

        public void ClickOnCategoriesFilter(string filterType)
        {
            ClickOn(CategoriesFilter(filterType), categoriesFilter(filterType));
        }

        public void ClickOnNextPage()
        {
            ClickOn(NextPageButton, nextPageButton);
        }

        #endregion
    }
}
