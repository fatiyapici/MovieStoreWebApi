using FluentValidation;
using MovieStoreWebApi.Applications.GenreOperations.Commands.DeleteGenre;

namespace MovieStoreWebApi.Applications.GenreOperations.Commands.GenreDirector
{
    public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
        }
    }
}