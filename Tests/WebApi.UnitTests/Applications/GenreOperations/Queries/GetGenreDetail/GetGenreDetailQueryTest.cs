using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.Applications.GenreOperations.Queries.GetGenreDetailById;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Entities;
using Tests.WebApi.UnitTests.TestSetup;
using Xunit;

namespace Tests.WebApi.UnitTests.Applications.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQueryTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;

        public GetGenreDetailQueryTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }
        [Fact]
        public void WhenGenreIsNotFound_InvalidOperationException_ShouldReturn()
        {
            GetGenreDetailById query = new GetGenreDetailById(_context);

            query.GenreId = 3;

            FluentActions.
                Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be(GetGenreDetailById.ExceptionMessage);
        }

        [Fact]
        public void WhenMovieIsFound_Movie_ShouldReturn()
        {
            var genre = new Genre()
            {
                Name = "WhenGenreIsFound_Genre_ShouldReturn",
            };
            _context.Genres.Add(genre);
            _context.SaveChanges();

            GetGenreDetailById query = new GetGenreDetailById(_context);
            query.GenreId = genre.Id;

            FluentActions.
                Invoking(() => query.Handle()).Invoke();
        }
    }
}