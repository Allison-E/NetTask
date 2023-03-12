namespace NetTask.Application.Dtos.Program;
public class ReadAdditionalProgramInformationDto
{
    public ProgramTypes TypeId { get; set; }
    public string Type => TypeId.ToString();
    public DateTime? StartDate { get; set; }
    public DateTime ApplicationOpenDate { get; set; }
    public DateTime ApplicationCloseDate { get; set; }
    public string? Duration { get; set; }
    public ReadProgramLocationDto Location { get; set; }
    public Qualifications? MinQualificationId { get; set; }
    public string? MinQualification => MinQualificationId?.ToString();
    public int? MaxApplications { get; set; }
}
