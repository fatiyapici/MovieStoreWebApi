using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Entities;

namespace Tests.WebApi.UnitTests.TestSetup
{
    public static class Customers
    {
        public static void AddCustomers(this MovieStoreDbContext context)
        {
            context.Customers.AddRange(
                new Customer {
                    Name = "Fatih",
                    Surname = "Yapici",
                    Email = "fati@gmail.com",
                    Password = "123456",
                    RefreshToken = "",
                    RefreshTokenExpireDate = System.DateTime.Now.AddHours(2)
                });
        }
    }
}