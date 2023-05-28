using AutoMapper;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommand
    {
        public const string ExceptionMessage = "Kullanici adi zaten mevcut.";
        public CreateCustomerViewModel Model { get; set; }

        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateCustomerCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var customer = _dbContext.Customers.SingleOrDefault(x => string.Equals(x.Email, Model.Email));

            if (customer is not null)
                throw new InvalidOperationException(ExceptionMessage);

            customer = _mapper.Map<Customer>(Model);
            customer.RefreshToken = "";

            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
        }

        public class CreateCustomerViewModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}