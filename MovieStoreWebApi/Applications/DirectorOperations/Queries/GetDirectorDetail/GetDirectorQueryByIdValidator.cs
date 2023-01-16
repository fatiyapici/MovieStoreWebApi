using FluentValidation;

namespace MovieStoreWebApi.Applications.DirectorOperations.Queries.GetDirectorDetailById
{
    public class GetDirectorDetailByIdValidator : AbstractValidator<GetDirectorDetailById>
    {
        public GetDirectorDetailByIdValidator()
        {
            RuleFor(x => x.DirectorId).NotEmpty().WithMessage("Director Id boş olamaz.");
        }
    }
}
