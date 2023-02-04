using FluentValidation;
using MovieStoreWebApi.Applications.CustomerOperations.GetCustomerDetail;

namespace MovieStoreWebApi.CustomerOperations.Queries.GetCustomerDetail
{
    public class GetCustomerDetailByIdValidator : AbstractValidator<GetCustomerDetailById>
    {
        public GetCustomerDetailByIdValidator()
        {
            RuleFor(query => query.CustomerId).GreaterThan(0);
        }
    }
}