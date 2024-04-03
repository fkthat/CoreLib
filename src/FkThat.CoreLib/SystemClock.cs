namespace FkThat.CoreLib;

/// <summary>
/// Represents the system clock.
/// </summary>
public sealed class SystemClock : IClock
{
    /// <inheritdoc/>
    public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
}
