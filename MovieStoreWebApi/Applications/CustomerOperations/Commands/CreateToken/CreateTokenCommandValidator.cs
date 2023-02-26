using FluentValidation;

namespace MovieStoreWebApi.Applications.CustomerOperations.Commands.CreateToken
{
    public class CreateTokenCommandValidator : AbstractValidator<CreateTokenCommand>
    {
        public CreateTokenCommandValidator()
        {
            RuleFor(command => command.Model.Email).NotEmpty().EmailAddress();
            RuleFor(command => command.Model.Password).NotEmpty().MinimumLength(6);
        }
    }
}