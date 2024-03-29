using MovieStoreWebApi.DbOperations;

namespace MovieStoreWebApi.Applications.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommand
    {
        public const string ExceptionMessage = "Silinecek film bulunamadi.";
        public int Id { get; set; }

        private readonly IMovieStoreDbContext _dbContext;

        public DeleteMovieCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public void Handle()
        {
            var movie = _dbContext.Movies.Find(Id);
            if (movie is null)
                throw new InvalidOperationException(ExceptionMessage);

            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();
        }
    }
}