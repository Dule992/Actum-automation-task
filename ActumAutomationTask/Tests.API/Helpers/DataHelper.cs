using Bogus;
using Newtonsoft.Json;
using Tests.API.Models;

namespace Tests.API.Helpers
{
    public class DataHelper
    {
        public static string CreateBookingData()
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

            var body = JsonConvert.SerializeObject(bookingData);

            return body;
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
    }
}
