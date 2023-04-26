using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Entities;

namespace Tests.WebApi.UnitTests.TestSetup
{
    public static class Directors
    {
        public static void AddDirectors(this MovieStoreDbContext context)
        {
            context.Directors.AddRange(
            new Director { PersonId = 1 },
            new Director { PersonId = 2 },
            new Director { PersonId = 3 }
            );
        }
    }
}