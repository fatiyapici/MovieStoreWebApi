using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.DbOperations;

namespace MovieStoreWebApi.Applications.DirectorOperations.Queries.GetDirectorDetailById
{
    public class GetDirectorDetailById
    {
        public int DirectorId { get; set; }
        private readonly IMovieStoreDbContext _context;
        public GetDirectorDetailById(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public DirectorDetailViewModel Handle()
        {
            var director = _context.Directors.Include(x => x.Person).SingleOrDefault(x => x.Id == DirectorId);
            if (director is null)
            {
                return null;
            }
            var directorViewModel = new DirectorDetailViewModel
            {
                Id = director.Id,
                Name = director.Person.Name,
                Surname = director.Person.Surname
            };
            return directorViewModel;
        }
        public class DirectorDetailViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
        }
    }
}
