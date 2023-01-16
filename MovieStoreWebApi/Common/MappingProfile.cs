using AutoMapper;
using MovieStoreWebApi.Applications.DirectorOperations.Commands.CreateDirector;
using MovieStoreWebApi.Applications.DirectorOperations.Commands.UpdateDirector;
using MovieStoreWebApi.Applications.DirectorOperations.GetDirectors;
using MovieStoreWebApi.Applications.DirectorOperations.Queries.GetDirectorDetailById;
using MovieStoreWebApi.Applications.MovieOperations.Queries.GetMovieDetail;
using MovieStoreWebApi.Controllers.Queries.GetMovies;
using MovieStoreWebApi.Entities;
using static MovieStoreWebApi.Applications.DirectorOperations.Queries.GetDirectorDetailById.GetDirectorDetailById;
using static MovieStoreWebApi.Applications.MovieOperations.Commands.CreateMovie.CreateMovieCommand;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MoviesViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate.Year))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres.Select(x => x.Genre.Name).ToList()))
                .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.Actors.Select(x => x.Actor.Person.Name + " " + x.Actor.Person.Surname).ToList()))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price)).ReverseMap();

            CreateMap<Movie, MovieDetailViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate.Year))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres.Select(x => x.Genre.Name).ToList()))
                .ForMember(dest => dest.Directors, opt => opt.MapFrom(src => src.Directors.Select(x => x.Director.Person.Name + " " + x.Director.Person.Surname)))
                .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.Actors.Select(x => x.Actor.Person.Name + " " + x.Actor.Person.Surname).ToList()))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price)).ReverseMap();

            CreateMap<CreateMovieModel, Movie>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ReleaseDate, opt => opt.MapFrom(src => src.ReleaseDate))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));
            // .ForMember(dest => dest.Directors, opt => opt.MapFrom(src => src.DirectorsIds .Select(id => new MovieDirector { DirectorId = id })))
            // .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.ActorsIds.Select(id => new MovieActor { ActorId = id })))
            // .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.GenresIds.Select(id => new MovieGenre { GenreId = id })));

            CreateMap<CreateDirectorModel, Director>()
                .ForMember(dest => dest.Person.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Person.Surname, opt => opt.MapFrom(src => src.Surname));

            CreateMap<UpdateDirectorModel, Director>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Person.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Person.Surname, opt => opt.MapFrom(src => src.Surname));

            CreateMap<Director, DirectorViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Person.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Person.Surname));

            CreateMap<GetDirectorDetailById, DirectorViewModel>();

            CreateMap<GetDirectorsQuery, DirectorViewModel>();


        }
    }
}