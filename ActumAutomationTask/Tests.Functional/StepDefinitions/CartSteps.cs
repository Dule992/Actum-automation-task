using TechTalk.SpecFlow;

namespace Tests.Functional.StepDefinitions
{
    [Binding]
    public class CartSteps : TestBase
    {
        [Given(@"User pick (.*) item")]
        public void UserPickItem(int numberOfItems)
        {
            
        }

        [Given(@"User put item in a cart")]
        public void UserPutItemInACart()
        {
            throw new PendingStepException();
        }

        [Given(@"User opened the cart page")]
        public void UserOpenedTheCartPage()
        {
            throw new PendingStepException();
        }

        [When(@"User filled the place order form with valid data")]
        public void UserFilledThePlaceOrderFormWithValidData()
        {
            throw new PendingStepException();
        }
    }
}
