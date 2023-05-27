using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.Applications.MovieOperations.Commands.CreateMovie;
using MovieStoreWebApi.DbOperations;
using Tests.WebApi.UnitTests.TestSetup;
using Xunit;
using static MovieStoreWebApi.Applications.MovieOperations.Commands.CreateMovie.CreateMovieCommand;

namespace Tests.WebApi.UnitTests.Applications.DirectorOperations.Commands.CreateActor
{
    public class CreateMovieCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateMovieCommandValidatorTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [InlineData("Interstellar", 20, 0, 0, 0)]
        [InlineData("Fight Club", 0, 1996, 05, 17)]
        [InlineData("", 5, 1996, 05, 17)]
        [InlineData("Interstellar", 20, 1996, 05, 17)]
        [InlineData("Fight Club", 10, 1996, 05, 17)]
        [InlineData("The Godfather", 5, 1996, 05, 17)]

        [Theory]
        public void WhenInvalidInputsAreGiven_InvalidOperationException_ShouldReturn(string name, decimal price, int year, int month, int day)
        {
            CreateMovieCommand command = new CreateMovieCommand(null, null);
            command.Model = new CreateMovieModel()
            {
                Name = name,
                Price = price,
                ReleaseDate = new DateTime(year, month, day)
            };

            CreateMovieCommandValidator validator = new CreateMovieCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}