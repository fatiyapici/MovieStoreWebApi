using FluentAssertions;
using MovieStoreWebApi.Applications.DirectorOperations.Commands.DeleteDirector;
using MovieStoreWebApi.DbOperations;
using Tests.WebApi.UnitTests.TestSetup;
using Xunit;

namespace Tests.WebApi.UnitTests.Applications.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;

        public DeleteDirectorCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenToBeDeletedDirectorIsNotFound_InvalidOperationException_ShouldReturn()
        {
            DeleteDirectorCommand command = new DeleteDirectorCommand(_context);
            command.DirectorId = 4;

            FluentActions.
                Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>()
                    .And.Message.Should().Be(DeleteDirectorCommand.ExceptionMessage);
        }
    }
}