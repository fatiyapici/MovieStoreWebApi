using MovieStoreWebApi.DbOperations;

namespace MovieStoreWebApi.Applications.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommand
    {
        public int MovieId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        public DeleteMovieCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var movie = _dbContext.Movies.SingleOrDefault(x => x.Id == MovieId);
            if (movie is null)
                throw new InvalidOperationException("Silinecek film bulunamadi.");
            _dbContext.Movies.Remove(movie);
            _dbContext.SaveChanges();
        }
    }
}