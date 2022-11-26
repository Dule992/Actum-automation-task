using FluentAssertions;
using TechTalk.SpecFlow;
using Tests.Functional.Drivers;
using Tests.Functional.Pages;

namespace Tests.Functional.StepDefinitions
{
    [Binding]
    public class CategoriesSteps : TestBase
    {
        private readonly HomePage _homePage;
        private List<string> _listOfItems;

        public CategoriesSteps(BrowserDriver driver)
        {
            _homePage = new HomePage(driver.Current);
        }

        [When(@"User click on the (.*) filter")]
        public void UserClickOnThePhonesFilter(string categoryType)
        {
            _homePage.WaitElement();
            _homePage.ClickOnCategoriesFilter(categoryType);

            Thread.Sleep(5000);
            _homePage.WaitElement();
            _listOfItems = _homePage.GetListOfItems();
        }

        [Then(@"User should see (.*) items in product store")]
        public void UserShouldSeeItemsInProductStore(int numberOfItems)
        {
            _listOfItems.Count().Should().Be(numberOfItems);
        }
    }
}
