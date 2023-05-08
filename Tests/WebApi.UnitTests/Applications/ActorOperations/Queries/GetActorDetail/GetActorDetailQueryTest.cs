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

        //todo fact test caseleri yanlis duzeltilecek.
        [Fact]
        public void WhenActorIsNotFound_InvalidOperationException_ShouldReturn()
        {
            // var actor = new Actor { PersonId = 1 };
            // _context.Actors.Add(actor);
            // _context.SaveChanges();

            GetActorDetailById query = new GetActorDetailById(_context, _mapper);
            query.ActorId = 10;

            FluentActions.
                Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>()
                    .WithMessage(GetActorDetailById.ExceptionMessage);
        }

        [Fact]
        public void WhenActorIsFound_Actor_ShouldReturn()
        {
            var actor = new Actor()
            {
                Id = 1,
                PersonId = 4
            };
            _context.Actors.Add(actor);
            _context.SaveChanges();

            GetActorDetailById query = new GetActorDetailById(_context, _mapper);
            query.ActorId = actor.Id;

            FluentActions.
                Invoking(() => query.Handle()).Invoke();
        }
    }
}