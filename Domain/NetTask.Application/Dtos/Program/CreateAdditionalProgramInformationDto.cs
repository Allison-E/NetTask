namespace NetTask.Application.Dtos.Program;

public class CreateAdditionalProgramInformationDto
{
    public ProgramTypes TypeId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime ApplicationOpenDate { get; set; }
    public DateTime ApplicationCloseDate { get; set; }
    public string? Duration { get; set; }
    public CreateProgramLocationDto Location { get; set; }
    public Qualifications? MinQualificationId { get; set; }
    public int? MaxApplications { get; set; }
}
