using MovieStoreWebApi.DbOperations;

namespace MovieStoreWebApi.Applications.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommand
    {
        public const string ExceptionMessage = "Guncellenecek film bulunamadi.";
        public UpdateMovieViewModel Model { get; set; }
        public int MovieId { get; set; }

        private readonly IMovieStoreDbContext _context;

        public UpdateMovieCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == MovieId);
            if (movie is null)
                throw new InvalidOperationException(ExceptionMessage);

            movie.Price = Model.Price != default ? Model.Price : movie.Price;

            _context.SaveChanges();
        }
        
        public class UpdateMovieViewModel
        {
            public decimal Price { get; set; }
        }
    }
}