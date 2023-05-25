using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.Applications.CustomerOperations.DeleteCustomer;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Validations.CustomerOperations.DeleteCustomer;
using Tests.WebApi.UnitTests.TestSetup;
using Xunit;
using static MovieStoreWebApi.Applications.CustomerOperations.DeleteCustomer.DeleteCustomerCommand;

namespace Tests.WebApi.UnitTests.Applications.CustomerOperations.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public DeleteCustomerCommandValidatorTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [InlineData("fati@gmail.com", "123456")]
        [InlineData("baran@gmail.com", "123456")]
        [InlineData("fatigmail.com", "123456")]
        [InlineData("fati@gmail.com", "12345")]

        [Theory]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(string email, string password)
        {
            DeleteCustomerCommand command = new DeleteCustomerCommand(null, null, null);
            command.Model = new DeleteCustomerModel()
            {
                Email = email,
                Password = password,
            };

            DeleteCustomerCommandValidator validator = new DeleteCustomerCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}