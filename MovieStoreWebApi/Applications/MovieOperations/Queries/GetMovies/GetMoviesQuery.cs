using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.Applications.DirectorOperations.GetDirectors;
using MovieStoreWebApi.DbOperations;

namespace MovieStoreWebApi.Controllers.Queries.GetMovies
{
    public class GetMoviesQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMoviesQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public List<MoviesViewModel> Handle()
        {
            var movieList = _dbContext.Movies.Include(x => x.Genres).OrderBy(x => x.Id).ToList();
            List<MoviesViewModel> vm = _mapper.Map<List<MoviesViewModel>>(movieList);
            return vm;
        }
    }

    public class MoviesViewModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ReleaseDate { get; set; }
        public List<DirectorsViewModel> Directors { get; set; }
    }
}

