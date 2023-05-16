using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.Applications.ActorOperations.Queries.GetActorDetail;
using MovieStoreWebApi.DbOperations;
using Tests.WebApi.UnitTests.TestSetup;
using Xunit;

namespace Tests.WebApi.UnitTests.Applications.ActorOperations.Queries.GetActorDetail
{
    public class GetActorDetailValidatorTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetActorDetailValidatorTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [InlineData(0)]
        [InlineData(1)]

        [Theory]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(int id)
        {
            GetActorDetailById query = new GetActorDetailById(null, null);
            query.ActorId = id;

            GetActorDetailByIdValidator validator = new GetActorDetailByIdValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}