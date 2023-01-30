using MovieStoreWebApi.DbOperations;

namespace MovieStoreWebApi.Applications.DirectorOperations.Commands.UpdateActor
{
    public class UpdateActorCommand
    {
        public UpdateActorViewModel Model { get; set; }
        public int Id { get; set; }
        private readonly IMovieStoreDbContext _context;
        public UpdateActorCommand(IMovieStoreDbContext context, int id)
        {
            _context = context;
            Id = id;
        }
        public void Handle()
        {
            var actor = _context.Actors.SingleOrDefault(x => x.Id == Id);
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