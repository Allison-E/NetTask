using NetTask.Application.Dtos.Program;

namespace NetTask.Application.Features.Program.Command.Validators;
internal sealed class CreateProgramLocationDtoValidator: AbstractValidator<CreateProgramLocationDto>
{
    public CreateProgramLocationDtoValidator()
    {
        RuleFor(p => p.IsRemote)
            .NotEmpty().WithMessage(ValidationErrorMessages.ShouldNotBeEmpty);

        RuleFor(p => p.Address)
            .NotEmpty().WithMessage(ValidationErrorMessages.ShouldNotBeEmpty);
    }
}
