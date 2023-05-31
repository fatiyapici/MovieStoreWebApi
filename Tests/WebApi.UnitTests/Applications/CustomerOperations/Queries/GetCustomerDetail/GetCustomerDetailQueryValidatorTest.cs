using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.Applications.CustomerOperations.GetCustomerDetail;
using MovieStoreWebApi.CustomerOperations.Queries.GetCustomerDetail;
using MovieStoreWebApi.DbOperations;
using Tests.WebApi.UnitTests.TestSetup;
using Xunit;

namespace Tests.WebApi.UnitTests.Applications.CustomerOperations.Queries.GetCustomerDetail
{
    public class GetCustomerDetailValidatorTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomerDetailValidatorTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [InlineData(0)]
        [InlineData(1)]

        [Theory]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(int id)
        {
            GetCustomerDetailById query = new GetCustomerDetailById(null, null);
            query.CustomerId = id;

            GetCustomerDetailByIdValidator validator = new GetCustomerDetailByIdValidator();
            var result = validator.Validate(query);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}