namespace NetTask.Application.Features.Program.Command.Validators;
internal sealed class CreateProgramCommandValidator: AbstractValidator<CreateProgramCommand>
{
    public CreateProgramCommandValidator()
    {
        RuleFor(c => c.Program)
            .SetValidator(new CreateProgramDtoValidator());
    }
}
