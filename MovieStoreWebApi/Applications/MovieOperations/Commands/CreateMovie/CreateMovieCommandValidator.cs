using FluentValidation;

namespace MovieStoreWebApi.Applications.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(1);
            RuleFor(command => command.Model.Price).NotEmpty().GreaterThanOrEqualTo(0);
            RuleFor(command => command.Model.ReleaseDate).NotEmpty();
            // RuleFor(command => command.Model.Genres).NotEmpty();
            // RuleFor(command => command.Model.Directors).NotEmpty();
            // RuleFor(command => command.Model.Actors).NotEmpty();
        }
    }
}