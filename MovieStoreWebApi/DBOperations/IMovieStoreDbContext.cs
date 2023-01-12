using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.DbOperations
{
    public interface IMovieStoreDbContext
    {
        DbSet<Person> Persons { get; set; }
        DbSet<Actor> Actors { get; set; }
        DbSet<MovieActor> MovieActors { get; set; }
        DbSet<Director> Directors { get; set; }
        DbSet<MovieDirector> MovieDirectors { get; set; }
        DbSet<Movie> Movies { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<MovieGenre> MovieGenres { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<CustomerGenre> CustomerGenres { get; set; }
        DbSet<Order> Orders { get; set; }
        int SaveChanges();
    }
}