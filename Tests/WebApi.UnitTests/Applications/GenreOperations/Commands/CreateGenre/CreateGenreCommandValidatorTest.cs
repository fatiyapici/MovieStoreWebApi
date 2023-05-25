using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.Applications.GenreOperations.Commands.CreateGenre;
using MovieStoreWebApi.DbOperations;
using Tests.WebApi.UnitTests.TestSetup;
using Xunit;
using static MovieStoreWebApi.Applications.GenreOperations.Commands.CreateGenre.CreateGenreCommand;

namespace Tests.WebApi.UnitTests.Applications.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateGenreCommandValidatorTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [InlineData("")]
        [InlineData("Adventure")]
        [InlineData("Documentary")]
        [InlineData("Mystery")]
        [InlineData("Musical")]
        [InlineData("War")]

        [Theory]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(string name)
        {
            CreateGenreCommand command = new CreateGenreCommand(null, null);
            command.Model = new CreateGenreViewModel()
            {
                Name = name
            };

            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenValidInputAreGiven_Validator_ShouldNotBeReturnError()
        {
            CreateGenreCommand command = new CreateGenreCommand(null, null);
            
            command.Model = new CreateGenreViewModel()
            {
                Name = "Horror"
            };

            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }

        [Fact]
        public void WhenValidInputsAreGiven_Movie_ShouldBeCreated()
        {
            CreateGenreCommand command = new CreateGenreCommand(_context, _mapper);

            CreateGenreViewModel model = new CreateGenreViewModel()
            {
                Name = "Thriller"
            };
            command.Model = model;

            FluentActions.Invoking(() => command.Handle()).Invoke();

            var genre = _context.Genres.SingleOrDefault(genre => genre.Name == model.Name);
            genre.Should().NotBeNull();
        }
    }
}