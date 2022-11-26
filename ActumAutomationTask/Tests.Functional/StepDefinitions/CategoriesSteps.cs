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
        private readonly CategoriesPage _categoriesPage;
        private List<string> _listOfItems;

        public CategoriesSteps(BrowserDriver driver)
        {
            _homePage = new HomePage(driver.Current);
            _categoriesPage = new CategoriesPage(driver.Current);
        }

        [When(@"User click on the (.*) filter")]
        public void UserClickOnThePhonesFilter(string filterType)
        {
            _categoriesPage.WaitElement();
            _categoriesPage.ClickOnCategoriesFilter(filterType);

            _homePage.WaitElement();
            Thread.Sleep(5000);
            _listOfItems = _homePage.GetListOfItems();
           
            if (filterType.Equals("Laptops"))
            {
                _categoriesPage.WaitElement();
                _categoriesPage.ClickOnNextPage();

                _categoriesPage.WaitElement();
                Thread.Sleep(5000);
                var nextPageList = _homePage.GetListOfItems();
                
                foreach (var item in nextPageList)
                {
                    _listOfItems.Add(item);
                }
            }
        }

        [Then(@"User should see (.*) items in product store")]
        public void UserShouldSeeItemsInProductStore(int numberOfItems)
        {
            _listOfItems.Count().Should().Be(numberOfItems);
        }
    }
}
