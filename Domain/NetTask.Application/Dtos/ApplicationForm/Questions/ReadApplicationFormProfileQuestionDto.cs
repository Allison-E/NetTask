using NetTask.Application.Dtos.ApplicationForm.Questions.Common;

namespace NetTask.Application.Dtos.ApplicationForm.Questions;

public class ReadApplicationFormProfileQuestionDto: IReadQuestionBaseDto, IHideable
{
    public ApplicationQuestionTypes TypeId { get; set; }
    public string Type => TypeId.ToString();
    public string Message { get; set; }
    public bool IsHidden { get; set; }
    public bool IsMandatory { get; set; }
    public object? AdditionalInfo { get; set; }
}
