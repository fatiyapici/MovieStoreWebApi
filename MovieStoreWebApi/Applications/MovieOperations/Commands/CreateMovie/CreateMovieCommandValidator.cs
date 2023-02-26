using FluentValidation;

namespace MovieStoreWebApi.Applications.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieCommandValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty().WithMessage("Film adi boş olamaz.");
            RuleFor(x => x.Model.Price).GreaterThanOrEqualTo(0).WithMessage("Film fiyati 0'dan büyük olmalidir.");
            RuleFor(x => x.Model.ReleaseDate).NotEmpty().WithMessage("Film yayin tarihi boş olamaz.");
        }
    }
}