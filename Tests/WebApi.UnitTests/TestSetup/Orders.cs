using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Entities;

namespace Tests.WebApi.UnitTests.TestSetup
{
    public static class Orders
    {
        public static void AddOrders(this MovieStoreDbContext context)
        {
            context.Orders.AddRange(
            new Order
            {
                MovieId = 1,
                CustomerId = 1,
                PuchasedDate = new DateTime(2022, 10, 10)
            },
            new Order
            {
                Id = 2,
                MovieId = 2,
                CustomerId = 2,
                PuchasedDate = new DateTime(2022, 10, 15)
            });
        }
    }
}