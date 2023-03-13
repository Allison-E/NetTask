using NetTask.Application.Dtos.Program;

namespace NetTask.Application.Features.Program.Command.Validators;
internal sealed class CreateProgramDtoValidator: AbstractValidator<CreateProgramDto>
{
    public CreateProgramDtoValidator()
    {
        RuleFor(p => p.Title)
            .NotEmpty().WithMessage(ValidationErrorMessages.ShouldNotBeEmpty);

        RuleFor(p => p.Summary)
            .MaximumLength(250).When(p => !string.IsNullOrEmpty(p.Summary)).WithMessage(ValidationErrorMessages.HasMaximumLength(250));

        RuleFor(p => p.Description)
            .NotEmpty().WithMessage(ValidationErrorMessages.ShouldNotBeEmpty);

        RuleFor(p => p.AdditionalInfo)
            .SetValidator(new CreateAdditionalProgramInformationDtoValidator());
    }
}
