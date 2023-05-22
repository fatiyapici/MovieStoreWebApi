using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.Applications.GenreOperations.Queries.GetGenreDetailById;
using MovieStoreWebApi.DbOperations;
using Tests.WebApi.UnitTests.TestSetup;
using Xunit;

namespace Tests.WebApi.UnitTests.Applications.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQueryValidatorTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetGenreDetailQueryValidatorTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [InlineData(0)]
        [InlineData(1)]

        [Theory]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(int id)
        {
            GetGenreDetailById query = new GetGenreDetailById(null);
            query.Id = id;

            GetGenreDetailByIdValidator validator = new GetGenreDetailByIdValidator();
            var result = validator.Validate(query);
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}