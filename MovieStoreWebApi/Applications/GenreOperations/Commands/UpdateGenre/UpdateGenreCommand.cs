using MovieStoreWebApi.DbOperations;

namespace MovieStoreWebApi.Applications.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public UpdateGenreViewModel Model { get; set; }
        public int Id { get; set; }
        private readonly IMovieStoreDbContext _context;
        public UpdateGenreCommand(IMovieStoreDbContext context, int id)
        {
            _context = context;
            Id = id;
        }
        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == Id);
            if (genre is null)
            {
                throw new InvalidOperationException("Tür bulunamadi.");
            }
            genre.Name = Model.Name;
            _context.Genres.Update(genre);
            _context.SaveChanges();
        }
    }
    public class UpdateGenreViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}