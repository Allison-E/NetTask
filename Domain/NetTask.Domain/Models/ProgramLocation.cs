namespace NetTask.Domain.Models;

/// <summary>
/// Location of the progarm.
/// </summary>
public class ProgramLocation
{
    /// <summary>
    /// Address.
    /// </summary>
    public string Address { get; set; }

    /// <summary>
    /// Indicates if the program is virtual.
    /// </summary>
    public bool IsRemote { get; set; }
}
