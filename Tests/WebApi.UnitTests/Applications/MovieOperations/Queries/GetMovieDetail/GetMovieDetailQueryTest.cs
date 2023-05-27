using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.Applications.MovieOperations.Queries.GetMovieDetail;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Entities;
using Tests.WebApi.UnitTests.TestSetup;
using Xunit;

namespace Tests.WebApi.UnitTests.Applications.MovieOperations.Queries.GetMovieDetail
{
    public class GetMovieDetailQueryTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetMovieDetailQueryTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenMovieIsNotFound_InvalidOperationException_ShouldReturn()
        {
            GetMovieDetailQuery query = new GetMovieDetailQuery(_context, _mapper);
            query.MovieId = 10;

            FluentActions.
                Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>()
                .WithMessage(GetMovieDetailQuery.ExceptionMessage);
        }

        [Fact]
        public void WhenMovieIsFound_Movie_ShouldReturn()
        {
            var movie = new Movie()
            {
                Name = "Interstellar",
                Price = 19.99m
            };
            _context.Movies.Add(movie);
            _context.SaveChanges();

            GetMovieDetailQuery query = new GetMovieDetailQuery(_context, _mapper);
            query.MovieId = movie.Id;

            FluentActions.Invoking(() => query.Handle()).Invoke();
        }
    }
}