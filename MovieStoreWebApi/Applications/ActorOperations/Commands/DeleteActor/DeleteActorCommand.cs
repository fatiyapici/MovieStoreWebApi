using MovieStoreWebApi.DbOperations;

namespace MovieStoreWebApi.Applications.DirectorOperations.Commands.DeleteActor
{
    public class DeleteActorCommand
    {
        public int Id { get; set; }
        private readonly IMovieStoreDbContext _context;
        public DeleteActorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var actor = _context.Actors.Find(Id);
            if (actor is null)
            {
                throw new InvalidOperationException("Oyuncu bulunamadi.");
            }
            _context.Actors.Remove(actor);
            _context.SaveChanges();
        }
    }
}