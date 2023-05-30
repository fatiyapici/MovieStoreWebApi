using MovieStoreWebApi.DbOperations;

namespace MovieStoreWebApi.Applications.CustomerOperations.UpdateCustomer
{
    public class UpdateCustomerCommand
    {
        public const string ExceptionMessageFound = "Guncellenecek musteri bulunamadi.";
        public const string ExceptionMessageEmail = "Guncellenecek musteri maili yanlis.";
        public const string ExceptionMessagePassword = "Guncellenecek musteri sifresi yanlis.";

        public UpdateCustomerViewModel Model { get; set; }
        public int Id { get; set; }

        private readonly IMovieStoreDbContext _context;

        public UpdateCustomerCommand(IMovieStoreDbContext context, int id)
        {
            _context = context;
            Id = id;
        }
        public void Handle()
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == Id);
            if (customer is null)
                throw new InvalidOperationException(ExceptionMessageFound);
            if (customer.Email != Model.Email)
                throw new InvalidOperationException(ExceptionMessageEmail);
            if (customer.Password != Model.Password)
                throw new InvalidOperationException(ExceptionMessagePassword);

            // For Update Mail: customer.Email = Model.Email != default ? Model.Email : customer.Email;
            customer.Password = Model.NewPassword;

            _context.SaveChanges();
        }
        public class UpdateCustomerViewModel
        {
            public int Id { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string NewPassword { get; set; }
        }
    }
}