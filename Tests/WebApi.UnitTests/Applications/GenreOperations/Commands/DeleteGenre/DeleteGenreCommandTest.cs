using FluentAssertions;
using MovieStoreWebApi.Applications.GenreOperations.Commands.DeleteGenre;
using MovieStoreWebApi.DbOperations;
using Tests.WebApi.UnitTests.TestSetup;
using Xunit;

namespace Tests.WebApi.UnitTests.Applications.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;

        public DeleteGenreCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenToBeDeletedGenreIsNotFound_InvalidOperationException_ShouldReturn()
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context);
            command.GenreId = 5;

            FluentActions.
                Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be(DeleteGenreCommand.ExceptionMessage);
        }
    }
}