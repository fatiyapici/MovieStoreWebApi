using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Entities;

namespace Tests.WebApi.UnitTests.TestSetup
{
    public static class Genres
    {
        public static void AddGenres(this MovieStoreDbContext context)
        {
            context.Genres.AddRange(
            new Genre { Name = "Action" },
            new Genre { Name = "Crime" },
            new Genre { Name = "Drama" }
            );
        }
    }
}