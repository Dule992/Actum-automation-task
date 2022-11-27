using Bogus;
using FluentAssertions;
using RestSharp;
using TechTalk.SpecFlow;
using Tests.API.Helpers;

namespace Tests.API.StepDefinitions
{
    [Binding]
    public class BookingSteps : TestBase
    {
        private RestResponse _response;

        public BookingSteps(): base() { }

        [Given(@"Request has authorized")]
        public void RequestHasAuthorized()
        {
            var response = RestClient.CreateToken();
            string token = response.Content.ToString();
        }

        [When(@"Request is sent to create a booking")]
        public void RequestIsSentToCreateABooking()
        {
            var bookingData = DataHelper.CreateBookingData();

            _response = RestClient.CreateBooking(bookingData);
        }

        [Then(@"Response should be (.*) and Success")]
        public void ResponseShouldBeAndSuccess(int statusCode)
        {
            Convert.ToInt32(_response.StatusCode).Should().Be(statusCode);
            var responseMessage = _response.Content.ToString();


        }

        [Then(@"Booking should be stored")]
        public void BookingShouldBeStored()
        {
            
        }
    }
}