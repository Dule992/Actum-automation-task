using FluentAssertions;
using TechTalk.SpecFlow;
using Tests.Functional.TestData;
using Tests.Functional.Drivers;
using Tests.Functional.Models;
using Tests.Functional.Pages;
using Tests.Functional.Utilities;

namespace Tests.Functional.StepDefinitions
{
    [Binding]
    public class LoginSteps : TestBase
    {
        private readonly HomePage _homePage;
        private readonly LoginPage _loginPage;
        private Data _testData;

        public LoginSteps(BrowserDriver driver)
        {
            _homePage = new HomePage(driver.Current);
            _loginPage = new LoginPage(driver.Current);
        }

        [When(@"User filled the login form with username and password")]
        public void UserFilledTheLoginFormWithUsernameAndPassword()
        {
            _testData = new Data()
            {
                userName = TestDataConstants.Username,
                password = TestDataConstants.Password
            };

            _homePage.WaitElement();
            _homePage.ClickOnLoginButon();
            _homePage.WaitElement();

            _loginPage.FillLoginForm(_testData.userName, _testData.password);
        }

        [When(@"User filled the login form with not existing username and password")]
        public void UserFilledTheLoginFormWithNotExistingUsernameAndPassword()
        {
            _testData = Helpers.CreateUserData();

            _homePage.WaitElement();
            _homePage.ClickOnLoginButon();
            _homePage.WaitElement();

            _loginPage.FillLoginForm(_testData.userName, _testData.password);
        }


        [Then(@"Label with username is shown in menu bar")]
        public void LabelWithUsernameIsShownInMenuBar()
        {
            Thread.Sleep(5000);
            string actualUserName = _loginPage.VerifyNameOfUser();

            actualUserName.Should().BeEquivalentTo("Welcome " + _testData.userName);
        }
    }
}
