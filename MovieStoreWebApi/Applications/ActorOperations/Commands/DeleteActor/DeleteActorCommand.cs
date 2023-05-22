using MovieStoreWebApi.DbOperations;

namespace MovieStoreWebApi.Applications.ActorOperations.Commands.DeleteActor
{
    public class DeleteActorCommand
    {
        public int ActorId { get; set; }
        private readonly IMovieStoreDbContext _context;
        public const string ExceptionMessage = "Oyuncu bulunamadi.";

        public DeleteActorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var actor = _context.Actors.Find(ActorId);
            if (actor is null)
            {
                throw new InvalidOperationException(ExceptionMessage);
            }
            _context.Actors.Remove(actor);
            _context.SaveChanges();
        }
    }
}