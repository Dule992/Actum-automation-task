using Microsoft.Extensions.Configuration;

namespace Functional.Tests
{
    public class TestBase
    {
        public static IConfiguration Configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

        public string HomePageUrl => Configuration["HomePageUrl"];
        public string CartPageUrl => Configuration["CartPageUrl"];
    }
}
