using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.Applications.CustomerOperations.DeleteCustomer;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Entities;
using Tests.WebApi.UnitTests.TestSetup;
using Xunit;
using static MovieStoreWebApi.Applications.CustomerOperations.DeleteCustomer.DeleteCustomerCommand;

namespace Tests.WebApi.UnitTests.Applications.CustomerOperations.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;
        
        public DeleteCustomerCommandTest(CommonTestFixture textFixture)
        {
            _context = textFixture.Context;
            _mapper = textFixture.Mapper;
        }

        [Fact]
        public void WhenDeletedCustomerIsNotExist_InvalidOperationException_ShouldReturn()
        {
            DeleteCustomerCommand command = new DeleteCustomerCommand(_context);
            command.Model = new DeleteCustomerModel()
            {
                Email = "hassemercioglu@gmail.com",
                Password = "123456"
            };

            FluentActions.
                Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be(ExceptionMessageFound);
        }
    }
}