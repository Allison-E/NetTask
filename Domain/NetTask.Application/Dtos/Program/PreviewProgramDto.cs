using NetTask.Application.Dtos.ApplicationForm;
using NetTask.Application.Dtos.Workflow;

namespace NetTask.Application.Dtos.Program;
public class PreviewProgramDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string? Summary { get; set; }
    public string Description { get; set; }
    public IList<string>? KeySkills { get; set; }
    public string? Benefits { get; set; }
    public string? Criteria { get; set; }
    public DateTime Created { get; set; }
    public DateTime Modified { get; set; }
    public ReadAdditionalProgramInformationDto AdditionalInfo { get; set; }
    public ReadApplicationFormDto? ApplicationForm { get; set; }
    public ReadWorkflowDto? Workflow { get; set; }
}
