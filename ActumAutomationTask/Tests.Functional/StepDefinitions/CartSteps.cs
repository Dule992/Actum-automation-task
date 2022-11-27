using FluentAssertions;
using TechTalk.SpecFlow;
using Tests.Functional.Drivers;
using Tests.Functional.Pages;

namespace Tests.Functional.StepDefinitions
{
    [Binding]
    public class CartSteps : TestBase
    {
        private readonly HomePage _homePage;
        private readonly CartPage _cartPage;
        private readonly ProductPage _productPage;
        private List<string> _listOfItems;

        public CartSteps(BrowserDriver driver)
        {
            _homePage = new HomePage(driver.Current);
            _cartPage = new CartPage(driver.Current);
            _productPage = new ProductPage(driver.Current);
        }

        [Given(@"User pick (.*) item and put item in a cart")]
        public void UserPickItemAndPutItemInACart(string numberOfItem)
        {
            _homePage.WaitElement();
            _listOfItems = _homePage.GetListOfItems();
            _homePage.WaitElement();
            _homePage.PickItem(numberOfItem);

            _productPage.WaitElement();
            _productPage.ClickOnAddToCartButon();
        }

        [Given(@"User opened the cart page")]
        [When(@"User opened the cart page")]
        [Then(@"User opened the cart page")]
        public void UserOpenedTheCartPage()
        {
            _productPage.GoToPage(CartPageUrl);
        }

        [Given(@"User see the item in cart")]
        [When(@"User see the item in cart")]
        [Then(@"User see the item in cart")]
        public void UserSeeTheItemInCart()
        {
            _cartPage.WaitElement();
            string itemInCart = _cartPage.GetItemTextFromTheCart();

            itemInCart.Should().BeEquivalentTo(_listOfItems[0].ToString());
        }

        [When(@"User filled the place order form with valid data")]
        public void UserFilledThePlaceOrderFormWithValidData()
        {
            _cartPage.WaitElement();
            _cartPage.ClickOnPlaceOrderButon();
            _cartPage.WaitElement();
            _cartPage.FillPlaceOrderForm();
            _cartPage.WaitElement();
            _cartPage.ClickOnPurchaseButon();
        }

        [Then(@"Receipt message (.*) is presented")]
        public void ReceiptMessageThankYouForYourPurchaseIsPresented(string expectedMessage)
        {
            _cartPage.WaitElement();

            string actualMessage = _cartPage.GetReceiptMessage();

            actualMessage.Should().BeEquivalentTo(expectedMessage);
        }
    }
}
