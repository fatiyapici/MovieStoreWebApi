using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.Applications.ActorOperations.Commands.CreateActor;
using MovieStoreWebApi.DbOperations;
using Tests.WebApi.UnitTests.TestSetup;
using Xunit;
using static MovieStoreWebApi.Applications.ActorOperations.Commands.CreateActor.CreateActorCommand;

namespace Tests.WebApi.UnitTests.Applications.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateActorCommandValidatorTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [InlineData("Matthew", "McConaughey")]
        [InlineData("William", "")]
        [InlineData("Fatih", "Yapici")]

        [Theory]
        public void WhenInvalidInputsAreGiven_InvalidOperationException_ShouldReturn(string name, string surname)
        {
            CreateActorCommand command = new CreateActorCommand(null,null);
            command.Model = new CreateActorViewModel()
            {
                Name = name,
                Surname = surname,
            };

            CreateActorCommandValidator validator = new CreateActorCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}