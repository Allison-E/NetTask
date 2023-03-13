using NetTask.Application.Dtos.ApplicationForm.Questions;

namespace NetTask.Application.Dtos.ApplicationForm;
public class ReadApplicationFormDto
{
    public string? CoverPhotoId { get; set; }
    public List<ReadApplicationFormPersonalInformationQuestionDto> PersonalInfo { get; set; }
    public List<ReadApplicationFormProfileQuestionDto> Profile { get; set; }
    public List<ReadApplicationFormAdditionalQuestionDto>? AdditionalQuestions { get; set; }
}
