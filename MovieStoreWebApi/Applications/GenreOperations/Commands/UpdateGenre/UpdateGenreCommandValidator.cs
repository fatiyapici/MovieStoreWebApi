using FluentValidation;
using MovieStoreWebApi.Applications.GenreOperations.Commands.UpdateGenre;

namespace MovieStoreWebApi.Application.Genres.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Genre Id boş birakilamaz.");
            RuleFor(x => x.Model.Name).NotEmpty().WithMessage("Genre adi boş birakilamaz.");
        }
    }
}
