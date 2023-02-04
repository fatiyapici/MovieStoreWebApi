using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {
                if (context.Movies.Any())
                {
                    return;
                }

                #region Persons

                context.Persons.AddRange(
                    new Person
                    {
                        // interstellar director
                        Name = "Christopher",
                        Surname = "Nolan",
                    },
                    new Person
                    {
                        // fightClub director
                        Name = "David",
                        Surname = "Fincher"
                    },
                    new Person
                    {
                        // theGodfather director
                        Name = "Francis Ford",
                        Surname = "Coppola"
                    },
                    new Person
                    {
                        // gora director - actor
                        Name = "Cem",
                        Surname = "Yilmaz"
                    },
                    new Person
                    {
                        // interstellar actor
                        Name = "Matthew",
                        Surname = "McConaughey"
                    },
                    new Person
                    {
                        // interstellar actor
                        Name = "Jessica",
                        Surname = "Chastain"
                    },
                    new Person
                    {
                        // fightClub actor
                        Name = "Bradd",
                        Surname = "Pitt"
                    },
                    new Person
                    {
                        // fightClub actor
                        Name = "Edward",
                        Surname = "Norton"
                    },
                    new Person
                    {
                        // theGodfather actor
                        Name = "Marlon",
                        Surname = "Brando"
                    },
                    new Person
                    {
                        // theGodfather actor
                        Name = "Al",
                        Surname = "Pacino"
                    },
                    new Person
                    {
                        // gora actor
                        Name = "Özge",
                        Surname = "Erberk"
                    },
                    new Person
                    {
                        // gora actor
                        Name = "Ozan",
                        Surname = "Güven"
                    }
                );

                context.SaveChanges();

                // --- ACTOR ---

                var persons = context.Persons.ToList();
                for (int i = 3; i < persons.Count; i++)
                {
                    var actor = new Actor
                    {
                        PersonId = persons[i].Id
                    };
                    context.Actors.Add(actor);
                }

                // --- DIRECTOR ---

                for (int i = 0; i < 5; i++)
                {
                    var director = new Director
                    {
                        PersonId = persons[i].Id
                    };
                    context.Directors.Add(director);
                }

                #endregion

                context.SaveChanges();

                #region Genres

                context.Genres.AddRange(
                 new Genre
                 {
                     Name = "Action"
                 },
                 new Genre
                 {
                     Name = "Science Fiction"
                 },
                 new Genre
                 {
                     Name = "Crime"
                 },
                 new Genre
                 {
                     Name = "Drama"
                 },
                 new Genre
                 {
                     Name = "Adventure"
                 },
                 new Genre
                 {
                     Name = "Comedy"
                 }
                 );

                #endregion

                context.SaveChanges();

                #region Movies

                var actors = context.Actors.ToList();

                context.Movies.AddRange(
                    new Movie
                    {
                        Id = 1,
                        Name = "Interstellar",
                        Price = 19.99m,
                        ReleaseDate = new DateTime(2014, 1, 1)
                    },
                   new Movie
                   {
                       Id = 2,
                       Name = "Fight Club",
                       Price = 14.99m,
                       ReleaseDate = new DateTime(1999, 1, 1)
                   },
                   new Movie
                   {
                       Id = 3,
                       Name = "The Godfather",
                       Price = 14.99m,
                       ReleaseDate = new DateTime(1972, 1, 1)
                   },
                   new Movie
                   {
                       Id = 4,
                       Name = "GORA",
                       Price = 9.99m,
                       ReleaseDate = new DateTime(2004, 1, 1)
                   }
               );

                #endregion

                context.SaveChanges();

                #region Many2Many Movies-Genres

                context.MovieGenres.AddRange(
                    new MovieGenre() { MovieId = 1, GenreId = 1 },
                    new MovieGenre() { MovieId = 1, GenreId = 2 },

                    new MovieGenre() { MovieId = 2, GenreId = 1 },
                    new MovieGenre() { MovieId = 2, GenreId = 3 },
                    new MovieGenre() { MovieId = 2, GenreId = 4 },

                    new MovieGenre() { MovieId = 3, GenreId = 3 },
                    new MovieGenre() { MovieId = 3, GenreId = 4 },

                    new MovieGenre() { MovieId = 4, GenreId = 5 },
                    new MovieGenre() { MovieId = 4, GenreId = 6 }
                    );

                #endregion

                context.SaveChanges();

                #region DirectorsInMovies

                context.MovieDirectors.AddRange(
                    new MovieDirector() { MovieId = 1, DirectorId = 1 },
                    new MovieDirector() { MovieId = 2, DirectorId = 2 },
                    new MovieDirector() { MovieId = 3, DirectorId = 3 },
                    new MovieDirector() { MovieId = 4, DirectorId = 4 }
                    );

                #endregion

                context.SaveChanges();

                #region ActorsInMovies

                context.MovieActors.AddRange(
                    new MovieActor() { MovieId = 1, ActorId = 2 },
                    new MovieActor() { MovieId = 1, ActorId = 3 },

                    new MovieActor() { MovieId = 2, ActorId = 4 },
                    new MovieActor() { MovieId = 2, ActorId = 5 },

                    new MovieActor() { MovieId = 3, ActorId = 6 },
                    new MovieActor() { MovieId = 3, ActorId = 7 },

                    new MovieActor() { MovieId = 4, ActorId = 1 },
                    new MovieActor() { MovieId = 4, ActorId = 8 },
                    new MovieActor() { MovieId = 4, ActorId = 9 }
                    );

                #endregion

                context.SaveChanges();

                #region Customers

                context.Customers.AddRange(
                    new Customer
                    {
                        Name = "Fatih",
                        Surname = "Yapici",
                        Email = "fati@gmail.com",
                        Password = "123456",
                        FavoriteGenres = new List<FavoriteCustomerGenre>
                            {
                            new FavoriteCustomerGenre { GenreId = 1 },
                            new FavoriteCustomerGenre { GenreId = 2 },
                            new FavoriteCustomerGenre { GenreId = 3 }
                            }
                    },
                    new Customer
                    {
                        Name = "Baran",
                        Surname = "Taylan",
                        Email = "baran@gmail.com",
                        Password = "123456",
                        FavoriteGenres = new List<FavoriteCustomerGenre>
                            {
                            new FavoriteCustomerGenre { GenreId = 1 },
                            new FavoriteCustomerGenre { GenreId = 2 },
                            new FavoriteCustomerGenre { GenreId = 3 }
                            }
                    });

                #endregion

                context.SaveChanges();

                #region Orders

                context.Orders.AddRange(
                    new Order
                    {
                        Id = 1,
                        MovieId = 1,
                        CustomerId = 1,
                        PuchasedDate = new DateTime(2022, 10, 10)
                    },
                    new Order
                    {
                        Id = 2,
                        MovieId = 2,
                        CustomerId = 2,
                        PuchasedDate = new DateTime(2022, 10, 15)
                    });

                #endregion

                context.SaveChanges();

                #region CustomerOrders

                context.CustomerOrders.AddRange(
                new List<CustomerOrder>
                {
                        new CustomerOrder { OrderId = 1 , CustomerId = 1},

                        new CustomerOrder { OrderId = 2 , CustomerId = 2}
                }
                );

                context.SaveChanges();

                #endregion
            }
        }
    }
}