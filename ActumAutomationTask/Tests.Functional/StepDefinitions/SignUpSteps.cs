using TechTalk.SpecFlow;
using Tests.Functional.Drivers;
using Tests.Functional.Pages;
using Tests.Functional.TestData;
using Tests.Functional.Utilities;

namespace Tests.Functional.StepDefinitions
{
    [Binding]
    public class SignUpSteps : TestBase
    {
        private readonly HomePage _homePage;

        public SignUpSteps(BrowserDriver driver)
        {
            _homePage = new HomePage(driver.Current);
        }

        [When(@"User filled the sign up form with new username and password")]
        public void UserFilledTheSignUpFormWithNewUsernameAndPassword()
        {
            var userData = Helpers.CreateUserData();
            _homePage.WaitElement();
            _homePage.ClickOnSingUpButon();
            _homePage.WaitElement();
            _homePage.FillSignUpForm(userData.userName, userData.password);
        }

        [When(@"User filled the sign up form with existing username and password")]
        public void UserFilledTheSignUpFormWithExisitingUsernameAndPassword()
        {
            _homePage.WaitElement();
            _homePage.ClickOnSingUpButon();
            _homePage.WaitElement();
            _homePage.FillSignUpForm(TestDataConstants.Username, TestDataConstants.Password);
        }

        [When(@"User filled the sign up form with missing (.*) and (.*)")]
        public void UserFilledTheSignUpFormWithMissingTestAnd(string username, string password)
        {
            _homePage.WaitElement();
            _homePage.ClickOnSingUpButon();
            _homePage.WaitElement();
            _homePage.FillSignUpForm(username, password);
        }
    }
}