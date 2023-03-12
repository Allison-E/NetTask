namespace NetTask.Domain.Models;

/// <summary>
/// Represents a program.
/// </summary>
public class Program: Entity, IAuditableEntity
{
    /// <summary>
    /// Title of the program.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Summary of the program.
    /// </summary>
    public string? Summary { get; set; }

    /// <summary>
    /// More information about the program.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Skills needed for program participants.
    /// </summary>
    public IList<string>? KeySkills { get; set; }

    /// <summary>
    /// Benefits of the programme.
    /// </summary>
    /// <remarks>May contain rich text.</remarks>
    public string? Benefits { get; set; }

    /// <summary>
    /// Candidate requirement to enter the program.
    /// </summary>
    public string? Criteria { get; set; }

    /// <inheritdoc/>
    public DateTime Created { get; set; }

    /// <inheritdoc/>
    public DateTime Modified { get; set; }

    /// <summary>
    /// Concurrency token.
    /// </summary>
    public string ETag { get; set; }

    /// <summary>
    /// Additional information 
    /// </summary>
    public AdditionalProgramInformation AdditionalInfo { get; set; }
}
