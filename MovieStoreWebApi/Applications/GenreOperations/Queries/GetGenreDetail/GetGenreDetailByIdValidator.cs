using FluentValidation;

namespace MovieStoreWebApi.Applications.GenreOperations.Queries.GetGenreDetailById
{
    public class GetGenreDetailByIdValidator : AbstractValidator<GetGenreDetailById>
    {
        public GetGenreDetailByIdValidator()
        {
            RuleFor(x => x.GenreId).NotEmpty().WithMessage("Genre id boş olamaz.");
        }
    }
}
