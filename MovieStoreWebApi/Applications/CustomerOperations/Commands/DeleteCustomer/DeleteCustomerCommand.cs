using MovieStoreWebApi.DbOperations;

namespace MovieStoreWebApi.Applications.CustomerOperations.DeleteCustomer
{
    public class DeleteCustomerCommand
    {
        public const string ExceptionMessageFound = "Silinecek musteri bulunamadi.";
        public const string ExceptionMessageEmail = "Silinecek musteri emaili yanlis.";
        public const string ExceptionMessagePassword = "Silinecek musteri sifresi yanlis.";
        public DeleteCustomerModel Model { get; set; }

        private readonly IMovieStoreDbContext _dbContext;

        public DeleteCustomerCommand(IMovieStoreDbContext dbContext, string email, string password)
        {
            _dbContext = dbContext;
            email = Model.Email;
            password = Model.Password;
        }

        public void Handle()
        {
            var customer = _dbContext.Customers.Find(Model.Id);
            if (customer is null)
                throw new InvalidOperationException(ExceptionMessageFound);
            if (customer.Email != Model.Email)
                throw new InvalidOperationException(ExceptionMessageEmail);
            if (customer.Password != Model.Password)
                throw new InvalidOperationException(ExceptionMessagePassword);
            _dbContext.Customers.Remove(customer);
            _dbContext.SaveChanges();
        }

        public class DeleteCustomerModel
        {
            public int Id { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}