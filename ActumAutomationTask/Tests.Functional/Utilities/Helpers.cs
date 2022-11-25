using Bogus;
using Tests.Functional.Models;

namespace Tests.Functional.Utilities
{
    public static class Helpers
    {
        public static Data CreateUserData()
        {
            var faker = new Faker();
            string username = "test_" + faker.Random.Number(0, 10000);
            string password = faker.Random.AlphaNumeric(5);

            var userData = new Data()
            {
                userName = username,
                password = password
            };

            return userData;
        }
    }
}
