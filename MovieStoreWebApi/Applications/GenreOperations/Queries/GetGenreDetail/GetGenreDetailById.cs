using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.DbOperations;

namespace MovieStoreWebApi.Applications.GenreOperations.Queries.GetGenreDetailById
{
    public class GetGenreDetailById
    {
        public int GenreId { get; set; }
        private readonly IMovieStoreDbContext _context;
        public GetGenreDetailById(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public GenreDetailViewModel Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);
            if (genre is null)
            {
                return null;
            }
            var genreViewModel = new GenreDetailViewModel
            {
                Id = genre.Id,
                Name = genre.Name,
            };
            return genreViewModel;
        }
        public class GenreDetailViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
