using System.Security.Cryptography;

namespace FkThat.CoreLib;

public class V7GuidGeneratorTests
{
    private static readonly DateTimeOffset UnixEpoche =
        new(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);

    [Theory]
    [InlineData(
        0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
        "00000000-0000-7000-8000-000000000000")]
    [InlineData(
        0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff,
        "00000000-0000-7000-bfff-ffffffffffff")]
    [InlineData(
        0xc7, 0xb8, 0xd8, 0x4b, 0xe0, 0x41, 0xac, 0x8e,
        "00000000-0000-7000-87b8-d84be041ac8e")]
    public void NewGuid_sets_correct_DEFGHIJK(
        byte d, byte e, byte f, byte g,
        byte h, byte i, byte j, byte k,
        Guid expected)
    {
        var bytes = new[] { d, e, f, g, h, i, j, k };

        var clock = A.Fake<IClock>();
        var random = A.Fake<RandomGen>();
        var seq = A.Fake<IV7GuidSeq>();

        A.CallTo(() => clock.UtcNow).Returns(UnixEpoche);
        A.CallTo(() => random.GetBytes()).Returns(bytes);

        V7GuidGenerator sut = new(clock, random, seq);
        var actual = sut.NewGuid();

        actual.Should().Be(expected);
    }

    [Theory]
    [InlineData(0, "00000000-0000-7000-8000-000000000000")]
    [InlineData(
        (137438953471L * TimeSpan.TicksPerSecond) +
            (999 * TimeSpan.TicksPerMillisecond),
        "ffffffff-f3e7-7000-8000-000000000000")]
    [InlineData(
        (42L * TimeSpan.TicksPerSecond) +
            (69L * TimeSpan.TicksPerMillisecond),
        "00000002-a045-7000-8000-000000000000")]
    public void NewGuid_sets_correct_AB(long ticks, Guid expected)
    {
        var clock = A.Fake<IClock>();
        var random = A.Fake<RandomGen>();
        var seq = A.Fake<IV7GuidSeq>();

        A.CallTo(() => clock.UtcNow).Returns(UnixEpoche.AddTicks(ticks));
        A.CallTo(() => random.GetBytes()).Returns(new byte[8]);

        V7GuidGenerator sut = new(clock, random, seq);
        var actual = sut.NewGuid();

        actual.Should().Be(expected);
    }

    [Fact]
    public void NewGuid_sets_correct_C()
    {
        var clock = A.Fake<IClock>();
        var random = A.Fake<RandomGen>();
        var gseq = A.Fake<IV7GuidSeq>();

        var ticks = (42 * TimeSpan.TicksPerSecond) + (69 * TimeSpan.TicksPerMillisecond);

        A.CallTo(() => clock.UtcNow).Returns(UnixEpoche.AddTicks(ticks));
        A.CallTo(() => random.GetBytes()).Returns(new byte[8]);

        var fullMsec = ticks / TimeSpan.TicksPerMillisecond;
        ushort seq = 0;
        A.CallTo(() => gseq.CompareAjust(ref fullMsec, ref seq))
            .AssignsOutAndRefParameters(fullMsec, (ushort)73);

        V7GuidGenerator sut = new(clock, random, gseq);
        var actual = sut.NewGuid();

        actual.Should().Be(new Guid("00000002-a045-7049-8000-000000000000"));
    }

    [Fact]
    public void NewGuid_returns_uniques()
    {
        var clock = A.Fake<IClock>();
        var random = A.Fake<RandomGen>();

        A.CallTo(() => clock.UtcNow).ReturnsLazily(() => DateTimeOffset.UtcNow);
        A.CallTo(() => random.GetBytes()).ReturnsLazily(() => RandomNumberGenerator.GetBytes(8));

        V7GuidGenerator sut = new(clock, random, V7GuidSeq.Singleton);

        Enumerable.Repeat(0, 42).Select(_ => sut.NewGuid())
            .Should().OnlyHaveUniqueItems();
    }

    [Fact]
    public void NewGuid_returns_ordered()
    {
        var clock = A.Fake<IClock>();
        var random = A.Fake<RandomGen>();

        A.CallTo(() => clock.UtcNow).ReturnsLazily(() => DateTimeOffset.UtcNow);
        A.CallTo(() => random.GetBytes()).ReturnsLazily(() => RandomNumberGenerator.GetBytes(8));

        V7GuidGenerator sut = new(clock, random, V7GuidSeq.Singleton);

        Enumerable.Repeat(0, 42).Select(_ => sut.NewGuid())
            .Should().BeInAscendingOrder();
    }
}

public class V7GuidSeqTests
{
    [Fact]
    public void CompareAjust_resets_seq()
    {
        V7GuidSeq sut = new(42, 69);

        var msec = 43L;
        ushort seq = 0;
        sut.CompareAjust(ref msec, ref seq);

        msec.Should().Be(43L);
        seq.Should().Be(0);

        sut.Msec.Should().Be(43L);
        sut.Seq.Should().Be(0);
    }

    [Fact]
    public void CompareAjust_increses_seq()
    {
        V7GuidSeq sut = new(42, 69);

        var msec = 42L;
        ushort seq = 0;
        sut.CompareAjust(ref msec, ref seq);

        msec.Should().Be(42L);
        seq.Should().Be(70);

        sut.Msec.Should().Be(42L);
        sut.Seq.Should().Be(70);
    }
}

abstract file class RandomGen : IRandomGenerator
{
    public abstract byte[] GetBytes();

    public void GetBytes(Span<byte> data) => new Span<byte>(GetBytes()).CopyTo(data);
}
