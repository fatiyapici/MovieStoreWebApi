using MovieStoreWebApi.DbOperations;

namespace MovieStoreWebApi.Applications.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        public int Id { get; set; }
        public const string ExceptionMessage = "Tür bulunamadi.";

        private readonly IMovieStoreDbContext _context;

        public DeleteGenreCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var genre = _context.Genres.Find(Id);
            if (genre is null)
            {
                throw new InvalidOperationException(ExceptionMessage);
            }
            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }
    }
}