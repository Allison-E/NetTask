namespace NetTask.Application.Exceptions;

/// <summary>
/// Respresents an error with model validations.
/// </summary>
public class ValidationException: Exception
{
    /// <summary>
    /// List of validation errors.
    /// </summary>
    public List<string> Errors { get; init; }

    /// <summary>
    /// Initialises a new instance of <see cref="ValidationException"/>.
    /// </summary>
    /// <param name="errors">The list of errors that occurred during validation.</param>
    /// <remarks>
    /// Has a default message of "Validation failure."
    /// </remarks>
    public ValidationException(List<string> errors) : this("Validation failure", errors) => Errors = errors;

    /// <summary>
    /// Initialises a new instance of <see cref="ValidationException"/> with the specified error message.
    /// </summary>
    /// <param name="message">An error message.</param>
    public ValidationException(string message, List<string> errors) : base(message) => Errors = errors;
}
