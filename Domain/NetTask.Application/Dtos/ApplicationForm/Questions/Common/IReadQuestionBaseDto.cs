namespace NetTask.Application.Dtos.ApplicationForm.Questions.Common;

public interface IReadQuestionBaseDto
{
    public ApplicationQuestionTypes TypeId { get; set; }
    public string Type => TypeId.ToString();
    public string Message { get; set; }
    public object? AdditionalInfo { get; set; }
}
