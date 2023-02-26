using FluentValidation;
using MovieStoreWebApi.Applications.ActorOperations.Commands.DeleteActor;

namespace MovieStoreWebApi.Applications.ActorOperations.Commands.UpdateActor
{
    public class DeleteActorCommandValidator : AbstractValidator<DeleteActorCommand>
    {
        public DeleteActorCommandValidator()
        {
            RuleFor(x => x.ActorId).NotEmpty().WithMessage("Id gerekli").GreaterThan(0).WithMessage("Id 0'dan büyük olmalidir.");
        }
    }
}