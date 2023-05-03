using FluentAssertions;
using MovieStoreWebApi.Applications.ActorOperations.Commands.DeleteActor;
using MovieStoreWebApi.Applications.ActorOperations.Commands.UpdateActor;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Entities;
using Tests.WebApi.UnitTests.TestSetup;
using Xunit;

namespace Tests.WebApi.UnitTests.Applications.ActorOperations.Commands.DeleteActor
{
    public class DeleteActorCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        public DeleteActorCommandValidatorTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]

        [Theory]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(int ActorId)
        {
            DeleteActorCommand command = new DeleteActorCommand(null);
            command.ActorId = ActorId;

            DeleteActorCommandValidator validator = new DeleteActorCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Actor_ShouldBeDeleted()
        {
            DeleteActorCommand command = new DeleteActorCommand(_context);
            var actor = new Actor()
            {
                Id = 3
            };

            command.ActorId = actor.Id;

            DeleteActorCommandValidator validator = new DeleteActorCommandValidator();
            var result = validator.Validate(command);

            FluentActions.Invoking(() => command.Handle()).Invoke();
            result.Errors.Count.Should().Be(0);
        }
    }
}