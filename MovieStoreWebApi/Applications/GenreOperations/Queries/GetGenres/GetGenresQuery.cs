using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.DbOperations;

namespace MovieStoreWebApi.GenreOperations.Queries.GetGenres
{
    public class GetGenresQuery
    {
        public readonly IMovieStoreDbContext _context;
        public readonly IMapper _mapper;

        public GetGenresQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<GetGenresViewModel> Handle()
        {
            var genres = _context.Genres.ToList();
            List<GetGenresViewModel> genreList = _mapper.Map<List<GetGenresViewModel>>(genres);
            return genreList;
        }
        public class GetGenresViewModel
        {
            public string Name { get; set; }
        }
    }
}