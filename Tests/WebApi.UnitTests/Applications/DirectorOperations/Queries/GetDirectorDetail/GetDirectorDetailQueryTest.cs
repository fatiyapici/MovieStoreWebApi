using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.Applications.DirectorOperations.Queries.GetDirectorDetailById;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Entities;
using Tests.WebApi.UnitTests.TestSetup;
using Xunit;

namespace Tests.WebApi.UnitTests.Applications.DirectorOperations.Queries.GetDirectorDetail
{
    public class GetDirectorDetailQueryTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetDirectorDetailQueryTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenDirectorIsNotFound_InvalidOperationException_ShouldReturn()
        {
            GetDirectorDetailById query = new GetDirectorDetailById(_context, _mapper);
            query.DirectorId = 10;

            FluentActions.
                Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>()
                .WithMessage(GetDirectorDetailById.ExceptionMessage);
        }

        [Fact]
        public void WhenDirectorIsFound_Director_ShouldReturn()
        {
            var person = new Person()
            {
                Name = "Christopher",
                Surname = "Nolan"
            };
            _context.Persons.Add(person);
            _context.SaveChanges();

            var director = new Director()
            {
                PersonId = person.Id
            };
            _context.Directors.Add(director);
            _context.SaveChanges();

            GetDirectorDetailById query = new GetDirectorDetailById(_context, _mapper);
            query.DirectorId = director.Id;

            FluentActions.Invoking(() => query.Handle()).Invoke();
        }
    }
}