using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using Tests.API.Models;

namespace Tests.API.Helpers
{
    public static class RestHelper
    {
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

        public static RestResponse CreateBooking(this RestClient restClient, string body)
        {
            var request = new RestRequest(restClient.Options.BaseUrl + "booking", Method.Post);

            request.AddHeader("Content-Type", "application/json");

            request.AddParameter("application/json", body, ParameterType.RequestBody);

            return restClient.Post(request);
        }
    }
}
