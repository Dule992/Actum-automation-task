using FluentAssertions;
using TechTalk.SpecFlow;
using Tests.Functional.Drivers;
using Tests.Functional.Pages;

namespace Tests.Functional.StepDefinitions
{
    [Binding]
    public class SharedSteps : TestBase
    {
        private readonly HomePage _homePage;
        public SharedSteps(BrowserDriver driver)
        {
            _homePage = new HomePage(driver.Current);
        }

        [Given(@"User opened the home page")]
        public void UserOpenedTheHomePage()
        {
            _homePage.GoToPage(HomePageUrl);
        }

        [Given(@"Validation message (.*) is presented")]
        [When(@"Validation message (.*) is presented")]
        [Then(@"Validation message (.*) is presented")]
        public void ValidationMessageThatIsPresented(string expectedMessage)
        {
            _homePage.WaitElement();

            string actualMessage = _homePage.GetAlertMessage();

            actualMessage.Should().BeEquivalentTo(expectedMessage);
        }
    }
}
