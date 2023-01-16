using FluentValidation;

namespace MovieStoreWebApi.Applications.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommandValidator : AbstractValidator<DeleteDirectorCommand>
    {
        public DeleteDirectorCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
        }
    }
}