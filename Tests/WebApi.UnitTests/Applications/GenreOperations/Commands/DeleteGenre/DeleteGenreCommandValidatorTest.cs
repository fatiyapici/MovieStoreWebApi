using FluentAssertions;
using MovieStoreWebApi.Applications.GenreOperations.Commands.DeleteGenre;
using MovieStoreWebApi.Applications.GenreOperations.Commands.GenreDirector;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Entities;
using Tests.WebApi.UnitTests.TestSetup;
using Xunit;

namespace Tests.WebApi.UnitTests.Applications.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        public DeleteGenreCommandValidatorTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [InlineData("", 0)]
        [InlineData("Adventure", 0)]
        [InlineData("", 2)]
        [InlineData("Mystery", 3)]
        [InlineData("Musical", 4)]
        [InlineData("War", 5)]

        [Theory]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(string name, int genreId)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(null);
            command.GenreId = genreId;

            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Genre_ShouldBeDeleted()
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            var genre = new Genre()
            {
                Name = "WhenValidInputsAreGiven_Genre_ShouldBeDeleted",
            };
            _context.Genres.Add(genre);
            _context.SaveChanges();

            command.GenreId = genre.Id;

            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().Be(0);

            FluentActions.Invoking(() => command.Handle()).Invoke();
        }
    }
}