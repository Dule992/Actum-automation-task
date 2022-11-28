using FluentAssertions;
using Newtonsoft.Json;
using RestSharp;
using TechTalk.SpecFlow;
using Tests.API.Helpers;
using Tests.API.Models;

namespace Tests.API.StepDefinitions
{
    [Binding]
    public class BookingSteps : TestBase
    {
        private RestResponse _response;
        private RestResponse _checkBookingIsDeleted;
        private BookingModel _bookingData;
        private string _token;

        public BookingSteps() : base() { }

        [Given(@"Request body is prepared with valid data")]
        public void RequestBodyIsPreparedWithValidData()
        {
            _bookingData = DataHelper.CreateBookingData();
        }

        [Given(@"Request is sent to get a token")]
        public void RequestIsSentToGetAaToken()
        {
            var response = RestClient.CreateToken();
            _token = DataHelper.GetTokenValueFromResponse(response);
        }

        [Given(@"Request is sent to (.*) a booking")]
        [When(@"Request is sent to (.*) a booking")]
        public void RequestIsSentToCreateABooking(string requestMethod)
        {
            string bookingId;

            switch (requestMethod)
            {
                case "get":
                    var response = RestClient.CreateBooking(_bookingData);
                    bookingId = DataHelper.GetBookingIdFromCreateBookingResponse(response).ToString();
                    _response = RestClient.GetBookingId(bookingId);
                    break;
                case "create":
                    _response = RestClient.CreateBooking(_bookingData);
                    break;
                case "update":
                    bookingId = GetBookingId();
                    _bookingData.additionalneeds = "Test";
                    _response = RestClient.UpdateBooking(_bookingData, bookingId, _token);
                    break;
                case "delete":
                    bookingId = GetBookingId();
                    _response = RestClient.DeleteBooking(bookingId, _token);
                    _checkBookingIsDeleted = RestClient.GetBookingId(bookingId);
                    break;
            }
        }

        [Then(@"Response should be (.*) and (.*)")]
        public void ResponseShouldBeAndSuccess(int statusCode, string statusMessage)
        {
            Convert.ToInt32(_response.StatusCode).Should().Be(statusCode);
            _response.StatusCode.ToString().Should().Be(statusMessage);
        }

        [Then(@"Response data corresponds with (.*) data")]
        public void ResponseDataCorrespondsWithCreatedData(string requestType)
        {
            var responseMessage = _response.Content.ToString();
            var actualData = JsonConvert.DeserializeObject<BookingModel>(responseMessage);
            actualData.Should().BeEquivalentTo(_bookingData);
        }

        [Then(@"Response for checking deleted booking should be (.*) and (.*)")]
        public void ResponseForCheckingDeletedBookingShouldBeAndNotFound(int statusCode, string statusMessage)
        {
            Convert.ToInt32(_checkBookingIsDeleted.StatusCode).Should().Be(statusCode);
            _checkBookingIsDeleted.Content.Should().Be(statusMessage);
        }

        private string GetBookingId()
        {
            var bookingIds = RestClient.GetBookingIds();
            string bookingId = DataHelper.GetBookingIdFromGetBookingIdsResponse(bookingIds).ToString();
            return bookingId;
        }
    }
}