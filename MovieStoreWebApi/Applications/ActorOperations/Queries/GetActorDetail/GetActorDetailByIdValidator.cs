using FluentValidation;

namespace MovieStoreWebApi.ActorOperations.Queries.GetActorDetail
{
    public class GetActorDetailByIdValidator : AbstractValidator<GetActorDetailById>
    {
        public GetActorDetailByIdValidator()
        {
            RuleFor(query => query.ActorId).GreaterThan(0);
        }
    }
}