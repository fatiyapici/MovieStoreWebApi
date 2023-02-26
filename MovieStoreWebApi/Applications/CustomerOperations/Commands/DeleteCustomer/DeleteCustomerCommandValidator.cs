using FluentValidation;
using MovieStoreWebApi.Applications.CustomerOperations.DeleteCustomer;

namespace MovieStoreWebApi.Validations.CustomerOperations.DeleteCustomer
{
    public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator()
        {
            RuleFor(command => command.CustomerId).GreaterThan(0);
        }
    }
}
