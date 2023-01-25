using AutoMapper;
using MovieStoreWebApi.DbOperations;

namespace MovieStoreWebApi.ActorOperations.Queries.GetActorDetail
{
    public class GetActorDetailQuery
    {
        public int ActorId { get; set; }
        public readonly IMovieStoreDbContext _context;
        public readonly IMapper _mapper;

        public GetActorDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public GetActorDetailViewModel Handle()
        {
            var actor = _context.MovieActors.SingleOrDefault(x => x.ActorId == ActorId);
            if (actor is null)
            {
                throw new InvalidOperationException("Aktör bulunamadi.");
            }
            return _mapper.Map<GetActorDetailViewModel>(actor);
        }
        public class GetActorDetailViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
        }
    }
}