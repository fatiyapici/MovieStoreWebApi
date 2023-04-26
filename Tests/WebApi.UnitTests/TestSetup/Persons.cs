using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Entities;

namespace Tests.WebApi.UnitTests.TestSetup
{
    public static class Persons
    {
        public static void AddPersons(this MovieStoreDbContext context)
        {
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
                });
        }
    }
}

