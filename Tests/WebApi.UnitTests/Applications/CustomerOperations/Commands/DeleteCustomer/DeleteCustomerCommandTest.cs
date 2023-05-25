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
            var person = new Person()
            {
                Name = "Burak",
                Surname = "Hassemercioglu"
            };
            _context.Persons.Add(person);
            _context.SaveChanges();

            var customer = new Customer
            {
                PersonId = person.Id,
                Email = "burak@gmail.com",
                Password = "123456",
                RefreshToken = "",
                RefreshTokenExpireDate = DateTime.Now.AddHours(2)
            };
            _context.Customers.Add(customer);
            _context.SaveChanges();

            DeleteCustomerCommand command = new DeleteCustomerCommand(_context, customer.Email, customer.Password);
            command.Model = new DeleteCustomerModel()
            {
                Email = "burak@gmail.com",
                Password = "123456"
            };

            FluentActions.
                Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be(ExceptionMessageFound);
        }
    }
}