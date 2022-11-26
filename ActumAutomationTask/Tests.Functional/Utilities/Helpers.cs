using Bogus;
using Tests.Functional.Models;

namespace Tests.Functional.Utilities
{
    public static class Helpers
    {
        public static Data CreateUserData()
        {
            var faker = new Faker();

            var userData = new Data()
            {
                UserName = "test_" + faker.Random.Number(0, 10000),
                Password = faker.Random.AlphaNumeric(5)
            };

            return userData;
        }

        public static UserDetails CreateUserDetails()
        {
            var faker = new Faker();

            var userDetails = new UserDetails()
            {
                Name = faker.Name.FullName(),
                Country = faker.Address.Country(),
                City = faker.Address.City(),
                CreditCard = faker.Finance.CreditCardNumber(),
                Month = faker.Date.Month(),
                Year = faker.Date.Past().Year.ToString(),
            };

            return userDetails;
        }
    }
}
