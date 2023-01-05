using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        // public List<MovieViewModel> Handle()
        // {
        //     var movieList = _dbContext.Movies.Include(x => x.GenreId).OrderBy(x => x.Id).ToList();
        //     List<MovieViewModel> vm = _mapper.Map<List<MovieViewModel>>(movieList);
        //     return vm;
        // }
    }

    public class MovieViewModel
    {
        public string Name { get; set; }
        public int MyProperty { get; set; }
    }
}

