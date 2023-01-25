using FluentValidation;
using MovieStoreWebApi.Applications.DirectorOperations.Commands.DeleteActor;

namespace MovieStoreWebApi.ActorOperations.Commands.UpdateActor
{
    public class DeleteActorCommandValidator : AbstractValidator<DeleteActorCommand>
    {
        public DeleteActorCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id gerekli").GreaterThan(0).WithMessage("Id 0'dan büyük olmalidir.");
        }
    }
}