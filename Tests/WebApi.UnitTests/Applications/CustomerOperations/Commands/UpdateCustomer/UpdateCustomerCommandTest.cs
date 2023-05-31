using FluentAssertions;
using MovieStoreWebApi.Applications.CustomerOperations.UpdateCustomer;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Entities;
using Tests.WebApi.UnitTests.TestSetup;
using Xunit;
using static MovieStoreWebApi.Applications.CustomerOperations.UpdateCustomer.UpdateCustomerCommand;

namespace Tests.WebApi.UnitTests.Applications.CustomerOperations.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;

        public UpdateCustomerCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
        }

        [Fact]
        public void WhenUpdatedCustomerIsNotExist_InvalidOperationException_ShouldReturn()
        {
            UpdateCustomerCommand command = new UpdateCustomerCommand(_context, 1);

            command.Model = new UpdateCustomerViewModel()
            {
                Email = "yapici@gmail.com",
                Password = "123456"
            };

            FluentActions.
                Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be(ExceptionMessageFound);
        }
    }
}