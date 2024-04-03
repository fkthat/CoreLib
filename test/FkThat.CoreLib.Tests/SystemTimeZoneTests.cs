namespace FkThat.CoreLib;

public class SystemTimeZoneTests
{
    [Fact]
    public void Local_returns_local_time_zone()
    {
        SystemTimeZone sut = new();
        sut.Local.Should().Be(TimeZoneInfo.Local);
    }
}
