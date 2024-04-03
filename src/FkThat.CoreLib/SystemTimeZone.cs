namespace FkThat.CoreLib;

/// <inheritdoc/>
public class SystemTimeZone : ITimeZone
{
    /// <inheritdoc/>
    public TimeZoneInfo Local => TimeZoneInfo.Local;
}
