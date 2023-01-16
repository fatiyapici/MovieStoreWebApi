using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.Applications.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommand
    {
        public CreateDirectorModel Model { get; set; }
        private readonly IMovieStoreDbContext _context;
        public CreateDirectorCommand(IMovieStoreDbContext context, AutoMapper.IMapper _mapper)
        {
            _context = context;
        }
        public void Handle()
        {
            var director = _context.Directors.SingleOrDefault(x => x.Person.Name == Model.Name && x.Person.Surname == Model.Surname);
            if (director != null)
            {
                throw new InvalidOperationException("Yönetmen zaten mevcut.");
            }
            director = new Director();
            director.Person = new Person()
            {
                Name = Model.Name,
                Surname = Model.Surname
            };
            _context.Directors.Add(director);
            _context.SaveChanges();
        }
    }

    public class CreateDirectorModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
