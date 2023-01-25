using FluentValidation;
using MovieStoreWebApi.Applications.DirectorOperations.Commands.UpdateActor;

namespace MovieStoreWebApi.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommandValidator : AbstractValidator<UpdateActorCommand>
    {
        public UpdateActorCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id gerekli").GreaterThan(0).WithMessage("Id 0'dan büyük olmalidir.");
            RuleFor(x => x.Model.Name).NotEmpty().WithMessage("İsim gerekli");
            RuleFor(x => x.Model.Surname).NotEmpty().WithMessage("Soyisim gerekli");
        }
    }
}