using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.DbOperations;

namespace MovieStoreWebApi.Applications.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommand
    {
        public int ActorId { get; set; }
        public UpdateActorViewModel Model { get; set; }
        private readonly IMovieStoreDbContext _context;
        public UpdateActorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var actor = _context.Actors
            .Include(g => g.Person)
            .SingleOrDefault(x => x.Id == ActorId);
            if (actor is null)
            {
                throw new InvalidOperationException("Oyuncu bulunamadi.");
            }
            actor.Person.Name = Model.Name;
            actor.Person.Surname = Model.Surname;
            _context.Actors.Update(actor);
            _context.SaveChanges();
        }
    }
    public class UpdateActorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}