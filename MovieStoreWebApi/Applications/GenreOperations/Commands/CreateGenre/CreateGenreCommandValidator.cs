using FluentValidation;

namespace MovieStoreWebApi.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty().WithMessage("Tür adi boş birakilamaz.");
        }
    }
}