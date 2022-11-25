using Bogus;
using FluentAssertions;
using Functional.Tests.Drivers;
using Functional.Tests.Pages;
using TechTalk.SpecFlow;
using Tests.Functional.Models;

namespace Functional.Tests.StepDefinitions
{
    [Binding]
    public class SignUpSteps : TestBase
    {
        private readonly HomePage _homePage;
        private readonly LoginPage _loginPage;

        private string _username;
        private string _password;

        public SignUpSteps(BrowserDriver driver)
        {
            _homePage = new HomePage(driver.Current);
            _loginPage = new LoginPage(driver.Current);
        }

        [Given(@"User opened the home page")]
        public void UserOpenedTheHomePage()
        {
            _homePage.GoToPage(HomePageUrl);
        }

        [When(@"User filled the sign up form with new username and password")]
        public void UserFilledTheSignUpFormWithNewUsernameAndPassword()
        {
            var userData = CreateUserData();
            _homePage.ClickOnSingUpButon();
            _homePage.FillSignUpForm(userData.userName, userData.password);
        }

        [When(@"User filled the sign up form with existing username and password")]
        public void UserFilledTheSignUpFormWithExisitingUsernameAndPassword()
        {
            _homePage.ClickOnSingUpButon();
            _homePage.FillSignUpForm("test", "test");
        }

        [When(@"User filled the sign up form with missing (.*) and (.*)")]
        public void UserFilledTheSignUpFormWithMissingTestAnd(string username, string password)
        {
            _homePage.ClickOnSingUpButon();
            _homePage.FillSignUpForm(username, password);
        }

        [Then(@"Validation message (.*) is presented")]
        public void ValidationMessageThatIsPresented(string expectedMessage)
        {
            string actualMessage = _homePage.GetAlertMessage();

            actualMessage.Should().BeEquivalentTo(expectedMessage);
        }

        [Then(@"Label with username is shown in menu bar")]
        public void LabelWithUsernameIsShownInMenuBar()
        {
            _homePage.ClickOnLoginButon();

            _loginPage.FillSignUpForm(_username, _password);

            string actualUserName = _loginPage.VerifyNameOfUser();

            actualUserName.Should().BeEquivalentTo("Welcome " + _username);
        }

        #region Methods

        private Data CreateUserData()
        {
            var faker = new Faker();
            _username = "test_" + faker.Random.Number(0,10000);
            _password = faker.Random.AlphaNumeric(5);

            var userData = new Data()
            {
                userName = _username,
                password = _password
            };

            return userData;
        }

        #endregion
    }
}