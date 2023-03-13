using NetTask.Application.Dtos.Program;

namespace NetTask.Application.Features.Program.Command.Validators;
internal sealed class CreateProgramDtoValidator: AbstractValidator<CreateProgramDto>
{
    public CreateProgramDtoValidator()
    {
        RuleFor(p => p.Title)
            .NotEmpty().WithMessage(ValidationErrorMessages.ShouldNotBeEmpty);

        RuleFor(p => p.Description)
            .NotEmpty().WithMessage(ValidationErrorMessages.ShouldNotBeEmpty);

        RuleFor(p => p.AdditionalInfo)
            .SetValidator(new CreateAdditionalProgramInformationDtoValidator());
    }
}
