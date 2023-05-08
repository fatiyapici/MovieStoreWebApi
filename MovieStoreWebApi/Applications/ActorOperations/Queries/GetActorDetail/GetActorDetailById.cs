using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.DbOperations;

namespace MovieStoreWebApi.Applications.ActorOperations.Queries.GetActorDetail
{
    public class GetActorDetailById
    {
        public int ActorId { get; set; }
        public readonly IMovieStoreDbContext _context;
        public readonly IMapper _mapper;
        public const string ExceptionMessage = "Aktör bulunamadi.";

        public GetActorDetailById(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public GetActorDetailViewModel Handle()
        {
            var actor = _context.Actors.Find(ActorId);
            if (actor is null)
            {
                throw new InvalidOperationException(ExceptionMessage);
            }
            var actorViewModel = new GetActorDetailViewModel
            {
                Id = actor.Id,
                Name = actor.Person.Name,
                Surname = actor.Person.Surname
            };
            return actorViewModel;
        }
        public class GetActorDetailViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
        }
    }
}