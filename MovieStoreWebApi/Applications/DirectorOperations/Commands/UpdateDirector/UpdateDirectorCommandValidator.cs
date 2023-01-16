using FluentValidation;

namespace MovieStoreWebApi.Applications.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommandValidator : AbstractValidator<UpdateDirectorCommand>
    {
        public UpdateDirectorCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(1);
            RuleFor(command => command.Model.Surname).NotEmpty().MinimumLength(1);
        }
    }
}