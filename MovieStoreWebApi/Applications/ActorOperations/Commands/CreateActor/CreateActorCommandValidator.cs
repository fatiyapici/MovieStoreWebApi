using FluentValidation;

namespace MovieStoreWebApi.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommandValidator : AbstractValidator<CreateActorCommand>
    {
        public CreateActorCommandValidator()
        {
            RuleFor(x => x.Model.Name).NotEmpty().WithMessage("Ad boş olamaz");
            RuleFor(x => x.Model.Surname).NotEmpty().WithMessage("Soyad boş olamaz");
        }
    }
}