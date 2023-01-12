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
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<CustomerGenre> FavoriteGenres { get; set; }
    }

    public class CustomerGenre
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}