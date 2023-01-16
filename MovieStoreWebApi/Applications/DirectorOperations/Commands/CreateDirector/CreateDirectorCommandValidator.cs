using FluentValidation;

namespace MovieStoreWebApi.Applications.DirectorOperations.Commands.CreateDirector
{
    public class CreateDirectorCommandValidator : AbstractValidator<CreateDirectorCommand>
    {
        public CreateDirectorCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(1);
            RuleFor(command => command.Model.Surname).NotEmpty().MinimumLength(1);
        }
    }
}