using AutoMapper;
using MovieStoreWebApi.Controllers.Queries.GetMovies;
using MovieStoreWebApi.Entities;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MoviesViewModel>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}