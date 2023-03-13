namespace NetTask.Application.Dtos.Program;

public class CreateProgramDto
{
    public string Title { get; set; }
    public string? Summary { get; set; }
    public string Description { get; set; }
    public IList<string>? KeySkills { get; set; }
    public string? Benefits { get; set; }
    public string? Criteria { get; set; }
    public CreateAdditionalProgramInformationDto AdditionalInfo { get; set; }
}
