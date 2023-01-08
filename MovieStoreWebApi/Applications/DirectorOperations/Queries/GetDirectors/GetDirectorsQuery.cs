using AutoMapper;
using MovieStoreWebApi.DbOperations;

namespace MovieStoreWebApi.Applications.DirectorOperations.GetDirectors
{
    public class GetDirectorsQuery
    {
        public readonly IMovieStoreDbContext _context;
        public readonly IMapper _mapper;

        public GetDirectorsQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<DirectorsViewModel> Handle()
        {
            var directors = _context.Directors;
            List<DirectorsViewModel> directorsList = _mapper.Map<List<DirectorsViewModel>>(directors);
            return directorsList;
        }
    }
    public class DirectorsViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}