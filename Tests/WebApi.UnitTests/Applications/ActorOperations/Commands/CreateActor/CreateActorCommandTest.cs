using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.Applications.ActorOperations.Commands.CreateActor;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Entities;
using Tests.WebApi.UnitTests.TestSetup;
using Xunit;
using static MovieStoreWebApi.Applications.ActorOperations.Commands.CreateActor.CreateActorCommand;

namespace Tests.WebApi.UnitTests.Applications.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateActorCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenAlreadyExistActorIsGiven_InvalidOperationException_ShouldReturn()
        {
            var actor = new Person()
            {
                Name = "Matthew",
                Surname = "McConaughey"
            };
            _context.Persons.Add(actor);
            _context.SaveChanges();

            CreateActorCommand command = new CreateActorCommand(_context, _mapper);
            command.Model = new CreateActorViewModel() { Name = actor.Name, Surname = actor.Surname };

            FluentActions.
            Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>()
            .And.Message.Should().Be(CreateActorCommand.ExceptionMessage);
        }
    }
}