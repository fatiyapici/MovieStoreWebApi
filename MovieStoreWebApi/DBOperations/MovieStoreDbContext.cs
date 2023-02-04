using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.DbOperations
{
    public class MovieStoreDbContext : DbContext, IMovieStoreDbContext
    {
        public MovieStoreDbContext(DbContextOptions<MovieStoreDbContext> options) : base(options)
        { }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<FavoriteCustomerGenre> FavoriteCustomerGenres { get; set; }
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<MovieDirector> MovieDirectors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Person> Persons { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MovieActor>()
                .HasKey(x => new { x.MovieId, x.ActorId });

            modelBuilder.Entity<MovieActor>()
                .HasOne(x => x.Movie)
                .WithMany(x => x.Actors)
                .HasForeignKey(x => x.MovieId);

            modelBuilder.Entity<MovieActor>()
                .HasOne(x => x.Actor)
                .WithMany()
                .HasForeignKey(x => x.ActorId);

            modelBuilder.Entity<MovieDirector>()
                .HasKey(x => new { x.MovieId, x.DirectorId });

            modelBuilder.Entity<MovieDirector>()
                .HasOne(x => x.Movie)
                .WithMany(x => x.Directors)
                .HasForeignKey(x => x.MovieId);

            modelBuilder.Entity<MovieDirector>()
                .HasOne(x => x.Director)
                .WithMany(x => x.DirectedMovies)
                .HasForeignKey(x => x.DirectorId);

            modelBuilder.Entity<FavoriteCustomerGenre>()
                .HasKey(x => new { x.CustomerId, x.GenreId });

            modelBuilder.Entity<FavoriteCustomerGenre>()
                .HasOne(x => x.Customer)
                .WithMany(x => x.FavoriteGenres)
                .HasForeignKey(x => x.CustomerId);

            modelBuilder.Entity<MovieGenre>()
                .HasKey(x => new { x.MovieId, x.GenreId });

            modelBuilder.Entity<MovieGenre>()
                .HasOne(x => x.Movie)
                .WithMany(x => x.Genres)
                .HasForeignKey(x => x.MovieId);

            modelBuilder.Entity<MovieGenre>()
                .HasOne(x => x.Genre)
                .WithMany()
                .HasForeignKey(x => x.GenreId);

            modelBuilder.Entity<CustomerOrder>()
                .HasKey(x => new { x.CustomerId, x.OrderId });

            modelBuilder.Entity<CustomerOrder>()
                .HasOne(x => x.Order)
                .WithMany()
                .HasForeignKey(x => x.OrderId);

            modelBuilder.Entity<CustomerOrder>()
                .HasOne(x => x.Customer)
                .WithMany(x=>x.CustomerOrders)
                .HasForeignKey(x => x.CustomerId);
        }
    }
}