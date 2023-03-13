using NetTask.Application.Dtos.Program;

namespace NetTask.Application.Features.Program.Command.Validators;
internal sealed class CreateAdditionalProgramInformationDtoValidator: AbstractValidator<CreateAdditionalProgramInformationDto>
{
    private readonly DateTime _endOfToday = DateTime.UtcNow
        .Date
        .AddDays(1)
        .Subtract(new TimeSpan(0, 0, 0, 0, 1));

    public CreateAdditionalProgramInformationDtoValidator()
    {
        RuleFor(c => c.TypeId)
            .IsInEnum().WithMessage(ValidationErrorMessages.ShouldBeInEnum(typeof(ProgramTypes)));

        RuleFor(c => c.ApplicationCloseDate)
            .GreaterThan(_endOfToday).WithMessage(ValidationErrorMessages.DateShouldBeInTheFuture);

        RuleFor(c => c.Location)
            .SetValidator(new CreateProgramLocationDtoValidator());

        RuleFor(c => c.MinQualificationId)
            .IsInEnum().When(c => c.MinQualificationId != null).WithMessage(ValidationErrorMessages.ShouldBeInEnum(typeof(Qualifications)));

        RuleFor(c => c.MaxApplications)
            .GreaterThan(0).WithMessage(ValidationErrorMessages.ShouldBeGreaterThan(0));
    }
}
