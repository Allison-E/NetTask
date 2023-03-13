namespace NetTask.Domain.Models;

/// <summary>
/// Additional information for a program.
/// </summary>
public class AdditionalProgramInformation
{
    /// <summary>
    /// Program type.
    /// </summary>
    public ProgramTypes Type { get; set; }

    /// <summary>
    /// Date the program starts.
    /// </summary>
    public DateTime? StartDate { get; set; }

    /// <summary>
    /// Date applications for the program can start coming <inheritdoc./>
    /// </summary>
    public DateTime ApplicationOpenDate { get; set; }

    /// <summary>
    /// Date applications for the program closes.
    /// </summary>
    public DateTime ApplicationCloseDate { get; set; }

    /// <summary>
    /// Duration of the program.
    /// </summary>
    public string? Duration { get; set; }

    /// <summary>
    /// Program location.
    /// </summary>
    public ProgramLocation Location { get; set; }

    /// <summary>
    /// Minimum qualification required for candidates.
    /// </summary>
    public Qualifications? MinQualification { get; set; }

    /// <summary>
    /// Maximum number of applications allowed for the program.
    /// </summary>
    public int? MaxApplications { get; set; }
}
