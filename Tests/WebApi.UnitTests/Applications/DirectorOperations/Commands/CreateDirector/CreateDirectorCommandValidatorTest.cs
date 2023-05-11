using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.Applications.ActorOperations.Commands.CreateActor;
using MovieStoreWebApi.Applications.DirectorOperations.Commands.CreateDirector;
using MovieStoreWebApi.DbOperations;
using Tests.WebApi.UnitTests.TestSetup;
using Xunit;

namespace Tests.WebApi.UnitTests.Applications.DirectorOperations.Commands.CreateActor
{
    public class CreateDirectorCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateDirectorCommandValidatorTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [InlineData("Christopher", "Nolan")]
        [InlineData("William", "")]
        [InlineData("Fatih", "Yapici")]

        [Theory]
        public void WhenInvalidInputsAreGiven_InvalidOperationException_ShouldReturn(string name, string surname)
        {
            CreateDirectorCommand command = new CreateDirectorCommand(null, null);
            command.Model = new CreateDirectorModel()
            {
                Name = name,
                Surname = surname,
            };

            CreateDirectorCommandValidator validator = new CreateDirectorCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}