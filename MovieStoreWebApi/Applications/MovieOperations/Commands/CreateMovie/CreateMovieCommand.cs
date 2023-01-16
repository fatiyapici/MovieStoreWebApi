using AutoMapper;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.Entities;

namespace MovieStoreWebApi.Applications.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommand
    {
        public CreateMovieModel Model { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateMovieCommand(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var movie = _dbContext.Movies.SingleOrDefault(x => x.Name == Model.Name);
            if (movie is not null)
                throw new InvalidOperationException("Film zaten mevcut.");
            movie = _mapper.Map<Movie>(Model);


            if (Model.Directors != null)
            {
                for (int i = 0; i < Model.Directors.Count; i++)
                {
                    var directorId = Model.Directors[i];
                    var director = _dbContext.Directors.SingleOrDefault(x => x.Id == directorId);
                    if (director == null)
                        continue;

                    movie.Directors.Add(new MovieDirector()
                    {
                        MovieId = movie.Id,
                        DirectorId = director.Id
                    });
                }
            }

            if (Model.Actors != null)
            {
                Model.Actors.Select(actorId =>
                    _dbContext.Actors.SingleOrDefault(ac => ac.Id == actorId) != null ?
                    _dbContext.MovieActors.Add(new MovieActor()
                    {
                        ActorId = actorId,
                        MovieId = movie.Id
                    }) : null);
            }
            _dbContext.Movies.Add(movie);
            _dbContext.SaveChanges();
        }

        public class CreateMovieModel
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string ReleaseDate { get; set; }
            public List<int> Directors { get; set; }
            public List<int> Genres { get; set; }
            public List<int> Actors { get; set; }
        }
    }
}