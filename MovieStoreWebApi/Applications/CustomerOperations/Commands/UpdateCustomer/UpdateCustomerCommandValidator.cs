using FluentValidation;
using MovieStoreWebApi.Applications.CustomerOperations.UpdateCustomer;

namespace MovieStoreWebApi.Applications.CustomerOperations.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(command => command.Model.Email).NotEmpty().EmailAddress();
            RuleFor(command => command.Model.Password).NotEmpty().MinimumLength(6);
            RuleFor(command => command.Model.NewPassword).NotEmpty().MinimumLength(6);
        }
    }
}