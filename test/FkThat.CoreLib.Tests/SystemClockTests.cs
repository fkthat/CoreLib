namespace FkThat.CoreLib;

public class SystemClockTests
{
    [Fact]
    public async Task UtcNow_should_return_incremental_time()
    {
        SystemClock sut = new();

        List<DateTimeOffset> r = new();

        for (var i = 0; i < 16; i++)
        {
            r.Add(sut.UtcNow);
            await Task.Delay(1);
        }

        r.Should().BeInAscendingOrder();
    }

    [Fact]
    public void UtcNow_should_return_UTC_time()
    {
        SystemClock sut = new();
        sut.UtcNow.Offset.Should().Be(TimeSpan.Zero);
    }

    [Fact]
    public void Local_returns_local_time_zone()
    {
        SystemClock sut = new();
        sut.LocalTimeZone.Should().Be(TimeZoneInfo.Local);
    }
}
