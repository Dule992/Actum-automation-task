using Newtonsoft.Json;
using RestSharp;
using Tests.API.Models;

namespace Tests.API.Helpers
{
    public static class RestHelper
    {
        //Request Authorization
        public static RestResponse CreateToken(this RestClient restClient)
        {
            var request = new RestRequest(restClient.Options.BaseUrl + "auth", Method.Post);

            request.AddHeader("Content-Type", "application/json");

            var dataAuth = new TokenModel()
            {
                Username = "admin",
                Password = "password123"
            };

            var body = JsonConvert.SerializeObject(dataAuth);

            request.AddParameter("application/json", body, ParameterType.RequestBody);
           
            return restClient.Post(request);
        }

        #region Booking

        public static RestResponse GetBookingIds(this RestClient restClient)
        {
            var request = new RestRequest(restClient.Options.BaseUrl + "booking", Method.Get);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");

            return restClient.Execute(request);
        }

        public static RestResponse GetBookingId(this RestClient restClient, string bookingId)
        {
            var request = new RestRequest(restClient.Options.BaseUrl + $"booking/{bookingId}", Method.Get);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");

            return restClient.Execute(request);
        }

        public static RestResponse CreateBooking(this RestClient restClient, BookingModel body)
        {
            var request = new RestRequest(restClient.Options.BaseUrl + "booking", Method.Post);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            return restClient.Execute(request);
        }

        public static RestResponse UpdateBooking(this RestClient restClient, BookingModel body, string bookingId, string tokenValue)
        {
            var request = new RestRequest(restClient.Options.BaseUrl + $"booking/{bookingId}", Method.Put);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", $"token={tokenValue}");
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            return restClient.Execute(request);
        }

        public static RestResponse DeleteBooking(this RestClient restClient, string bookingId, string tokenValue)
        {
            var request = new RestRequest(restClient.Options.BaseUrl + $"booking/{bookingId}", Method.Delete);

            request.AddHeader("Accept", "application/json");
            request.AddHeader("Cookie", $"token={tokenValue}");

            return restClient.Execute(request);
        }

        #endregion
    }
}
