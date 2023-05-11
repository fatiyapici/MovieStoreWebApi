using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.Applications.DirectorOperations.Commands.CreateDirector;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Entities;
using Tests.WebApi.UnitTests.TestSetup;
using Xunit;

namespace Tests.WebApi.UnitTests.Applications.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private IMapper _mapper;

        public CreateDirectorCommandTest(CommonTestFixture textFixture)
        {
            _context = textFixture.Context;
            _mapper = textFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistActorIsGiven_InvalidOperationException_ShouldReturn()
        {
            var director = new Person()
            {
                Name = "Christopher",
                Surname = "Nolan"
            };
            _context.Persons.Add(director);
            _context.SaveChanges();

            CreateDirectorCommand command = new CreateDirectorCommand(_context, _mapper);
            command.Model = new CreateDirectorModel() { Name = director.Name, Surname = director.Surname };

            FluentActions.
            Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>()
            .And.Message.Should().Be(CreateDirectorCommand.ExceptionMessage);
        }
    }
}