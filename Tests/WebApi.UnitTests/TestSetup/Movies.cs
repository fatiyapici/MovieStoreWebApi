using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Entities;

namespace Tests.WebApi.UnitTests.TestSetup
{
    public static class Movies
    {
        public static void AddMovies(this MovieStoreDbContext context)
        {
            context.Movies.AddRange(
            new Movie
            {
                Name = "Interstellar",
                Price = 19.99m,
                ReleaseDate = new DateTime(2014, 1, 1)
            },
            new Movie
            {
                Name = "Fight Club",
                Price = 14.99m,
                ReleaseDate = new DateTime(1999, 1, 1)
            },
            new Movie
            {
                Name = "The Godfather",
                Price = 14.99m,
                ReleaseDate = new DateTime(1972, 1, 1),
            }
            );
        }
    }
}