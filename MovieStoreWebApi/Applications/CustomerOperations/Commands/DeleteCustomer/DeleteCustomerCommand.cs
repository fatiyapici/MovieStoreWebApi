using MovieStoreWebApi.DbOperations;

namespace MovieStoreWebApi.Applications.CustomerOperations.DeleteCustomer
{
    public class DeleteCustomerCommand
    {
        public DeleteCustomerModel Model { get; set; }
        public int CustomerId { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPassword { get; set; }
        public const string ExceptionMessageFound = "Silinecek musteri bulunamadi.";
        public const string ExceptionMessageEmail = "Silinecek musteri emaili yanlis.";
        public const string ExceptionMessagePassword = "Silinecek musteri sifresi yanlis.";

        private readonly IMovieStoreDbContext _dbContext;

        public DeleteCustomerCommand(IMovieStoreDbContext dbContext, string email, string password)
        {
            _dbContext = dbContext;
            email = CustomerEmail;
            password = CustomerPassword;
        }

        public void Handle()
        {
            var customer = _dbContext.Customers.Find(CustomerId);
            if (customer is null)
                throw new InvalidOperationException(ExceptionMessageFound);
            if (customer.Email != CustomerEmail)
                throw new InvalidOperationException(ExceptionMessageEmail);
            if (customer.Password != CustomerPassword)
                throw new InvalidOperationException(ExceptionMessagePassword);
            _dbContext.Customers.Remove(customer);
            _dbContext.SaveChanges();
        }

        public class DeleteCustomerModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}