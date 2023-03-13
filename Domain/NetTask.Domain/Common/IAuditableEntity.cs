namespace NetTask.Domain.Common;

/// <summary>
/// An auditable entity.
/// </summary>
public interface IAuditableEntity
{
    /// <summary>
    /// Creation date.
    /// </summary>
    public DateTime Created { get; set; }

    /// <summary>
    /// Last modification date.
    /// </summary>
    public DateTime Modified { get; set; }
}
