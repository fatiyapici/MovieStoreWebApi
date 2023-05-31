using FluentValidation;
using MovieStoreWebApi.Applications.CustomerOperations.DeleteCustomer;

namespace MovieStoreWebApi.Validations.CustomerOperations.DeleteCustomer
{
    public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator()
        {
            //RuleFor(command => command.CustomerId).GreaterThan(0);
            RuleFor(command => command.Model.Email).NotEmpty().EmailAddress();
            RuleFor(command => command.Model.Password).NotEmpty().MinimumLength(6);
        }
    }
}
