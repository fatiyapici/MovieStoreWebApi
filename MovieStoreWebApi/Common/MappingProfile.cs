using AutoMapper;
using MovieStoreWebApi.Applications.MovieOperations.Queries.GetMovieDetail;
using MovieStoreWebApi.Controllers.Queries.GetMovies;
using MovieStoreWebApi.Entities;

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
        }
    }
}