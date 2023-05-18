using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.Applications.GenreOperations.Commands.CreateGenre;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Entities;
using Tests.WebApi.UnitTests.TestSetup;
using Xunit;
using static MovieStoreWebApi.Applications.GenreOperations.Commands.CreateGenre.CreateGenreCommand;

namespace Tests.WebApi.UnitTests.Applications.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandTest : IClassFixture<CommonTestFixture>

    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateGenreCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistMovieGenreIsGiven_InvalidOperationException_ShouldReturn()
        {
            var genre = new Genre()
            {
                Name = "WhenAlreadyExistMovieGenreIsGiven_InvalidOperationException_ShouldReturn"
            };
            _context.Genres.Add(genre);
            _context.SaveChanges();

            CreateGenreCommand command = new CreateGenreCommand(_context, _mapper);
            command.Model = new CreateGenreViewModel() { Name = genre.Name };

            FluentActions.
                Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be(CreateGenreCommand.ExceptionMessage);
        }
    }
}