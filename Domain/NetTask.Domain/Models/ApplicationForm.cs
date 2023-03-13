namespace NetTask.Domain.Models;

/// <summary>
/// Application form for a program.
/// </summary>
public class ApplicationForm: Entity
{
    /// <summary>
    /// Foreign key of the parent program.
    /// </summary>
    public Guid ProgramId { get; set; }

    /// <summary>
    /// Cover photo for the form.
    /// </summary>
    public string? CoverPhotoId { get; set; }

    /// <summary>
    /// Personal information questions segment.
    /// </summary>
    public IList<ApplicationQuestion> PersonalInfo { get; set; }

    /// <summary>
    /// Profile questions segment.
    /// </summary>
    public IList<ApplicationQuestion> Profile { get; set; }

    /// <summary>
    /// Additional questions segment.
    /// </summary>
    public IList<ApplicationQuestion>? AdditionalQuestions { get; set; }
}
