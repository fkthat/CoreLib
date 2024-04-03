namespace FkThat.CoreLib;

/// <summary>
/// Provides access to the local <see cref="TimeZoneInfo"/>.
/// </summary>
public interface ITimeZone
{
    /// <summary>
    /// Gets a <see cref="TimeZoneInfo"/> object that represents the local time zone.
    /// </summary>
    TimeZoneInfo Local { get; }
}
