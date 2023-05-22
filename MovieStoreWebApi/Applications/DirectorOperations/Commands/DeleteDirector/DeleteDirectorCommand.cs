using MovieStoreWebApi.DbOperations;

namespace MovieStoreWebApi.Applications.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommand
    {
        public int DirectorId { get; set; }
        private readonly IMovieStoreDbContext _context;
        public const string ExceptionMessage = "Yönetmen bulunamadi.";

        public DeleteDirectorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var director = _context.Directors.Find(DirectorId);
            if (director is null)
            {
                throw new InvalidOperationException(ExceptionMessage);
            }
            _context.Directors.Remove(director);
            _context.SaveChanges();
        }
    }
}