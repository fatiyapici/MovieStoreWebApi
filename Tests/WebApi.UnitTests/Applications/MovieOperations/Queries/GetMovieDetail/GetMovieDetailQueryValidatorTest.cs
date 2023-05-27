using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.Applications.MovieOperations.Queries.GetMovieDetail;
using MovieStoreWebApi.DbOperations;
using Tests.WebApi.UnitTests.TestSetup;
using Xunit;

namespace Tests.WebApi.UnitTests.Applications.MovieOperations.Queries.GetMovieDetail
{
    public class GetMovieDetailValidatorTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetMovieDetailValidatorTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [InlineData(1)]
        [InlineData(2)]

        [Theory]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(int id)
        {
            GetMovieDetailQuery query = new GetMovieDetailQuery(null, null);
            query.MovieId = id;

            GetMovieDetailQueryValidator validator = new GetMovieDetailQueryValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}