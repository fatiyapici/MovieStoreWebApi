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
                for (int i = 4; i < persons.Count; i++)
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

                // List<Actor> interstellarCast = new List<Actor>();
                // interstellarCast.Add(actors.First(x => x.Id == 5));
                // interstellarCast.Add(actors.First(x => x.Id == 6));

                // List<Actor> fightClubCast = new List<Actor>();
                // fightClubCast.Add(actors.First(x => x.Id == 9));
                // fightClubCast.Add(actors.First(x => x.Id == 10));

                // List<Actor> theGodfatherCast = new List<Actor>();
                // theGodfatherCast.Add(actors.First(x => x.Id == 7));
                // theGodfatherCast.Add(actors.First(x => x.Id == 8));

                // List<Actor> goraCast = new List<Actor>();
                // goraCast.Add(actors.First(x => x.Id == 4));
                // goraCast.Add(actors.First(x => x.Id == 11));
                // goraCast.Add(actors.First(x => x.Id == 12));

                context.Movies.AddRange(
                    new Movie
                    {
                        Id = 1,
                        Name = "Interstellar",
                        // Casts = interstellarCast,
                        Price = 19.99m,
                        ReleaseDate = new DateTime(2014)
                    },
                   new Movie
                   {
                       Id = 2,
                       Name = "Fight Club",
                    //    Casts = fightClubCast,
                       Price = 14.99m,
                       ReleaseDate = new DateTime(1999)
                   },
                   new Movie
                   {
                       Id = 3,
                       Name = "The Godfather",
                    //    Casts = theGodfatherCast,
                       Price = 14.99m,
                       ReleaseDate = new DateTime(1972)
                   },
                   new Movie
                   {
                       Id = 4,
                       Name = "GORA",
                    //    Casts = goraCast,
                       Price = 9.99m,
                       ReleaseDate = new DateTime(2004)
                   }
               );

                #endregion
                
                context.SaveChanges();

                #region Many2Many Movies-Genres

                context.MovieGenres.AddRange(new MovieGenre(){ MovieId = 1, GenreId = 1},
                   new MovieGenre(){ MovieId = 1, GenreId = 2});

                // context.MovieGenres.AddRange(
                //     
                //     
                //     new MovieGenre()
                //     {
                //         MovieId = 2,
                //         GenreId = 1
                //     },
                //     new MovieGenre()
                //     {
                //         MovieId = 2,
                //         GenreId = 3
                //     },
                //     new MovieGenre()
                //     {
                //         MovieId = 2,
                //         GenreId = 4
                //     },
                //     new MovieGenre()
                //     {
                //         MovieId = 3,
                //         GenreId = 3
                //     },
                //     new MovieGenre()
                //     {
                //         MovieId = 3,
                //         GenreId = 4
                //     },
                //     new MovieGenre()
                //     {
                //         MovieId = 4,
                //         GenreId = 5
                //     },
                //     new MovieGenre()
                //     {
                //         MovieId = 4,
                //         GenreId = 6
                //     }
                // );

                #endregion

                context.SaveChanges();

                #region ActorsInMovies

                // bunun karşılığı bu
                //     new ActorMovie
                //  {
                //      ActorId = 5,
                //      MovieId = 1
                //  },
                //  new ActorMovie
                //  {
                //      ActorId = 6,
                //      MovieId = 1
                //  },

                context.MovieActors.AddRange(new MovieActor(){MovieId = 1, ActorId = 1},
                    new MovieActor(){MovieId = 1, ActorId = 2});

                // context.ActorMovies.AddRange(
                //  new ActorMovie
                //  {
                //      ActorId = 5,
                //      MovieId = 1
                //  },
                //  new ActorMovie
                //  {
                //      ActorId = 6,
                //      MovieId = 1
                //  },
                //  new ActorMovie
                //  {
                //      ActorId = 7,
                //      MovieId = 3
                //  },
                //  new ActorMovie
                //  {
                //      ActorId = 8,
                //      MovieId = 3
                //  },
                //  new ActorMovie
                //  {
                //      ActorId = 9,
                //      MovieId = 2
                //  },
                //  new ActorMovie
                //  {
                //      ActorId = 10,
                //      MovieId = 2
                //  }, new ActorMovie
                //  {
                //      ActorId = 11,
                //      MovieId = 4
                //  }, new ActorMovie
                //  {
                //      ActorId = 12,
                //      MovieId = 4
                //  }, new ActorMovie
                //  {
                //      ActorId = 4,
                //      MovieId = 4
                //  }
                //  );

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
                    },
                    new Customer
                    {
                        Name = "Baran",
                        Surname = "Taylan",
                        Email = "baran@gmail.com",
                        Password = "123456",
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
            }
        }
    }
}