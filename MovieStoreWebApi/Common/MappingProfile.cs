using AutoMapper;
using MovieStoreWebApi.Entities;
using MovieStoreWebApi.Applications.ActorOperations.Commands.UpdateActor;
using MovieStoreWebApi.Applications.CustomerOperations.GetCustomerDetail;
using MovieStoreWebApi.Applications.CustomerOperations.GetCustomers;
using MovieStoreWebApi.Applications.DirectorOperations.Commands.CreateDirector;
using MovieStoreWebApi.Applications.DirectorOperations.Commands.UpdateDirector;
using MovieStoreWebApi.Applications.DirectorOperations.GetDirectors;
using MovieStoreWebApi.Applications.GenreOperations.Commands.UpdateGenre;
using MovieStoreWebApi.Applications.MovieOperations.Queries.GetMovies;
using MovieStoreWebApi.Applications.MovieOperations.Queries.GetMovieDetail;
using static MovieStoreWebApi.Applications.ActorOperations.Commands.CreateActor.CreateActorCommand;
using static MovieStoreWebApi.Applications.ActorOperations.Queries.GetActorDetail.GetActorDetailById;
using static MovieStoreWebApi.Applications.ActorOperations.Queries.GetActors.GetActorsQuery;
using static MovieStoreWebApi.Applications.DirectorOperations.Queries.GetDirectorDetailById.GetDirectorDetailById;
using static MovieStoreWebApi.Applications.GenreOperations.Commands.CreateGenre.CreateGenreCommand;
using static MovieStoreWebApi.Applications.GenreOperations.Queries.GetGenreDetailById.GetGenreDetailById;
using static MovieStoreWebApi.Applications.GenreOperations.Queries.GetGenres.GetGenresQuery;
using static MovieStoreWebApi.Applications.MovieOperations.Commands.CreateMovie.CreateMovieCommand;
using static MovieStoreWebApi.CustomerOperations.Commands.CreateCustomer.CreateCustomerCommand;
using static MovieStoreWebApi.Applications.CustomerOperations.UpdateCustomer.UpdateCustomerCommand;
using static MovieStoreWebApi.Applications.MovieOperations.Commands.UpdateMovie.UpdateMovieCommand;

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

            //UpdateMovie
            CreateMap<UpdateMovieViewModel, Movie>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));

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

            //GetActors
            CreateMap<Actor, ActorsViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Person.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Person.Surname));

            //GetActorsDetail
            CreateMap<Actor, GetActorDetailViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Person.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Person.Name));

            //CreateActor
            CreateMap<CreateActorViewModel, Person>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname));

            //UpdateActor
            CreateMap<UpdateActorViewModel, Person>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname));

            #endregion

            #region GenreMaps

            //GetGenres
            CreateMap<Genre, GetGenresViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            //GetGenreDetailById
            CreateMap<Genre, GenreDetailViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            //CreateGenre
            CreateMap<CreateGenreViewModel, Genre>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            //UpdateGenre
            CreateMap<UpdateGenreViewModel, Genre>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            #endregion

            #region CustomerMaps

            //GetCustomers
            CreateMap<Customer, GetCustomersViewModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

            //GetCustomerDetail
            CreateMap<Customer, GetCustomerDetailViewModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.FavoriteGenres, opt => opt.MapFrom(src => src.FavoriteGenres.Select(x => x.Genre.Name)))
                .ForMember(dest => dest.PurchasedFilms, opt => opt.MapFrom(src => src.CustomerOrders.Select(x => x.Order.Movie.Name)));

            //CreateCustomer
            CreateMap<CreateCustomerViewModel, Customer>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));

            //UpdateCustomer
            CreateMap<UpdateCustomerViewModel, Customer>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password));

            #endregion
        }
    }
}