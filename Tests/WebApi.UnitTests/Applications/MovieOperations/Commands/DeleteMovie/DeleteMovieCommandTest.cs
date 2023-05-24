using FluentAssertions;
using MovieStoreWebApi.Applications.MovieOperations.Commands.DeleteMovie;
using MovieStoreWebApi.DbOperations;
using Tests.WebApi.UnitTests.TestSetup;
using Xunit;

namespace Tests.WebApi.UnitTests.Applications.DirectorOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;

        public DeleteMovieCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenToBeDeletedMovieIsNotFound_InvalidOperationException_ShouldReturn()
        {
            DeleteMovieCommand command = new DeleteMovieCommand(_context);
            command.Id = 4;

            FluentActions.
                Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be(DeleteMovieCommand.ExceptionMessage);
        }
    }
}