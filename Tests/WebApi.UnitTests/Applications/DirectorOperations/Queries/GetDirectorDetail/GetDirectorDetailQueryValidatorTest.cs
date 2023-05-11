using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.Applications.DirectorOperations.Queries.GetDirectorDetailById;
using MovieStoreWebApi.DbOperations;
using Tests.WebApi.UnitTests.TestSetup;
using Xunit;

namespace Tests.WebApi.UnitTests.Applications.DirectorOperations.Queries.GetDirectorDetail
{
    public class GetDirectorDetailValidatorTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetDirectorDetailValidatorTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [InlineData(0)]
        [InlineData(1)]

        [Theory]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(int id)
        {
            GetDirectorDetailById query = new GetDirectorDetailById(null, null);
            query.DirectorId = id;

            GetDirectorDetailByIdValidator validator = new GetDirectorDetailByIdValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}