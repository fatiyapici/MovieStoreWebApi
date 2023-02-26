using MovieStoreWebApi.DbOperations;

namespace MovieStoreWebApi.Applications.CustomerOperations.DeleteCustomer
{
    public class DeleteCustomerCommand
    {
        public int CustomerId { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPassword { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        public DeleteCustomerCommand(IMovieStoreDbContext dbContext, string email, string password)
        {
            _dbContext = dbContext;
            email = CustomerEmail;
            password = CustomerPassword;
        }
        public void Handle()
        {
            var customer = _dbContext.Customers
            .SingleOrDefault(x => x.Id == CustomerId);
            if (customer is null)
                throw new InvalidOperationException("Silinecek musteri bulunamadi.");
            if (customer.Email != CustomerEmail)
                throw new InvalidOperationException("Silinecek musteri emaili yanlis.");
            if (customer.Password != CustomerPassword)
                throw new InvalidOperationException("Silinecek musteri sifresi yanlis.");
            _dbContext.Customers.Remove(customer);
            _dbContext.SaveChanges();
        }
    }
}