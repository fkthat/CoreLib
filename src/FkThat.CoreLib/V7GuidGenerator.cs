namespace FkThat.CoreLib;

/// <summary>
/// Sequential (V7) GUID generator.
/// </summary>
/// <param name="clock">The clock.</param>
/// <param name="random">The random generator.</param>
public sealed class V7GuidGenerator(IClock clock, IRandomGenerator random) : IGuidGenerator
{
    private static readonly DateTimeOffset UnixEpoche =
        new(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);

    private readonly IV7GuidSeq _seq = V7GuidSeq.Singleton;

    /// <summary>
    /// The constructor for unit tests.
    /// </summary>
    internal V7GuidGenerator(IClock clock, IRandomGenerator random, IV7GuidSeq seq)
        : this(clock, random)
    {
        _seq = seq;
    }

    /// <inheritdoc/>
    public Guid NewGuid()
    {
        uint a = 0;
        ushort b = 0;
        ushort c = 0;
        Span<byte> d = stackalloc byte[8];

        var unixTicks = clock.UtcNow.Ticks - UnixEpoche.Ticks;
        var unixts = unixTicks / TimeSpan.TicksPerSecond;
        var fullMsec = unixTicks / TimeSpan.TicksPerMillisecond;
        ushort seq = 0;
        _seq.CompareAjust(ref fullMsec, ref seq);
        var msec = fullMsec % 1000;

        a = (uint)(unixts >> 4);
        b = (ushort)(((unixts & 0x0f) << 12) | (msec & 0x0fff));
        c = (ushort)(0x7000 | seq);

        random.GetBytes(d);
        var d0 = (byte)((d[0] & 0x3f) | 0x80);
        return new(a, b, c, d0, d[1], d[2], d[3], d[4], d[5], d[6], d[7]);
    }
}
