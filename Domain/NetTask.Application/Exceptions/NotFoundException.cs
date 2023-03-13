namespace NetTask.Application.Exceptions;

/// <summary>
/// The exception that is thrown when a resource or object requested is not found.
/// </summary>
public class NotFoundException: Exception
{
    /// <summary>
    /// Creates an instance of the <see cref="NotFoundException"/>.
    /// </summary>
    public NotFoundException(string message) : base(message)
    {
    }

    /// <summary>
    /// Creates an instance of the <see cref="NotFoundException"/> with the default message,
    /// "Not found."
    /// </summary>
    public NotFoundException() : base("Not found.")
    {
    }
}
