using Bogus;
using Newtonsoft.Json.Linq;
using RestSharp;
using Tests.API.Models;

namespace Tests.API.Helpers
{
    public class DataHelper
    {
        public static BookingModel CreateBookingData()
        {
            Faker faker = new Faker();
            
            var bookingData = new BookingModel()
            {
                firstname = faker.Name.FirstName(),
                lastname = faker.Name.LastName(),
                totalprice = (long)faker.Finance.Amount(0, 1000, 2),
                depositpaid = true,
                bookingdates = PrepareBookingDates(faker),
                additionalneeds = "Breakfast"
            };

            return bookingData;
        }

        public static BookingDatesModel PrepareBookingDates(Faker faker)
        {
            var bookingDates = new BookingDatesModel()
            {
                Checkin = faker.Date.Future(1).ToString("yyyy-MM-dd"),
                Checkout = faker.Date.Future(2).ToString("yyyy-MM-dd"),
            };

            return bookingDates;
        }
        public static string GetTokenValueFromResponse(RestResponse response)
        {
            var message = response.Content.ToString();
            var data = JObject.Parse(message);
            var token = data.Value<string>("token");
            return token;
        }

        public static int GetBookingIdFromGetBookingIdsResponse(RestResponse response)
        {
            var message = response.Content.ToString();
            var data = JArray.Parse(message);
            var bookingId = data.First.Value<int>("bookingid");
            return bookingId;
        }

        public static int GetBookingIdFromCreateBookingResponse(RestResponse response)
        {
            var message = response.Content.ToString();
            var data = JObject.Parse(message);
            var bookingId = data.Value<int>("bookingid");
            return bookingId;
        }
    }
}
