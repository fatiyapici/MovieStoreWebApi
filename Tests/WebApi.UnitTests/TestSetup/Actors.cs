using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Entities;

namespace Tests.WebApi.UnitTests.TestSetup
{
    public static class Actors
    {
        public static void AddActors(this MovieStoreDbContext context)
        {
            context.Actors.AddRange(
            new Actor { PersonId = 4 },
            new Actor { PersonId = 5 },
            new Actor { PersonId = 6 }
            );
        }
    }
}