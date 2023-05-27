using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.Applications.MovieOperations.Commands.CreateMovie;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Entities;
using Tests.WebApi.UnitTests.TestSetup;
using Xunit;
using static MovieStoreWebApi.Applications.MovieOperations.Commands.CreateMovie.CreateMovieCommand;

namespace Tests.WebApi.UnitTests.Applications.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateMovieCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistMovieIsGiven_InvalidOperationException_ShouldReturn()
        {
            var movie = new Movie()
            {
                Name = "WhenAlreadyExistBookTitleIsGiven",
                Price = 10,
                ReleaseDate = new DateTime(1996, 05, 17)
            };
            _context.Movies.Add(movie);
            _context.SaveChanges();

            CreateMovieCommand command = new CreateMovieCommand(_context, _mapper);
            command.Model = new CreateMovieModel() { Name = movie.Name };

            FluentActions.
                Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be(ExceptionMessage);
        }
    }
}