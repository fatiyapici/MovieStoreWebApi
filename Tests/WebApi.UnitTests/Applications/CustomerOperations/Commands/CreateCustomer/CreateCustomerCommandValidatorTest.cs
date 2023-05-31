using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.CustomerOperations.Commands.CreateCustomer;
using MovieStoreWebApi.DbOperations;
using Tests.WebApi.UnitTests.TestSetup;
using Xunit;
using static MovieStoreWebApi.CustomerOperations.Commands.CreateCustomer.CreateCustomerCommand;

namespace Tests.WebApi.UnitTests.Applications.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateCustomerCommandValidatorTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [InlineData("fati@gmail.com", "123456", "Fatih", "Yapici")]
        [InlineData("baran@gmail.com", "123456", "B", "Taylan")]
        [InlineData("fatigmail.com", "123456", "Fatih", "Yapici")]
        [InlineData("fati@gmail.com", "12345", "Fatih", "Yapici")]

        [Theory]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(string email, string password, string name, string surname)
        {
            CreateCustomerCommand command = new CreateCustomerCommand(null, null);
            command.Model = new CreateCustomerViewModel()
            {
                Email = email,
                Password = password,
                Name = name,
                Surname = surname
            };

            CreateCustomerCommandValidator validator = new CreateCustomerCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}