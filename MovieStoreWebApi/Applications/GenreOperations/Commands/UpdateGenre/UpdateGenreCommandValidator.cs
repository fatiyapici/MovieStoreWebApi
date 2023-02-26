using FluentValidation;

namespace MovieStoreWebApi.Applications.GenreOperations.Commands.UpdateGenre
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
