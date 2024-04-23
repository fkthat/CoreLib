namespace FkThat.CoreLib;

/// <summary>
/// Represents a clock.
/// </summary>
public interface IClock
{
    /// <summary>
    /// Gets a <c cref="DateTimeOffset"/> object whose date and time are set to the current
    /// Coordinated Universal Time (UTC) date and time and whose offset is <c c="TimeSpan.Zero"/>.
    /// </summary>
    DateTimeOffset UtcNow { get; }

    /// <summary>
    /// Gets a <see cref="TimeZoneInfo"/> object that represents the local time zone.
    /// </summary>
    TimeZoneInfo LocalTimeZone { get; }
}
