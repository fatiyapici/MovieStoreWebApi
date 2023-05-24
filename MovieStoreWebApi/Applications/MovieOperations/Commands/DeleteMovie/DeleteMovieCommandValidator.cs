using FluentValidation;

namespace MovieStoreWebApi.Applications.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommandValidator : AbstractValidator<DeleteMovieCommand>
    {
        public DeleteMovieCommandValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}