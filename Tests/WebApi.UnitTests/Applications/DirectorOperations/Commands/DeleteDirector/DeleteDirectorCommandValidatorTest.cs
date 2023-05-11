using FluentAssertions;
using MovieStoreWebApi.Applications.DirectorOperations.Commands.DeleteDirector;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Entities;
using Tests.WebApi.UnitTests.TestSetup;
using Xunit;

namespace Tests.WebApi.UnitTests.Applications.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        public DeleteDirectorCommandValidatorTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]

        [Theory]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(int DirectorId)
        {
            DeleteDirectorCommand command = new DeleteDirectorCommand(null);
            command.Id = DirectorId;

            DeleteDirectorCommandValidator validator = new DeleteDirectorCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Director_ShouldBeDeleted()
        {
            DeleteDirectorCommand command = new DeleteDirectorCommand(_context);
            var director = new Director()
            {
                Id = 4
            };

            command.Id = director.Id;

            DeleteDirectorCommandValidator validator = new DeleteDirectorCommandValidator();
            var result = validator.Validate(command);

            FluentActions.Invoking(() => command.Handle()).Invoke();
            result.Errors.Count.Should().Be(0);
        }
    }
}