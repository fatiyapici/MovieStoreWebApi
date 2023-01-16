using MovieStoreWebApi.DbOperations;

namespace MovieStoreWebApi.Applications.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommand
    {
        public int Id { get; set; }
        private readonly IMovieStoreDbContext _context;
        public DeleteDirectorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var director = _context.Directors.Find(Id);
            if (director is null)
            {
                throw new InvalidOperationException("Yönetmen bulunamadi.");
            }
            _context.Directors.Remove(director);
            _context.SaveChanges();
        }
    }
}
