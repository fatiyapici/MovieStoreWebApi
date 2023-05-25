using AutoMapper;
using Microsoft.Extensions.Configuration;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.TokenOperations.Models;

namespace WebApi.Applications.CustomerOperations.Commands.CreateToken
{
    public class CreateTokenCommand
    {
        public CreateTokenModel Model { get; set; }
        public const string ExceptionMessage = "Kullanici adi-sifre hatali.";

        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public CreateTokenCommand(IMovieStoreDbContext dbContext, IMapper mapper, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        public Token Handle()
        {
            var user = _dbContext.Customers.FirstOrDefault(x => x.Email == Model.Email && x.Password == Model.Password);
            if (user is not null)
            {
                MovieStoreWebApi.TokenOperations.Models.TokenHandler handler = new MovieStoreWebApi.TokenOperations.Models.TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(user);

                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
                _dbContext.SaveChanges();
                
                return token;
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessage);
            }
        }

        public class CreateTokenModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}