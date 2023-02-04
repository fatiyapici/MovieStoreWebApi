using AutoMapper;
using MovieStoreWebApi.DbOperations;

namespace MovieStoreWebApi.Applications.CustomerOperations.GetCustomers
{
    public class GetCustomersQuery
    {
        public readonly IMovieStoreDbContext _context;
        public readonly IMapper _mapper;

        public GetCustomersQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<GetCustomersViewModel> Handle()
        {
            var customerList = _context.Customers.ToList();

            List<GetCustomersViewModel> vm = _mapper.Map<List<GetCustomersViewModel>>(customerList);
            return vm;
        }
    }
    public class GetCustomersViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
    }
}