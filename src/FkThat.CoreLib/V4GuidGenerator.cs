namespace FkThat.CoreLib;

/// <summary>
/// System (V4) GUID generator.
/// </summary>
public sealed class V4GuidGenerator : IGuidGenerator
{
    ///<inheritdoc/>
    public Guid NewGuid() => Guid.NewGuid();
}
