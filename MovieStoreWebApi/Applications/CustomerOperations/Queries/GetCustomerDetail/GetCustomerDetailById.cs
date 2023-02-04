using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreWebApi.DbOperations;

namespace MovieStoreWebApi.Applications.CustomerOperations.GetCustomerDetail
{
    public class GetCustomerDetailById
    {
        public int CustomerId { get; set; }
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomerDetailById(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public GetCustomerDetailViewModel Handle()
        {
            var customer = _context.Customers
            .Include(g => g.CustomerOrders).ThenInclude(g => g.Order).ThenInclude(o=>o.Movie)
            .Include(g => g.FavoriteGenres).ThenInclude(g => g.Genre)
            .SingleOrDefault(x => x.Id == CustomerId);
            if (customer is null)
            {
                throw new InvalidOperationException("Müşteri bulunamadi.");
            }
            GetCustomerDetailViewModel vm = _mapper.Map<GetCustomerDetailViewModel>(customer);
            return vm;
        }
    }
    public class GetCustomerDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public virtual List<string> PurchasedFilms { get; set; }
        public virtual List<string> FavoriteGenres { get; set; }
    }
}