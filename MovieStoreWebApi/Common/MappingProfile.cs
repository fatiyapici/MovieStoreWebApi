using AutoMapper;
using MovieStoreWebApi.Applications.DirectorOperations.Commands.CreateDirector;
using MovieStoreWebApi.Applications.DirectorOperations.Commands.UpdateActor;
using MovieStoreWebApi.Applications.DirectorOperations.Commands.UpdateDirector;
using MovieStoreWebApi.Applications.DirectorOperations.GetDirectors;
using MovieStoreWebApi.Applications.MovieOperations.Queries.GetMovieDetail;
using MovieStoreWebApi.Controllers.Queries.GetMovies;
using MovieStoreWebApi.Entities;
using static MovieStoreWebApi.ActorOperations.Commands.CreateActor.CreateActorCommand;
using static MovieStoreWebApi.ActorOperations.Queries.GetActorDetail.GetActorDetailQuery;
using static MovieStoreWebApi.ActorOperations.Queries.GetActors.GetActorsQuery;
using static MovieStoreWebApi.Applications.DirectorOperations.Queries.GetDirectorDetailById.GetDirectorDetailById;
using static MovieStoreWebApi.Applications.MovieOperations.Commands.CreateMovie.CreateMovieCommand;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region MovieMaps

            //GetMovies
            CreateMap<Movie, MoviesViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate.Year))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres.Select(x => x.Genre.Name).ToList()))
                .ForMember(dest => dest.Directors, opt => opt.MapFrom(src => src.Directors.Select(x => x.Director.Person.Name + " " + x.Director.Person.Surname).ToList()))
                .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.Actors.Select(x => x.Actor.Person.Name + " " + x.Actor.Person.Surname).ToList()))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price)).ReverseMap();

            //GetMovieDetail
            CreateMap<Movie, MovieDetailViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate.Year))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres.Select(x => x.Genre.Name).ToList()))
                .ForMember(dest => dest.Directors, opt => opt.MapFrom(src => src.Directors.Select(x => x.Director.Person.Name + " " + x.Director.Person.Surname)))
                .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.Actors.Select(x => x.Actor.Person.Name + " " + x.Actor.Person.Surname).ToList()))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price)).ReverseMap();

            //CreateMovie
            CreateMap<CreateMovieModel, Movie>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Directors, opt => opt.MapFrom(src => src.Directors.Select(id => new MovieDirector { DirectorId = id })))
                .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.Actors.Select(id => new MovieActor { ActorId = id })))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres.Select(id => new MovieGenre { GenreId = id })));

            #endregion

            #region DirectorMaps

            //GetDirectors
            CreateMap<Director, DirectorsViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Person.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Person.Surname));

            //GetDirectorDetail
            CreateMap<Director, DirectorDetailViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Person.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Person.Surname));

            //CreateDirector
            CreateMap<CreateDirectorModel, Person>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname));

            //UpdateDirector
            CreateMap<UpdateDirectorModel, Person>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname));

            #endregion

            #region ActorMaps

            //CreateActor
            CreateMap<CreateActorModel, Person>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname));

            //UpdateActor
            CreateMap<UpdateActorModel, Person>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname));

            //GetActors
            CreateMap<MovieActor, ActorsViewModel>().ReverseMap();

            //GetActorsDetail
            CreateMap<MovieActor, GetActorDetailViewModel>().ReverseMap();

            #endregion


        }
    }
}