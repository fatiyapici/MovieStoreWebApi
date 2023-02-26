using MovieStoreWebApi.DbOperations;

namespace MovieStoreWebApi.Applications.CustomerOperations.UpdateCustomer
{
    public class UpdateCustomerCommand
    {
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
            var customer = _context.Customers.SingleOrDefault(x => x.Id == Model.Id);
            if (customer is null)
                throw new InvalidOperationException("Guncellenecek musteri bulunamadi.");
            if (customer.Email != Model.Email)
                throw new InvalidOperationException("Guncellenecek musteri maili yanlis.");
            if (customer.Password != Model.Password)
                throw new InvalidOperationException("Guncellenecek musteri sifresi yanlis.");

            // For Update Mail: customer.Email = Model.Email != default ? Model.Email : customer.Email;
            customer.Password = Model.Password != default ? Model.Password : customer.Password;

            _context.SaveChanges();
        }
        public class UpdateCustomerViewModel
        {
            public int Id { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}