namespace NetTask.Domain.Enums;

/// <summary>
/// Types of application questions.
/// </summary>
public enum ApplicationQuestionTypes
{
    /// <summary>
    /// A long paragraph question.
    /// </summary>
    Paragraph = 1,

    /// <summary>
    /// A short answer question.
    /// </summary>
    ShortAnswer,

    /// <summary>
    /// A question containing yes or no options.
    /// </summary>
    YesNo,

    /// <summary>
    /// A question containing a drop-down.
    /// </summary>
    DropDown,

    /// <summary>
    /// A question containing multiple choice options.
    /// </summary>
    MultipleChoice,

    /// <summary>
    /// A question whose answer is a date.
    /// </summary>
    Date,

    /// <summary>
    /// A question whose answer is a number.
    /// </summary>
    Number,

    /// <summary>
    /// A question that requires a file upload.
    /// </summary>
    FileUpload,

    /// <summary>
    /// A question that requires a video.
    /// </summary>
    Video,
}
