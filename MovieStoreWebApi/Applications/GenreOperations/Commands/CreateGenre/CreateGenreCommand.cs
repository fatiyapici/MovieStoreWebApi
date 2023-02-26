using AutoMapper;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.Applications.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        public Genre Model { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateGenreCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var genre = _dbContext.Genres.SingleOrDefault(x => x.Name == Model.Name);
            if (genre != null)
                throw new InvalidOperationException("Bu tür zaten mevcut.");

            genre = _mapper.Map<Genre>(Model);
            _dbContext.Genres.Add(genre);
            _dbContext.SaveChanges();
        }

        public class CreateGenreViewModel
        {
            public string Name { get; set; }
        }
    }
}