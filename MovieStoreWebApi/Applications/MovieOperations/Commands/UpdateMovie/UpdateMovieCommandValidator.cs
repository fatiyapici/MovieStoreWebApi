using FluentValidation;

namespace MovieStoreWebApi.Applications.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
    {
        public UpdateMovieCommandValidator()
        {
            RuleFor(command => command.MovieId).GreaterThan(0);
            RuleFor(command => command.Model.Price).GreaterThanOrEqualTo(0);
        }
    }
}