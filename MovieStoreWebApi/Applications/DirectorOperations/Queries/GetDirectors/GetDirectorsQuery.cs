using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
            var directors = _context.Directors.Include(x => x.Person).ToList();
            var directorViewModels = _mapper.Map<List<DirectorsViewModel>>(directors);
            return directorViewModels;
        }
    }
    public class DirectorsViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}