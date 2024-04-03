namespace FkThat.CoreLib;

/// <summary>
/// Abstract GUID generator.
/// </summary>
public interface IGuidGenerator
{
    /// <summary>
    /// Initializes a new instance of the System.Guid structure.
    /// </summary>
    /// <returns>A new GUID object.</returns>
    Guid NewGuid();
}
