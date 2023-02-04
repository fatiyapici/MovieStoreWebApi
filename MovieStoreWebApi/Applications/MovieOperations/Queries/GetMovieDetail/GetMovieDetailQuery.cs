using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.DbOperations;

namespace MovieStoreWebApi.Applications.MovieOperations.Queries.GetMovieDetail
{
    public class GetMovieDetailQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int MovieId { get; set; }
        public GetMovieDetailQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public MovieDetailViewModel Handle()
        {
            var movie = _dbContext.Movies
                .Include(g => g.Genres).ThenInclude(g => g.Genre)
                .Include(a => a.Actors).ThenInclude(a => a.Actor).ThenInclude(a => a.Person)
                .Include(d => d.Directors).ThenInclude(d => d.Director).ThenInclude(d => d.Person)
                .Where(movie => movie.Id == MovieId)
                .SingleOrDefault();
            if (movie is null)
            {
                throw new InvalidOperationException("Film Bulunamadi.");
            }
            MovieDetailViewModel vm = _mapper.Map<MovieDetailViewModel>(movie);
            return vm;
        }
    }

    public class MovieDetailViewModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ReleaseDate { get; set; }
        public List<string> Directors { get; set; }
        public virtual List<string> Genres { get; set; }
        public virtual List<string> Actors { get; set; }
    }
}
