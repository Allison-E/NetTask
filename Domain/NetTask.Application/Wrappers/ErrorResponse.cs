namespace NetTask.Application.Wrappers;

/// <summary>
/// Response sent if an error occurred.
/// </summary>
public class ErrorResponse
{
    /// <summary>
    /// Status code.
    /// </summary>
    public int Status { get; set; }

    /// <summary>
    /// Error message.
    /// </summary>
    public string Message { get; set; }
}
