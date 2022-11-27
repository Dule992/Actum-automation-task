using Microsoft.Extensions.Configuration;
using RestSharp;

namespace Tests.API
{
    public class TestBase
    {
        protected IConfiguration Configuration;
        protected RestClient RestClient;

        public TestBase()
        {
            Configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            RestClient = new RestClient(Configuration["BASE_URL"]);
        }
    }
}
