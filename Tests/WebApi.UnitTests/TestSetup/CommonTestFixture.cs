using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.DbOperations;
using WebApi.Common;

namespace Tests.WebApi.UnitTests.TestSetup
{
    public class CommonTestFixture
    {
        public MovieStoreDbContext Context { get; set; }
        public IMapper Mapper { get; set; }
        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<MovieStoreDbContext>().UseInMemoryDatabase(databaseName: "MovieStoreTestDB").Options;
            Context = new MovieStoreDbContext(options);

            Context.Database.EnsureCreated();
            Context.AddActors();
            Context.AddCustomers();
            Context.AddDirectors();
            Context.AddGenres();
            Context.AddMovies();
            Context.AddOrders();
            Context.AddPersons();

            Mapper = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); }).CreateMapper();
        }
    }
}