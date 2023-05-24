using FluentAssertions;
using MovieStoreWebApi.Applications.MovieOperations.Commands.DeleteMovie;
using MovieStoreWebApi.DbOperations;
using Tests.WebApi.UnitTests.TestSetup;
using Xunit;

namespace Tests.WebApi.UnitTests.Applications.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;

        public DeleteMovieCommandValidatorTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]

        [Theory]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(int MovieId)
        {
            DeleteMovieCommand command = new DeleteMovieCommand(null);
            command.Id = MovieId;

            DeleteMovieCommandValidator validator = new DeleteMovieCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Movie_ShouldBeDeleted()
        {
            DeleteMovieCommand command = new DeleteMovieCommand(_context);
            command.Id = 2;

            DeleteMovieCommandValidator validator = new DeleteMovieCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().Be(0);

            FluentActions.Invoking(() => command.Handle()).Invoke();
        }
    }
}