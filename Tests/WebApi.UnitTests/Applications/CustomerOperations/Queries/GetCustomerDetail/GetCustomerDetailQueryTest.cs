using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.Applications.CustomerOperations.GetCustomerDetail;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Entities;
using Tests.WebApi.UnitTests.TestSetup;
using Xunit;

namespace Tests.WebApi.UnitTests.Applications.CustomerOperations.Queries.GetCustomerDetail
{
    public class GetCustomerDetailQueryTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomerDetailQueryTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenCustomerIsNotFound_InvalidOperationException_ShouldReturn()
        {
            GetCustomerDetailById query = new GetCustomerDetailById(_context, _mapper);
            query.CustomerId = 10;

            FluentActions.
                Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>()
                .WithMessage(GetCustomerDetailById.ExceptionMessage);
        }

        [Fact]
        public void WhenCustomerIsFound_Customer_ShouldReturn()
        {
            var person = new Person()
            {
                Name = "Burak",
                Surname = "Hassemercioğlu"
            };
            _context.Persons.Add(person);
            _context.SaveChanges();

            var customer = new Customer()
            {
                PersonId = person.Id
            };
            _context.Customers.Add(customer);
            _context.SaveChanges();

            GetCustomerDetailById query = new GetCustomerDetailById(_context, _mapper);
            query.CustomerId = customer.Id;

            FluentActions.Invoking(() => query.Handle()).Invoke();
        }
    }
}