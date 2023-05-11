using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.DbOperations;

namespace MovieStoreWebApi.Applications.DirectorOperations.Queries.GetDirectorDetailById
{
    public class GetDirectorDetailById
    {
        public int DirectorId { get; set; }
        private readonly IMovieStoreDbContext _context;
        public readonly IMapper _mapper;
        public const string ExceptionMessage = "Yönetmen bulunamadi.";

        public GetDirectorDetailById(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public DirectorDetailViewModel Handle()
        {
            var director = _context.Directors.Find(DirectorId);
            if (director is null)
            {
                throw new InvalidOperationException(ExceptionMessage);
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
