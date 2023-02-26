using FluentValidation;

namespace MovieStoreWebApi.Applications.ActorOperations.Queries.GetActorDetail
{
    public class GetActorDetailByIdValidator : AbstractValidator<GetActorDetailById>
    {
        public GetActorDetailByIdValidator()
        {
            RuleFor(query => query.ActorId).GreaterThan(0);
        }
    }
}