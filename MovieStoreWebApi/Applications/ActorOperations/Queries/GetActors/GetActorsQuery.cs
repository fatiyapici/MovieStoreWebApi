using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.DbOperations;

namespace MovieStoreWebApi.Applications.ActorOperations.Queries.GetActors
{
    public class GetActorsQuery
    {
        public readonly IMovieStoreDbContext _context;
        public readonly IMapper _mapper;

        public GetActorsQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<ActorsViewModel> Handle()
        {
            var actors = _context.Actors.Include(x => x.Person).ToList();
            List<ActorsViewModel> actorList = _mapper.Map<List<ActorsViewModel>>(actors);
            return actorList;
        }
        public class ActorsViewModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
        }
    }
}