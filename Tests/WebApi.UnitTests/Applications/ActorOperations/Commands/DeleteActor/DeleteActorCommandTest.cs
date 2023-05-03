using FluentAssertions;
using MovieStoreWebApi.Applications.ActorOperations.Commands.DeleteActor;
using MovieStoreWebApi.DbOperations;
using Tests.WebApi.UnitTests.TestSetup;
using Xunit;

namespace Tests.WebApi.UnitTests.Applications.ActorOperations.DeleteActor
{
    public class DeleteActorCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;

        public DeleteActorCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenToBeDeletedActorIsNotFound_InvalidOperationException_ShouldReturn()
        {
            //3 Actor registered in the Database

            DeleteActorCommand command = new DeleteActorCommand(_context);
            command.ActorId = 4;

            FluentActions.
                Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>()
                    .And.Message.Should().Be("Oyuncu bulunamadi.");
        }
    }
}