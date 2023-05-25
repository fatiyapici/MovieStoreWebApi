using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.CustomerOperations.Commands.CreateCustomer;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Entities;
using Tests.WebApi.UnitTests.TestSetup;
using Xunit;
using static MovieStoreWebApi.CustomerOperations.Commands.CreateCustomer.CreateCustomerCommand;

namespace Tests.WebApi.UnitTests.Applications.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateCustomerCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenUsernameIsExist_InvalidOperationException_ShouldReturn()
        {
            var person = new Person()
            {
                Name = "Baran",
                Surname = "Taylan"
            };
            _context.Persons.Add(person);
            _context.SaveChanges();

            var customer = new Customer
            {
                PersonId = person.Id,
                Email = "baran@gmail.com",
                Password = "123456",
                RefreshToken = "",
                RefreshTokenExpireDate = DateTime.Now.AddHours(2)
            };
            _context.Customers.Add(customer);
            _context.SaveChanges();

            CreateCustomerCommand command = new CreateCustomerCommand(_context, _mapper);
            command.Model = new CreateCustomerViewModel()
            {
                Name = person.Name,
                Surname = person.Surname,
                Email = customer.Email,
                Password = customer.Password
            };

            FluentActions.
                Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be(ExceptionMessage);
        }
    }
}