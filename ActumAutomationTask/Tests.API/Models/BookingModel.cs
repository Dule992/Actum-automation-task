using Newtonsoft.Json;

namespace Tests.API.Models
{
    public class BookingModel
    {
        [JsonProperty("firstname")]
        public string firstname { get; set; }

        [JsonProperty("lastname")]
        public string lastname { get; set; }

        [JsonProperty("totalprice")]
        public long totalprice { get; set; }

        [JsonProperty("depositpaid")]
        public bool depositpaid { get; set; }

        [JsonProperty("bookingdates")]
        public BookingDatesModel bookingdates { get; set; }

        [JsonProperty("additionalneeds")]
        public string additionalneeds { get; set; }
    }

    public class BookingDatesModel
    {
        [JsonProperty("checkin")]
        public string Checkin { get; set; }

        [JsonProperty("checkout")]
        public string Checkout { get; set; }
    }
}
