using FluentAssertions;
using MovieStoreWebApi.Applications.CustomerOperations.Commands.UpdateCustomer;
using MovieStoreWebApi.Applications.CustomerOperations.UpdateCustomer;
using MovieStoreWebApi.DbOperations;
using Tests.WebApi.UnitTests.TestSetup;
using Xunit;
using static MovieStoreWebApi.Applications.CustomerOperations.UpdateCustomer.UpdateCustomerCommand;

namespace Tests.WebApi.UnitTests.Applications.CustomerOperations.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;

        public UpdateCustomerCommandValidatorTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [InlineData("fati@gmail.com", "123456", "234567")]
        [InlineData("baran@gmail.com", "123456", "23456")]
        [InlineData("fatigmail.com", "123456", "234567")]
        [InlineData("fati@gmail.com", "12345", "234567")]

        //Review yapılacak.

        [Theory]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(string email, string password, string newPassword)
        {
            UpdateCustomerCommand command = new UpdateCustomerCommand(null, 1);

            UpdateCustomerViewModel model = new UpdateCustomerViewModel();
            model.Email = email;
            model.NewPassword = newPassword;
            model.Password = password;
            command.Model = model;

            UpdateCustomerCommandValidator validator = new UpdateCustomerCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}