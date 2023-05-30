using AutoMapper;
using Microsoft.Extensions.Configuration;
using MovieStoreWebApi.DbOperations;
using MovieStoreWebApi.TokenOperations.Models;

namespace WebApi.Applications.CustomerOperations.Commands.CreateToken
{
    public class CreateTokenCommand
    {
        public const string ExceptionMessage = "Kullanici adi-sifre hatali.";
        
        public CreateTokenModel Model { get; set; }
        
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
            var customer = _dbContext.Customers.FirstOrDefault(x => x.Email == Model.Email && x.Password == Model.Password);

            if (customer is null)
                throw new InvalidOperationException(ExceptionMessage);

            else
            {
                TokenHandler handler = new TokenHandler(_configuration);
                Token token = handler.CreateAccessToken(customer);

                customer.RefreshToken = token.RefreshToken;
                customer.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
                _dbContext.SaveChanges();

                return token;
            }
        }

        public class CreateTokenModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}