using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Tests.Functional.Drivers;
using Tests.Functional.Pages;

namespace Tests.Functional.StepDefinitions
{
    [Binding]
    public class CommonSteps : TestBase
    {
        private readonly HomePage _homePage;
        public CommonSteps(BrowserDriver driver)
        {
            _homePage = new HomePage(driver.Current);
        }

        [Given(@"User opened the home page")]
        public void UserOpenedTheHomePage()
        {
            _homePage.GoToPage(HomePageUrl);
        }

        [Then(@"Validation message (.*) is presented")]
        public void ValidationMessageThatIsPresented(string expectedMessage)
        {
            _homePage.WaitElement();

            string actualMessage = _homePage.GetAlertMessage();

            actualMessage.Should().BeEquivalentTo(expectedMessage);
        }
    }
}
