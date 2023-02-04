using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStoreWebApi.Entities
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        // public string RefreshToken { get; set; }
        public Person Person { get; set; }
        // public DateTime? RefreshTokenExpireDate { get; set; }
        public virtual ICollection<FavoriteCustomerGenre> FavoriteGenres { get; set; }
        public virtual ICollection<CustomerOrder> CustomerOrders { get; set; }
    }
    public class FavoriteCustomerGenre
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
    public class CustomerOrder
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}