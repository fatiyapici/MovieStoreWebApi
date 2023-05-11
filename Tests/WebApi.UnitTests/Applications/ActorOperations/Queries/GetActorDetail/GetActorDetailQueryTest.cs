using AutoMapper;
using FluentAssertions;
using MovieStoreWebApi.Applications.ActorOperations.Queries.GetActorDetail;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Entities;
using Tests.WebApi.UnitTests.TestSetup;
using Xunit;

namespace Tests.WebApi.UnitTests.Applications.ActorOperations.Queries.GetActorDetail
{
    public class GetActorDetailQueryTest : IClassFixture<CommonTestFixture>
    {
        private readonly MovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetActorDetailQueryTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenActorIsNotFound_InvalidOperationException_ShouldReturn()
        {
            GetActorDetailById query = new GetActorDetailById(_context, _mapper);
            query.ActorId = 10;

            FluentActions.
                Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>()
                    .WithMessage(GetActorDetailById.ExceptionMessage);
        }

        [Fact]
        public void WhenActorIsFound_Actor_ShouldReturn()
        {
            var actor = new Person()
            {
                Name = "Matthew",
                Surname = "McConaughey"
            };
            _context.Persons.Add(actor);
            _context.SaveChanges();

            GetActorDetailById query = new GetActorDetailById(_context, _mapper);
            query.ActorId = 2;

            FluentActions.
                Invoking(() => query.Handle()).Invoke();
        }
    }
}