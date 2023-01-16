using MovieStoreWebApi.DbOperations;

namespace MovieStoreWebApi.Applications.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommand
    {
        public UpdateDirectorModel Model { get; set; }
        public int Id { get; set; }
        private readonly IMovieStoreDbContext _context;
        public UpdateDirectorCommand(IMovieStoreDbContext context, int id)
        {
            _context = context;
            Id = id;
        }
        public void Handle()
        {
            var director = _context.Directors.SingleOrDefault(x => x.Id == Id);
            if (director is null)
            {
                throw new InvalidOperationException("Yönetmen bulunamadi.");
            }
            director.Person.Name = Model.Name;
            director.Person.Surname = Model.Surname;
            _context.Directors.Update(director);
            _context.SaveChanges();
        }
    }
    public class UpdateDirectorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}